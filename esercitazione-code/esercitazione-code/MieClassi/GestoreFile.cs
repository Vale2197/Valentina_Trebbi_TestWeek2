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
            ArrayList arrayTasks = new ArrayList();

            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "task.txt");

                using (StreamReader sr = new StreamReader(path))
                {

                    string[] stringhe = File.ReadAllLines(path);

                    for (int i = 0; i < stringhe.Length; i++)
                    {
                        if (i > 0)
                        {
                            string taskPart = stringhe[i];
                            string[] taskParts = taskPart.Split('|');

                            Task taskDaFile = new Task();

                            taskDaFile.Description = taskParts[0];
                            taskDaFile.DataScadenza = DateTime.Parse(taskParts[1]);
                            taskDaFile.LivelloPriorita = int.Parse(taskParts[2]);

                            arrayTasks.Add(taskDaFile);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"La tua agenda al momento è vuota");
                Console.WriteLine();
            }

            return arrayTasks;
        }
    }
}
