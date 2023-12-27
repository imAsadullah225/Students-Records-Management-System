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
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        #region Close and Minimized Buttons Events
        private void AuthenticationCloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AuthenticationMinimizedButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Button & Slider Events
        private void loginSliderButton_Click(object sender, EventArgs e)
        {
            Slider.Show();
            Slider.Location = new Point(61, 179);
            loginForm.Location = new Point(1, 194);
            registerForm.Location = new Point(383, 194);
            resetForm.Location = new Point(765, 194);
        }

        private void registerSliderButton_Click(object sender, EventArgs e)
        {
            Slider.Show();
            Slider.Location = new Point(194, 179);
            registerForm.Location = new Point(1, 194);
            loginForm.Location = new Point(383, 194);
            resetForm.Location = new Point(765, 194);
        }

        #endregion

        #region Placeholder event

        public void RemoveText(object sender, EventArgs e)
        {
            BunifuMetroTextbox tb = (BunifuMetroTextbox)sender;

            if (tb.Text == "Username" || tb.Text == "Security Answer")
            {
                tb.Text = "";
            }
            else if (tb.Text == "Password")
            {
                tb.Text = "";
                loginPassTB.isPassword = true;
            }
            else if (tb.Text == "Create Password")
            {
                tb.Text = "";
                regPassTB.isPassword = true;
            }
            else if (tb.Text == "New Password")
            {
                tb.Text = "";
                resetPassTB.isPassword = true;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (loginUserTB.Text == "")
            {
                loginUserTB.Text = "Username";
            }
            else if (loginPassTB.Text == "")
            {
                loginPassTB.isPassword = false;
                loginPassTB.Text = "Password";
            }
            else if (regUserTB.Text == "")
            {
                regUserTB.Text = "Username";
            }
            else if (regSecurityAnsTB.Text == "")
            {
                regSecurityAnsTB.Text = "Security Answer";
            }
            else if (regPassTB.Text == "")
            {
                regPassTB.isPassword = false;
                regPassTB.Text = "Create Password";
            }
            else if (resetPassTB.Text == "")
            {
                resetPassTB.isPassword = false;
                resetPassTB.Text = "New Password";
            }
            else if (resetSecurityAnsTB.Text == "")
            {
                resetSecurityAnsTB.Text = "Security Answer";
            }
        }

        #endregion

        #region Login, Register & Reset Buttons Events 
        public void clearAllFieldsToDefault()
        {
            loginUserTB.Text = "Username";
            loginPassTB.isPassword = false;
            loginPassTB.Text = "Password";
            regUserTB.Text = "Username";
            regPassTB.isPassword = false;
            regPassTB.Text = "Create Password";
            regSecurityQueDropdown.selectedIndex = 0;
            regSecurityAnsTB.Text = "Security Answer";
            resetPassTB.isPassword = false;
            resetPassTB.Text = "New Password";
            resetSecurityAnsTB.Text = "Security Answer";
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            string directoryPath;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Accounts\\Admin");
            directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";

            CircularLinkedList circularLL = new CircularLinkedList();
            circularLL.LoginUser(loginUserTB.Text, loginPassTB.Text, directoryPath, this);
            
        }
   
        private void registerButton_Click(object sender, EventArgs e)
        {
            string directoryPath;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Accounts\\Admin");
            directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";

            CircularLinkedList circularLL = new CircularLinkedList();
            circularLL.RegisterUser(regUserTB.Text, regPassTB.Text, regSecurityQueDropdown.selectedValue,
                regSecurityAnsTB.Text, directoryPath, this);
            loginSliderButton_Click(sender, e);
        }

        private void ForgottenButton_Click(object sender, EventArgs e)
        {
            string DB_Username;
            string DB_SecurityQuestion;
            string directoryPath;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Accounts\\Admin");
            directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";


            if (File.Exists(directoryPath))
            {
                StreamReader sr = new StreamReader(directoryPath);
                DB_Username= sr.ReadLine();
                sr.ReadLine();
                DB_SecurityQuestion = sr.ReadLine();
                sr.Close();

                if (DB_Username == loginUserTB.Text)
                {
                    resetUserTB.Text = DB_Username;
                    resetSecurityQueTB.Text = DB_SecurityQuestion;
                    Slider.Hide();
                    resetForm.Location = new Point(1, 194);
                    loginForm.Location = new Point(765, 194);
                }
                else
                {
                    MetroMessageBox.Show(this,
                            "This Account is not Exists",
                            "Account Not Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
            else
            {
                MetroMessageBox.Show(this,
                            "First create an Account",
                            "No Admin Exist",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void resetAccountButton_Click(object sender, EventArgs e)
        {
            string directoryPath;
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Accounts\\Admin");
            directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";

            CircularLinkedList CircularLL = new CircularLinkedList();
            CircularLL.ResetUser(resetPassTB.Text, resetSecurityQueTB.Text, resetSecurityAnsTB.Text, directoryPath, this);
        }
        #endregion
    }
}
