using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ColorPickerIbr
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<RadioButton, Color> rbColors;
		private readonly List<Color> colors;
		private bool rbUpdated = false;
		
		private bool areSameColor(Color c1, Color c2)
		{
			return c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
		}

		public Color SelectedColor
		{
			set { pictureBox.BackColor = value; }
			get { return pictureBox.BackColor; }
		}

        public Form1()
        {
            InitializeComponent();

			colors = new List<Color>
			{
				Color.Black,
				Color.Red,
				Color.Lime,
				Color.Yellow,
				Color.Blue,
				Color.Magenta,
				Color.Cyan,
				Color.White
			};

			rbColors = new Dictionary<RadioButton, Color>
			{
				{radioButtonBlack, colors[0] },
				{radioButtonRed, colors[1] },
				{radioButtonGreen, colors[2] },
				{radioButtonYellow, colors[3] },
				{radioButtonBlue, colors[4] },
				{radioButtonMagenta, colors[5] },
				{radioButtonCyan, colors[6] },
				{radioButtonWhite, colors[7] },
			};

			comboBoxColor.DataSource = colors;
            comboBoxColor.DisplayMember = Name;
        }

		private void trackBar_Scroll(object sender, EventArgs e)
		{
			SelectedColor = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
			UpdateUI();
		}

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
			var rb = (RadioButton)sender;
			if (rbColors.ContainsKey(rb))
			{
				SelectedColor = rbColors[rb];
			}
			UpdateUI();
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
			CheckBox checkBox = (CheckBox)sender;
			int channelValue;
			channelValue = checkBox.Checked ? 255 : 0;
			switch (checkBox.Text.ToString())
			{
				case "Красный":
					SelectedColor = Color.FromArgb(channelValue, pictureBox.BackColor.G, pictureBox.BackColor.B);
					break;
				case "Зеленый":
					SelectedColor = Color.FromArgb(pictureBox.BackColor.R, channelValue, pictureBox.BackColor.B);
					break;
				case "Синий":
					SelectedColor = Color.FromArgb(pictureBox.BackColor.R, pictureBox.BackColor.G, channelValue);
					break;
			}
			UpdateUI();
		}

		private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedColor = (Color)comboBoxColor.SelectedItem;
			UpdateUI();
		}

		private void UpdateUI()
		{
			update_trackBars();
			update_checkBoxes();
			update_comboBox();
			if (!rbUpdated)
			{
				rbUpdated = true;
				update_radioButtons();
				rbUpdated = false;
			}
		}

		private void update_trackBars()
		{
			trackBarRed.Value = SelectedColor.R;
			trackBarGreen.Value = SelectedColor.G;
			trackBarBlue.Value = SelectedColor.B;
		}
		
		private void update_checkBoxes()
		{
			checkBoxRed.Checked = SelectedColor.R > 127;
			checkBoxGreen.Checked = SelectedColor.G > 127;
			checkBoxBlue.Checked = SelectedColor.B > 127;
		}

		private void update_comboBox()
		{
			foreach (var c in comboBoxColor.Items)
			{
				if (areSameColor((Color)c, SelectedColor))
				{
					comboBoxColor.SelectedItem = (Color)c;
				}
			}
		}

		private void update_radioButtons()
		{
			foreach (var pair in rbColors)
			{
				RadioButton rb = pair.Key;
				if (areSameColor(rbColors[rb], SelectedColor))
				{
					rb.Select();
					break;
				}
			}
		}

		private void update_radioButtons(object sender, EventArgs e)
		{
			foreach (var pair in rbColors)
			{
				RadioButton rb = pair.Key;
				if (areSameColor(rbColors[rb], SelectedColor))
				{
					rb.Select();
					break;
				}
			}
		}
	}
}
