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
        public int Del(int id)
        {
            string sql = $"delete from OrderComment where Commentid ={id}";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'删除订单评论ID为{id}的订单评论',NOW(),'订单评论表')");
            return DapperHelper.Execute(sql) ;
        }

        public List<Model.OrderComment> Query()
        {
            string sql = @$"SELECT a.*,b.*,c.commodityPic,c.commodityName FROM 
OrderComment a 
JOIN Com_Comment b on a.Com_CommentId=b.Com_CommentId
JOIN Commodity c ON c.CommodityId=b.CommodityId";
            return DapperHelper.GetList<Model.OrderComment>(sql);
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
            
            return DapperHelper.Execute(sqlq);
        }

    }
}
