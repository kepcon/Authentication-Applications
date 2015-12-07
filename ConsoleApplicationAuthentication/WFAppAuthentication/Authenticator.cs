using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            //Allows file read/write
using System.Windows.Forms; //Allows addition of messageboxes

namespace WFAppAuthentication
{
    class Authenticator
    {
        //class variable and data structure
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public string userDictionary = ("C:\\Users\\MARS\\Documents\\Visual Studio 2013\\Projects\\ConsoleApplicationAuthentication\\WFAppAuthentication\\dictionary.csv");
 
        public Authenticator() //constructor method to load all dictionary values from file
        {
            if (File.Exists(userDictionary))
            {
                StreamReader userInputStream = new StreamReader(userDictionary);
                dictionary.Add(userInputStream.ReadLine(), userInputStream.ReadLine());
                dictionary.Add(userInputStream.ReadLine(), userInputStream.ReadLine());
                dictionary.Add(userInputStream.ReadLine(), userInputStream.ReadLine());
                dictionary.Add(userInputStream.ReadLine(), userInputStream.ReadLine());
                dictionary.Add(userInputStream.ReadLine(), userInputStream.ReadLine());                
            }
            else
            {
                //Displays error if dictionary file isn't in specified path
                MessageBox.Show("Error: Essential dictionary file cannot be found, No username and password combinaitons are valid");   
            }


        }
       
     
       // public void Authenticator(Authenticator userDictionary)               //ATTEMPT at adding additional constructor method
        //{                                                                     //Although program is capable without it
        //    StreamReader userInputStream = new StreamReader(userDictionary);
         //   string Line;
        //    while((Line = userInputStream.ReadLine()) != null)
        //    {
        //        Line = userInputStream.ReadLine();
        //    }
        //    userInputStream.Close();
       // }


        public bool authenticated;
        public bool authenticate(string username, string password)              //method to find match between username and password
        {

            if (dictionary.ContainsKey(username) && dictionary[username] == password)       
            {
                return authenticated = true;
            }
            return authenticated = false;
        }

    }
}
