using IOT.Core.Common;
using IOT.Core.IRepository.GroupBooking;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.GroupBooking
{
    public class GroupBookingRepository : IGroupBookingRepository
    {
        //添加
        public int AddGroupBooking(Model.GroupBooking a)
        {
            string sql = $"insert into  DelGroupBooking values({a.ColonelID},{a.CommodityId},'{a.GroupBookingName}','{a.GroupBookingRemark}','{a.GroupBookingUnit}','{a.GroupBookingSdate}','{a.GroupBookingZdate}',{ a.GroupBookingResults},{ a.GroupBookingNumber},{ a.GroupBookingSellLimitNum},{ a.GroupBookingSort},{ a.GroupBookingTemplate},{ a.GroupBookingState},{ a.GroupBookingPrice},{ a.GroupBookingLimitNum}) ";
            return DapperHelper.Execute(sql);
        }

        //删除
        public int DelGroupBooking(string id)
        {
            string sql = $"delete from DelGroupBooking where GroupBookingID={id}";
            return DapperHelper.Execute(sql);
        }

        //显示
        public List<Model.V_GroupBooking> ShowGroupBooking()
        {
            string sql = "select * from V_GroupBooking";
            return DapperHelper.GetList<Model.V_GroupBooking>(sql);
        }

        //修改
        public int UptGroupBooking(Model.GroupBooking a)
        {
            string sql = $"update  DelGroupBooking set ColonelID={a.ColonelID},CommodityId={a.CommodityId},GroupBookingName='{a.GroupBookingName}',GroupBookingRemark='{a.GroupBookingRemark}',GroupBookingUnit='{a.GroupBookingUnit}',GroupBookingSdate='{a.GroupBookingSdate}',GroupBookingZdate='{a.GroupBookingZdate}',GroupBookingResults={ a.GroupBookingResults},GroupBookingNumber={ a.GroupBookingNumber},GroupBookingSellLimitNum={ a.GroupBookingSellLimitNum},GroupBookingSort={ a.GroupBookingSort},GroupBookingTemplate={ a.GroupBookingTemplate},GroupBookingState={ a.GroupBookingState},GroupBookingPrice={ a.GroupBookingPrice},GroupBookingLimitNum={ a.GroupBookingLimitNum} where GroupBookingID={a.GroupBookingID}";
            return DapperHelper.Execute(sql);
        }

    }
}
