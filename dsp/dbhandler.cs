using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using static dsp.structdata;

namespace dsp
{
    class dbhandler
    {
        public static string name;
        static string _databaseconnectionString = string.Empty;
        static string _logfilepath = string.Empty;
        public static string _idproof = string.Empty;
        static string _tablename = string.Empty;
        static string _database = string.Empty;
        public static string _tariff_type = string.Empty;
        public static string _extra_bed = string.Empty;
        public static string _referral = string.Empty;
        public static string _plan = string.Empty;
        public static string _kotlog = string.Empty;
        public static string _hklog = string.Empty;
        public static string _storelog = string.Empty;
        public static string _frontlog = string.Empty;
        public static string _laundry = string.Empty;
        public static string _purchase_folder = string.Empty;
        public static string _gst = string.Empty;
        public static string _night_folder = string.Empty;
        public static string _invoice_folder = string.Empty;
        public static string _date = string.Empty;
        public static string _segment = string.Empty;
        public static string _mode = string.Empty;
        static SqlConnection conn;
        //static SqlConnection conn = new SqlConnection();
        //static booking_details Temp_customer;
        public static string DatabaseConnectionString
        {
            get { return _databaseconnectionString; }

            set { _databaseconnectionString = value; }
        }
        public static string Purchase_order_folder
        {
            get { return _purchase_folder; }

            set { _purchase_folder = value; }
        }
        public static string GST
        {
            get { return _gst; }

            set { _gst = value; }
        }
        public static string Night_folder
        {
            get { return _night_folder; }

            set { _night_folder = value; }
        }
        public static string invoice_folder
        {
            get { return _invoice_folder; }

            set { _invoice_folder = value; }
        }
        public static string Kotlog
        {
            get { return _kotlog; }

            set { _kotlog = value; }
        }
        public static string Storelog
        {
            get { return _storelog; }

            set { _storelog = value; }
        }
        public static string Hklog
        {
            get { return _hklog; }

            set { _hklog = value; }
        }
        public static string Frontdesk_log
        {
            get { return _frontlog; }

            set { _frontlog = value; }
        }
        public static string plan_hotel
        {
            get { return _plan; }

            set { _plan = value; }
        }
        public static string ExtraBedCost
        {
            get { return _extra_bed; }

            set { _extra_bed = value; }
        }
        public static string TariffTypeString
        {
            get { return _tariff_type; }

            set { _tariff_type = value; }
        }
        public static string LogFilePath
        {
            get { return _logfilepath; }

            set { _logfilepath = value; }
        }
        public static string Id_proofs
        {
            get { return _idproof; }

            set { _idproof = value; }
        }
        public static string SourceOfBooking
        {
            get { return _referral; }

            set { _referral = value; }
        }
        public static string Tablename
        {
            get { return _tablename; }

            set { _tablename = value; }
        }
        public static string Database
        {
            get { return _database; }

            set { _database = value; }
        }
        public static string Laundry
        {
            get { return _laundry; }

            set { _laundry = value; }
        }
        public static string Date
        {
            get { return _date; }

            set { _date = value; }
        }
        public static string Segment
        {
            get { return _segment; }

            set { _segment = value; }
        }
        public static string Mode
        {
            get { return _mode; }

            set { _mode = value; }
        }
        public dbhandler()
        {
            configload();
            conn = new SqlConnection(_databaseconnectionString);

        }
        public void configload()
        {
            try
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "fileConfig.xml";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                DatabaseConnectionString = config.AppSettings.Settings["DBConnectionString"].Value;
                //LogFilePath = config.AppSettings.Settings["LogFilePath"].Value;
                Id_proofs = config.AppSettings.Settings["ID_Proofs"].Value;
                SourceOfBooking = config.AppSettings.Settings["Source_of_booking"].Value;
                plan_hotel = config.AppSettings.Settings["Plan"].Value;
                Kotlog = config.AppSettings.Settings["kot_log"].Value;
                Frontdesk_log = config.AppSettings.Settings["front_log"].Value;
                Hklog = config.AppSettings.Settings["hk_log"].Value;
                Storelog = config.AppSettings.Settings["store_log"].Value;
                Laundry = config.AppSettings.Settings["laundry"].Value;
                Purchase_order_folder = config.AppSettings.Settings["purchase_order"].Value;
                Night_folder = config.AppSettings.Settings["night_audit"].Value;
                invoice_folder = config.AppSettings.Settings["invoice"].Value;
                GST = config.AppSettings.Settings["gst"].Value;
                Date = config.AppSettings.Settings["date"].Value;
                Segment= config.AppSettings.Settings["segment"].Value;
                Mode = config.AppSettings.Settings["mode"].Value;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "configure");
            }
        }
        public static void datedel()
        {
            try
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "fileConfig.xml";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("date");
                config.AppSettings.Settings.Add("date", DateTime.Now.Date.ToString());
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static int user_db(String username, String password)
        {
            int value = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String usercheck = String.Format("select count(1) from [User] where user_name = @USERNAME and password = @PASS");
                    SqlCommand myCommand = new SqlCommand(usercheck, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USERNAME", username);
                    myCommand.Parameters.AddWithValue("@PASS", password);
                    value = Convert.ToInt32(myCommand.ExecuteScalar());
                    conn.Close();
                    return value;

                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return value;
        }
        public static int frontdesk_pre(String username)
        {
            int status = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String fd_pre = String.Format("select front_desk from [User] where user_name = @USERNAME");
                    SqlCommand myCommand = new SqlCommand(fd_pre, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USERNAME", username);
                    status = Convert.ToInt32(myCommand.ExecuteScalar());
                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return status;
        }
        public static int fb_pre(String username)
        {
            int status = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String fb_pre = String.Format("select f_b from [User] where user_name = @USERNAME");
                    SqlCommand myCommand = new SqlCommand(fb_pre, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USERNAME", username);
                    status = Convert.ToInt32(myCommand.ExecuteScalar());
                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return status;
        }
        public static int hk_pre(String username)
        {
            int status = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String hk_pre = String.Format("select h_k from [User] where user_name = @USERNAME");
                    SqlCommand myCommand = new SqlCommand(hk_pre, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USERNAME", username);
                    status = Convert.ToInt32(myCommand.ExecuteScalar());
                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return status;
        }
        public static int store_pre(String username)
        {
            int status = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String store_pre = String.Format("select store from [User] where user_name = @USERNAME");
                    SqlCommand myCommand = new SqlCommand(store_pre, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USERNAME", username);
                    status = Convert.ToInt32(myCommand.ExecuteScalar());
                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return status;
        }
        public static int report_pre(String username)
        {
            int status = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String report_pre = String.Format("select report from [User] where user_name = @USERNAME");
                    SqlCommand myCommand = new SqlCommand(report_pre, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USERNAME", username);
                    status = Convert.ToInt32(myCommand.ExecuteScalar());
                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return status;
        }
        public static int add_pre(String username)
        {
            int status = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String add_pre = String.Format("select add_u from [User] where user_name = @USERNAME");
                    SqlCommand myCommand = new SqlCommand(add_pre, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USERNAME", username);
                    status = Convert.ToInt32(myCommand.ExecuteScalar());
                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return status;
        }
        public static check checkifPhonenumberavailable(string code,string phone_number)
        {
            check checkByPhone = new check();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    string sqlAddUserQuery = String.Format("select * from [info1] where phone_number = @PHONENUMBER and country_code=@CC");
                    SqlCommand myCommand = new SqlCommand(sqlAddUserQuery, conn);
                    myCommand.Parameters.AddWithValue("@PHONENUMBER", phone_number);
                    myCommand.Parameters.AddWithValue("@CC", code);
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    checkByPhone.available = false;
                    while (myReader.Read())
                    {
                        checkByPhone.customer.name = ((string)myReader["name"]).TrimEnd();
                        checkByPhone.customer.phonenumber = ((string)myReader["phone_number"]).TrimEnd();
                        checkByPhone.customer.address = ((string)myReader["street_address"]).TrimEnd();
                        checkByPhone.customer.district = ((string)myReader["district"]).TrimEnd();
                        checkByPhone.customer.state = ((string)myReader["state"]).TrimEnd();
                        checkByPhone.customer.country = ((string)myReader["country"]).TrimEnd();
                        checkByPhone.customer.pincode = ((string)myReader["pincode"]).TrimEnd();
                        checkByPhone.customer.mail = ((string)myReader["mail"]).TrimEnd();
                        checkByPhone.customer.dob = ((string)myReader["dob"]).TrimEnd();
                        checkByPhone.customer.marital_status = ((string)myReader["marital_status"]).TrimEnd();
                        checkByPhone.customer.anniversary_date = ((string)myReader["anniversary_date"]).TrimEnd();
                        checkByPhone.customer.idproof = ((string)myReader["id_proof"]).TrimEnd();
                        checkByPhone.customer.id_proof_number = ((string)myReader["id_num"]).TrimEnd();
                        checkByPhone.customer.foreigner = ((string)myReader["foreigner"]).TrimEnd();
                        checkByPhone.customer.foreigner_details = ((string)myReader["foreigner_details"]).TrimEnd();
                        checkByPhone.customer.visit_count = ((string)myReader["visit_count"]).TrimEnd();
                        checkByPhone.available = true;
                    }

                    myReader.Close();

                }

            }


            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            conn.Close();
            return checkByPhone;
        }
        public static Boolean BasicInfoEntry(basic_info customer)
        {

            string sqlAddUserQuery = String.Format("INSERT INTO [info1](country_code,name,phone_number,street_address,district,state,country,pincode,mail,dob,marital_status,anniversary_date,id_proof,id_num,foreigner,foreigner_details,visit_count,cform_filled)VALUES(@CC,@NAME, @PHONENUMBER, @ADDRESS, @DISTRICT, @STATE, @COUNTRY, @PINCODE, @MAIL, @DOB, @MARITAL_STATUS, @ANNIVERSARY, @IDPROOF, @ID_NUM,  @FOREIGNER, @FOREIGNER_DETAILS,@VISIT,@CFORM)");
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sqlAddUserQuery, conn))
                    {
                        command.Parameters.AddWithValue("@CC", customer.cc);
                        command.Parameters.AddWithValue("@PHONENUMBER", customer.phonenumber);
                        command.Parameters.AddWithValue("@NAME", customer.name);
                        command.Parameters.AddWithValue("@ADDRESS", customer.address);
                        command.Parameters.AddWithValue("@DISTRICT", customer.district);
                        command.Parameters.AddWithValue("@STATE", customer.state);
                        command.Parameters.AddWithValue("@COUNTRY", customer.country);
                        command.Parameters.AddWithValue("@PINCODE", customer.pincode);
                        command.Parameters.AddWithValue("@MAIL", customer.mail);
                        command.Parameters.AddWithValue("@IDPROOF", customer.idproof);
                        command.Parameters.AddWithValue("@ID_NUM", customer.id_proof_number);
                        command.Parameters.AddWithValue("@DOB", customer.dob);
                        command.Parameters.AddWithValue("@MARITAL_STATUS", customer.marital_status);
                        command.Parameters.AddWithValue("@ANNIVERSARY", customer.anniversary_date);
                        command.Parameters.AddWithValue("@FOREIGNER", customer.foreigner);
                        command.Parameters.AddWithValue("@FOREIGNER_DETAILS", customer.foreigner_details);
                        command.Parameters.AddWithValue("@VISIT", customer.visit_count);
                        command.Parameters.AddWithValue("@CFORM", customer.cform_fill);
                        command.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            return false;
        }
        public static check_in_check check1(string cc, String phone_number)
        {
            check_in_check checkbyph = new check_in_check();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    string sqlAddUserQuery = String.Format("select * from [checkin] where phonenumber = @PHONENUMBER and country_code= @CC");
                    SqlCommand myCommand = new SqlCommand(sqlAddUserQuery, conn);
                    myCommand.Parameters.AddWithValue("@PHONENUMBER", phone_number);
                    myCommand.Parameters.AddWithValue("@CC", cc);
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    checkbyph.available = false;
                    while (myReader.Read())
                    {
                        checkbyph.customer.checkin_date = ((string)myReader["checkin_date"]).TrimEnd();
                        checkbyph.customer.phonenumber = ((string)myReader["phonenumber"]).TrimEnd();
                        checkbyph.customer.checkin_time = ((string)myReader["checkin_time"]).TrimEnd();
                        checkbyph.customer.hotel_name = ((string)myReader["hotel_name"]).TrimEnd();
                        checkbyph.customer.room_no = ((string)myReader["room_no"]).TrimEnd();
                        checkbyph.customer.no_of_persons = ((string)myReader["person_count"]).TrimEnd();
                        checkbyph.customer.room_amt = ((string)myReader["room_amt"]).TrimEnd();
                        checkbyph.available = true;
                    }
                }
            }
            catch (Exception e)
            {

            }
            conn.Close();
            return checkbyph;
        }
        public static Boolean Checkin(check_in_struct customer)
        {
            string sqlCheckinQuery = String.Format("INSERT INTO [checkin](phonenumber,checkin_date,checkin_time,checkin_out_date,checkin_out_time,referral,hotel_name,room_type,room_no,p_plan,person_count,kot_amount,advance_paid,room_amt,post_charges,discount,transaction_no,invoice,checkout,nc_kot,room_group,advance_used,total_amount)VALUES(@PHONENUMBER, @CHECKIN_DATE, @CHECKIN_TIME, @CHECKIN_OUT_DATE, @CHECKIN_OUT_TIME, @REFERRAL,@HOTEL_NAME, @ROOM_TYPE,@ROOM_NO, @PLAN, @PERSON_COUNT, @KOT_AMOUNT, @ADVANCE_PAID, @ROOMAMT,@P_CHARGE,@DISCOUNT,@TRANSACTION,@INVOICE,@CHECKOUT,@NCKOT,@ROOMGRP,@AUSED,@TT)");
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sqlCheckinQuery, conn))
                    {
                        command.Parameters.AddWithValue("@PHONENUMBER", customer.phonenumber);
                        command.Parameters.AddWithValue("@CHECKIN_DATE", customer.checkin_date);
                        command.Parameters.AddWithValue("@CHECKIN_TIME", customer.checkin_time);
                        command.Parameters.AddWithValue("@CHECKIN_OUT_DATE", customer.checkout_date);
                        command.Parameters.AddWithValue("@CHECKIN_OUT_TIME", customer.checkout_time);
                        command.Parameters.AddWithValue("@REFERRAL", customer.referral);
                        command.Parameters.AddWithValue("@HOTEL_NAME", customer.hotel_name);
                        command.Parameters.AddWithValue("@ROOM_TYPE", customer.room_type);
                        command.Parameters.AddWithValue("@ROOM_NO", customer.room_no);
                        command.Parameters.AddWithValue("@PLAN", customer.plan);
                        command.Parameters.AddWithValue("@PERSON_COUNT", customer.no_of_persons);
                        command.Parameters.AddWithValue("@KOT_AMOUNT", customer.kot_amount);
                        command.Parameters.AddWithValue("@ADVANCE_PAID", customer.advance_paid);
                        command.Parameters.AddWithValue("@ROOMAMT", customer.room_amt);
                        command.Parameters.AddWithValue("@CHECKOUT", customer.check_out);
                        command.Parameters.AddWithValue("@P_CHARGE", customer.post_charges);
                        command.Parameters.AddWithValue("@DISCOUNT", customer.discount);
                        command.Parameters.AddWithValue("@TRANSACTION", customer.transaction);
                        command.Parameters.AddWithValue("@INVOICE", customer.Invoice_number);
                        command.Parameters.AddWithValue("@NCKOT", customer.nc_kot_count);
                        command.Parameters.AddWithValue("@ROOMGRP", customer.room_group);
                        command.Parameters.AddWithValue("@AUSED", customer.advance_used);
                        command.Parameters.AddWithValue("@TT", customer.total_amt);
                        command.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        public static void visit_count(String visit_c, String phonenumber)
        {
            String visit_query = String.Format("update [info1] set visit_count=@VISIT_COUNT where phone_number=@PHONE");
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand mycommand = new SqlCommand(visit_query, conn))
                    {
                        mycommand.Parameters.AddWithValue("@VISIT_COUNT", visit_c);
                        mycommand.Parameters.AddWithValue("@PHONE", phonenumber);
                        mycommand.ExecuteNonQuery();
                        conn.Close();
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static DataTable inventory_table()
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select * from [inventory]", conn);
                    conn.Close();
                    ada.Fill(dt);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dt;
        }
        public static DataTable split_room(String phnumber)
        {

            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select * from [checkin] where phonenumber='" + phnumber + "'and checkout='0'", conn);

                    ada.Fill(dt);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            conn.Close();
            return dt;
        }
        public static check_in_check checkout_check(String phone_number)
        {

            check_in_check checkbyph = new check_in_check();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    string sqlAddUserQuery = String.Format("select * from [checkin] where phonenumber = @PHONENUMBER AND checkout=@COUT");
                    SqlCommand myCommand = new SqlCommand(sqlAddUserQuery, conn);
                    myCommand.Parameters.AddWithValue("@PHONENUMBER", phone_number);
                    myCommand.Parameters.AddWithValue("@COUT", "0");
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    checkbyph.available = false;
                    while (myReader.Read())
                        {
                        checkbyph.customer.room_group = ((string)myReader["room_group"]).TrimEnd();
                            checkbyph.customer.checkin_date += ((string)myReader["checkin_date"]).TrimEnd()+",";
                            checkbyph.customer.phonenumber += ((string)myReader["phonenumber"]).TrimEnd() + ",";
                            checkbyph.customer.checkin_time += ((string)myReader["checkin_time"]).TrimEnd() + ",";
                            checkbyph.customer.hotel_name += ((string)myReader["hotel_name"]).TrimEnd() + ",";
                            checkbyph.customer.kot_amount += ((string)myReader["kot_amount"]).TrimEnd() + ",";
                        checkbyph.customer.kot_paid+= ((string)myReader["kot_paid"]).TrimEnd() + ",";
                        checkbyph.customer.advance_paid += ((string)myReader["advance_paid"]).TrimEnd() + ",";
                            checkbyph.customer.nc_kot_count += ((string)myReader["nc_kot"]).TrimEnd() + ",";
                            checkbyph.customer.plan += ((string)myReader["p_plan"]).TrimEnd() + ",";
                            checkbyph.customer.room_no += ((string)myReader["room_no"]).TrimEnd() + ",";
                            checkbyph.customer.room_type += ((string)myReader["room_type"]).TrimEnd() + ",";
                            checkbyph.customer.no_of_persons += ((string)myReader["person_count"]).TrimEnd() + ",";
                            checkbyph.customer.room_amt += ((string)myReader["room_amt"]).TrimEnd() + ",";
                        checkbyph.customer.room_paid+=((string)myReader["room_paid"]).TrimEnd() + ",";
                        checkbyph.customer.post_charges += ((string)myReader["post_charges"]).TrimEnd() + ",";
                        checkbyph.customer.post_paid+= ((string)myReader["post_paid"]).TrimEnd() + ",";
                        checkbyph.customer.discount += ((string)myReader["discount"]).TrimEnd() + ",";
                        checkbyph.customer.advance_used += ((string)myReader["advance_used"]).TrimEnd() + ",";
                        checkbyph.customer.Invoice_number += ((string)myReader["invoice"]).TrimEnd() + ",";
                            checkbyph.available = true;
                        }
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            conn.Close();
            return checkbyph;
        }

        public static Boolean room_status_update(room_update update1)
        {
            String update_sql = String.Format(@"insert into [room_status](room_no,room_type,status,supervisor_name,checkin_date,checkin_time,checkout_date,checkout_time,phonenumber,remark)values(@RNO,@RTYPE,@STATUS,@SNAME,@CIN_D,@CIN_T,@COUT_D,@COUT_T,@PHONE,@REMARK)");
            String update2 = String.Format(@"update [room_status] set status=@STATUS, supervisor_name=@SNAME,checkin_date=@CIN_D,checkin_time=@CIN_T,checkout_date=@COUT_D,checkout_time=@COUT_T,phonenumber='0',remark=@REMARK where (room_no=@RNO and status='2') or(room_no=@RNO and status='3')");
            String del = String.Format(@"delete from [room_status] where room_no=@RNO");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    if ((update1.status == "0") || (update1.status == "3"))
                    {
                        using (SqlCommand command = new SqlCommand(update_sql, conn))
                        {
                            command.Parameters.AddWithValue("@RNO", update1.room_no);
                            command.Parameters.AddWithValue("@RTYPE", update1.room_type);
                            command.Parameters.AddWithValue("@STATUS", update1.status);
                            command.Parameters.AddWithValue("@SNAME", update1.s_name);
                            command.Parameters.AddWithValue("@CIN_D", update1.checkin_date);
                            command.Parameters.AddWithValue("@CIN_T", update1.checkin_time);
                            command.Parameters.AddWithValue("@COUT_D", update1.checkout_date);
                            command.Parameters.AddWithValue("@COUT_T", update1.checkout_time);
                            command.Parameters.AddWithValue("@PHONE", update1.phonenumber);
                            command.Parameters.AddWithValue("@REMARK", update1.remark);
                            command.ExecuteNonQuery();
                            conn.Close();

                            return true;
                        }
                    }
                    else if ((update1.status == "4") || (update1.status == "2"))
                    {
                        using (SqlCommand command = new SqlCommand(update2, conn))
                        {
                            command.Parameters.AddWithValue("@RNO", update1.room_no);
                            command.Parameters.AddWithValue("@STATUS", update1.status);
                            command.Parameters.AddWithValue("@SNAME", update1.s_name);
                            command.Parameters.AddWithValue("@CIN_D", update1.checkin_date);
                            command.Parameters.AddWithValue("@CIN_T", update1.checkin_time);
                            command.Parameters.AddWithValue("@COUT_D", update1.checkout_date);
                            command.Parameters.AddWithValue("@COUT_T", update1.checkout_time);
                            command.Parameters.AddWithValue("@REMARK", update1.remark);
                            command.ExecuteNonQuery();
                            conn.Close();

                            return true;
                        }
                    }
                    else if (update1.status == "1")
                    {

                        using (SqlCommand command = new SqlCommand(del, conn))
                        {
                            command.Parameters.AddWithValue("@RNO", update1.room_no);
                            command.ExecuteNonQuery();
                            conn.Close();

                            return true;
                        }
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static String kot(String rno)
        {
            String r_checksql = String.Format("select * from [checkin] where room_no=@RNO and checkout=@COUT");
            String amount = String.Empty;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand myCommand1 = new SqlCommand(r_checksql, conn);
                    myCommand1.CommandType = System.Data.CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@RNO", rno);
                    myCommand1.Parameters.AddWithValue("@COUT", "0");
                    SqlDataReader myReader = myCommand1.ExecuteReader();
                    while (myReader.Read())
                    {
                        amount = ((string)myReader["kot_amount"]).TrimEnd();
                    }
                    conn.Close();
                    return amount;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return amount;
        }
        public static Boolean kot_update(String rno, String amount)
        {
            String count_qry = String.Format("select count(*) from [checkin] where room_no=@RNO and checkout=@COUT");
            string roomQuery = String.Format("update [checkin] set kot_amount=@AMOUNT where room_no=@RNO and checkout=@COUT");
            int count;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand myCommand1 = new SqlCommand(count_qry, conn);
                    myCommand1.CommandType = System.Data.CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@RNO", rno);
                    myCommand1.Parameters.AddWithValue("@COUT", "0");
                    count = Convert.ToInt32(myCommand1.ExecuteScalar());
                    if (count == 1)
                    {
                        using (SqlCommand command = new SqlCommand(roomQuery, conn))
                        {
                            command.Parameters.AddWithValue("@AMOUNT", amount);
                            command.Parameters.AddWithValue("@RNO", rno);
                            command.Parameters.AddWithValue("@COUT", "0");
                            command.ExecuteNonQuery();
                            conn.Close();
                            return true;
                        }
                    }


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean inventory_update(String item, String status, String balance)
        {
            String sqlinv = String.Format("update [inventory] set current_unit=@CURRENT,status=@STATUS where items=@ITEM");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sqlinv, conn))
                    {
                        command.Parameters.AddWithValue("@CURRENT", balance);
                        command.Parameters.AddWithValue("@STATUS", status);
                        command.Parameters.AddWithValue("@ITEM", item);
                        command.ExecuteNonQuery();


                    }

                }
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean inventory_eupdate(String item, String pamount, String status, String balance)
        {
            String sqlinv = String.Format("update [inventory] set current_unit=@CURRENT,order_amount=@OAMT,status=@STATUS where items=@ITEM");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sqlinv, conn))
                    {
                        command.Parameters.AddWithValue("@CURRENT", balance);
                        command.Parameters.AddWithValue("@STATUS", status);
                        command.Parameters.AddWithValue("@OAMT", pamount);
                        command.Parameters.AddWithValue("@ITEM", item);
                        command.ExecuteNonQuery();


                    }

                }
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean purchase_update(String item, String quantity)
        {
            String sqlinv = String.Format("update [inventory] set status=@STATUS,order_amount=@OAMT where items=@ITEM");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sqlinv, conn))
                    {
                        command.Parameters.AddWithValue("@STATUS", "ordered");
                        command.Parameters.AddWithValue("@OAMT", quantity);
                        command.Parameters.AddWithValue("@ITEM", item);
                        command.ExecuteNonQuery();

                    }

                }
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static String nc_kot_check(String rno)
        {
            String r_checksql = String.Format("select * from [checkin] where room_no=@RNO and checkout=@COUT");
            String count = String.Empty;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand myCommand1 = new SqlCommand(r_checksql, conn);
                    myCommand1.CommandType = System.Data.CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@RNO", rno);
                    myCommand1.Parameters.AddWithValue("@COUT", "0");
                    SqlDataReader myReader = myCommand1.ExecuteReader();
                    while (myReader.Read())
                    {
                        count = ((string)myReader["nc_kot"]).TrimEnd();
                    }
                    conn.Close();
                    return count;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return count;
        }
        public static Boolean nc_kot_update(String rno, int count)
        {
            String nc_sql = String.Format(@"update [checkin] set nc_kot=@NCKOT where room_no=@RNO and checkout=@COUT");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(nc_sql, conn))
                    {
                        command.Parameters.AddWithValue("@NCKOT", count);
                        command.Parameters.AddWithValue("@RNO", rno);
                        command.Parameters.AddWithValue("@COUT", "0");
                        command.ExecuteNonQuery();
                        return true;

                    }

                }
                conn.Close();
            }
            catch
            {

            }
            return false;
        }
        public static Boolean checkout_update(checkout_update c_update)
        {
            String update_qsql = String.Format(@"update [checkin] set checkin_out_date=@COUT_D, checkin_out_time=@COUT_T, room_amt=@AMT,discount=@DISCOUNT,transaction_no=@TID,checkout='1',post_charges=@POST where room_no=@RNO and checkout='0'");
            String room_updatesql = String.Format(@"update [room_status] set checkout_date=@COUT_D, checkout_time=@COUT_T,remark=@REMARK,status='2' where room_no=@RNO and status='0'");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(update_qsql, conn))
                    {
                        command.Parameters.AddWithValue("@COUT_D", c_update.checkoutdate);
                        command.Parameters.AddWithValue("@COUT_T", c_update.checkouttime);
                        command.Parameters.AddWithValue("@AMT", c_update.room_amt);
                        command.Parameters.AddWithValue("@DISCOUNT", c_update.discount);
                        command.Parameters.AddWithValue("@TID", c_update.transaction_detail);
                        command.Parameters.AddWithValue("@RNO", c_update.room_no);
                        command.Parameters.AddWithValue("@POST", c_update.post_charge);
                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command2 = new SqlCommand(room_updatesql, conn))
                    {
                        command2.Parameters.AddWithValue("@COUT_D", c_update.checkoutdate);
                        command2.Parameters.AddWithValue("@COUT_T", c_update.checkouttime);
                        command2.Parameters.AddWithValue("@REMARK", c_update.remark);
                        command2.Parameters.AddWithValue("@RNO", c_update.room_no);
                        command2.ExecuteNonQuery();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean checkout_all_update(checkout_update c_update)
        {
            String update_qsql = String.Format(@"update [checkin] set checkin_out_date=@COUT_D, checkin_out_time=@COUT_T, room_amt=@AMT,discount=@DISCOUNT,transaction_no=@TID,checkout='1' where phonenumber=@PHONENUMBER and checkout='0'");
            String room_updatesql = String.Format(@"update [room_status] set checkout_date=@COUT_D, checkout_time=@COUT_T, status='2' where status='0' and phonenumber=@PHONENUMBER");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(update_qsql, conn))
                    {

                        command.Parameters.AddWithValue("@PHONENUMBER", c_update.phonenumber);
                        command.Parameters.AddWithValue("@COUT_T", c_update.checkoutdate);
                        command.Parameters.AddWithValue("@COUT_D", c_update.checkouttime);
                        command.Parameters.AddWithValue("@AMT", c_update.room_amt);
                        command.Parameters.AddWithValue("@DISCOUNT", c_update.discount);
                        command.Parameters.AddWithValue("@TID", c_update.transaction_detail);
                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command2 = new SqlCommand(room_updatesql, conn))
                    {
                        command2.Parameters.AddWithValue("@COUT_T", c_update.checkoutdate);
                        command2.Parameters.AddWithValue("@COUT_D", c_update.checkouttime);
                        command2.Parameters.AddWithValue("@PHONENUMBER", c_update.phonenumber);
                        command2.ExecuteNonQuery();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean log_update(String log_path, String log_text)
        {
            try
            {
                StreamWriter sw = new StreamWriter(log_path, true);
                sw.WriteLine(log_text);
                sw.Close();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean user_add(user1 add)
        {
            String add_user = String.Format(@"insert into [User](name,designation,user_name,password,front_desk,f_b,h_k,store,report,add_u,remark)values(@NAME,@JOB,@U_NAME,@PASS,@FD,@FB,@HK,@STORE,@REPORT,@ADD,@REMARK)");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(add_user, conn))
                    {
                        command.Parameters.AddWithValue("@NAME", add.name);
                        command.Parameters.AddWithValue("@JOB", add.job);
                        command.Parameters.AddWithValue("@U_NAME", add.username);
                        command.Parameters.AddWithValue("@PASS", add.password);
                        command.Parameters.AddWithValue("@FD", add.fd_pre);
                        command.Parameters.AddWithValue("@FB", add.fb_pre);
                        command.Parameters.AddWithValue("@HK", add.hk_pre);
                        command.Parameters.AddWithValue("@STORE", add.store_pre);
                        command.Parameters.AddWithValue("@REPORT", add.report_pre);
                        command.Parameters.AddWithValue("@ADD", add.add_u_pre);
                        command.Parameters.AddWithValue("@REMARK", add.remark);
                        command.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n USER NAME EXIST");
            }
            return false;
        }
        public static user_avail user_check(String username, String pass)
        {
            user_avail fetch = new user_avail();
            String user_sql = String.Format(@"select * from [User] where user_name=@USER and password=@PASS");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand(user_sql, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@USER", username);
                    myCommand.Parameters.AddWithValue("@PASS", pass);
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        fetch.name = ((string)myReader["name"]).TrimEnd();
                        fetch.job = ((string)myReader["designation"]).TrimEnd();
                        fetch.username = ((string)myReader["user_name"]).TrimEnd();
                        fetch.password = ((string)myReader["password"]).TrimEnd();
                        fetch.fd_pre = ((int)myReader["front_desk"]).ToString();
                        fetch.fb_pre = ((int)myReader["f_b"]).ToString();
                        fetch.hk_pre = ((int)myReader["h_k"]).ToString();
                        fetch.store_pre = ((int)myReader["store"]).ToString();
                        fetch.report_pre = ((int)myReader["report"]).ToString();
                        fetch.add_u_pre = ((int)myReader["add_u"]).ToString();
                        fetch.remark = ((string)myReader["remark"]).TrimEnd();
                        fetch.available = "true";
                    }
                }
                conn.Close();
                return fetch;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            fetch.available = "false";
            return fetch;

        }
        public static Boolean update_user(user1 update_user, String username)
        {
            String update_usersql = String.Format(@"update [User] set name=@NAME,designation=@JOB,user_name=@U_NAME,password=@PASS,front_desk=@FD,f_b=@FB,h_k=@HK,store=@STORE,report=@REPORT,add_u=@ADD,remark=@REMARK where user_name=@ORG_USER");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(update_usersql, conn))
                    {
                        command.Parameters.AddWithValue("@NAME", update_user.name);
                        command.Parameters.AddWithValue("@JOB", update_user.job);
                        command.Parameters.AddWithValue("@U_NAME", update_user.username);
                        command.Parameters.AddWithValue("@PASS", update_user.password);
                        command.Parameters.AddWithValue("@FD", update_user.fd_pre);
                        command.Parameters.AddWithValue("@FB", update_user.fb_pre);
                        command.Parameters.AddWithValue("@HK", update_user.hk_pre);
                        command.Parameters.AddWithValue("@STORE", update_user.store_pre);
                        command.Parameters.AddWithValue("@REPORT", update_user.report_pre);
                        command.Parameters.AddWithValue("@ADD", update_user.add_u_pre);
                        command.Parameters.AddWithValue("@REMARK", update_user.remark);
                        command.Parameters.AddWithValue("@ORG_USER", username);
                        command.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n USER NAME EXIST");
            }
            return false;
        }
        public static Boolean del_user(String username)
        {
            String del_sql = String.Format(@"delete from [User] where user_name=@USER");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(del_sql, conn))
                    {
                        command.Parameters.AddWithValue("@USER", username);
                        command.ExecuteNonQuery();

                    }
                    conn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean room_book_check(String rnum, String book_date)
        {
            String book_check = String.Format(@"select count(*) from booking_status where booked_date=@BDATE and room_no=@RNUM");
            int count = 0;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand(book_check, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@BDATE", book_date);
                    myCommand.Parameters.AddWithValue("@RNUM", rnum);
                    count = Convert.ToInt32(myCommand.ExecuteScalar());
                    if (count == 0)
                    {
                        conn.Close();
                        return true;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static Boolean book_room(booking_details book)
        {
            String booksql = String.Format(@"insert into [booking_status](booking_id,hotel,room_no,roomtype,booked_date,booked_intime,checkout_date,checkout_time,period,phonenumber,name,advance_paid,status)values(@BID,@HOTEL,@RNUM,@RTYPE,@BDATE,@BTIME,@CDATE,@CTIME,@PERIOD,@PH,@NAME,@ADVANCE,@STATUS)");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(booksql, conn))
                    {
                        command.Parameters.AddWithValue("@BID", book.invoice);
                        command.Parameters.AddWithValue("@HOTEL", book.hotel);
                        command.Parameters.AddWithValue("@RNUM", book.roomnumber);
                        command.Parameters.AddWithValue("@RTYPE", book.room_type);
                        command.Parameters.AddWithValue("@BDATE", book.book_date);
                        command.Parameters.AddWithValue("@BTIME", book.book_time);
                        command.Parameters.AddWithValue("@CDATE", book.checkout_date);
                        command.Parameters.AddWithValue("@CTIME", book.checkout_time);
                        command.Parameters.AddWithValue("@PERIOD", book.period);
                        command.Parameters.AddWithValue("@PH", book.phonenumber);
                        command.Parameters.AddWithValue("@NAME", book.name);
                        command.Parameters.AddWithValue("@ADVANCE", book.advance_paid);
                        command.Parameters.AddWithValue("@STATUS", book.status);
                        command.ExecuteNonQuery();
                        conn.Close();
                        return true;

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static book_avail book_retrieve(String code,String phone)
        {
            String booksql = String.Format(@"select * from [booking_status] where phonenumber=@PHONE and country_code=@CC and status='1' and booked_date=@BDATE and booked_intime<=@BTIME");
            book_avail detail = new book_avail();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand(booksql, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@PHONE", phone);
                    myCommand.Parameters.AddWithValue("@BDATE", DateTime.Now.ToString("M/dd/yyyy"));
                    myCommand.Parameters.AddWithValue("@BTIME", DateTime.Now.Hour);
                    Console.WriteLine(DateTime.Now.ToString("M/dd/yyyy") + "" + DateTime.Now.Hour);
                    myCommand.Parameters.AddWithValue("@CC", code);
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    detail.available = "false";
                    while (myReader.Read())
                    {
                        detail.available = "true";
                        detail.name = ((string)myReader["name"]).TrimEnd();
                        detail.phonenumber = ((string)myReader["phonenumber"]).TrimEnd();
                        detail.room_type += ((string)myReader["roomtype"]).TrimEnd()+",";
                        detail.hotel = ((string)myReader["hotel"]).TrimEnd();
                        detail.book_date = ((string)myReader["booked_date"]).TrimEnd();
                        detail.book_time += ((string)myReader["booked_intime"]).TrimEnd()+",";
                        detail.checkout_date += ((string)myReader["checkout_date"]).TrimEnd()+",";
                        detail.checkout_time += ((string)myReader["checkout_time"]).TrimEnd()+",";
                        detail.count += ((string)myReader["count"]).TrimEnd()+",";
                        detail.advance_paid += ((string)myReader["advance_paid"]).TrimEnd()+",";
                        detail.amount+= ((string)myReader["room_amount"]).TrimEnd()+",";

                    }
                    conn.Close();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return detail;
        }
        public static void book_status(String bookid)
        {
            string book_status = String.Format(@"update booking_status set status='checked' where booking_id=@BID");
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                SqlCommand com = new SqlCommand(book_status, conn);
                com.Parameters.AddWithValue("@BID", bookid);
                com.ExecuteNonQuery();
                conn.Close();
            }

        }
        public static DataTable book_cal()
        {
            DataTable dt = new DataTable();
            string book_calsql = String.Format(@"select * from [booking_status]");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(book_calsql, conn);
                    da.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dt;
        }
        public static Boolean kot_table(kot_table kot1)
        {
            String kotsql = String.Format(@"insert into [kot](room_no,date,bill_no,nc_kot,amount,kot_type,number,items,session,steward)values(@RNO,@DATE,@BILLNO,@NC_KOT,@AMOUNT,@KOT_TYPE,@NO,@ITEM,@SESSION,@STEWARD)");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(kotsql, conn))
                    {
                        com.Parameters.AddWithValue("@RNO", kot1.room_no);
                        com.Parameters.AddWithValue("@DATE", kot1.date);
                        com.Parameters.AddWithValue("@BILLNO", kot1.bill_no);
                        com.Parameters.AddWithValue("@NC_KOT", kot1.nc_kot);
                        com.Parameters.AddWithValue("@AMOUNT", kot1.amount);
                        com.Parameters.AddWithValue("@KOT_TYPE", kot1.kot_type);
                        com.Parameters.AddWithValue("@NO", kot1.number);
                        com.Parameters.AddWithValue("@ITEM", kot1.items);
                        com.Parameters.AddWithValue("@SESSION", kot1.session);
                        com.Parameters.AddWithValue("@STEWARD", kot1.steward);
                        com.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static night_audit1 night(string date)
        {
            night_audit1 na = new night_audit1();
            na.receive = false;
            string room = string.Empty;
            string broom = string.Empty;
            string bill = string.Empty;
            String roomsql = String.Format(@"select room_no from [checkin] where checkin_date=@CDATE");
            String totalsql = String.Format(@"select sum(cast ([advance_paid] as int)) as paid from [checkin] where checkin_date=@CDATE");
            String kotsql = String.Format(@"select bill_no from [kot] where date=@CDATE");
            String kot_revsql = String.Format(@"select sum(cast([amount] as int)) as total,sum(cast([nc_kot] as int)) as nckot from [kot] where date=@CDATE");
            String booksql = String.Format(@"select room_no from [booking_status] where booked_date=@BDATE");
            String bookrev = String.Format(@"select sum(cast([advance_paid] as int)) as value from [booking_status] where booked_date=@BDATE");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand(roomsql, conn);
                    myCommand.CommandType = System.Data.CommandType.Text;
                    myCommand.Parameters.AddWithValue("@CDATE", date);
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        room += ((string)myReader["room_no"]).TrimEnd() + ",";
                    }
                    na.room_no = room;
                    myReader.Close();
                    SqlCommand myCommand1 = new SqlCommand(totalsql, conn);
                    myCommand1.CommandType = System.Data.CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@CDATE", date);
                    SqlDataReader myReader1 = myCommand1.ExecuteReader();
                    while (myReader1.Read())
                    {
                        if (myReader1["paid"] != DBNull.Value)
                        {
                            na.adv_rev = ((int)myReader1["paid"]).ToString();
                        }

                    }
                    myReader1.Close();
                    SqlCommand myCommand2 = new SqlCommand(kotsql, conn);
                    myCommand2.CommandType = System.Data.CommandType.Text;
                    myCommand2.Parameters.AddWithValue("@CDATE", date);
                    SqlDataReader myReader2 = myCommand2.ExecuteReader();
                    while (myReader2.Read())
                    {
                        bill = ((string)myReader2["bill_no"]).TrimEnd() + ",";
                    }
                    na.bill_no = bill;
                    myReader2.Close();
                    SqlCommand myCommand3 = new SqlCommand(kot_revsql, conn);
                    myCommand3.CommandType = System.Data.CommandType.Text;
                    myCommand3.Parameters.AddWithValue("@CDATE", date);
                    SqlDataReader myReader3 = myCommand3.ExecuteReader();
                    while (myReader3.Read())
                    {
                        if (myReader3["total"] != DBNull.Value)
                        {
                            na.kot_rev = ((int)myReader3["total"]).ToString();
                        }
                        if (myReader3["nckot"] != DBNull.Value)
                        {
                            na.nc_kot = ((int)myReader3["nckot"]).ToString();
                        }

                    }
                    myReader3.Close();
                    SqlCommand myCommand4 = new SqlCommand(booksql, conn);
                    myCommand4.CommandType = System.Data.CommandType.Text;
                    myCommand4.Parameters.AddWithValue("@BDATE", date);
                    SqlDataReader myReader4 = myCommand4.ExecuteReader();
                    while (myReader4.Read())
                    {
                        broom += ((string)myReader4["room_no"]).TrimEnd() + ",";
                    }
                    na.book = broom;
                    myReader4.Close();
                    SqlCommand myCommand5 = new SqlCommand(bookrev, conn);
                    myCommand5.CommandType = System.Data.CommandType.Text;
                    myCommand5.Parameters.AddWithValue("@BDATE", date);
                    SqlDataReader myReader5 = myCommand5.ExecuteReader();
                    while (myReader5.Read())
                    {
                        if (myReader5["value"] != DBNull.Value)
                        {
                            na.book_rev = ((int)myReader5["value"]).ToString();
                        }

                    }
                    myReader5.Close();
                    na.receive = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            conn.Close();
            return na;
        }
        public static void roomxml()
        {
            string sqlroom = String.Format(@"select * from [room_status] where status!='1' order by checkin_date,checkin_time");
            String room = String.Empty;
            String status = String.Empty;
            String rtype = String.Empty;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    XmlDocument doc1 = new XmlDocument();
                    doc1.Load("room.xml");
                    XmlNode node1 = doc1.DocumentElement;
                    foreach (XmlNode pnode in node1.ChildNodes)
                    {
                        foreach (XmlNode type in pnode.ChildNodes)
                        {
                            type.Attributes[0].InnerText = "1";
                        }

                    }
                    doc1.Save("room.xml");
                    SqlCommand com = new SqlCommand(sqlroom, conn);
                    com.CommandType = System.Data.CommandType.Text;
                    SqlDataReader myReader = com.ExecuteReader();
                    while (myReader.Read())
                    {
                        room = ((string)myReader["room_no"]).TrimEnd();
                        status = ((string)myReader["status"]).TrimEnd();
                        rtype = ((string)myReader["room_type"]).TrimEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.Load("room.xml");
                        XmlNode node = doc.DocumentElement;
                        foreach (XmlNode pnode in node.ChildNodes)
                        {
                            if (pnode.Attributes[0].InnerText == rtype)
                            {

                                foreach (XmlNode type in pnode.ChildNodes)
                                {
                                    if (type.InnerText == room)
                                    {
                                        type.Attributes[0].InnerText = status;
                                    }


                                }
                            }

                        }
                        doc.Save("room.xml");
                    }
                    conn.Close();
                    bookxml();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void bookxml()
        {
            string bookq = String.Format(@"select * from [booking_status] where booked_date=@DATE");
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                SqlCommand com = new SqlCommand(bookq, conn);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@DATE", DateTime.Now.ToString("dd/MM/yyyy"));
                SqlDataReader myReader = com.ExecuteReader();
                while (myReader.Read())
                {
                    string rtype = ((string)myReader["roomtype"]).TrimEnd();
                    string room = ((string)myReader["room_no"]).TrimEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.Load("room.xml");
                    XmlNode node = doc.DocumentElement;
                    foreach (XmlNode pnode in node.ChildNodes)
                    {
                        if (pnode.Attributes[0].InnerText == rtype)
                        {

                            foreach (XmlNode type in pnode.ChildNodes)
                            {
                                if (type.InnerText == room)
                                {
                                    type.Attributes[0].InnerText = "5";
                                }


                            }
                        }

                    }
                    doc.Save("room.xml");
                }
                conn.Close();
            }
        }
        public static void flash_report()
        {
            string room_d = String.Format(@"select count(*) from [checkin] where convert(datetime2,checkin_date)>=DATEADD(DAY, -1, GETDATE()) order by checkin_date,checkin_time");
            string room_m = String.Format(@"select count(*) from [checkin] where convert(datetime2,checkin_date)>=DATEADD(MONTH, -1, GETDATE()) order by checkin_date,checkin_time");
            string room_y = String.Format(@"select count(*) from [checkin] where convert(datetime2,checkin_date)>=DATEADD(YEAR, -1, GETDATE()) order by checkin_date,checkin_time");
            string roomrev_d = String.Format(@"select sum(cast([total))");

        }

    }
}
