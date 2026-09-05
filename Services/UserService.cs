using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using libraryconsole;
using libraryconsole.Services;

namespace libraryconsole.Services
{
    public  class UserService
    {

        public void validateUser(int choose)
        {
         
            switch (choose)
            {


                case 1:
                    Console.WriteLine("inter first name:");
                    Console.WriteLine("--------------");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("inter last name:");
                    Console.WriteLine("--------------");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("inter USername name:");
                    Console.WriteLine("--------------");
                    string Username = Console.ReadLine();
                    if (!isExist(Username))
                    {
                        Console.WriteLine("inter password :");
                        Console.WriteLine("--------------");
                        int password = int.Parse(Console.ReadLine());
                        try
                        {
                            var UserAccount = new Person(firstname, lastname, Username, password);
                            library.AddPerson(UserAccount);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine(" an arror eccured");
                        }
                        Console.WriteLine("User Crated Succsecfully press any key");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("User name is exist pick another Username ");
                        Console.ReadKey();
                        return;
                    }
                    break;


                case 2:
                    Console.WriteLine("inter Username name:");
                    Console.WriteLine("--------------");
                    string Usernameexist = Console.ReadLine();
                    Console.WriteLine("inter password :");
                    Console.WriteLine("--------------");
                    int passwordexist = int.Parse(Console.ReadLine());
                    var UserLogin = library.persons.Any(c => c.Username == Usernameexist && c.Password == passwordexist);
                    if (UserLogin)
                    {
                        
                        
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("welcome to manager library");
                            Console.WriteLine("select option:");
                            Console.WriteLine("--------------");
                            Console.WriteLine("1: Addbook");
                            Console.WriteLine("--------------");
                            Console.WriteLine("2:reserve book");
                            Console.WriteLine("--------------");
                            Console.WriteLine("3: realse book");
                            Console.WriteLine("--------------");
                            Console.WriteLine("4:delete book");
                            Console.WriteLine("--------------");
                            Console.WriteLine("5:show reservation book");
                            Console.WriteLine("--------------");
                            Console.WriteLine("6:show all available book");
                            int option = int.Parse(Console.ReadLine());
                            switch (option)
                            {


                                case 1:
                                    Console.WriteLine("select bookname:");
                                    Console.WriteLine("--------------");
                                    string name = Console.ReadLine();
                                   

                                    if (isExistbook(name))
                                    {
                                         Console.WriteLine("book is already exists");
                                        Console.WriteLine("press any key to go dashboaed...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                         Book Book = new Book(name);
                                    library.Addbook(Book);
                                       Console.WriteLine("book created seccsfully");
                                        Console.WriteLine("press any key to go dashboaed...");
                                        Console.ReadKey();
                                        break;
                                        
                                    }
                                case 2:
                                    Console.WriteLine("enter book name you want to reserve:");
                                    string bookreserve = Console.ReadLine();

                                    var book = library.books
                                        .FirstOrDefault(c => c.BookName == bookreserve);

                                    if (book == null)
                                    {
                                        Console.WriteLine("Book not found");
                                        break;
                                    }

                                    if (book.isreserved)
                                    {
                                        Console.WriteLine("Book already reserved");
                                        break;
                                    }

                                    var person = library.persons
                                        .FirstOrDefault(c => c.Username == Usernameexist &&
                                                              c.Password == passwordexist);

                                    if (person == null)
                                    {
                                        Console.WriteLine("User not found");
                                        break;
                                    }

                                    book.isreserved = true;
                                    person.Bookreserved.Add(book);

                                    Console.WriteLine("Book reserved successfully");
                                    Console.ReadKey();
                                    break;

                               case 3:
    Console.WriteLine("select bookname you wanna realse it:");
    Console.WriteLine("--------------");
    string realsename = Console.ReadLine();

    var bookToRelease = library.books.FirstOrDefault(c => c.BookName == realsename);

    if (bookToRelease == null)
    {
        Console.WriteLine("Book not found");
        Console.ReadKey();
        break;
    }

    var ownerPerson = library.persons.FirstOrDefault(c => c.Bookreserved.Contains(bookToRelease));

    if (ownerPerson != null)
    {
        ownerPerson.realsebook(bookToRelease);
        Console.WriteLine("book realse it");
    }
    else
    {
        Console.WriteLine("this book was not reserved");
    }

    Console.WriteLine("press any key to continue");
    Console.WriteLine("---------------");
    Console.ReadKey();
    break;
                                case 4:
                                    Console.WriteLine("select bookname you wanna delete it:");
                                    string deletebook = Console.ReadLine();

                                    var bookdelete = library.books
                                        .FirstOrDefault(c => c.BookName == deletebook);

                                    if (bookdelete == null)
                                    {
                                        Console.WriteLine("Book not found");
                                        Console.ReadKey();
                                        break;
                                    }

                                    if (bookdelete.isreserved)
                                    {
                                        Console.WriteLine("This book is reserved, you can't delete it.");
                                        Console.ReadKey();
                                        break;
                                    }

                                    library.books.Remove(bookdelete);
                                    foreach (var item in library.persons)
                                    {
                                        item.Bookreserved.RemoveAll(c => c.BookName == deletebook);
                                    }

                                    Console.WriteLine("Book deleted");
                                    Console.ReadKey();
                                    continue;

                                case 5:
                                    Console.WriteLine("inter username of user you wanna see it:");
                                    Console.WriteLine("--------------");
                                    var user= Console.ReadLine();
                                        Console.WriteLine("inter password of user you wanna see it:");
                                    Console.WriteLine("--------------");
                                    var pass=int.Parse(Console.ReadLine());
                                   
                                    var a =library.persons.FirstOrDefault(c => c.Username == user && c.Password == pass);
                                    if (a==null)
                                    {
                                        Console.WriteLine("user not found");
                                        Console.ReadKey();
                                        break;

                                    }
                                    
                                   if (a.Bookreserved==null||a.Bookreserved.Count==0)
                                    {
                                        Console.WriteLine("there is no reserve");
                                        Console.ReadKey();
                                         break;
                                    }
                                    Console.WriteLine($"Total reserved books: {a.Bookreserved.Count}");
                                    foreach (var item in a.Bookreserved)
                                    {
                                        Console.WriteLine(item.BookName);
                                        Console.ReadKey();
                                    }
                                    break;
                                    case 6:
                                    System.Console.WriteLine("all books available are listed below:");
                                     System.Console.WriteLine("-------------------------------------");
                                    showAllbook();
                                    System.Console.WriteLine("press any key to exit ...");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        
                    }
                    Console.WriteLine("User is not exists");
                    break;
                case 7:

                    break;
            }
        }

                  
        public static  bool isExist(string Username)
        {
            if (library.persons.Any(c=>c.Username==Username))
            {
               
                return true;
            }
            return false;

        }
        public static bool isExistbook(string bookname)
        {
            if (library.books.Any(c => c.BookName == bookname))
            {

                return true;
            }
            return false;

        }
      public static List<Book> showAllbook()
        {
            var books=library.books.Where(c=>c.isreserved==false);
            var bookavailbe=new List<Book>();
      foreach(var a in books)
            {
                bookavailbe.Add(a);
                Console.WriteLine($" book name {a.BookName}");
                Console.WriteLine($"------------------------");
            }
            return bookavailbe;
        }
    }
}
