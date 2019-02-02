using ATTEmployee;
using MajorConn;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLEmployee
{
   public class DLLEmployee
    {
        public List<EmployeeATT> GetEmployee(int ExpItmId, string Visibility, string p_rc, string role)
        {

            List<EmployeeATT> lst = new List<EmployeeATT>();
            try
            {
                string msg = "";
                char status;
                SqlCommand oCommand = new SqlCommand();
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "getEmployee";
                SqlParameter[] objParameter = new SqlParameter[2];
                SqlDataReader dr = SqlHelper.SingleExecuteReader(oCommand);
                while (dr.Read())
                {
                    EmployeeATT obj = new EmployeeATT();
                    obj.EmployeeID = Convert.ToInt32(dr["EmployeeID"].ToString());
                    obj.EName = dr["EName"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.MobileNo = dr["MobNo"].ToString();
                    obj.Salary =Convert.ToDouble(dr["Salary"].ToString());
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                  
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



        public string DeleteEmployee(int EmpId, string Visibility, string p_rc, string role)
        {

            List<EmployeeATT> lst = new List<EmployeeATT>();
            try
            {
                string msg = "";
                char status;
                SqlCommand oCommand = new SqlCommand();
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "DelEmployee";
                SqlParameter[] objParameter = new SqlParameter[1];
                objParameter[0] = new SqlParameter("@EmployeeID", EmpId);
                Int32 dr = SqlHelper.ExecuteNonQuery(oCommand, objParameter);
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }
        public string SaveEmployee(List<EmployeeATT> obj, string role)
        {
            string SP = "";
            string msg = "";
            char status;
            SqlCommand oCommand = new SqlCommand();
            oCommand.CommandType = CommandType.StoredProcedure;
            try
            {


                foreach (EmployeeATT ob in obj)
                {
                    if (ob.Action == "A")
                    {
                        SqlParameter[] objParameter = new SqlParameter[8];
                        oCommand.CommandText = "InsEmployee";
                        //objParameter[0] = new SqlParameter("@EmployeeID", ob.EmployeeID);                        
                        objParameter[0] = new SqlParameter("@EName", ob.EName);
                        objParameter[1] = new SqlParameter("@MobNo", ob.MobileNo);
                        objParameter[2] = new SqlParameter("@Address", ob.Address);
                        objParameter[3] = new SqlParameter("@JoiningDate", ob.JoiningDate);
                        objParameter[4] = new SqlParameter("@Salary", ob.Salary);
                        objParameter[5] = new SqlParameter("@EntryDate", "2018.01.07");
                        objParameter[6] = new SqlParameter("@EntryBy", "Admin");
                        objParameter[7] = new SqlParameter("@Status", "U");



                        Int32 dr = SqlHelper.ExecuteNonQuery(oCommand, objParameter);
                    }
                    else if (ob.Action == "E")
                    {
                        SqlParameter[] objParameters = new SqlParameter[9];
                        oCommand.CommandText = "UspEmployee";
                        objParameters[0] = new SqlParameter("@EmployeeID", ob.EmployeeID);                        
                        objParameters[1] = new SqlParameter("@EName", ob.EName);
                        objParameters[2] = new SqlParameter("@MobNo", ob.MobileNo);
                        objParameters[3] = new SqlParameter("@Address", ob.Address);
                        objParameters[4] = new SqlParameter("@JoiningDate", ob.JoiningDate);
                        objParameters[5] = new SqlParameter("@Salary", ob.Salary);
                        objParameters[6] = new SqlParameter("@EntryDate", "2018.01.07");
                        objParameters[7] = new SqlParameter("@EntryBy", "Admin");
                        objParameters[8] = new SqlParameter("@Status", "U");

                        Int32 dr = SqlHelper.ExecuteNonQuery(oCommand, objParameters);
                    }

                
                }

            }
            catch (Exception ex)
            {
               
                throw new Exception("Error" + ex.Message);
            }



            return msg;
        }
    }
}
