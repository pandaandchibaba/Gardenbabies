using IOT.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.Users;

namespace IOT.Core.Repository.Users
{
    /// <summary>
    /// 员工管理
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        
        /// <summary>
        /// /显示
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Model.Users> GetUsers(string name)
        {
            string sql = $"select * from Users where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and UserName like '%{name}%'";
            }
            
            return DapperHelper.GetList<Model.Users>(sql);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int InsertUsers(Model.Users Model)
        {
            string sql = $"INSERT INTO Users VALUES(NULL,'{Model.UserName}','{Model.LoginName}','{Model.LoginPwd}','{Model.Phone}','{Model.Address}','{Model.State}','{Model.NickName}','{Model.ColonelID}','{Model.RoleId}','{Model.Mid}')";
            return DapperHelper.Execute(sql);

        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int UptUsers(Model.Users a)
        {
            string sql = $"UPDATE  Users SET UserName='{a.UserName}',LoginName='{a.LoginName}',LoginPwd='{a.LoginPwd}',NickName='{a.NickName}',Address='{a.Address}',State='{a.State}' where UserId='{a.UserId}'";
            return DapperHelper.Execute(sql);
        }
        
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UptUsersState(int id)
        {
            IOT.Core.Model.Users ls = DapperHelper.GetList<IOT.Core.Model.Users>($"select * from Users  where UserId={id}").FirstOrDefault();
            if (ls.State == 0)
            {
                ls.State = 1;
            }
            else
            {
                ls.State = 0;

            }
            string sql = $"Update Users set State={ls.State} where UserId={ls.UserId}";
            return DapperHelper.Execute(sql);

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DelUsers(int ids)
        {
            string sql = $"delete from Users where UserId in ({ids})";
            return DapperHelper.Execute(sql);
        }

        /// <summary>
        /// 反填用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.Users> GetUsersFan(int id)
        {
            string sql = $"select * from Users where Userid={id}";
            return DapperHelper.GetList<IOT.Core.Model.Users>(sql);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginname"></param>
        /// <param name="loginpwd"></param>
        /// <returns></returns>
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginname"></param>
        /// <param name="loginpwd"></param>
        /// <returns></returns>
        public int Login(string loginname, string loginpwd)
        {
            
            string sql = $"select * from Users where LoginName='{loginname}' and LoginPwd='{loginpwd}'";
            //List<Model.Users> lists=lists; 
            IOT.Core.Model.Users users = DapperHelper.GetList<Model.Users>(sql).FirstOrDefault();
            if (users!=null)
            {
                return users.UserId;
            }
            else
            {
                return 0;
            }

        }
        
        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        public List<Model.Users> GetAllUsers()
        {
            return DapperHelper.GetList<Model.Users>("select * from Users");
        }
    }
}
