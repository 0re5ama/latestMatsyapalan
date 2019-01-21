using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTILITY;
using AttFishary;
using BllFishary;

namespace Matshyapalan.Handler.Fishery
{
    /// <summary>
    /// Summary description for FishSizeSetupHandler
    /// </summary>
    public class FishSizeSetupHandler : BaseHandler
    {

        public object GetFishCategoryType(int ExpItmId, string Visibility, string p_rc, string role)
        {
            BllFishSizeSetup objBll = new BllFishSizeSetup();

            JsonResponse response = new JsonResponse();
            try
            {
                response.ResponseData = objBll.GetFishCategoryType(ExpItmId, Visibility, p_rc, role);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }

        public object SaveFishSize(string args, string role)
        {

            JsonResponse response = new JsonResponse();
            //if (token == CurrentToken())
            //{
            BllFishSizeSetup objBll = new BllFishSizeSetup();
           List<FishSizeATT> ll = JsonUtility.DeSerialize(args, typeof(List<FishSizeATT>)) as List<FishSizeATT>;
            // response.Message = bl.SaveParameter(ll, role);
            try
            {
                 response.ResponseData = objBll.SaveFishSize(ll, role);
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

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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