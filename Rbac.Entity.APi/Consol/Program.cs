using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Quartz;
using Quartz.Impl;
using static Quartz.Logging.OperationName;

namespace Consol
{
    public class Program
    {
       
        static async Task Main(string[] args)
        {

            //Timer timer = new Timer();
            //timer.Interval = 60000;
            //timer.Enabled = true;
            //timer.Elapsed += Timer_Elapsed;

            //1,创建调度器
            ISchedulerFactory scheduler2 = new StdSchedulerFactory();
            IScheduler scheduler1 = await scheduler2.GetScheduler();
            //2,创建Job
            //3,创建JobDetail
            var jobdetail = JobBuilder.Create<MyJob>().WithDescription("myJob").Build();
            //4,创建触发器
            var trigger = TriggerBuilder.Create().WithSimpleSchedule(build =>
            {
                build.WithInterval(TimeSpan.FromSeconds(1)).WithRepeatCount(10);  //FromSeconds（"每几秒执行一次"）  WithRepeatCount（"循环次数"）
            }).Build();
            //5.通过调度器调Task 并执行
            await scheduler1.ScheduleJob(jobdetail, trigger);
            await scheduler1.Start();

            Console.ReadLine();
            #region 
            //int a = 1;
            //a = 2;
            //int b = a;
            //Console.WriteLine(b);

            //Console.ReadLine();
            ////string arr = "";
            ////int[] arr2 = { };
            //string[] arrTemp = { "22", "23", "24" };
            //int[] arr1 = arrTemp.Select(s => Convert.ToInt32(s)).ToArray();
            //int[] intArray;
            //intArray = Array.ConvertAll<string, int>(arrTemp, s => int.Parse(s));
            //foreach (var item in intArray)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
        }
        /// <summary>
        /// 创建Job
        /// </summary>
        public class MyJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                Console.WriteLine(DateTime.Now);
            }
        }

        //private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Console.WriteLine(DateTime.Now.Second);
        //}
    }
}
