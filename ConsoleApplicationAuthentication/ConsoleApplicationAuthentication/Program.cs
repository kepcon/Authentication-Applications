using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAuthentication
{
    class Program
    {
        static private Authenticator a = new Authenticator();   //class variable

        static void Main(string[] args)
        {
            string UserUN;          //variables
            string UserPW;
            
            UserUN = GetUserUN();
            UserPW = GetUserPW();
            
            bool tORf = a.authenticated;            //Using Authenticator.cs to confirm or deny matches between username & password
            tORf = a.authenticate(UserUN, UserPW);
            Console.WriteLine(tORf.ToString());     //Writing bool value to a string in the console       
            Console.ReadLine();         
        }

        public static string GetUserUN()            //Prompts user to enter username then gets username from what they have typed
        {
            string unameinput;                      
            Console.WriteLine("Enter Username");
            unameinput = Console.ReadLine();
            return unameinput;
        }
        public static string GetUserPW()            //Prompts user to enter password then gets password from what they have typed
        {
            string pwinput;
            Console.WriteLine("Enter Password");
            pwinput = Console.ReadLine();
            return pwinput;
        }

    }
}
