using IOT.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.Users;

namespace IOT.Core.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
       

        public List<Model.Users> GetUsers(string name)
        {
            string sql = $"select * from Users where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and UserName like '%{name}%'";
            }
            
            return DapperHelper.GetList<Model.Users>(sql);
        }

        public int InsertUsers(Model.Users Model)
        {
            string sql = $"INSERT INTO Users VALUES(NULL,{Model.UserName},{Model.LoginName},{Model.LoginPwd},'0','0','1',NULL,'{Model.RoleId}','0')";
            return DapperHelper.Execute(sql);

        }

        public int UptUsers(Model.Users Model)
        {
            string sql = $"UPDATE  Users SET UserName='{Model.UserName}',LoginName='{Model.LoginName}',LoginPwd='{Model.LoginPwd}',RoleId='{Model.RoleId}' where UserId='{Model.UserId}'";
            return DapperHelper.Execute(sql);
        }

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
        public int DelUsers(int ids)
        {
            string sql = $"delete from Users where UserId in ({ids})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Users> GetUsersFan(int id)
        {
            string sql = $"select * from Users where Userid={id}";
            return DapperHelper.GetList<IOT.Core.Model.Users>(sql);
        }

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
