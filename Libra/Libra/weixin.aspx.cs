using Libra.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libra
{
    public partial class weixin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Loadfile(path);
            menu.value = "";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            StringBuilder sb = new StringBuilder();

            List.add(menu)
            for(int i = 0; List.length; i++)
            {
                sb.Append("");
             
            }
            updatefile("path",sb.ToString(),true);
        }
    }
}