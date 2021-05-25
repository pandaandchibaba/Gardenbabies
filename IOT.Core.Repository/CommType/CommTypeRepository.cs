using IOT.Core.Common;
using IOT.Core.IRepository.CommType;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.CommType
{
    public class CommTypeRepository : ICommTypeRepository
    {
        public List<Model.CommType> BindType(int pid)
        {
            string sql = $"select * from CommType where ParentId={pid} and State=1";
            return DapperHelper.GetList<Model.CommType>(sql);
        }

        /// <summary>
        /// 添加 or 修改 分类
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public string CreateType(Model.CommType comm)
        {
            if (comm.TId == 0)  //添加
            {
                try
                {
                    string sql = $"insert into CommType values(null,'{comm.TName}',{comm.Sort},'{comm.TIcon}',{comm.State},{comm.ParentId})";
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
            else  //修改
            {
                try
                {
                    string sql = $"update CommType set TName='{comm.TName}',Sort={comm.Sort},TIcon='{comm.TIcon}',State={comm.State},ParentId={comm.ParentId} where TId={comm.TId}";
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
                catch (Exception)
                {

                    throw;
                }
            }
        }
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int DeleteType(int tid)
        {
            //查询要删除商品的子菜单数量
            int sonNum = Convert.ToInt32(DapperHelper.Exescalar($"select count(*) from CommType where ParentId={tid}"));
            if (sonNum == 0)
            {
                //删除的SQL语句
                string sql = $"delete from CommType where TId={tid}";
                return DapperHelper.Execute(sql);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<IOT.Core.Model.V_CommType> GetCommTypes(string st = "", string key = "")
        {
            List<IOT.Core.Model.V_CommType> lst = DapperHelper.GetList<IOT.Core.Model.V_CommType>("select * from V_CommType ");
            //状态
            if (!string.IsNullOrEmpty(st))
            { 
                lst = lst.Where(x => x.State == Convert.ToInt32(st)).ToList();
            }
            if (!string.IsNullOrEmpty(key))
            {
                lst = lst.Where(x => x.TName.Contains(key)).ToList();
            }
            return lst;
        }

        /// <summary>
        /// 通过类别id获取分类
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public Model.CommType GetCommTypeByTid(int tid)
        {
            return DapperHelper.GetList<IOT.Core.Model.CommType>("select * from CommType").FirstOrDefault();
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public List<Model.CommType> GetOneType()
        {
            return DapperHelper.GetList<Model.CommType>("select * from CommType where ParentId=0 and State=1");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int UpdateState(int tid)
        {
            try
            {
                //获取要修改的分类
                IOT.Core.Model.CommType commType = DapperHelper.GetList<IOT.Core.Model.CommType>($"select * from CommType where TId={tid}").FirstOrDefault();
                if (commType.State == 0)
                {
                    commType.State = 1;
                }
                else
                {
                    commType.State = 0;
                }
                //修改的SQL语句
                string sql = $"update CommType set State={commType.State} where TId={commType.TId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
