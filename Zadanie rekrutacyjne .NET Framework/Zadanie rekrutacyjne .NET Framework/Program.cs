using System;
using System.Collections.Generic;

namespace Zadanie_rekrutacyjne.NET_Framework
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Book> booksList = new List<Book>();
            bool isActive = true;
            //Loop to keep application active
            while (isActive)
            {

                Console.Clear();
                Console.WriteLine("Type number with the task you want to perform.");
                Console.WriteLine("1. Show all books.");
                Console.WriteLine("2. Create new book.");
                Console.WriteLine("3. Edit a book.");
                Console.WriteLine("4. Delete a book.");
                Console.WriteLine("5. Exit application.");
                int task;
                Int32.TryParse(Console.ReadLine().Trim(), out task);
                switch (task)
                {

                    //Show all books
                    case 1: 
                        Console.Clear();
                        Console.WriteLine("List of books:");
                        foreach (var book in booksList)
                        {
                            Console.WriteLine(book.ToString());
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Create new book
                    case 2:
                        Console.Clear();
                        //Title input
                        Console.WriteLine("Write book's title.");
                        string title = "";
                        while (title == string.Empty)
                        {
                            title = Console.ReadLine().Trim();
                            Console.Clear();
                            Console.WriteLine("The title cannot be empty\nWrite book's title.");
                        }
                        Console.Clear();

                        //Author input
                        Console.WriteLine("Write book's author.");
                        string author = "";
                        while (author == string.Empty)
                        {
                            author = Console.ReadLine().Trim();
                            Console.Clear();
                            Console.WriteLine("The author cannot be empty\nWrite author's name.");
                        }
                        Console.Clear();

                        //Date input. Script to avoid inappropriate date.
                        DateTime releaseDate = ValidateClass.CheckDate();
                        Console.Clear();

                        //ISBN input. Check if the ISBN is valid with the standards
                        string isbn = ValidateClass.CheckISBN();

                        //Add new book to list
                        if (booksList.Count == 0)
                        {
                            booksList.Add(new Book(1, title, author, releaseDate, isbn));
                        }
                        else
                        {
                            //Adds book with id 1 higher than the last one.
                            booksList.Add(new Book(booksList[booksList.Count-1].id + 1, title, author, releaseDate, isbn));
                        }
                        Console.WriteLine("Book has been added.\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Edit a book
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Write book's id that will be edited.");
                        int editId;
                        Int32.TryParse(Console.ReadLine().Trim(), out editId);
                        int indexEdit = ValidateClass.GetIndexById(booksList, editId);
                        if (indexEdit != 0)
                        {
                            bool editActive = true;
                            while (editActive)
                            {

                                Console.Clear();
                                Console.WriteLine("Type number with the task you want to perform.");
                                Console.WriteLine("1. Edit Title.");
                                Console.WriteLine("2. Edit Author.");
                                Console.WriteLine("3. Edit Release date.");
                                Console.WriteLine("4. Edit ISBN code.");
                                Console.WriteLine("5. Back to books menu.");
                                int taskEdit;
                                Int32.TryParse(Console.ReadLine().Trim(), out taskEdit);
                                switch (taskEdit)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine($"Current book's Title: {booksList[indexEdit].title}");
                                        Console.WriteLine($"Type new title");
                                        string titleEdit = "";
                                        while (titleEdit == string.Empty)
                                        {
                                            titleEdit = Console.ReadLine().Trim();
                                            Console.Clear();
                                            Console.WriteLine("The title cannot be empty\nWrite new book's title.");
                                        }
                                        Console.Clear();
                                        booksList[indexEdit].title = titleEdit;
                                        Console.WriteLine("The title has been changed.");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadKey();
                                        editActive = false;
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine($"Current book's Author: {booksList[indexEdit].author}");
                                        Console.WriteLine($"Type new author");
                                        string authorEdit = "";
                                        while (authorEdit == string.Empty)
                                        {
                                            authorEdit = Console.ReadLine().Trim();
                                            Console.Clear();
                                            Console.WriteLine("The author cannot be empty\nWrite new book's author.");
                                        }
                                        Console.Clear();
                                        booksList[indexEdit].author = authorEdit;
                                        Console.WriteLine("The author has been changed.");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadKey();
                                        editActive = false;
                                        break;
                                    case 3:
                                        Console.Clear();
                                        DateTime editDate = ValidateClass.CheckDate();
                                        booksList[indexEdit].releaseDate = editDate;
                                        Console.Clear();
                                        Console.WriteLine("The date has been changed.");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadKey();
                                        editActive = false;
                                        Console.Clear();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        string isbnEdit = ValidateClass.CheckISBN();
                                        booksList[indexEdit].isbn = isbnEdit;
                                        Console.Clear();
                                        Console.WriteLine("The ISBN code has been changed.");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadKey();
                                        editActive = false;
                                        Console.Clear();
                                        break;
                                    case 5:
                                        editActive = false;
                                        break;
                                    default:
                                        Console.WriteLine("Input a proper option!");
                                        break;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Book with inserted id does not exist.");
                        }
                        Console.Clear();
                        break;

                    //Delete a book
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Write book's id that will be deleted.");
                        int deleteId;
                        Int32.TryParse(Console.ReadLine().Trim(), out deleteId);
                        int indexDelete = ValidateClass.GetIndexById(booksList, deleteId);
                        if (indexDelete != 0)
                        {
                            booksList.Remove(booksList[indexDelete]);
                            Console.WriteLine("The book has been deleted");
                        }
                        else
                        {
                            Console.WriteLine("Book with inserted id does not exist.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Exit application
                    case 5:
                        isActive = false;
                        break;

                    //TESTING ONLY. UNCOMMENT IF NEEDED
                    //case 6:
                    //    booksList.Add(new Book(1, "Title-1", "Author-1", DateTime.ParseExact("10.10.1010", "dd.MM.yyyy", System.Globalization.CultureInfo.CurrentCulture), "0-19-852663-6"));
                    //    booksList.Add(new Book(2, "Title-2", "Author-2", DateTime.ParseExact("10.10.1010", "dd.MM.yyyy", System.Globalization.CultureInfo.CurrentCulture), "0-19-852663-6"));
                    //    booksList.Add(new Book(3, "Title-3", "Author-3", DateTime.ParseExact("10.10.1010", "dd.MM.yyyy", System.Globalization.CultureInfo.CurrentCulture), "0-19-852663-6"));
                    //    booksList.Add(new Book(4, "Title-4", "Author-4", DateTime.ParseExact("10.10.1010", "dd.MM.yyyy", System.Globalization.CultureInfo.CurrentCulture), "0-19-852663-6"));
                    //    booksList.Add(new Book(5, "Title-5", "Author-5", DateTime.ParseExact("10.10.1010", "dd.MM.yyyy", System.Globalization.CultureInfo.CurrentCulture), "0-19-852663-6"));
                    //    break;

                    //Input is different from the numbers listed above
                    default:
                        Console.WriteLine("Input a proper option!");
                        break;
                }
            }          
        }
    }
}
