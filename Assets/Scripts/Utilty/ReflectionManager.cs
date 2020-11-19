using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilty
{
    public class ReflectionManager : Singleton<ReflectionManager>
    {
        private ReflectionManager() { }

        /// <summary>
        /// 当前程序集下的某个类是否存在
        /// </summary>
        /// <param name="typeStr"></param>
        /// <returns></returns>
        private bool TypeIsExit(string typeStr)
        {
            Type type = Type.GetType(typeStr);
            return type != null;
        }

        /// <summary>
        /// 判断两个类是否有继承关系
        /// </summary>
        /// <param name="typeStr">子类</param>
        /// <param name="extentType">父类</param>
        /// <returns></returns>
        public bool TypeIsExtentOrEquel(string typeStr,string extentType)
        {
            //判断两个类型是否都存在
            if (!TypeIsExit(typeStr))
            {
                return false;
            }
            if (typeStr == extentType)
            {
                return true;
            }
            //判断基础父类的名字是否和参数父类匹配
            return Type.GetType(typeStr).BaseType.Name == extentType;
           
        }
    }
}