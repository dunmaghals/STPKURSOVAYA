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
using System.Messaging;

namespace WindowsFormsAppSTP
{
    public partial class CreateNote : Form
    {
        public string user_name;// Имя пользователя
        public CreateNote()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1 != null)// Проверка на пустоту первого текст бокса
            {
                    string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
                    Sound.Button_Click_Sound();
                    try
                    {
                        string sch = Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.rtf").Skip(2).First());// Берём количество существующих файлов/нумерация
                        bool check = false;
                        for(int i = 0; i < Convert.ToInt32(sch); i++) 
                        { 
                            if(File.Exists(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf")) 
                            { 

                            }
                            else 
                            {
                                check = true;
                                using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                                {
                                    await fayl.WriteLineAsync(bunifuTextBox1.Text);//Записываем название заметки в файл
                                    await fayl.WriteLineAsync(dateTimePicker1.Text);//Записываем дату заметки в файл
                                    await fayl.WriteAsync(richTextBox1.Text);//Записываем заметку бокс в файл
                                }
                            break;
                            }
                        }
                        if (check == false)
                        {
                            using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{sch}.rtf"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                            {
                                await fayl.WriteLineAsync(bunifuTextBox1.Text);//Записываем название заметки в файл
                                await fayl.WriteLineAsync(dateTimePicker1.Text);//Записываем дату заметки в файл
                                await fayl.WriteAsync(richTextBox1.Text);//Записываем заметку бокс в файл
                            }
                            sch = Convert.ToString(Convert.ToInt32(sch) + 1);// Увеличиваем счётчик
                            string password = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.rtf").Skip(0).First();// Берём пароль
                            string mail = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.rtf").Skip(1).First();// Берём почту
                            using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.rtf"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                            {
                                await fayl.WriteLineAsync($"{password}");// Перезаписываем пароль
                                await fayl.WriteLineAsync($"{mail}");// Перезаписываем почту
                                await fayl.WriteLineAsync($"{Shifr.EncodeDecrypt(sch)}");// Вводим колличество заметок
                            }
                            Hide();
                        }
                        else { Hide(); }
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
            else// Если пустое
            {
                Sound.Button_Click_Mistake_Sound();
                MessageBox.Show("Пустым поле имени быть не должно!");
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if(fontDialog.ShowDialog() == DialogResult.OK) 
            { 
                richTextBox1.Font=fontDialog.Font;
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextBox1.SelectionColor = colorDialog.Color;
        }
    }
}
