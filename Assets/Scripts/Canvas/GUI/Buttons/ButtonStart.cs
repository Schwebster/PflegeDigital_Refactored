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
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class ButtonStart : MonoBehaviour
    {
        private void Awake()
        {
            if (LocalizationManager.Instance != null)
            GetComponentInChildren<Text>().text = LocalizationManager.Instance.GetText("Start");
        }

        public void StartApp()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}