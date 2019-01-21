using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTILITY;
using BllFishary;
using AttFishary;

namespace Matshyapalan.Handler
{
    /// <summary>
    /// Summary description for LoginHandler
    /// </summary>
    public class LoginHandler : BaseHandler
    {

        public object SaveParameter(string args, string role)
        {
            JsonResponse response = new JsonResponse();
            //if (token == CurrentToken())
            //{
            BllLogin bl = new BllLogin();
             LoginAtt ll= JsonUtility.DeSerialize(args, typeof(LoginAtt)) as LoginAtt;
           // response.Message = bl.SaveParameter(ll, role);
            try
            {
                response.Message = bl.SaveParameter(ll, role);
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