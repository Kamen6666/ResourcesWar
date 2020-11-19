using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilty
{
    public class AssetsManager : Singleton<AssetsManager>
    {
        //缓存池
        private Dictionary<string, Object> assetsCache;
        protected  AssetsManager()
        {
            assetsCache = new Dictionary<string, Object>();
        }
        public virtual T GetAssets<T>(string path) where T : Object
        {
            //查看缓存池中是否含有该资源
            if (assetsCache.ContainsKey(path))
            {
                return assetsCache[path] as T;
            }
            else
            {
                T assets = Resources.Load<T>(path);
                assetsCache.Add(path,assets);
                return assets;
            }
        }

        /// <summary>
        /// 卸载资源
        /// </summary>
        public void UnloadUselessAssets()
        {
            Resources.UnloadUnusedAssets();
        }
    }
   
    public class PrefabManager : Singleton<PrefabManager>
    {
        private PrefabManager()
        {

        }


        #region CreateGameObjectByPrefab
        public GameObject CreateGameObjectByPrefab(string path)
        {
            GameObject prefab = AssetsManager.GetInstance().GetAssets<GameObject>(path);
            GameObject obj = Object.Instantiate(prefab);
            return obj;
        }
        public GameObject CreateGameObjectByPrefab(string path,Transform parent)
        {
            GameObject prefab = AssetsManager.GetInstance().GetAssets<GameObject>(path);
            GameObject obj = Object.Instantiate(prefab, parent);
            return obj;
        }
        public GameObject CreateGameObjectByPrefab(string path,Transform parent,Vector2 anchoredPosition)
        {
            GameObject prefab = AssetsManager.GetInstance().GetAssets<GameObject>(path);
            GameObject obj = Object.Instantiate(prefab, parent);
            obj.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
           
            return obj;
        }
        public GameObject CreateGameObjectByPrefab(string path, Transform parent, Vector3 localpos,Vector3 localScale)
        {
            GameObject obj = CreateGameObjectByPrefab(path, parent);
            obj.GetComponent<RectTransform>().localPosition = localpos;
            obj.transform.localScale = localScale;
           // Tool.SetParent(obj, parent, localpos,localScale);
            return obj;
        }
        public GameObject CreateGameObjectByPrefab(string path, Transform parent,Vector3 localpos,Quaternion localqua,Vector3 localScale)
        {
            GameObject obj = CreateGameObjectByPrefab(path,parent);
            Tool.SetProp(obj,localpos,localqua,localScale);
            return obj;
        }
        #endregion



        //public GameObject GetGameObjectByObjectPool(string path,Transform parent,Vector3 localPos)
        //{

        //}
    }

}