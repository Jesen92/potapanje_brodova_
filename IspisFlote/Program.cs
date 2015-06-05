using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PotapanjeBrodova;

namespace IspisFlote
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Brodograditelj b = new Brodograditelj(10, 10, duljineBrodova);
            var flota = b.SložiFlotu();
            Console.WriteLine(flota);

            Console.ReadKey();
        }
    }
}
