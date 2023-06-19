using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ObjectClasses;
using UnityEngine;

namespace Assets.Scripts.Lists
{
    public  class ObjectAnimationList
    {
        public List<ObjectAnimation> list;

        private GameObject tissue, compress, swab, tweezer,
             tweezerAtHand, woundDisinfectant;

        public ObjectAnimationList() {
            list = new List<ObjectAnimation>();   
        }

        public void InitializeStartList()
        {
            tissue = GameObject.Find("Scene/Objects/TooltipObjects/Tissue");
            compress = GameObject.Find("Scene/Objects/TooltipObjects/Compress/Compress_Model");
            swab = GameObject.Find("Scene/Objects/TooltipObjects/Swab/Swab_Model");
            tweezer = GameObject.Find("Scene/Objects/TooltipObjects/Tweezer/Tweezer_Model");
            tweezerAtHand = GameObject.Find("Scene/Objects/TooltipObjects/TweezerAtHand");
            woundDisinfectant = GameObject.Find("Scene/Objects/TooltipObjects/WoundDisinfectant");


            list.Add(new ObjectAnimation(tissue, "Tissue_big"));
            list.Add(new ObjectAnimation(tissue, "Tissue_small"));
            list.Add(new ObjectAnimation(compress, "openingCompress"));
            list.Add(new ObjectAnimation(swab, "openingSwab"));
            list.Add(new ObjectAnimation(tweezer, "openingTweezer"));
            list.Add(new ObjectAnimation(woundDisinfectant, "Tupfer_traenken"));
            list.Add(new ObjectAnimation(tweezerAtHand, "CleaningWound"));
        }

        public void Substitute(List<ObjectAnimation> objAnimations)
        {
            list = new List<ObjectAnimation>();

            foreach (ObjectAnimation objAnimation in objAnimations)
            {
                ObjectAnimation objAnim = new ObjectAnimation(objAnimation.animationObject, objAnimation.name);
                objAnim.SetAnimationPlayed(objAnimation.alreadyPlayed);
                list.Add(objAnim);
            }
        }

        public ObjectAnimation GetAnimation(string name)
        {
            foreach (ObjectAnimation objectAnimation in list)
            {
                if (objectAnimation.name.Equals(name))
                {
                    return objectAnimation;
                }
            }
            throw new Exception(name + " does not Exist in objectAnimationList");
        }

        public void InitializeAnimationsStates()
        {
            foreach (ObjectAnimation objectAnimation in list)
            {
                if (!objectAnimation.alreadyPlayed)
                {
                    objectAnimation.Rewind();
                }
            }
        }
    }
}
