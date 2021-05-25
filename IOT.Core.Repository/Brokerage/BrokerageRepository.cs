using IOT.Core.Common;
using IOT.Core.IRepository.Brokerage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Brokerage
{
    public class BrokerageRepository : IBrokerageRepository
    {
    

        public List<Model.Brokerage> GetBrokerages()
        {
            string sql = "select a.BId, b.HeadPortrait,b.NickName,a.BrokerageType,a.Income,a.State,a.EndTime,a.OrderFormStatus from brokerage a join Colonel b ON a.ColonelID=b.ColonelID";
            return DapperHelper.GetList<Model.Brokerage>(sql);
        }

        public int Updatestate(int id)
        {
            try
            {
                IOT.Core.Model.Brokerage ls = DapperHelper.GetList<IOT.Core.Model.Brokerage>($"select * from Brokerage  where BId   ={id}").FirstOrDefault();
                if (ls.State == 0)
                {
                    ls.State = 1;
                }
                else
                {
                    ls.State = 0;
                }
                string sql = $"update Brokerage set State ={ls.State } where BId   ={id} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
