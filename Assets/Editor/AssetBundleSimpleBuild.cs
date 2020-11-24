using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundleSimpleBuild : Editor
{
    
    public static string NeedBuildPath = Application.dataPath + "/NeedBuild";
    public static string outputPath = Application.dataPath + "/OutputAssetBundle";
   
   public static void SimpleBuildWindows64()
    {
        BuildPipeline.BuildAssetBundles(outputPath,
            BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.StandaloneWindows64);
    }
    [MenuItem("SimpleTool/AssetBundleWindows64")]
    public static void AutoBuildWindow64()
    {
        //清除名称【初始化】
        ClearAssetBundleNames();
        //设置名称
        SetFilesAssetBundleName(NeedBuildPath);
        //打包
        SimpleBuildWindows64();
        //清除名称
        ClearAssetBundleNames();
        //刷新资源
        AssetDatabase.Refresh();
    }
   
    public static void SetFilesAssetBundleName(string path)
    {
        //先获取该路径下的所有文件路径
        string[] filesName = Directory.GetFiles(path);
        //获取该路径下的子文件夹的名称
        string[] directoryName = Directory.GetDirectories(path);
        for (int i = 0; i < directoryName.Length; i++)
        {
            //递归
            SetFilesAssetBundleName(directoryName[i]);
        }
        for (int i = 0; i < filesName.Length; i++)
        {
            if (filesName[i].EndsWith(".meta"))
            {
                continue;
            }
            //设置文件的bundle名称
            SetAssetBundleName(filesName[i]);
        }
    }
    private static void SetAssetBundleName(string path)
    {
        #region 例子
        /*例
         * path = "E:/Unity/Working/AssetWork/Assets/NeedBuild\\abc";
         Application.dataPath = "E:/Unity/Working/AssetWork/Assets";
        下标                     0                               32
         Application.dataPath.Length = 33
        path.Substring(Application.dataPath.Length)指截取从33开始一直到最后的字符串
        relativePath = "/NeedBuild\\abc";
         */
        #endregion
        string relativePath = path.Substring(Application.dataPath.Length);
        relativePath = "Assets" + relativePath;
        //     带后缀的文件名                                      LastIndexOf 找下标     
        string FileNameWithPostfix = relativePath.Substring(relativePath.LastIndexOf('\\') + 1);
        //去掉后缀
        string bundleName = FileNameWithPostfix.Remove(FileNameWithPostfix.LastIndexOf('.'));
        //通过相对路径获取资源导入对象
        AssetImporter asset = AssetImporter.GetAtPath(relativePath);
        asset.assetBundleName = bundleName;
    }
    /// <summary>
    /// 清除Bundle名称
    /// </summary>
    private static void ClearAssetBundleNames()
    {
        //获取所有的Bundle名称
        string[] names = AssetDatabase.GetAllAssetBundleNames();

        //遍历
        for (int i = 0; i < names.Length; i++)
        {
            //强制移除bundle名称
            AssetDatabase.RemoveAssetBundleName(names[i], true);
        }
    }
}
