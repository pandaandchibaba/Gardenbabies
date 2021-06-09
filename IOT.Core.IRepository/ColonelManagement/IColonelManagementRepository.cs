using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.ColonelManagement
{
   public interface IColonelManagementRepository
    {
        //显示
        List<IOT.Core.Model.ColonelManagement> GetColonelManagements();
        //修改状态
        int Uptdata(string id);
    }
}
