using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ysk.AsyncSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 実行結果
            // button end
            // 1
            // 2
            // 3
            // task end

            Hogehoge hoge = new Hogehoge();

            hoge.CountUpAsync();

            Debug.WriteLine("button end");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 実行結果
            // button end
            // 1
            // 2
            // 3

            Hogehoge hoge = new Hogehoge();

            Task task = new Task(hoge.CountUp);

            task.Start();

            Debug.WriteLine("button end");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 実行結果
            // 1
            // 1
            // 2
            // 2
            // button end ※画面操作可能になる
            // 3
            // 4
            // 5

            Hogehoge hoge = new Hogehoge();

            Task[] tasks = new Task[2];
            // 引数を指定
            tasks[0] = Task.Factory.StartNew(hoge.CountUp, 2);
            tasks[1] = Task.Factory.StartNew(hoge.CountUp, 5);

            //Task.WaitAll(tasks);
            Task.WaitAny(tasks);

            Debug.WriteLine("button end");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hogehoge hoge = new Hogehoge();

            // 戻り値
            Task<string> task = new Task<string>(hoge.CountDown);
            task.Start();

            // タスクが完了するまでWait
            // 画面操作できない
            string result = task.Result;

            Debug.WriteLine(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hogehoge hoge = new Hogehoge();

            // タスク→タスクの実行: 継続タスク
            Task<string> task = Task.Run(() => hoge.CountUp())
                .ContinueWith<string>(t => hoge.CountDown());

            //Debug.WriteLine(task.Result);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button100_Click(object sender, EventArgs e)
        {
            Hogehoge hoge = new Hogehoge();

            // 定義済みデリゲート（引数は最大16個もてる）
            // Action:戻り値なし
            // Func:戻り値あり
            Func<int, int, int> add = hoge.Add;
            Debug.WriteLine(add(1, 3));
        }
    }
}
