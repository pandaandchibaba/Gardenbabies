using IOT.Core.Common;
using IOT.Core.IRepository.Com_Comment;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Com_Comment
{
    public class Com_CommentRepository : ICom_CommentRepository
    {
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public string CreateCom_Comment(Model.Com_Comment comment)
        {
            string sql = $"insert into Com_Comment values(null,{comment.CommodityId},{comment.UserId},{comment.CommGrade},{comment.SeverGrade},'{comment.CommentContent}','{comment.RevertContent}','{comment.CommentPic}',now())";
            int i = DapperHelper.Execute(sql);
            if (i>0)
            {
                return "添加成功";
            }
            else
            {
                return "添加失败";
            }
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeleteCom_Comment(int cid)
        {
            string sql = $"delete from Com_Comment where Com_CommentId={cid}";
            return DapperHelper.Execute(sql);
        }

        /// <summary>
        /// 显示 查询所有评论
        /// </summary>
        /// <param name="cname"></param>
        /// <param name="uname"></param>
        /// <returns></returns>
        public List<V_Com_Comment> GetComments(string cname = "", string uname = "")
        {
            string sql = "select * from V_Com_Comment";
            List<V_Com_Comment> lst = DapperHelper.GetList<V_Com_Comment>(sql);
            return lst;
        }
    }
}
