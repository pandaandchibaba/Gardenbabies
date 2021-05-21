using IOT.Core.Common;
using IOT.Core.IRepository.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Roles
{
    public class RolesRepository : IRolesRepository
    {
        public int AddRoles(Model.Roles a)
        {
            string sql = $"INSERT into Roles VALUES(null,'{a.RoleName}')";
            return DapperHelper.Execute(sql);
        }

        public int DeleteRoles(string id)
        {
            string sql = $"delete from Roles where RoleId in ({id}) ";
            return DapperHelper.Execute(sql);
        }

        public Model.Roles FT(int id)
        {
            string sql = $"select  * from roles where RoleId={id} ";
            return DapperHelper.GetList<IOT.Core.Model.Roles>(sql).First();
        }

        public List<Model.Roles> GetRoles()
        {
            string sql = $"select  * from roles";
            return DapperHelper.GetList<Model.Roles>(sql);
        }

        public int UptRoles(Model.Roles a)
        {
            string sql = $"update Roles set RoleName= '{a.RoleName}'";
            return DapperHelper.Execute(sql);
        }
    }
}
