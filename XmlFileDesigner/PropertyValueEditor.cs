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
    public partial class PropertyValueEditor : UserControl
    {
        public PropertyValueEditor()
        {
            InitializeComponent();
        }

        public void LoadFromDesignerXml(string xmlLocation)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlLocation);

            XmlNodeList classes = xmlDocument.GetElementsByTagName("Class");
            foreach (XmlNode classNode in classes)
            {
                
            }
        }
    }
}
