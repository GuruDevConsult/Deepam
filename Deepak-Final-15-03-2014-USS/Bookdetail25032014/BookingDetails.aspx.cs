using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using AjaxControlToolkit;

public partial class BookingDetails : UIBase
{
    #region Variables
    static int curScreenID;
    string resultMsg = string.Empty;
    int affectedRows = 0;
    Components.BL.BookDetailsBL BDBL = Components.BL.BookDetailsBL.Instance;
    Components.DTO.BookDetailsDTO BDDTO = new Components.DTO.BookDetailsDTO();
    Components.Common.GlobalFunction GlbFunc = Components.Common.GlobalFunction.Instance;
    Components.DAL.SQLConnect SqlHelper;
    DataTable dtBook = new DataTable();
    DataSet dsBook = new DataSet();
    Components.BL.AuthenticationBL AuthentBL = Components.BL.AuthenticationBL.Instance;
    public string iteration;
    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Pages"] != "BookingDetails.aspx"))
        {
            if (!Page.IsPostBack)
            {
                string UserID = Components.DTO.LoginDTO.UserID;
                string Branch = Components.DTO.LoginDTO.BranchName;
                DataTable dt = AuthentBL.AddressBook_UName_Check(UserID,Branch);
                string UName;


                if (UserID == null)
                {
                    Response.Redirect("Warning.aspx");
                }
                else if (dt != null && dt.Rows.Count > 0)
                {
                    UName = dt.Rows[0]["UserName"].ToString();
                    if (UserID == UName)
                    {
                    }
                }
                else if (UserID != null)
                {
                    InitPage();
                }

                AutoGenLoad();
                Charges();
                CreateTable();
                GridShow();
                BookingDate.Focus();
                btnSave.Attributes.Add("onclick", "return Form_Validator('txtConsignor','txtConsignee','txtInsuranceCompanyName','txtPolicyNo','txtDate','txtRisk','txtAgentName','txtFrom','txtTo','','','','','','','','','','','','','','','')");
                lblResult.Visible = false;
                StoreNo_Load();
                ItemName_Load();
                Session["Branch"] = Components.DTO.LoginDTO.BranchName;
                From.Text = Components.DTO.LoginDTO.BranchName;
            }
        }
    }
    #endregion

    //#region InitPage
    //protected void InitPage()
    //{
    //    curScreenID = base.InitPageIdent(Page);
    //    base.UIValidator(Page.Validators);
    //}
    //#endregion

    #region InitPage()
    private void InitPage()
    {
        //curScreenID = base.InitPageIdent(Page);
        //base.UIValidator(Page.Validators);
        btnSave.Visible = false;
        btnDelete.Visible = false;
        btnClear.Visible = false;

        string UserID = Components.DTO.LoginDTO.UserID;
        string Branch = Components.DTO.LoginDTO.BranchName;
        DataTable dtID = AuthentBL.SelectID(UserID,Branch);
        string User = string.Empty;
        if (dtID != null && dtID.Rows.Count > 0)
        {
            User = dtID.Rows[0]["EmpName"].ToString();
        }
        DataTable dtUser = AuthentBL.Select(User,Branch);
        if (dtUser != null && dtUser.Rows.Count > 0)
        {
            string Resource = dtUser.Rows[0]["ResourceID"].ToString();
            string Alls = dtUser.Rows[0]["All1"].ToString();
            string Saves = dtUser.Rows[0]["Save1"].ToString();
            string Deletes = dtUser.Rows[0]["Delete1"].ToString();
            // string Views = dtUser.Rows[0]["View1"].ToString();
            string Edits = dtUser.Rows[0]["Edit"].ToString();
            string[] Screen = Resource.Split(',');

            foreach (string scr in Screen)
            {
                if (scr == "BookingDetails.aspx")
                {
                    iteration = "BookingDetails.aspx";

                }

            }

            string[] All = Alls.Split(',');
            foreach (string scr in All)
            {
                if (scr == "BookingDetails.aspx")
                {
                    iteration = "BookingDetails.aspx";
                    btnSave.Visible = true;
                    btnDelete.Visible = true;
                    btnClear.Visible = true;


                }
            }

            string[] Save = Saves.Split(',');
            foreach (string scr in Save)
            {
                if (scr == "BookingDetails.aspx")
                {
                    iteration = "BookingDetails.aspx";
                    btnSave.Visible = true;
                }
            }

            string[] Delete = Deletes.Split(',');
            foreach (string scr in Delete)
            {
                if (scr == "BookingDetails.aspx")
                {
                    iteration = "BookingDetails.aspx";
                    btnDelete.Visible = true;
                }
            }

            //string[] View = Views.Split(',');
            //foreach (string scr in View)
            //{
            //    if (scr == "account.aspx")
            //    {
            //        iteration = "account.aspx";

            //    }
            //}

            string[] Edit = Edits.Split(',');
            foreach (string scr in Edit)
            {
                if (scr == "BookingDetails.aspx")
                {

                    iteration = "BookingDetails.aspx";


                }
            }
        }
        else if (iteration == "BookingDetails.aspx")
        {

        }
        else if (iteration != "BookingDetails.aspx")
        {
            Response.Redirect("Warning.aspx");
        }
        else
        {
            Response.Redirect("Warning.aspx");
        }
    }

    #endregion

    #region CreateTable
    public void CreateTable()
    {
        DataTable table = new DataTable();  //create new datatable and also create columns 
        string[] name = { "BookingDetailsID", "Packages", "ItemName","Packings", "Rate", "Weight", "ChargedWeight", "Total" };

        DataColumn dcol;
        for (int i = 0; i < name.Length; i++)
        {
            dcol = new DataColumn();
            dcol.ColumnName = name[i];
            table.Columns.Add(dcol);
        }
        ViewState["CreateTable"] = table;
    }
    #endregion

    #region GridShow
    public void GridShow()
    {
        try
        {
            //if (btnSave.Text == "Save")
            //{
                DataTable dt2 = (DataTable)ViewState["CreateTable"];
                GridBook.DataSource = dt2;
                GridBook.DataBind();

                if (GridBook.Rows.Count < 1)
                {
                    ShowNoResultFound(dt2, GridBook);
                }
                //TextBox txtPackages = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                //TextBox txtActualWeight = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                //TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                //txtPackages.Focus();
            //}
            //else if (btnSave.Text == "Update")
            //{
            //    DataTable dt2 = (DataTable)ViewState["LoadGridUpdate"];
            //    GridBook.DataSource = dt2;
            //    GridBook.DataBind();

            //    if (GridBook.Rows.Count < 1)
            //    {
            //        ShowNoResultFound(dt2, GridBook);
            //    }
            //    if (dt2.Rows.Count == 3)
            //    {
            //        TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
            //        TextBox txtDesc1 = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
            //        TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
            //        TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
            //        LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
            //        LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
            //        txtDesc1.Visible = false;
            //        txtActualWeight1.Visible = false;
            //        txtChargedWeight1.Visible = false;
            //        txtPack1.Visible = false;
            //        link.Visible = false;
            //        link1.Visible = false;
            //        //ViewState["NewGrid"] = dtInsert;
            //    }
            //}

        }
        catch { }
    }
    #endregion

    #region Grid_Row
    private void Grid_Row(GridView gv)
    {
        //source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable
        //// Bind the DataTable which contain a blank row to the GridView
        //gv.DataSource = source;
        //gv.DataBind();
        //source.Rows.RemoveAt(0); //This is to remove the first row 
        // Get the total number of columns in the GridView to know what the Column Span should be
        int columnsCount = gv.Columns.Count;
        //gv.Rows[0].Cells.Clear();// clear all the cells in the row
        gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
        gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
        gv.Rows[0].Visible = false;
        //source.Rows.RemoveAt(0); //This is to remove the first row 

        //You can set the styles here
        gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[0].Font.Bold = true;
        //set No Results found to the new added cell
        //gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
    }
    #endregion

    #region ShowNoResultFound
    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable
        // Bind the DataTable which contain a blank row to the GridView
        gv.DataSource = source;
        gv.DataBind();
        source.Rows.RemoveAt(0); //This is to remove the first row 
        // Get the total number of columns in the GridView to know what the Column Span should be
        int columnsCount = gv.Columns.Count;
        gv.Rows[0].Cells.Clear();// clear all the cells in the row
        gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
        gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
        //source.Rows.RemoveAt(0); //This is to remove the first row 

        //You can set the styles here
        gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[0].Font.Bold = true;
        //set No Results found to the new added cell
        //gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
    }
    #endregion

    #region Charges
    private void Charges()
    {
        int FC = 0;
        int HC = 0;
        int CC = 0;
        int SC = 0;
        int ME = 0;
        int Ins = 0;
        int AO = 0;
        int ST = 0;
        FreightCharges.Text = FC.ToString(); ;
        HandlingCharges.Text = HC.ToString();
        CartageCharges.Text = CC.ToString();
        StatisticalCharges.Text = SC.ToString();
        MiscExp.Text = ME.ToString();
        Insurance.Text = Ins.ToString();
        AOC.Text = AO.ToString();
        ServiceTax.Text = ST.ToString();
    }
    #endregion

    #region AutoGen
    public void AutoGenLoad()
    {
        string AutoGenID = "";
        string Branch=Components.DTO.LoginDTO.BranchName;
        AutoGenID = BDBL.AutoGenID("BDLRNo", Branch);
            //GlbFunc.AutoGenID(Components.DTO.LoginDTO.CompanyID, "BDLRNo");
        LRNo.Text = AutoGenID;
    }
    #endregion

    #region StoreNo_Load
    protected void StoreNo_Load()
    {
        string Branch = Components.DTO.LoginDTO.BranchName;
        DataTable dt_store = BDBL.BookingDetails_StoreNoview(Branch);
        if (dt_store != null && dt_store.Rows.Count > 0)
        {
            StoreNo.DataSource = dt_store;
            StoreNo.DataTextField = "StoreNo";
            StoreNo.DataValueField = "ID";
            StoreNo.DataBind();
            StoreNo.Items.Insert(0, "--SELECT--");
        }
    }
    #endregion

    #region Consignor TextChanged
    protected void Consignor_TextChanged(object sender, EventArgs e)
    {
        GlbFunc = Components.Common.GlobalFunction.Instance;
        BDBL = Components.BL.BookDetailsBL.Instance;
        string ConName = Consignor.Text.Trim();
        string Branch = Components.DTO.LoginDTO.BranchName;
        dtBook = BDBL.BookDetails_Consignor_View(ConName,Branch);
        if (dtBook.Rows.Count > 0 && dtBook != null)
        {
            hidConsignor.Value = dtBook.Rows[0]["ID"].ToString();
            Address.Text = dtBook.Rows[0]["Address"].ToString();
            City.Text = dtBook.Rows[0]["City"].ToString();
            Pincode.Text = dtBook.Rows[0]["Pincode"].ToString();
            Consignee.Focus();
        }
        if (btnSave.Text == "Save")
        {
            Grid_Row(GridBook);// This is to hide the first row of the dynamic grid
        }
    }
    #endregion

    #region Consignee TextChanged
    protected void Consignee_TextChanged(object sender, EventArgs e)
    {
        BDBL = Components.BL.BookDetailsBL.Instance;
        string ConsigneeName = Consignee.Text.Trim();
        string Branch = Components.DTO.LoginDTO.BranchName;

        dtBook = BDBL.BookDetails_Consignee_View(ConsigneeName,Branch);
        if (dtBook.Rows.Count > 0 && dtBook != null)
        {
            hidConsignee.Value = dtBook.Rows[0]["ID"].ToString();
            ConsigneeAddress.Text = dtBook.Rows[0]["Address"].ToString();
            ConsigneeCity.Text = dtBook.Rows[0]["City"].ToString();
            ConsigneePincode.Text = dtBook.Rows[0]["Pincode"].ToString();
            InsuranceCompanyName.Focus();
        }
    }
    #endregion

    #region AgentName TextChanged
    protected void AgentName_TextChanged(object sender, EventArgs e)
    {
        string AgentN = AgentName.Text.Trim();
        string Branch = Components.DTO.LoginDTO.BranchName;

        dtBook = BDBL.BookDetails_Agent_View(AgentN,Branch);
        if (dtBook.Rows.Count > 0 && dtBook != null)
        {
            hidAgent.Value = dtBook.Rows[0]["ID"].ToString();
            From.Focus();
        }
    }

    #endregion

    #region StoreNo TextChanged
    protected void StoreNo_TextChanged(object sender, EventArgs e)
    {
        //string Store = StoreNo.Text;
        //dtBook = BDBL.BookDetails_StoreNo_View(Store);
        //if (dtBook.Rows.Count > 0 && dtBook != null)
        //{
        //    hidStoreID.Value = dtBook.Rows[0]["ID"].ToString();
        //    AgentName.Focus();
        //}
    }
    #endregion

    #region FreightCharges TextChanged
    protected void FreightCharges_TextChanged(object sender, EventArgs e)
    {

        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;

        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty 
            && Insurance.Text != string.Empty && MiscExp.Text != string.Empty 
            && StatisticalCharges.Text != string.Empty && 
            CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty
            && FreightCharges.Text != string.Empty)
        {
            
            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amount;
            amount = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amount;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            HandlingCharges.Focus();
        }
    }
    #endregion

    #region HandlingCharges TextChanged
    protected void HandlingCharges_TextChanged(object sender, EventArgs e)
    {

        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;

        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty && Insurance.Text != string.Empty && MiscExp.Text != string.Empty && StatisticalCharges.Text != string.Empty && CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty && FreightCharges.Text != string.Empty)
        {

            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amnt;
            amnt = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amnt;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            CartageCharges.Focus();
        }
    }
    #endregion

    #region CartageCharges TextChanged
    protected void CartageCharges_TextChanged(object sender, EventArgs e)
    {
        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;
        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty && Insurance.Text != string.Empty && MiscExp.Text != string.Empty && StatisticalCharges.Text != string.Empty && CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty && FreightCharges.Text != string.Empty)
        {
            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amnt;
            amnt = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amnt;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            StatisticalCharges.Focus();
        }
    }
    #endregion

    #region StatisticalCharges TextChanged
    protected void StatisticalCharges_TextChanged(object sender, EventArgs e)
    {
        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;
        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty && Insurance.Text != string.Empty && MiscExp.Text != string.Empty && StatisticalCharges.Text != string.Empty && CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty && FreightCharges.Text != string.Empty)
        {
            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amt;
            amt = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amt;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            MiscExp.Focus();
        }
    }
    #endregion

    #region MiscExp TextChanged
    protected void MiscExp_TextChanged(object sender, EventArgs e)
    {
        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;
        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty && Insurance.Text != string.Empty && MiscExp.Text != string.Empty && StatisticalCharges.Text != string.Empty && CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty && FreightCharges.Text != string.Empty)
        {
            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amt;
            amt = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amt;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            Insurance.Focus();
        }
    }
    #endregion

    #region Insurance TextChanged
    protected void Insurance_TextChanged(object sender, EventArgs e)
    {

        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;
        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty && Insurance.Text != string.Empty && MiscExp.Text != string.Empty && StatisticalCharges.Text != string.Empty && CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty && FreightCharges.Text != string.Empty)
        {
            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amt;
            amt = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amt;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            AOC.Focus();
        }
    }
    #endregion

    #region AOC TextChanged
    protected void AOC_TextChanged(object sender, EventArgs e)
    {
        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;
        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty && Insurance.Text != string.Empty && MiscExp.Text != string.Empty && StatisticalCharges.Text != string.Empty && CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty && FreightCharges.Text != string.Empty)
        {
            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amt;
            amt = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amt;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            ServiceTax.Focus();
        }
    }
    #endregion

    #region ServiceTax TextChanged
    protected void ServiceTax_TextChanged(object sender, EventArgs e)
    {
        DataTable Rate = (DataTable)ViewState["NewGrid"];
        decimal Totalamnt = 0;
        foreach (DataRow drr in Rate.Rows)
        {
            Totalamnt += Convert.ToDecimal(drr["Total"].ToString());
        }
        decimal rat = Convert.ToDecimal(Totalamnt);//string.Format("{0:0}", Qty);
        ViewState["Total"] = rat;
        if (ServiceTax.Text != string.Empty && AOC.Text != string.Empty && Insurance.Text != string.Empty && MiscExp.Text != string.Empty && StatisticalCharges.Text != string.Empty && CartageCharges.Text != string.Empty && HandlingCharges.Text != string.Empty && FreightCharges.Text != string.Empty)
        {
            decimal FC, HC, CC, SC, ME, Ins, AO, ST, Tot,amt;
            amt = (decimal)ViewState["Total"];
            FC = decimal.Parse(FreightCharges.Text);
            HC = decimal.Parse(HandlingCharges.Text);
            CC = decimal.Parse(CartageCharges.Text);
            SC = decimal.Parse(StatisticalCharges.Text);
            ME = decimal.Parse(MiscExp.Text);
            Ins = decimal.Parse(Insurance.Text);
            AO = decimal.Parse(AOC.Text);
            ST = decimal.Parse(ServiceTax.Text);
            Tot = FC + HC + CC + SC + ME + Ins + AO + ST+amt;
            Total.Text = string.Format("{0:0}", Tot);
            //GridShow();
            //InsuranceCompanyName.Focus();
        }
    }
    #endregion

    #region GridBook RowCommand
    protected void GridBook_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "InsertNew")
        {
            if (btnSave.Text == "Save")
            {
                DataTable dtInsert = (DataTable)ViewState["CreateTable"];
                DataRow drow = dtInsert.NewRow();
                TextBox txtPack = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                DropDownList ddlPackings1 = GridBook.FooterRow.FindControl("ddlPackings1") as DropDownList;
               // DropDownList ddlrate1 = GridBook.FooterRow.FindControl("ddlrate1") as DropDownList;

                TextBox txtRate = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
                TextBox txtActualWeight = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;

                string ItemName = ddlItemName.SelectedItem.Text;

                if (txtPack.Text == string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Packages Should Not Be Empty";
                    if (dtInsert.Rows.Count < 1)
                    {
                        Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    }
                    txtPack.Focus();
                }
                else if (ddlItemName.SelectedIndex == 0)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Select the ItemName";
                    if (dtInsert.Rows.Count < 1)
                    {
                        Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    }
                    ddlItemName.Focus();
                }

                else if (ddlPackings1.SelectedIndex == 0)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Select the Packings";
                    if (dtInsert.Rows.Count < 1)
                    {
                        Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    }
                    ddlPackings1.Focus();
                }
                else if (txtRate.Text ==string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Select the Rate";
                    if (dtInsert.Rows.Count < 1)
                    {
                        Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    }
                    txtRate.Focus();
                }
                else if (txtActualWeight.Text == string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Actual Weight Should Not Be Empty";
                    if (dtInsert.Rows.Count < 1)
                    {
                        Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    }
                    txtActualWeight.Focus();
                }
                else if (txtChargedWeight.Text == string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Charged Weight Should Not Be Empty";
                    if (dtInsert.Rows.Count < 1)
                    {
                        Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    }
                    txtChargedWeight.Focus();
                }
                else if (dtInsert.Rows.Count < 3 && dtInsert != null)
                {
                    drow["Packages"] = txtPack.Text.Trim();
                    drow["ItemName"] = ddlItemName.SelectedItem.Text;
                    drow["Packings"] = ddlPackings1.SelectedItem.Text;
                    drow["Rate"] = txtRate.Text;
                    drow["Weight"] = txtActualWeight.Text.Trim();
                    drow["ChargedWeight"] = txtChargedWeight.Text.Trim();
                    drow["Total"] = txtTotal.Text.Trim();

                    dtInsert.Rows.Add(drow);
                    GridBook.DataSource = dtInsert;
                    GridBook.DataBind();
                    ViewState["NewGrid"] = dtInsert;
                    ItemName_Load();
                    TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;

                    txtPack1.Focus();
                }
                if (dtInsert.Rows.Count == 3)
                {
                    TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                    DropDownList ddlPackings = GridBook.FooterRow.FindControl("ddlPackings1") as DropDownList;
                   // DropDownList ddlrate = GridBook.FooterRow.FindControl("ddlrate1") as DropDownList;
                    //DropDownList ddlDesc1 = GridBook.FooterRow.FindControl("txtDesc1") as DropDownList;
                    TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                    TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                    TextBox txtItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as TextBox;
                    TextBox txtRate1 = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
                    TextBox txtTotal1 = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
                    LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
                    LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
                    ddlItemName.Visible = false;
                    txtActualWeight1.Visible = false;
                    txtChargedWeight1.Visible = false;
                    txtPack1.Visible = false;
                    link.Visible = false;
                    link1.Visible = false;
                    ViewState["NewGrid"] = dtInsert;
                }
            }
            else if (btnSave.Text == "Update")
            {
                DataTable dtInsert1 = (DataTable)ViewState["LoadGridUpdate"];
                DataRow drow = dtInsert1.NewRow();
                TextBox txtPack = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                DropDownList ddlPackings1 = GridBook.FooterRow.FindControl("ddlPackings1") as DropDownList;
                TextBox txtRate1 = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
                TextBox txtActualWeight = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
                string ItemName = ddlItemName.SelectedItem.Text.Trim();

                if (txtPack.Text == string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Packages Should Not Be Empty";
                    Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    txtPack.Focus();
                }
                else if (ddlItemName.SelectedIndex == 0)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Select the ItemName";
                    Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    ddlItemName.Focus();
                }

                else if (ddlPackings1.SelectedIndex == 0)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Select the ItemName";
                    Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    ddlPackings1.Focus();
                }
                else if (txtRate1.Text==string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Select the ItemName";
                    Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    txtRate1.Focus();
                }
                else if (txtActualWeight.Text == string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Actual Weight Should Not Be Empty";
                    Grid_Row(GridBook);     // This is to hide the first row of the dynamic grid
                    txtActualWeight.Focus();
                }
                else if (txtChargedWeight.Text == string.Empty)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Charged Weight Should Not Be Empty";
                    if (dtInsert1.Rows.Count < 1)
                    {
                        Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                    }
                    txtChargedWeight.Focus();
                }
                else if (dtInsert1.Rows.Count < 3 && dtInsert1 != null)
                {
                    drow["Packages"] = txtPack.Text.Trim();
                    drow["ItemName"] = ddlItemName.SelectedItem.Text;
                    drow["Rate"] = txtRate1.Text;
                    drow["Packings"] = ddlPackings1.SelectedItem.Text;
                    drow["Weight"] = txtActualWeight.Text.Trim();
                    drow["ChargedWeight"] = txtChargedWeight.Text.Trim();
                    drow["Total"] = txtTotal.Text.Trim();
                    dtInsert1.Rows.Add(drow);
                    GridBook.DataSource = dtInsert1;
                    GridBook.DataBind();
                    ViewState["GridUpdate"] = dtInsert1;
                    txtPack.Focus();
                }
                if (dtInsert1.Rows.Count == 3)
                {
                    TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                    DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                    TextBox txtRate = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
                    TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                    TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                    TextBox txtTotal1 = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
                    LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
                    LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
                    ddlItemName.Visible = false;
                    txtActualWeight1.Visible = false;
                    txtChargedWeight1.Visible = false;
                    txtPack1.Visible = false;
                    link.Visible = false;
                    link1.Visible = false;
                    ViewState["GridUpdate"] = dtInsert1;
                }
            }
        }
        if (e.CommandName == "CancelNew")
        {
            if (btnSave.Text == "Save")
            {
                TextBox txtPack = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                DropDownList ddlPackings = GridBook.FooterRow.FindControl("ddlPackings1") as DropDownList;
               
                TextBox txtRate = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
                TextBox txtActualWeight = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
                txtPack.Text = string.Empty;
                ddlItemName.SelectedIndex = 0;
                ddlPackings.SelectedIndex = 0;
                txtRate.Text=string.Empty;
                txtActualWeight.Text = string.Empty;
                txtChargedWeight.Text = string.Empty;
                if (GridBook.Rows.Count <= 1)
                {
                    GridShow();
                    ItemName_Load();
                }
                txtPack.Focus();
            }
            else if (btnSave.Text == "Update")
            {
                TextBox txtPack = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                DropDownList ddlPackings = GridBook.FooterRow.FindControl("ddlPackings1") as DropDownList;
                
                TextBox txtRate = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
                TextBox txtActualWeight = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
                txtPack.Text = string.Empty;
                ddlItemName.SelectedIndex = 0;
                ddlPackings.SelectedIndex = 0;
                txtRate.Text =string.Empty;
                txtActualWeight.Text = string.Empty;
                txtChargedWeight.Text = string.Empty;
                txtPack.Focus();
                ItemName_Load();
            }
        }

    }
    #endregion

    #region GridBook RowCancelingEdit
    protected void GridBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridBook.EditIndex = -1;
        DataTable dtCancel = (DataTable)ViewState["NewGrid"];
        GridBook.DataSource = dtCancel;
        GridBook.DataBind();
        TextBox txtPack = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
        txtPack.Focus();
        lblResult.Visible = false;
        ItemName_Load();

        if (dtCancel.Rows.Count == 3)
        {
            TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
            //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
            DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
            TextBox txtRate1 = GridBook.FooterRow.FindControl("txtRate1") as TextBox;
            TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
            TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
            TextBox txtTotal1 = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
            LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
            LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
            ddlItemName1.Visible = false;
            txtActualWeight1.Visible = false;
            txtChargedWeight1.Visible = false;
            txtPack1.Visible = false;
            link.Visible = false;
            link1.Visible = false;
        }
    }
    #endregion

    #region GridBook RowEditing
    protected void GridBook_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridBook.EditIndex = e.NewEditIndex;
        int RowIndex = e.NewEditIndex;
        ViewState["RowNo"] = RowIndex;
        
        //ddlItemName.SelectedIndex = ddlItemName.Items.IndexOf(ddlItemName.Items.FindByText(dt.Rows[RowIndex]["ItemName"].ToString()));
        //ddlPackings.SelectedIndex = ddlPackings.Items.IndexOf(ddlPackings.Items.FindByText(dt.Rows[RowIndex]["Packings"].ToString()));
                
        if (btnSave.Text == "Save")
        {
           // DropDownList ddlItemName = GridBook.Rows[RowIndex].FindControl("ddlItemName") as DropDownList;
           
            TextBox txtRate1 = GridBook.Rows[RowIndex].FindControl("txtRate") as TextBox;
            TextBox txtPack = GridBook.Rows[RowIndex].FindControl("txtPackages") as TextBox;
            TextBox txtActualWeight = GridBook.Rows[RowIndex].FindControl("txtActualWeight") as TextBox;
            TextBox txtChargedWeight = GridBook.Rows[RowIndex].FindControl("txtChargedWeight") as TextBox;
            TextBox txtTotal = GridBook.Rows[RowIndex].FindControl("txtTotal") as TextBox;

            DataTable dt = (DataTable)ViewState["NewGrid"];
            if (dt.Rows.Count > 0 && dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GridBook.DataSource = dt;
                    GridBook.DataBind();
                    ViewState["LoadGrid"] = dt;
                }
                DropDownList ddlItemName = GridBook.Rows[RowIndex].FindControl("ddlItemName") as DropDownList;
                string Branch = Components.DTO.LoginDTO.BranchName;
                DataTable dtItem = BDBL.ItemName_Load(Branch);
                if (dtItem != null && dtItem.Rows.Count > 0)
                {
                    ddlItemName.DataSource = dtItem;
                    ddlItemName.DataValueField = "ID";
                    ddlItemName.DataTextField = "ItemName";
                    ddlItemName.DataBind();
                    ddlItemName.Items.Insert(0, "---SELECT---");
                    ddlItemName.SelectedIndex = ddlItemName.Items.IndexOf(ddlItemName.Items.FindByText(dt.Rows[RowIndex]["ItemName"].ToString()));
                }
                DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                //DataTable dtItem = BDBL.ItemName_Load();
                if (dtItem != null && dtItem.Rows.Count > 0)
                {
                    ddlItemName1.DataSource = dtItem;
                    ddlItemName1.DataValueField = "ID";
                    ddlItemName1.DataTextField = "ItemName";
                    ddlItemName1.DataBind();
                    ddlItemName1.Items.Insert(0, "---SELECT---");
                }
                DropDownList ddlPackings = GridBook.Rows[RowIndex].FindControl("ddlPackings") as DropDownList;
                ddlPackings.SelectedIndex = ddlPackings.Items.IndexOf(ddlPackings.Items.FindByText(dt.Rows[RowIndex]["Packings"].ToString()));
         
            }
            if (dt.Rows.Count == 3)
            {
                TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                TextBox txtRate = GridBook.FooterRow.FindControl("txtRate1") as TextBox;
                TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                TextBox txtTotal1 = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
                LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
                LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
                ddlItemName1.Visible = false;
                txtActualWeight1.Visible = false;
                txtChargedWeight1.Visible = false;
                txtPack1.Visible = false;
                link.Visible = false;
                link1.Visible = false;
            }
        }
        else if (btnSave.Text == "Update")
        {
            DropDownList ddlPackings = GridBook.Rows[RowIndex].FindControl("ddlPackings") as DropDownList;
            TextBox txtRate1 = GridBook.Rows[RowIndex].FindControl("txtRate") as TextBox;
            TextBox txtActualWeight = GridBook.Rows[RowIndex].FindControl("txtActualWeight") as TextBox;
            TextBox txtChargedWeight = GridBook.Rows[RowIndex].FindControl("txtChargedWeight") as TextBox;
            TextBox txtTotal = GridBook.Rows[RowIndex].FindControl("txtTotal") as TextBox;
            TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
            DataTable dt1 = (DataTable)ViewState["LoadGridUpdate"];


            if (dt1.Rows.Count > 0 && dt1 != null)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    GridBook.DataSource = dt1;
                    GridBook.DataBind();
                    ViewState["LoadGrid1"] = dt1;
                }
                DropDownList ddlItemName = GridBook.Rows[RowIndex].FindControl("ddlItemName") as DropDownList;
                string Branch = Components.DTO.LoginDTO.BranchName;
                DataTable dtItem = BDBL.ItemName_Load(Branch);
                if (dtItem != null && dtItem.Rows.Count > 0)
                {
                    ddlItemName.DataSource = dtItem;
                    ddlItemName.DataValueField = "ID";
                    ddlItemName.DataTextField = "ItemName";
                    ddlItemName.DataBind();
                    ddlItemName.Items.Insert(0, "---SELECT---");
                    ddlItemName.SelectedIndex = ddlItemName.Items.IndexOf(ddlItemName.Items.FindByText(dt1.Rows[RowIndex]["ItemName"].ToString()));
                }
                DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                //DataTable dtItem = BDBL.ItemName_Load();
                if (dtItem != null && dtItem.Rows.Count > 0)
                {
                    ddlItemName1.DataSource = dtItem;
                    ddlItemName1.DataValueField = "ID";
                    ddlItemName1.DataTextField = "ItemName";
                    ddlItemName1.DataBind();
                    ddlItemName1.Items.Insert(0, "---SELECT---");
                }
                ddlPackings.SelectedIndex = ddlPackings.Items.IndexOf(ddlPackings.Items.FindByText(dt1.Rows[RowIndex]["Packings"].ToString()));

            }
            if (dt1.Rows.Count == 3)
            {
                TextBox txtPack = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                TextBox txtRate = GridBook.FooterRow.FindControl("txtRate1") as TextBox;
                TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                TextBox txtTotal1 = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
                LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
                LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
                ddlItemName1.Visible = false;
                txtActualWeight1.Visible = false;
                txtChargedWeight1.Visible = false;
                txtPack1.Visible = false;
                link.Visible = false;
                link1.Visible = false;
            }
        }
    }
    #endregion

    #region GridBook RowUpdating
    protected void GridBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            DataTable dtUpdate = (DataTable)ViewState["NewGrid"];

            int RowNo = (int)ViewState["RowNo"];
            GridViewRow row = GridBook.Rows[RowNo];
            TextBox txtPack = row.FindControl("txtPackages") as TextBox;
            DropDownList ddlItemName = row.FindControl("ddlItemName") as DropDownList;
            DropDownList ddlPackings = row.FindControl("ddlPackings") as DropDownList;
            //DropDownList ddlrate =row.FindControl("ddlrate") as DropDownList;
            TextBox txtRate = row.FindControl("txtrate") as TextBox;
            TextBox txtWeight = row.FindControl("txtActualWeight") as TextBox;
            TextBox txtChargedWeight = row.FindControl("txtChargedWeight") as TextBox;
            TextBox txtTotal = row.FindControl("txtTotal") as TextBox;

            if (txtPack.Text == string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "No of Packages Should Not Be Empty";
                if (dtUpdate.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtPack.Focus();
            }
            else if (txtWeight.Text == string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "Weight Should Not Be Empty";
                if (dtUpdate.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtWeight.Focus();
            }
            else if (ddlItemName.SelectedIndex == 0)
            {
                lblResult.Visible = true;
                lblResult.Text = "Select the ItemName";
                if (dtUpdate.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                ddlItemName.Focus();
            }
            else if (ddlPackings.SelectedIndex == 0)
            {
                lblResult.Visible = true;
                lblResult.Text = "Select the Packings";
                if (dtUpdate.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                ddlPackings.Focus();
            }
            else if (txtRate.Text ==string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "Select the Rate";
                if (dtUpdate.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtRate.Focus();
            }
            else if (txtChargedWeight.Text == string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "Charged Weight Should Not Be Empty";
                if (dtUpdate.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtChargedWeight.Focus();
            }

            else
            {
                dtUpdate.Rows[RowNo]["Packages"] = txtPack.Text.Trim();
                dtUpdate.Rows[RowNo]["ItemName"] = ddlItemName.SelectedItem.Text.Trim();
                dtUpdate.Rows[RowNo]["Packings"] = ddlPackings.SelectedItem.Text;
                dtUpdate.Rows[RowNo]["Rate"] = txtRate.Text;
                dtUpdate.Rows[RowNo]["Weight"] = txtWeight.Text.Trim();
                dtUpdate.Rows[RowNo]["ChargedWeight"] = txtChargedWeight.Text.Trim();
                dtUpdate.Rows[RowNo]["Total"] = txtTotal.Text.Trim();
                GridBook.EditIndex = -1;

                GridBook.DataSource = dtUpdate;
                GridBook.DataBind();
                ViewState["GridUpdate"] = dtUpdate;

                ItemName_Load();


            }
            //ViewState["Rate"] = txtRate.Text;
            //TextBox txtRate = GridBook.FooterRow.FindControl("txtRate_footer") as TextBox;
            //txtRate1.Text = ViewState["Rate"].ToString();

            if (dtUpdate.Rows.Count == 3)
            {
                TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                TextBox txtRate1 = GridBook.FooterRow.FindControl("txtRate1") as TextBox;
                TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
                LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
                ddlItemName.Visible = false;
                txtActualWeight1.Visible = false;
                txtChargedWeight1.Visible = false;
                txtPack1.Visible = false;
                link.Visible = false;
                link1.Visible = false;
            }
        }
        else if (btnSave.Text == "Update")
        {
            DataTable dtUpdate1 = (DataTable)ViewState["LoadGridUpdate"];

            int RowNo = (int)ViewState["RowNo"];
            GridViewRow row = GridBook.Rows[RowNo];
            TextBox txtPack = row.FindControl("txtPackages") as TextBox;
            DropDownList ddlItemName = row.FindControl("ddlItemName") as DropDownList;
            DropDownList ddlPackings = row.FindControl("ddlPackings") as DropDownList;
           // DropDownList ddlrate = row.FindControl("ddlrate") as DropDownList;
            TextBox txtRate = row.FindControl("txtRate") as TextBox;
            TextBox txtWeight = row.FindControl("txtActualWeight") as TextBox;
            TextBox txtChargedWeight = row.FindControl("txtChargedWeight") as TextBox;
            TextBox txtTotal = row.FindControl("txtTotal") as TextBox;

            if (txtPack.Text == string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "No of Packages Should Not Be Empty";
                if (dtUpdate1.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtPack.Focus();
            }
            else if (txtWeight.Text == string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "Weight Should Not Be Empty";
                if (dtUpdate1.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtWeight.Focus();
            }
            else if (ddlItemName.SelectedIndex == 0)
            {
                lblResult.Visible = true;
                lblResult.Text = "Select the ItemName";
                if (dtUpdate1.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                ddlItemName.Focus();
            }
            else if (ddlPackings.SelectedIndex == 0)
            {
                lblResult.Visible = true;
                lblResult.Text = "Select the Packings";
                if (dtUpdate1.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                ddlPackings.Focus();
            }
            else if (txtRate.Text==string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "Select the Rate";
                if (dtUpdate1.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtRate.Focus();
            }
            else if (txtChargedWeight.Text == string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = "Charged Weight Should Not Be Empty";
                if (dtUpdate1.Rows.Count < 1)
                {
                    Grid_Row(GridBook); // This is to hide the first row of the dynamic grid
                }
                txtChargedWeight.Focus();
            }
            else
            {
                dtUpdate1.Rows[RowNo]["Packages"] = txtPack.Text.Trim();
                dtUpdate1.Rows[RowNo]["ItemName"] = ddlItemName.SelectedItem.Text.Trim();
                dtUpdate1.Rows[RowNo]["Packings"] = ddlPackings.SelectedItem.Text;
                dtUpdate1.Rows[RowNo]["Rate"] = txtRate.Text;
                dtUpdate1.Rows[RowNo]["Weight"] = txtWeight.Text.Trim();
                dtUpdate1.Rows[RowNo]["ChargedWeight"] = txtChargedWeight.Text.Trim();
                dtUpdate1.Rows[RowNo]["Total"] = txtTotal.Text.Trim();

                GridBook.EditIndex = -1;

                GridBook.DataSource = dtUpdate1;
                GridBook.DataBind();
                ViewState["LoadGridUpdate"] = dtUpdate1;

                ItemName_Load();
            }

            if (dtUpdate1.Rows.Count == 3)
            {
                TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                //TextBox txtDesc = GridBook.FooterRow.FindControl("txtDesc1") as TextBox;
                DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                TextBox txtRate1 = GridBook.FooterRow.FindControl("txtRate1") as TextBox;
                TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
                LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
                ddlItemName1.Visible = false;
                txtActualWeight1.Visible = false;
                txtChargedWeight1.Visible = false;
                txtPack1.Visible = false;
                link.Visible = false;
                link1.Visible = false;
            }
        }
    }
    #endregion

    #region GridBook RowDeleting
    protected void GridBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        if (btnSave.Text == "Save")
        {
            DataTable dtDel = (DataTable)ViewState["CreateTable"];
            if (dtDel.Rows.Count > 0 && dtDel != null)
            {
                dtDel.Rows[e.RowIndex].Delete();
                GridBook.DataSource = dtDel;
                GridBook.DataBind();
                //ViewState["NewGrid"] = dtDel;
            }
            if (dtDel.Rows.Count < 1)
            {
                CreateTable();
                GridShow();
                ItemName_Load();
            }
        }
        else if (btnSave.Text == "Update")
        {
            DataTable dtDel = (DataTable)ViewState["LoadGridUpdate"];
            if (dtDel != null && dtDel.Rows.Count > 0)
            {
                int BDID = GlbFunc.ConvertStrToInt(dtDel.Rows[index]["BookingDetailsID"].ToString());
                string Branch = Components.DTO.LoginDTO.BranchName;
                int aff = BDBL.BookingDetails_RowDelete(BDID,Branch);
                if (aff > 0)
                {
                    dtDel.Rows.RemoveAt(e.RowIndex);
                    GridBook.DataSource = dtDel;
                    GridBook.DataBind();

                    ItemName_Load();
                }
            }
            if (dtDel.Rows.Count < 1)
            {
                CreateTable();
                GridShow();
                ItemName_Load();
            }
        }
    }
    #endregion

    #region btnSave
    protected void btnSave_Click(object sender, EventArgs e)
    {
        GlbFunc = Components.Common.GlobalFunction.Instance;
        BDBL = Components.BL.BookDetailsBL.Instance;
        BDDTO = new Components.DTO.BookDetailsDTO();
        try
        {
            if (btnSave.Text == "Save")
            {
                BookDetailsSave();
                DataTable dtBookItem = (DataTable)ViewState["NewGrid"];
                if (dtBookItem != null && dtBookItem.Rows.Count > 0)
                {
                    BDDTO.BranchName = Components.DTO.LoginDTO.BranchName;
                    string Branch = Components.DTO.LoginDTO.BranchName;
                    string UserID = Components.DTO.LoginDTO.UserID;
                    decimal balanceamount =Convert.ToDecimal(txtbalanceamount.Text);
                    affectedRows = BDBL.BookDetSave(BDDTO, dtBookItem,Branch,UserID,balanceamount);

                    if (affectedRows > 0)
                    {
                        
                        lblResult.Visible = true;
                        lblResult.Text = "Record Saved Successfully";
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@LRNo", LRNo.Text.Trim());
                        param[1] = new SqlParameter("@BranchName", Branch);
                        SqlHelper = Components.DAL.SQLConnect.Instance;
                        SqlHelper.SqlProcedure = "BookingDetails_Report";
                        SqlHelper.SqlParam = param;
                        SqlHelper.PageName = Page.GetType().BaseType.FullName;
                        Response.Redirect("NewReport.aspx");
                        Clear();
                        AutoGenLoad();
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.Text = "Record Already Exists";
                    }
                }
                else
                {
                    lblResult.Visible = true;
                    lblResult.Text = "No.of Packages Should not emplty";
                }
            }
            else if (btnSave.Text == "Update")
            {
                BookDetailsUpdate();
                DataTable dtBookItem1 = (DataTable)ViewState["LoadGridUpdate"];
                int ID = GlbFunc.ConvertStrToInt(hidBookDetID.Value.Trim());
                string Branch = Components.DTO.LoginDTO.BranchName;
                string UserID = Components.DTO.LoginDTO.UserID;
                affectedRows = BDBL.BookDetUpdate(BDDTO, dtBookItem1, ID,Branch,UserID);

                if (affectedRows > 0)
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Record Updated Successfully";
                    Clear();
                    AutoGenLoad();
                }
            }
        }

        catch
        {
            lblResult.Text = "Error";
        }
    }
    #endregion

    #region BookDetailsSave
    public void BookDetailsSave()
    {
        int LNo = GlbFunc.ConvertStrToInt(LRNo.Text);

        if (LNo <= 9)
        {
            LRNo.Text = "00" + LNo;
        }
        else if (LNo < 99)
        {
            LRNo.Text = "0" + LNo;
        }
        BDDTO.LRNo = LRNo.Text.Trim();
        BDDTO.BookingDate = GlbFunc.ConvertStrToDateTime(BookingDate.Text.Trim());
        BDDTO.ConsignorID = GlbFunc.ConvertStrToInt(hidConsignor.Value);
        BDDTO.ConsigneeID = GlbFunc.ConvertStrToInt(hidConsignee.Value);
        BDDTO.StoreID = GlbFunc.ConvertStrToInt(hidStoreID.Value);
        BDDTO.InsuranceCoName = InsuranceCompanyName.Text.Trim();
        BDDTO.PolicyNo = PolicyNo.Text.Trim();
        BDDTO.Date = GlbFunc.ConvertStrToDateTime(Date.Text.Trim());
        BDDTO.Risk = Risk.Text.Trim();
        BDDTO.AgentID = GlbFunc.ConvertStrToInt(hidAgent.Value);
        BDDTO.From = From.Text.Trim();
        BDDTO.To = To.Text.Trim();
        BDDTO.FreightCharges = Convert.ToDecimal(FreightCharges.Text.Trim());
        BDDTO.HandlingCharges = Convert.ToDecimal(HandlingCharges.Text.Trim());
        BDDTO.CartageCharges = Convert.ToDecimal(CartageCharges.Text.Trim());
        BDDTO.StatisticalCharges = Convert.ToDecimal(StatisticalCharges.Text.Trim());
        BDDTO.MiscExp = Convert.ToDecimal(MiscExp.Text.Trim());
        BDDTO.Insurance = Convert.ToDecimal(Insurance.Text.Trim());
        BDDTO.AOC = Convert.ToDecimal(AOC.Text.Trim());
        BDDTO.ServiceTax = Convert.ToDecimal(ServiceTax.Text.Trim());
        BDDTO.UserID = Components.DTO.LoginDTO.UserID;
    }
    #endregion

    #region BookDetailsUpdate
    public void BookDetailsUpdate()
    {
        BDDTO.LRNo = LRNo.Text.Trim();
        BDDTO.BookingDate = GlbFunc.ConvertStrToDateTime(BookingDate.Text.Trim());
        BDDTO.ConsignorID = GlbFunc.ConvertStrToInt(hidConsignor.Value);
        BDDTO.ConsigneeID = GlbFunc.ConvertStrToInt(hidConsignee.Value);
        BDDTO.StoreID = GlbFunc.ConvertStrToInt(hidStoreID.Value);
        BDDTO.InsuranceCoName = InsuranceCompanyName.Text.Trim();
        BDDTO.PolicyNo = PolicyNo.Text.Trim();
        BDDTO.Date = GlbFunc.ConvertStrToDateTime(Date.Text.Trim());
        BDDTO.Risk = Risk.Text.Trim();
        BDDTO.AgentID = GlbFunc.ConvertStrToInt(hidAgent.Value);
        BDDTO.From = From.Text.Trim();
        BDDTO.To = To.Text.Trim();
        BDDTO.FreightCharges = Convert.ToDecimal(FreightCharges.Text.Trim());
        BDDTO.HandlingCharges = Convert.ToDecimal(HandlingCharges.Text.Trim());
        BDDTO.CartageCharges = Convert.ToDecimal(CartageCharges.Text.Trim());
        BDDTO.StatisticalCharges = Convert.ToDecimal(StatisticalCharges.Text.Trim());
        BDDTO.MiscExp = Convert.ToDecimal(MiscExp.Text.Trim());
        BDDTO.Insurance = Convert.ToDecimal(Insurance.Text.Trim());
        BDDTO.AOC = Convert.ToDecimal(AOC.Text.Trim());
        BDDTO.ServiceTax = Convert.ToDecimal(ServiceTax.Text.Trim());
        BDDTO.UserID = Components.DTO.LoginDTO.UserID;
    }
    #endregion

    #region Clear()
    private void Clear()
    {
        BookingDate.Text = string.Empty;
        Consignor.Text = string.Empty;
        Consignee.Text = string.Empty;
        hidConsignor.Value = string.Empty;
        AgentName.Text = string.Empty;
        Address.Text = string.Empty;
        City.Text = string.Empty;
        Pincode.Text = string.Empty;
       // StoreNo.Items.Insert(0, "--Select--");
        StoreNo.SelectedIndex = 0;
        hidConsignee.Value = string.Empty;
        ConsigneeAddress.Text = string.Empty;
        ConsigneeCity.Text = string.Empty;
        ConsigneePincode.Text = string.Empty;
        InsuranceCompanyName.Text = string.Empty;
        PolicyNo.Text = string.Empty;
        Date.Text = string.Empty;
        Risk.Text = string.Empty;
        hidAgent.Value = string.Empty;
        From.Text = string.Empty;
        To.Text = string.Empty;
        FreightCharges.Text = string.Empty;
        HandlingCharges.Text = string.Empty;
        CartageCharges.Text = string.Empty;
        StatisticalCharges.Text = string.Empty;
        MiscExp.Text = string.Empty;
        Insurance.Text = string.Empty;
        AOC.Text = string.Empty;
        ServiceTax.Text = string.Empty;
        Total.Text = string.Empty;

        GridBook.DataSource = null;
        GridBook.DataBind();
        CreateTable();
        GridShow();
        ItemName_Load();
        Consignor.Focus();
        btnSave.Text = "Save";
        AutoGenLoad();
        From.Text = Components.DTO.LoginDTO.BranchName;
        txtbalanceamount.Text="";
        txtpaidamount.Text="";
    }
    #endregion

    #region btnClear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
        lblResult.Text = "";
    }
    #endregion

    #region btnDelete
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GlbFunc = Components.Common.GlobalFunction.Instance;
        BDBL = Components.BL.BookDetailsBL.Instance;
        BDDTO = new Components.DTO.BookDetailsDTO();
        try
        {
            int BookDetID = GlbFunc.ConvertStrToInt(hidBookDetID.Value.Trim());
            BDDTO.UserID = Components.DTO.LoginDTO.UserID;
            BDDTO.LRNo = LRNo.Text.Trim();
            dtBook = (DataTable)ViewState["NewGrid"];
            string Branch = Components.DTO.LoginDTO.BranchName;
            string UserID = Components.DTO.LoginDTO.UserID;
            affectedRows = BDBL.DeleteBookDet(BDDTO, dtBook, BookDetID,UserID,Branch);
            if (affectedRows > 0)
            {
                resultMsg = "Record Deleted Successfully";
                Clear();
                AutoGenLoad();
            }
            else
            {
                lblResult.Text = "Record Not Deleted";
            }
        }
        catch
        {
            resultMsg = "Delete Record Failed";
        }
        finally
        {


        }
    }
    #endregion

    #region LRNO TextChanged
    protected void LRNo_TextChanged(object sender, EventArgs e)
    {
        BDDTO.LRNo = LRNo.Text;
        string Branch = Components.DTO.LoginDTO.BranchName;
        dsBook = BDBL.LoadData(BDDTO,Branch);
        if (dsBook.Tables.Count > 0 && dsBook != null)
        {
            DataTable dtLoad = dsBook.Tables[0];
            if (dtLoad.Rows.Count > 0 && dtLoad != null)
            {
                hidBookDetID.Value = dtLoad.Rows[0]["ID"].ToString();
                BookingDate.Text = dtLoad.Rows[0]["BookingDate"].ToString();
                Consignor.Text = dtLoad.Rows[0]["ConsignorName"].ToString();
                hidConsignor.Value = dtLoad.Rows[0]["ConsignorID"].ToString();
                hidStoreID.Value = dtLoad.Rows[0]["StoreID"].ToString();
                Address.Text = dtLoad.Rows[0]["Address"].ToString();
                City.Text = dtLoad.Rows[0]["City"].ToString();
                Pincode.Text = dtLoad.Rows[0]["Pincode"].ToString();
                Consignee.Text = dtLoad.Rows[0]["ConsigneeName"].ToString();
                hidConsignee.Value = dtLoad.Rows[0]["ConsigneeID"].ToString();
                ConsigneeAddress.Text = dtLoad.Rows[0]["ConsigneeAddr"].ToString();
                ConsigneeCity.Text = dtLoad.Rows[0]["ConsigneeCity"].ToString();
                ConsigneePincode.Text = dtLoad.Rows[0]["ConsigneePincode"].ToString();
                StoreNo.SelectedIndex = StoreNo.Items.IndexOf(StoreNo.Items.FindByText(dtLoad.Rows[0]["StoreNo"].ToString()));
                AgentName.Text = dtLoad.Rows[0]["AgentName"].ToString();
                hidAgent.Value = dtLoad.Rows[0]["AgentID"].ToString();
                FreightCharges.Text = dtLoad.Rows[0]["Freight"].ToString();
                HandlingCharges.Text = dtLoad.Rows[0]["HandlingCharges"].ToString();
                CartageCharges.Text = dtLoad.Rows[0]["CartageCharges"].ToString();
                StatisticalCharges.Text = dtLoad.Rows[0]["StatisticalCharges"].ToString();
                MiscExp.Text = dtLoad.Rows[0]["MiscExp"].ToString();
                Insurance.Text = dtLoad.Rows[0]["Insurance"].ToString();
                AOC.Text = dtLoad.Rows[0]["AOC"].ToString();
                ServiceTax.Text = dtLoad.Rows[0]["ServiceTax"].ToString();
                Total.Text = dtLoad.Rows[0]["Total"].ToString();
                InsuranceCompanyName.Text = dtLoad.Rows[0]["InsuranceCoName"].ToString();
                PolicyNo.Text = dtLoad.Rows[0]["PolicyNo"].ToString();
                Date.Text = dtLoad.Rows[0]["PolicyDate"].ToString();
                Risk.Text = dtLoad.Rows[0]["Risk"].ToString();
                From.Text = dtLoad.Rows[0]["StartFrom"].ToString();
                To.Text = dtLoad.Rows[0]["DestTo"].ToString();
            }
            DataTable dtLoadIt = dsBook.Tables[1];
            if (dtLoadIt.Rows.Count > 0 && dtLoadIt != null)
            {
                GridBook.DataSource = dtLoadIt;
                GridBook.DataBind();
                ViewState["LoadGridUpdate"] = dtLoadIt;

                DropDownList ddlItemName = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                //string Branch = Components.DTO.LoginDTO.BranchName;
                DataTable dtItem1 = BDBL.ItemName_Load(Branch);
                ddlItemName.DataSource = dtItem1;
                ddlItemName.DataValueField = "ID";
                ddlItemName.DataTextField = "ItemName";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, "---SELECT---");

                if (dtLoadIt.Rows.Count == 3)
                {
                    TextBox txtPack1 = GridBook.FooterRow.FindControl("txtPackages1") as TextBox;
                    DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
                    TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
                    TextBox txtChargedWeight1 = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
                    LinkButton link = (LinkButton)GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
                    LinkButton link1 = (LinkButton)GridBook.FooterRow.FindControl("LinkButton4") as LinkButton;
                    ddlItemName1.Visible = false;
                    txtActualWeight1.Visible = false;
                    txtChargedWeight1.Visible = false;
                    txtPack1.Visible = false;
                    link.Visible = false;
                    link1.Visible = false;
                    ViewState["NewGrid"] = dtLoadIt;
                    //string Branch = Components.DTO.LoginDTO.BranchName;
                    DataTable dtItem = BDBL.ItemName_Load(Branch);
                    ddlItemName.DataSource = dtItem;
                    ddlItemName.DataValueField = "ID";
                    ddlItemName.DataTextField = "ItemName";
                    ddlItemName.DataBind();
                    ddlItemName.Items.Insert(0, "---SELECT---");
                    ddlItemName.SelectedIndex = ddlItemName.Items.IndexOf(ddlItemName.Items.FindByText(dtItem.Rows[0]["ItemName"].ToString()));
                }
                btnSave.Text = "Update";

            }
            else
            {
                Clear();
                AutoGenLoad();

            }
        }
    }
    #endregion

    #region GetConsignorName
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetConsignorName(string prefixText)
    {
        string Branch = Components.DTO.LoginDTO.BranchName;
        //string Branch = HttpContext.Current.Session["Branch"].ToString();
        string sql = "Select Name from " + Branch + " .dbo.AddressBook Where Name like @prefixText and BranchName='" + Branch + "' AND Active='True' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
        da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Name"].ToString(), i);
            i++;
        }
        return items;
    }
    #endregion

    #region GetConsigneeName
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetConsigneeName(string prefixText)
    {
        string Branch = Components.DTO.LoginDTO.BranchName;
        //string Branch = HttpContext.Current.Session["Branch"].ToString();
        string sql = "Select Name from " + Branch + " .dbo.AddressBook Where Name like @prefixText and BranchName='" + Branch + "' AND Active='True' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
        da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Name"].ToString(), i);
            i++;
        }
        return items;
    }
    #endregion

    #region GetAgentName
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetAgentName(string prefixText)
    {
        //string Branch = HttpContext.Current.Session["Branch"].ToString();
        string Branch = Components.DTO.LoginDTO.BranchName;
        string sql = "Select Name from " + Branch + " .dbo.AddressBook Where Name like @prefixText and BranchName='" + Branch + "' AND Active='True' ";
        
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
        da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Name"].ToString(), i);
            i++;
        }
        return items;
    }
    #endregion


    #region GetToBranchname
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetToBranchname(string prefixText)
        {
        //string Branch = HttpContext.Current.Session["Branch"].ToString();
        string Branch = "chennai";
        string sql = "Select Branch from " + Branch + " .dbo.Branches Where Branch like @prefixText and  Active='True' ";
        
       // string sql = "Select Branch from dbo.Branches Where Name like @prefixText and  Active='True' ";

        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
        da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Branch"].ToString(), i);
            i++;
        }
        return items;
    }
    #endregion

    #region StoreNo_SelectedIndexChanged
    protected void StoreNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Store = StoreNo.SelectedItem.Text;
        string Branch = Components.DTO.LoginDTO.BranchName;
        dtBook = BDBL.BookDetails_StoreNo_View(Store,Branch);
        if (dtBook.Rows.Count > 0 && dtBook != null)
        {
            hidStoreID.Value = dtBook.Rows[0]["ID"].ToString();
            AgentName.Focus();
        }
    }
    #endregion

    #region ItemName_Load
    public void ItemName_Load()
    {
        DataTable dtItem = new DataTable();
        DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
        string Branch = Components.DTO.LoginDTO.BranchName;
        dtItem = BDBL.ItemName_Load(Branch);
        if (dtItem.Rows.Count > 0 && dtItem != null)
        {
            ddlItemName1.DataSource = dtItem;
            ddlItemName1.DataTextField = "ItemName";
            ddlItemName1.DataValueField = "ID";
            ddlItemName1.DataBind();
            ddlItemName1.Items.Insert(0, "---SELECT---");
        }
    }
    #endregion

    #region ItemName_Load_Edit
    public void ItemName_Load_Edit()
    {
        int RowIndex = (int)ViewState["RowNo"];
        DataTable dt = (DataTable)ViewState["NewGrid"];
        DataTable dtItem = new DataTable();
        DropDownList ddlItemName1 = GridBook.Rows[RowIndex].FindControl("ddlItemName") as DropDownList;
        string Branch = Components.DTO.LoginDTO.BranchName;
        dtItem = BDBL.ItemName_Load(Branch);
        if (dtItem.Rows.Count > 0 && dtItem != null)
        {
            ddlItemName1.DataSource = dtItem;
            ddlItemName1.DataTextField = "ItemName";
            ddlItemName1.DataValueField = "ID";
            ddlItemName1.DataBind();
            ddlItemName1.Items.Insert(0, "---SELECT---");
            ddlItemName1.SelectedIndex = ddlItemName1.Items.IndexOf(ddlItemName1.Items.FindByText(dt.Rows[RowIndex]["ItemName"].ToString()));
        }
    }
    #endregion

    //#region ddlItemName1 Changed
    //protected void ddlItemName1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList ddlItemName1 = GridBook.FooterRow.FindControl("ddlItemName1") as DropDownList;
    //    TextBox txtRate = GridBook.FooterRow.FindControl("txtRate1") as TextBox;
    //    TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
    //    TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
    //    string Item = ddlItemName1.SelectedItem.Text;
    //    string Branch = Components.DTO.LoginDTO.BranchName;
    //    dtBook = BDBL.Rate_Load(Item,Branch);
    //    if (dtBook != null && dtBook.Rows.Count > 0)
    //    {

    //        txtRate.Text = dtBook.Rows[0]["Rate"].ToString();
    //        decimal Rate = 0, Total = 0, ChargedWeight = 0;
    //        Rate = decimal.Parse(txtRate.Text);
    //        ChargedWeight = GlbFunc.ConvertStrToDecimal(txtChargedWeight.Text);
    //        Total = ChargedWeight * Rate;
    //        txtTotal.Text = string.Format("{0:0}", Total);
    //        ddlItemName1.Focus();

    //    }
    //    //DataTable dt2 = new DataTable();
    //    //dt2 = (DataTable)ViewState["CreateTable"];
    //    //if (dt2.Rows.Count == 0)
    //    //{
    //    //    Grid_Row(GridBook);
    //    //}
    //}
    //#endregion

    //#region ddlItemName Changed
    //protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int RowIndex = (int)ViewState["RowNo"];

    //    DropDownList ddlItemName1 = GridBook.Rows[RowIndex].FindControl("ddlItemName") as DropDownList;
    //    TextBox txtRate = GridBook.Rows[RowIndex].FindControl("txtRate") as TextBox;
    //    TextBox txtTotal = GridBook.Rows[RowIndex].FindControl("txtTotal") as TextBox;
    //    TextBox txtChargedWeight = GridBook.Rows[RowIndex].FindControl("txtChargedWeight") as TextBox;
    //    string Item = ddlItemName1.SelectedItem.Text;
    //    string Branch = Components.DTO.LoginDTO.BranchName;
    //    dtBook = BDBL.Rate_Load(Item,Branch);
    //    if (dtBook != null && dtBook.Rows.Count > 0)
    //    {

    //        txtRate.Text = dtBook.Rows[0]["Rate"].ToString();
    //        decimal Rate, Total, ChargedWeight;
    //        Rate = decimal.Parse(txtRate.Text);
    //        ChargedWeight = GlbFunc.ConvertStrToDecimal(txtChargedWeight.Text);
    //        Total = ChargedWeight * Rate;
    //        txtTotal.Text = string.Format("{0:0}", Total);
    //        ddlItemName1.Focus();
    //    }
    //    //DataTable dt2 = new DataTable();
    //    //dt2 = (DataTable)ViewState["CreateTable"];
    //    //if (dt2.Rows.Count == 0)
    //    //{
    //    //    Grid_Row(GridBook);
    //    //}
    //}
    //#endregion

    #region ddlPackings1_SelectedIndexChanged
    protected void ddlPackings1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string consigne = Consignor.Text;
        DropDownList ddlPackings = GridBook.FooterRow.FindControl("ddlPackings1") as DropDownList;
        TextBox txtrate1 = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
        TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
        string packings=ddlPackings.SelectedItem.Text;
        string Branch = Components.DTO.LoginDTO.BranchName;
        if (Consignor.Text!=string.Empty && ddlPackings.SelectedItem.Text != "--SELECT--")
        {
            DataTable dtrate = BDBL.GridRateLoad(consigne, packings, Branch);
            if (dtrate != null && dtrate.Rows.Count > 0)
            {
                txtrate1.Text = dtrate.Rows[0]["Weight"].ToString();
                ddlPackings.Focus();
            }
            else
            {
                lblResult.Visible = true;
                lblResult.Text = "";
                lblResult.Text = "Record not available";
                ddlPackings.Focus();
            }
        }
        else
        {
            lblResult.Visible = true;
            lblResult.Text = "";
            lblResult.Text = "Please enter the consignor Name";
            DataTable dtgr = (DataTable)ViewState["NewGrid"];
            GridBook.DataSource = null;
            GridBook.DataBind();
            GridShow();
        }
    }
    #endregion

    #region ddlPackings_SelectedIndexChanged
    protected void ddlPackings_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = (int)ViewState["RowNo"];
        string consigne = Consignor.Text;
        DropDownList ddlPackings = GridBook.Rows[RowIndex].FindControl("ddlPackings") as DropDownList;
        TextBox txtrate1 = GridBook.Rows[RowIndex].FindControl("txtrate") as TextBox;
        TextBox txtActualWeight1 = GridBook.Rows[RowIndex].FindControl("txtActualWeight") as TextBox;
        string packings = ddlPackings.SelectedItem.Text;
        string Branch = Components.DTO.LoginDTO.BranchName;
        if (Consignor.Text != string.Empty && ddlPackings.SelectedItem.Text != "--SELECT--")
        {
            DataTable dtrate = BDBL.GridRateLoad(consigne, packings, Branch);
            if (dtrate != null && dtrate.Rows.Count > 0)
            {
                txtrate1.Text = dtrate.Rows[0]["Weight"].ToString();
                txtActualWeight1.Focus();
            }
        }
        else
        {

        }
    }
    #endregion


    #region txtrate1_TextChanged
    protected void txtrate1_TextChanged(object sender, EventArgs e)
    {
        TextBox txtActualWeight1 = GridBook.FooterRow.FindControl("txtActualWeight1") as TextBox;
        TextBox txtrate1 = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
        
        TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
        TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
        //string rate = ddlrate1.SelectedItem.Text;
        //string Chargedweight = txtChargedWeight.Text;
        if (txtrate1.Text != "" && txtChargedWeight.Text != "")
        {
            decimal Rate = 0, Total = 0, ChargedWeight = 0;
            Rate = decimal.Parse(txtrate1.Text);
            ChargedWeight = GlbFunc.ConvertStrToDecimal(txtChargedWeight.Text);
            Total = ChargedWeight * Rate;
            txtTotal.Text = string.Format("{0:0}", Total);
        }
        else
        {
            txtActualWeight1.Focus();
        }
    }
    #endregion

    #region txtrate_TextChanged
    protected void txtrate_TextChanged(object sender, EventArgs e)
    {
        int RowIndex = (int)ViewState["RowNo"];

        TextBox txtActualWeight1 = GridBook.Rows[RowIndex].FindControl("txtActualWeight") as TextBox;
        TextBox txtrate = GridBook.Rows[RowIndex].FindControl("txtrate") as TextBox;
        DropDownList ddlrate1 = GridBook.Rows[RowIndex].FindControl("ddlrate") as DropDownList;
        TextBox txtTotal = GridBook.Rows[RowIndex].FindControl("txtTotal") as TextBox;
        TextBox txtChargedWeight = GridBook.Rows[RowIndex].FindControl("txtChargedWeight") as TextBox;
        if (txtrate.Text != "" && txtChargedWeight.Text != "")
        {
            decimal Rate = 0, Total = 0, ChargedWeight = 0;
            Rate = decimal.Parse(txtrate.Text);
            ChargedWeight = GlbFunc.ConvertStrToDecimal(txtChargedWeight.Text);
            Total = ChargedWeight * Rate;
            txtTotal.Text = string.Format("{0:0}", Total);
        }
        else
        {
            txtActualWeight1.Focus();
        }
    }
    #endregion

    #region txtActualWeight1_TextChanged
    protected void txtActualWeight1_TextChanged(object sender, EventArgs e)
    {
        TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
        txtChargedWeight.Focus();
       
    }
    #endregion


    #region txtChargedWeight1 Text Changed
    protected void txtChargedWeight1_TextChanged(object sender, EventArgs e)
    {
        decimal Rate, Total, ChargedWeight;
      
        TextBox txtrate1 = GridBook.FooterRow.FindControl("txtrate1") as TextBox;
        TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal1") as TextBox;
        TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight1") as TextBox;
        LinkButton lkbtn = GridBook.FooterRow.FindControl("LinkButton3") as LinkButton;
        if (txtrate1.Text != "" && txtChargedWeight.Text != "")
        {
            Rate = decimal.Parse(txtrate1.Text);
            ChargedWeight = decimal.Parse(txtChargedWeight.Text);
            Total = ChargedWeight * Rate;
            txtTotal.Text = string.Format("{0:0}", Total);
        }
        lkbtn.Focus();

    }
    #endregion

    #region txtChargedWeight Text Changed
    protected void txtChargedWeight_TextChanged(object sender, EventArgs e)
    {
        int RowNo = (int)ViewState["RowNo"];
        GridViewRow row = GridBook.Rows[RowNo];
        decimal Rate, Total, ChargedWeight;
        DropDownList ddlrate1 =row.FindControl("ddlrate") as DropDownList;
        TextBox txtRate = row.FindControl("txtrate") as TextBox;
        TextBox txtTotal = row.FindControl("txtTotal") as TextBox;
        TextBox txtChargedWeight = row.FindControl("txtChargedWeight") as TextBox;
        LinkButton lkbtn = row.FindControl("LinkButton1") as LinkButton;
        if (txtRate.Text != "" && txtChargedWeight.Text != "")
        {
            Rate = GlbFunc.ConvertStrToDecimal(txtRate.Text);
            ChargedWeight = decimal.Parse(txtChargedWeight.Text);
            Total = ChargedWeight * Rate;
            txtTotal.Text = string.Format("{0:0}", Total);
        }

        lkbtn.Focus();
    }
    #endregion

    //#region Rate_Footer_Textchanged
    //protected void txtRate_footer_OnTextChanged(object sender, EventArgs e)
    //{
    //    txtRate_Load();
    //}
    //#endregion

    //#region txtRate_Footer
    //public void txtRate_Load()
    //{
    //    TextBox txtChargedWeight = GridBook.FooterRow.FindControl("txtChargedWeight") as TextBox;
    //    TextBox txtRate = GridBook.FooterRow.FindControl("txtRate") as TextBox;
    //    TextBox txtTotal = GridBook.FooterRow.FindControl("txtTotal") as TextBox;

    //    decimal a, b, c;
    //    a = Decimal.Parse(txtChargedWeight.Text.Trim());
    //    b = Decimal.Parse(txtRate.Text.Trim());
    //    c = a * b;
    //    txtTotal.Text = c.ToString();
    //}
    //#endregion

    protected void ChFixed_CheckedChanged(object sender, EventArgs e)
    {
        if (ChFixed.Checked == true)
        {
            lblpaidamount.Visible = false;
            txtpaidamount.Visible = false;                   
        }
        else
        {
            lblpaidamount.Visible = true;
            txtpaidamount.Visible = true;
        }
        GridShow();
    }

    protected void txtpaidamount_TextChanged(object sender, EventArgs e)
   {
        decimal total =Convert.ToDecimal(Total.Text);
        decimal paidamount = Convert.ToDecimal(txtpaidamount.Text);
        if (txtpaidamount.Text != "" && Total.Text != "")
        {
            decimal bal = total - paidamount;
            txtbalanceamount.Text = string.Format("{0:0}", bal);//Convert.ToString( bal);
        }

    }
}

