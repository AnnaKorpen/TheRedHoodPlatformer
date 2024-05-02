using System;

[Serializable]
public class FloatReference 
{
    public bool useConstant = true;
    public float constantValue;

    public FloatValueSO variable;

    public float value
    {
        get { return useConstant ? constantValue : variable.runtimeValue; }
    }
}
