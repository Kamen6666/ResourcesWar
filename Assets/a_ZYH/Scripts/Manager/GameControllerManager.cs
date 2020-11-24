using System;
using System.Collections;
using System.Collections.Generic;
using UIFrame;
using UnityEngine;

public class GameControllerManager : MonoBehaviour
{
    private void Start()
    {
        //显示主面板
        UIManager.GetInstance().VagueOpenModule("InitPanel",null);
    }
}
