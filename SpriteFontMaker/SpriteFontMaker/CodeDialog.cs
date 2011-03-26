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
    public partial class CodeDialog : Form
    {
        public CodeDialog()
        {
            InitializeComponent();
        }

        public void loadCode(List<string> code)
        {
            richTextBox1.Lines = code.ToArray();
        }

    }
}
