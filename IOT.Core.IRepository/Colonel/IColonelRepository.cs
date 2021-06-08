using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Colonel
{
   public interface IColonelRepository
    {
        //显示
        List<IOT.Core.Model.Colonel> ShowColonel();


        /// <summary>
        /// 显示 查询
        /// </summary>
        /// <param name="address"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        List<IOT.Core.Model.V_Colonel> GetColonel(string address="",string key="");
        //删除
        int DelColonel(string id);

        //修改
        int UptColonel(IOT.Core.Model.Colonel a);
        //用户显示
        List<IOT.Core.Model.Users>GetUsers();

        //商品显示
        int ColoneluptGoods(int CommIds, int ColonelID);

        //反填
        IOT.Core.Model.Colonel FT1(int id);
        //修改状态
        int Updates(int  id);

        //获取商品ID
        List<IOT.Core.Model.Colonel> GetCommdit();

        //获取团员IP
        int GetUser(int ColonelID, int UserId);
     

    }
}
