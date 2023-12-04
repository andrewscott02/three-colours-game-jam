using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundwaveManager : MonoBehaviour
{
    public GameObject soundWaveGO;

    public Vector2 breathingMinMax = new Vector2(0.5f, 1);
    public float stopDelay = 0.4f;
    public float tInterval = 0.1f;
    float currentTTime;
    bool advancing = false;

    // Start is called before the first frame update
    void Start()
    {
        advancing = true;
        currentTTime = 0;
        UpdateSoundWaveSize(breathingMinMax.x);
    }

    // Update is called once per frame
    void Update()
    {
        currentTTime = Mathf.Clamp(advancing ? currentTTime + tInterval : currentTTime - tInterval, 0, 1);
        float size = Remap(currentTTime, 0, 1, breathingMinMax.x, breathingMinMax.y);
        UpdateSoundWaveSize(size);

        if (currentTTime >= 1)
        {
            advancing = false;
        }
        else if (currentTTime <= 0)
        {
            advancing = true;
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
}
