using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace libraryconsole
{
    public class Book
    {
       
        public string BookName { get; set; }
        public bool isreserved { get; set; }
        public Book(string name)
        {
            BookName= name;

        }
        public Book()
        {
            
        }
    }
}
