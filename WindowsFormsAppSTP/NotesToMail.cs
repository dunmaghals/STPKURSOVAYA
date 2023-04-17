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
    public partial class NotesToMail : Form
    {
        public string user_name;
        public NotesToMail(string local_user_name)
        {
            InitializeComponent();
            user_name = local_user_name;
        }

        private void comboBox1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            int sch = Convert.ToInt32(Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First()));// Берём количество существующих файлов/нумерация
            for (int i = 0; i < sch; i++)
            {
                if (File.Exists(Path.Combine(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt"))) // Если файл с заметкой n существует
                {
                    Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").First() + " - " + File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").Skip(1).First();// Читаем название заметки
                    
                    comboBox1.Items.Add($"{Name}");// Добавляем в комбо бокс
                }
                else// Если файл с заметкой не существует
                {

                }
            }
        }
        public void ContentSearch()
        {
            comboBox1.Items.Clear();
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            int sch = Convert.ToInt32(Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First()));// Берём количество существующих файлов/нумерация
            for (int i = 0; i < sch; i++)
            {
                if (File.Exists(Path.Combine(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt"))) // Если файл с заметкой n существует
                {
                    Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").First() + " - " + File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").Skip(1).First();// Читаем название заметки
                    if (Name.Contains(bunifuTextBox1.Text))
                    {
                        comboBox1.Items.Add($"{Name}");// Добавляем в комбо бокс
                    }
                }
                else// Если файл с заметкой не существует
                {

                }
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            ContentSearch();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (comboBox1 != null) 
            {
                if (!comboBox2.Items.Contains(comboBox1.SelectedItem))
                    comboBox2.Items.Add(comboBox1.SelectedItem);
                else
                    MessageBox.Show("Такая заметка уже внесена!");
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (comboBox2 != null)
            {
                comboBox2.Items.Remove(comboBox2.SelectedItem);
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if(comboBox2 != null) 
            {
                string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
                int sch = Convert.ToInt32(Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First()));// Берём количество существующих файлов/нумерация
                string[] array = new string[comboBox2.Items.Count];
                int array_sch = 0;
                string messadge_text = "Your notes are:";
                for (int i = 0; i < sch; i++) 
                {
                    Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").First() + " - " + File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").Skip(1).First();// Читаем название заметки
                    
                    if (comboBox2.Items.Contains(Name)) 
                    {
                        array[array_sch] = currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt";
                        array_sch++;
                        messadge_text += " "+File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").First()+";";
                    }
                }
                string mail = Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(1).First());
                Mail.SendFile(user_name, $"{mail}", $"Ditary notes request",messadge_text, array);
                this.Close();
            }
        }
    }
}
