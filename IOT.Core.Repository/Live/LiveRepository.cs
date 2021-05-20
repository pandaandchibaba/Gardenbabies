using IOT.Core.Common;
using IOT.Core.IRepository.Live;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Live
{
    public class LiveRepository : ILiveRepository
    {
        //添加
        public int AddLive(Model.Live a)
        {
            string sql = $"insert into Live values (null,'{a.LiveTitle}','{a.Remark}','{a.LiveCover}','{a.GoodId}',{a.LiveModel},{a.AnchorId},'{a.BeginLiveDate}','{a.EndLiveDate}',{a.IsEnable})";
            return DapperHelper.Execute(sql);
        }

        //删除
        public int DelLive(string id)
        {
            string sql = $"delete from Live where LiveId = {id}";
            return DapperHelper.Execute(sql);
        }

        //显示
        public List<Model.Live> ShowLive()
        {
            string sql = "select * from Live a join Anchor b on a.AnchorId=b.AnchorId";
            return DapperHelper.GetList<IOT.Core.Model.Live>(sql);
        }

        //修改
        public int UptLive(Model.Live a)
        {
            string sql = $"update Live set LiveTitle='{a.LiveTitle}',Remark='{a.Remark}',LiveCover='{a.LiveCover}',GoodId='{a.GoodId}',LiveModel={a.LiveModel},AnchorId={a.AnchorId},BeginLiveDate='{a.BeginLiveDate}',EndLiveDate='{a.EndLiveDate}',IsEnable={a.IsEnable} where LiveId={a.LiveId}";
            return DapperHelper.Execute(sql);
        }
    }
}
