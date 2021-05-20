using IOT.Core.Common;
using IOT.Core.IRepository.SeckillCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.SeckillCom
{
    public class SeckillComRepository : ISeckillComRepository
    {
        //添加
        public int AddSeckillCom(Model.SeckillCom a)
        {
            string sql = $"insert into SeckillCom values (null,{a.ActivityId},{a.CommodityId},'{a.SeckillTitle}','{a.SeckillRemaek}',{a.SeckillModel},{a.TackTime},'{a.ActionDate}',{a.State},{a.SeckilPrice},{a.LimitNum})";
            return DapperHelper.Execute(sql);
        }

        //删除
        public int DelSeckillCom(string id)
        {
            string sql = $"delete from SeckillCom where SeckillComId={id}";
            return DapperHelper.Execute(sql);
        }

        //修改状态
        public int UptSt(int id)
        {
            IOT.Core.Model.SeckillCom ls = DapperHelper.GetList<IOT.Core.Model.SeckillCom>($"select * from SeckillCom a join Commodity b on a.CommodityId=b.CommodityId join Activity c on a.ActivityId=c.ActivityId where SeckillComId={id}").FirstOrDefault();
            if (ls.State == 0)
            {
                ls.State = 1;
            }
            else
            {
                ls.State = 0;
            }
            string sql = $"update SeckillCom set State={ls.State} where SeckillComId={id}";
            return DapperHelper.Execute(sql);
        }

        //显示
        public List<Model.SeckillCom> ShowSeckillCom()
        {
            string sql = "select * from SeckillCom a join Commodity b on a.CommodityId=b.CommodityId join Activity c on a.ActivityId=c.ActivityId";
            return DapperHelper.GetList<IOT.Core.Model.SeckillCom>(sql);
        }

        //修改
        public int UptSeckillCom(Model.SeckillCom a)
        {
            string sql = $"update SeckillCom set ActivityId={ a.ActivityId},CommodityId={a.CommodityId},SeckillTitle='{a.SeckillTitle}',SeckillRemaek='{a.SeckillRemaek}',SeckillModel={ a.SeckillModel},TackTime={ a.TackTime},ActionDate='{a.ActionDate}',State={ a.State},SeckilPrice={ a.SeckilPrice},LimitNum={ a.LimitNum} where SeckillComId={a.SeckillComId}";
            return DapperHelper.Execute(sql);
        }
    }
}
