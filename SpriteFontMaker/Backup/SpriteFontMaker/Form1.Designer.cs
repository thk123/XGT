namespace SpriteFontMaker
{
    partial class Form1
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
            this.fontNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bold0 = new System.Windows.Forms.CheckBox();
            this.ital0 = new System.Windows.Forms.CheckBox();
            this.fontSize1 = new System.Windows.Forms.NumericUpDown();
            this.exportName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ital1 = new System.Windows.Forms.CheckBox();
            this.bold1 = new System.Windows.Forms.CheckBox();
            this.fontName1 = new System.Windows.Forms.TextBox();
            this.fontName2 = new System.Windows.Forms.TextBox();
            this.ital2 = new System.Windows.Forms.CheckBox();
            this.bold2 = new System.Windows.Forms.CheckBox();
            this.fontSize2 = new System.Windows.Forms.NumericUpDown();
            this.fontName3 = new System.Windows.Forms.TextBox();
            this.ital3 = new System.Windows.Forms.CheckBox();
            this.bold3 = new System.Windows.Forms.CheckBox();
            this.fontSize3 = new System.Windows.Forms.NumericUpDown();
            this.fontName4 = new System.Windows.Forms.TextBox();
            this.ital4 = new System.Windows.Forms.CheckBox();
            this.bold4 = new System.Windows.Forms.CheckBox();
            this.fontSize4 = new System.Windows.Forms.NumericUpDown();
            this.fontName5 = new System.Windows.Forms.TextBox();
            this.ital5 = new System.Windows.Forms.CheckBox();
            this.bold5 = new System.Windows.Forms.CheckBox();
            this.fontSize5 = new System.Windows.Forms.NumericUpDown();
            this.fontName6 = new System.Windows.Forms.TextBox();
            this.ital6 = new System.Windows.Forms.CheckBox();
            this.bold6 = new System.Windows.Forms.CheckBox();
            this.fontSize6 = new System.Windows.Forms.NumericUpDown();
            this.fontName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize6)).BeginInit();
            this.SuspendLayout();
            // 
            // fontNameLabel
            // 
            this.fontNameLabel.AutoSize = true;
            this.fontNameLabel.Location = new System.Drawing.Point(16, 51);
            this.fontNameLabel.Name = "fontNameLabel";
            this.fontNameLabel.Size = new System.Drawing.Size(62, 13);
            this.fontNameLabel.TabIndex = 0;
            this.fontNameLabel.Text = "Font Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Use if you want bold/italic for all variations";
            // 
            // bold0
            // 
            this.bold0.AutoSize = true;
            this.bold0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bold0.Location = new System.Drawing.Point(251, 93);
            this.bold0.Name = "bold0";
            this.bold0.Size = new System.Drawing.Size(51, 17);
            this.bold0.TabIndex = 3;
            this.bold0.Text = "Bold";
            this.bold0.UseVisualStyleBackColor = true;
            this.bold0.Click += new System.EventHandler(this.bold0_CheckedChanged);
            this.bold0.CheckedChanged += new System.EventHandler(this.nameUpdateReq);
            // 
            // ital0
            // 
            this.ital0.AutoSize = true;
            this.ital0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ital0.Location = new System.Drawing.Point(337, 93);
            this.ital0.Name = "ital0";
            this.ital0.Size = new System.Drawing.Size(53, 17);
            this.ital0.TabIndex = 4;
            this.ital0.Text = "Italics";
            this.ital0.UseVisualStyleBackColor = true;
            this.ital0.Click += new System.EventHandler(this.ital0_CheckedChanged);
            this.ital0.CheckedChanged += new System.EventHandler(this.nameUpdateReq);
            // 
            // fontSize1
            // 
            this.fontSize1.Location = new System.Drawing.Point(142, 147);
            this.fontSize1.Name = "fontSize1";
            this.fontSize1.Size = new System.Drawing.Size(79, 20);
            this.fontSize1.TabIndex = 5;
            this.fontSize1.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // exportName
            // 
            this.exportName.AutoSize = true;
            this.exportName.Location = new System.Drawing.Point(20, 119);
            this.exportName.Name = "exportName";
            this.exportName.Size = new System.Drawing.Size(68, 13);
            this.exportName.TabIndex = 6;
            this.exportName.Text = "Export Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Font Size";
            // 
            // ital1
            // 
            this.ital1.AutoSize = true;
            this.ital1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ital1.Location = new System.Drawing.Point(340, 149);
            this.ital1.Name = "ital1";
            this.ital1.Size = new System.Drawing.Size(53, 17);
            this.ital1.TabIndex = 9;
            this.ital1.Text = "Italics";
            this.ital1.UseVisualStyleBackColor = true;
            this.ital1.Click += new System.EventHandler(this.ital1_CheckedChanged);
            // 
            // bold1
            // 
            this.bold1.AutoSize = true;
            this.bold1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bold1.Location = new System.Drawing.Point(254, 149);
            this.bold1.Name = "bold1";
            this.bold1.Size = new System.Drawing.Size(51, 17);
            this.bold1.TabIndex = 8;
            this.bold1.Text = "Bold";
            this.bold1.UseVisualStyleBackColor = true;
            this.bold1.Click += new System.EventHandler(this.bold1_CheckedChanged);
            // 
            // fontName1
            // 
            this.fontName1.Location = new System.Drawing.Point(23, 147);
            this.fontName1.Name = "fontName1";
            this.fontName1.Size = new System.Drawing.Size(100, 20);
            this.fontName1.TabIndex = 10;
            // 
            // fontName2
            // 
            this.fontName2.Location = new System.Drawing.Point(23, 180);
            this.fontName2.Name = "fontName2";
            this.fontName2.Size = new System.Drawing.Size(100, 20);
            this.fontName2.TabIndex = 14;
            // 
            // ital2
            // 
            this.ital2.AutoSize = true;
            this.ital2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ital2.Location = new System.Drawing.Point(340, 182);
            this.ital2.Name = "ital2";
            this.ital2.Size = new System.Drawing.Size(53, 17);
            this.ital2.TabIndex = 13;
            this.ital2.Text = "Italics";
            this.ital2.UseVisualStyleBackColor = true;
            this.ital2.Click += new System.EventHandler(this.ital2_CheckedChanged);
            // 
            // bold2
            // 
            this.bold2.AutoSize = true;
            this.bold2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bold2.Location = new System.Drawing.Point(254, 182);
            this.bold2.Name = "bold2";
            this.bold2.Size = new System.Drawing.Size(51, 17);
            this.bold2.TabIndex = 12;
            this.bold2.Text = "Bold";
            this.bold2.UseVisualStyleBackColor = true;
            this.bold2.Click += new System.EventHandler(this.bold2_CheckedChanged);
            // 
            // fontSize2
            // 
            this.fontSize2.Location = new System.Drawing.Point(142, 180);
            this.fontSize2.Name = "fontSize2";
            this.fontSize2.Size = new System.Drawing.Size(79, 20);
            this.fontSize2.TabIndex = 11;
            this.fontSize2.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // fontName3
            // 
            this.fontName3.Location = new System.Drawing.Point(23, 213);
            this.fontName3.Name = "fontName3";
            this.fontName3.Size = new System.Drawing.Size(100, 20);
            this.fontName3.TabIndex = 18;
            // 
            // ital3
            // 
            this.ital3.AutoSize = true;
            this.ital3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ital3.Location = new System.Drawing.Point(340, 215);
            this.ital3.Name = "ital3";
            this.ital3.Size = new System.Drawing.Size(53, 17);
            this.ital3.TabIndex = 17;
            this.ital3.Text = "Italics";
            this.ital3.UseVisualStyleBackColor = true;
            this.ital3.Click += new System.EventHandler(this.ital3_CheckedChanged);
            // 
            // bold3
            // 
            this.bold3.AutoSize = true;
            this.bold3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bold3.Location = new System.Drawing.Point(254, 215);
            this.bold3.Name = "bold3";
            this.bold3.Size = new System.Drawing.Size(51, 17);
            this.bold3.TabIndex = 16;
            this.bold3.Text = "Bold";
            this.bold3.UseVisualStyleBackColor = true;
            this.bold3.Click += new System.EventHandler(this.bold3_CheckedChanged);
            // 
            // fontSize3
            // 
            this.fontSize3.Location = new System.Drawing.Point(142, 213);
            this.fontSize3.Name = "fontSize3";
            this.fontSize3.Size = new System.Drawing.Size(79, 20);
            this.fontSize3.TabIndex = 15;
            this.fontSize3.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // fontName4
            // 
            this.fontName4.Location = new System.Drawing.Point(23, 245);
            this.fontName4.Name = "fontName4";
            this.fontName4.Size = new System.Drawing.Size(100, 20);
            this.fontName4.TabIndex = 22;
            // 
            // ital4
            // 
            this.ital4.AutoSize = true;
            this.ital4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ital4.Location = new System.Drawing.Point(340, 247);
            this.ital4.Name = "ital4";
            this.ital4.Size = new System.Drawing.Size(53, 17);
            this.ital4.TabIndex = 21;
            this.ital4.Text = "Italics";
            this.ital4.UseVisualStyleBackColor = true;
            this.ital4.Click += new System.EventHandler(this.ital4_CheckedChanged);
            // 
            // bold4
            // 
            this.bold4.AutoSize = true;
            this.bold4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bold4.Location = new System.Drawing.Point(254, 247);
            this.bold4.Name = "bold4";
            this.bold4.Size = new System.Drawing.Size(51, 17);
            this.bold4.TabIndex = 20;
            this.bold4.Text = "Bold";
            this.bold4.UseVisualStyleBackColor = true;
            this.bold4.Click += new System.EventHandler(this.bold4_CheckedChanged);
            // 
            // fontSize4
            // 
            this.fontSize4.Location = new System.Drawing.Point(142, 245);
            this.fontSize4.Name = "fontSize4";
            this.fontSize4.Size = new System.Drawing.Size(79, 20);
            this.fontSize4.TabIndex = 19;
            this.fontSize4.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // fontName5
            // 
            this.fontName5.Location = new System.Drawing.Point(23, 275);
            this.fontName5.Name = "fontName5";
            this.fontName5.Size = new System.Drawing.Size(100, 20);
            this.fontName5.TabIndex = 26;
            // 
            // ital5
            // 
            this.ital5.AutoSize = true;
            this.ital5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ital5.Location = new System.Drawing.Point(340, 277);
            this.ital5.Name = "ital5";
            this.ital5.Size = new System.Drawing.Size(53, 17);
            this.ital5.TabIndex = 25;
            this.ital5.Text = "Italics";
            this.ital5.UseVisualStyleBackColor = true;
            this.ital5.Click += new System.EventHandler(this.ital5_CheckedChanged);
            // 
            // bold5
            // 
            this.bold5.AutoSize = true;
            this.bold5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bold5.Location = new System.Drawing.Point(254, 277);
            this.bold5.Name = "bold5";
            this.bold5.Size = new System.Drawing.Size(51, 17);
            this.bold5.TabIndex = 24;
            this.bold5.Text = "Bold";
            this.bold5.UseVisualStyleBackColor = true;
            this.bold5.Click += new System.EventHandler(this.bold5_CheckedChanged);
            // 
            // fontSize5
            // 
            this.fontSize5.Location = new System.Drawing.Point(142, 275);
            this.fontSize5.Name = "fontSize5";
            this.fontSize5.Size = new System.Drawing.Size(79, 20);
            this.fontSize5.TabIndex = 23;
            this.fontSize5.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // fontName6
            // 
            this.fontName6.Location = new System.Drawing.Point(23, 303);
            this.fontName6.Name = "fontName6";
            this.fontName6.Size = new System.Drawing.Size(100, 20);
            this.fontName6.TabIndex = 30;
            // 
            // ital6
            // 
            this.ital6.AutoSize = true;
            this.ital6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ital6.Location = new System.Drawing.Point(340, 305);
            this.ital6.Name = "ital6";
            this.ital6.Size = new System.Drawing.Size(53, 17);
            this.ital6.TabIndex = 29;
            this.ital6.Text = "Italics";
            this.ital6.UseVisualStyleBackColor = true;
            this.ital6.Click += new System.EventHandler(this.ital6_CheckedChanged);
            // 
            // bold6
            // 
            this.bold6.AutoSize = true;
            this.bold6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bold6.Location = new System.Drawing.Point(254, 305);
            this.bold6.Name = "bold6";
            this.bold6.Size = new System.Drawing.Size(51, 17);
            this.bold6.TabIndex = 28;
            this.bold6.Text = "Bold";
            this.bold6.UseVisualStyleBackColor = true;
            this.bold6.Click += new System.EventHandler(this.bold6_CheckedChanged);
            // 
            // fontSize6
            // 
            this.fontSize6.Location = new System.Drawing.Point(142, 303);
            this.fontSize6.Name = "fontSize6";
            this.fontSize6.Size = new System.Drawing.Size(79, 20);
            this.fontSize6.TabIndex = 27;
            this.fontSize6.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // fontName
            // 
            this.fontName.FormattingEnabled = true;
            this.fontName.Location = new System.Drawing.Point(85, 51);
            this.fontName.Name = "fontName";
            this.fontName.Size = new System.Drawing.Size(121, 21);
            this.fontName.TabIndex = 31;
            this.fontName.SelectedValueChanged += new System.EventHandler(this.nameUpdateReq);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 511);
            this.Controls.Add(this.fontName);
            this.Controls.Add(this.fontName6);
            this.Controls.Add(this.ital6);
            this.Controls.Add(this.bold6);
            this.Controls.Add(this.fontSize6);
            this.Controls.Add(this.fontName5);
            this.Controls.Add(this.ital5);
            this.Controls.Add(this.bold5);
            this.Controls.Add(this.fontSize5);
            this.Controls.Add(this.fontName4);
            this.Controls.Add(this.ital4);
            this.Controls.Add(this.bold4);
            this.Controls.Add(this.fontSize4);
            this.Controls.Add(this.fontName3);
            this.Controls.Add(this.ital3);
            this.Controls.Add(this.bold3);
            this.Controls.Add(this.fontSize3);
            this.Controls.Add(this.fontName2);
            this.Controls.Add(this.ital2);
            this.Controls.Add(this.bold2);
            this.Controls.Add(this.fontSize2);
            this.Controls.Add(this.fontName1);
            this.Controls.Add(this.ital1);
            this.Controls.Add(this.bold1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exportName);
            this.Controls.Add(this.fontSize1);
            this.Controls.Add(this.ital0);
            this.Controls.Add(this.bold0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fontNameLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fontSize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label fontNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox bold0;
        private System.Windows.Forms.CheckBox ital0;
        private System.Windows.Forms.NumericUpDown fontSize1;
        private System.Windows.Forms.Label exportName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ital1;
        private System.Windows.Forms.CheckBox bold1;
        private System.Windows.Forms.TextBox fontName1;
        private System.Windows.Forms.TextBox fontName2;
        private System.Windows.Forms.CheckBox ital2;
        private System.Windows.Forms.CheckBox bold2;
        private System.Windows.Forms.NumericUpDown fontSize2;
        private System.Windows.Forms.TextBox fontName3;
        private System.Windows.Forms.CheckBox ital3;
        private System.Windows.Forms.CheckBox bold3;
        private System.Windows.Forms.NumericUpDown fontSize3;
        private System.Windows.Forms.TextBox fontName4;
        private System.Windows.Forms.CheckBox ital4;
        private System.Windows.Forms.CheckBox bold4;
        private System.Windows.Forms.NumericUpDown fontSize4;
        private System.Windows.Forms.TextBox fontName5;
        private System.Windows.Forms.CheckBox ital5;
        private System.Windows.Forms.CheckBox bold5;
        private System.Windows.Forms.NumericUpDown fontSize5;
        private System.Windows.Forms.TextBox fontName6;
        private System.Windows.Forms.CheckBox ital6;
        private System.Windows.Forms.CheckBox bold6;
        private System.Windows.Forms.NumericUpDown fontSize6;
        private System.Windows.Forms.ComboBox fontName;
        
    }
}

