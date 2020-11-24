using UIFrame;
using UnityEngine;

public class SkillTree_Panel : UIModuleBase
{
	SkillTree_PanelController controller;
	protected void Start()
	{
        if (controller == null)
        {
            controller = new SkillTree_PanelController();
            BindController(controller);
        }
        //controller.Clear();
	}
    public override void OnOpen()
    {
        base.OnOpen();
        if (controller == null)
        {
            controller = new SkillTree_PanelController();
            BindController(controller);
        }
		controller.Refresh();
        //controller.Clear();
    }
}