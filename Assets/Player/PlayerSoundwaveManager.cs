using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundwaveManager : MonoBehaviour
{
    public GameObject soundWaveGO;

    public Vector2 baseSoundwaveMinMax = new Vector2(1.4f, 1.8f);
    Vector2 soundwaveMinMax = new Vector2(1.4f, 1.8f);
    public float stopDelay = 0.4f;
    public float tInterval = 0.0005f;
    float currentTTime;
    bool advancing = false;

    // Start is called before the first frame update
    void Start()
    {
        soundwaveMinMax = baseSoundwaveMinMax;
        advancing = true;
        currentTTime = 0;
        UpdateSoundWaveSize(soundwaveMinMax.x);
    }

    // Update is called once per frame
    void Update()
    {
        currentTTime = Mathf.Clamp(advancing ? currentTTime + tInterval : currentTTime - tInterval, 0, 1);
        float size = Remap(currentTTime, 0, 1, soundwaveMinMax.x, soundwaveMinMax.y);
        UpdateSoundWaveSize(size + tempImpulse);

        if (currentTTime >= 1)
        {
            advancing = false;
        }
        else if (currentTTime <= 0)
        {
            advancing = true;
        }

        if (resettingSoundwave)
        {
            returnT = Mathf.Clamp(returnT + returnInterval, 0, 1);
            tempImpulse = Mathf.Lerp(tempImpulse, 0, returnT);

            if (returnT >= 1)
            {
                resettingSoundwave = false;
            }
        }
    }

    void UpdateSoundWaveSize(float size)
    {
        soundWaveGO.transform.localScale = new Vector3(size, size, size);
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
    }
}
