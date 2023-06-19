using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class Test
{
    [UnityTest]
    public IEnumerator TestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        Assert.AreEqual(1, 1);
    }

    [UnityTest]
    public IEnumerator NSubstitute_Test()
    {
        var nSubstituteTest = Substitute.For<INSubstituteTest>();
        var nSubUse = new NSubstituteUseTest();
        nSubstituteTest.ReturnOne().Returns(2);
        nSubUse.NSubTest = nSubstituteTest;

        nSubUse.SetNumber();

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        Assert.AreEqual(2, nSubUse.testNumber);
    }
}
