using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundwave : MonoBehaviour
{
    bool setup = false;

    void FixedUpdate()
    {
        if (!setup)
            return;

        returnT = Mathf.Clamp((returnT + returnInterval) * Time.fixedDeltaTime, 0, 1);
        tempImpulse = Mathf.Lerp(tempImpulse, 0, returnT);

        UpdateSoundWaveSize(tempImpulse);

        if (returnT >= 1)
        {
            Destroy(this.gameObject);
        }
    }

    void UpdateSoundWaveSize(float size)
    {
        gameObject.transform.localScale = new Vector3(size, size, size);
    }

    public static float Remap(float inputValue, float fromMin, float fromMax, float toMin, float toMax)
    {
        float i = (((inputValue - fromMin) / (fromMax - fromMin)) * (toMax - toMin) + toMin);
        i = Mathf.Clamp(i, toMin, toMax);
        return i;
    }

    float tempImpulse = 0;
    float returnT = 0;
    float returnInterval;
    bool resettingSoundwave = false;

    public void Impulse(float strength, float returnInterval)
    {
        tempImpulse = strength;
        resettingSoundwave = true;
        this.returnInterval = returnInterval;
        returnT = 0;

        setup = true;
    }
}
