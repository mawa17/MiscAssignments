﻿using System;
using System.ComponentModel.DataAnnotations;

namespace C1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.CursorVisible = false;
            await UserRepository.LoadUsers();
            PrintTitle("Telephone Book Registrar");
            Console.WriteLine("Press (1) to add a new contact");
            Console.WriteLine("Press (2) to remove a contact");
            Console.WriteLine("Press (3) to edit a contact");
            Console.WriteLine("Press (4) to search after an contact");
            PrintLine();
            ConsoleKey key = Console.ReadKey().Key;
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
            }
            await UserRepository.SaveUsers();

        }

        #region Helper
        private static void PrintTitle(in string title)
        {
            Console.Clear();
            Console.WriteLine("".PadRight((Console.WindowWidth / 2) - (title.Length / 2), '=') + title.PadRight(Console.WindowWidth / 2 + (title.Length / 2), '='));
        }
        private static void PrintLine() => Console.WriteLine("".PadRight(Console.WindowWidth, '='));
        private static (string name, string number, string email) GetInput(bool skipName = false, bool skipNumber = false, bool skipEmail = false)
        {
            string name = String.Empty, number = String.Empty, email = String.Empty;
            if (!skipName)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                if(String.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty!");
                    return default;
                }
            }
            if (!skipNumber)
            {
                Console.Write("Enter number: ");
                number = Console.ReadLine();
                if (String.IsNullOrEmpty(number))
                {
                    Console.WriteLine("Number cannot be empty!");
                    return default;
                }
            }
            if (!skipEmail)
            {
                Console.Write("Enter email: ");
                email = Console.ReadLine();
                if (String.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email cannot be empty!");
                    return default;
                }
            }
            return (name, number, email);

        }
        #endregion

        private static void AddUser()
        {
            PrintTitle("Add Contact");
            var input = GetInput();
            var user = new User(input.name, input.name, input.email);
            UserRepository.AddUser(user);
            Console.WriteLine($"Successfully added user");
        }
        private static void RemoveUser()
        {
            PrintTitle("Remove Contact");
            var input = GetInput(skipNumber: true, skipEmail: true);
            var user = new User(input.name, null, null);
            var usr = UserRepository.GetUser(user);
            if(usr is null)
            {
                Console.WriteLine($"User not found");
                return;
            }
            UserRepository.RemoveUser(usr);
            Console.WriteLine($"Successfully removed user");
        }
        private static void EditUser()
        {
            PrintTitle("Edit Contact");
            var oldUser = GetInput(skipNumber: true, skipEmail: true);
            PrintTitle("Override Contact");
            var newUser = GetInput();
            bool sucess = UserRepository.EditUser(
                new(oldUser.name, oldUser.number, oldUser.email),
                new(newUser.name, newUser.number, newUser.email));

            Console.WriteLine(sucess ? $"Successfully editited user" : $"Failed to edit user");
        }
        private static void SearchUser()
        {
            PrintTitle("Search Contact");

            var input = GetInput(skipNumber: true, skipEmail: true);
            var user = new User(input.name, null, null);

            var users = UserRepository.SearchUsers(user);

            if (!users.Any())
            {
                Console.WriteLine("User not found");
                return;
            }

            const int pageSize = 10;
            int currentPage = 0;
            int totalPages = (int)Math.Ceiling(users.Count() / (double)pageSize);

            while (true)
            {
                Console.Clear();
                PrintTitle("Search Results - Page " + (currentPage + 1) + " of " + totalPages);

                var pagedUsers = users.GetUsers(pageSize, currentPage * pageSize);
                foreach (var usr in pagedUsers)
                {
                    Console.WriteLine($"Name: {usr.Name}, Number: {usr.Number}, Email: {usr.Email}");
                }

                Console.WriteLine("\nPress '>' for Next page, '<' for Previous page, or 'esc' to Exit.");

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        if (currentPage < totalPages - 1)
                            currentPage++;
                        else
                            Console.WriteLine("\nNo more pages.");
                        break;

                    case ConsoleKey.LeftArrow:
                        if (currentPage > 0)
                            currentPage--;
                        else
                            Console.WriteLine("\nYou're already on the first page.");
                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        Console.WriteLine("\nInvalid input. Please press '>', '<', or 'esc'.");
                        break;
                }
            }
        }


    }
}
