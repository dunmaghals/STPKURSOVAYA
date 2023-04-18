using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsAppSTP
{
    public partial class NotesToFolder : Form
    {
        public string user_name;
        public string folder_path;
        public NotesToFolder(string local_user_name)
        {
            InitializeComponent();
            user_name = local_user_name;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folder_path = folderBrowserDialog1.SelectedPath;// запишем в нашу переменную путь к папке
                string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
                int sch = Convert.ToInt32(Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First()));// Берём количество существующих файлов/нумерация
                for (int i = 0; i < sch; i++)
                {
                    Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").First() + " - " + File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").Skip(1).First();// Читаем название заметки

                    if (comboBox2.Items.Contains(Name))
                    {
                        File.Copy(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt", folder_path+ $"/{user_name}_Data{i}.txt");
                    }
                }
                MessageBox.Show("Выгрузка заметок произошла успешно!");
                this.Close();
            }
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

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            ContentSearch();
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
    }
}
