using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ObjectClasses
{
    public class Hitplane
    {
        public string name { get; private set; }
        public Vector3 position { get; private set; }
        public bool isActive { get; private set; }

        public Hitplane(string _name, Vector3 _position) { 
            name = _name;
            position = _position;
        }

        public void SetActive(bool active) { 
            isActive = active;
        }


    }
}
