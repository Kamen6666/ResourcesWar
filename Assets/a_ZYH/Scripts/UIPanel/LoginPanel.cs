using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;
public class LoginPanel : UIModuleBase
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //绑定控制器
        BindController(new LoginController());
    }
    public override void OnOpen()
    {
        base.OnOpen();
        _animator.SetBool("Open",true);
    }
    
    public override void OnClose()
    {
        base.OnClose();
        _animator.SetBool("Open",false);
    }
}
