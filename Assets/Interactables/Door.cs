using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Interact(bool open)
    {
        if (open == push)
            return;

        Debug.Log("Door opening " + open);
        push = open;

        moving = true;
    }

    bool moving = false;
    bool push = false;
    Vector3 basePos;
    Vector3 pushPos;
    public Vector3 pushOffset = new Vector3(0, 6f, 0);
    float currentT = 0;
    public float pushSpeed = 1;

    private void Start()
    {
        basePos = transform.position;
        pushPos = basePos + pushOffset;
    }

    private void FixedUpdate()
    {
        if (!moving)
            return;

        transform.position = LerpVector3(basePos, pushPos, currentT);

        currentT = Mathf.Clamp(push ? currentT + (Time.fixedDeltaTime * pushSpeed) : currentT - (Time.fixedDeltaTime * pushSpeed), 0, 1);

        if (currentT <= 0 || currentT >= 1)
        {
            moving = false;

            SpawnImpulse();
        }
    }

    public static Vector3 LerpVector3(Vector3 a, Vector3 b, float p)
    {
        float x = Mathf.Lerp(a.x, b.x, p);
        float y = Mathf.Lerp(a.y, b.y, p);
        float z = Mathf.Lerp(a.z, b.z, p);
        return new Vector3(x, y, z);
    }

    public Object soundwaveObject;
    public float impulseStrength = 4f;
    public float returnT = 5f;

    private void SpawnImpulse()
    {
        GameObject GO = Instantiate(soundwaveObject, transform.position, Quaternion.identity) as GameObject;

        Soundwave soundwaveScript = GO.GetComponent<Soundwave>();
        soundwaveScript.Impulse(impulseStrength, returnT);
    }
}
