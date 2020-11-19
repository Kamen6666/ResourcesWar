using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillsButton : MonoBehaviour, IPointerClickHandler
{
    public SkillData skillData;
    private void Awake()
    {
        
    }
   

    private void Start()
    {
        skillData = Resources.Load<SkillData>($"SkillData/{gameObject.name.Substring(0, 2)}");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SkillManager.instance.activeSkill = skillData;
        SkillManager.instance.DisplaySkillInfo();

    }
   
}
