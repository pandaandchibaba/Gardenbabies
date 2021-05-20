using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Com_Comment
{
    public interface ICom_CommentRepository
    {
        /// <summary>
        /// 显示 查询评论
        /// </summary>
        /// <param name="cname"></param>
        /// <param name="uname"></param>
        /// <returns></returns>
        List<IOT.Core.Model.V_Com_Comment> GetComments(string cname="",string uname="");

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        string CreateCom_Comment(IOT.Core.Model.Com_Comment comment);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        int DeleteCom_Comment(int cid);
    }
}
