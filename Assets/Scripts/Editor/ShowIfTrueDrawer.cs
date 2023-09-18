using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


[CustomPropertyDrawer(typeof(ShowIfTrue))]
public class ShowIfDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfTrue conditionAttribute = (ShowIfTrue)attribute;
        bool enabled = GetConditionAttributeResult(conditionAttribute, property);
        bool previouslyEnabled = GUI.enabled;
        GUI.enabled = enabled;
        if (!conditionAttribute.hidden || enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
        GUI.enabled = previouslyEnabled;
    }

    private bool GetConditionAttributeResult(ShowIfTrue condHAtt, SerializedProperty property)
    {
        bool enabled = true;
        string propertyPath = property.propertyPath;
        string conditionPath = propertyPath.Replace(property.name, condHAtt.conditionBoolean);
        SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

        if (sourcePropertyValue != null)
        {
            enabled = sourcePropertyValue.boolValue;
        }
        else
        {
            Debug.LogWarning("No matching boolean found for ConditionAttribute in object: " + condHAtt.conditionBoolean);
        }

        return enabled;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowIfTrue conditionAttribute = (ShowIfTrue)attribute;
        bool enabled = GetConditionAttributeResult(conditionAttribute, property);

        if (!conditionAttribute.hidden || enabled)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
        else
        {
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
