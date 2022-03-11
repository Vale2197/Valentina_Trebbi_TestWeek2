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

            while (!DateTime.TryParse(Console.ReadLine(), out dataScadenza) || dataScadenza <= dataOggi)
            {
                Console.WriteLine("la data inserita non è corretta... non può essere minore della data attuale..");
            }

            return dataScadenza;
        }

        public static int LeggiLivelloPriorita()
        {
            int livello;

            while (!int.TryParse(Console.ReadLine(), out livello) || livello <= 0 || livello > 3)
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
            Console.WriteLine("5- Esci");

        }

        public static void StampaListaTask(ArrayList myTasks)
        {
            foreach (Task task in myTasks)
            {
                Console.WriteLine($"Indice task: {myTasks.IndexOf(task)}");
                task.StampaSingoloTask();
                Console.WriteLine();
            }
        }

        public static Task CreaTask(string myDesc, DateTime dataScadenza, int livello)
        {
            Task newTask = new Task();
            newTask.Description = myDesc;
            newTask.DataScadenza = dataScadenza;
            newTask.LivelloPriorita = livello;
            return newTask;
        }

        public static void VerificaPresenzaTask(ArrayList myTasks)
        {
            if (myTasks.Count > 0)
            {
                Task.StampaListaTask(myTasks);
            }
            else
            {
                Console.WriteLine("non ci sono task al momento..");
            }
        }

        public static ArrayList RimuoviTask(ArrayList myTasks)
        {


            if (myTasks.Count > 0)
            {
                StampaListaTask(myTasks);
                Console.WriteLine($"inserisci l'indice del task che vuoi rimuovere");
                int miaScelta = MyInput.LeggiNumero();

                if (miaScelta >= 0 && miaScelta < myTasks.Count)
                {

                    foreach (Task task in myTasks)
                    {
                        if (myTasks.IndexOf(task) == miaScelta)
                        {
                            myTasks.Remove(task);
                            Console.WriteLine("task rimosso");
                            return myTasks;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("non è stato trovato nessun task con questo indice..");
                }

            }
            else
            {
                Console.WriteLine("non ci sono task al momento..");

            }
            return myTasks;
        }

        public void StampaSingoloTask()
        {
            Console.WriteLine($"descrizione: {Description}");
            Console.WriteLine($"data di scadenza: {DataScadenza}");

            if (LivelloPriorita == 1)
            {
                Console.WriteLine($"Livello di priorità: {LivelloPriorita} (Basso)");
            }
            else if (LivelloPriorita == 2)
            {
                Console.WriteLine($"Livello di priorità: {LivelloPriorita} (Medio)");
            }
            else if (LivelloPriorita == 3)
            {
                Console.WriteLine($"Livello di priorità: {LivelloPriorita} (Alto)");
            }
           
        }

        public static void RicercaPerLivello(ArrayList myTask)
        {
            Console.WriteLine("inserisci un livello (1- basso, 2-medio, 3- alto)");
            int scelta = LeggiLivelloPriorita();
            ArrayList selezionePerLivello = new ArrayList();

            foreach (Task task in myTask)
            {
                if(task.LivelloPriorita == scelta)
                {
                    selezionePerLivello.Add(task);
                }
               
            }

            if(selezionePerLivello.Count > 0)
            {
                foreach(Task task in selezionePerLivello)
                {
                     task.StampaSingoloTask();
                    Console.WriteLine();
                }
               
            }
            else
            {
                Console.WriteLine("non ci sono task con questo livello..");
            }


        }
    }
}
