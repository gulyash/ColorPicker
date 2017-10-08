using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPickerIbr
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<RadioButton, Color> commonColors;

        public Color SelectedColor
        {
            set
            {
                pictureBox.BackColor = value;
            }
        }

        public Form1()
        {
            InitializeComponent();

            commonColors = new Dictionary<RadioButton, Color>
            {
                {radioButtonBlack, Color.Black },
                {radioButtonRed, Color.Red },
                {radioButtonGreen, Color.Green },
                {radioButtonYellow, Color.Yellow },
                {radioButtonBlue, Color.Blue },
                {radioButtonMagenta, Color.DarkMagenta },
                {radioButtonCyan, Color.Cyan },
                {radioButtonWhite, Color.White },
            };
        }

        private void trackBarRed_Scroll(object sender, EventArgs e)
        {
            SelectedColor = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
        }

        private void trackBarGreen_Scroll(object sender, EventArgs e)
        {
            SelectedColor = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
        }

        private void trackBarBlue_Scroll(object sender, EventArgs e)
        {
            SelectedColor = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
        }

        private void radioButtonBlack_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (commonColors.ContainsKey(rb))
            {
                SelectedColor = commonColors[rb];
            }
        }
    }
}
