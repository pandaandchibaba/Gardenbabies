using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.PutLibrary;
using IOT.Core.Common;

namespace IOT.Core.Repository.PutLibrary
{
    public class PutLibraryRepository : IPutLibraryRepository
    {
        public int Delete(string ids)
        {
            string sql = $"DELETE FROM PutLibrary WHERE PutLibraryId in({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.PutLibrary Model)
        {
            string sql = $"INSERT INTO PutLibrary VALUES(NULL,{Model.WarehouseId},{Model.CommodityId},{Model.GoodNum},NOW(),'{Model.PutNO}')";
            return DapperHelper.Execute(sql);
        }

        public List<Model.PutLibrary> Query()
        {
            string sql = "SELECT *FROM PutLibrary a JOIN Warehouse b ON a.WarehouseId=b.WarehouseId JOIN Commodity c ON a.CommodityId = c.CommodityId";
            return DapperHelper.GetList<IOT.Core.Model.PutLibrary>(sql);
        }

        public int Update(Model.PutLibrary Model)
        {
            string sql = $"UPDATE PutLibrary SET WarehouseId={Model.WarehouseId},CommodityId={Model.CommodityId},GoodNum={Model.GoodNum},PutDate=NOW() WHERE PutLibraryId=({Model.PutLibraryId})";
            return DapperHelper.Execute(sql);
        }
    }
}
