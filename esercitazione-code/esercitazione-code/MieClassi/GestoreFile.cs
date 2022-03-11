using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace esercitazione_code.MieClassi
{
    internal class GestoreFile
    {
        public static void ScritturaTasksSuFile(ArrayList myArray)
        {
            string myPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "task.txt");

            using (StreamWriter sw = new StreamWriter(myPath))
            {
                sw.WriteLine("Descrizione | data di scadenza | livelloPriorità");
                foreach (Task task in myArray)
                {
                    sw.WriteLine($"{task.Description} | {task.DataScadenza} | {task.LivelloPriorita}");
                }
            }

        }

        public static ArrayList LetturaDaFile()
        {
            ArrayList myArray = new ArrayList();

            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "task.txt");

                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.ReadLine() != null)
                    {
                        myArray.Add(sr.ReadLine());
                        sr.ReadLine();

                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"non esistono ancora task registrati..");
            }

            return myArray;
        }
    }
}
