using UnityEngine;
using UIFrame;
public class InitPanel : UIModuleBase
{
    private void Start() {
        //绑定控制器
        BindController(new InitController());
    }
    public override void OnOpen()
    {
        base.OnOpen();
        //打开登录面板
        UIManager.GetInstance().VagueOpenModule("LoginPanel",null);
    }
    public override void OnClose()
    {
        base.OnClose();
    }

}
