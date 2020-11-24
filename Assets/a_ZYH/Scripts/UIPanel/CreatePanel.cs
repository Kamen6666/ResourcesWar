using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

public class CreatePanel : UIModuleBase
{

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start() {
        //绑定控制器
        BindController(new CreateController());
    }
    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnOpen()
    {
        base.OnOpen();
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    public override void OnResume()
    {
        base.OnResume();
    }
}
