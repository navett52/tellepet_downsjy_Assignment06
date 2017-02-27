/* Hello from Bill */

using ds_TransTypeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ds_LoyaltyDropdownTableAdapters;

public partial class _Default : System.Web.UI.Page {
    //Making the objects that interact with the DB
    private static System.Data.SqlClient.SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;

    /// <summary>
    /// Populate the dropdown and populate the available enchantments for the first dropdown item on the page load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            openConnection();

            //Populating the Transaction Type drop down using the databse.
            tTransactionTypeTableAdapter transTypeAdapter = new tTransactionTypeTableAdapter();
            ds_TransType.tTransactionTypeDataTable transTypes = transTypeAdapter.GetData();
            ddTransType.DataTextField = "TransactionType";
            ddTransType.DataValueField = "TransactionTypeID";
            ddTransType.DataSource = transTypes;
            ddTransType.DataBind();

            //Populating Loyalty Numbers to drop down using data set
            tLoyaltyTableAdapter loyaltyAdapter = new tLoyaltyTableAdapter();
            ds_LoyaltyDropdown.tLoyaltyDataTable loyaltyNumber = loyaltyAdapter.GetData();
            ddLoyaltyNumbers.DataTextField = "LoyaltyNumber";
            ddLoyaltyNumbers.DataValueField = "LoyaltyID";
            ddLoyaltyNumbers.DataSource = loyaltyNumber;
            ddLoyaltyNumbers.DataBind();
        }
    }



    /// <summary>
    /// Opening the database connection
    /// </summary>
    public void openConnection() {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString();
        // Console.WriteLine(strConn.ConnectionString);

        conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);

        // This could go wrong in so many ways...
        try {
            conn.Open();
        } catch (Exception ex) {
            // Miserable error handling...
            Console.WriteLine(ex.Message);
        }
    }

    /** Read the connection string from the web.config file. 
      * This is a much more secure way to store sensitive information. Don't hard-code connection information in the source code.
      * Adapted from http://msdn.microsoft.com/en-us/library/ms178411.aspx
      */
    private System.Configuration.ConnectionStringSettings ReadConnectionString() {
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0) {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulatorPopulator"];
        }
        return connString;
    }

    protected void btnSubmit_Click(object sender, EventArgs e) {
        Regex checktime = new Regex(@"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$"); //Ref: http://stackoverflow.com/questions/884848/regular-expression-to-validate-valid-time
        if (!checktime.IsMatch(txtTimeOfTrans.Text)) {
            Response.Write("The time entered is not in the correct format!");
        } //test commenting stuffffffffffffffff
    }
}
