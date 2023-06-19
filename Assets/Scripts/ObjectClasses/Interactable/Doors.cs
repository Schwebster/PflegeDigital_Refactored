using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts.ObjectClasses
{
    public class Doors : MonoBehaviour
    {
        public GameObject doorLeft { get; private set; }
        public GameObject doorRight { get; private set; }
        public bool doorsAreOpen { get; set; }

        void Awake()
        {
            doorLeft = GameObject.Find("Scene/Objects/FirstAidCabinet/FirstAidCabinet_Model/DoorL");
            doorRight = GameObject.Find("FirstAidCabinet/FirstAidCabinet_Model/DoorR");
            CloseAnimation();
            doorsAreOpen = false;
        }

        public void CloseAnimation()
        {
            doorLeft.GetComponent<Animation>().Play("TuerL_zu");
            doorRight.GetComponent<Animation>().Play("TuerR_zu");
            doorsAreOpen = false;
        }

        public void OpenAnimation()
        {
            doorLeft.GetComponent<Animation>().Play("TuerL_auf");
            doorRight.GetComponent<Animation>().Play("TuerR_auf");
            doorsAreOpen = true;
        }

        public bool AnimationIsPLaying()
        {
            return doorLeft.GetComponent<Animation>().isPlaying;
        }

        public bool GetBoolDoorsAreOpen()
        {
            return doorsAreOpen;
        }
    }
}

