namespace FileHanlder
{
    public class Program
    
        {
            static void Main()
            {
                FileHandler fileHandler = new FileHandler();

                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nIndtast brugernavn og informationer til registrering:");

                        Console.Write("Fornavn: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Efternavn: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Alder: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("Alder skal være et gyldigt tal.");
                            continue;
                        }

                        Console.Write("E-mail: ");
                        string email = Console.ReadLine();

                        fileHandler.RegisterUser(firstName, lastName, age, email);
                    }
                    catch (InvalidNameException ex)
                    {
                        Console.WriteLine($"Fejl: {ex.Message}");
                    }
                    catch (InvalidAgeException ex)
                    {
                        Console.WriteLine($"Fejl: {ex.Message}");
                    }
                    catch (InvalidEmailException ex)
                    {
                        Console.WriteLine($"Fejl: {ex.Message} ({ex.InnerException?.Message})");
                    }
                    catch (FileLoadException ex)
                    {
                        Console.WriteLine($"Filfejl: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Uventet fejl: {ex.Message}");
                    }
                    finally
                    {
                        Console.WriteLine("Program afsluttes korrekt.");
                    }
                }
            }
        }
    }

