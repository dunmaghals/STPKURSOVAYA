using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace WindowsFormsAppSTP
{
    internal class Sound
    {
        public static int volume = 100;
        public static void Button_Click_Sound()
        {
            try
            {
                WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
                WMP.settings.volume = volume;
                WMP.URL= "Button_Click.wav";
                WMP.controls.play();;
            }
            catch
            { 

            }
        }
        public static void Button_Click_Mistake_Sound()
        {
            try
            {
                WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
                WMP.settings.volume = volume;
                WMP.URL = "Button_Click_Mistake.wav";
                WMP.controls.play();
            }
            catch
            {

            }
        }
        public static void Volume_Change(int volumes) 
        {
            volume = volumes;
        }
    }
}
