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

        //删除
        public int DelColonel(string id)
        {
            throw new NotImplementedException();
        }

        public Model.Colonel FT1(int id)
        {
            string sql = $"select  * from colonel where ColonelID={id} ";
            return DapperHelper.GetList<IOT.Core.Model.Colonel>(sql).First();
        }

        //显示
        public List<Model.Commodity> GetCommodities()
        {
            string sql = "select CommodityPic,CommodityName,ShopPrice from Commodity";
            return DapperHelper.GetList<Model.Commodity>(sql);
        }
       
        public List<Model.Users> GetUsers()
        {
            string sql = "SELECT b.HeadPortrait,a.UserName,a.Phone from Users a join Colonel b on a.ColonelID =b.ColonelID ";
            return DapperHelper.GetList<Model.Users>(sql);
        }
   
        public List<Model.Colonel> ShowColonel()
        {
            string sql = "select  * from colonel";
            return DapperHelper.GetList<Model.Colonel>(sql);
        }
        //商品显示
        public int UptColonel(Model.Colonel a)
        {
            string sql = $"Update Colonel set NickName= '{a.NickName}',Sex='{a.Sex}',Phone='{a.Phone}',ColonelName='{a.ColonelName}',MemberNum='{a.MemberNum}',PColonelId='{a.PColonelId}',Region='{a.Region}',Estate='{a.Estate}',Address='{a.Address}',Coordinates='{a.Coordinates}',RegisterTime='{a.RegisterTime}',Integral='{a.Integral}',Saleroom='{a.Saleroom}',DeliveryStatus='{a.DeliveryStatus}',Cost='{a.Cost}',Alipay='{a.Alipay}',BankSite='{a.BankSite}',CardName='{a.CardName}',BankCard='{a.BankCard}',HeadPortrait='{a.HeadPortrait}',CommIds='{a.CommIds}'where ColonelID ='{a.ColonelID}'";
            return DapperHelper.Execute(sql);
        }

  
    }
}
