using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OD_Launcher.Resources;
using System.IO;
using System.Diagnostics;
using System;
using System.Threading;
namespace OD_Launcher
{
    public partial class Form1 : Form
    {

        Thread oThread;
        public Form1()
        {
            InitializeComponent();

           // lbl_Title = new Label();

            //lbl_Title.BackColor = Color.Black;
            //lbl_Title.ForeColor = Color.White;
            //lbl_Title.Text = "Orbital Drop Launcher";
            //lbl_Title.Location = new Point(375, 0);
            //this.Controls.Add(lbl_Title);


            Btn_Minimize.Click += new EventHandler(Resize);
            Btn_Exit.Click += new EventHandler(Exit);

            Output_Log.Clear();
            //The Folder to Access
            Updater updater = new Updater("OrbitalDrop",this);
            oThread = new Thread(new ThreadStart(updater.Get_CurrentDir));
            _Toggle_Play(false);
            oThread.Start();

        }
        public void Toggle_Play(bool enabled)
        {
            Invoke(new Action(() =>
            {
                _Toggle_Play(enabled);
            }));
        }

        void _Toggle_Play(bool enabled)
        {
            Btn_Play.Enabled = enabled;
        }




        public void UpdateProgress(float percent)
        {
            //The Below invokes the _AddText call from the Main THread. Otherwise Winforms Cries in pain
            Invoke(new Action(() =>
            {
                _UpdateProgress(percent);
            }));
        }
        void _UpdateProgress(float percent)
        {
            UpdateBar.Value = (int)(percent * 100);
        }

        public void AddText(string line)
        {
            //The Below invokes the _AddText call from the Main THread. Otherwise Winforms Cries in pain
            Invoke(new Action(() =>
            {
                _AddText(line);
            }));
        }
        void _AddText(string line)
        {
            Output_Log.ForeColor = Color.DodgerBlue;
      //      Output_Log.Text += (line + "\r\n");
            Output_Log.AppendText(line + "\r\n");
        }
        public void Resize(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked on Form Area");
            this.WindowState = FormWindowState.Minimized;
        }
        public void Exit(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked on Form Area");
            while(oThread.IsAlive) //Dont close till we are sure the thread is killed. 
                oThread.Abort();
  
            Application.Exit();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            
        }


        //Drag Form on Mouse Click :) V
        //http://stackoverflow.com/questions/30184/winforms-click-drag-anywhere-in-the-form-to-move-it-as-if-clicked-in-the-form
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }

                    return;
            }

            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Status_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Play_Click(object sender, System.EventArgs e)
        {
            Process process = new Process();
            string exePath = Find_Exe();
            process.StartInfo.FileName = exePath;
            //process.Start();

            process.Start();
        }



        //Need to find the first Exe in the directory.
        string Find_Exe()
        {
            string path = Directory.GetCurrentDirectory();

            string[] directories = Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories);

            //for (int i = 0; i < directories.Length; i++)
            //    _AddText(directories[i]);
            return directories[directories.Length - 1];


        }
    }
}
