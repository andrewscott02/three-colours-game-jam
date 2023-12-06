using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public Object soundwaveObject;
    public float impulseMultiplier = 2f;
    public float returnT = 0.001f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            GameObject GO = Instantiate(soundwaveObject, collision.GetContact(0).point, Quaternion.identity) as GameObject;

            Soundwave soundwaveScript = GO.GetComponent<Soundwave>();
            soundwaveScript.Impulse(impulseMultiplier * collision.relativeVelocity.magnitude, returnT);
        }
    }
}
