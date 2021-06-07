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
        public enum Days
        {
            全部 = 0,
            今天 = 1,
            昨天 = 2,
            最近七天 = 3,
            最近三十天 = 4,
            本月 = 5,
            本年 = 6,
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public string CreateCom_Comment(Model.Com_Comment comment)
        {
            try
            {
                string sql = $"insert into Com_Comment values(null,{comment.CommodityId},{comment.UserId},{comment.CommGrade},{comment.SeverGrade},'{comment.CommentContent}','{comment.RevertContent}','{comment.CommentPic}',now(),{comment.CommentState})";
                int i = DapperHelper.Execute(sql);
                if (i > 0)
                {
                    return "添加成功";
                }
                else
                {
                    return "添加失败";
                }
            }
            catch (Exception)
            {

                throw;
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
        public List<V_Com_Comment> GetComments(int days = 0, string st = "", string cname = "", string uname = "")
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from V_Com_Comment ");
            //转换成枚举
            Days day = (Days)days;
            switch (day)
            {
                case Days.今天:
                    sql.Append(" where Days<1");
                    break;
                case Days.昨天:
                    sql.Append(" where Days=1");
                    break;
                case Days.最近七天:
                    sql.Append(" where Days<=7");
                    break;
                case Days.最近三十天:
                    sql.Append(" where Days<=30");
                    break;
                case Days.本月:
                    sql.Append($" where Months={DateTime.Now.Month} and Years={DateTime.Now.Year}");
                    break;
                case Days.本年:
                    sql.Append($" where Years={DateTime.Now.Year}");
                    break;
                default:
                    break;
            }
            //获取全部数据
            List<V_Com_Comment> lst = DapperHelper.GetList<V_Com_Comment>(sql.ToString());
            lst = lst.Where(x => (string.IsNullOrEmpty(uname) ? true : x.UserName.Contains(uname)) && (string.IsNullOrEmpty(cname) ? true : x.CommodityName.Contains(cname)) && (string.IsNullOrEmpty(st) ? true : x.CommentState.ToString() == st)).ToList();
            return lst;
        }

        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public int ReplyComment(Model.Com_Comment com)
        {
            try
            {
                string sql = $"update Com_Comment set RevertContent='{com.RevertContent}',CommentState=1 where  Com_CommentId={com.Com_CommentId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
