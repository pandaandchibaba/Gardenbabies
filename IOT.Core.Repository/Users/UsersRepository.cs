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
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int InsertUsers(Model.Users Model)
        {
            string sql = $"INSERT INTO Users VALUES(NULL,'{Model.UserName}','{Model.LoginName}','{Model.LoginPwd}','{Model.Phone}','{Model.Address}','{Model.State}','{Model.NickName}','{Model.ColonelID}','{Model.RoleId}')";
            return DapperHelper.Execute(sql);

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int UptUsers(Model.Users Model)
        {
            string sql = $"UPDATE  Users SET UserName='{Model.UserName}',LoginName='{Model.LoginName}',NickName='{Model.NickName}',Address='{Model.Address}',State='{Model.State}' where UserId='{Model.UserId}'";
            return DapperHelper.Execute(sql);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public int UptUsersState(int id)
        {
            string sql = $"select * from Users ";

            List<IOT.Core.Model.Users> list = DapperHelper.GetList<IOT.Core.Model.Users>(sql);

            IOT.Core.Model.Users order = list.FirstOrDefault(x => x.UserId.Equals(id));
            string sqlq = "";
            if (order.State == 0)
            {
                sqlq = $"UPDATE Users SET State=State+1 where  UserId={id}";
            }
            else
            {
                sqlq = $"UPDATE Users SET State=State-1 where UserId={id}";

            }
            return DapperHelper.Execute(sqlq);
        }
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
        public int Login(string loginname, string loginpwd)
        {
            
                string sql = $"select * from Users where LoginName={loginname} and LoginPwd={loginpwd}";
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
    }
}
