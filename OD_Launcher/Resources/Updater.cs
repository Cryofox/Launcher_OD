using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Threading;
using System.Diagnostics;


using System.Net;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using Google.Apis.Drive.v2.Data;


using OD_Launcher;

using GFile= Google.Apis.Drive.v2.Data.File ;

namespace OD_Launcher.Resources
{
    class Updater
    {
        Form1 winform;
        //ex OD_V...
        public Updater(string fileName, Form1 winform)
        { 
            //First Setup Connection
            //Sample_GDrive();
            this.winform = winform;
   
        }

        public void Get_CurrentDir()
        {
            Debug.WriteLine("Directory="+Directory.GetCurrentDirectory());
            
            //Check if a Folder named Orbital Drop Exists Here...if it doesn't create it.
            winform.AddText("Checking for Root Directory -Orbital Drop- \n");
            if (!Directory.Exists("./OrbitalDrop"))
            {
                winform.AddText("Directory was not found, creating -Orbital Drop-");
                Directory.CreateDirectory("OrbitalDrop");
            }
            winform.AddText("Checking latest Version on GDrive...");
            Engage_Update("OrbitalDrop");

            winform.AddText("Done. :)");
        }


        void Engage_Update(string parentFolder)
        {
            winform.AddText("Establishing Connection...");
            UserCredential credential;
            using (var filestream = new FileStream( Directory.GetCurrentDirectory()+"/Resources/client_secrets.json",
                FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(filestream).Secrets,
                    new[] { DriveService.Scope.Drive },
                    "user",
                    CancellationToken.None,
                    new FileDataStore("DriveCommandLineSample")).Result;
            }

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "OrbitalDrop_Launcher",
            });
            List<Google.Apis.Drive.v2.Data.File> result = new List<Google.Apis.Drive.v2.Data.File>();
        
            FilesResource.ListRequest request = service.Files.List();
            request.Q = "mimeType = 'application/vnd.google-apps.folder' and title = '" + parentFolder + "' and trashed=false";

            winform.AddText("Processing Query -Root-");
            try
            {
                FileList files = request.Execute();
                result.AddRange(files.Items);
            }
            catch (ThreadAbortException e)
            { return; }
            catch (Exception e)
            {
                winform.AddText("An error occurred: " + e.Message);
            }
            //Only 1 File is needed.
            string od_RootID = result[0].Id;
            winform.AddText("Root=" + result[0].Title);
            result.Clear();

