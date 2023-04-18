using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSTP
{
    public partial class Settings : Form
    {
        public string user_name;
        public Settings(string local_user_name)
        {
            InitializeComponent();
            user_name = local_user_name;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            PasswordChange passwordChange = new PasswordChange(user_name);
            passwordChange.Show();
        }
    }
}
