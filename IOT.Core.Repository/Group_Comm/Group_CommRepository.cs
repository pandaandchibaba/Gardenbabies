using IOT.Core.Common;
using IOT.Core.IRepository.Group_Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Group_Comm
{
    public class Group_CommRepository : IGroup_CommRepository
    {
        //添加
        public int AddGroup_Comm(Model.Group_Comm a)
        {
            string sql = $"insert into Group_Comm values (null,{a.ColonelId},{a.GroupBookingID},{a.Group_State},{a.PeopleNum})";
            return DapperHelper.Execute(sql);
        }

        //删除
        public int DelGroup_Comm(string id)
        {
            string sql = $"delete from Group_Comm where Group_CommId = {id}";
            return DapperHelper.Execute(sql);
        }

        //反填
        public Model.Group_Comm FT(int id)
        {
            string sql = $"select * from Group_Comm where Group_CommId={id}";
            return DapperHelper.GetList<Model.Group_Comm>(sql).FirstOrDefault();
        }

        //显示
        public List<Model.V_GC> ShowGroup_Comm()
        {
            string sql = "select * from V_GC";
            return DapperHelper.GetList<IOT.Core.Model.V_GC>(sql);
            
        }

        //修改状态
        public int UptSt(int id)
        {
            IOT.Core.Model.Group_Comm ls = DapperHelper.GetList<IOT.Core.Model.Group_Comm>($"select * from Group_Comm a join Colonel b on a.ColonelId=b.ColonelID join GroupBooking c on a.GroupBookingID=c.GroupBookingID where Group_CommId ={id}").FirstOrDefault();
            if (ls.Group_State == 1)
            {
                ls.Group_State = 0;
            }
            else
            {
                ls.Group_State = 1;
            }
            string sql = $"update Group_Comm set Group_State={ls.Group_State} where Group_CommId ={id}";
            return DapperHelper.Execute(sql);
        }
    }
}
