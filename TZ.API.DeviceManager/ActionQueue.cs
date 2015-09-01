using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TZ.API.DeviceManagement
{
    class ActionQueue
    {
        private Thread _thread;
        private AutoResetEvent _waitHandler = new AutoResetEvent(false);

        private Queue<Action>[] _queues = new Queue<Action>[10];

        public ActionQueue()
        {
            for (int i = 0; i < _queues.Length; i++)
            {
                _queues[i] = new Queue<Action>();
            }
        }

        public void Start()
        {
            this._thread = new Thread(this.Execute) { Priority = ThreadPriority.Lowest, IsBackground = true };
            this._thread.Start();
        }

        public void Stop()
        {
            this._thread.Abort();
        }

        private void Execute()
        {
            while (true)
            {
                _waitHandler.WaitOne();
                Action action;
                do
                {
                    action = Peek();
                    if (action != null)
                    {
                        try
                        {
                            action();
                        }
                        catch
                        {

                            
                        }
                    }
                } while (action != null);
            }
        }

        private object _syncRoot = new object();

      
        private Action Peek()
        {
            Action rs = null;
            lock (_syncRoot)
            {
                foreach (Queue<Action> queue in this._queues)
                {
                    if (queue.Count > 0)
                    {
                        rs = queue.Dequeue();
                        break;
                    }
                }
            }

            return rs;


        }

       

        public void Add(Action action, int priority)
        {
            lock (_syncRoot)
            {
                this._queues[priority].Enqueue(action);
            }
            this._waitHandler.Set();
        }
    }
}
