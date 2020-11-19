using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectByPool : MonoBehaviour
{
    /// <summary>
    /// 对象从对象池中出来时，进行初始化操作
    /// </summary>
    public abstract void ObjectInit(object initParameter);

    /// <summary>
    /// 对象进入对象池，进行释放操作
    /// </summary>
    public abstract void ObjectDispose(object disposeParameter);
    
}
