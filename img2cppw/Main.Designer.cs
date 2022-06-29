
namespace img2cppw
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.ImageFileTextBox = new System.Windows.Forms.TextBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.TypeComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ArduinoCheckBox = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.WidthTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.HeightTextBox = new System.Windows.Forms.TextBox();
			this.BigEndianCheckBox = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.FormatComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// OpenDialog
			// 
			this.OpenDialog.Filter = "Image Files|*.bmp;*.jpg;*.png|All files (*.*)|*.*";
			// 
			// SaveDialog
			// 
			this.SaveDialog.Filter = "C++ Header|*.hpp|All Files|*.*";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Image";
			// 
			// ImageFileTextBox
			// 
			this.ImageFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImageFileTextBox.Location = new System.Drawing.Point(65, 10);
			this.ImageFileTextBox.Name = "ImageFileTextBox";
			this.ImageFileTextBox.Size = new System.Drawing.Size(212, 26);
			this.ImageFileTextBox.TabIndex = 1;
			// 
			// BrowseButton
			// 
			this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BrowseButton.Location = new System.Drawing.Point(283, 6);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(40, 35);
			this.BrowseButton.TabIndex = 2;
			this.BrowseButton.Text = "...";
			this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.BrowseButton.UseVisualStyleBackColor = true;
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(8, 174);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(130, 31);
			this.SaveButton.TabIndex = 3;
			this.SaveButton.Text = "Save...";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Name";
			// 
			// NameTextBox
			// 
			this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NameTextBox.Location = new System.Drawing.Point(65, 42);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(251, 26);
			this.NameTextBox.TabIndex = 6;
			// 
			// TypeComboBox
			// 
			this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeComboBox.FormattingEnabled = true;
			this.TypeComboBox.Items.AddRange(new object[] {
            "C++",
            "GFX/C++14",
            "GFX/C++17"});
			this.TypeComboBox.Location = new System.Drawing.Point(65, 75);
			this.TypeComboBox.Name = "TypeComboBox";
			this.TypeComboBox.Size = new System.Drawing.Size(121, 28);
			this.TypeComboBox.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "Type";
			// 
			// ArduinoCheckBox
			// 
			this.ArduinoCheckBox.AutoSize = true;
			this.ArduinoCheckBox.Location = new System.Drawing.Point(193, 79);
			this.ArduinoCheckBox.Name = "ArduinoCheckBox";
			this.ArduinoCheckBox.Size = new System.Drawing.Size(90, 24);
			this.ArduinoCheckBox.TabIndex = 9;
			this.ArduinoCheckBox.Text = "Arduino";
			this.ArduinoCheckBox.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "Size";
			// 
			// WidthTextBox
			// 
			this.WidthTextBox.Location = new System.Drawing.Point(65, 109);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.Size = new System.Drawing.Size(58, 26);
			this.WidthTextBox.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(130, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 20);
			this.label5.TabIndex = 12;
			this.label5.Text = "x";
			// 
			// HeightTextBox
			// 
			this.HeightTextBox.Location = new System.Drawing.Point(152, 109);
			this.HeightTextBox.Name = "HeightTextBox";
			this.HeightTextBox.Size = new System.Drawing.Size(58, 26);
			this.HeightTextBox.TabIndex = 13;
			// 
			// BigEndianCheckBox
			// 
			this.BigEndianCheckBox.AutoSize = true;
			this.BigEndianCheckBox.Location = new System.Drawing.Point(193, 144);
			this.BigEndianCheckBox.Name = "BigEndianCheckBox";
			this.BigEndianCheckBox.Size = new System.Drawing.Size(112, 24);
			this.BigEndianCheckBox.TabIndex = 14;
			this.BigEndianCheckBox.Text = "Big Endian";
			this.BigEndianCheckBox.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "Fmt";
			// 
			// FormatComboBox
			// 
			this.FormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FormatComboBox.FormattingEnabled = true;
			this.FormatComboBox.Items.AddRange(new object[] {
            "RGB888",
            "RGB565",
            "JPG"});
			this.FormatComboBox.Location = new System.Drawing.Point(65, 140);
			this.FormatComboBox.Name = "FormatComboBox";
			this.FormatComboBox.Size = new System.Drawing.Size(121, 28);
			this.FormatComboBox.TabIndex = 15;
			this.FormatComboBox.SelectedIndexChanged += new System.EventHandler(this.FormatComboBox_SelectedIndexChanged);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 217);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.FormatComboBox);
			this.Controls.Add(this.BigEndianCheckBox);
			this.Controls.Add(this.HeightTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.WidthTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ArduinoCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TypeComboBox);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.BrowseButton);
			this.Controls.Add(this.ImageFileTextBox);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(351, 273);
			this.Name = "Main";
			this.Text = "img2cpp";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog OpenDialog;
		private System.Windows.Forms.SaveFileDialog SaveDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ImageFileTextBox;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.ComboBox TypeComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox ArduinoCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox WidthTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox HeightTextBox;
		private System.Windows.Forms.CheckBox BigEndianCheckBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox FormatComboBox;
	}
}

