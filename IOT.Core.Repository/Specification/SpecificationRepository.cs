using IOT.Core.Common;
using IOT.Core.IRepository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Specification
{
    public class SpecificationRepository : ISpecificationRepository
    {
        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        public string CreateSpecification(Model.Specification specification)
        {
            if (specification.SId == 0)  //添加
            {
                string sql = $"insert into Specification values(null,'{specification.SpecificationName}','{specification.CommSpec}','{specification.CommProp}',{specification.SpecificationValue})";
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
            else  //修改
            {
                string sql = $"update Specification set SpecificationName='{specification.SpecificationName}',CommSpec='{specification.CommSpec}',CommProp='{specification.CommProp}',SpecificationValue={specification.SpecificationValue} where SId={specification.SId}";
                int i = DapperHelper.Execute(sql);
                if (i > 0)
                {
                    return "修改成功";
                }
                else
                {
                    return "修改失败";
                }
            }
        }

        /// <summary>
        /// 删除规格
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteSpecification(string ids)
        {
            string sql = $"delete from Specification where SId in({ids})";
            return DapperHelper.Execute(sql);
        }

        public Model.Specification GetSpecificationBySId(int sid)
        {
            return DapperHelper.GetList<Model.Specification>($"select * from Specification where SId ={sid}").FirstOrDefault();
        }

        public List<Model.Specification> GetSpecifications(string key = "")
        {
            //获取全部规格
            List<IOT.Core.Model.Specification> lst = DapperHelper.GetList<IOT.Core.Model.Specification>("select * from Specification");
            //查询
            if (!string.IsNullOrEmpty(key))
            {
                lst = lst.Where(x => x.CommSpec.Contains(key)).ToList();
            }
            return lst;
        }
    }
}
