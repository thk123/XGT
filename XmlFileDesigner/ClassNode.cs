using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace XmlFileDesigner
{
    class ClassNode : TreeNode
    {
        private Panel mPropertyPanel;
        private List<Property> mProperties;
        private bool mbGeneratesXml;

        public bool GeneratesXml
        {
            get
            {
                return mbGeneratesXml;
            }
            set
            {
                mbGeneratesXml = value;
            }
        }


        public ClassNode(string name, Panel lPanel)
            : base(name)
        {
            mPropertyPanel = lPanel;
            mProperties = new List<Property>();
            ToolStripMenuItem addProperty = new ToolStripMenuItem("Add property");
            addProperty.Click += new EventHandler(addProperty_Click);
            ToolStripMenuItem addSubChild = new ToolStripMenuItem("Add subclass");
            addSubChild.Click += new EventHandler(addSubChild_Click);
            ContextMenuStrip = new ContextMenuStrip();
            ContextMenuStrip.Items.Add(addProperty);
            ContextMenuStrip.Items.Add(addSubChild);
        }

        public void SaveClassDefinition(XmlTextWriter lXmlWriter)
        {
            lXmlWriter.WriteStartElement("Class");
            lXmlWriter.WriteElementString("ClassName", Text);
            if (Parent != null && Parent is ClassNode)
            {
                lXmlWriter.WriteElementString("ParentClass", Parent.Text);
            }
            lXmlWriter.WriteStartElement("Properties");
            List<Property> allProperties = GetAllProperties();
            foreach (Property lProperty in allProperties)
            {
                lProperty.ExportPropertyAsXml(lXmlWriter);
            }
            lXmlWriter.WriteEndElement();
            lXmlWriter.WriteEndElement();


            foreach (ClassNode childNode in Nodes)
            {
                childNode.SaveClassDefinition(lXmlWriter);
            }
        }

        private  List<Property> GetAllProperties()
        {
            List<Property> allProperties = new List<Property>(mProperties);
            if (Parent != null &&  Parent is ClassNode)
            {
                allProperties.AddRange(((ClassNode)Parent).GetAllProperties());
            }
            return allProperties;
        }

        void addSubChild_Click(object sender, EventArgs e)
        {
            PropertyNameDialog propertyName = new PropertyNameDialog();
            if (propertyName.ShowDialog() == DialogResult.OK)
            {
                ClassNode newNode = new ClassNode(propertyName.className.Text, mPropertyPanel);
                this.Nodes.Add(newNode);
            }
        }

        public void NodeSelected()
        {
            foreach (Property property in mProperties)
            {
                property.ShowProperties();
            }
        }

        public void NodeDeselected()
        {
            foreach (Property property in mProperties)
            {
                property.HideProperties();
            }
        }

        private void addProperty_Click(object sender, EventArgs e)
        {
            Property newProperty = new Property(mPropertyPanel, mProperties.Count);
            mProperties.Add(newProperty);
        }
    }
}
