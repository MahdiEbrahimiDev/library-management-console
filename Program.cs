// See https://aka.ms/new-console-template for more information
using libraryconsole;
using libraryconsole.Services;
var userservice = new UserService();
while (true)
{
    Console.Clear();
   
    Console.WriteLine("Welcome to library management");
    Console.WriteLine("----------------------------");
    Console.WriteLine("for continue please first of all create a User:");
    Console.WriteLine("if u dont have a UserAccount press 1");
    Console.WriteLine("if u have a UserAccount press 2:");
    Console.WriteLine("-------------------------------");
    int choose = int.Parse(Console.ReadLine());
    userservice.validateUser(choose);

   
}



