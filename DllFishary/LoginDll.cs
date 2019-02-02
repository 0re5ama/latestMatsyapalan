using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttFishary;
using System.Data.SqlClient;
using System.Data;
using MajorConn;

namespace DllFishary
{

   public class LoginDll
    {
       
        public string SaveParameter(LoginAtt objCampaignParameter, string role)
        {
            string SP = "";
            string msg = "";
            char status;
            SqlCommand oCommand = new SqlCommand();
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "mt_login";
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@username", objCampaignParameter.UserName);
            objParameter[1] = new SqlParameter("@password", objCampaignParameter.Password);
           // objParameter[2] = new SqlParameter("@submitteddate", "2018.01.07");
           // objParameter[3] = new SqlParameter("@submittebBy", "Admin");
           SqlDataReader dr=   SqlHelper.ExecuteReader( oCommand, objParameter);
            if (dr.HasRows)
            {
                 msg = "";

            }
            else {
                 msg = " कुनै डाटा छैन!!!";
            }
            //while (dr.Read())
            //{
            //    string col = dr["UserName"].ToString();
            //}
            //GetConnection conn = new GetConnection();
            //OracleConnection dbConn = conn.GetDbConn(role);
            //OracleTransaction tran = dbConn.BeginTransaction();

            //try
            //{



            //    if (objCampaignParameter.Status == true)
            //    {
            //        status = 'A';
            //    }
            //    else
            //    {
            //        status = 'I';
            //    }

            //    if (objCampaignParameter.Action == "E")
            //    {
            //        SP = "EPR_EDIT_ELECTION_CP_PARAMETER";
            //        msg = "सफलतापूर्वक रकम अद्यावधिक भयो ।";
            //    }
            //    else
            //    {
            //        SP = "EPR_ADD_ELECTION_CP_PARAMETER";
            //        msg = "सफलतापूर्वक सेव भयो ।";
            //    }

            //    if (SP != "")
            //    {

            //        List<OracleParameter> paramList = new List<OracleParameter>();

            //        paramList.Add(SqlHelper.GetOraParam(":P_ELECTION_ID", objCampaignParameter.ElectionID, OracleDbType.Int32, ParameterDirection.InputOutput));
            //        paramList.Add(SqlHelper.GetOraParam(":P_EC_LEVEL_ID", objCampaignParameter.EcLevelID, OracleDbType.Int32, ParameterDirection.Input));
            //        paramList.Add(SqlHelper.GetOraParam(":P_CP_ID", objCampaignParameter.CPID, OracleDbType.Int32, ParameterDirection.Input));
            //        paramList.Add(SqlHelper.GetOraParam(":P_CP_VALUES", objCampaignParameter.CPValues, OracleDbType.Varchar2, ParameterDirection.Input));

            //        paramList.Add(SqlHelper.GetOraParam(":P_R_STATUS", status, OracleDbType.Char, ParameterDirection.Input));
            //        paramList.Add(SqlHelper.GetOraParam(":P_ENTRY_BY", objCampaignParameter.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));


            //        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, SP, paramList.ToArray());


            //    }

            //    tran.Commit();

            //}
            //catch (Exception ex)
            //{
            //    tran.Rollback();
            //    throw new Exception("Error" + ex.Message);
            //}

            //finally
            //{
            //    dbConn.Close();
            //    //conn.CloseDbConn();
            //}


            return msg;
        }

        public string SaveUser(List<LoginAtt> objCampaignParameter, string role)
        {
            string SP = "";
            string msg = "";
            char status;
            SqlCommand oCommand = new SqlCommand();
            oCommand.CommandType = CommandType.StoredProcedure;
          
            try
            {

                foreach (LoginAtt ob in objCampaignParameter)
                {
                    if (ob.Action == "A")
                    {
                        oCommand.CommandText = "sp_login";
                        SqlParameter[] objParameter = new SqlParameter[5];
                        objParameter[0] = new SqlParameter("@username", ob.UserName);
                        objParameter[1] = new SqlParameter("@password", ob.Password);
                        objParameter[2] = new SqlParameter("@Address", ob.Address);
                        objParameter[3] = new SqlParameter("@submitteddate", "2018.01.07");
                        objParameter[4] = new SqlParameter("@submittebBy", "Admin");
                        int dr = SqlHelper.ExecuteNonQuery(oCommand, objParameter);
                    }
                    else if (ob.Action == "E")
                    {
                        oCommand.CommandText = "UserUpdate";
                        SqlParameter[] objParameters= new SqlParameter[6];
                        objParameters[0] = new SqlParameter("@ID", ob.ID);
                        objParameters[1] = new SqlParameter("@username", ob.UserName);
                        objParameters[2] = new SqlParameter("@password", ob.Password);
                        objParameters[3] = new SqlParameter("@Address", ob.Address);
                        objParameters[4] = new SqlParameter("@submitteddate", "2018.01.07");
                        objParameters[5] = new SqlParameter("@submittebBy", "Admin");
                        int dr = SqlHelper.ExecuteNonQuery(oCommand, objParameters);
                    }
                    }
          

            }
            catch (Exception ex)
            {

                throw;
            }
       

            return msg;
        }

        public List<LoginAtt> GetUser()
        {
            List<LoginAtt> lst = new List<LoginAtt>();
            try
            {
                string msg = "";
                char status;
                SqlCommand oCommand = new SqlCommand();
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "getUser";
                SqlParameter[] objParameter = new SqlParameter[2];
                SqlDataReader dr = SqlHelper.SingleExecuteReader(oCommand);
                while (dr.Read())
                {
                    LoginAtt obj = new LoginAtt();
                    obj.ID = Convert.ToInt32(dr["ID"].ToString());
                    obj.UserName = dr["UserName"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.Password = dr["Password"].ToString();                

                    lst.Add(obj);
                }
                //else
                //{
                //    msg = " कुनै डाटा छैन!!!";
                //}

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public string DeleteUser(string useID)
        {
            List<LoginAtt> lst = new List<LoginAtt>();
            try
            {
                string msg = "";
                char status;
                SqlCommand oCommand = new SqlCommand();
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "DelUser";
                SqlParameter[] objParameter = new SqlParameter[1];
                objParameter[0] = new SqlParameter("@ID", useID);
                Int32 dr = SqlHelper.ExecuteNonQuery(oCommand, objParameter);
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
