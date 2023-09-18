using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public BoolAnimationParameter boolAnimationParameter = new BoolAnimationParameter("boolParam");
    public FloatAnimationParameter floatAnimationParameter = new FloatAnimationParameter("floatParam");
    public IntAnimationParameter intAnimationParameter = new IntAnimationParameter("intParam");
    public TriggerAnimationParameter triggerAnimationParameter = new TriggerAnimationParameter("triggerParam");

    [Space(10)]

    [CustomReadOnly]
    public int testIntValue = 1;

    [Space(10)]

    public bool testBoolValue;

    [ShowIfTrue("testBoolValue", true)]
    public bool lookAtMe;
    [ShowIfTrue("testBoolValue", false)]
    public bool canYouSeeMe;
}
