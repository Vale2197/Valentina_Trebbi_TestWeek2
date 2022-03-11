using esercitazione_code.MieClassi;
using System;
using System.Collections;

namespace esercitazione_code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**GESTIONE AGENDA**");
            ArrayList iMieiTasks = new ArrayList();
            bool program = true;

            do
            {
                Task.PrintTasksMenu();
                int scelta = MyInput.LeggiNumero();

                switch (scelta)
                {
                    case 1:
                        Msg($"Aggiungi una descrizione: ");
                        string myDesc = Console.ReadLine();

                        Msg("Imposta data di scadenza (YYYY, MM, DD): ");
                        DateTime dataScadenza = Task.LeggiDataScadenza();

                        Msg("Ora imposta un livello di priorità, 1- basso, 2- medio, 3- alto");
                        int livello = Task.LeggiLivelloPriorita();

                        Task newTask = Task.CreaTask(myDesc, dataScadenza, livello);

                        iMieiTasks.Add(newTask);
                        break;
                    case 2:

                        Task.VerificaPresenzaTask(iMieiTasks);
                        break;
                    case 3:
                        Task.RimuoviTask(iMieiTasks);
                        break;
                    case 4:
                        Task.RicercaPerLivello(iMieiTasks);

                        break;
                    case 5:
                        program = false;

                        break;
                    default:
                        Msg("Scelta non valida..");
                        break;
                }

            } while (program);

        }

        public static void Msg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
