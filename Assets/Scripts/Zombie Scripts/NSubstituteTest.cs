using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface INSubstituteTest
{
    public int ReturnOne();
}

public class NSubstituteTest : INSubstituteTest
{
    public NSubstituteTest() { }

    public int ReturnOne()
    {
        return 1;
    }
}

public class NSubstituteUseTest
{
    public INSubstituteTest NSubTest { get; set; }

    public int testNumber { get; set; }
    public NSubstituteUseTest()
    {
        NSubTest = new NSubstituteTest();
        testNumber = 0;
    }

    public void SetNumber()
    {
        testNumber = NSubTest.ReturnOne();
    }
}
