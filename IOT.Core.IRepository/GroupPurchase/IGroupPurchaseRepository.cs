using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.GroupPurchase
{
   public interface IGroupPurchaseRepository
    {
        List<IOT.Core.Model.GroupPurchase> GetModels();
        int insert(IOT.Core.Model.GroupPurchase a);
    }
}
