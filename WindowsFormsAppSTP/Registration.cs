using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsAppSTP
{
    public partial class Registration : Form
    {
        public string user_name;
        public Registration()
        {
            InitializeComponent();
        }
        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (!bunifuTextBox1.Text.Contains(" "))// Проверка
            {
                if (bunifuTextBox1.Text != null)// Проверка
                {
                    if (!bunifuTextBox2.Text.Contains(" "))// Проверка
                    {
                        if (bunifuTextBox2.Text != null)// Проверка
                        {
                            if (!bunifuTextBox3.Text.Contains(" "))// Проверка
                            {
                                if (bunifuTextBox3.Text != null)// Проверка
                                {
                                    if (bunifuTextBox3.Text == bunifuTextBox2.Text)// Проверка
                                    {
                                        if (Mail.IsValidEmail(bunifuTextBox4.Text))// Проверка
                                        {
                                            string currentPath = Directory.GetCurrentDirectory();// Берём выбранный путь приложения
                                            if (!Directory.Exists(Path.Combine(currentPath + "/Users", $"{bunifuTextBox1.Text}")))
                                            {
                                                Sound.Button_Click_Sound();
                                                if (!Directory.Exists(Path.Combine(currentPath, "Users")))// Если нет директории Users, то создаём её
                                                {
                                                    Directory.CreateDirectory(Path.Combine(currentPath, "Users"));
                                                }
                                                if (!Directory.Exists(Path.Combine(currentPath + "/Users", $"{bunifuTextBox1.Text}")))// Если нет директории {имя пользователя}, то создаём её
                                                {
                                                    Directory.CreateDirectory(Path.Combine(currentPath + "/Users", $"{bunifuTextBox1.Text}"));
                                                }
                                                using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{bunifuTextBox1.Text}/" + $"/{bunifuTextBox1.Text}.rtf"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                                                {
                                                    string password = Shifr.EncodeDecrypt(bunifuTextBox2.Text);
                                                    string mail = Shifr.EncodeDecrypt(bunifuTextBox4.Text);
                                                    string sch = Shifr.EncodeDecrypt("0");
                                                    await fayl.WriteLineAsync($"{password}");// Вводим пароль
                                                    await fayl.WriteLineAsync($"{mail}");// Вводим почту
                                                    await fayl.WriteLineAsync($"{sch}");// Вводим колличество заметок
                                                }
                                                //using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{textBox1.Text}/" + $"/{textBox1.Text}_Data.txt")) { }   
                                                user_name = bunifuTextBox1.Text;
                                                MessageBox.Show("Регистрация прошла успешно!");
                                                Enter fr2 = new Enter();
                                                fr2.Show();
                                                this.Hide();
                                            }
                                            else 
                                            {
                                                Sound.Button_Click_Mistake_Sound();
                                                MessageBox.Show("Пользователь уже создан!");
                                            }
                                        }
                                        else// Не прошёл роверку
                                        {
                                            Sound.Button_Click_Mistake_Sound();
                                            MessageBox.Show("Почта не действительна!");
                                        }
                                    }
                                    else// Не прошёл роверку
                                    {
                                        Sound.Button_Click_Mistake_Sound();
                                        MessageBox.Show("Пароли не совпадают!");
                                    }
                                }
                                else// Не прошёл роверку
                                {
                                    Sound.Button_Click_Mistake_Sound();
                                    MessageBox.Show("Поле повторное введение пароля пустое!");
                                }
                            }
                            else// Не прошёл роверку
                            {
                                Sound.Button_Click_Mistake_Sound();
                                MessageBox.Show("Поле повторное введение пароля содержит пробел!");
                            }
                        }
                        else// Не прошёл роверку
                        {
                            Sound.Button_Click_Mistake_Sound();
                            MessageBox.Show("Поле пароль пустое!");
                        }
                    }
                    else// Не прошёл роверку
                    {
                        Sound.Button_Click_Mistake_Sound();
                        MessageBox.Show("Поле пароль содержит пробел!");
                    }
                }
                else// Не прошёл роверку
                {
                    Sound.Button_Click_Mistake_Sound();
                    MessageBox.Show("Поле пользователь пустое!");
                }
            }
            else// Не прошёл роверку
            {
                Sound.Button_Click_Mistake_Sound();
                MessageBox.Show("Поле пользователь содержит пробел!");
            }

        }

       
        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == "")
            {
                bunifuTextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                bunifuTextBox2.UseSystemPasswordChar = true;
            }
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox3.Text == "")
            {
                bunifuTextBox3.UseSystemPasswordChar = false;
            }
            else
            {
                bunifuTextBox3.UseSystemPasswordChar = true;
            }
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Enter fr2 = new Enter();
            fr2.Show();
            Hide();
        }
    }
}