using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAuthentication
{
    class Authenticator
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public Authenticator() //constructor method
        { 
            dictionary.Add("c0nnor", "letmein");    //Usernames(as Key value) and passwords added to dictionary
            dictionary.Add("keppi3","trustno1");
            dictionary.Add("conkep", "opensesame");
            dictionary.Add("kepcon!", "admin");
            dictionary.Add("Keppethor", "password11");
        }

        public bool authenticated;

        public bool authenticate(string username, string password)      //Method to check username/password combination matches returning bool
        {  
            if (dictionary.ContainsKey(username) && dictionary[username] == password)
            {
                return authenticated = true;
            }
            return authenticated = false;    
        }

    }
}
