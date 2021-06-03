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
        //缓存关键字
        string redisKey;
        //全部数据
        List<IOT.Core.Model.Specification> lst=new List<Model.Specification>();
        public SpecificationRepository()
        {
            redisKey = "spec_list";
            lst = rh.GetList(redisKey);
        }
        //实例化帮助文件
        RedisHelper<Model.Specification> rh = new RedisHelper<Model.Specification>();
        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        #region 添加 or 修改
        public string CreateSpecification(Model.Specification specification)
        {
            if (specification.SId == 0)  //添加
            {
                try
                {
                    string sql = $"insert into Specification values(null,'{specification.SpecificationName}','{specification.CommSpec}','{specification.CommProp}',{specification.SpecificationValue})";
                    int i = DapperHelper.Execute(sql);
                    if (i > 0)
                    {
                        lst.Add(specification);
                        //存入
                        rh.SetList(lst, redisKey);
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
            else  //修改
            {
                try
                {
                    string sql = $"update Specification set SpecificationName='{specification.SpecificationName}',CommSpec='{specification.CommSpec}',CommProp='{specification.CommProp}',SpecificationValue={specification.SpecificationValue} where SId={specification.SId}";
                    int i = DapperHelper.Execute(sql);
                    if (i > 0)
                    {
                        lst[lst.IndexOf(lst.First(x => x.SId == specification.SId))] = specification;
                        //存入
                        rh.SetList(lst, redisKey);
                        return "修改成功";
                    }
                    else
                    {
                        return "修改失败";
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        #endregion

        /// <summary>
        /// 删除规格
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        #region 删除
        public int DeleteSpecification(string ids)
        {
            string sql = $"delete from Specification where SId in({ids})";
            //删除
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                //截取
                string[] arr = ids.Split(',');
                foreach (var item in arr)
                {
                    //找到要删除的对象
                    Model.Specification specification = lst.FirstOrDefault(x => x.SId.ToString() == item);
                    lst.Remove(specification);
                }
                //从新存入
                rh.SetList(lst, redisKey);
            }
            return i;
        }
        #endregion

        /// <summary>
        /// 通过规格id获取规格
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        #region 通过规格id获取规格
        public Model.Specification GetSpecificationBySId(int sid)
        {
            //判断缓存是否存在
            if (lst == null || lst.Count == 0)
            {
                //不存在
                lst = DapperHelper.GetList<IOT.Core.Model.Specification>("select * from Specification");
                //存入
                rh.SetList(lst, redisKey);
            }
            return lst.FirstOrDefault(x => x.SId == sid);
        } 
        #endregion

        /// <summary>
        /// 显示查询商品规格
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        #region 显示查询商品规格
        public List<Model.Specification> GetSpecifications(string key = "")
        {
            //判断缓存是否存在
            if (lst == null || lst.Count == 0)
            {
                //不存在
                lst = DapperHelper.GetList<IOT.Core.Model.Specification>("select * from Specification");
                //存入
                rh.SetList(lst, redisKey);
            }
            //查询
            if (!string.IsNullOrEmpty(key))
            {
                lst = lst.Where(x => x.CommSpec.Contains(key)).ToList();
            }
            return lst;
        } 
        #endregion
    }
}
