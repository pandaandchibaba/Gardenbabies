using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Live
{
    public interface ILiveRepository
    {
        //添加
        int AddLive(IOT.Core.Model.Live a);

        //显示
        List<IOT.Core.Model.Live> ShowLive();

        //删除
        int DelLive(int id);

        //修改
        int UptLive(IOT.Core.Model.Live a);

        //反填
        IOT.Core.Model.Live FT(int id);

        //修改状态
        int UptSt(int id);
    }
}
