using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.TooltipClasses
{
    public class Tooltip
    {
        private Text _tooltipText;
        private RectTransform _tooltipBackground;
        private GameObject _tooltip;


        public Tooltip()
        {
            _tooltip = GameObject.FindGameObjectWithTag("Tooltip");
            _tooltipBackground = _tooltip.transform.Find("tooltipBackground").GetComponent<RectTransform>();
            _tooltipText = _tooltip.transform.Find("tooltipText").GetComponent<Text>();
            HideTooltip();
        }

        public void ShowTooltip(string tooltipString)
        {
            _tooltip.SetActive(true);

            _tooltipText.text = tooltipString;
            float textPaddingSize = 4f;
            Vector2 backgroundSize = new Vector2(_tooltipText.preferredWidth + textPaddingSize * 2f, _tooltipText.preferredHeight + textPaddingSize * 2f);
            _tooltipBackground.sizeDelta = backgroundSize;
        }

        public void HideTooltip()
        {
            _tooltip.SetActive(false);
        }
    }
}
