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
            string sql = $"insert into Live values (null,'{a.LiveTitle}','{a.Remark}','https://www.hualigs.cn/image/60b086b319dbb.jpg','{a.GoodId}',1,{a.AnchorId},now(),now(),1)";
            return DapperHelper.Execute(sql);
        }

        //删除
        public int DelLive(int id)
        {
            string sql = $"delete from Live where LiveId = {id}";
            return DapperHelper.Execute(sql);
        }

        //反填
        public Model.Live FT(int id)
        {
            string sql = $"select * from Live where LiveId = {id}";
            return DapperHelper.GetList<Model.Live>(sql).First();
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
            string sql = $"update Live set LiveTitle='{a.LiveTitle}',Remark='{a.Remark}',LiveCover='{a.LiveCover}',GoodId='{a.GoodId}',LiveModel={a.LiveModel},AnchorId={a.AnchorId},BeginLiveDate='{a.BeginLiveDate}',EndLiveDate=,IsEnable={a.IsEnable} where LiveId={a.LiveId}";
            return DapperHelper.Execute(sql);
        }

        //修改直播状态
        public int UptSt(int id)
        {
            IOT.Core.Model.Live ls = DapperHelper.GetList<IOT.Core.Model.Live>($"select * from Live a join Anchor where LiveId={id}").FirstOrDefault();
            if (ls.IsEnable == 1)
            {
                ls.IsEnable = 0;
            }
            else
            {
                ls.IsEnable = 1;
            }
            string sql = $"update Live set IsEnable={ls.IsEnable} where LiveId={id}";
            return DapperHelper.Execute(sql);
        }
    }
}
