using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XmlFileDesigner
{
    public partial class Form1 : Form
    {

        List<Property> properties;
        public Form1()
        {
            InitializeComponent();
            properties = new List<Property>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                if (treeView1.Nodes.Count == 0)
                {
                    treeView1.Nodes.Add(((TextBox)sender).Text);
                }
                else
                {
                    treeView1.Nodes[0].Text = ((TextBox)sender).Text;
                }
            }
        }

        private void addProperty()
        {
            Property newProperty = new Property("New Property", typeof(int), panel1, properties.Count);
            properties.Add(newProperty);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addProperty();
            ((Button)sender).Location = new Point(((Button)sender).Location.X, ((Button)sender).Location.Y + 50);
        }
    }
}
