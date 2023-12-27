using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.IO;
using MetroFramework.Controls;
using MetroFramework;

namespace StudentsRecordsManagementSystem
{
    public partial class Authentication
    {
        public class Accounts       //---> Node
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string SecurityQuestion { get; set; }
            public string SecurityAnswer { get; set; }
            public string Path { get; set; }
            public Authentication AuthenticationForm;
            public Accounts Next;
            public Accounts Previous;

            //For login
            public Accounts(string username, string password, string path, Authentication authenticationForm)
            {
                this.Username = username;
                this.Password = password;
                this.Path = path;
                this.AuthenticationForm = authenticationForm;
                this.Next = null;
                this.Previous = null;
            }

            //For Register
            public Accounts(string username,
                string password, string securityQuestion, string securityAnswer,
                string path, Authentication authenticationForm)
            {
                this.Username = username;
                this.Password = password;
                this.SecurityQuestion = securityQuestion;
                this.SecurityAnswer = securityAnswer;
                this.Path = path;
                this.AuthenticationForm = authenticationForm;
                this.Next = null;
                this.Previous = null;
            }

            //For Reset
            public Accounts(string newPassword, string securityQuestion, string securityAnswer,
                string path, Authentication authenticationForm)
            {
                this.Password = newPassword;
                this.SecurityQuestion = securityQuestion;
                this.SecurityAnswer = securityAnswer;
                this.Path = path;
                this.AuthenticationForm = authenticationForm;
                this.Next = null;
                this.Previous = null;
            }
        }

        private class Login
        {
            public Login(string username, string password,
                string path, Authentication authenticationForm)   //---> Login Class for Process Login User
            {
                string DB_Username;
                string DB_Password;

                if (!File.Exists(path))
                {
                    MetroMessageBox.Show(authenticationForm, "Please Register Admin First",
                            "Admin Not Register",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else
                {
                    if (username == "" || username == "Username" || password == "" || password == "Password")
                    {
                        MetroMessageBox.Show(authenticationForm,
                            "Please fill in all fields",
                            "Blank fields",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(path);
                        DB_Username = sr.ReadLine();
                        DB_Password = sr.ReadLine();
                        sr.Close();

                        if (DB_Username == username && DB_Password == password)
                        {
                            ManagementSystem managementForm = new ManagementSystem();
                            managementForm.currentUserLabel.Text = DB_Username;
                            authenticationForm.Hide();
                            managementForm.Closed += (s, args) => authenticationForm.Close();
                            managementForm.Show();
                        }
                        else
                        {
                            MetroMessageBox.Show(authenticationForm,
                            "Enter Right Information",
                            "Invalid Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                        }
                    }
                }
            }
        }

        private class Register      //---> Register Class for Process Registration
        {
            public Register(string Username,
                string Password, string SecurityQuestion, string SecurityAnswer,
                string Path, Authentication AuthenticationForm)
            {
                if (!File.Exists(Path))
                {
                    if (Username == "" || Username == "Username" ||
                        Password == "" || Password == "Create Password" ||
                        SecurityQuestion == "" || SecurityQuestion == "Select a Security Question" ||
                        SecurityAnswer == "" || SecurityAnswer == "Security Answer")
                    {
                        MetroMessageBox.Show(AuthenticationForm,
                        "Please fill in all fields",
                        "Blank fields",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(Path);
                        sw.WriteLine(Username);
                        sw.WriteLine(Password);
                        sw.WriteLine(SecurityQuestion);
                        sw.WriteLine(SecurityAnswer);
                        sw.Close();
                        MetroMessageBox.Show(AuthenticationForm,
                        "Your Account has been Created",
                        "Sucessfully Created",
                        MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
                        AuthenticationForm.clearAllFieldsToDefault();
                    }
                }
                else
                {
                    MetroMessageBox.Show(AuthenticationForm,
                        "Sorry you don't have Permission to Create another Admin",
                        "Already a Admin Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }
        public class CircularLinkedList
        {
            public Accounts Header;
            public Accounts Pointer;

            public CircularLinkedList()
            {
                this.Header = null;
                this.Pointer = null;
            }

            public void LoginUser(string username, string password, string path,
                Authentication authenticationForm)    //---> LoginUser using CircularlinkedList
            {
                Accounts Account = new Accounts(username, password, path, authenticationForm);

                if (Header == null)
                {
                    Header = Account;
                    Pointer = Account;
                    Header.Previous = Pointer;
                    Pointer.Next = Header;
                    new Login(username, password, path, authenticationForm);
                }
                else
                {
                    Pointer.Next = Account;
                    Pointer.Next.Previous = Pointer;
                    Pointer = Pointer.Next;
                    Pointer.Next = Header;
                    Header.Previous = Pointer;
                    new Login(username, password, path, authenticationForm);
                }
            }

            public void RegisterUser(string username,
                string password, string securityQuestion, string securityAnswer,
                string path, Authentication authenticationForm)     //---> Add Method Registration using CircularlinkedList 
            {
                Accounts Account = new Accounts(username, password, securityQuestion, securityAnswer, path, authenticationForm);

                if (Header == null)
                {
                    Header = Account;
                    Pointer = Account;
                    Header.Previous = Pointer;
                    Pointer.Next = Header;
                    new Register(username, password, securityQuestion, securityAnswer, path, authenticationForm);
                }
                else
                {
                    Pointer.Next = Account;
                    Pointer.Next.Previous = Pointer;
                    Pointer = Pointer.Next;
                    Pointer.Next = Header;
                    Header.Previous = Pointer;
                    new Register(username, password, securityQuestion, securityAnswer, path, authenticationForm);
                }
            }
            public void ResetUser(string newPassword, string securityQuestion, string securityAnswer,
                string path, Authentication authenticationForm)
            {
                Accounts account = new Accounts(newPassword, securityQuestion, securityAnswer,
                 path, authenticationForm);

                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);
                    account.Username = sr.ReadLine();
                    account.Password = sr.ReadLine();
                    account.SecurityQuestion = sr.ReadLine();
                    account.SecurityAnswer = sr.ReadLine();
                    sr.Close();

                    if (newPassword == "" || newPassword == "New Password" || securityAnswer == "" || securityAnswer == "Security Answer")
                    {
                        MetroMessageBox.Show(authenticationForm,
                       "Please fill in all fields",
                       "Blank fields",
                       MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        string newPass = authenticationForm.resetPassTB.Text;
                        if (securityAnswer == account.SecurityAnswer)
                        {
                            File.Delete(path);
                            StreamWriter sw = new StreamWriter(path);

                            sw.WriteLine(account.Username);
                            sw.WriteLine(newPass);
                            sw.WriteLine(account.SecurityQuestion);
                            sw.WriteLine(account.SecurityAnswer);
                            sw.Close();

                            MetroMessageBox.Show(authenticationForm,
                            "Your Account has been Reset",
                            "Sucessfully Reset",
                            MessageBoxButtons.OK, MessageBoxIcon.Question, 125);

                            authenticationForm.clearAllFieldsToDefault();
                            authenticationForm.Slider.Show();
                            authenticationForm.Slider.Location = new Point(61, 179);
                            authenticationForm.loginForm.Location = new Point(1, 194);
                            authenticationForm.registerForm.Location = new Point(383, 194);
                            authenticationForm.resetForm.Location = new Point(765, 194);
                        }
                        else
                        {
                            MetroMessageBox.Show(authenticationForm,
                            "Wrong Security Answer",
                            "Wrong Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                        }
                    }
                }
            }
        }
    }
}
