﻿using Libra.App_Start;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
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
            string url = Request.QueryString["url"] == null ? "" : Request.QueryString["url"];
            if (url != "") { Read_Xml(url); }
            else { s = "error"; }
         //   mysql();
        }

        public void Read_Xml(string Url)
        {
            WebClient client = new WebClient();
            client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
            client.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            client.Encoding = System.Text.Encoding.UTF8;
            string data = client.DownloadString(Url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("ns", "http://www.esri.com/wms");
            nsMgr.AddNamespace("esri_wms", "http://www.esri.com/wms");
            XmlNode root = doc.SelectSingleNode("ns:FeatureInfoResponse/ns:FIELDS", nsMgr);
            if (root != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.Append("\"OBJECTID\":\"");
                sb.Append(root.Attributes["OBJECTID"].Value);
                sb.Append("\";\"Shape\":\"");
                sb.Append(root.Attributes["Shape"].Value);
                sb.Append("\";\"矿产地编号\":\"");
                sb.Append(root.Attributes["矿产地编号"].Value);
                sb.Append("\";\"矿种\":\"");
                sb.Append(root.Attributes["矿种"].Value);
                sb.Append("\";\"矿产地名\":\"");
                sb.Append(root.Attributes["矿产地名"].Value);
                sb.Append("\";\"交通位置\":\"");
                sb.Append(root.Attributes["交通位置"].Value);
                sb.Append("\";\"地理经度\":\"");
                sb.Append(root.Attributes["地理经度"].Value);
                sb.Append("\";\"地理纬度\":\"");
                sb.Append(root.Attributes["地理纬度"].Value);
                sb.Append("\";\"矿床成因类型\":\"");
                sb.Append(root.Attributes["矿床成因类型"].Value);
                sb.Append("\";\"共生矿\":\"");
                sb.Append(root.Attributes["共生矿"].Value);
                sb.Append("\";\"伴生矿\":\"");
                sb.Append(root.Attributes["伴生矿"].Value);
                sb.Append("\";\"矿床规模\":\"");
                sb.Append(root.Attributes["矿床规模"].Value);
                sb.Append("\";\"成矿时代\":\"");
                sb.Append(root.Attributes["成矿时代"].Value);
                sb.Append("\";\"三级成矿带\":\"");
                sb.Append(root.Attributes["三级成矿带"].Value);
                sb.Append("\";\"四级成矿带\":\"");
                sb.Append(root.Attributes["四级成矿带"].Value);
                sb.Append("\";\"地质工作程度\":\"");
                sb.Append(root.Attributes["地质工作程度"].Value);
                sb.Append("\";\"开采情况\":\"");
                sb.Append(root.Attributes["开采情况"].Value);
                sb.Append("\"}");
                s = sb.ToString();
            }
            else
            {
                s = "nothing";
            }

            menu menu = new menu();
            menu.Name = "";
            menu.Title = "";
            menu.Description1 = "";
            menu.PicUrl1 = "";
            menu.Url1 = "";
            List<menu> menus = new List<menu>();
            menus.Add(menu);


           
        }

        public void mysql()
        {
            string constr = "server=localhost;User Id=root;password=\"\";Database=mytest";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("insert into buyer(name,password,email) values('小王','dikd3939','1134384387@qq.com')", mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("数据插入成功！");
            }
            Console.ReadLine();
            mycon.Close();
        }
    }
}