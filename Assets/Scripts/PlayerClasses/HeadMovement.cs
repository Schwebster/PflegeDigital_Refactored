using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using UnityEngine;


namespace Assets.Scripts.PlayerClasses
{
    public class HeadMovement
    {
        private float _lookingSpeed;
        private float _cameraPitch = 0;

        public HeadMovement(float speed)
        {
            _lookingSpeed = speed;
        }

        public Quaternion CalculateX(float XAxis)
        {
            var lookX = XAxis * _lookingSpeed * Time.timeScale;

            _cameraPitch -= lookX;
            _cameraPitch = Mathf.Clamp(_cameraPitch, -60f, 70f);
            return Quaternion.Euler(_cameraPitch, 0, 0);
        }

        public Vector3 CalculateY(float YAxis)
        {
            var lookY = YAxis * _lookingSpeed * Time.timeScale;

            return new Vector3(0, lookY, 0);
        }
    }
}
