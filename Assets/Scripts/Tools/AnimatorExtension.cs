using System.Collections.Generic;
using UnityEngine;

public static class AnimatorExtension
{
    public static int GetAnimationParameter(Animator animator, string paramName, AnimatorControllerParameterType paramType)
    {
        int parameter = -1;

        if (animator != null && !string.IsNullOrEmpty(paramName))
        {
            if (animator.HasParameterOfType(paramName, paramType))
            {
                parameter = Animator.StringToHash(paramName);
            }
        }

        return parameter;
    }


    static bool HasParameterOfType(this Animator animator, string paramName, AnimatorControllerParameterType paramType)
    {
        foreach (var parameter in animator.parameters)
        {
            if (parameter.name == paramName && parameter.type == paramType)
            {
                return true;
            }
        }

        return false;
    }
}
