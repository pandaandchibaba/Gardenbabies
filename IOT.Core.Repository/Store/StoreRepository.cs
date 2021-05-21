using IOT.Core.Common;
using IOT.Core.IRepository.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Store
{
    public class StoreRepository : IStoreRepository
    {
        public int DelStore(int ids)
        {
            string sql = $"delete from Store where Mid in ({ids})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Store> GetStores()
        {
            string sql = $"SELECT * FROM Store ";
            return DapperHelper.GetList<Model.Store>(sql);
        }

        public List<Model.Store> GetStoresFan(int id)
        {
            string sql = $"select * from Store where Mid={id}";
            return DapperHelper.GetList<IOT.Core.Model.Store>(sql);
        }

        public int InsertStore(Model.Store Model)
        {
            string sql = $"INSERT INTO Store VALUES(NULL,'{Model.MName}','{Model.Shopowner}','{Model.Goods}','{Model.Volume}','{Model.StoreType}','{Model.Extraction}','{Model.State}','{Model.StoreNo}','{Model.Pwd}','{Model.Phone}','{Model.Background}','{Model.Logo}','{Model.Approve}')";
            return DapperHelper.Execute(sql);
        }

        public int UptStore(Model.Store Model)
        {
            string sql = $"UPDATE Store SET MName ='{Model.MName}',Shopowner='{Model.Shopowner}',Goods='{Model.Goods}',Volume='{Model.Volume}',StoreType='{Model.StoreType}',Extraction='{Model.Extraction}',State='{Model.State}',StoreNo='{Model.StoreNo}',Pwd='{Model.Pwd}',Phone='{Model.Phone}',Background='{Model.Background}',Logo='{Model.Logo}',Approve='{Model.Approve}' where Mid='{Model.Mid}'";
            return DapperHelper.Execute(sql);
        }

        public int UptStoreState(int id)
        {
            string sql = $"SELECT * FROM Store ";

            List<IOT.Core.Model.Store> list = DapperHelper.GetList<IOT.Core.Model.Store>(sql);

            IOT.Core.Model.Store order = list.FirstOrDefault(x => x.Mid.Equals(id));
            string sqlq = "";
            if (order.State == 0)
            {
                sqlq = $"UPDATE Store SET State=State+1 where Mid={id}";
            }
            else
            {
                sqlq = $"UPDATE Store SET State=State-1 where Mid={id}";

            }
            return DapperHelper.Execute(sqlq);
        }
    }
}
