using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;

namespace IOT.Core.IRepository.PutLibrary
{
    public interface IPutLibraryRepository : IBaseRepository<IOT.Core.Model.PutLibrary>
    {
        int Update(IOT.Core.Model.PutLibrary Model);
    }
}
