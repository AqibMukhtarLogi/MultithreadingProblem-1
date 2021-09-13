using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Problem_1_Multithreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateThread()
        {}
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int NumberOfThreads = rand.Next(1, 6);
            List<Thread> IOUs = new List<Thread>();

            for(int i = 1; i <= NumberOfThreads; i++)
            {
                Thread IOU = new Thread(new ThreadStart(CreateThread));
                IOUs.Add(IOU);
                IOU.Start();
            }

            while (IOUs.Any())
            {
                for(int i = 0; i < IOUs.Count; i++ )
                {
                    Thread IOU = IOUs.ElementAt(i);
                    if (IOU.IsAlive == false)
                    {
                        textBox1.AppendText("Hello from thread no: " + IOU.GetHashCode());
                        textBox1.AppendText(Environment.NewLine);
                        IOUs.Remove(IOU);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
