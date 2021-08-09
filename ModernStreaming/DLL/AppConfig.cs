using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for AppConfig
/// </summary>
/// 

    public class AppConfig
    {
        public AppConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Get Connection String Value

        /*Sub Header***********************************************************
       Function Name: GetConnectionString

        Functionality: Return the Connection string value from web.config file
        Input: 
        Output: Connection string value
        Note: Any Special comment
        *********************************************************************/
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["yfc_ConnectionString"].ConnectionString.ToString();
        }


        #endregion
        /*Sub Header***********************************************************
        Function Name: GetSMTPserver
        Functionality: This function will return SMTP server.
        Input:
        Output: string
        Note: Any Special comment
        *********************************************************************/
        public static string GetSMTPserver()
        {
            return ConfigurationManager.AppSettings["SmtpClient"].ToString();
        }


    }
