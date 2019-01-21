using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
//using System.Web.Script.Serialization;
using System.Reflection;
//using System.Web.SessionState;
//using System.ComponentModel;
//using NEWSECURITY.ATT;
//using COMMON.ATT;

namespace UTILITY
{
    # region Copyright
    /*
   *********************************************************************************
    Copyright © HRFA PCS System  2016
   *********************************************************************************
   Project              :HRFA PCS System  2016 
   File                 :BaseHandler.cs 
   Description          :This File contain the BaseHandler class
   *********************************************************************************
   <Name>                                          <Date>         <Version>
   shanjeev sah <shanjeev007@gmail.com>             2015.05.30      1.0.0                                                                    
   *********************************************************************************
    */
    # endregion

    public abstract partial class BaseHandler //: IHttpHandler, IRequiresSessionState
    {

        private HttpContext _context = null;
        public HttpContext context
        {
            get { return _context; }
            private set { _context = value; }
        }

        public virtual void HandleRequest() { }

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            //IntegratedTaxSystem.IntegratedTaxSystemServiceReference.User user = new IntegratedTaxSystem.IntegratedTaxSystemServiceReference.User();

            //if (context.Session["User"] == null)
            //{
            //    //context.Response.Redirect("/Home.aspx");
            //    JsonResponse response1 = new JsonResponse();

            //    response1.Message = "Login Failed !!!";
            //    response1.IsSucess = false;

            //    HttpContext.Current.Response.ContentType = "application/json";
            //    HttpContext.Current.Response.Write(response1);

            //    return;
            //    //return JsonUtility.Serialize(response);
            //}


            //if (context.Session["User"] == null)
            //{
            //    user.UserID = "ITS";
            //    user.Password = "WEBUSERT0!RD";
            //    context.Session["User"] = user;
            //}


            //ControllerBase controller = new ControllerBase();
            //if (controller.Message != string.Empty)
            //{
            //    context.Response.Write(controller.Message);
            //    context.Response.End();
            //}

            // it's possible to the requestor to be able to handle everything himself, overriding all this implemention
            string handleRequest = context.Request["handlerequest"];
            if (!string.IsNullOrEmpty(handleRequest) && handleRequest.ToLower() == "true")
            {
                HandleRequest();
                return;
            }

            var ajaxCall = new AjaxCallSignature(context);

            //context.Response.ContentType = string.Empty;
            if (!string.IsNullOrEmpty(ajaxCall.returnType))
            {
                switch (ajaxCall.returnType)
                {
                    case "json":
                        context.Response.ContentType = "application/json";
                        break;
                    case "xml":
                        context.Response.ContentType = "application/xml";
                        break;
                    case "jpg":
                    case "jpeg":
                    case "image/jpg":
                        context.Response.ContentType = "image/jpg";
                        break;
                    default:
                        break;
                }
            }

            // call the requested method
            object result = ajaxCall.Invoke(this, context);

            // if neither on the arguments or the actual method the content type was set then make sure to use the default content type
            if (string.IsNullOrEmpty(context.Response.ContentType) && !SkipContentTypeEvaluation)
            {
                context.Response.ContentType = DefaultContentType();
            }

