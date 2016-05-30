using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class zzzz : System.Web.UI.Page
{
    DataSet ds ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("cdcatalog.xml"));
            Session["sd"] = ds;
            Databind();
        }
      
    }
    private void Databind()
    {

        cdcatalog.DataSource = ds;
        cdcatalog.DataBind();
    }
    protected void cdcatalog_EditCommand(object source, DataListCommandEventArgs e)
    {
        this.cdcatalog.EditItemIndex = e.Item.ItemIndex;
        ds = (DataSet)Session["sd"];
        this.Databind();
    }

    protected void cdcatalog_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {           
            ds = (DataSet)Session["sd"];
            int i = e.Item.ItemIndex;
            DataRow dr = ds.Tables[0].NewRow();
            dr["name"] = "请点击";
            dr["title"] = "编辑按钮";
            dr["abstract"] = "进行编辑";
            dr["picurl"] = "或删除按钮";
            dr["url"] = "删除该行";
            ds.Tables[0].Rows.InsertAt(dr, i+1);
            Session["sd"] = ds;
            this.Databind();
        }
    }

    protected void cdcatalog_CancelCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            this.cdcatalog.EditItemIndex = -1;
            ds = (DataSet)Session["sd"];
            this.Databind();
        }
    }

    protected void cdcatalog_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            int i = e.Item.ItemIndex;
            string newname = (cdcatalog.Items[i].FindControl("TextBox1")as TextBox).Text;
            string newtitle = (cdcatalog.Items[i].FindControl("TextBox2") as TextBox).Text;
            string newabstract = (cdcatalog.Items[i].FindControl("TextBox3") as TextBox).Text;
            string newpicurl = (cdcatalog.Items[i].FindControl("TextBox4") as TextBox).Text;
            string newurl = (cdcatalog.Items[i].FindControl("TextBox5") as TextBox).Text;
            DataRow rowCustomer;
            ds = (DataSet)Session["sd"];
            rowCustomer = ds.Tables[0].Rows[i];
            if (rowCustomer != null)      
            {
                rowCustomer["name"] = newname;
                rowCustomer["title"] = newtitle;
                rowCustomer["abstract"] = newabstract;
                rowCustomer["picurl"] = newpicurl;
                rowCustomer["url"] = newurl;
            }
            Session["sd"] = ds;
            this.cdcatalog.EditItemIndex = -1;
            this.Databind();
        }
    }

    protected void cdcatalog_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int  i = e.Item.ItemIndex;//获取当前行数
            ds = (DataSet)Session["sd"];
            ds.Tables[0].Rows.RemoveAt(i);
            Session["sd"] = ds;
            Databind();
        }
    }

    protected void save_Click(object sender, EventArgs e)
    {
        ds = (DataSet)Session["sd"];
        ds.WriteXml(Server.MapPath("cdcatalog.xml"));
        Response.Write("<script>alert('保存成功!')</script>");
        Databind();
    }
}