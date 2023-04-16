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
    public partial class MailRestore : Form
    {
        public MailRestore()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text != null) 
            {
                if (!bunifuTextBox1.Text.Contains(" "))
                {
                    Mail.SendMessage(bunifuTextBox1.Text, "evgenigaber@gmail.com","STPKursovaya","322");
                }
                else
                {
                    MessageBox.Show("Имя пользователя не должно содержать пробелы!");
                }
            }
            else 
            {
                MessageBox.Show("Имя пользователя не должно быть пустым!");
            }
        }
    }
}
