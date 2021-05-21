using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.SVIP
{
    public interface ISVIPRepository
    {
        /// <summary>
        /// 添加超级会员
        /// </summary>
        /// <param name="sVIP"></param>
        /// <returns></returns>
        public string CreateSVIP(IOT.Core.Model.SVIP sVIP);
    }
}
