using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;


using System.IO;

using System.IO.Ports;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace loger_final
{
    public partial class Form1 : Form
    {
        komunikacja k2 = new komunikacja();
        zapis z2 = new zapis();

        public Form1()
        {
           
            InitializeComponent();
            




        }

      

       public void Form1_Load(object sender, EventArgs e)
        {
            string[] porty = SerialPort.GetPortNames();

            int i = 0;
            foreach (string port in porty)
            {
                listBox1.DataSource= porty;

                i++;
            }

            string[] vs = { "w dół", "w górę" };
            listBox2.DataSource = vs;
            textBox1.Text = "c:/log/log.txt";
            textBox2.Text = "0";
            button2.Enabled=false;
            button3.Enabled = false;
                button4.Enabled = false;
            button5.Enabled = false;
        }

        public void button1_Click(object sender, EventArgs e)
        {
           
            
            label5.Text= ( k2.rs(listBox1.SelectedItem.ToString())/10).ToString();
            button3.Enabled = true;
         
           
        }

        public void button2_Click(object sender, EventArgs e)
        {
           
            System.Timers.Timer aTimer;
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;



            void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs d)
            {
               
                z2.dopisz(k2.Sprawdz(Convert.ToString(d.SignalTime)));
                temp();
                wykres(Convert.ToString(d.SignalTime), k2.akttemp()/10);

            }

        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void wykres(string x, double y)
        {
            this.chart1.Series["T"].Points.AddXY(x,y);
         
            
        }
        public void button4_Click(object sender, EventArgs e)
        {
            
            
            k2.kierunek(listBox2.SelectedIndex);
            button5.Enabled = true;

    }

        public void button3_Click(object sender, EventArgs e)
        {
           
            
            z2.utworz(textBox1.Text);
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            k2.nastawa (Int32.Parse(textBox2.Text));
            button2.Enabled = true;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

     
        public void temp()
        {
            label5.Text = (((k2.akttemp() / 10).ToString() + "C"));
        }

        private void label5_Click(object sender, EventArgs e)

        {
           
            //  label5.Text = (((k2.akttemp() / 10).ToString() + "C"));
        }

        
    }

    public class komunikacja
    {
        int t;
        int k;
        string naz;
        public void sprawdzporty()
        {
            {
                string[] porty = SerialPort.GetPortNames();

                int i = 0;
                foreach (string port in porty)
                {
                    Console.WriteLine(port);
                    i++;
                }

            }
        }
        public float rs(string a)
        {
            if (a != null)
            {
                float xx;
                SerialPort port = new SerialPort(a,
                        9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.WriteLine("1");
                xx= float.Parse(port.ReadLine());
                port.WriteLine("3");
                port.WriteLine("5");
                port.WriteLine("7");
                port.Close();
                naz = a;
                return xx;
            }
            return 0;
        }
        public int nastawa(int b)
        {
            t = b;
            return t;
        }
        public void kierunek(int b)
        {
            k = b;

        }
        public string Sprawdz(string str)
        {

            int temp;
            SerialPort port1 = new SerialPort(naz,
                   9600, Parity.None, 8, StopBits.One);
                   port1.Close();
            port1.Open();
            port1.WriteLine("1");

            temp = Int32.Parse(port1.ReadLine());
            port1.Close();
            if (k == 0)
            {
                if (temp < (t * 10))
                {
                    port1.Open();
                    port1.WriteLine("4");
                    port1.WriteLine("6");
                    port1.Close();
                    return ((Convert.ToString(temp / 10)) + " " + str);
                }

            }
            if (k == 1)
            {
                if (temp > (t * 10))
                {
                    port1.Open();
                    port1.WriteLine("2");
                    port1.WriteLine("6");
                    port1.Close();
                    return ((Convert.ToString(temp / 10)) + " " + str);
                }

            }
            port1.Open();
            port1.WriteLine("7");
            port1.WriteLine("3");
            port1.WriteLine("5");
            port1.Close();
            return "a";
        }

       public float akttemp()
        {
            float temp;
            SerialPort port1 = new SerialPort(naz,
                   9600, Parity.None, 8, StopBits.One);
            port1.Open();
            port1.WriteLine("1");

            temp = float.Parse(port1.ReadLine());
            port1.Close();
            
            return temp;
        }
    }

    class zapis
    {
        string naz;
        public void utworz(string n)
        {
            naz = n;
            if (!File.Exists(n))
            {
                File.CreateText(n);
                


            }
        }

        public void dopisz(string s)

        {





            StreamWriter sw = new StreamWriter(naz, append: true);
            // StreamWriter sw = File.CreateText(naz);
            if (s != "a")
            {
                sw.WriteLine(s, "/n");
            }

            sw.Close();




        }
    }


    /*  public class czasomierz
       {


           public void start()

           {


               Timer czas = new System.Timers.Timer();
               czas.Interval = 2000;
               czas.Elapsed += TimedEvent;
               czas.AutoReset = true;

               czas.Enabled = true;
           }
              public  void TimedEvent(Object source, System.Timers.ElapsedEventArgs e)
               {
                   Console.WriteLine("czas", e.SignalTime);


               }



       }
       */






   
   


}







