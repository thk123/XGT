using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace SpriteFontMaker
{
    class SpriteFont
    {
        public string mFontName;
        private int mFontSize;
        private bool mBold;
        private bool mItalics;
        private bool mInclude;
        private string mFontFamily;

        private TextBox fontNameBox;
        private NumericUpDown fontSizeControl;
        private CheckBox italicsControl;
        private CheckBox boldControl;
        private CheckBox includeControl;

        public SpriteFont(string fontFamily, int lFontSize, bool lBold, bool lItalic, int verticalPosition, Form1 lForm)
        {
            mFontFamily = fontFamily;
            fontSizeControl = new NumericUpDown();
            fontSizeControl.Value = lFontSize;
            mFontSize = lFontSize;
            fontSizeControl.Width = 40;
            fontSizeControl.Location = new Point(260, 50 * verticalPosition);
            fontSizeControl.ValueChanged += new EventHandler(fontSizeControl_ValueChanged);
            lForm.fontPanel.Controls.Add(fontSizeControl);

            italicsControl = new CheckBox();
            italicsControl.Checked = lItalic;
            mItalics = lItalic;
            italicsControl.Width = 15;
            italicsControl.Location = new Point(315, 50 * verticalPosition);
            italicsControl.CheckedChanged += new EventHandler(italicsControl_CheckedChanged);
            lForm.fontPanel.Controls.Add(italicsControl);

            boldControl = new CheckBox();
            boldControl.Checked = lBold;
            mBold = lBold;
            boldControl.Width = 15;
            boldControl.Location = new Point(355, 50 * verticalPosition);
            boldControl.CheckedChanged += new EventHandler(boldControl_CheckedChanged);
            lForm.fontPanel.Controls.Add(boldControl);

            includeControl = new CheckBox();
            includeControl.Checked = true;
            mInclude = true;
            includeControl.Width = 15;
            includeControl.Location = new Point(390, 50 * verticalPosition);
            includeControl.CheckedChanged += new EventHandler(includeControl_CheckedChanged);
            lForm.fontPanel.Controls.Add(includeControl);

            fontNameBox = new TextBox();
            UpdateName(fontFamily);
            fontNameBox.Text = mFontName;
            fontNameBox.Width = 250;
            fontNameBox.Location = new Point(0, 50 * verticalPosition);
            fontNameBox.TextChanged += new EventHandler(fontNameBox_TextChanged);
            lForm.fontPanel.Controls.Add(fontNameBox);
        }

        public void UpdateName(string newFontFamilyName)
        {
            mFontFamily = newFontFamilyName;
            mFontName = newFontFamilyName.Replace(" ","") + mFontSize;
            if (mBold)
            {
                mFontName += "Bold";
            }
            if (mItalics)
            {
                mFontName += "Italic";
            }

            fontNameBox.Text = mFontName;
        }

        public void ExportToXml()
        {
            if (includeControl.Checked)
            {
                try
                {
                    XmlDocument fontFile = new XmlDocument();
                    XmlTextReader reader = new XmlTextReader("templateFont.spritefont");
                    fontFile.Load(reader);
                    XmlNodeList fontFamilyNodes = fontFile.GetElementsByTagName("FontName");
                    fontFamilyNodes[0].InnerText = mFontFamily;
                    fontFile.GetElementsByTagName("Size")[0].InnerText = mFontSize.ToString();

                    string style = getStyle();
                    fontFile.GetElementsByTagName("Style")[0].InnerText = style;

                    XmlTextWriter writter = new XmlTextWriter("Fonts//" + mFontName + ".spritefont", Encoding.ASCII);
                    reader.Close();
                    fontFile.Save(writter);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private string getStyle()
        {
            string style = "Regular";
            if (mBold)
            {
                if (mItalics)
                {
                    style = "Bold, Italic";
                }
                else
                {
                    style = "Bold";
                }
            }
            else if (mItalics)
            {
                style = "Italic";
            }
            return style;
        }

        void fontNameBox_TextChanged(object sender, EventArgs e)
        {
            mFontName = ((TextBox)sender).Text;
        }

        void includeControl_CheckedChanged(object sender, EventArgs e)
        {
            mInclude = ((CheckBox)sender).Checked;
        }

        void boldControl_CheckedChanged(object sender, EventArgs e)
        {
            mBold = ((CheckBox)sender).Checked;
            UpdateName(mFontFamily);
        }

        void italicsControl_CheckedChanged(object sender, EventArgs e)
        {
            mItalics = ((CheckBox)sender).Checked;
            UpdateName(mFontFamily);
        }

        void fontSizeControl_ValueChanged(object sender, EventArgs e)
        {
            mFontSize = (int)((NumericUpDown)sender).Value;
            UpdateName(mFontFamily);
        }

    }
}
