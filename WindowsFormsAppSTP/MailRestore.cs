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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppSTP
{
    public partial class MailRestore : Form
    {
        public MailRestore()
        {
            InitializeComponent();
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text != null)
            {
                if (!bunifuTextBox1.Text.Contains(" "))
                {
                    string currentPath = Directory.GetCurrentDirectory();
                    if (Directory.Exists(Path.Combine(currentPath, "Users")))
                    {
                        if (Directory.Exists(Path.Combine(currentPath + "/Users/" + $"{bunifuTextBox1.Text}")))
                        {
                            if (File.Exists(Path.Combine(currentPath + "/Users" + $"/{bunifuTextBox1.Text}/" + $"/{bunifuTextBox1.Text}.txt")))
                            {
                                try
                                {
                                    Sound.Button_Click_Sound();
                                    string mail = Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{bunifuTextBox1.Text}/" + $"/{bunifuTextBox1.Text}.txt").Skip(1).First());
                                    string password = Shifr.EncodeDecrypt(File.ReadLines(currentPath + "/Users" + $"/{bunifuTextBox1.Text}/" + $"/{bunifuTextBox1.Text}.txt").First());
                                    Mail.SendMessage(bunifuTextBox1.Text, $"{mail}", $"Ditary password restore", $"Your password is {password}!\nOur team is always ready to help you!\nThanks for using our app)");
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
                                MessageBox.Show("Данные пользователя отсутствуют!");
                            }
                        }
                        else
                        {
                            Sound.Button_Click_Mistake_Sound();
                            MessageBox.Show("Не создано ни одного пользователя!");
                        }
                    }
                    else
                    {
                        Sound.Button_Click_Mistake_Sound();
                        MessageBox.Show("Не создано ни одного пользователя!");
                    }
                }
                else
                {
                    MessageBox.Show("Имя пользователя не должно содержать пробелы!");
                }
            }
            else
            {
                Sound.Button_Click_Mistake_Sound();
                MessageBox.Show("Имя пользователя не должно быть пустым!");
            }
        }
    }
}
