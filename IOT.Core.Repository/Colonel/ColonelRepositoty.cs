using IOT.Core.Common;
using IOT.Core.IRepository.Colonel;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Colonel
{
    public class ColonelRepositoty : IColonelRepository
    {
        public int ColoneluptGoods(int CommIds, int ColonelID)
        {
            string sql = $"Update Colonel set CommIds={CommIds} where ColonelID={ColonelID} ";
            return DapperHelper.Execute(sql);
        }

        //删除
        public int DelColonel(string id)
        {
            throw new NotImplementedException();
        }
        //反填
        public Model.Colonel FT1(int id)
        {
            string sql = $"select  * from colonel where ColonelID={id} ";
            return DapperHelper.GetList<IOT.Core.Model.Colonel>(sql).First();
        }

        /// <summary>
        /// 团长的显示查询
        /// </summary>
        /// <param name="address"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<V_Colonel> GetColonel(string address = "", string key = "")
        {
            //获取全部数据
            List<Model.V_Colonel> lst = DapperHelper.GetList<Model.V_Colonel>("select * from V_Colonel");
            lst = lst.Where(x => (string.IsNullOrEmpty(address) ? true : x.Address.Contains(address)) && (string.IsNullOrEmpty(key) ? true : (x.UserName.Contains(key) || x.Phone == key))).ToList();
            return lst;
        }

        public List<Model.Colonel> GetCommdit()
        {
            string sql = $"select b.CommodityId,b.CommodityPic,b.CommodityName,ShopPrice from Colonel a join Commodity b on a.CommIds=b.CommodityId ";
            return DapperHelper.GetList<Model.Colonel>(sql);
        }

        public int GetUser(int ColonelID, int UserId)
        {
            string sql = $"Update  Users set ColonelID={ColonelID} where UserId={UserId} ";
            return DapperHelper.Execute(sql);
        }

        ////商品显示
        //public List<Model.Commodity> GetCommodities()
        //{
        //    string sql = "select b.CommodityId,b.CommodityPic,b.CommodityName,ShopPrice from Colonel a join Commodity b on a.ColonelID=b.ColonelID";
        //    return DapperHelper.GetList<Model.Commodity>(sql);
        //}
        /// <summary>
        /// 团员显示
        /// </summary>
        /// <returns></returns>
        public List<Model.Users> GetUsers()
        {
            string sql = "SELECT a.ColonelID, b.HeadPortrait,a.UserName,a.Phone from Users a join Colonel b on a.ColonelID =b.ColonelID ";
            return DapperHelper.GetList<Model.Users>(sql);
        }
        /// <summary>
        /// 团长显示
        /// </summary>
        /// <returns></returns>
        public List<Model.Colonel> ShowColonel()
        {
            string sql = "select  * from colonel";
            return DapperHelper.GetList<Model.Colonel>(sql);
        }
        //修改状态
        public int Updates(int  id)
        {
            IOT.Core.Model.Colonel ls = DapperHelper.GetList<IOT.Core.Model.Colonel>($"select * from colonel  where ColonelID={id}").FirstOrDefault();
            if (ls.DeliveryStatus == 0)
            {
                ls.DeliveryStatus = 1;
            }
            else
            {
                ls.DeliveryStatus = 2; 
            }
            string sql = $"Update colonel set DeliveryStatus={ls.DeliveryStatus} where ColonelID={ls.ColonelID} ";
            return DapperHelper.Execute(sql);
        }


        //修改
        public int UptColonel(Model.Colonel a)
        {
            string sql = $"Update Colonel set NickName= '{a.NickName}',Sex='{a.Sex}',Phone='{a.Phone}',ColonelName='{a.ColonelName}',MemberNum='{a.MemberNum}',PColonelId='{a.PColonelId}',Region='{a.Region}',Estate='{a.Estate}',Address='{a.Address}',Coordinates='{a.Coordinates}',RegisterTime='{a.RegisterTime}',Integral='{a.Integral}',Saleroom='{a.Saleroom}',DeliveryStatus='{a.DeliveryStatus}',Cost='{a.Cost}',Alipay='{a.Alipay}',BankSite='{a.BankSite}',CardName='{a.CardName}',BankCard='{a.BankCard}',HeadPortrait='{a.HeadPortrait}',CommIds='{a.CommIds}'where ColonelID ='{a.ColonelID}'";
            return DapperHelper.Execute(sql);
        }


    }
}
