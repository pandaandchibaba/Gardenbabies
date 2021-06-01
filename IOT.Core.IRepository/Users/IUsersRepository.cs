using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Users
{
   public  interface IUsersRepository
    {    



        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<IOT.Core.Model.Users> GetUsers(string name);
        List<IOT.Core.Model.Users> GetUsersFan(int id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int InsertUsers(IOT.Core.Model.Users Model);
        /// <summary>
        /// 修改内容
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptUsers(IOT.Core.Model.Users a);
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptUsersState(int id);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int DelUsers(int ids);

        int Login(string loginname, string loginpwd);

    }
}
