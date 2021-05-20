﻿using IOT.Core.Common;
using IOT.Core.IRepository.Path;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.path
{
    public class pathRepository : IPathRepository
    {
        public int Add(Path a)
        {
            string sql = $"insert into Path values(null,'{a.PathName}','{a.PName}','{a.Phone}','{a.WarehouseAddress}','{a.LongAndLat}','{a.ColonelNum}','{a.State}')";
            return DapperHelper.Execute(sql);
        }

        public int delete(string id)
        {
            string sql = $"DELETE from path WHERE  RathID={id}";
            return DapperHelper.Execute(sql);
        }

        public int Edit(Path a)
        {
            string sql = $"Update path set PathName='{a.PathName}',PName='{a.PName}',Phone='{a.Phone}',WarehouseAddress='{a.WarehouseAddress}',LongAndLat='{a.LongAndLat}',ColonelNum='{a.ColonelNum}',State='{a.State}' where RathID='{a.RathID}' ";
            return DapperHelper.Execute(sql);
        }

        public List<Path> GthXS()
        {
            string sql = "select * from path";
            return DapperHelper.GetList<Path>(sql);
        }

        public int Update(int cid)
        {
            throw new NotImplementedException();
        }
    }
}
