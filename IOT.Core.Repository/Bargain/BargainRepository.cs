using IOT.Core.Common;
using IOT.Core.IRepository.Bargain;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Bargain
{
    public class BargainRepository : IBargainRepository
    {
        //添加
        public int AddBargain(Model.Bargain a)
        {
            try
            {
                string sql = $"insert into Bargain values (null,{a.CommodityId},2,{a.PeopleNum},{a.KNum},'{a.BeginDate}','{a.EndDate}',{a.Astrict},'{a.Job}',{a.ActionState},7,5,6,7,'{a.BargainName}','{a.BargainRemark}',{a.Template},100,{a.Sort},36)";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        //显示砍价列表
        public List<Model.V_Bargain> BargainShow()
        {
            try
            {
                string sql = "select * from V_Bargain";
                return DapperHelper.GetList<Model.V_Bargain>(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //删除
        public int DelBargain(string id)
        {
            string sql = $"delete from Bargain where BargainId={id}";
            return DapperHelper.Execute(sql);
        }

        //反填
        public V_Bargain FT(int id)
        {
            string sql = $"select * from V_Bargain where BargainId={id}";
            return DapperHelper.GetList<Model.V_Bargain>(sql).First();
        }

        //显示砍价商品
        public List<Model.Bargain> ShowBargain()
        {
            string sql = "select * from Bargain a join Commodity b on a.CommodityId=b.CommodityId";
            return DapperHelper.GetList<Model.Bargain>(sql);
        }

        //修改
        public int UptBargain(Model.Bargain a)
        {
            string sql = $"update Bargain set MinPrice={a.MinPrice},BargainName='{a.BargainName}',BargainRemark='{a.BargainRemark}',BargainSum={a.BargainSum},ActionState={a.ActionState}  where BargainId={a.BargainId}";
            return DapperHelper.Execute(sql);
        }
        

        //修改状态
        public int UptSt(int id)
        {
            IOT.Core.Model.Bargain ls = DapperHelper.GetList<IOT.Core.Model.Bargain>($"select* from Bargain a join Commodity b on a.CommodityId=b.CommodityId join Users c on a.UserId=c.UserId where BargainId={id}").FirstOrDefault();
            if (ls.ActionState == 0)
            {
                ls.ActionState = 1;
            }
            else
            {
                ls.ActionState = 0;
            }
            string sql = $"update Bargain set ActionState={ls.ActionState} where BargainId={id}";
            return DapperHelper.Execute(sql);
        }
    }
}
