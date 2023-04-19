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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppSTP
{
    public partial class PasswordChange : Form
    {
        private string user_name;
        public PasswordChange(string local_user_name)
        {
            InitializeComponent();
            user_name = local_user_name;
        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1 != null)
            {
                if (!bunifuTextBox1.Text.Contains(" "))
                {
                    if (bunifuTextBox1.Text == bunifuTextBox2.Text)
                    {
                        Sound.Button_Click_Sound();
                        try
                        {
                            string currentPath = Directory.GetCurrentDirectory();// Текущая директория программы
                            string mail = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(1).First();
                            string sch = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First();
                            using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                            {
                                string password = Shifr.EncodeDecrypt(bunifuTextBox1.Text);
                                await fayl.WriteLineAsync($"{password}");// Вводим пароль
                                await fayl.WriteLineAsync($"{mail}");// Вводим почту
                                await fayl.WriteLineAsync($"{sch}");// Вводим колличество заметок
                            }
                            MessageBox.Show("Смена пароля произошла успешно!");
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
                        MessageBox.Show("Пароли не совпадают!");
                    }
                }
                else 
                {
                    Sound.Button_Click_Mistake_Sound();
                    MessageBox.Show("Пароль не должен содержать пробелы!");
                }
            }
            else 
            {
                Sound.Button_Click_Mistake_Sound();
                MessageBox.Show("Пароль не должен быть пустым!");
            }
        }
    }
}
