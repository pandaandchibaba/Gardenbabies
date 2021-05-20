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
            string sql = $"insert into Bargain values (null,{a.CommodityId},{a.PeopleNum},{a.KNum},'{a.BeginDate}','{a.EndDate}',{a.Astrict},{a.ActionState},{a.PartNum},{a.MinPrice},{a.SurplusNum},{a.SurplusBargain},'{a.BargainName}','{a.BargainRemark}',{a.Template},{a.LimitNum},{a.BargainSum})";
            return DapperHelper.Execute(sql);
        }

        //显示砍价列表
        public List<Model.V_Bargain> BargainShow()
        {
            string sql = "select * from V_Bargain";
            return DapperHelper.GetList<Model.V_Bargain>(sql);
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
            string sql = $"update Bargain set PeopleNum={a.PeopleNum},KNum={a.KNum},Astrict={a.Astrict},PartNum={a.PartNum},MinPrice={a.MinPrice},SurplusNum={a.SurplusNum},SurplusBargain={a.SurplusBargain},BargainName='{a.BargainName}',BargainRemark='{a.BargainRemark}',Template={a.Template},LimitNum={a.LimitNum},BargainSum={a.BargainSum}  where BargainId={a.BargainId}";
            return DapperHelper.Execute(sql);
        }

        public int UptSt(int id)
        {
            throw new NotImplementedException();
        }
    }
}
