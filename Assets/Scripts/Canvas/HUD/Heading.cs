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
    public class Heading
    {
        public Text heading { get; private set; }
        public Heading()
        {
            heading = GameObject.Find("Canvas/HUD/TextHeading").GetComponent<Text>();
            heading.text = LocalizationManager.Instance.GetText("Heading_workSequence0_00");
        }

        public void UpdateHeadingText(WorkSequence currentWorkSequence)
        {
            if (currentWorkSequence.sequenceID.Equals("workSequence0_00") ||
                currentWorkSequence.sequenceID.Equals("workSequence6_00") ||
                currentWorkSequence.sequenceID.Equals("workSequence10_00") ||
                currentWorkSequence.sequenceID.Equals("workSequence14_00") ||
                currentWorkSequence.sequenceID.Equals("workSequence19_00") ||
                currentWorkSequence.sequenceID.Equals("workSequence27_00") ||
                currentWorkSequence.sequenceID.Equals("workSequence32_00") ||
                currentWorkSequence.sequenceID.Equals("workSequence38_00"))
            {
                heading.text = LocalizationManager.Instance.GetText("Heading_" + currentWorkSequence.sequenceID);
            }
        }
    }
}
