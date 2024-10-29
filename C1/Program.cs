using System;
using System.ComponentModel.DataAnnotations;

namespace C1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey loopKey = ConsoleKey.None;
            do
            {
                Console.CursorVisible = false;
                PrintTitle("Telefonbog Register");
                Console.WriteLine("Press (1) to add a contact");
                Console.WriteLine("Press (2) to remove a contact");
                Console.WriteLine("Press (3) to edit a contact");
                Console.WriteLine("Press (4) to search after an contact");
                PrintLine();
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1: AddUser(); break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2: RemoveUser(); break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3: EditUser(); break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4: SearchUser(); break;
                    default:
                        Console.WriteLine($"Sorry the selected option ({((char)key)}) isn't a valid option");
                        Console.WriteLine($"Hit enter to try again");
                        break;

                }
                loopKey = Console.ReadKey(true).Key;
            }
            while (loopKey == ConsoleKey.Enter);
        }

        private static void PrintTitle(in string title)
        {
            Console.Clear();
            Console.WriteLine("".PadRight((Console.WindowWidth / 2) - (title.Length / 2), '=') + title.PadRight(Console.WindowWidth / 2 + (title.Length / 2), '='));
        }
        private static void PrintLine() => Console.WriteLine("".PadRight(Console.WindowWidth, '='));



        private static (string name, string number, string email) GetInput(bool skipName = false, bool skipNumber = false, bool skipEmail = false)
        {
            string name = default, number = default, email = default;
            if(!skipName)
            {
                Console.Write("Write the name: ");
                name = Console.ReadLine();
                if (String.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Contact name cannot be empty!");
                    return default;
                }
            }

            if (!skipNumber)
            {
                Console.Write("Write the number: ");
                number = Console.ReadLine();
                if (String.IsNullOrEmpty(number))
                {
                    Console.WriteLine("Contact number cannot be empty!");
                    return default;
                }
            }

            if (!skipEmail)
            {
                Console.Write("Write the email: ");
                email = Console.ReadLine();
                if (String.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Contact email cannot be empty!");
                    return default;
                }
            }
            return (name, number, email);
        }

        private static void AddUser()
        {
            PrintTitle("Add Contact");
            var input = GetInput();
            User user = new User(input.name, input.number, input.email);
            if(!user.IsValid())
            {
                Console.WriteLine("The given data dosen't fit the required format!");
                return;
            }
            UserRepository.AddUser(user);
            Console.WriteLine("User successfully added");
        }


        private static void RemoveUser()
        {
            PrintTitle("Remove Contact");
            var input = GetInput(skipNumber: true, skipEmail: true);
            User user = new User(input.name, null, null);
            if (!user.IsValid())
            {
                Console.WriteLine("The given data dosen't fit the required format!");
                return;
            }
            UserRepository.RemoveUser(user);
            Console.WriteLine("User successfully removed");

        }

        private static void EditUser()
        {
            PrintTitle("Edit Contact");
            var input = GetInput(skipNumber: true, skipEmail: true);
            User user = new User(input.name, null, null);
            if (!user.IsValid())
            {
                Console.WriteLine("The given data dosen't fit the required format!");
                return;
            }
            PrintTitle("New Contact");
            var inputNew = GetInput(skipNumber: true, skipEmail: true);
            User userNew = new User(input.name, null, null);
            if (!userNew.IsValid())
            {
                Console.WriteLine("The given data dosen't fit the required format!");
                return;
            }
            UserRepository.EditUser(user, userNew);
        }

        private static void SearchUser()
        {
            PrintTitle("Search Contact");

        }

    }
}
