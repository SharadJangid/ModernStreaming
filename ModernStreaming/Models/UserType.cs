using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModernStreaming.Models
{
    public class UserType
    {
        #region Properties
        public string Id { get; set; }
        public string user_type_id { get; set; }
       
        public string user_type_name { get; set; }
        #endregion


        #region Function
   
        public static List<SelectListItem> BindUserTypeList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            SqlDataReader dr = null;

            try
            {
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_user_type_select]");
                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        items.Add(new SelectListItem { Text = Convert.ToString(dr["user_type_name"]), Value = Convert.ToString(dr["Id"]) });
                    }
                }
                return items;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

        }

        #endregion
    }
}