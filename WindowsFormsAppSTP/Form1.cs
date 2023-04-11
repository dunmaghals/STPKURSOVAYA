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
    public partial class Form1 : Form
    {
        public string user_name;
        public Form1()
        {
            InitializeComponent();
            textBox1_Leave(null, null); textBox2_Leave(null, null); textBox3_Leave(null, null); textBox4_Leave(null, null); // Визуальная составляющая текстбоксов
        }
        private void textBox1_Enter(object sender, EventArgs e)// Вход в 1й текст бокс
        {
            if (textBox1.Text == "Имя пользователя")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)// Выход из 1го текст бокса
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Имя пользователя";
                textBox1.ForeColor = Color.Gray;
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)// Вход в 2й текст бокс
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Clear();
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)// Выход из 2го текст бокса
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Пароль";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)// Вход в 3й текст бокс
        {
            if (textBox3.Text == "Повторите пароль")
            {
                textBox3.Clear();
                textBox3.ForeColor = Color.Black;
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)// Выход из 3го текст бокса
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "Повторите пароль";
                textBox3.ForeColor = Color.Gray;
                textBox3.UseSystemPasswordChar = false;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)// Вход в 4й текст бокс
        {
            if (textBox4.Text == "Почта")
            {
                textBox4.Clear();
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)// Выход из 4го текст бокса
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Почта";
                textBox4.ForeColor = Color.Gray;
            }
        }


        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(" "))// Проверка
            {
                if (textBox1.Text != null)// Проверка
                {
                    if (!textBox2.Text.Contains(" "))// Проверка
                    {
                        if (textBox2.Text != null)// Проверка
                        {
                            if (!textBox3.Text.Contains(" "))// Проверка
                            {
                                if (textBox3.Text != null)// Проверка
                                {
                                    if (textBox3.Text == textBox2.Text)// Проверка
                                    {
                                        if (!textBox4.Text.Contains(" "))// Проверка
                                        {
                                            if (textBox4.Text != null)// Проверка
                                            {
                                                string currentPath = Directory.GetCurrentDirectory();// Берём выбранный путь приложения
                                                if (!Directory.Exists(Path.Combine(currentPath, "Users")))// Если нет директории Users, то создаём её
                                                {
                                                    Directory.CreateDirectory(Path.Combine(currentPath, "Users"));
                                                }
                                                if (!Directory.Exists(Path.Combine(currentPath + "/Users", $"{textBox1.Text}")))// Если нет директории {имя пользователя}, то создаём её
                                                {
                                                    Directory.CreateDirectory(Path.Combine(currentPath + "/Users", $"{textBox1.Text}"));
                                                }
                                                using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{textBox1.Text}/" + $"/{textBox1.Text}.txt"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                                                {
                                                    await fayl.WriteLineAsync($"{textBox2.Text}");// Вводим пароль
                                                    await fayl.WriteLineAsync($"{textBox4.Text}");// Вводим почту
                                                    await fayl.WriteLineAsync($"0");// Вводим колличество заметок
                                                }
                                                //using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{textBox1.Text}/" + $"/{textBox1.Text}_Data.txt")) { }   
                                                user_name = textBox1.Text;
                                            }
                                            else// Не прошёл роверку
                                            {
                                                MessageBox.Show("Поле почта пустое!");
                                            }
                                        }
                                        else// Не прошёл роверку
                                        {
                                            MessageBox.Show("Поле пароль содержит пробел!");
                                        }
                                    }
                                    else// Не прошёл роверку
                                    {
                                        MessageBox.Show("Пароли не совпадают!");
                                    }
                                }
                                else// Не прошёл роверку
                                {
                                    MessageBox.Show("Поле повторное введение пароля пустое!");
                                }
                            }
                            else// Не прошёл роверку
                            {
                                MessageBox.Show("Поле повторное введение пароля содержит пробел!");
                            }
                        }
                        else// Не прошёл роверку
                        {
                            MessageBox.Show("Поле пароль пустое!");
                        }
                    }
                    else// Не прошёл роверку
                    {
                        MessageBox.Show("Поле пароль содержит пробел!");
                    }
                }
                else// Не прошёл роверку
                {
                    MessageBox.Show("Поле пользователь пустое!");
                }
            }
            else// Не прошёл роверку
            {
                MessageBox.Show("Поле пользователь содержит пробел!");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            Hide();
        }
    }
}