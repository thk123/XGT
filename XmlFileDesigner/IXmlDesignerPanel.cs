using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlFileDesigner
{
    interface IXmlDesignerPanel
    {
        void SaveXml(string lsXmlLocation);
        void LoadFromXml(string lsXmlLocation);
    }
}
