﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.CommType
{
    public interface ICommTypeRepository
    {
        /// <summary>
        /// 获取所有一级分类
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.CommType> GetOneType();

        /// <summary>
        /// 添加  or  修改
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        string CreateType(IOT.Core.Model.CommType comm);

        /// <summary>
        /// 显示所有分类
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.V_CommType> GetCommodities();

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        int DeleteType(int tid);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        int UpdateState(int tid);

        /// <summary>
        /// 通过类别id获取分类
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        IOT.Core.Model.CommType GetCommTypeByTid(int tid);

        /// <summary>
        /// 绑定类别下拉
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<IOT.Core.Model.CommType> BindType(int pid);
    }
}