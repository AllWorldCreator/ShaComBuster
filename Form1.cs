using ShaComBuster.Properties;
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


namespace ShaComBuster
{
    public partial class ShaComBuster : Form
    {   
        string[] proce;
        int boost = 0;
        bool auto = false;
        string prname = "ShaderCompileWorker";
        public ShaComBuster()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                        
        }

        private void get_list()
        {
            var prior = ProcessPriorityClass.High;
            string priort;
            if (boost == 1)
            {
                prior = ProcessPriorityClass.High;
                priort = "High";
            }
            else if (boost == 2)
            {
                prior = ProcessPriorityClass.RealTime;
                priort = "RealTime";
            }
            else
            {
                prior = ProcessPriorityClass.AboveNormal;
                priort = "AboveNormal";
            }
            Process[] processes = Process.GetProcessesByName(prname);
            foreach (Process proc in processes)
            {
                button1.Text = "Changing Priority for: " + proc.Id + " To " + priort;
                proc.PriorityClass = prior;
                if (proc.PriorityClass == prior)
                {
                    button1.Text = "Boosted";

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            get_list();
            timer2.Enabled = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            boost = trackBar1.Value;
            //label5.Text = boost.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            get_list();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            auto = !auto;
            timer1.Enabled = auto;
            if (auto == true)
            {
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.LightSlateGray;
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                textBox1.Enabled = false;
                pictureBox1.Visible = true;
                
            }
            else
            {
                button1.BackColor = Color.LimeGreen;
                button2.BackColor = Color.IndianRed;
                button3.BackColor = Color.LightSteelBlue;
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                textBox1.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName(prname);
            foreach (Process proc in processes)
            {
                button1.Text = ("Changing Priority for: " + proc.Id + " To normal");
                proc.PriorityClass = ProcessPriorityClass.Normal;
                if (proc.PriorityClass == ProcessPriorityClass.Normal)
                {
                    button1.Text = "Normal";
                }
            }
            timer2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            prname = textBox1.Text;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button1.Text = "Boost!";
            timer2.Enabled = false;
        }
    }
}
