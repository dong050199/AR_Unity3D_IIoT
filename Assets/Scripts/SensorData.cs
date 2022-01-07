using UnityEngine;

[System.Serializable]
public class SensorData 
{
    public float flowsp=0f;
    public float flowpv=0f;
    public float p3 = 0f;
    public float val = 0f;
    public float sen = 0f;

    public static SensorData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<SensorData>(jsonString);
    }
}
