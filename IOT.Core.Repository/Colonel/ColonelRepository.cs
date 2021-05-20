using IOT.Core.Common;
using IOT.Core.IRepository.Colonel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Colonel
{
    public class ColonelRepository : IColonelRepository
    {/// <summary>
    /// 添加
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
        public int AddColonel(Model.Colonel a)
        {
            string sql = $"insert into Colonel values(null,'{a.NickName}','{a.Sex}','{a.Phone}','{a.ColonelName}','{a.MemberNum}','{a.PColonelId}','{a.Region}','{a.Estate}','{a.Address}','{a.Coordinates}','{a.RegisterTime}','{a.Integral}','{a.Saleroom}','{a.DeliveryStatus}','{a.Cost}','{a.Alipay}','{a.BankSite}','{a.CardName}','{a.BankCard}','{a.HeadPortrait}','{a.CommIds}')";
            return DapperHelper.Execute(sql);
        }

        public int DelColonel(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Model.Colonel> ShowColonel()
        {
            string sql = "select * from Colonel";
            return DapperHelper.GetList<Model.Colonel>(sql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UptColonel(Model.Colonel a)
        {
            string sql = $"Update Colonel set  NickName='{a.NickName}',Sex='{a.Sex}',Phone='{a.Phone}',ColonelName='{a.ColonelName}',MemberNum='{a.MemberNum}',PColonelId='{a.PColonelId}',Region='{a.Region}',Estate='{a.Estate}',Address='{a.Address}',.Coordinates='{a.Coordinates}',RegisterTime='{a.RegisterTime}',Integral='{a.Integral}',Saleroom='{a.Saleroom}',DeliveryStatus='{a.DeliveryStatus}',Cost='{a.Cost}',Alipay='{a.Alipay}',BankSite='{a.BankSite}',CardName='{a.CardName}',BankCard='{a.BankCard}'HeadPortrait='{a.HeadPortrait}',CommIds='{a.CommIds}')";
            return DapperHelper.Execute(sql);
        }
    }
}
