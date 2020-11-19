using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CopyHierarchy : MonoBehaviour
{
    private static readonly TextEditor CopyTool = new TextEditor();

    [MenuItem("GameObject/CopyPath", priority = 20)]
    static void CopyPath()
    {
        Transform trans = Selection.activeTransform;
        if (null == trans) return;
        CopyTool.text = GetPath(trans);
        CopyTool.SelectAll();
        CopyTool.Copy();
    }
    public static string GetPath(Transform trans)
    {
        if (null == trans) return string.Empty;
        if (null == trans.parent) return trans.name;
        return GetPath(trans.parent) + "/" + trans.name;
    }

}
