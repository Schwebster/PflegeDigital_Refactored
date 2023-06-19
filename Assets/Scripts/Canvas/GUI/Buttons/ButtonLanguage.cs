using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.TooltipClasses;

namespace Assets.Scripts.Menu
{
    public class ButtonLanguage : MonoBehaviour
    {
        LocalizationManager localizedManager;
        //[SerializeField]
        GameObject[] texts;

        void Awake()
        {
            texts = GameObject.FindGameObjectsWithTag("Text");
            localizedManager = GameObject.Find("Canvas/LanguageManager").GetComponent<LocalizationManager>();
        }

        public void ChangeLang(int val)
        {
            localizedManager.currentLanguageID = val;
            foreach (GameObject gameObject in texts) { 
                gameObject.GetComponent<LocalizedText>().UpdateText(); 
            }
        }
    }
}