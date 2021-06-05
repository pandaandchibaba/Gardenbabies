using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OrderComment
{
   public  interface IOrderCommentRepository
    {
        List<IOT.Core.Model.OrderComment> Query();
        int UptState(int id);
        int Del(string id);

    }
}
