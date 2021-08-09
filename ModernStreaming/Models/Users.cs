using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModernStreaming.Models
{
    public class Users
    {

        #region Properties
        public string Id { get; set; }
        [Display(Name = "User Type")]
        [Required(ErrorMessage = "Select User Type")]
        public string user_utype_id { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter Username")]
        public string user_name { get; set; }
           
        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please enter valid 10 digit Mobile Number.")]
        [Required(ErrorMessage = "Please enter valid 10 digit Mobile Number.")]
        public string user_mobile { get; set; }

            
        [Display(Name = "DOB")]
        [Required(ErrorMessage = "Select DOB")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public string user_dob { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string user_email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string user_password { get; set; }

        [Display(Name = "User Status")]
        public int user_status { get; set; }
 
        public string user_edited_by { get; set; }
        public string user_type_name { get; set; }
        public string Mode { get; set; }
        public int status { get; set; }
        public string searchstr { get; set; }

        public string encryptionkey = "Tempkey";

        public List<Users> _listUsers { get; set; }
        public List<Status> _listStatus { get; set; }
        public List<SelectListItem> _DDUserType { get; set; }
  



        #endregion

        #region Functions
        public List<Users> GetUserList(Users obj)
        {
            List<Users> _list = new List<Users>();
            SqlDataReader dr = null;
            SqlParameter[] oparam = new SqlParameter[5];

            oparam[0] = new SqlParameter("@Id", obj.Id);
            oparam[1] = new SqlParameter("@user_utype_id", obj.user_utype_id);
            oparam[2] = new SqlParameter("@user_status", obj.user_status);
            oparam[3] = new SqlParameter("@Mode", obj.Mode);
            oparam[4] = new SqlParameter("@searchstr", obj.searchstr);


            try
            {
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_users_select]", oparam);
                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Users _obj = new Users();
                        _obj.Id = Convert.ToString(dr["Id"]);

                        _obj.user_utype_id = Convert.ToString(dr["user_utype_id"]);
                        _obj.user_type_name = Convert.ToString(dr["user_type_name"]);
                        if (dr["user_dob"] != DBNull.Value)
                        {
                            
                            _obj.user_dob = Convert.ToString(dr["user_dob"]);
                            DateTime dt = Convert.ToDateTime(_obj.user_dob);
                            _obj.user_dob = dt.ToString("dd-MMM-yyyy");
                        }
                        _obj.user_name = Convert.ToString(dr["user_name"]);
                        _obj.user_mobile = Convert.ToString(dr["user_mobile"]);
                        _obj.user_email = Convert.ToString(dr["user_email"]);
                        _obj.user_status = Convert.ToInt32(dr["user_status"]);
                      
                        _list.Add(_obj);
                    }
                }
                return _list;
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

        public Users GetUsers(Users obj)
        {
            List<Users> _list = new List<Users>();
            SqlDataReader dr = null;
            SqlParameter[] oparam = new SqlParameter[4];

            oparam[0] = new SqlParameter("@Id", obj.Id);
            oparam[1] = new SqlParameter("@user_utype_id", obj.user_utype_id);
            oparam[2] = new SqlParameter("@user_status", obj.user_status);
            oparam[3] = new SqlParameter("@Mode", obj.Mode);
         

            try
            {
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_users_select]", oparam);
                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Users _obj = new Users();
                        _obj.Id = Convert.ToString(dr["Id"]);

                        _obj.user_utype_id = Convert.ToString(dr["user_utype_id"]);
                        _obj.user_type_name = Convert.ToString(dr["user_type_name"]);

                        if (dr["user_dob"] != DBNull.Value)
                        {

                            _obj.user_dob = Convert.ToString(dr["user_dob"]);
                            DateTime dt = Convert.ToDateTime(_obj.user_dob);
                            _obj.user_dob = dt.ToString("dd-MMM-yyyy");
                        }
                        _obj.user_name = Convert.ToString(dr["user_name"]);
                        _obj.user_mobile = Convert.ToString(dr["user_mobile"]);
                        _obj.user_email = Convert.ToString(dr["user_email"]);
                        _obj.user_status = Convert.ToInt32(dr["user_status"]);

                        return _obj;
                    }
                }
                return null;
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

        public string InsertUpdateUsers(Users obj)
        {
            SqlParameter[] oParam = new SqlParameter[11];
            SqlDataReader dr = null;
            oParam[0] = new SqlParameter("@Id", obj.Id);
            oParam[1] = new SqlParameter("@user_utype_id", obj.user_utype_id);
            oParam[2] = new SqlParameter("@user_name", obj.user_name);
            oParam[3] = new SqlParameter("@user_mobile", obj.user_mobile);
            oParam[4] = new SqlParameter("@user_email", obj.user_email);
            oParam[5] = new SqlParameter("@user_status", obj.user_status);          
            oParam[6] = new SqlParameter("@user_login", obj.user_edited_by);
            oParam[7] = new SqlParameter("@user_password", obj.user_password);
            oParam[8] = new SqlParameter("@encryptionkey", obj.encryptionkey);
            oParam[9] = new SqlParameter("@Mode", obj.Mode);
            oParam[10] = new SqlParameter("@user_dob", obj.user_dob);


            oParam[0].Direction = ParameterDirection.InputOutput;
            oParam[0].DbType = DbType.String;
            oParam[0].Size = 256;

            try
            {
                SqlHelper.ExecuteNonQuery(
                AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_users_insert_update]", oParam);
                return oParam[0].Value.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return "";
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }

        public static List<Status> BindStatusList(Users obj)
        {
            List<Status> _listStatus = new List<Status>();
            SqlParameter[] oparam = new SqlParameter[2];
            oparam[0] = new SqlParameter("@Id", obj.Id);
            oparam[1] = new SqlParameter("@Mode", 's');

            SqlDataReader dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_users_select]", oparam);
            while (dr.Read())
            {
                Status _objStatus = new Status();
                _objStatus.status = Convert.ToInt32(dr["status"].ToString());
                _objStatus.status_name = dr["status_name"].ToString() + " (" + dr["status_count"].ToString() + ")";

                if (Convert.ToString(dr["status_count"]) == "0")
                {
                    _objStatus.status_bool = false;
                }
                else
                {
                    if (obj.user_status == 1 && _objStatus.status == 1)
                        _objStatus.status_bool = true;
                    if (obj.user_status == 2 && _objStatus.status == 2)
                        _objStatus.status_bool = true;
                }

                _listStatus.Add(_objStatus);
            }
            return _listStatus;
        }


        public static List<SelectListItem> BindUserDropDownList(Users obj)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            SqlParameter[] oparam = new SqlParameter[1];
           
            oparam[0] = new SqlParameter("@user_status", obj.user_status);
          
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_users_select]", oparam);
                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        items.Add(new SelectListItem { Text = Convert.ToString(dr["user_name"]), Value = Convert.ToString(dr["Id"]) });
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