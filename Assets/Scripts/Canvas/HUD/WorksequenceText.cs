using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.TooltipClasses;

namespace Assets.Scripts.Menu
{
    public class WorksequenceText
    {
        public Text worksequenceText { get; private set; }

        public WorksequenceText()
        {
            worksequenceText = GameObject.Find("Canvas/HUD/TextWorksequence").GetComponent<Text>();
            worksequenceText.text = LocalizationManager.Instance.GetText("workSequence1");
        }

        public void UpdateWorksequenceText(WorkSequence workSequence)
        {
            string workSequenceString = workSequence.sequenceID.Substring(0, workSequence.sequenceID.Length - 3);
            worksequenceText.text = LocalizationManager.Instance.GetText(workSequenceString);
        }
    }
}