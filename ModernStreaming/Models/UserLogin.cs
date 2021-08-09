using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
namespace ModernStreaming.Models
{
    public class UserLogin:Users
    {

        #region Properties
        public string login_msg { get; set; }

        public static bool IsUserSessionExpired()
        {
            bool session_expire = true;
            if (HttpContext.Current.Session[SessionVariables.Id] != null)
            {
                session_expire = false;
            }
            return session_expire;
        }
        #endregion

        public void Authenticate_AdminUser(ref List<UserLogin> _AdminUser)
        {
            SqlDataReader dr = null;
            try
            {
                SqlParameter[] oParam = new SqlParameter[3];
                oParam[0] = new SqlParameter("@user_email", this.user_email);
                oParam[1] = new SqlParameter("@user_password", this.user_password);
                oParam[2] = new SqlParameter("@encryptionkey", "TempKey");
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "yfcp_user_login", oParam);

                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserLogin _obj = new UserLogin();

                        _obj.Id = Convert.ToString(dr["Id"]);
                        _obj.user_name = Convert.ToString(dr["user_name"]);                      
                        _obj.user_utype_id = Convert.ToString(dr["user_utype_id"]);
                        _obj.user_email = Convert.ToString(dr["user_email"]);
                        _obj.user_type_name = Convert.ToString(dr["user_type_name"]);
                       
                        _AdminUser.Add(_obj);
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (dr != null) dr.Close();
            }
        }
    }
}