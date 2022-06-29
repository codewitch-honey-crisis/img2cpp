using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using img2cpp;
namespace img2cppw
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
			TypeComboBox.SelectedIndex = 0;
			FormatComboBox.SelectedIndex = 0;
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			if(DialogResult.OK==OpenDialog.ShowDialog())
			{
				ImageFileTextBox.Text = OpenDialog.FileName;
				NameTextBox.Text = Img2CppGen.PathToCppName(ImageFileTextBox.Text);
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if(DialogResult.OK!=SaveDialog.ShowDialog())
			{
				return;
			}
			Img2CppType type;
			switch(TypeComboBox.SelectedIndex)
			{
				case 0:
					type = Img2CppType.Cpp;
					break;
				case 1:
					type = Img2CppType.Gfx14;
					break;
				default: // 2
					type = Img2CppType.Gfx17;
					break;
			}
			bool jpg = FormatComboBox.SelectedIndex == 2;
			bool be = BigEndianCheckBox.Checked && BigEndianCheckBox.Enabled;
			bool cvt16bpp = FormatComboBox.SelectedIndex == 1;
			bool arduino = ArduinoCheckBox.Checked;
			Size size=Size.Empty;
			if(!string.IsNullOrEmpty(WidthTextBox.Text))
			{
				try
				{
					size.Width = int.Parse(WidthTextBox.Text);
				}
				catch
				{

				}
			}
			if (!string.IsNullOrEmpty(HeightTextBox.Text))
			{
				try
				{
					size.Height = int.Parse(HeightTextBox.Text);
				}
				catch
				{

				}
			}
			using (var writer = new StreamWriter(File.OpenWrite(SaveDialog.FileName), System.Text.Encoding.ASCII))
			{
				Img2CppGen.Generate(ImageFileTextBox.Text, NameTextBox.Text, type, jpg, be, cvt16bpp, arduino, size, writer);
			}
		}

		private void FormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			BigEndianCheckBox.Enabled = FormatComboBox.SelectedIndex == 1;
		}
	}
}
