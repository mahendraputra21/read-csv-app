using ReadCsvConsoleApp.Class;
using ReadCsvConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadCsvConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Ask user for CSV file path
            Console.Write("Enter the path to the CSV file: ");
            string filePath = Console.ReadLine();

            try
            {
                // Read the CSV file into a list of records using the CSV reader interface
                ICsvReader csvReader = new CsvReader();
                List<Record> records = csvReader.ReadCsv(filePath);

                // Compute statistics
                int totalRecords = records.Count;
                int invalidEmails = records.Count(r => !CsvValidation.IsValidEmail(r.Email));
                int invalidPhones = records.Count(r => !CsvValidation.IsValidPhone(r.Phone));
                int futureBirthdays = records.Count(r => r.Birthday > DateTime.Now);
                int longNames = records.Count(r => r.Name.Length > 50);

                // Output statistics to console
                Console.WriteLine($"Total records: {totalRecords}");
                Console.WriteLine($"Invalid emails: {invalidEmails}");
                Console.WriteLine($"Invalid phones: {invalidPhones}");
                Console.WriteLine($"Future birthdays: {futureBirthdays}");
                Console.WriteLine($"Long names: {longNames}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Wait for user to press a key before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
