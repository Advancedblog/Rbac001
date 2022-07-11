using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Quartz;
using Quartz.Impl;

namespace Consol
{
    /// <summary>
    /// 触发器
    /// </summary>
    public class Program
    {
       
        static async Task Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 60000;
            timer.Enabled = true;
            //timer.Elapsed += Timer_Elapsed;
            #region 
            int a = 1;
            a = 2;
            int b = a;
            Console.WriteLine(b);

            Console.ReadLine();
            //string arr = "";
            //int[] arr2 = { };
            string[] arrTemp = { "22", "23", "24" }; 
            int[] arr1 = arrTemp.Select(s => Convert.ToInt32(s)).ToArray(); //第一种 转换
            int[] intArray;
            intArray = Array.ConvertAll<string, int>(arrTemp, s => int.Parse(s)); //第二种 转换
            foreach (var item in intArray)
            {
                Console.WriteLine(item);
            }
            #endregion

            //1,创建调度器  
            //ISchedulerFactory (调度程序工厂)
            //它的实现完成了基于文件内容SchedulerFactory创建实例的所有工作
            ISchedulerFactory scheduler2 = new StdSchedulerFactory();
            IScheduler scheduler1 = await scheduler2.GetScheduler();
            //2,创建Job
            //3,创建JobDetail
            var jobdetail = JobBuilder.Create<MyJob>().WithDescription("myJob").Build();
            //4,创建触发器
            var trigger = TriggerBuilder.Create().WithSimpleSchedule(build =>
            {
                build.WithInterval(TimeSpan.FromSeconds(1)).WithRepeatCount(0);  //FromSeconds（"每几秒执行一次"）  WithRepeatCount（"循环次数"）
            }).Build(); // Build 构造触发器
            //5.通过调度器调Task 并执行
            await scheduler1.ScheduleJob(jobdetail, trigger);
            await scheduler1.Start();
            Console.ReadLine();
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
