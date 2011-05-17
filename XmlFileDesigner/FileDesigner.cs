using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace XmlFileDesigner
{
    public partial class FileDesigner : UserControl, IXmlDesignerPanel
    {
        public FileDesigner()
        {
            InitializeComponent();
            
            ToolStripMenuItem newClass = new ToolStripMenuItem("New class");
            newClass.Click += new EventHandler(newClass_Click);
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            ContextMenuStrip.Items.Add(newClass);
            
            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            treeView1.BeforeSelect += new TreeViewCancelEventHandler(treeView1_BeforeSelect);
        }

        public void LoadFromDesignXml(string xmlFile)
        {
            XmlTextReader lXmlReader = new XmlTextReader(xmlFile);
            XmlDocument mXmlDocument = new XmlDocument();
            mXmlDocument.Load(xmlFile);
            mXmlDocument.GetElementsByTagName("Class");
        }

        public void SaveClasses(XmlTextWriter lXmlWriter)
        {
            lXmlWriter.WriteStartDocument();
            lXmlWriter.WriteStartElement("ClassDefinitions");
            foreach (ClassNode node in treeView1.Nodes)
            {
                node.SaveClassDefinition(lXmlWriter);
            }
            lXmlWriter.WriteEndElement();
            lXmlWriter.WriteEndDocument();
        }

        void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode is ClassNode)
            {
                ((ClassNode)treeView1.SelectedNode).NodeDeselected();
            }
        }

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ((ClassNode)e.Node).NodeSelected();
        }

        void newClass_Click(object sender, EventArgs e)
        {
            PropertyNameDialog propertyName = new PropertyNameDialog();
            if (propertyName.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(propertyName.className.Text))
                {
                    ClassNode newNode = new ClassNode(propertyName.className.Text, splitContainer1.Panel2);
                    treeView1.Nodes.Add(newNode);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode is ClassNode)
            {
                ((ClassNode)treeView1.SelectedNode).GeneratesXml = checkBox1.Checked;
            }
        }

        public void SaveXml(string lsXmlLocation)
        {

        }

        public void LoadFromXml(string lsXmlLocation)
        {
            throw new NotImplementedException();
        }
    }
}
