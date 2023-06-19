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

    [RequireComponent(typeof(Text))]
    public class LocalizedErrorCount : MonoBehaviour
    {
        string key;

        void Awake()
        {
            key = "ErrorCount";
            // Get the string value from localization manager from key 
            // and set the text component text value to the  returned string value 
            GetComponent<Text>().text = LocalizationManager.Instance.GetText(key) + "-";
        }

        public void UpdateErrCount(int Count)
        {
            GetComponent<Text>().text = LocalizationManager.Instance.GetText(key) + Count;
        }
    }
}