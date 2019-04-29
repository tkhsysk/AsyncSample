using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ysk.AsyncSample
{
    public class Hogehoge
    {
        public void Output(Action action)
        {
            action();
        }

        public async void CountUpAsync()
        {
            await Task.Run(() =>
            {
                for(int i=1; i<=3; i++)
                {
                    Thread.Sleep(1000);
                    Output(() => Debug.WriteLine(i.ToString()));
                }
            });

            // await後に実行される
            Debug.WriteLine("task end");
        }

        public void CountUp()
        {
            for(int i=1; i<=3; i++)
            {
                Thread.Sleep(1000);
                Debug.WriteLine(i.ToString());
            }
        }

        public void CountUp(object count)
        {
            for (int i = 1; i <= Convert.ToInt32(count); i++)
            {
                Thread.Sleep(1000);
                Debug.WriteLine(i.ToString());
            }
        }

        public string CountDown()
        {
            for (int i = 3; i >= 1; i--)
            {
                Thread.Sleep(1000);
                Debug.WriteLine(i.ToString());
            }

            return "DOWN";
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
