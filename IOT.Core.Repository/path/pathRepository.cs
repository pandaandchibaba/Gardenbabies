using IOT.Core.Common;
using IOT.Core.IRepository.Path;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Path
{
    public class PathRepository : IPathRepository
    {
        public int Add(Model.Path a)
        {
            string sql = $"insert into Path values(null,'{a.PathName}','{a.PName}','{a.Phone}','{a.WarehouseAddress}','{a.LongAndLat}','{a.ColonelNum}','{a.State}')";
            return DapperHelper.Execute(sql);
        }

        public int delete(string id)
        {
            string sql = $"DELETE from path WHERE  RathID={id}";
            return DapperHelper.Execute(sql);
        }

        public int Edit(Model. Path a)
        {
            string sql = $"Update path set PathName='{a.PathName}',PName='{a.PName}',Phone='{a.Phone}',WarehouseAddress='{a.WarehouseAddress}',LongAndLat='{a.LongAndLat}',ColonelNum='{a.ColonelNum}',State='{a.State}' where RathID='{a.RathID}' ";
            return DapperHelper.Execute(sql);
        }

        public Model.Path Ft(int id)
        {
            string sql = $"select * from path where RathID={id}";
            return DapperHelper.GetList<IOT.Core.Model.Path>(sql).First();
        }

        public List<Model.Path> GthXS()
        {
            string sql = "select * from path";
            return DapperHelper.GetList< Model.Path>(sql);
        }

        public int Update(int cid)
        {
            IOT.Core.Model.Path ls = DapperHelper.GetList<IOT.Core.Model.Path>($"select * from Path  where RathID   ={cid}").FirstOrDefault();
            if (ls.State == 0)
            {
                ls.State = 1;
            }
            else
            {
                ls.State = 0;
            }
            string sql = $"update Path set State={ls.State} where RathID   ={cid} ";
            return DapperHelper.Execute(sql);
        }
    }
}
