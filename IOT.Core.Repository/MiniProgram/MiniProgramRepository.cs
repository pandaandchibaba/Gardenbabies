using IOT.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.MiniProgram
{
    public class MiniProgramRepository : IMiniProgramRepository
    {
        public int Insert(Model.MiniProgram Model)
        {
            string sql = $"INSERT INTO MiniProgram VALUES(NULL,{Model.APPID},{Model.SECRET},{Model.MerchantCode},'{Model.SecretKey}','{Model.CertificateCERT}','{Model.CertificateKEY}','{Model.Payment}')";
            return DapperHelper.Execute(sql);
        }
    }
}
