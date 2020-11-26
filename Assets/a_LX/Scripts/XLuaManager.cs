using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using UnityEngine.SceneManagement;
public class XLuaManager : MonoBehaviour
{

    private LuaEnv luaEnv;

    private string webFileURL = null;
    void Awake()
    {
        luaEnv = new LuaEnv();
        StartCoroutine(LoadLuaFile());
    }

    IEnumerator LoadLuaFile()
    {
        WWW www = new WWW("file://" + Application.dataPath + "/LuaScripts/LuaTest.lua.txt");

        yield return www;
        if (www.isDone)
        {
            Debug.Log(www.text);
            luaEnv.DoString(www.text);

        }
    }
}