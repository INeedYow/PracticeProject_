using UnityEngine;


public abstract class AnimationParameter
{
    [SerializeField] 
    protected string parameterName;
    [SerializeField, CustomReadOnly] 
    protected AnimatorControllerParameterType parameterType;

    protected int parameter = -1;
    protected bool initialized;


    public AnimationParameter(AnimatorControllerParameterType paramType, string paramName)
    {
        parameterName = paramName;
        parameterType = paramType;
    }

    protected virtual void Initialize(Animator animator)
    {
        if (!initialized)
        {
            parameter = AnimatorExtension.GetAnimationParameter(animator, parameterName, parameterType);
            initialized = true;
        }
    }

    protected bool IsValidParameter(Animator animator) 
    {
        if (animator == null)
        {
            return false;
        }

        if (!initialized)
        {
            Initialize(animator);
        }

        return parameter != -1;
    }
}

[System.Serializable]
public class BoolAnimationParameter : AnimationParameter
{
    public BoolAnimationParameter(string paramName = "") : base(AnimatorControllerParameterType.Bool, paramName) { }

    public virtual void UpdateParameter(Animator animator, bool value)
    {
        if (IsValidParameter(animator))
        {
            animator.SetBool(parameter, value);
        }
    }
}

[System.Serializable]
public class FloatAnimationParameter : AnimationParameter
{
    public FloatAnimationParameter(string paramName = "") : base(AnimatorControllerParameterType.Float, paramName) { }

    public virtual void UpdateParameter(Animator animator, float value)
    {
        if (IsValidParameter(animator))
        {
            animator.SetFloat(parameter, value);
        }
    }
}

[System.Serializable]
public class IntAnimationParameter : AnimationParameter
{
    public IntAnimationParameter(string paramName = "") : base(AnimatorControllerParameterType.Int, paramName) { }

    public virtual void UpdateParameter(Animator animator, int value)
    {
        if (IsValidParameter(animator))
        {
            animator.SetInteger(parameter, value);
        }
    }
}

[System.Serializable]
public class TriggerAnimationParameter : AnimationParameter
{
    public TriggerAnimationParameter(string paramName = "") : base(AnimatorControllerParameterType.Trigger, paramName) { }

    public virtual void UpdateParameter(Animator animator)
    {
        if (IsValidParameter(animator))
        {
            animator.SetTrigger(parameter);
        }
    }

    public virtual void ResetParameter(Animator animator)
    {
        if (IsValidParameter(animator))
        {
            animator.ResetTrigger(parameter);
        }
    }
}
