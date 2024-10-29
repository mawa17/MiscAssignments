using System;
using System.ComponentModel.DataAnnotations;

namespace C1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await UserRepository.LoadUsers();

            await UserRepository.SaveUsers();

        }

        #region Helper
        private static void PrintTitle(in string title)
        {
            Console.Clear();
            Console.WriteLine("".PadRight((Console.WindowWidth / 2) - (title.Length / 2), '=') + title.PadRight(Console.WindowWidth / 2 + (title.Length / 2), '='));
        }
        private static void PrintLine() => Console.WriteLine("".PadRight(Console.WindowWidth, '='));
        #endregion

    }
}
