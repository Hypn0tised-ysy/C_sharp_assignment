using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_assignment
{
        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInput = textBox1.Text;
            bool success = int.TryParse(userInput, out int seconds);
            if (!success)
            {
                MessageBox.Show("请输入有效的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            countDownValue = seconds;

            label1.Text = $"开始计时：{countDownValue}秒后响铃";

            progressBar1.Maximum = seconds;
            progressBar1.Value = 0;

            clock = new Clock(seconds);
            clock.Tick += Clock_Tick;
            clock.Alarm += Clock_Alarm;
            clock.Start();
            //timer1.Start();
        }
        private void Clock_Tick(object sender, int remainingSeconds)
        {
            // 因为 Timer 事件可能在 UI 线程上触发，直接更新控件即可
            label1.Text = $"倒计时：{remainingSeconds}秒";
            // 更新 ProgressBar，已过时间 = 最大秒数 - 剩余秒数
            progressBar1.Value = progressBar1.Maximum - remainingSeconds;
        }

        // 处理 Clock 的 Alarm 事件（倒计时结束时触发）
        private void Clock_Alarm(object sender, EventArgs e)
        {
            label1.Text = "闹钟响了！";
            MessageBox.Show("叮铃铃~~~，时间到！", "提示");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            countDownValue--;
            label1.Text = "Tick: " + countDownValue;

            // 更新进度条：已经过去的时间 = (最大秒数 - 剩余秒数)
            int usedTime = progressBar1.Maximum - countDownValue;
            if (usedTime >= 0 && usedTime <= progressBar1.Maximum)
            {
                progressBar1.Value = usedTime;
            }

            // 如果倒计时到 0，响铃
            if (countDownValue <= 0)
            {
                timer1.Stop();
                label1.Text = "闹钟响了！";
                MessageBox.Show("叮铃铃铃~~~，闹钟响了！", "提示");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private int countDownValue;
        private Clock clock;
    }
 public class Clock
    {
        public delegate void TickEventHandler(object sender, int remainingSeconds);
        public event TickEventHandler Tick;

        public event EventHandler Alarm;

        private Timer timer;          // 使用 WinForms Timer 模拟计时
        private int remainingSeconds; 

        // 构造函数：传入倒计时总秒数
        public Clock(int seconds)
        {
            remainingSeconds = seconds;
            timer = new Timer();
            timer.Interval = 1000;  // 每 1 秒触发一次
            timer.Tick += Timer_Tick;
        }

        public void Start()
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--; 
            Tick?.Invoke(this, remainingSeconds);

            if (remainingSeconds <= 0)
            {
                timer.Stop();
                Alarm?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
