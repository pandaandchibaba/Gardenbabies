using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Colonel
{
   public interface IColonelRepository
    {
        //添加
        int AddColonel(IOT.Core.Model.Colonel a);

        //显示
        List<IOT.Core.Model.Colonel> ShowColonel();

        //删除
        int DelColonel(string id);

        //修改
        int UptColonel(IOT.Core.Model.Colonel a);
    }
}
