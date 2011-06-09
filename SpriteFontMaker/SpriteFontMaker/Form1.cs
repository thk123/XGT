using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SpriteFontMaker
{
    public partial class Form1 : Form
    {
        private bool fontBoxesCreated;
        private int verticalPosition;

        private List<SpriteFont> fontBoxes;
        private string fontFamily;

        //private const int maxFonts = 7;

        TextBox codeOutput;

        public Form1()
        {
            InitializeComponent();
            List<String> arrayOfFonts = new List<string>();
            arrayOfFonts.AddRange(System.IO.Directory.GetFiles(@"C:\Windows\Fonts"));
            for (int i = 0; i < arrayOfFonts.Count; i++)
            {
                arrayOfFonts[i] = arrayOfFonts[i].Substring(17);
                arrayOfFonts[i] = arrayOfFonts[i].Substring(0, arrayOfFonts[i].Length - 4);
            }
            fontName.Items.AddRange(arrayOfFonts.ToArray());
            verticalPosition = 0;
            fontBoxesCreated = false;
            fontBoxes = new List<SpriteFont>();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Generate fonts:
            System.IO.Directory.CreateDirectory("Fonts");
            foreach (SpriteFont font in fontBoxes)
            {
                font.ExportToXml();
            }
        }

        private void fontName_TextChanged(object sender, EventArgs e)
        {
            fontFamily = ((ComboBox)sender).Text;
            if (!fontBoxesCreated)
            {
                createInitialFontBoxes(fontFamily);
            }
            else
            {
                updateFontNames(fontFamily);
            }
        }

        private void createInitialFontBoxes(string fontFamily)
        {
            AddFont(fontFamily, 14, false, false);
            AddFont(fontFamily, 24, false, false);
            AddFont(fontFamily, 24, true, false);

            fontBoxesCreated = true;
            button2.Enabled = true;
        }

        private void updateFontNames(string newFontFamily)
        {
            foreach (SpriteFont font in fontBoxes)
            {
                font.UpdateName(newFontFamily);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           AddFont(fontFamily, 14, false, false);
        }

        private void AddFont(string fontFamily, int lFontSize, bool lBold, bool lItalic)
        {
                SpriteFont newFont = new SpriteFont(fontFamily, lFontSize, lBold, lItalic, verticalPosition, this);
                fontBoxes.Add(newFont);
                verticalPosition++;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 50);
                button2.Invalidate();
        }

        private void createCSharpCode()
        {
            List<String> lines = new List<string>();
            lines.Add("#region Fonts");
            foreach(SpriteFont font in fontBoxes)
            {
                lines.Add(String.Format("private SpriteFont {0};",font.mFontName) + "");
            }
            lines.Add("#endregion");
            lines.Add("");
            lines.Add("");
            lines.Add("//In Load method");
            lines.Add("#region Font loading");
            foreach (SpriteFont font in fontBoxes)
            {
                lines.Add(String.Format("{0} = Content.Load<SpriteFont>(\"Fonts\\\\{0}\");", font.mFontName));
            }
            lines.Add("#endregion");
            
            CodeDialog showCode = new CodeDialog();
            showCode.loadCode(lines);
            showCode.Show();
        }

        void codeOutput_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            createCSharpCode();
        }

        private void fontPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            this.fontPanel.MaximumSize = new Size(this.fontPanel.MaximumSize.Width, ((Form1)sender).Height - 215);
        }
    }
}
