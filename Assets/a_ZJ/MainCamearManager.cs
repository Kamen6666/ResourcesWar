using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamearManager : MonoBehaviour
{
    //跟随目标
    public Transform Target;
    //跟随距离
    private Vector3 _distance;
    void Start()
    {
        _distance = transform.position - Target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    /// <summary>
    /// 跟随
    /// </summary>
    private void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + _distance, 0.1f);
    }
    /// <summary>
    /// 围绕目标旋转
    /// </summary>
    private void RoundTarget()
    { 
        
    }
}

