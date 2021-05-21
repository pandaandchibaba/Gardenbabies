using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Store_Configuration
{
    public interface IStore_ConfigurationRepository
    {

        int InsertPic(IOT.Core.Model.Store_Configuration Model);

    }
}
