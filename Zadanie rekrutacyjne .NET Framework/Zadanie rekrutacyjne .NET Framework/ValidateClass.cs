using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadanie_rekrutacyjne.NET_Framework
{
    public static class ValidateClass
    {
        //Checks if ISBN with 13 digits is valid
        public static bool CheckISBN13(string isbn)
        {
            isbn = isbn.Replace("-", "").Replace(" ", "");
            if (isbn.Length != 13) return false;
            int sum = 0;
            foreach (var (index, digit) in isbn.Select((digit, index) => (index, digit)))
            {
                if (char.IsDigit(digit)) sum += (digit - '0') * (index % 2 == 0 ? 1 : 3);
                else return false;
            }
            return sum % 10 == 0;
        }
        //Checks if ISBN with 10 digits is valid
        public static bool CheckISBN10(string isbn)
        {

            // length must be 10 
            isbn = isbn.Replace("-", "").Replace(" ", "");
            int n = isbn.Length;
            if (n != 10)
                return false;

            // Computing weighted sum of  
            // first 9 digits 
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = isbn[i] - '0';

                if (0 > digit || 9 < digit)
                    return false;

                sum += (digit * (10 - i));
            }

            // Checking last digit. 
            char last = isbn[9];
            if (last != 'X' && (last < '0'
                             || last > '9'))
                return false;

            // If last digit is 'X', add 10  
            // to sum, else add its value. 
            sum += ((last == 'X') ? 10 :
                              (last - '0'));

            // Return true if weighted sum  
            // of digits is divisible by 11. 
            return (sum % 11 == 0);
        }

        /// <summary>
        /// Method that loops the User into entering ISBN number until it's correct with the standards
        /// </summary>
        /// <returns>String with the ISBN code that passes 13 or 10 digits standard</returns>
        public static string CheckISBN()
        {
            bool isISBNAppropriate = false;
            string isbnCheck = "";
            while (!isISBNAppropriate)
            {
                //example is only for testing
                Console.WriteLine("Write book's ISBN number. Example: 0-19-852663-6 or 978-1-4028-9462-6");
                isbnCheck = Console.ReadLine().Trim();
                //True when ISBN code passes 13 or 10 digits standard
                if (ValidateClass.CheckISBN13(isbnCheck) || ValidateClass.CheckISBN10(isbnCheck))
                {
                    isISBNAppropriate = true;
                    return isbnCheck;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Inserted ISBN code is not valid.");

                }
            }
            return "";
        }
        /// <summary>
        /// Method that loops the User into entering date until it's correct with the dd.mm.yyyy format
        /// </summary>
        /// <returns>Date in dd.mm.yyyy format</returns>
        public static DateTime CheckDate()
        {
            bool isDateAppropriate = false;
            DateTime releaseDate = DateTime.Now;
            while (!isDateAppropriate)
            {
                Console.WriteLine("Write book's release date. (dd.mm.yyyy)");
                try
                {
                    releaseDate = DateTime.ParseExact(Console.ReadLine().Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    isDateAppropriate = true;
                    return releaseDate;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Inserted date is not valid.");
                }
            }
            return releaseDate;
        }
        /// <summary>
        /// Method that return index of the book with inserted ID.
        /// </summary>
        /// <returns>Index of the book in list</returns>
        public static int GetIndexById(List<Book> books, int id)
        {
            int index = 0;
            foreach (var book in books)
            {
                if (book.id == id)
                {
                    return index;
                }
                index++;
            }
            return 0;
        }
    }
}
