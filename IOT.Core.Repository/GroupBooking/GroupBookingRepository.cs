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
            try
            {
                string sql = $"insert into  GroupBooking values(null,{a.ColonelID},{a.CommodityId},1,'{a.GroupBookingName}','{a.GroupBookingRemark}','{a.GroupBookingUnit}','{a.GroupBookingSdate}','{a.GroupBookingZdate}',{ a.GroupBookingResults},{ a.GroupBookingNumber},{ a.GroupBookingSellLimitNum},{ a.GroupBookingSort},{ a.GroupBookingTemplate},{ a.GroupBookingState},34,20) ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //删除
        public int DelGroupBooking(string id)
        {
            try
            {
                string sql = $"delete from GroupBooking where GroupBookingID={id}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //反填
        public V_GroupBooking FTV_GroupBooking(int id)
        {
            string sql = $"select * from V_GroupBooking where GroupBookingID={id}";
            return DapperHelper.GetList<Model.V_GroupBooking>(sql).First();
        }

        //显示
        public List<Model.V_GroupBooking> ShowGroupBooking()
        {
            try
            {
                string sql = "select * from V_GroupBooking";
                return DapperHelper.GetList<Model.V_GroupBooking>(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //修改
        public int UptGroupBooking(Model.GroupBooking a)
        {
            try
            {
                string sql = $"update  GroupBooking set GroupBookingName='{a.GroupBookingName}',GroupBookingRemark='{a.GroupBookingRemark}', GroupBookingState={a.GroupBookingState} ,GroupBookingNumber={ a.GroupBookingNumber}  where GroupBookingID={a.GroupBookingID}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //修改状态
        public int UptSt(int id)
        {
            try
            {
                IOT.Core.Model.GroupBooking ls = DapperHelper.GetList<IOT.Core.Model.GroupBooking>($"select * from V_GroupBooking where GroupBookingID={id}").FirstOrDefault();
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
