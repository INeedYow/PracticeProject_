using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ShowIfTrue : PropertyAttribute
{
    public string conditionBoolean = "";
    public bool hidden = false;

    public ShowIfTrue(string conditionBoolean)
    {
        this.conditionBoolean = conditionBoolean;
        this.hidden = false;
    }

    public ShowIfTrue(string conditionBoolean, bool hidden)
    {
        this.conditionBoolean = conditionBoolean;
        this.hidden = hidden;
    }
}
