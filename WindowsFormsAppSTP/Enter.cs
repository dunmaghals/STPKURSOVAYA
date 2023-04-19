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
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsAppSTP
{
    public partial class Enter : Form
    {
        public Enter()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e) // Нажатие на лейбл регистрации
        {
            Registration fr1 = new Registration();
            fr1.Show();
            Close();
        }

        private void label3_Click(object sender, EventArgs e) // Нажатие на лейбл восстановления пароля по почте
        {
            MailRestore mailRestore = new MailRestore();
            mailRestore.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text != null)// Проверка присутствия имени пользователя
            {
                if (!bunifuTextBox1.Text.Contains(" "))// Проверка содержания имени пользователя на пробел
                {
                    if (bunifuTextBox2.Text != null)// Проверка присутствия пароля
                    {
                        if (!bunifuTextBox2.Text.Contains(" "))// Проверка пароля на содержание пробелов
                        {
                            string currentPath = Directory.GetCurrentDirectory();// Текущая директория программы
                            if (Directory.Exists(Path.Combine(currentPath, "Users")))// Проверка существования директории user
                            {
                                if (Directory.Exists(Path.Combine(currentPath + "/Users/" + $"{bunifuTextBox1.Text}")))// Проверка существования директории имя пользователя
                                {
                                    if (File.Exists(Path.Combine(currentPath + "/Users" + $"/{bunifuTextBox1.Text}/" + $"/{bunifuTextBox1.Text}.txt")))// Проверка существования директории имя пользователя
                                    {
                                        using (StreamReader sr = File.OpenText(currentPath + "/Users" + $"/{bunifuTextBox1.Text}/" + $"/{bunifuTextBox1.Text}.txt"))// Открытие файла имени пользователя
                                        {
                                            string password = Shifr.EncodeDecrypt(sr.ReadLine());// считываем пароль
                                            if (bunifuTextBox2.Text == password) // Если поле текст бокс == пароль
                                            {
                                                Sound.Button_Click_Sound();
                                                MessageBox.Show("Вход выполнен!");
                                                MainMenu fr3 = new MainMenu(bunifuTextBox1.Text);
                                                fr3.Show();
                                                Close();
                                            }
                                            else 
                                            {
                                                Sound.Button_Click_Mistake_Sound();
                                                MessageBox.Show("Пароли не совпадают!");
                                            }
                                        }
                                    }
                                    else // Если файл с именем пользователя отсутствует
                                    {
                                        Sound.Button_Click_Mistake_Sound();
                                        MessageBox.Show("Данный пользователь отсутствует!");
                                    }
                                }
                                else // Если нет директории с именем пользователя
                                {
                                    Sound.Button_Click_Mistake_Sound();
                                    MessageBox.Show("Данный пользователь отсутствует!");
                                }
                            }
                            else // Если нет директории пользователей
                            {
                                Sound.Button_Click_Mistake_Sound();
                                MessageBox.Show("Данный пользователь отсутствует!");
                            }
                        }
                        else // Пароль содержит пробелы
                        {
                            Sound.Button_Click_Mistake_Sound();
                            MessageBox.Show("Пароль содержит пробелы!");
                        }
                    }
                    else // Пароль пустой
                    {
                        Sound.Button_Click_Mistake_Sound();
                        MessageBox.Show("Пароль пустой!");
                    }
                }
                else // Имя содержит пробелы
                {
                    Sound.Button_Click_Mistake_Sound();
                    MessageBox.Show("Имя пользователя содержит пробелы!");
                }
            }
            else // Имя пользователя пустое
            {
                Sound.Button_Click_Mistake_Sound();
                MessageBox.Show("Имя пользователя пустое!");
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

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
