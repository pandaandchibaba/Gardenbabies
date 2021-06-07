using IOT.Core.Common;
using IOT.Core.IRepository.OrderComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OrderComment
{
    public class OrderCommentRepository : IOrderCommentRepository
    {

        string redisKey;
        List<IOT.Core.Model.OrderComment> lt = new List<Model.OrderComment>();
        RedisHelper<Model.OrderComment> rd = new RedisHelper<Model.OrderComment>();

        public OrderCommentRepository()
        {
            redisKey = "orderomment_list";
            lt = rd.GetList(redisKey);
        }

        public int Del(string id)
        {
            string sql = $"delete from OrderComment where Commentid ={id}";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'删除订单评论ID为{id}的订单评论',NOW(),'订单评论表')");
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                string[] arr = id.Split(',');
                foreach (var item in arr)
                {
                    Model.OrderComment orderComment = lt.FirstOrDefault(x => x.Commentid.ToString() == item);
                    lt.Remove(orderComment);
                }
                rd.SetList(lt, redisKey);
            }
            return i;
        }

        public List<Model.OrderComment> Query()
        {
            if (lt==null||lt.Count==0)
            { 
            string sql = @$"SELECT a.*,b.*,c.commodityPic,c.commodityName FROM 
            OrderComment a 
            JOIN Com_Comment b on a.Com_CommentId=b.Com_CommentId
            JOIN Commodity c ON c.CommodityId=b.CommodityId";
            lt = DapperHelper.GetList<Model.OrderComment>(sql);
            rd.SetList(lt, redisKey);
            }
            return lt;
        }

        public int UptState(int id)
        {
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改状态订单评论ID为{id}的订单评论',NOW(),'订单评论表')");
            string sql = $"SELECT * FROM OrderComment a JOIN Com_Comment b on a.Com_CommentId=b.Com_CommentId";

            List<IOT.Core.Model.OrderComment> list = DapperHelper.GetList<IOT.Core.Model.OrderComment>(sql);

            IOT.Core.Model.OrderComment order = list.FirstOrDefault(x => x.Commentid.Equals(id));
            string sqlq="";
            if (order.State==0)
            {
                 sqlq = $"UPDATE OrderComment SET State=State+1 where Commentid={id}";
            }
            else
            {
                 sqlq = $"UPDATE OrderComment SET State=State-1 where Commentid={id}";
                
            }

            int i = DapperHelper.Execute(sqlq);
            if (i > 0)
            {
                lt[lt.IndexOf(lt.First(x => x.Commentid == order.Commentid))] = order;
                rd.SetList(lt, redisKey);
                return i;
            }
            else
            {
                return 0;
            }
        }

    }
}
