using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpriteFontMaker
{
    public partial class Form1 : Form
    {
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
        }

        private void bold0_CheckedChanged(object sender, EventArgs e)
        {
            bold1.Checked = bold0.Checked;
            bold2.Checked = bold0.Checked;
            bold3.Checked = bold0.Checked;
            bold4.Checked = bold0.Checked;
            bold5.Checked = bold0.Checked;
            bold6.Checked = bold0.Checked;
        }

        private void bold1_CheckedChanged(object sender, EventArgs e)
        {
            if (bold1.Checked)
            {
                if (bold2.Checked && bold3.Checked && bold4.Checked && bold5.Checked && bold6.Checked)
                {
                    bold0.Checked = true;
                }
            }
            else
            {
                //If just unchecked, not all are checked therefore uncheck the top tick box
                bold0.Checked = false;
            }
        }
        private void bold2_CheckedChanged(object sender, EventArgs e)
        {
            if (bold2.Checked)
            {
                if (bold1.Checked && bold3.Checked && bold4.Checked && bold5.Checked && bold6.Checked)
                {
                    bold0.Checked = true;
                }
            }
            else
            {
                //If just unchecked, not all are checked therefore uncheck the top tick box
                bold0.Checked = false;
            }
        }

        private void bold3_CheckedChanged(object sender, EventArgs e)
        {
            if (bold3.Checked)
            {
                if (bold1.Checked && bold2.Checked && bold4.Checked && bold5.Checked && bold6.Checked)
                {
                    bold0.Checked = true;
                }
            }
            else
            {
                //If just unchecked, not all are checked therefore uncheck the top tick box
                bold0.Checked = false;
            }
        }
        private void bold4_CheckedChanged(object sender, EventArgs e)
        {
            if (bold4.Checked)
            {
                if (bold1.Checked && bold3.Checked && bold2.Checked && bold5.Checked && bold6.Checked)
                {
                    bold0.Checked = true;
                }
            }
            else
            {
                //If just unchecked, not all are checked therefore uncheck the top tick box
                bold0.Checked = false;
            }
        }
        private void bold5_CheckedChanged(object sender, EventArgs e)
        {
            if (bold5.Checked)
            {
                if (bold1.Checked && bold3.Checked && bold4.Checked && bold2.Checked && bold6.Checked)
                {
                    bold0.Checked = true;
                }
            }
            else
            {
                //If just unchecked, not all are checked therefore uncheck the top tick box
                bold0.Checked = false;
            }
        }
        private void bold6_CheckedChanged(object sender, EventArgs e)
        {
            if (bold6.Checked)
            {
                if (bold1.Checked && bold3.Checked && bold4.Checked && bold5.Checked && bold2.Checked)
                {
                    bold0.Checked = true;
                }
            }
            else
            {
                //If just unchecked, not all are checked therefore uncheck the top tick box
                bold0.Checked = false;
            }
        }

        private void ital0_CheckedChanged(object sender, EventArgs e)
        {
            ital1.Checked = ital0.Checked;
            ital2.Checked = ital0.Checked;
            ital3.Checked = ital0.Checked;
            ital4.Checked = ital0.Checked;
            ital5.Checked = ital0.Checked;
            ital6.Checked = ital0.Checked;
        }
        private void ital1_CheckedChanged(object sender, EventArgs e)
        {
            if (ital1.Checked && ital2.Checked && ital3.Checked && ital4.Checked && ital5.Checked && ital6.Checked)
            {
                ital0.Checked = true;
            }
            else if (!ital1.Checked)
            {
                ital0.Checked = false;
            }
        }
        private void ital2_CheckedChanged(object sender, EventArgs e)
        {
            if (ital1.Checked && ital2.Checked && ital3.Checked && ital4.Checked && ital5.Checked && ital6.Checked)
            {
                ital0.Checked = true;
            }
            else if (!ital2.Checked)
            {
                ital0.Checked = false;
            }
        }
        private void ital3_CheckedChanged(object sender, EventArgs e)
        {
            if (ital1.Checked && ital2.Checked && ital3.Checked && ital4.Checked && ital5.Checked && ital6.Checked)
            {
                ital0.Checked = true;
            }
            else if (!ital3.Checked)
            {
                ital0.Checked = false;
            }
        }
        private void ital4_CheckedChanged(object sender, EventArgs e)
        {
            if (ital1.Checked && ital2.Checked && ital3.Checked && ital4.Checked && ital5.Checked && ital6.Checked)
            {
                ital0.Checked = true;
            }
            else if (!ital4.Checked)
            {
                ital0.Checked = false;
            }
        }
        private void ital5_CheckedChanged(object sender, EventArgs e)
        {
            if (ital1.Checked && ital2.Checked && ital3.Checked && ital4.Checked && ital5.Checked && ital6.Checked)
            {
                ital0.Checked = true;
            }
            else if (!ital5.Checked)
            {
                ital0.Checked = false;
            }
        }
        private void ital6_CheckedChanged(object sender, EventArgs e)
        {
            if (ital1.Checked && ital2.Checked && ital3.Checked && ital4.Checked && ital5.Checked && ital6.Checked)
            {
                ital0.Checked = true;
            }
            else if (!ital6.Checked)
            {
                ital0.Checked = false;
            }
        }

        void nameUpdateReq(object sender, System.EventArgs e)
        {
            string dec = "";
            if (bold1.Checked)
            {
                dec += "[bold]";
            }
            if (ital1.Checked)
            {
                dec += "[ital1]";
            }
            fontName1.Text = fontName.Text + dec + fontSize1.Value.ToString() + ".spritefont";
        }
    }
}
