using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilty
{
   
    public class ObjectPool : Singleton<ObjectPool>
    {
        private Dictionary<string, Queue<GameObject>> pool;
        private ObjectPool()
        {
            pool = new Dictionary<string, Queue<GameObject>>();
        }


        /// <summary>
        /// 生成对象
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="initParameter">初始化操作</param>
        /// <returns>对象</returns>
        public GameObject SpawnObject(string path,object initParameter = null)
        {
            //从路径分析得到名字
            string name = path.Substring(path.LastIndexOf('/') + 1);

            GameObject needObj;
            if (pool.ContainsKey(path) && pool[path].Count > 0)
            {
                needObj = pool[path].Dequeue();
            }
            else
            {
                needObj = PrefabManager.GetInstance().CreateGameObjectByPrefab(path);
                needObj.name = name;
            }
            needObj.SetActive(true);

            //执行初始化操作
            needObj.GetComponent<ObjectByPool>().ObjectInit(initParameter);

            return needObj;
        }




        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj">要回收的对象</param>
        public void RecycleObj(GameObject obj,object disposeParameter = null)
        {
            obj.SetActive(false);
            //如果有该对象的池子
            if (pool.ContainsKey(obj.name))
            {
                //入队
                pool[obj.name].Enqueue(obj);
            }
            else
            {
                //新建该对象的池子
                Queue<GameObject> q1 = new Queue<GameObject>();
                q1.Enqueue(obj);
                //将池子加入字典进行管理
                pool.Add(obj.name,q1);
            }
            //执行收尾操作
            obj.GetComponent<ObjectByPool>().ObjectDispose(disposeParameter);
        }
    }
}