using IOT.Core.Common;
using IOT.Core.IRepository.OrderInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OrderInfo
{
    public  class OrderInfoRepository : IOrderInfoRepository
    {
        string redisKey;
        List<IOT.Core.Model.OrderInfo> lt = new List<Model.OrderInfo>();
        RedisHelper<Model.OrderInfo> rd = new RedisHelper<Model.OrderInfo>();

        public OrderInfoRepository()
        {
            redisKey = "order_list";
            lt = rd.GetList(redisKey);
        }
        /// <summary>
        /// 三表联查各种数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="state"></param>
        /// <param name="end"></param>
        /// <param name="tui"></param>
        /// <param name="dingt"></param>
        /// <param name="uid"></param>
        /// <param name="cname"></param>
        /// <param name="ziti"></param>
        /// <returns></returns>
        public List<Model.OrderInfo> GetOrderInfos(string name, int sendway, string state, string end, int tui, int dingt, int uid, string cname, string ziti)
        {
            if (lt==null||lt.Count==0)
            {
                string sql = $@"select b.CommodityName ,b.CommodityPic ,b.ShopPrice ,b.SId ,
             c.NickName ,c.UserName ,c.Phone ,c.Address ,a.* from OrderInfo a
            join Commodity b on a.CommodityId = b.CommodityId
            join Users c on a.UserId = c.UserId 
            join Colonel d on c.ColonelID=d.ColonelID";
                lt = DapperHelper.GetList<Model.OrderInfo>(sql);
                rd.SetList(lt, redisKey);
            }
            return lt;

           
        }

        public int Delete(string ids)
        {

            string sql = $@"delete from OrderInfo where Orderid={ids}";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'删除订单ID为{ids}的订单',NOW(),'订单表')");
            int i=DapperHelper.Execute(sql);
            if (i>0)
            {
                string[] arr = ids.Split(',');
                foreach (var item in arr)
                {
                    Model.OrderInfo orderInfo = lt.FirstOrDefault(x => x.Orderid.ToString() == item);
                    lt.Remove(orderInfo);
                }
                rd.SetList(lt, redisKey);
            }
            return i;
        }

       

        public int Insert(Model.OrderInfo Model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询订单表
        /// </summary>
        /// <returns></returns>
        public List<Model.OrderInfo> Query(int pm,int ps,int sts)
        {
            if (lt==null||lt.Count==0)
            {
                string sql = $@"select a.*,b.*,c.*,d.*
                from OrderInfo a
                join Commodity b on a.CommodityId = b.CommodityId
                join Users c on a.UserId = c.UserId 
                join Colonel d on c.ColonelID=d.ColonelID";

                lt = DapperHelper.GetList<Model.OrderInfo>(sql);
                rd.SetList(lt, redisKey);
            }
            return lt;
            
        }

        public int UptRemark(Model.OrderInfo Model)
        {
            string sql = $"UPDATE OrderInfo SET Remark='{Model.Remark}' where Orderid={Model.Orderid}";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改备注订单ID为{Model.Orderid}的订单',NOW(),'订单表')");
            int i= DapperHelper.Execute(sql);
            if (i>0)
            {
                lt[lt.IndexOf(lt.First(x => x.Orderid == Model.Orderid))] = Model;
                rd.SetList(lt, redisKey);
                return i;
            }
            else
            {
                return 0;
            }
        }

        public int UptSendWay(Model.OrderInfo Model)
        {
            string sql = $"UPDATE OrderInfo SET SendWay='{Model.SendWay}' where Orderid={Model.Orderid}";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改送货方式订单ID为{Model.Orderid}的订单',NOW(),'订单表')");
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                lt[lt.IndexOf(lt.First(x => x.Orderid == Model.Orderid))] = Model;
                rd.SetList(lt, redisKey);
                return i;
            }
            else
            {
                return 0;
            }
        }

        public int UptOrderState(Model.OrderInfo Model)
        {
            string sql = $"UPDATE OrderInfo SET OrderState='{Model.OrderState}' where Orderid={Model.Orderid}";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改状态订单ID为{Model.Orderid}的订单',NOW(),'订单表')");
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                lt[lt.IndexOf(lt.First(x => x.Orderid == Model.Orderid))] = Model;
                rd.SetList(lt, redisKey);
                return i;
            }
            else
            {
                return 0;
            }
        }

        public int insert(Model.OrderInfo orderInfo)
        {
            string sql = $"SELECT CONCAT(DATE_FORMAT(now(), '%Y%m%d%H%i%s'),lpad(round(round(rand(),4)*1000),4,'0'))";
            var num = DapperHelper.Exescalar(sql);
            string sqla = $"SELECT CONCAT(DATE_FORMAT(now(), '%Y%m%d%H%i%s'),lpad(round(round(rand(),4)*1000),4,'0'))";
            var nums = DapperHelper.Exescalar(sqla);
            string sqls = $"insert INTO OrderInfo values(NULL,'{num}','{nums}','{orderInfo.CommodityId}','{orderInfo.UserId}','{orderInfo.SendWay}','{orderInfo.OrderState}','{orderInfo.Remark}','{orderInfo.CommodityPrice}','{orderInfo.DistributionCosts}','{orderInfo.OrderPrice}','{orderInfo.CouponPrice}','{orderInfo.AmountPaid}','{orderInfo.StartTime}')";
            int i= DapperHelper.Execute(sqls);

            if (i>0)
            {
                lt.Add(orderInfo);
                rd.SetList(lt, redisKey);
                return i;
            }
            else
            {
                return 0;
            }
        }

        public List<Model.v_OrderInfo> getnum()
        {
            string sql = $"select * from  v_OrderInfo";
            return DapperHelper.GetList<Model.v_OrderInfo>(sql);
        }
    }
}
