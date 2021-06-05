using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Bargain
{
    public interface IBargainRepository
    {
        //添加
        int AddBargain(IOT.Core.Model.Bargain a);

        //显示砍价商品
        List<IOT.Core.Model.Bargain> ShowBargain();

        //显示砍价列表
        List<IOT.Core.Model.V_Bargain> BargainShow(int days = 0);

        //删除
        int DelBargain(string id);

        //修改
        int UptBargain(IOT.Core.Model.Bargain a);

        //反填
        IOT.Core.Model.V_Bargain FT(int id);

        //修改状态
        int UptSt(int id);
    }
}
