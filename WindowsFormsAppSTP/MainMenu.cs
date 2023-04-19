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
using System.Threading;
using FluentFTP;
using Bunifu.UI.WinForms;
using Timer = System.Windows.Forms.Timer;



namespace WindowsFormsAppSTP
{
    public partial class MainMenu : Form
    {
        public string user_name;// Имя пользователя
        WMPLib.WindowsMediaPlayer wplayer;
        Timer tmr = new Timer();
        int sch=1;
        public MainMenu(string user_name_local)
        {
            InitializeComponent();
            Inet.StartServ();
            user_name = user_name_local;
            try 
            {
                string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
                Sound.volume = Convert.ToInt32(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_sound.txt").First());
            }
            catch
            {
            }
            tmr.Interval = 10;
            tmr.Stop();
            tmr.Tick += new EventHandler(tmr_Tick);
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "Back_Music_1.mp3";
            wplayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
            wplayer.controls.play();
        }
        void wplayer_PlayStateChange(int NewState)
        {
            if (NewState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                switch (sch) 
                {
                    case 0:
                        wplayer.URL = "Back_Music_1.mp3";
                        sch++;
                        tmr.Start();
                        break;
                    case 1:
                        wplayer.URL = "Back_Music_2.mp3";
                        sch++;
                        tmr.Start();
                        break;
                    case 2:
                        wplayer.URL = "Back_Music_3.mp3";
                        sch++;
                        tmr.Start();
                        break;
                    case 3:
                        wplayer.URL = "Back_Music_4.mp3";
                        sch = 0;
                        tmr.Start();
                        break;
                }
            }
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            wplayer.controls.play();
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
            Sound.Button_Click_Sound();
            CreateNote fr4 = new CreateNote();// Новая форма заметки
            fr4.user_name = user_name;// Переносим данные о имени пользователя в другую форму/форму добавления заметок
            fr4.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            //string Value = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{comboBox1.SelectedIndex}.txt").Skip(1).First();// Берём текст заметки
            //textBox1.Text = Value;// Записываем текст в текст бокс
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            VievNotes fr4 = new VievNotes(user_name);// Новая форма заметки
            fr4.Show();
        }
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            Settings settings = new Settings(user_name);
            settings.Show();
        }

        private async void bunifuButton4_Click(object sender, EventArgs e)
        {
            Sound.Button_Click_Sound();
            try 
            {
                string currentPath = Directory.GetCurrentDirectory();// Берём выбранный путь приложения
                using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_sound.txt"))// Создаём файл с именем пользователя в каталоге имени пользователя)
                {
                    await fayl.WriteLineAsync($"{Sound.volume}");// Вводим пароль
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
            Inet.StopServ();
            Application.Exit();
        }
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Inet.StopServ();
            Application.Exit();
        }

        private void OnFormClosed(object sender, FormClosingEventArgs e)
        {
            Inet.StopServ();
            Application.Exit();
        }

        private void Music_timer_Tick(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:5000/");
        }
    }
}
