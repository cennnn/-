using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal class InputThread
    {
        private Thread thread;
        public event Action Func;
        private static InputThread Instance =new InputThread();
        public static InputThread inputThread { get { return Instance; } }
        private InputThread()
        {
            thread = new Thread(Start);
            thread.IsBackground = true;
            thread.Start();
        }
        private void Start()
        {
            while (true)
            {
                Func?.Invoke();
            }
        }
    }
}
