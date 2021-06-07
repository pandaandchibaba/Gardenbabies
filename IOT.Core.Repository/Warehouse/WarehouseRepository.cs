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
        //实例化帮助文件
        RedisHelper<Model.Warehouse> rh = new RedisHelper<Model.Warehouse>();
        //缓存关键字
        string redisKey;
        //全部数据
        List<IOT.Core.Model.Warehouse> lst = new List<Model.Warehouse>();
        public WarehouseRepository()
        {
            redisKey = "ware_list";
            lst = rh.GetList(redisKey);
        }

        public int Delete(string ids)
        {
            string sql = $"DELETE FROM Warehouse WHERE WarehouseId IN({ids})";

            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                //截取
                string[] arr = ids.Split(',');
                foreach (var item in arr)
                {
                    //找到要删除的对象
                    Model.Warehouse warehouse = lst.FirstOrDefault(x => x.WarehouseId.ToString() == item);
                    lst.Remove(warehouse);
                   
                }
                //从新存入
                rh.SetList(lst, redisKey);
                DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'删除ID为{ids}的仓库表信息',NOW(),'仓库表')");
            }
            return i;
        }
        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Insert(Model.Warehouse Model)
        {
            //添加数据
            if (Model.WarehouseId==0)
            {
                try
                {
                    string sql = $"INSERT INTO Warehouse VALUES(NULL,'{Model.WarehouseName}','{Model.WarehouseSite}','{Model.WarehouseCoordinate}',{Model.WarehouseNum},'{Model.WarehouseState}')";
                    
                   int i=DapperHelper.Execute(sql);
                    if (i>0)
                    {
                        Model = DapperHelper.GetList<Model.Warehouse>("select * from Warehouse order by WarehouseId desc LIMIT 1").FirstOrDefault();
                        lst.Add(Model);
                        rh.SetList(lst, redisKey);
                        DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'添加仓库名称为{Model.WarehouseName}的仓库表信息',NOW(),'仓库表')");
                        return i;
                    }
                    else
                    {
                        return i;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //修改数据
            else
            {
                try
                {
                    string sql = $"UPDATE Warehouse SET WarehouseName='{Model.WarehouseName}',WarehouseSite='{Model.WarehouseSite}',WarehouseCoordinate='{Model.WarehouseCoordinate}',WarehouseNum={Model.WarehouseNum},WarehouseState='{Model.WarehouseState}' WHERE WarehouseId={Model.WarehouseId}";
                   
                    int i= DapperHelper.Execute(sql);
                    if (i>0)
                    {
                        lst[lst.IndexOf(lst.First(x => x.WarehouseId == Model.WarehouseId))] = Model;
                        //从新存入
                        rh.SetList(lst, redisKey);
                        DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改仓库名称为{Model.WarehouseName}的仓库表信息',NOW(),'仓库表')");
                        return i;
                    }
                    else
                    {
                        return i;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
           
        }
        //显示
        public List<Model.Warehouse> Query()
        {
            //判断缓存是否存在
            if (lst == null || lst.Count == 0)
            {
                //不存在
                lst = DapperHelper.GetList<IOT.Core.Model.Warehouse>("select * from Warehouse");
                //从新存入
                rh.SetList(lst, redisKey);
            }
            return lst;
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
            
            int i= DapperHelper.Execute(sqls);
            if (i>0)
            {
                //找到要的对象
                lst[lst.IndexOf(lst.First(x => x.WarehouseId==id))] = warehouse;
                //从新存入
                rh.SetList(lst,redisKey);
                DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改仓库状态ID为:{id}的仓库表信息',NOW(),'仓库表')");
            }
            return i;
        }
    }
}
