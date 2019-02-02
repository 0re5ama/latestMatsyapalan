using ATTEmployee;
using BLLEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTILITY;

namespace Matshyapalan.Handler.Emloyee
{
    /// <summary>
    /// Summary description for EmployeeHandler
    /// </summary>
    public class EmployeeHandler : BaseHandler
    {
        public object GetEmployee(int ExpItmId, string Visibility, string p_rc, string role)
        {
            BllEmployee objBll = new BllEmployee();

            JsonResponse response = new JsonResponse();
            try
            {
                response.ResponseData = objBll.GetEmployee(ExpItmId, Visibility, p_rc, role);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }

        public object DeleteEmployee(int EmpId, string Visibility, string p_rc, string role)
        {
            BllEmployee objBll = new BllEmployee();

            JsonResponse response = new JsonResponse();
            try
            {
                response.ResponseData = objBll.DeleteEmployee(EmpId, Visibility, p_rc, role);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }
        public object SaveEmployee(string args, string role)
        {
            JsonResponse response = new JsonResponse();
            //if (token == CurrentToken())
            //{
            BllEmployee bl = new BllEmployee();
            List<EmployeeATT> ll = JsonUtility.DeSerialize(args, typeof(List<EmployeeATT>)) as List<EmployeeATT>;
            // response.Message = bl.SaveParameter(ll, role);
            try
            {
                response.Message = bl.SaveEmployee(ll, role);
                if (response.Message != "")
                {
                    response.IsSucess = false;
                }
                else
                {
                    response.IsSucess = true;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}