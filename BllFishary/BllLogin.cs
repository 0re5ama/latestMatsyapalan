using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttFishary;
using DllFishary;

namespace BllFishary
{
   public class BllLogin
    {
        public string SaveParameter(LoginAtt obj, string role)
        {
            try
            {
                LoginDll dllparameter = new LoginDll();
                return dllparameter.SaveParameter(obj, role);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public string SaveUser(List<LoginAtt> obj, string role)
        {
            try
            {
                LoginDll dllparameter = new LoginDll();
                return dllparameter.SaveUser(obj, role);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public List<LoginAtt> GetUser()
        {
            try
            {
                LoginDll dllparameter = new LoginDll();
                return dllparameter.GetUser();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public string DeleteUser(string useID)
        {
            try
            {
                LoginDll dllparameter = new LoginDll();
                return dllparameter.DeleteUser(useID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }


}
