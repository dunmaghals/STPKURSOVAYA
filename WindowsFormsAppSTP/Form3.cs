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
    public partial class Form3 : Form
    {
        public string user_name;// Имя пользователя
        public Form3(string user_name_local)
        {
            InitializeComponent();
            user_name = user_name_local;
        }
        public void ComboBox_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            int sch = Convert.ToInt32(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First());// Берём количество существующих файлов/нумерация
            for (int i = 0; i <sch; i++)
            {
                if (File.Exists(Path.Combine(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt"))) // Если файл с заметкой n существует
                {
                    Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").First();// Читаем название заметки
                    //comboBox1.Items.Add($"{Name}");// Добавляем в комбо бокс
                }
                else// Если файл с заметкой не существует
                {

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 fr4 = new Form5();// Новая форма заметки
            fr4.user_name = user_name;// Переносим данные о имени пользователя в другую форму/форму добавления заметок
            fr4.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            //string Value = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{comboBox1.SelectedIndex}.txt").Skip(1).First();// Берём текст заметки
            //textBox1.Text = Value;// Записываем текст в текст бокс
        }
    }
}
