using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.StaffAuthority
{
   public interface IStaffAuthorityRepository
    {
        //编辑角色权限
        int UptAut(int rid, string menuid);
        //反填/显示角色权限信息
        string FanMenu(int rid);
    }
}
