using System.IO;
using UnityEngine;
using UnityEditor;
using Utilty;

public class AutoCreate : Editor
{
    private static string prefabPath = Application.dataPath + "/Resources/LobbyUIPanels";
    private static string modulePath = Application.dataPath + "/Scripts/UserLogic/UserUIModules";
    private static string controllerPath = Application.dataPath + "/Scripts/UserLogic/UserUIControllers";

    [MenuItem("AutoCreate/AutoCreateScripts")]
    public static void AutoCreateScripts()
    {
        var strs = Directory.EnumerateFiles(prefabPath);

        foreach (var item in strs)
        {
            if (item.EndsWith("DS_Store"))
                continue;
            if (item.EndsWith(".meta"))
                continue;

            //去掉前面的路径
            string fileNameWithSuffix = item.Substring(item.LastIndexOf("\\") + 1);
            //去掉后缀扩展名
            string fileName = fileNameWithSuffix.Remove(fileNameWithSuffix.LastIndexOf("."));

            CreateModuleFile(modulePath, fileName);
            CreateContollerFile(controllerPath, fileName);

            // AddComponent(item.Substring(item.LastIndexOf("Assets")),fileName);

            //保存
            AssetDatabase.SaveAssets();
            //刷新
            AssetDatabase.Refresh();
        }
    }

    private static void CreateModuleFile(string path, string name)
    {
        //创建文件
        StreamWriter writer = File.CreateText(path + "/" + name + ".cs");
        //获取模板 
        string template = AssetsManager.GetInstance().GetAssets<TextAsset>("ScriptTemplates/ModuleScriptTemplate").text;
        //替换关键内容
        template = template.Replace("[ModuleName]", name);
        template = template.Replace("[ControllerName]", name + "Controller");
        //写入文件
        writer.Write(template);
        //关闭流
        writer.Close();
    }

    private static void CreateContollerFile(string path, string name)
    {
        //创建文件
        StreamWriter writer = File.CreateText(path + "/" + name + "Controller" + ".cs");
        //获取模板
        string template = AssetsManager.GetInstance().GetAssets<TextAsset>("ScriptTemplates/ControllerScriptTemplate").text;
        //替换关键内容
        template = template.Replace("[ControllerName]", name + "Controller");
        //写入文件
        writer.Write(template);
        //关闭流
        writer.Close();
    }

    private static void AddComponent(string path, string componentName)
    {
        Debug.Log(path);
        //加载预设文件
        // GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        // GameObject newgo = PrefabUtility.CreateEmptyPrefab(path) as GameObject;
        //创建
        // GameObject obj = Instantiate(go);
        // obj.AddComponent(Type.GetType(componentName));
        // obj.name = obj.name.Remove(obj.name.LastIndexOf("(Clone)"));
        // Debug.Log(obj);
        // //替换目标预设
        // PrefabUtility.ReplacePrefab(obj, go, ReplacePrefabOptions.ConnectToPrefab);
        // DestroyImmediate(obj);
    }
}