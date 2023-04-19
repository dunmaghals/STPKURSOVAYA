using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSTP
{
    public partial class SoundChange : Form
    {
        public SoundChange()
        {
            InitializeComponent();
            bunifuHSlider1.Maximum = 100;
            bunifuHSlider1.Minimum = 0;
            bunifuHSlider1.Value = Sound.volume;
        }

        private void bunifuHSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            Sound.volume = bunifuHSlider1.Value;
            Sound.Volume_Change(bunifuHSlider1.Value);
        }
    }
}