            ChildrenResource.ListRequest children_request = service.Children.List(od_RootID);
            List<string> children_IDs = new List<string>();
            //Now that we have the folder ID we should be able to get the Children
            do
            {
                try
                {
                    ChildList children = children_request.Execute();
                    int i=0;
                    foreach (ChildReference child in children.Items)
                    {
                      //  winform.AddText("File Id ["+(i)+"]: " + child.Id);
   
                        children_IDs.Add(child.Id);
                        i++;
                    }
                    request.PageToken = children.NextPageToken;
                }
                catch (ThreadAbortException e)
                { return; }
                catch (Exception e)
                {
                    winform.AddText("An error occurred: " + e.Message);
                    request.PageToken = null;
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            winform.AddText("Folder Versions:");


            for (int i = 0; i < children_IDs.Count; i++)
            {
                winform.AddText(Get_Child_FolderName(service, children_IDs[i]));
            }

            //The First Entry pulled is the Most Recent Update
            CheckForUpdate(service, children_IDs[0]);
        }
        void CheckForUpdate(DriveService service, String folderId)
        {
            string curDIr = Directory.GetCurrentDirectory();

            GFile downloadFile = Get_File(service,folderId);

            if (Directory.Exists(curDIr + "\\OrbitalDrop\\" + downloadFile.Title))
            {
                //Update the Progress Bar
                winform.UpdateProgress(1); //The Folder is up to speed, no updates are required. :)
                winform.Toggle_Play(true);
                return;
            }
            else
            {
                winform.AddText(curDIr + "\\OrbitalDrop\\" + downloadFile.Title);
            }


            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo("./OrbitalDrop");
            Empty(directory);
            //winform.AddText("Dir=" + directory.ToString());
            winform.AddText("Clearing out Directory");

  
            
           
           Manual_FileCount(service, downloadFile.Id);
           winform.AddText("Total Files=" + fileCount);

           string rootDir = curDIr+"\\OrbitalDrop\\" + downloadFile.Title + "\\";
           Directory.CreateDirectory(rootDir);
           Manual_Download(service,downloadFile.Id, rootDir);
            //Now files can be downloaded in order in the directory :D

           winform.Toggle_Play(true);
        }
        int fileCount = 0;
        int progress = 0;
        //This function will 
        public void Manual_FileCount(DriveService service, string rootDirID)
        { 
            //Step 1 Get total file count
            ChildrenResource.ListRequest children_request = service.Children.List(rootDirID);
            List<string> children_IDs = new List<string>();
            //Now that we have the folder ID we should be able to get the Children
            do
            {
                try
                {
                    ChildList children = children_request.Execute();
                    int i = 0;
                    foreach (ChildReference child in children.Items)
                    {
                        //  winform.AddText("File Id ["+(i)+"]: " + child.Id);

                        children_IDs.Add(child.Id);
                        i++;
                    }
                    children_request.PageToken = children.NextPageToken;
                }
                catch (ThreadAbortException e)
                { return; }
                catch (Exception e)
                {
                    winform.AddText("An error occurred: " + e.Message);
                    children_request.PageToken = null;
                }
            } while (!String.IsNullOrEmpty(children_request.PageToken));


            //For each Child ID use that for parent
            for (int i = 0; i < children_IDs.Count; i++)
            {
                fileCount++;
                //winform.AddText("File=" + Get_Child_FolderName(service, children_IDs[i]));
                Manual_FileCount(service, children_IDs[i]);
            }
        }



        public void Manual_Download(DriveService service, string rootDirID, string currentDirectory)
        {
            //Step 1 Get total file count
            ChildrenResource.ListRequest children_request = service.Children.List(rootDirID);
            List<string> children_IDs = new List<string>();
            //Now that we have the folder ID we should be able to get the Children
            do
            {
                try
                {
                    ChildList children = children_request.Execute();
                    int i = 0;
                    foreach (ChildReference child in children.Items)
                    {
                        //  winform.AddText("File Id ["+(i)+"]: " + child.Id);

                        children_IDs.Add(child.Id);
                        i++;
                    }
                    children_request.PageToken = children.NextPageToken;
                }
                catch (ThreadAbortException e)
                { return; }
                catch (Exception e)
                {
                    winform.AddText("An error occurred: " + e.Message);
                    children_request.PageToken = null;
                }
            } while (!String.IsNullOrEmpty(children_request.PageToken));


            //For each Child ID use that for parent
            for (int i = 0; i < children_IDs.Count; i++)
            {       
                //Pass the CurrentDirectory to Download files
                string temp = currentDirectory +Get_Child_FolderName(service, children_IDs[i]);
                bool status = DownloadFile(service, Get_File(service,children_IDs[i]), temp);
                //if status fails odds are its a Directory. So make it Create a Temp string, and push that to the function
                if (!status)
                {
                    winform.AddText("Creating Directory:" + temp);
                    Directory.CreateDirectory(temp);
                    temp += "\\";
                    Manual_Download(service, children_IDs[i], temp);
                }

                IncrementProgress();
            }
        }

        //This is called with each pass.
        void IncrementProgress()
        {
            progress++;
            float percent = (float)(progress) / (float)(fileCount);
            winform.UpdateProgress(percent);
        }

  /*      public Boolean DownloadFile(DriveService service, GFile _fileResource, string _saveTo)
        {
            try {
                  //File file = service.Files.Get(fileId).Execute();
                FilesResource.GetRequest request = service.Files.Get(_fileResource.Id);
                request.url
                  return true;
                } 
            catch (Exception e) {
                return false;
                }
        }*/
        public Boolean DownloadFile(DriveService service, GFile _fileResource, string _saveTo)
        {
           
            GFile newFile = service.Files.Get(_fileResource.Id).Execute();
            if (!String.IsNullOrEmpty(_fileResource.DownloadUrl))
            {
                using (FileStream fs = System.IO.File.Create(_saveTo))
                {
                    //Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    
                    var x = service.HttpClient.GetByteArrayAsync(newFile.DownloadUrl);
                    byte[] arrBytes = x.Result;
                    //fs.WriteAllBytes(_saveTo, arrBytes);
                    fs.Write(arrBytes, 0, arrBytes.Length);
                    //fs.WriteAsync()
                    //fs.Write(arrBytes, 0, arrBytes.Length);
                    return true;
                }
            }
            else
            {
                // The file doesn't have any content stored on Drive.
                //winform.AddText("Error2");
                return false;
            }
            return false;
        }
        

        public void Empty(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }        



        string Get_Child_FolderName(DriveService service, String folderId)
        {

            string name = "_";
            try
            {
                GFile file = service.Files.Get(folderId).Execute();
                name = file.Title;
            }
            catch (Exception e)
            {
                winform.AddText("An error occurred: " + e.Message);
                //name = "! Wrong permissions mate";
            }
            return name;
        }
        GFile Get_File(DriveService service, String folderId)
        {

            string name = "_";
            GFile file=null;
            try
            {
                file = service.Files.Get(folderId).Execute();
                //Debug.WriteLine("File=" + file.Id);
                //winform.AddText(file.Id);
            }
            catch (Exception e)
            {
                winform.AddText("An error occurred: " + e.Message);
                //name = "! Wrong permissions mate";
            }

            return file;
        }
    }
}