            // only skip transformations if the requestor explicitly said so
            if (result == null)
            {
                context.Response.Write(string.Empty);
            }
            else if (!SkipDefaultSerialization)
            {
                switch (context.Response.ContentType.ToLower())
                {
                    case "application/json":
                        //JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        //string json = jsonSerializer.Serialize(result);
                        //context.Response.Write(json);
                        context.Response.Write(result);
                        break;
                    case "application/xml":
                        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(result.GetType());
                        StringBuilder xmlSb = new StringBuilder();
                        System.Xml.XmlWriter xmlWriter = System.Xml.XmlWriter.Create(xmlSb);
                        xmlSerializer.Serialize(xmlWriter, result);
                        context.Response.Write(xmlSb.ToString());
                        break;
                    case "text/html":
                        context.Response.Write(result);
                        break;
                    default:
                        throw new Exception(string.Format("Unsuported content type [{0}]", context.Response.ContentType));
                }
            }
            else
            {
                context.Response.Write(result);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //public string GetUser()
        //{
        //    string userID = "";
        //    string roleID = "";
        //    string userType = "";
        //    Int32? offCode;
        //    string offcode = "";

        //    if (HttpContext.Current.Session["User"] != null)
        //    {
        //        userID = ((ATTUser)HttpContext.Current.Session["User"]).UserID;
        //        roleID = ((ATTUser)HttpContext.Current.Session["User"]).RoleID;
        //        userType = ((ATTUser)HttpContext.Current.Session["User"]).UserType;
        //        offCode = ((ATTUser)HttpContext.Current.Session["User"]).OfficeCode;
        //        offcode = offCode.ToString();
                
        //    }
        //    return userID + "~" + roleID + "~" + userType + "~" + offcode;
        //}

        //public List<ATTMenu> GetLoginMenus()
        //{
        //    List<ATTMenu> lstMenu = new List<ATTMenu>();

        //    if (HttpContext.Current.Session["User"] != null)
        //        lstMenu = ((ATTUser)HttpContext.Current.Session["User"]).Menus;

        //    return lstMenu;
        //}

        //public string GetPortalUser()
        //{
        //    string userID = "";
        //    if (HttpContext.Current.Session["PUser"] != null)
        //      userID = HttpContext.Current.Session["PUser"].ToString();

        //    return userID;
        //}

        //public string GetPortalUserBFIID()
        //{
        //    Int64? EmpID = null;
        //    Int64? OfficeCD = null;
        //    string UserID = "";
        //    string userInfo = "";
        //    if (HttpContext.Current.Session["PUser"] != null)
        //            EmpID = ((ATTPortalLogin)HttpContext.Current.Session["PUser"]).EmpID;
        //            OfficeCD = ((ATTPortalLogin)HttpContext.Current.Session["PUser"]).OfficeCD;
        //        UserID = ((ATTPortalLogin)HttpContext.Current.Session["PUser"]).UserID;

        //        userInfo = EmpID.ToString() + "," +OfficeCD.ToString() + "," + UserID;
        //    return userInfo;
        //}

        //public int? GetOfficeCode()
        //{
        //    int? offCode = null;

        //    if (HttpContext.Current.Session["User"] != null)
        //        offCode = ((ATTUser)HttpContext.Current.Session["User"]).OfficeUser.OfficeCode;

        //    return offCode;
        //}

        //public string CurrentToken()
        //{
        //    string token = "";
        //    if (HttpContext.Current.Session["Token"] != null)
        //        token = HttpContext.Current.Session["Token"].ToString();
        //    else
        //        token = "-1";

        //    return token;
        //    //return "1";
        //}


        //public bool IsValidUser()
        //{
        //    bool flag = false;

        //    if (HttpContext.Current.Session["User"] != null)
        //    {
        //        flag = true;
        //    }
        //    return flag;
        //}

        //public bool IsValidPortalUser()
        //{
        //    bool flag = false;

        //    if (HttpContext.Current.Session["PUser"] != null)
        //        flag = true;

        //    return flag;
        //}


        /// <summary>
        /// Returns the default content type returned by the handler.
        /// </summary>
        /// <returns></returns>
        public virtual string DefaultContentType()
        {
            return "application/json";
        }

        public void SetResponseContentType(string value)
        {
            context.Response.ContentType = value;
        }

        /// <summary>
        /// Setting this to false will make the handler to respond with exacly what the called method returned.
        /// If true the handler will try to serialize the content based on the ContentType set.
        /// </summary>
        public bool SkipDefaultSerialization { get; set; }

        /// <summary>
        /// Setting this to true will avoid the handler to change the content type wither to its default value or to its specified value on the request.
        /// This is useful if you're handling the request yourself and need to specify it yourself.
        /// </summary>
        public bool SkipContentTypeEvaluation { get; set; }

        /// <summary>
        /// Prints an help page discribng the available methods on this handler.
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            context.Response.ContentType = "text/html";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<style>");
            sb.AppendLine(".MainHeader { background-color: FFFFE0; border: 1px dashed red; padding: 0 10 0 10; }");
            sb.AppendLine("h3 { background-color: #DCDCDC; }");
            sb.AppendLine("ul { background-color: #FFFFFF; }");
            sb.AppendLine(".type { color: gray; }");
            sb.AppendLine("</style>");

            sb.AppendLine("<div class='MainHeader'><h2>Handler available methods</h2></div>");

            MethodInfo[] methods = this.GetType().GetMethods();	// All methods found on this type
            MethodInfo[] excludeMethods = this.GetType().BaseType.GetMethods();	// methods from the base class are not to be shown

            foreach (var m in methods)
            {
                // do nothing if the current method belongs to the base type.
                // I'm not supporting overrides here, I'm only searching by name, if more than one method with the same name exist they all will be ignored.
                if (excludeMethods.FirstOrDefault(c => c.Name == m.Name) != null)
                    continue;

                ParameterInfo[] parameters = m.GetParameters();

                bool RequiresAuthentication = false;

                sb.AppendLine("<h3>" + m.Name + (RequiresAuthentication ? " <span style=\"color:#f00\">[Requires Authentication]</span>" : string.Empty) + "</h3>");

                sb.AppendLine("<table><tr><td width=\"250px\">");
                sb.AppendLine("<table width=\"100%\">");
                foreach (var p in parameters)
                {
                    sb.AppendLine("<tr><td>" + p.Name + "</td><td><span class='type'>[" + p.ParameterType.ToString() + "]</span></td></tr>");
                }

                sb.AppendLine("</table>");

                sb.AppendLine("</td><td style=\"border-left: 1px dashed #DCDCDC; padding-left: 8px;\">");

                string getJSONSample = "<pre>$.getJSON(\n\t'" + context.Request.Url.LocalPath + "', \n\t{method: \"" + m.Name + "\", returntype: \"json\", args: {";
                foreach (var p in m.GetParameters())
                {
                    getJSONSample += " " + p.Name + ": \"\",";
                }
                getJSONSample = getJSONSample.TrimEnd(',') + " ";
                getJSONSample += "}}, \n\tfunction() { alert('Success!'); });</pre>";
                sb.AppendLine(getJSONSample);

                sb.AppendLine("</td>");
                sb.AppendLine("</tr></table>");
            }
            return sb.ToString();
        }

        public JsonResponse Execute(Func<JsonResponse> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                JsonResponse response = new JsonResponse();
                response.IsSucess = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public string Execute(Func<string> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
