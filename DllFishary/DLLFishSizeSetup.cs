using AttFishary;
using MajorConn;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllFishary
{
    public class DLLFishSizeSetup
    {
        string SP = "";
        public List<FishSizeATT> GetFishCategoryType(int ExpItmId, string Visibility, string p_rc, string role)
        {

            List<FishSizeATT> lst = new List<FishSizeATT>();
            try
            {
                string msg = "";
                char status;
                SqlCommand oCommand = new SqlCommand();
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "get_fishsize";
                SqlParameter[] objParameter = new SqlParameter[2];
                SqlDataReader dr = SqlHelper.SingleExecuteReader(oCommand);
                while (dr.Read())
                {
                    FishSizeATT obj = new FishSizeATT();
                    obj.SizeId = Convert.ToInt32(dr["FSizeID"].ToString());
                    obj.SizeName = dr["SizeName"].ToString();
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


        public string SaveFishSize(List<FishSizeATT> obj, string role)
        {
            string SP = "";
            string msg = "Saved Successfully";
            char status;
            SqlCommand oCommand = new SqlCommand();
            oCommand.CommandType = CommandType.StoredProcedure;
            try
            {

                
                foreach (FishSizeATT ob in obj)
                {
                    if (ob.Action == "A")
                    {
                        SqlParameter[] objParameter = new SqlParameter[3];
                        oCommand.CommandText = "sp_Ins_FishSize";
                        objParameter[0] = new SqlParameter("@SizeName", ob.SizeName);
                        objParameter[1] = new SqlParameter("@submitteddate", "2018.01.07");
                        objParameter[2] = new SqlParameter("@submittebBy", "Admin");
                        Int32 dr = SqlHelper.ExecuteNonQuery(oCommand, objParameter);
                    }
                    else if (ob.Action == "E")
                    {
                        SqlParameter[] objParameters = new SqlParameter[4];
                        oCommand.CommandText = "sp_Ipd_FishSize";
                        objParameters[0] = new SqlParameter("@FSizeID", ob.SizeId);
                        objParameters[1] = new SqlParameter("@SizeName", ob.SizeName);
                        objParameters[2] = new SqlParameter("@submitteddate", "2018.01.07");
                        objParameters[3] = new SqlParameter("@submittebBy", "Admin");
                 
                        Int32 dr = SqlHelper.ExecuteNonQuery(oCommand, objParameters);
                    }
                    //if (ob.Action != null)
                    //{
                      
                    //}
                }

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return msg;

        }

    }
}
