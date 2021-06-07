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
        public enum Days
        {
            全部 = 0,
            今天 = 1,
            昨天 = 2,
            最近七天 = 3,
            最近三十天 = 4,
            本月 = 5,
            本年 = 6,
        }
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
        public List<Model.V_GroupBooking> ShowGroupBooking(int days = 0)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select * from V_GroupBooking");
                Days day = (Days)days;
                switch (day)
                {
                    case Days.今天:
                        sql.Append(" where Days < 1");
                        break;
                    case Days.昨天:
                        sql.Append(" where Days = 1");
                        break;
                    case Days.最近七天:
                        sql.Append(" where Days <= 7");
                        break;
                    case Days.最近三十天:
                        sql.Append(" where Days <= 30");
                        break;
                    case Days.本月:
                        sql.Append($" where months ={DateTime.Now.Month} and years={DateTime.Now.Year}");
                        break;
                    case Days.本年:
                        sql.Append($" where years ={DateTime.Now.Year}");
                        break;
                    default:
                        break;
                }
                //获取全部数据
                List<V_GroupBooking> lst = DapperHelper.GetList<V_GroupBooking>(sql.ToString());
                return lst;
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
