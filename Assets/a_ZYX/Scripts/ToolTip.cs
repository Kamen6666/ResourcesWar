using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolTip : MonoBehaviour
{
    private Text toolTipTxt;
    private Text contentTxt;
    private float targetAlpha=1;
    public float smoothing = 15;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        contentTxt = transform.Find("content").GetComponent<Text>();
        toolTipTxt = GetComponent<Text>();
    }

    void Update()
    {
        if (canvasGroup.alpha!=targetAlpha)
        {
            canvasGroup.alpha=Mathf.Lerp(canvasGroup.alpha, targetAlpha,smoothing*Time.deltaTime);
            if (Math.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public void Show(string text)
    {
        toolTipTxt.text = text;
        contentTxt.text = text;
        targetAlpha = 1;
    }

    public void Hide()
    {
        targetAlpha = 0;
    }

    public void SetLocalPosition(Vector2 position)
    {
        transform.localPosition = position;
    }
}
