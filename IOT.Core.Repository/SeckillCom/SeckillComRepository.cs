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
            try
            {
                string sql = $"insert into SeckillCom values (null,{a.ActivityId},{a.CommodityId},'{a.SeckillTitle}','{a.SeckillRemaek}',{a.SeckillModel},'{a.Job}',{a.TackTime},'{a.ActionDate}',{a.State},25,3)";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        //删除
        public int DelSeckillCom(int id)
        {
            try
            {
                string sql = $"delete from SeckillCom where SeckillComId={id}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        //修改状态
        public int UptState(int id)
        {
            try
            {
                IOT.Core.Model.SeckillCom ls = DapperHelper.GetList<IOT.Core.Model.SeckillCom>($"select * from SeckillCom where SeckillComId={id}").FirstOrDefault();
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
            catch (Exception)
            {

                throw;
            }
           
        }

        //显示
        public List<Model.V_SeckillCom> ShowSeckillCom()
        {
            try
            {
                string sql = "select * from V_SeckillCom";
                return DapperHelper.GetList<IOT.Core.Model.V_SeckillCom>(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        //修改
        public int UptSeckillCom(Model.SeckillCom a)
        {
            try
            {
                string sql = $"update SeckillCom set SeckillTitle='{a.SeckillTitle}',SeckillRemaek='{a.SeckillRemaek}',State={ a.State},SeckilPrice={ a.SeckilPrice} where SeckillComId={a.SeckillComId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
