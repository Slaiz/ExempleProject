using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadTest
{
    public partial class MainForm : Form
    {
        private Worker _worker;
        private int ProgresOnPause;

        public MainForm()
        {
            InitializeComponent();

            btnResume.Enabled = false;
            btnStop.Enabled = false;

            btnStart.Click +=BtnStartOnClick;
            btnResume.Click +=BtnResumeOnClick;
            btnStop.Click +=BtnStopOnClick;
        }

        private void BtnResumeOnClick(object sender, EventArgs eventArgs)
        {
            btnStop.Enabled = true;

            _worker = new Worker();

            _worker.Progress = ProgresOnPause;

            _worker.ProcessChanged += WorkerOnProcessChanged;
            _worker.WorkCompleted += WorkerOnWorkCompleted;

            btnStart.Enabled = false;

            Thread thread = new Thread(_worker.Work);
            thread.Start();
        }

        private void WorkerOnResumeWork(int progress, bool canceled)
        {
            Action action = () =>
            {
                if (canceled == false ) MessageBox.Show("Procces has end");
                else MessageBox.Show("Procces has stop");

            };

            this.InvokeEx(action);
        }

        private void BtnStopOnClick(object sender, EventArgs eventArgs)
        {
            _worker.Cancel();
            btnResume.Enabled = true;
        }
        private void BtnStartOnClick(object sender, EventArgs eventArgs)
        {
            btnStop.Enabled = true;

            _worker = new Worker();

            _worker.ProcessChanged += WorkerOnProcessChanged;
            _worker.WorkCompleted +=WorkerOnWorkCompleted;

            btnStart.Enabled = false;

            Thread thread = new Thread(_worker.Work);
            thread.Start();
        }

        private void WorkerOnWorkCompleted(bool cancelled)
        {
            Action action = () =>
            {
                string message = cancelled ? "Procces stop" : "Procces end";

                MessageBox.Show(message);

                btnStart.Enabled = true;
            };

            this.InvokeEx(action);
        }

        private void WorkerOnProcessChanged(int progress)
        {
            Action action = () =>
            {
                progressBar.Value = progress + 1;
                progressBar.Value = progress;
                ProgresOnPause = progress;
            };

            this.InvokeEx(action);
        }



    }
}
