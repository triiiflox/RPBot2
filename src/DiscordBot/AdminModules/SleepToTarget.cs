using System;
using System.Threading;

namespace DiscordBot.AdminModules
{
    internal class SleepToTarget
    {
        private DateTime TargetTime;
        private Action MyAction;
        private int MinSleepMilliseconds;

        /// <summary>
        /// Sleep till TargetDate, then fire MyAction
        /// </summary>
        /// <param name="TargetDate">Date to wait till</param>
        /// <param name="MyAction">Action to fire</param>
        /// <param name="MinSleepMilliseconds">Optional minimal sleeptime [less ms is more proc%]</param>
        public SleepToTarget(DateTime TargetDate, Action MyAction, int MinSleepMilliseconds = 500)
        {
            this.TargetTime = TargetDate;
            this.MyAction = MyAction;
            this.MinSleepMilliseconds = MinSleepMilliseconds;
        }

        /// <summary>
        /// Start the Targeted Timer
        /// </summary>
        public void Start()
        {
            new Thread(new ThreadStart(ProcessTimer)).Start();
        }

        private void ProcessTimer()
        {
            DateTime Now = DateTime.Now; //set Now

            while (Now < TargetTime) //Check it time is in treshold
            {
                int SleepMilliseconds = (int)Math.Round((TargetTime - Now).TotalMilliseconds / 2); //sleep for 2/4 of the desired time
                Console.WriteLine(SleepMilliseconds); //Log sleeptime
                Thread.Sleep(SleepMilliseconds > MinSleepMilliseconds ? SleepMilliseconds : MinSleepMilliseconds); //Sleep no less then minimal
                Now = DateTime.Now; //reset Now
            }

            MyAction(); //Fire MyAction
        }
    }
}