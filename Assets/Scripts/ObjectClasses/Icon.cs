using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ObjectClasses
{
    public class Icon
    {
        public string name { get; private set; }
        public bool isActive { get; private set; }

        public Icon(string _name)
        {
            name = _name;
        }

        public void SetActive(bool _isActive) { 
            isActive = _isActive;
        }
    }
}
