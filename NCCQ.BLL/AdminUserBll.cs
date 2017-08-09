using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using NCCQ.DAL;

namespace NCCQ.BLL
{
    public class AdminUserBll
    {
        public T_AdminUser GetModel(int Id)
        {
            return new T_AdminUserDal().GetModel(Id);
        }
    }
}
