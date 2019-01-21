using AttFishary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllFishary;

namespace BllFishary
{
  public  class BllFishSizeSetup
    {

        public List<FishSizeATT> GetFishCategoryType(int ExpItmId, string Visibility, string p_rc, string role)
        {
            try
            {
                DLLFishSizeSetup obj = new DLLFishSizeSetup();
                return obj.GetFishCategoryType(ExpItmId, Visibility, p_rc, role);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public string SaveFishSize(List<FishSizeATT> args, string role)
        {
            try
            {
                DLLFishSizeSetup obj = new DLLFishSizeSetup();
                return obj.SaveFishSize(args, role);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        //public string SaveExpenseHeadType(List<ATTExpenseHeadType> lst, string role)
        //{
        //    try
        //    {
        //        DLLExpenseHeadType objSaveDLL = new DLLExpenseHeadType();
        //        return objSaveDLL.SaveExpenseHeadType(lst, role);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //}




        //public string DeleteExpenseHeadType(int? ExpenseHeadTypeID, string role)
        //{
        //    try
        //    {
        //        DLLExpenseHeadType obj = new DLLExpenseHeadType();
        //        return obj.DeleteOfficeType(ExpenseHeadTypeID, role);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //}


    }
}
