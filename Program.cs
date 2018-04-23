using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Program { 
class cube
    {
        int a;
        int b;
        int c;
    public int vol()
            {
                return a * b * c;
            }
    public int pow()
            {
                return (2 * a * b) + (2 * a * c) + (2 * c * b);
            }
      public    cube(int a1,int b1, int c1)
        {
            a = a1;
            b = b1;
            c = c1;

        }
    }
        class stozek
        {
            float a;
            float b;
          
            public double vol()
            {
                return (3.141592653*a*a*b)/3;
            }
            public double pow()
            {
                return (3.141592653 * a * b*2);
            }
              public  stozek(int x, int y)
            {
                a = x;
                b = y;
               
            }
        }


        static void Main(string[] args)
        {
                for(int i=1; i>0;)
                {
                    int a = 0;
                    Console.WriteLine("Obliczanie powierzchni i objętości : 1 - stożka, 2 - prostopadłościanu");
                   a= Convert.ToInt32(Console.ReadLine());
                    if (a== 2)
                        {
                   
                            Console.WriteLine("Podaj po kolei wymiary prostopadłościanu");
                    cube c1 = new cube((Convert.ToInt32(Console.ReadLine())), (Convert.ToInt32(Console.ReadLine())), (Convert.ToInt32(Console.ReadLine())));
                    Console.WriteLine("objętość");
                    Console.WriteLine(c1.vol());
                    Console.WriteLine("powierzchnia");
                    Console.WriteLine(c1.pow());

                }
                 if (a ==1)
                    {
                    Console.WriteLine("Podaj po kolei wymiary stożka - promień, potem wysokość");
                    stozek s1 = new stozek( (Convert.ToInt32(Console.ReadLine())), (Convert.ToInt32(Console.ReadLine())));
                    Console.WriteLine("objętość");
                    Console.WriteLine( s1.vol());
                    Console.WriteLine("powierzchnia");
                    Console.WriteLine(    s1.pow());


                }



            }
        }
    }
}
