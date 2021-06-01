using IOT.Core.Common;
using IOT.Core.IRepository.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Activity
{
    public class ActivityRepository : IActivityRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int AddActivity(Model.Activity a)
        {
            try
            {
                string sql = $"insert into Activity values (null,'{a.ActivityName}', '{a.BeginTime}', '{a.EndTime}', 'https://www.hualigs.cn/image/60b086b319dbb.jpg', {a.State},'{a.CreateDate}', 3)";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelActivity(string id)
        {
            try
            {
                string sql = $"delete from Activity where ActivityId={id}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Model.Activity> ShowActivity()
        {
            try
            {
                string sql = "select * from Activity";
                return DapperHelper.GetList<Model.Activity>(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UptActivity(Model.Activity a)
        {
            try
            {
                string sql = $"update Activity set ActivityName='{a.ActivityName}', BeginTime='{a.BeginTime}', EndTime='{a.EndTime}', Slideshow='{a.Slideshow}', State={a.State},CreateDate='{a.CreateDate}', ActivityTime={a.ActivityTime} where ActivityId={a.ActivityId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public int UptState(int id)
        {
            try
            {
                IOT.Core.Model.Activity ls = DapperHelper.GetList<Model.Activity>($"select * from Activity where ActivityId={id}").FirstOrDefault();
                if (ls.State == 0)
                {
                    ls.State = 1;
                }
                else
                {
                    ls.State = 0;

                }
                string sql = $"update Activity set State ={ls.State} where ActivityId={id}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
