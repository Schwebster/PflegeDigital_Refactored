using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.TooltipClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Canvas.GUI.Buttons
{
    public class ButtonWorkSequence : MonoBehaviour
    {
        private string _buttonName;
        MainScene _mainScene;
        GameObject tweezer, compress, swab;
        public AnimationClip tweezerOpeningClip;
        public AnimationClip swabOpeningClip;
        public AnimationClip compressOpeningClip;

        void Awake()
        {
            _buttonName = gameObject.name;
            _mainScene = GameObject.FindGameObjectWithTag("Main").GetComponent<MainScene>();
            tweezer = GameObject.Find("Scene/Objects/TooltipObjects/Tweezer/Tweezer_Model");
            compress = GameObject.Find("Scene/Objects/TooltipObjects/Compress/Compress_Model");
            swab = GameObject.Find("Scene/Objects/TooltipObjects/Swab/Swab_Model");

            Language();
        }

        private void PressButton()
        {
            _mainScene.LoadWorkSequence(_buttonName);


            if (_buttonName.Equals("workSequence0_00") ||
                _buttonName.Equals("workSequence6_00") ||
                _buttonName.Equals("workSequence10_00"))
            {
                tweezerOpeningClip.SampleAnimation(tweezer, 0);
                compressOpeningClip.SampleAnimation(compress, 0);
                swabOpeningClip.SampleAnimation(swab, 0);
            }
            else
            {
                tweezerOpeningClip.SampleAnimation(tweezer, 10);
                compressOpeningClip.SampleAnimation(compress, 10);
                swabOpeningClip.SampleAnimation(swab, 10);
            }
        }

        private void Language()
        {
            GetComponentInChildren<Text>().text = LocalizationManager.Instance.GetText("Heading_" + _buttonName);
        }
    }
}
