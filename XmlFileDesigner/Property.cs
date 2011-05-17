using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace XmlFileDesigner
{
    class Property
    {
        private const int propertyStartY = 20;
        private const int gapBetweenProperties = 30;

        private string mPropertyName;
        private string mPropertyType;
        private string mPropertyDefaultValue;
        private Control[] mPropertyControls;

        /// <summary>
        /// This is used when creating a new property
        /// </summary>
        /// <param name="lPanel">The panel to add the controls to</param>
        /// <param name="propertyId">The number of properties added - used to position the controls</param>
        public Property(Panel lPanel, int propertyId)
        {
            mPropertyControls = new Control[3];
            addUIElements(lPanel, propertyId);
        }

        /// <summary>
        /// When loading a property from a schema with values filled in
        /// </summary>
        /// <param name="lPanel">The panel to add the controls to</param>
        /// <param name="propertyId">The number of properties added - used to position the controls</param>
        /// <param name="lPropertyName">The properties name</param>
        /// <param name="lPropertyType">The properties type</param>
        /// <param name="lPropertyDefaultValue">The properties default value</param>
        public Property(Panel lPanel, int propertyId, string lPropertyName, string lPropertyType, string lPropertyDefaultValue)
        {
            mPropertyName = lPropertyDefaultValue;
            mPropertyType = lPropertyType;
            mPropertyDefaultValue = lPropertyDefaultValue;
            mPropertyControls = new Control[3];
            addUIElements(lPanel, propertyId);

            ((TextBox)mPropertyControls[0]).Text = lPropertyName;
            ((TextBox)mPropertyControls[1]).Text = lPropertyType;
            ((TextBox)mPropertyControls[2]).Text = lPropertyDefaultValue;
        }

        /// <summary>
        /// Display all the properties associated with this property
        /// </summary>
        public void ShowProperties()
        {
            for(int propertyControlId = 0; propertyControlId<mPropertyControls.Length;propertyControlId++)
            {
                mPropertyControls[propertyControlId].Visible = true;
            }
        }

        /// <summary>
        /// Hide all the properties associated with this property
        /// </summary>
        public void HideProperties()
        {
            for (int propertyControlId = 0; propertyControlId < mPropertyControls.Length; propertyControlId++)
            {
                mPropertyControls[propertyControlId].Visible = false;
            }
        }

        public void ExportPropertyAsXml(XmlTextWriter lWriter)
        {
            lWriter.WriteStartElement("Property");
            lWriter.WriteElementString("PropertyName", mPropertyName);
            lWriter.WriteElementString("PropertyType", mPropertyType);
            lWriter.WriteElementString("PropertyDefaultValue", mPropertyDefaultValue);
            lWriter.WriteEndElement();
        }

        private void addUIElements(Panel lPanel, int propertyId)
        {
            TextBox lPropertyNameTextBox = new TextBox();
            lPropertyNameTextBox.Text = mPropertyName;
            lPropertyNameTextBox.TextChanged += new EventHandler(mPropertyNameTextBox_TextChanged);
            lPropertyNameTextBox.Location = new Point(10, propertyStartY + gapBetweenProperties * propertyId);
            lPropertyNameTextBox.Width = 100;
            lPanel.Controls.Add(lPropertyNameTextBox);
            mPropertyControls[0] = lPropertyNameTextBox;

            TextBox lPropertyTypeTextBox = new TextBox();
            lPropertyTypeTextBox.Text = mPropertyType;
            lPropertyTypeTextBox.TextChanged += new EventHandler(mPropertyTypeTextBox_TextChanged);
            lPropertyTypeTextBox.Location = new Point(120, propertyStartY + gapBetweenProperties * propertyId);
            lPropertyTypeTextBox.Width = 200;
            lPanel.Controls.Add(lPropertyTypeTextBox);
            mPropertyControls[1] = lPropertyTypeTextBox;

            TextBox lPropertyDefaultValueTextBox = new TextBox();
            lPropertyDefaultValueTextBox.TextChanged += new EventHandler(mPropertyDefaultValueTextBox_TextChanged);
            lPropertyDefaultValueTextBox.Location = new Point(330, propertyStartY + gapBetweenProperties * propertyId);
            lPropertyDefaultValueTextBox.Width = 100;
            lPanel.Controls.Add(lPropertyDefaultValueTextBox);
            mPropertyControls[2] = lPropertyDefaultValueTextBox;
        }

        private void mPropertyDefaultValueTextBox_TextChanged(object sender, EventArgs e)
        {
            mPropertyDefaultValue = ((TextBox)sender).Text;
        }

        private void mPropertyTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            mPropertyType = ((TextBox)sender).Text;
        }

        private void mPropertyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            mPropertyName = ((TextBox)sender).Text;
        }
    }
}
