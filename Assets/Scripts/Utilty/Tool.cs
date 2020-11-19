using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utilty
{
    public class Tool
    {
       
        public static void SetParent(GameObject obj,Transform parentTra,Vector3 localPos,Quaternion localQua)
        {
            obj.transform.SetParent(parentTra);
            obj.transform.localPosition = localPos;
            obj.transform.localRotation = localQua;
        }
        public static void SetProp(GameObject obj,  Vector3 localPos, Quaternion localQua, Vector3 localScale)
        {
            obj.transform.localPosition = localPos;
            obj.transform.localRotation = localQua;
            obj.transform.localScale = localScale;
        }
        public static void SetParent(GameObject obj, Transform parentTra, Vector3 localPos, Vector3 localScale)
        {
            obj.transform.SetParent(parentTra);
            obj.transform.localPosition = localPos;
            obj.transform.localScale = localScale;
        }
        public static void SetParent(GameObject obj, Transform parentTra, Vector3 localPos, Quaternion localQua,Vector3 localScale)
        {
            obj.transform.SetParent(parentTra);
            obj.transform.localPosition = localPos;
            obj.transform.localRotation = localQua;
            obj.transform.localScale = localScale;
        }

    }
}