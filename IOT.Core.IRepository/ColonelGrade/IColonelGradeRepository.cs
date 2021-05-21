using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.ColonelGrade
{
   public interface IColonelGradeRepository
    {
        //显示
        List<IOT.Core.Model.ColonelGrade> GetColonels();
        //删除
        int Edit(string id);
        //修改
        int Upt(IOT.Core.Model.ColonelGrade a);

        //修改状态
        int UptState(int Cid);

        //反填
        IOT.Core.Model.ColonelGrade ft2(int id);
    }
}
