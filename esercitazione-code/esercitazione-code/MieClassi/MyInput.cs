using System;
using System.Collections.Generic;
using System.Text;

namespace esercitazione_code.MieClassi
{
    internal class MyInput
    {
        public static int LeggiNumero()
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num) || num < 0)
            {
                Console.WriteLine("inserisci numero");

            }

            return num;
        }


    }
}
