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
using static System.Net.Mime.MediaTypeNames;


namespace WindowsFormsAppSTP
{
    public partial class VievNotes : Form
    {
        public string user_name;
        public VievNotes(string user_name_local)
        {
            InitializeComponent();
            user_name = user_name_local;
            bunifuTextBox2.Visible = false;
        }

        public void ComboBox_Load(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Visible ==false)
            {
                comboBox1.Items.Clear();
                string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
                try
                {
                    int sch = Convert.ToInt32(Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.rtf").Skip(2).First()));// Берём количество существующих файлов/нумерация
                    for (int i = 0; i < sch; i++)
                    {
                        if (File.Exists(Path.Combine(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf"))) // Если файл с заметкой n существует
                        {
                            Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf").First() + " - " + File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf").Skip(1).First();// Читаем название заметки
                            comboBox1.Items.Add($"{Name}");// Добавляем в комбо бокс
                        }
                        else// Если файл с заметкой не существует
                        {

                        }
                    }
                    bunifuTextBox2.Visible = true;
                }
                catch (Exception excep)
                {
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
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            string Value = "";
            try
            {
                int sch = Convert.ToInt32(Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.rtf").Skip(2).First()));
                for (int i = 0; i <sch; i++) 
                {
                    if (File.Exists(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf")) 
                    { 
                        if((File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf").First() + " - " + File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf").Skip(1).First()) == comboBox1.Text) 
                        {
                            using (StreamReader reader = new StreamReader(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf"))
                            {
                                int j = 0;
                                string line;
                                while ((line = await reader.ReadLineAsync()) != null)
                                {
                                    if (j > 1)
                                        Value += line + "\n";
                                    else j++;
                                }
                            }
                            richTextBox1.Text = Value;// Записываем текст в текст бокс
                            break;
                        }
                    }
                }
            }
            catch (Exception excep)
            {
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
        public void ContentSearch() 
        {
            comboBox1.Items.Clear();
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            try
            {
                int sch = Convert.ToInt32(Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.rtf").Skip(2).First()));// Берём количество существующих файлов/нумерация
                for (int i = 0; i < sch; i++)
                {
                    try
                    {
                        if (File.Exists(Path.Combine(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf"))) // Если файл с заметкой n существует
                        {
                            Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf").First() + " - " + File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.rtf").Skip(1).First();// Читаем название заметки
                            if (Name.Contains(bunifuTextBox2.Text))
                            {
                                comboBox1.Items.Add($"{Name}");// Добавляем в комбо бокс
                            }
                        }
                        else// Если файл с заметкой не существует
                        {

                        }
                    }
                    catch (Exception excep)
                    {
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
            }
            catch (Exception excep)
            {
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

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            ContentSearch();
        }
        private void ComboBox_Leave(object sender, MouseEventArgs e)
        {
            bunifuTextBox2.Visible = false;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            NotesToMail notes_to_mail = new NotesToMail(user_name);
            notes_to_mail.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            NotesToFolder notes_to_folder = new NotesToFolder(user_name);
            notes_to_folder.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextBox1.SelectionColor = colorDialog.Color;
        }
    }
}
