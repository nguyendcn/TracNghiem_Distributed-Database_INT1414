using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TracNghiem_CSDLPT.Share
{
    public static class TimerAction
    {
        private static List<Timer> _listTimer = new List<Timer>();
        private static int _timerAlive = 5000;

        public static void AddTimer(ElapsedEventHandler elapsedEvent)
        {
            Timer timer = new Timer();
            timer.Interval = _timerAlive;

            timer.Elapsed += elapsedEvent;

            timer.Elapsed += (sender, a) =>
            {
                timer.Stop();
                _listTimer.Remove(timer);
                timer.Dispose();
            };

            _listTimer.Add(timer);

            timer.Start();
        }

    }
}
