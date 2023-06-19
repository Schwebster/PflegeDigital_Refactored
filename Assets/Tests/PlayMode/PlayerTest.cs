using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
public class PlayerTest
{
    [UnityTest]
    public IEnumerator Moves_Positiv_Along_X_Axis_For_Positiv_Horizontal_Input()
    {
        GameObject playerObj = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.SetBodyMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.MoveX().Returns(1f);
        

        playerScript._input = input;

        cc.Move(
            playerObj.transform.TransformDirection(
            playerScript.bodyMovement.Calculate(
                playerScript._input.MoveX(),
                playerScript._input.MoveZ()
                )));
        
        yield return null;

        Assert.AreEqual(1, 1);
    }

    [UnityTest]
    public IEnumerator Moves_Negativ_Along_X_Axis_For_Negativ_Horizontal_Input()
    {
        GameObject playerObj = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.SetBodyMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.MoveX().Returns(-1f);

        playerScript._input = input;

        cc.Move(
            playerObj.transform.TransformDirection(
            playerScript.bodyMovement.Calculate(
                playerScript._input.MoveX(),
                playerScript._input.MoveZ()
                )));

        yield return null;

        Assert.AreEqual(-1, playerObj.transform.position.x);
    }

    [UnityTest]
    public IEnumerator Moves_Positiv_Along_Z_Axis_For_Positiv_Vertical_Input()
    {
        GameObject playerObj = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.SetBodyMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.MoveZ().Returns(1f);

        playerScript._input = input;

        cc.Move(
            playerObj.transform.TransformDirection(
            playerScript.bodyMovement.Calculate(
                playerScript._input.MoveX(),
                playerScript._input.MoveZ()
                )));

        yield return null;

        Assert.AreEqual(1, playerObj.transform.position.z);
    }

    [UnityTest]
    public IEnumerator Moves_Negativ_Along_Z_Axis_For_Negativ_Vertical_Input()
    {
        GameObject playerObj = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.SetBodyMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.MoveZ().Returns(-1f);

        playerScript._input = input;

        cc.Move(
            playerObj.transform.TransformDirection(
            playerScript.bodyMovement.Calculate(
                playerScript._input.MoveX(),
                playerScript._input.MoveZ()
                )));

        yield return null;

        Assert.AreEqual(-1, playerObj.transform.position.z);
    }

    [UnityTest]
    public IEnumerator Camera_Rotate_Positiv_Along_X_Axis_For_Negativ_Vertical_MouseInput()
    {
        GameObject playerObj = new GameObject();
        GameObject camera = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.fpsCamera = camera;
        playerScript.SetHeadMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.LookX().Returns(-1f);
        playerScript._input = input;

        playerScript.LookVertical();

        float quaternionX = Quaternion.Euler(1, 0, 0).x;
        float cameraRotationX = camera.transform.rotation.x;

        yield return null;

        Assert.IsTrue(Math.Abs(quaternionX - cameraRotationX) < 0.0001f);
    }


    [UnityTest]
    public IEnumerator Camera_Rotate_Negativ_Along_X_Axis_For_Positiv_Vertical_MouseInput()
    {
        GameObject playerObj = new GameObject();
        GameObject camera = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.fpsCamera = camera;
        playerScript.SetHeadMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.LookX().Returns(1f);
        playerScript._input = input;

        playerScript.LookVertical();

        float quaternionX = Quaternion.Euler(-1, 0, 0).x;
        float cameraRotationX = camera.transform.rotation.x;

        yield return null;

        Assert.IsTrue(Math.Abs(quaternionX - cameraRotationX) < 0.0001f);
    }

    [UnityTest]
    public IEnumerator Rotates_Positiv_Along_Y_Axis_For_Positiv_Horizontal_MouseInput()
    {
        GameObject playerObj = new GameObject();
        GameObject camera = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.fpsCamera = camera;
        playerScript.SetHeadMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.LookY().Returns(1f);
        playerScript._input = input;

        playerScript.LookHorizontal();

        float quaternionY = Quaternion.Euler(0, 1, 0).y;
        float cameraRotationY = playerObj.transform.rotation.y;

        yield return null;

        Assert.IsTrue(Math.Abs(quaternionY - cameraRotationY) < 0.0001f);
    }

    [UnityTest]
    public IEnumerator Rotates_Negativ_Along_Y_Axis_For_Negativ_Horizontal_MouseInput()
    {
        GameObject playerObj = new GameObject();
        GameObject camera = new GameObject();
        playerObj.AddComponent<Player>();
        playerObj.AddComponent<CharacterController>();
        Player playerScript = playerObj.GetComponent<Player>();
        CharacterController cc = playerObj.GetComponent<CharacterController>();
        playerScript.fpsCamera = camera;
        playerScript.SetHeadMovementSpeed(1);
        var input = Substitute.For<IInputLoadManager>();
        input.LookY().Returns(-1f);
        playerScript._input = input;

        playerScript.LookHorizontal();

        float quaternionY = Quaternion.Euler(0, -1, 0).y;
        float cameraRotationY = playerObj.transform.rotation.y;

        yield return null;

        Assert.IsTrue(Math.Abs(quaternionY - cameraRotationY) < 0.0001f);
    }
}

