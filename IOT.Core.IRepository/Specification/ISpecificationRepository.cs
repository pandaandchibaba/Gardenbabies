using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Specification
{
    public interface ISpecificationRepository
    {
        /// <summary>
        /// 查询，显示所有规格
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<IOT.Core.Model.Specification> GetSpecifications(string key = "");

        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        string CreateSpecification(IOT.Core.Model.Specification specification);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int DeleteSpecification(string ids);

        /// <summary>
        /// 获取规格通过规格id
        /// </summary>
        /// <returns></returns>
        IOT.Core.Model.Specification GetSpecificationBySId(int sid);
    }
}
