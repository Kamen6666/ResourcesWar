using ExitGames.Client.Photon;
using MobaCommon.Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Lx_Test : MonoBehaviour
{
    public string assetBundleName;
    public string assetRealName;
    SkillData skillData = null;
    private void Start()
    {
        //Debug.Log(FindMinArrowShots(new int[][]
         //{
         //   new int[]{10,16},
         //   new int[]{2,8 },
         //   new int[]{1,6 },
         //   new int[]{7,12 }
         //}));
        StartCoroutine(LoadAssetsByWebRequest());
    }
    public int FindMinArrowShots(int[][] points)
    {
        List<int[]> list1 = new List<int[]>();
        //遍历给定的i个气球
        for (int i = 0; i < points.Length; i++)
        {
            //第一个气球直接加入List
            if (i == 0)
            {
                list1.Add(points[i]);
                continue;
            }
            bool needAdd = true;
            //遍历List中的气球
            for (int j = 0; j < list1.Count; j++)
            {
                //遍历当前气球的x坐标
                for (int k = 0; k < 2; k++)
                {
                    //如果当前遍历的x坐标在List中气球的坐标内，
                    //则该气球可被同一支箭击破
                    if (points[i][k] >= list1[j][0] && points[i][k] <= list1[j][1])
                    {
                        needAdd = false;
                    }
                }
            }
            //    两个x坐标都不在List中所有气球范围内，将当前气球添加到List
            if (needAdd)
            {
                list1.Add(points[i]);
            } 
        }
        return list1.Count;
    }

    private IEnumerator LoadAssetsByWebRequest()
    {
        //获取要加载的资源路径【bundle总说明文件】
        string path = "http://122.51.66.22:8080/LX/OutPutAssetBundle/OutPutAssetBundle.manifest";

        //通过WebRequest的方式获取资源
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path);
        //等待获取
        yield return request.SendWebRequest();
        //获取其中的bundle
        AssetBundle manifestBundle = DownloadHandlerAssetBundle.GetContent(request);
        //获取到说明文件
        AssetBundleManifest manifest = manifestBundle.LoadAsset<AssetBundleManifest>("OutPutAssetBundle");
        //获取资源的所有依赖
        string[] dependencies = manifest.GetAllDependencies(assetBundleName);

        //获取到相对路径  file:///user/..../HLLesson11/Assets/Output/【Output】
        path = path.Remove(path.LastIndexOf("/") + 1);
        //声明依赖的Bundle数组
        AssetBundle[] depAssetBundles = new AssetBundle[dependencies.Length];
        //遍历加载所有的依赖
        for (int i = 0; i < dependencies.Length; i++)
        {
            //获取到依赖Bundle的路径
            //file:///user/..../HLLesson11/Assets/Output/mat
            string depPath = path + dependencies[i];

            request = UnityWebRequestAssetBundle.GetAssetBundle(depPath);
            //等待获取
            yield return request.SendWebRequest();
            //将依赖临时保存
            depAssetBundles[i] = DownloadHandlerAssetBundle.GetContent(request);
        }

        //获取路径
        path += assetBundleName;

        request = UnityWebRequestAssetBundle.GetAssetBundle(path);
        //等待获取
        yield return request.SendWebRequest();
        //获取到资源的Bundle
        AssetBundle realAssetBundle = DownloadHandlerAssetBundle.GetContent(request);

        //加载真正的资源
        SkillData prefab = realAssetBundle.LoadAsset<SkillData>(assetRealName);
        //TEST:生成
        //Instantiate(prefab);
        skillData = prefab;
        Debug.Log(skillData.skillName);
    }

   
}
