using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Allows Messageboxes
using System.IO;        //Allows file read/write

namespace WFAppAuthentication
{
    public partial class Form1 : Form
    {
        private Authenticator a = new Authenticator(); //Form class variables
        private string UserUN;
        private string UserPW;
        private DateTime logDate { get; set; }
        StreamWriter log_writer = new StreamWriter("C:\\Users\\MARS\\Documents\\Visual Studio 2013\\Projects\\ConsoleApplicationAuthentication\\WFAppAuthentication\\userlog.csv", true);

        public Form1()
        {
            InitializeComponent();
        }

        private void username_textBox_TextChanged(object sender, EventArgs e)   //Gets username from user input
        {
            UserUN = UsernameTextBox.Text;
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)   //Gets password from user input
        {
            UserPW = PasswordTextBox.Text;
        }

        private void btnAuthenticate_Click(object sender, EventArgs e) //button method, shows user if their username/password combo works
        {
            bool tORf = a.authenticated;
            tORf = a.authenticate(UserUN, UserPW);
            if (tORf == true)
            {
                MessageBox.Show("Access Granted");
            }
            else
            {
                MessageBox.Show("Access Denied");
            }


            //Log file, displays Username, Password, Date/Time logged in and whether login attempt was successful
            if (File.Exists("C:\\Users\\MARS\\Documents\\Visual Studio 2013\\Projects\\ConsoleApplicationAuthentication\\WFAppAuthentication\\userlog.csv"))
            {
                log_writer.WriteLine("Username: " + UserUN);
                log_writer.WriteLine("Password: " + UserPW);
                DateTime current = DateTime.Now;
                log_writer.WriteLine("Date/Time: " + current);
                if (tORf == true)
                {
                    log_writer.WriteLine("Password accepted");
                }
                else
                {
                    log_writer.WriteLine("Password denied");
                }
                log_writer.Close();
            }
            else
            {
                MessageBox.Show("Error:log file cannot be found");      //Error message for unavailable log file
            }

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

