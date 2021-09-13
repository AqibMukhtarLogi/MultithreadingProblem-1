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

        private delegate void PrintMessageDelegate(string threadId);

        private void PrintMessage(string threadId)
        {
            textBox1.AppendText("Hello from thread#: " + threadId);
            textBox1.AppendText(Environment.NewLine);
        }
        private void CreateThread()
        {
            textBox1.Invoke(new PrintMessageDelegate(PrintMessage), Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int NumberOfThreads = rand.Next(1, 6);
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < NumberOfThreads; i++)
            {
                threads.Add(new Thread(new ThreadStart(CreateThread)));
                threads[i].Start();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
