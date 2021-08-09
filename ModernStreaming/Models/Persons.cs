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
    public class Persons
    {

        #region Properties

        public string Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter person first name")]
        public string person_first_name { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter person last name")]
        public string person_last_name { get; set; }
        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please enter valid 10 digit Mobile Number.")]
        [Required(ErrorMessage = "Please enter valid 10 digit Mobile Number.")]
        public string person_mobile_number { get; set; }

        [Display(Name = "DOB")]
        [Required(ErrorMessage = "Select DOB")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public string person_dob { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Select Gender")]
        public int person_gender { get; set; }

        public string person_gender_name { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string person_address { get; set; }

        [Required(ErrorMessage = "Enter Pincode")]
        public string person_pincode { get; set; }

        [Display(Name = "Email address")]        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string person_email { get; set; }

        [Display(Name = "No. of direct_dependents")]
        [Required(ErrorMessage = "Enter no of direct_dependents")]
        public int? person_no_of_direct_dependents { get; set; }

        [Display(Name = "Pan Card No.")]
        [Required(ErrorMessage = "Enter Pan Card no.")]
        public string person_pan_card_no { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Please enter valid 12 digit Aadhaar Number.")]
        [Display(Name = "Aadhar Card No.")]
        [Required(ErrorMessage = "Enter AadharCard no.")]
        public string person_aadhaar_card_no { get; set; }

        [Display(Name = "Union Membership")]
        [Required(ErrorMessage = "Enter Union Membership")]
        public string person_union_membership { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Enter Bank Name")]
        public string person_bank_name { get; set; }

        [Display(Name = "Account No.")]
        [Required(ErrorMessage = "Enter Bank Account No.")]
        public string person_bank_account_no { get; set; }

        [Display(Name = "IFSC Code")]
        [Required(ErrorMessage = "Enter IFSC Code")]
        public string person_ifsc_code { get; set; }

        [Display(Name = "User Status")]
        public int person_status { get; set; }

        public string person_edited_by { get; set; }
        public string Mode { get; set; }
        public int status { get; set; }
        public string searchstr { get; set; }

        public List<Persons> _listPersons { get; set; }
        public List<Status> _listStatus { get; set; }
        public List<SelectListItem> _DDGenderType { get; set; }

        #endregion

        #region Functions
        public List<Persons> GetPersonList(Persons obj)
        {
            List<Persons> _list = new List<Persons>();
            SqlDataReader dr = null;
            SqlParameter[] oparam = new SqlParameter[5];

            oparam[0] = new SqlParameter("@Id", obj.Id);
            oparam[1] = new SqlParameter("@person_gender", obj.person_gender);
            oparam[2] = new SqlParameter("@person_status", obj.person_status);
            oparam[3] = new SqlParameter("@Mode", obj.Mode);
            oparam[4] = new SqlParameter("@searchstr", obj.searchstr);


            try
            {
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_person_select]", oparam);
                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Persons _obj = new Persons();
                        _obj.Id = Convert.ToString(dr["Id"]);
                        _obj.person_first_name = Convert.ToString(dr["person_first_name"]);
                        _obj.person_last_name = Convert.ToString(dr["person_last_name"]);
                        _obj.person_mobile_number = Convert.ToString(dr["person_mobile_number"]);

                        if (dr["person_dob"] != DBNull.Value)
                        {

                            _obj.person_dob = Convert.ToString(dr["person_dob"]);
                            DateTime dt = Convert.ToDateTime(_obj.person_dob);
                            _obj.person_dob = dt.ToString("dd-MMM-yyyy");
                        }

                        _obj.person_gender_name = Convert.ToString(dr["gender_name"]);
                        _obj.person_gender = Convert.ToInt32(dr["person_gender"]);
                        _obj.person_address = Convert.ToString(dr["person_address"]);
                        _obj.person_pincode = Convert.ToString(dr["person_pincode"]);
                        _obj.person_email = Convert.ToString(dr["person_email"]);
                        if (dr["person_no_of_direct_dependents"] != DBNull.Value)
                        {

                            _obj.person_no_of_direct_dependents = Convert.ToInt32(dr["person_no_of_direct_dependents"]);
                        }
                        _obj.person_pan_card_no = Convert.ToString(dr["person_pan_card_no"]);
                        _obj.person_aadhaar_card_no = Convert.ToString(dr["person_aadhaar_card_no"]);
                        _obj.person_union_membership = Convert.ToString(dr["person_union_membership"]);
                        _obj.person_bank_name = Convert.ToString(dr["person_bank_name"]);
                        _obj.person_bank_account_no = Convert.ToString(dr["person_bank_account_no"]);
                        _obj.person_ifsc_code = Convert.ToString(dr["person_ifsc_code"]);
                        _obj.person_status = Convert.ToInt32(dr["person_status"]);


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

        public Persons GetPersons(Persons obj)
        {
            List<Persons> _list = new List<Persons>();
            SqlDataReader dr = null;
            SqlParameter[] oparam = new SqlParameter[3];

            oparam[0] = new SqlParameter("@Id", obj.Id);
            oparam[1] = new SqlParameter("@person_status", obj.person_status);
            oparam[2] = new SqlParameter("@Mode", obj.Mode);


            try
            {
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_person_select]", oparam);
                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Persons _obj = new Persons();
                        _obj.Id = Convert.ToString(dr["Id"]);
                        _obj.person_first_name = Convert.ToString(dr["person_first_name"]);
                        _obj.person_last_name = Convert.ToString(dr["person_last_name"]);
                        _obj.person_mobile_number = Convert.ToString(dr["person_mobile_number"]);

                        if (dr["person_dob"] != DBNull.Value)
                        {

                            _obj.person_dob = Convert.ToString(dr["person_dob"]);
                            DateTime dt = Convert.ToDateTime(_obj.person_dob);
                            _obj.person_dob = dt.ToString("dd-MMM-yyyy");
                        }

                        _obj.person_gender_name = Convert.ToString(dr["gender_name"]);
                        _obj.person_gender = Convert.ToInt32(dr["person_gender"]);
                        _obj.person_address = Convert.ToString(dr["person_address"]);
                        _obj.person_pincode = Convert.ToString(dr["person_pincode"]);
                        _obj.person_email = Convert.ToString(dr["person_email"]);
                        if (dr["person_no_of_direct_dependents"] != DBNull.Value)
                        {

                            _obj.person_no_of_direct_dependents = Convert.ToInt32(dr["person_no_of_direct_dependents"]);
                        }
                        _obj.person_pan_card_no = Convert.ToString(dr["person_pan_card_no"]);
                        _obj.person_aadhaar_card_no = Convert.ToString(dr["person_aadhaar_card_no"]);
                        _obj.person_union_membership = Convert.ToString(dr["person_union_membership"]);
                        _obj.person_bank_name = Convert.ToString(dr["person_bank_name"]);
                        _obj.person_bank_account_no = Convert.ToString(dr["person_bank_account_no"]);
                        _obj.person_ifsc_code = Convert.ToString(dr["person_ifsc_code"]);
                        _obj.person_status = Convert.ToInt32(dr["person_status"]);


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

        public string InsertUpdatePersons(Persons obj)
        {

            SqlParameter[] oParam = new SqlParameter[19];
            SqlDataReader dr = null;
            oParam[0] = new SqlParameter("@Id", obj.Id);
            oParam[1] = new SqlParameter("@person_first_name", obj.person_first_name);
            oParam[2] = new SqlParameter("@person_last_name", obj.person_last_name);
            oParam[3] = new SqlParameter("@person_mobile_number", obj.person_mobile_number);
            oParam[4] = new SqlParameter("@person_dob", obj.person_dob);
            oParam[5] = new SqlParameter("@person_gender", obj.person_gender);
            oParam[6] = new SqlParameter("@person_address", obj.person_address);
            oParam[7] = new SqlParameter("@person_pincode", obj.person_pincode);
            oParam[8] = new SqlParameter("@person_email", obj.person_email);
            oParam[9] = new SqlParameter("@person_no_of_direct_dependents", obj.person_no_of_direct_dependents);
            oParam[10] = new SqlParameter("@person_pan_card_no", obj.person_pan_card_no);
            oParam[11] = new SqlParameter("@person_aadhaar_card_no", obj.person_aadhaar_card_no);
            oParam[12] = new SqlParameter("@person_union_membership", obj.person_union_membership);
            oParam[13] = new SqlParameter("@person_bank_name", obj.person_bank_name);
            oParam[14] = new SqlParameter("@person_bank_account_no", obj.person_bank_account_no);
            oParam[15] = new SqlParameter("@person_ifsc_code", obj.person_ifsc_code);
            oParam[16] = new SqlParameter("@person_status", obj.person_status);
            oParam[17] = new SqlParameter("@user_login", obj.person_edited_by);
            oParam[18] = new SqlParameter("@Mode", obj.Mode);


            oParam[0].Direction = ParameterDirection.InputOutput;
            oParam[0].DbType = DbType.String;
            oParam[0].Size = 256;

            try
            {
                SqlHelper.ExecuteNonQuery(
                AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_person_insert_update]", oParam);
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

        public static List<Status> BindStatusList(Persons obj)
        {
            List<Status> _listStatus = new List<Status>();
            SqlParameter[] oparam = new SqlParameter[2];
            oparam[0] = new SqlParameter("@Id", obj.Id);
            oparam[1] = new SqlParameter("@Mode", 's');

            SqlDataReader dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_person_select]", oparam);
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
                    if (obj.person_status == 1 && _objStatus.status == 1)
                        _objStatus.status_bool = true;
                    if (obj.person_status == 2 && _objStatus.status == 2)
                        _objStatus.status_bool = true;
                }

                _listStatus.Add(_objStatus);
            }
            return _listStatus;
        }


        public static List<SelectListItem> BindGenderList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            SqlDataReader dr = null;

            try
            {
                dr = SqlHelper.ExecuteReader(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[yfcp_gender_select]");
                if (dr != null & dr.HasRows)
                {
                    while (dr.Read())
                    {
                        items.Add(new SelectListItem { Text = Convert.ToString(dr["gender_name"]), Value = Convert.ToString(dr["Id"]) });
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