using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.MiniProgram
{
    public interface IMiniProgramRepository
    {
        int Insert(IOT.Core.Model.MiniProgram Model);
    }
}
