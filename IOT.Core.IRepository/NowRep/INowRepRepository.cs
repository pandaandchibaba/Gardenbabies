﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;
namespace IOT.Core.IRepository.NowRep
{
    public interface INowRepRepository
    {
        int Delete(string ids);
        List<IOT.Core.Model.NowRep> Query();
    }
}
