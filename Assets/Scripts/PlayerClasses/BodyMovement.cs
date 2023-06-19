using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using UnityEngine;

namespace Assets.Scripts.PlayerClasses {
    public class BodyMovement
    {
        private float _movementSpeed;

        public BodyMovement(float speed)
        {
            _movementSpeed = speed;
        }

        public Vector3 Calculate(float h, float v)
        {
            var x = h * _movementSpeed * Time.timeScale;
            var y = v * _movementSpeed * Time.timeScale;
            return new Vector3(x, 0, y);
        }
    }
}


