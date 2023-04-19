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
    public partial class MailChange : Form
    {
        private string user_name;
        public MailChange(string user_name)
        {
            InitializeComponent();
            this.user_name = user_name;
        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (Mail.IsValidEmail(bunifuTextBox1.Text))
            {
                string currentPath = Directory.GetCurrentDirectory();// Текущая директория программы
                string mail = Shifr.EncodeDecrypt(bunifuTextBox1.Text);
                Sound.Button_Click_Sound();
                try
                {
                    string sch = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First();
                    string password = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").First();
                    using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                    {
                        await fayl.WriteLineAsync($"{password}");// Вводим пароль
                        await fayl.WriteLineAsync($"{mail}");// Вводим почту
                        await fayl.WriteLineAsync($"{sch}");// Вводим колличество заметок
                    }
                    MessageBox.Show("Смена почты произошла успешно!");
                    this.Close();
                }
                catch (Exception excep)
                {
                    Sound.Button_Click_Mistake_Sound();
                    try
                    {
                        throw new Exception(excep.Message);
                    }
                    catch
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
            }
            else 
            {
                Sound.Button_Click_Mistake_Sound();
                MessageBox.Show("Почта введена неверно!");
            }
        }
    }
}
