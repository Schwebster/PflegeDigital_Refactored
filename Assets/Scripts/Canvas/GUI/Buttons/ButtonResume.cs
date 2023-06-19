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

namespace Assets.Scripts.Menu
{
    public class ButtonResume : MonoBehaviour
    {
        private PauseMenu _pauseMenu;

        private void Awake()
        {
            _pauseMenu = GameObject.FindGameObjectWithTag("GUI").GetComponent<PauseMenu>();
            GetComponentInChildren<Text>().text = LocalizationManager.Instance.GetText("Resume");
        }

        public void Resume()
        {
            _pauseMenu.Resume();
        }
        
    }
}
