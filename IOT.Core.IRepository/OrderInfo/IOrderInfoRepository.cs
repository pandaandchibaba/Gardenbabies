using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OrderInfo
{
    public interface IOrderInfoRepository
    {
        /// <summary>
        /// 订单概述
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.v_OrderInfo> getnum();
        List<IOT.Core.Model.OrderInfo> GetOrderInfos(string name, int sendway, string state, string end, int tui, int dingt, int uid, string cname, string ziti);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        int insert(IOT.Core.Model.OrderInfo orderInfo);
        int Delete(string ids);
        int Insert(IOT.Core.Model.OrderInfo Model);
        List<IOT.Core.Model.OrderInfo> Query(int pm,int ps,int sts);
        /// <summary>
        /// 修改备注
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptRemark(IOT.Core.Model.OrderInfo Model);
        /// <summary>
        /// 修改配送地址
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptSendWay(IOT.Core.Model.OrderInfo Model);
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptOrderState(IOT.Core.Model.OrderInfo Model);


    }
}
