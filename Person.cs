using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace libraryconsole
{
    public class Person
    {
      
       
        public string Username { get; set; }
        public string FirstName { get; set; }
        public int Password{ get; set; }
        public string LastName { get; set; }
      public  List<Book> Bookreserved { get; set; }=new List<Book>();

        public Person(string firstname,string lastname,string username,int password)
        {
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Username= username;
           
        }
        public Person()
        {
            
        }
        public void realsebook(Book book)
        {
            if (book!=null)
            {
                Bookreserved.Remove(book);
                book.isreserved = false;
            }
        }
    }
}
