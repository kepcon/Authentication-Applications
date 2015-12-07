using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

//USED FOR TESTING WEBSERVICE IN WFA, Instead of using existing WindowsFormsApp

namespace WFAppAuthWeb1
{
    public partial class Form1 : Form
    {
        //Form class variables
        public WFAppAuthWeb1.wsA.WebAuthentication aw = new WFAppAuthWeb1.wsA.WebAuthentication();      //WebService reference
        private string myUsername;
        private string myPassword;
        private DateTime logDateWeb { get; set; }
        StreamWriter log_writerWeb = new StreamWriter("C:\\Users\\MARS\\Documents\\Visual Studio 2013\\Projects\\ConsoleApplicationAuthentication\\WFAppAuthWeb1\\userlogWeb.csv", true);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)   //Gets username from user input
        {
            myUsername = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)   //Gets password from user input
        {
            myPassword = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch accessServer = Stopwatch.StartNew();          //Retrieves time taken to access web server
            bool tORf = aw.authenticateMe(myUsername, myPassword);  //Uses web service method, returns bool
            if (tORf == true)
            {
                MessageBox.Show("Access Granted" + " Server Access Time: " + accessServer.ElapsedMilliseconds + "ms");
            }
            else 
            {
                MessageBox.Show("Access Denied" + " Server Access Time: " + accessServer.ElapsedMilliseconds + "ms");
            }

            //Log file, displays Username, Password, Date/Time logged in and whether login attempt was successful
            if (File.Exists("C:\\Users\\MARS\\Documents\\Visual Studio 2013\\Projects\\ConsoleApplicationAuthentication\\WFAppAuthWeb1\\userlogWeb.csv"))
            {
                log_writerWeb.WriteLine("Username: " + myUsername);
                log_writerWeb.WriteLine("Password: " + myPassword);
                DateTime current = DateTime.Now;
                log_writerWeb.WriteLine("Date/Time: " + current);
                if (tORf == true)
                {
                    log_writerWeb.WriteLine("Password accepted");
                }
                else
                {
                    log_writerWeb.WriteLine("Password denied");
                }
                log_writerWeb.Close();
            }
            else
            {
                MessageBox.Show("Error:log file cannot be found");      //Error message for unavailable log file
            }

        }
    }
}
