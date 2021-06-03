using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;
using IOT.Core.IRepository.Warehouse;
using IOT.Core.Common;
namespace IOT.Core.Repository.Warehouse
{
    public class WarehouseRepository : IWarehouseRepository
    {
        
        public int Delete(string ids)
        {
            string sql = $"DELETE FROM Warehouse WHERE WarehouseId IN({ids})";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'删除ID为{ids}的仓库表信息',NOW(),'仓库表')");
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Warehouse Model)
        {
            string sql = $"INSERT INTO Warehouse VALUES(NULL,'{Model.WarehouseName}','{Model.WarehouseSite}','{Model.WarehouseCoordinate}',{Model.WarehouseNum},'{Model.WarehouseState}')";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'添加仓库名称为{Model.WarehouseName}的仓库表信息',NOW(),'仓库表')");
            return DapperHelper.Execute(sql);
        }

        public List<Model.Warehouse> Query()
        {
            string sql = "SELECT *FROM Warehouse";
            return DapperHelper.GetList<IOT.Core.Model.Warehouse>(sql);
        }

        public int Update(Model.Warehouse warehouse)
        {
            string sql = $"UPDATE Warehouse SET WarehouseName='{warehouse.WarehouseName}',WarehouseSite='{warehouse.WarehouseSite}',WarehouseCoordinate='{warehouse.WarehouseCoordinate}',WarehouseNum={warehouse.WarehouseNum},WarehouseState='{warehouse.WarehouseState}' WHERE WarehouseId={warehouse.WarehouseId}";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改仓库名称为{warehouse.WarehouseName}的仓库表信息',NOW(),'仓库表')");
            return DapperHelper.Execute(sql);
        }

        public int UptState(int id)
        {
            string sql = "SELECT *FROM Warehouse";
            List<IOT.Core.Model.Warehouse> lw = DapperHelper.GetList<IOT.Core.Model.Warehouse>(sql);
            IOT.Core.Model.Warehouse warehouse = lw.FirstOrDefault(x => x.WarehouseId.Equals(id));
            string sqls = "";
            if (warehouse.WarehouseState=="0")
            {
                sqls = $"UPDATE Warehouse SET WarehouseState='1' WHERE WarehouseId={id}";
            }
            else
            {
                sqls = $"UPDATE Warehouse SET WarehouseState='0' WHERE WarehouseId={id}";
            }
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改仓库状态ID为{id}的仓库表信息',NOW(),'仓库表')");
            return DapperHelper.Execute(sqls);
        }
    }
}
