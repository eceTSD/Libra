using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Libra
{
    public partial class GetMapInfo : System.Web.UI.Page
    {
        public string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Read_Xml("http://219.142.81.85/arcgis/services/0refield/MapServer/WMSServer?version=1.1.1&request=getfeatureinfo&layers=0&SRS=EPSG:4326&bbox=59.6742209631728,9.99999999999999,150.325779036827,60&width=1280&height=706&format=xml/html&X=757&Y=328&query_layers=0");
        }

        public void Read_Xml(string Url)
        {
            WebClient client = new WebClient();
            client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
            client.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            string data =   client.DownloadString(Url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode root = doc.SelectSingleNode("FIELDS");
            s = root.ToString();
        }
    }
}