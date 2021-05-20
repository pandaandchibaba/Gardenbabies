using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Group_Comm
{
    public interface IGroup_CommRepository
    {
        //添加
        int AddGroup_Comm(IOT.Core.Model.Group_Comm a);

        //显示砍价商品
        List<IOT.Core.Model.V_GC> ShowGroup_Comm();

        //删除
        int DelGroup_Comm(string id);
       
        //反填
        IOT.Core.Model.Group_Comm FT(int id);

        //修改状态
        int UptSt(int id);
    }
}
