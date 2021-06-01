using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.GroupBooking
{
    public interface IGroupBookingRepository
    {
        //添加
        int AddGroupBooking(IOT.Core.Model.GroupBooking a);

        //显示
        List<IOT.Core.Model.V_GroupBooking> ShowGroupBooking();

        //删除
        int DelGroupBooking(string id);

        //反填
        IOT.Core.Model.V_GroupBooking FTV_GroupBooking(int id);

        //修改
        int UptGroupBooking(IOT.Core.Model.GroupBooking a);

        //修改状态
        int UptSt(int id);
    }
}
