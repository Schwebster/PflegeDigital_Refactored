using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using UnityEngine;


namespace Assets.Scripts.Main
{
    public interface IUnityService
    {
        float GetAxis(string axisName);
        bool GetKeyDown(KeyCode keynName);
        bool GetMouseButtonUp(int mouseButton);
    }

    public class UnityService : IUnityService
    {
        public float GetAxis(string axisName)
        {
            return Input.GetAxis(axisName);
        }

        public bool GetKeyDown(KeyCode keyName)
        {
            return Input.GetKeyDown(keyName);
        }

        public bool GetMouseButtonUp(int mouseButton)
        {
            return Input.GetMouseButtonUp(mouseButton);
        }
    }
}
