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
            string sql = $"insert into  GroupBooking values(null,{a.ColonelID},{a.CommodityId},'{a.GroupBookingName}','{a.GroupBookingRemark}','{a.GroupBookingUnit}','{a.GroupBookingSdate}','{a.GroupBookingZdate}',{ a.GroupBookingResults},{ a.GroupBookingNumber},{ a.GroupBookingSellLimitNum},{ a.GroupBookingSort},{ a.GroupBookingTemplate},{ a.GroupBookingState},{ a.GroupBookingPrice},{ a.GroupBookingLimitNum}) ";
            return DapperHelper.Execute(sql);
        }

        //删除
        public int DelGroupBooking(string id)
        {
            string sql = $"delete from GroupBooking where GroupBookingID={id}";
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
            string sql = $"update  GroupBooking set ColonelID={a.ColonelID},CommodityId={a.CommodityId},GroupBookingName='{a.GroupBookingName}',GroupBookingRemark='{a.GroupBookingRemark}',GroupBookingUnit='{a.GroupBookingUnit}',GroupBookingSdate='{a.GroupBookingSdate}',GroupBookingZdate='{a.GroupBookingZdate}',GroupBookingResults={ a.GroupBookingResults},GroupBookingNumber={ a.GroupBookingNumber},GroupBookingSellLimitNum={ a.GroupBookingSellLimitNum},GroupBookingSort={ a.GroupBookingSort},GroupBookingTemplate={ a.GroupBookingTemplate},GroupBookingState={ a.GroupBookingState},GroupBookingPrice={ a.GroupBookingPrice},GroupBookingLimitNum={ a.GroupBookingLimitNum} where GroupBookingID={a.GroupBookingID}";
            return DapperHelper.Execute(sql);
        }
        
        //修改状态
        public int UptSt(int id)
        {
            IOT.Core.Model.GroupBooking ls = DapperHelper.GetList<IOT.Core.Model.GroupBooking>($"select * from GroupBooking a join Colonel b on a.ColonelID=b.ColonelID join Commodity c on a.CommodityId=c.CommodityId where GroupBookingID={id}").FirstOrDefault();
            if (ls.GroupBookingState == 1)
            {
                ls.GroupBookingState = 0;
            }
            else
            {
                ls.GroupBookingState = 1;
            }
            string sql = $"update  GroupBooking set GroupBookingState={ls.GroupBookingState} where GroupBookingID={id}";
            return DapperHelper.Execute(sql);
        }
    }
}
