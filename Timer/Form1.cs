using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace TIMER
{
    public partial class Form1 : Form
    {
        private int countdownDuration = 0; // Độ dài của đếm ngược (số giây)
        private System.Timers.Timer countdownTimer;

        public Form1()
        {
            InitializeComponent();
            //int timer1_left = ((int.Parse(textBox1.Text) * 24) + (int.Parse(textBox2.Text) * 60) + (int.Parse(textBox3.Text) * 60)) * 1000;
            //int timer1_left = Convert_Time_to_Second(int.Parse(textBox1.Text),int.Parse(textBox2.Text),int.Parse(textBox3.Text));
            //timer1.Tick += new EventHandler(timer1_Tick);
            countdownTimer = new System.Timers.Timer(1000); // Interval là 1 giây (1000ms)
            countdownTimer.Elapsed += CountdownTimerElapsed;
            countdownTimer.AutoReset = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private int Convert_Time_to_Second(string a, string b, string c)
        {

            return int.Parse(a) * 3600 + int.Parse(b) * 60 + int.Parse(c);
        }
        private string Convert_Second_to_Time(int x)
        {
            int h, m, s;
            h = x / 3600;
            m = (x % 3600) / 60;
            s = (x % 3600) % 60;
            string kq = h + " : " + m + " : " + s;
            return kq;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.timer1.Enabled == false)
            {
                this.timer1.Interval = 5000;
                this.timer1.Enabled = true;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           /* int timer1_left = Convert_Time_to_Second(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            if (timer1_left > 0) // 
            {
                timeLeft = timeLeft - 1; // decrement of timeleft on each tick
                hour = timeLeft / 3600; // Left hours
                min = (timeLeft - (hour * 3600)) / 60; //Left Minutes
                sec = timeLeft - (hour * 3600) - (min * 60); //Left Seconds
                hh.Text = hour.ToString(); // Setting hour Text on each timer tick
                mm.Text = min.ToString(); // Setting minutes Text on each timer tick
                ss.Text = sec.ToString(); // Setting sec Text on each timer tick
            }
            else
            {
                timer.Stop(); // Stop Timer
                Process.Start("shutdown", "/s /t 0"); // Shutdown PC when Time is over
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
                // Bắt đầu đếm ngược
            countdownDuration = Convert_Time_to_Second(textBox1.Text, textBox2.Text, textBox3.Text);
            countdownTimer.Start();
            button1.Enabled = false; // Tắt nút "Bắt đầu đếm ngược" sau khi đã bắt đầu
        }
        private void CountdownTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Giảm thời gian đếm ngược đi 1 giây
            countdownDuration--;

            // Hiển thị thời gian còn lại trên giao diện
            button1.Invoke((MethodInvoker)delegate
            {
                label7.Text = $" {Convert_Second_to_Time(countdownDuration)} giây";
            });
            string selectedValue = comboBox1.SelectedItem.ToString();
            // Kiểm tra nếu đếm ngược đã kết thúc
            if (countdownDuration == 0)
            {
                countdownTimer.Stop();
                
                switch(selectedValue)
                {
                    case "Shutdown":
                        MessageBox.Show("Shutdown");
                        break;
                    case "Log out":
                        MessageBox.Show("Log out");
                        break;
                    case "Restart":
                        MessageBox.Show("Restart");
                        break;  

                }

                //MessageBox.Show("Shutdown");
                // Tắt máy tính
                
                //Process.Start("shutdown", "/s /t 0");
            }
        }


    }
}
