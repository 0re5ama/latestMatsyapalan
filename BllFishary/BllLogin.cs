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
    }
}
