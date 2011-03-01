using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace XmlFileDesigner
{
    class Property
    {
        private string mPropertyName;
        private Type mPropertyType;
        private TextBox mPropertyNameTextBox;
        private TextBox mPropertyTypeTextBox;

        public Property(string lPropertyName, Type lPropertyType, Panel lPanel, int propertyNumber)
        {
            mPropertyName = lPropertyName;
            mPropertyType = lPropertyType;
            
            mPropertyNameTextBox = new TextBox();
            mPropertyNameTextBox.Text = mPropertyName;
            mPropertyNameTextBox.Location = new Point(mPropertyNameTextBox.Location.X, mPropertyNameTextBox.Location.Y + 50*propertyNumber);
            mPropertyTypeTextBox = new TextBox();
            mPropertyTypeTextBox.Text = mPropertyType.ToString();
                       
            mPropertyTypeTextBox.Location = new Point(mPropertyTypeTextBox.Location.X, mPropertyTypeTextBox.Location.Y + 50 * propertyNumber);
            mPropertyTypeTextBox.Dock = DockStyle.Right;

            lPanel.Controls.Add(mPropertyNameTextBox);
            lPanel.Controls.Add(mPropertyTypeTextBox);
        }
    }
}
