using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreDllDemo
{
    public class OracleConnector
    {
        public static DataTable FillDataGrid()
        {
            //string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            //string ConString = "Data Source=DESKTOP-55AGI0I\\SQLEXPRESS;Initial Catalog=BOADB;User ID=sa;Password=vignesh";

            //string ConString = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SID = XE))); User Id = System; Password=vignesh";
            string CmdString = string.Empty;
            //using (SqlConnection con = new SqlConnection(ConString))
            //{
            //    CmdString = "SELECT CurrencyCode,Value FROM CurrencyInfo";
            //    SqlCommand cmd = new SqlCommand(CmdString, con);
            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable("Dept");
            //    sda.Fill(dt);
            //    return dt;
            //}
            using (OracleConnection con = OracleHelper.getConnection())
            {
                con.Open();
                String sql = "select * from CON_USER";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                //OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable("Dept");
                dt.Load(dr);
                return dt;
            }
        }

        public static int addUser(CONT_USER userObj)
        {
            using (OracleConnection conn = OracleHelper.getConnection())
            {
                conn.Open();
                String seqQuery = "select CONT_SEQ.NEXTVAL from dual";
                OracleCommand seqCmd = new OracleCommand(seqQuery, conn);
                seqCmd.CommandType = CommandType.Text;
                OracleDataReader dr = seqCmd.ExecuteReader();
                dr.Read();
                int id= dr.GetInt32(0);
                String sql = "insert into CON_USER (USER_ID,FIRST_NAME,LAST_NAME,DOB,GENDER," +
                    "EMAIL,STATE,PASSWORD,ADDRESS,PROFILE_PHOTO) " +
                    "values(:id,:fname,:lname,:dob,:gender,:email,:state,:password,:address,:pic)";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add("id", id);
                cmd.Parameters.Add("fname", userObj.FirstName);
                cmd.Parameters.Add("lname", userObj.LastName);
                cmd.Parameters.Add("dob", userObj.DOB);
                cmd.Parameters.Add("gender", userObj.Gender);
                cmd.Parameters.Add("email", userObj.Email);
                cmd.Parameters.Add("state", userObj.State);
                cmd.Parameters.Add("password", userObj.Password);
                cmd.Parameters.Add("address", userObj.Address);
                cmd.Parameters.Add("pic", userObj.ProfilePhoto);
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }


                
        }
    }
}
