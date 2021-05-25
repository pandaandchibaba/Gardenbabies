using IOT.Core.Common;
using IOT.Core.IRepository.SVIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.SVIP
{
    public class SVIPRepository : ISVIPRepository
    {
        /// <summary>
        /// 添加超级会员
        /// </summary>
        /// <param name="sVIP"></param>
        /// <returns></returns>
        public string CreateSVIP(Model.SVIP sVIP)
        {
            try
            {
                string sql = $"insert into SVIP values (null,'{sVIP.SName}','{sVIP.BackgroudColor}','{sVIP.Icon}','{sVIP.BCImg}',{sVIP.Consume},{sVIP.Commission},{sVIP.Money},'{sVIP.Rate}','{sVIP.Explains}')";
                int i = DapperHelper.Execute(sql);
                if (i > 0)
                {
                    return "添加成功";
                }
                else
                {
                    return "添加失败";
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
