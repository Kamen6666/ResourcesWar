using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

public class CreatePanel : UIModuleBase
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
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
        _animator.SetBool("Show",true);
    }

    public override void OnClose()
    {
        base.OnClose();
        _animator.SetBool("Show",false);
    }

    public override void OnResume()
    {
        base.OnResume();
    }
}
