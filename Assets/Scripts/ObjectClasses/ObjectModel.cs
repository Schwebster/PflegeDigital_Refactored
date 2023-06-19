using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ObjectClasses
{
    public class ObjectModel
    {
        public string name { get; private set; }
        public bool isActive { get; private set; }

        public ObjectModel(string _name, bool _isActive) { 
            name = _name;
            isActive = _isActive;
        }

        public void SetActive(bool _isActive)
        {
            if (isActive == _isActive)
            {
                throw new Exception(name + " was already on " + _isActive.ToString());
            }

            isActive = _isActive;
        }
    }
}
