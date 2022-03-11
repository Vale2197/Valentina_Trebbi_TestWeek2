using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace esercitazione_code.MieClassi
{
    internal class Task
    {
        public string Description { get; set; }
        public DateTime DataScadenza { get; set; }
        public int LivelloPriorita { get; set; }


        public static DateTime LeggiDataScadenza()
        {
            DateTime dataScadenza;

            DateTime dataOggi = DateTime.Now;

            while (DateTime.TryParse(Console.ReadLine(), out dataScadenza) || dataScadenza <= dataOggi)
            {
                Console.WriteLine("la data inserita non è corretta... non può essere minore della data attuale..");
            }

            return dataScadenza;
        }

        public static int LeggiLivelloPriorita()
        {
            int livello;

            while (int.TryParse(Console.ReadLine(), out livello) || livello <= 0 || livello > 3)
            {
                Console.WriteLine("non corretto..il livello può essere 1(basso), 2(medio), 3(alto).. inserisci un numero");
            }

            return livello;
        }

        public static void PrintTasksMenu()
        {
            Console.WriteLine("1- Inserisci un nuovo Task");
            Console.WriteLine("2- Visualizza i tuoi Tasks");
            Console.WriteLine("3- Rimuovi un Task");
            Console.WriteLine("4- Cerca Task per livello di priorità (1-basso, 2-medio, 3-alto)");
            
        }

        public static void StampaListaTask(ArrayList myTasks) 
        {
            foreach (Task task in myTasks)
            {
                Console.WriteLine($"Descrizione: {task.Description}");
                Console.WriteLine($"Data di scadenza: {task.DataScadenza}");

                if(task.LivelloPriorita == 1)
                {
                    Console.WriteLine($"Livello di priorità: {task.LivelloPriorita} (Basso)");
                }
                else if (task.LivelloPriorita == 2)
                {
                    Console.WriteLine($"Livello di priorità: {task.LivelloPriorita} (Medio)");
                }
                else if (task.LivelloPriorita == 3)
                {
                    Console.WriteLine($"Livello di priorità: {task.LivelloPriorita} (Alto)");
                }
            }
        }
    }
}
