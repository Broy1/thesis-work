using System.Timers;

namespace FilterManagerPortal.Repository
{
    public class TimerService : ITimerService
    {
        private System.Timers.Timer timer;
        private IScanLogic _scanLogic;
        public TimerService(IScanLogic _scanlogic)
        {
            _scanLogic = _scanlogic;
            // will fire every 2 hours
            timer = new System.Timers.Timer(2 * 60 * 60 * 1000);
            timer.Elapsed += Timer_Elapsed;

            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _scanLogic.ScanDbForAllFilters();
        }
    }
}
