using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ObjectClasses
{
    public class ObjectAnimation
    {
        public GameObject animationObject { get; private set; }
        public Animation animation { get; private set; }
        public string name { get; private set; }
        public bool alreadyPlayed { get; private set; }

        public ObjectAnimation(GameObject anim, string animationName) { 
            animationObject = anim;
            animation = anim.GetComponent<Animation>();
            name = animationName;
            alreadyPlayed = false;
        }

        public void SetAnimationPlayed(bool played)
        {
            alreadyPlayed = played;
        }

        public void Play()
        {
            animation.Play(name);
        }

        public void Rewind()
        {
            animation.Rewind(name);
        }
    }
}
