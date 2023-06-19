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
    public class LocalizedText : MonoBehaviour
    {
        public string key;

        void Start()
        {
            // Get the string value from localization manager from key 
            // and set the text component text value to the  returned string value 
            GetComponent<Text>().text = LocalizationManager.Instance.GetText(key);
        }

        public void UpdateText()
        {
            GetComponent<Text>().text = LocalizationManager.Instance.GetText(key);
        }
    }
}