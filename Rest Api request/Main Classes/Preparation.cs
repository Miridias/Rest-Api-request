using Rest_Api_request.Interfaces;
using System;
namespace Rest_Api_request.Main_Classes
{
    class Preparation : IPreparation
    {
        public void Choice()
        {
            Request request = new();
            Console.WriteLine("Нажмите Enter чтобы сделать запрос на удаленный rest API");
            Console.WriteLine("Нажмите Esc для выхода");
            var result = Console.ReadKey();
            if (result.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("\nРезультат запроса:");
                request.ProcessingRequest();
            }
            else if (result.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\n_Завершение работы программы");
                Environment.Exit(0);
            }
            else Console.WriteLine($"\nВы ввели {result.Key}, такая операция отсутствует, повторите ввод\n");
            Choice();
        }
    }
}
