using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XmlFileDesigner
{
    public partial class Form1 : Form
    {
        private FileDesigner mFileDesigner;
        private PropertyValueEditor mValueEditor;
        private IXmlDesignerPanel mCurrentPanel;
        private bool mbInDesignerMode;
        private static string msPreviousSaveAddress;

        public static string SaveAddress
        {
            get
            {
                if (string.IsNullOrWhiteSpace(msPreviousSaveAddress))
                {
                    SaveFileDialog lSaveFileDialog = new SaveFileDialog();
                    lSaveFileDialog.DefaultExt = "cpd";
                    DialogResult lDResult = lSaveFileDialog.ShowDialog();
                    if (lDResult == DialogResult.OK)
                    {
                        msPreviousSaveAddress = lSaveFileDialog.FileName;
                    }
                }

                return msPreviousSaveAddress;
            }
        }

        public Form1()
        {
            InitializeComponent();
            mFileDesigner = fileDesigner1;
            mbInDesignerMode = true;
            msPreviousSaveAddress = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mbInDesignerMode)
            {
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "XML Schemas (*.schema)|*.schema";
                DialogResult result = oFD.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mFileDesigner.LoadFromDesignXml(oFD.FileName);
                }
            }
            else
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lAddress = SaveAddress;
            if (lAddress == "")
            {
                return;
            }
            mCurrentPanel.SaveXml(lAddress);
            /*if (mbInDesignerMode)
            {
                string lAddress = SaveAddress;
                if (lAddress == "")
                {
                    return;
                }
                try
                {
                    XmlTextWriter xmlWriter = new XmlTextWriter(lAddress, Encoding.Default);
                    mFileDesigner.SaveClasses(xmlWriter);
                    xmlWriter.Close();
                }
                catch
                {
                    MessageBox.Show("Error saving: " + e.ToString());
                    return;
                }
            }
            else
            {
                throw new NotImplementedException();
            }*/
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
