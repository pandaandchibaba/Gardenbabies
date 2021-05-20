using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.SeckillCom
{
    public interface ISeckillComRepository
    {
        //添加
        int AddSeckillCom(IOT.Core.Model.SeckillCom a);

        //显示
        List<IOT.Core.Model.SeckillCom> ShowSeckillCom();

        //删除
        int DelSeckillCom(string id);

        //修改
        int UptSeckillCom(IOT.Core.Model.SeckillCom a);
    }
}
