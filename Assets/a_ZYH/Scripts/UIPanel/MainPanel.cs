using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

public class MainPanel : UIModuleBase
{
    private void Start() {
        //绑定控制器
        BindController(new MainController());
    }
    public override void OnOpen()
    {
        base.OnOpen();
    }
    public override void OnClose()
    {
        base.OnClose();
    }
}
