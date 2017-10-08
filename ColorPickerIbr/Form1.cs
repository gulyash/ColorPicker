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

            List<Color> colors = new List<Color>
            {
                Color.Aquamarine,
                Color.Beige,
                Color.BurlyWood,
                Color.Coral,
                Color.Crimson,
                Color.DarkOliveGreen,
                Color.Gainsboro,
                Color.Gray,
                Color.Maroon
            };
            comboBoxColor.DataSource = colors;
            comboBoxColor.DisplayMember = Name;

            comboBoxColor.SelectedIndexChanged += comboBoxColor_SelectedIndexChanged;
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

        private void checkBoxRed_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                trackBarRed.Enabled = true;
                SelectedColor = Color.FromArgb(trackBarRed.Value, pictureBox.BackColor.G, pictureBox.BackColor.B);
            }
            else
            {
                trackBarRed.Enabled = false;
                SelectedColor = Color.FromArgb(0, pictureBox.BackColor.G, pictureBox.BackColor.B);
            }
        }

        private void checkBoxGreen_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                trackBarGreen.Enabled = true;
                SelectedColor = Color.FromArgb(pictureBox.BackColor.R, trackBarGreen.Value, pictureBox.BackColor.B);
            }
            else
            {
                trackBarGreen.Enabled = false;
                SelectedColor = Color.FromArgb(pictureBox.BackColor.R, 0, pictureBox.BackColor.B);
            }
        }

        private void checkBoxBlue_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                trackBarBlue.Enabled = true;
                SelectedColor = Color.FromArgb(pictureBox.BackColor.R, pictureBox.BackColor.G, trackBarBlue.Value);
            }
            else
            {
                trackBarBlue.Enabled = false;
                SelectedColor = Color.FromArgb(pictureBox.BackColor.R, pictureBox.BackColor.G, 0);
            }
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxRed.Checked = true;
            checkBoxGreen.Checked = true;
            checkBoxBlue.Checked = true;
            SelectedColor = (Color)comboBoxColor.SelectedItem;
        }
    }
}
