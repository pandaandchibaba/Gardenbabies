using IOT.Core.Common;
using IOT.Core.IRepository.ColonelManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.ColonelManagement
{
    public class ColonelManagementRepository : IColonelManagementRepository
    {
        public List<Model.ColonelManagement> GetColonelManagements()
        {
            string sql = "select a.CMId,b.HeadPortrait,a.CheckName,b.Phone,a.cityName,b.Address,b.Cost,a.CheckName,a.AapplyTime,a.CheckTime,a.CheckStatus from ColonelManagement a join Colonel b  on a.ColonelID=b.ColonelID ";
            return DapperHelper.GetList<Model.ColonelManagement>(sql);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Uptdata(string id)
        {
            IOT.Core.Model.ColonelManagement ls = DapperHelper.GetList<IOT.Core.Model.ColonelManagement>($"select * from ColonelManagement where CMId ={id}").FirstOrDefault();
            if (ls.CheckStatus == 0)
            {
                ls.CheckStatus = 1;
            }
            else
            {
                ls.CheckStatus = 2;
            }
            
            string sql = $"update ColonelManagement set CheckStatus={ls.CheckStatus} where CMId ={id} ";
            return DapperHelper.Execute(sql);
        }
    }
    
}
