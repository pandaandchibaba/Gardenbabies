using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Roles
{
   public interface IRolesRepository
    {
        //显示
        List<IOT.Core.Model.Roles> GetRoles();
        //添加
        int AddRoles(IOT.Core.Model.Roles a);
        //删除
        int DeleteRoles(int id);
        //修改
        int UptRoles(IOT.Core.Model.Roles a);
        //反填
        IOT.Core.Model.Roles FT(int id);
    }
}
