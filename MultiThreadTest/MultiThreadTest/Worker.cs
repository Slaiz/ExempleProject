using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadTest
{
    class Worker
    {
        private bool _cancelled=false;
        private int _progress;

        public int Progress {
            get { return _progress;  } 
            set { _progress = value; } 
        }

        public Worker()
        {
            Progress = 0;
        }

        public void Cancel()
        {
            _cancelled = true;
        }

        public void Resume()
        {
            _cancelled = false;
        }

        public void Work()
        {
            for ( ;_progress < 100; _progress++)
            {
                if (_cancelled)
                    break;

                Thread.Sleep(50);

                ProcessChanged?.Invoke(_progress);
            }

            WorkCompleted?.Invoke(_cancelled);
        }

        public event Action<int> ProcessChanged; 

        public event Action<bool> WorkCompleted;
    }
}
