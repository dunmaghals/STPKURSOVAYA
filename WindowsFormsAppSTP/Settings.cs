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
            Sound.Button_Click_Sound();
            PasswordChange passwordChange = new PasswordChange(user_name);
            passwordChange.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            MailChange mailChange = new MailChange(user_name);
            mailChange.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            SoundChange soundChange = new SoundChange();
            soundChange.Show();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            ToDevelopers toDevelopers = new ToDevelopers(user_name);
            toDevelopers.Show();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            this.Close();
        }
    }
}
