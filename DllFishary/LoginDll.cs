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
    }
}
