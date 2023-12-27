using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsRecordsManagementSystem
{
    public partial class splashScreenForm : Form
    {
        public splashScreenForm()
        {
            InitializeComponent();
        }

        Authentication AuthForm = new Authentication();
        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashLoadingBar.Value += 2;

            if (splashLoadingBar.Value >= 100)
            {
                splashTimer.Stop();
                this.Hide();
                AuthForm.Closed += (s, args) => this.Close();
                AuthForm.Show();
            }
        }

        
    }
}
