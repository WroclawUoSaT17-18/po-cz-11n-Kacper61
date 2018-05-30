using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel;
using System.Data;
using System.Drawing;


using System.IO;

using System.IO.Ports;

namespace loger2
{
    class Program
    {
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
            public void rs(string a)
            {
                SerialPort port = new SerialPort(a,
                        9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.WriteLine("1");
                Console.WriteLine(port.ReadLine());
                port.WriteLine("3");
                port.WriteLine("5");
                port.WriteLine("7");
                port.Close();
                naz = a;
            }
            public void nastawa(int b)
            {
                t = b;

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
                        Console.WriteLine("Alarm "+ Convert.ToString(temp / 10));
                        return ((Convert.ToString(temp / 10)) + " " + str);

                        
                    }
                    port1.Open();
                    port1.WriteLine("7");
                    port1.WriteLine("3");
                    port1.WriteLine("5");
                    port1.Close();
                    return "a";

                }
                if (k == 1)
                {
                    if (temp > (t * 10))
                    {
                        port1.Open();
                        port1.WriteLine("2");
                        port1.WriteLine("6");
                        port1.Close();
                        Console.WriteLine("Alarm " + Convert.ToString(temp / 10));
                        return ((Convert.ToString(temp / 10)) + " " + str);
                       
                    }
                    port1.Open();
                    port1.WriteLine("7");
                    port1.WriteLine("3");
                    port1.WriteLine("5");
                    port1.Close();
                    return "a";
                }
                return "a";
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
                    //File.CreateText(n);
                    Console.WriteLine("log utworzony");


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







        public static void Main(string[] args)
        {



            komunikacja k1 = new komunikacja();
            zapis z1 = new zapis();
            Console.WriteLine("dostępne porty");
            k1.sprawdzporty();
            Console.WriteLine("Wpisz port, pod którym jest logger");
            k1.rs(Console.ReadLine());
            Console.WriteLine("Podaj temperaturę progową");
            k1.nastawa(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Podaj kierunek przekroczenia ( 1- w górę, 0 - w dół");
            k1.kierunek(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Podaj ścieżkę do logu w formacie c:\\log\\nazwalogu.txt");

            z1.utworz(Console.ReadLine());
            Timer aTimer;
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;

            
            Console.ReadLine();

            void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
            {
                //Console.WriteLine("czas {0}", e.SignalTime);
                z1.dopisz(k1.Sprawdz(Convert.ToString(e.SignalTime)));
            }

            /*    void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
            {
                Console.WriteLine("czas", e.SignalTime);
                    z1.dopisz(k1.Sprawdz());

            }
            */
            Console.ReadKey();




        }



    }
}





