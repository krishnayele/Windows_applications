using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceDemo
{
    public class ICanDoIt
    {
        private readonly Timer _timer;
        public ICanDoIt()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += timer_Elapsed;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string[] line = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"E:\practice\C#\services\ICan.txt",line);
        }

        public void start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
