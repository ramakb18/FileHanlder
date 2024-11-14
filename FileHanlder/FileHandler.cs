using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHanlder
{
    public class FileHandler
    
        {
            private const string FolderPath = "Files";
            private const string FilePath = FolderPath + "/Users.txt";

            public FileHandler()
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                if (!File.Exists(FilePath))
                {
                    File.Create(FilePath).Dispose();
                }
            }

            public void RegisterUser(string firstName, string lastName, int age, string email)
            {
                ValidateInput(firstName, lastName, age, email);

                try
                {
                    string userInfo = $"{firstName} {lastName}, {age}, {email}";
                    File.AppendAllText(FilePath, userInfo + Environment.NewLine);
                    Console.WriteLine("Bruger registreret!");

                    DisplayRegisteredUsers();
                }
                catch (FileLoadException ex)
                {
                    Console.WriteLine($"Kunne ikke indlæse filen: {ex.Message}");
                }
            }

            private void ValidateInput(string firstName, string lastName, int age, string email)
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                    throw new InvalidNameException();

                if (age < 18 || age > 50)
                    throw new InvalidAgeException();

                if (!email.Contains("@") || !email.Contains("."))
                    throw new InvalidEmailException("E-mailen skal indeholde '@' og '.'.", new Exception("Ugyldig e-mail format."));
            }

            public void DisplayRegisteredUsers()
            {
                try
                {
                    string[] users = File.ReadAllLines(FilePath);
                    Console.WriteLine("Registrerede brugere:");
                    foreach (string user in users)
                    {
                        Console.WriteLine(user);
                    }
                }
                catch (FileLoadException ex)
                {
                    Console.WriteLine($"Kunne ikke læse filen: {ex.Message}");
                }
            }
        }
}
