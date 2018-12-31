using EARS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EARS.Models
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {      
            if (!Page.IsPostBack)
            {
                LoadPage();
                //Connect with the EARS_DB
                DBHelper.ConnectReportingServer();

                //All fields
                //Execute a query to fetch the data for grid
                //string query = "SELECT [TestCycleID],[TestName], [Expected], [Actual], [Result], [Build] FROM [tblTestCycle]";
                string query = "SELECT [TestCycleID],[TestName], [Expected], [Actual], [Result], [DateOfExecution] FROM [tblTestCycle]";
                DataTable table = Settings.ReportingConn.ExecuteQuery(query);

                //Bind the data to the gridview
                GridView1.DataSource = table;
                GridView1.DataBind();

                //TCID combo box 
                query = "select TestCycleID from tblTestCycle";
                DataTable source = Settings.ReportingConn.ExecuteQuery(query);
                PopulateCombobox(source, ddlTestCycleID, "TestCycleID");

                /*
                //Expected
                query = "select distinct Expected from tblTestCycle";
                DataTable source1 = Settings.ReportingConn.ExecuteQuery(query);
                PopulateCombobox(source1, ddlName, "Expected");
                */

                //Results combo bos pass/fail
                query = "select distinct Result from tblTestCycle";
                DataTable source1 = Settings.ReportingConn.ExecuteQuery(query);
                PopulateCombobox(source1, ddlName, "Result");

                
                
                //DateFrom combo box
                query = "select FORMAT(DateOfExecution,'d', 'en-gb' ) as 'DateOfExecution' from tblTestCycle";
                DataTable source2 = Settings.ReportingConn.ExecuteQuery(query);
                PopulateCombobox(source2, ddlFromDate, "DateOfExecution");

                //DateTo combo box
                query = "select FORMAT(DateOfExecution,'d', 'en-gb' ) as 'DateOfExecution' from tblTestCycle";
                DataTable source3 = Settings.ReportingConn.ExecuteQuery(query);
                PopulateCombobox(source3, ddlToDate, "DateOfExecution");
                
            }

        }

        public void PopulateCombobox(DataTable dsSource, DropDownList cmbbox, string columnName)
        {
            try
            {
                cmbbox.DataTextField = columnName;
                cmbbox.DataValueField = columnName;
                cmbbox.DataSource = dsSource;
                cmbbox.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            try
            {
              
                //int nTestCycleID = int.Parse(txtTestCycleID.Text.Length > 0 ? txtTestCycleID.Text : "-1");
                int nTestCycleID = int.Parse(ddlTestCycleID.Text.Length > 0 ? ddlTestCycleID.Text : "-1");
                string userName = string.Empty;
                string descName = string.Empty;

                //Only set value if the visibility True
                //Story
                if (ddlName.Visible == true)
                {
                    userName = ddlName.SelectedItem.ToString();
                    //ht.Add("@FromDate", sFromDate);
                    //ht.Add("@ToDate", sToDate);
                    //ht.Add("@TestCycleID", nTestCycleID);
                    ht.Add("@Result", userName);
                    DataTable dt = Settings.ReportingConn.ExecuteProcWithParamsDT("sp_GetFilterDataResult", ht);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                //TCID
                else if (lblTestCycleID.Visible == true)
                {
                    //userName = string.Empty;
                    //ht.Add("@FromDate", sFromDate);
                    //ht.Add("@ToDate", sToDate);
                    ht.Add("@TestCycleID", nTestCycleID);
                    //ht.Add("@Expected", userName);
                    //ht.Add("@TestName", descName);
                    DataTable dt = Settings.ReportingConn.ExecuteProcWithParamsDT("sp_GetFilterData", ht);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if ( lblFromDate.Visible == true )
                {
                    //Format date to 
                    DateTime DF = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime DT = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    string sFromDate = DF.ToString("yyyy-MM-dd");
                    string sToDate = DT.ToString("yyyy-MM-dd");

                    //userName = ddlName.SelectedItem.ToString();
                    ht.Add("@FromDate", sFromDate);
                    ht.Add("@ToDate", sToDate);
                    //ht.Add("@TestCycleID", nTestCycleID);
                    //ht.Add("@Result", userName);
                    DataTable dt = Settings.ReportingConn.ExecuteProcWithParamsDT("sp_GetFilterDataDate", ht);
           
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ht = null;
            }
            finally
            {
                ht = null;
            }
        }


        public void LoadPage()
        {
            lblToDate.Visible = false;
            lblFromDate.Visible = false;
            ddlFromDate.Visible = false;
            ddlToDate.Visible = false;

            txtFromDate.Visible = false;
            txtToDate.Visible = false;
            lblTestCycleID.Visible = false;
            //txtTestCycleID.Visible = false;
            ddlTestCycleID.Visible = false;
            lblName.Visible = false;
            ddlName.Visible = false;
            btnShow.Visible = false;
        }

        protected void rdOptionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShow.Visible = true;
            if (rdOptionList.SelectedItem.Value == "TCID")
            {
                lblTestCycleID.Visible = true;
                //txtTestCycleID.Visible = true;
                ddlTestCycleID.Visible = true;
                lblToDate.Visible = false;
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                txtToDate.Visible = false;

                ddlFromDate.Visible = false;
                ddlToDate.Visible = false;

                lblName.Visible = false;
                ddlName.Visible = false;
                txtFromDate.Text = string.Empty;
                txtToDate.Text = string.Empty;
            }
            if (rdOptionList.SelectedItem.Value == "Date")
            {
                lblToDate.Visible = true;
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                txtToDate.Visible = true;

                ddlFromDate.Visible = true;
                ddlToDate.Visible = true;

                lblTestCycleID.Visible = false;
                //txtTestCycleID.Visible = false;
                ddlTestCycleID.Visible = false;
                lblName.Visible = false;
                ddlName.Visible = false;
                txtTestCycleID.Text = string.Empty;
            }
            if (rdOptionList.SelectedItem.Value == "Name")
            {
                lblName.Visible = true;
                ddlName.Visible = true;
                lblToDate.Visible = false;
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                txtToDate.Visible = false;

                ddlFromDate.Visible = false;
                ddlToDate.Visible = false;

                lblTestCycleID.Visible = false;
                //txtTestCycleID.Visible = false;
                ddlTestCycleID.Visible = false;
                txtTestCycleID.Text = string.Empty;
                txtFromDate.Text = string.Empty;
                txtToDate.Text = string.Empty;
            }
        }

        protected void OnLnkClick(object sender, CommandEventArgs e)
        {
            Response.Redirect("DetailedReport.aspx?ParentCycleID=" + e.CommandArgument.ToString());
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}