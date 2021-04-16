using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
          
        private static void dobavlenie(int n, int Pos)
        {
            ochered += n;        
        }
        private static void Umenshenie(int n, int Pos)
        {
            ochered -= n;           
        }
        private static bool end = false;
        public static int ochered = 0;
        public static void proizvoditel(int N)
        {          
            Random rand = new Random();
            bool sleep = false;
            while (end == false)
            {
                Thread.Sleep(200);
                if (ochered < 80)
                {
                    sleep = false;
                }
                else
                {
                    if (ochered > 100)
                    {
                        sleep = true;
                    }
                }
                if (!sleep)
                {
                    dobavlenie(rand.Next(1, 100), N);
                }
            }
        }
        public static void potrebitel(int Pos)
        {                                  
                Random rand = new Random();
                while ((end == false) || (ochered != 0))
            {
                Thread.Sleep(200);
                if (ochered > 0)
                    {
                        if (ochered > 100) { Umenshenie(rand.Next(1, 100), Pos); } else { Umenshenie(rand.Next(1, ochered), Pos); }
                    }               
            }         
        }

        public Form1()
        {
            InitializeComponent();
            Thread Proizv1, Proizv2, Proizv3;
            Proizv1 = new Thread(() => proizvoditel(0));
            Proizv2 = new Thread(() => proizvoditel(1));
            Proizv3 = new Thread(() => proizvoditel(2));
            Proizv1.Start();
            Proizv2.Start();
            Proizv3.Start();
            Thread.Sleep(100);
            Thread Potreb1, Potreb2;
            Potreb1 = new Thread(() => potrebitel(3));
            Potreb2 = new Thread(() => potrebitel(4));
            Potreb1.Start();
            Potreb2.Start();
            timer1.Start();          
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {        
           label1.Text = ochered.ToString();
            if ((end == true) && (ochered == 0))
            {
                label2.Text = "Программа завершилась)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            end = true;
            
        }
    }
}
