using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSTP
{
    public partial class ToDevelopers : Form
    {
        private string user_name;
        public ToDevelopers(string local_user_name)
        {
            InitializeComponent();
            user_name = local_user_name;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1 != null)
            {
                Sound.Button_Click_Sound();
                string currentPath = Directory.GetCurrentDirectory();
                string mail = "dgecka749@mail.ru";
                Mail.SendMessage("Ditary team", $"{mail}", $"Ditary backtrack from {user_name}", $"{richTextBox1}");
                this.Close();
            }
            else 
            {
                Sound.Button_Click_Mistake_Sound();
                MessageBox.Show("Пожалуйста, введите отзыв!");
            }
        }
    }
}
