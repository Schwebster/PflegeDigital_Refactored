using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.TooltipClasses;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Error
{
    private GameObject error;
    private Text errorText, errorCounter;
    private RectTransform errorBackgroundRectTransform;
    public int errorCount {  get; set; }


    public Error()
    {
        errorCount = 0;
        errorBackgroundRectTransform = GameObject.Find("/Canvas/HUD/Error/errorBackground").GetComponent<RectTransform>();
        errorText = GameObject.Find("/Canvas/HUD/Error/errorText").GetComponent<Text>();
        error = GameObject.FindGameObjectWithTag("Error");
        errorCounter = GameObject.Find("/Canvas/HUD/ErrorCounter").GetComponent<Text>();
        errorCounter.text = LocalizationManager.Instance.GetText("ErrorCount") + "-";
        HideError();
    }

    public void ShowError(string tooltipString)
    {
        error.SetActive(true);

        errorText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(errorText.preferredWidth + textPaddingSize * 2f, errorText.preferredHeight + textPaddingSize * 2f);
        errorBackgroundRectTransform.sizeDelta = backgroundSize;
    }

    public void HideError()
    {
        error.SetActive(false);
    }

    public void UpdateErrorCounter()
    {
        errorCounter.text = LocalizationManager.Instance.GetText("ErrorCount") + errorCount;
    }
}
