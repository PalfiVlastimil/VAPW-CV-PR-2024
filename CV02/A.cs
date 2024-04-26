using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV2
{

    class A // : object implicitní odvození
    {
        int cislo; // int je obalen structurou :O
        int cislo2;
        int cislo3;
        int cislo4;

        public int Cislo
        {
            get { return cislo; }
            set 
            { 
                if(value > 0 && value < 100)
                {
                    cislo = value; 

                }
            }
        }
        public double Cislo2 { get; set; }
        public double Cislo3 { get; private set; }//použití
        public int Cislo4 //jen getter, ne getter
        {
            get { return cislo + cislo2; }
        }

    }
}
