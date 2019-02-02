using ATTEmployee;
using DLEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEmployee
{
   public class BllEmployee
    {
        public List<EmployeeATT> GetEmployee(int ExpItmId, string Visibility, string p_rc, string role)
        {
            try
            {
                DLLEmployee obj = new DLLEmployee();
                return obj.GetEmployee(ExpItmId, Visibility, p_rc, role);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public string DeleteEmployee(int EmpId, string Visibility, string p_rc, string role)
        {
            try
            {
                DLLEmployee obj = new DLLEmployee();
                return obj.DeleteEmployee(EmpId, Visibility, p_rc, role);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public string SaveEmployee(List<EmployeeATT> obj, string role)
        {
            try
            {
                DLLEmployee dllparameter = new DLLEmployee();
                return dllparameter.SaveEmployee(obj, role);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
