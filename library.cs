using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryconsole
{
    public static class library
    {
        public static List<Person> persons { get; set; }=new List<Person>();
        public static List<Book> books { get; set; } = new List<Book>()
        {
            new Book()
            {
                BookName="jenatyat mokafat",
                isreserved=false,
            },
             new Book()
            {
                BookName="boofkoor",
                isreserved=false,
            },
              
        };
        public static void AddPerson(Person person)
        {
            persons.Add(person);
            
        }
        public static void Addbook(Book book)
        {
            books.Add(book);
           
        }
       
    }
}
