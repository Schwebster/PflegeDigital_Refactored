using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ObjectClasses;
using UnityEngine;

namespace Assets.Scripts.Lists
{
    public class IconList
    {
        public List<Icon> list { get; private set; }

        public IconList() { 
            list = new List<Icon>();       
        }

        public void Substitute(List<Icon> icons)
        {
            list = new List<Icon>();
            foreach (Icon icon in icons)
            {
                Icon _icon = new Icon(icon.name);
                _icon.SetActive(icon.isActive);
                list.Add(_icon);
            }
        }
        public void InitializeStartList()
        {
            list = new List<Icon>();
            foreach (GameObject iconObj in GameObject.FindGameObjectsWithTag("Icon"))
            {
                Icon icon = new Icon(iconObj.name);
                list.Add(icon);
                Hands();
                Body();
                Face();
            }
        }
        public void Hands()
        {
            foreach (Icon icon in list)
            {
                if (icon.name.Equals("Hand_Left") || icon.name.Equals("Hand_Right"))
                {
                    icon.SetActive(true);
                } else if (icon.name.Equals("Hand_Left_Disinfected") || icon.name.Equals("Hand_Right_Disinfected") ||
                    icon.name.Equals("Glove_Left") || icon.name.Equals("Glove_Right"))
                {
                    icon.SetActive(false);
                }
            }
        }
        public void HandsDisinfected()
        {
            foreach (Icon icon in list)
            {
                if (icon.name.Equals("Hand_Left_Disinfected") || icon.name.Equals("Hand_Right_Disinfected"))
                {
                    icon.SetActive(true);
                }
                if (icon.name.Equals("Hand_Left") || icon.name.Equals("Hand_Right") ||
                    icon.name.Equals("Glove_Left") || icon.name.Equals("Glove_Right"))
                {
                    icon.SetActive(false);
                }
            }
        }
        public void Gloves()
        {
            foreach (Icon icon in list)
            {
                if (icon.name.Equals("Glove_Left") || icon.name.Equals("Glove_Right"))
                {
                    icon.SetActive(true);
                }
                if (icon.name.Equals("Hand_Left") || icon.name.Equals("Hand_Right") ||
                    icon.name.Equals("Hand_Left_Disinfected") || icon.name.Equals("Hand_Right_Disinfected"))
                {
                    icon.SetActive(false);
                }
            }
        }
        public void Face() {
            foreach (Icon icon in list)
            {
                if (icon.name.Equals("Face"))
                {
                    icon.SetActive(true);
                }
                if (icon.name.Equals("Face_Mask"))
                {
                    icon.SetActive(false);
                }
            }
        }
        public void FaceMask()
        {
            foreach (Icon icon in list)
            {
                if (icon.name.Equals("Face_Mask"))
                {
                    icon.SetActive(true);
                }
                if (icon.name.Equals("Face"))
                {
                    icon.SetActive(false);

                }
            }
        }              
        public void Body() {
            foreach (Icon icon in list)
            {
                if (icon.name.Equals("Body"))
                {
                    icon.SetActive(true);
                }
                if (icon.name.Equals("Body_Apron"))
                {
                    icon.SetActive(false);

                }
            }
        }
        public void Apron() {
            foreach (Icon icon in list)
            {
                if (icon.name.Equals("Body_Apron"))
                {
                    icon.SetActive(true);
                }
                if (icon.name.Equals("Body"))
                {
                    icon.SetActive(false);

                }
            }
        }
    }
}
