using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AlarmClock
{
    class Program
    {
        public delegate void Task(AlarmEventArgs args);

        public class AlarmEventArgs
        {
            public int Hour { get; set; }
            public int Minute { get; set; }
            public int Second { get; set; }
        }
        public class AlarmClock     //事件发布类
        {
            public event Task Tick;
            public event Task Alarm;
            //闹铃时间
            public int setHour { get; set; }
            public int setMinute { get; set; }
            
            public void OnTick()
            {
                while (true)
                {
                    AlarmEventArgs args = new AlarmEventArgs()
                    {
                        Hour = DateTime.Now.Hour,
                        Minute = DateTime.Now.Minute,
                        Second = DateTime.Now.Second
                    };
                    //触发Tick事件
                    Tick(args);
                    if (args.Hour == setHour && args.Minute == setMinute)
                    {
                        OnAlarm(setHour, setMinute);
                    }
                    Thread.Sleep(1000);

                }
            }
            public void OnAlarm(int x,int y)
            {
                AlarmEventArgs args = new AlarmEventArgs()
                {
                    Hour = x,
                    Minute = y
                };
                
                    //触发Alarm事件
                    Alarm(args);
                
            }
        }
        public class Settings    //闹钟事件订阅类
        {
            public AlarmClock ac1 = new AlarmClock();
            public Settings()
            {
                ac1.Tick += Ac_Tick1;
                ac1.Alarm += Ac_Alarm1;
            }
            public void Ac_Tick1(AlarmEventArgs args)
            {
                Console.WriteLine($"Tick:现在是{args.Hour}时 {args.Minute}分 {args.Second}秒");
            }
            public void Ac_Alarm1(AlarmEventArgs args)
            {
                Console.WriteLine($"现在是{args.Hour}时 {args.Minute}分!叮铃铃！");
            }
        }
        static void Main(string[] args)
        {
          
            Settings set1 = new Settings();
            set1.ac1.setHour = 10;
            set1.ac1.setMinute = 32;
            set1.ac1.OnTick();
        }
    }
}
