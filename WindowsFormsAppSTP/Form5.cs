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
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsAppSTP
{
    public partial class Form5 : Form
    {
        public string user_name;// Имя пользователя
        public Form5()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null)// Проверка на пустоту первого текст бокса
            {
                if (!textBox1.Text.Contains(" "))// Проверка на содержание пробелов в первом текст боксе
                {
                    string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
                    string sch = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First();// Берём количество существующих файлов/нумерация
                    using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{sch}.txt"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                    {
                        await fayl.WriteLineAsync(textBox1.Text);//Записываем название заметки в файл
                        await fayl.WriteLineAsync(dateTimePicker1.Text);//Записываем дату заметки в файл
                        await fayl.WriteAsync(richTextBox1.Text);//Записываем заметку бокс в файл
                    }
                    sch=Convert.ToString(Convert.ToInt32(sch)+1);// Увеличиваем счётчик
                    string password = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(0).First();// Берём пароль
                    string mail = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(1).First();// Берём почту
                    using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                    {
                        await fayl.WriteLineAsync($"{password}");// Перезаписываем пароль
                        await fayl.WriteLineAsync($"{mail}");// Перезаписываем почту
                        await fayl.WriteLineAsync($"{sch}");// Вводим колличество заметок
                    }
                    Hide();
                }
                else// Если содержит пробел
                {
                    MessageBox.Show("Содержание пробелов не допустимо!");
                }
            }
            else// Если пустое
            {
                MessageBox.Show("Пустым поле имени быть не должно!");
            }
        }
    }
}
