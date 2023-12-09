using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public Object soundwaveObject;
    public float impulseMultiplier = 2f;
    public float soundMultiplier = 0.5f;
    public float returnT = 0.001f;
    public float minImpactThreshold = 0.75f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minImpactThreshold)
        {
            GameObject GO = Instantiate(soundwaveObject, collision.GetContact(0).point, Quaternion.identity) as GameObject;

            Soundwave soundwaveScript = GO.GetComponent<Soundwave>();
            soundwaveScript.Impulse(impulseMultiplier * collision.relativeVelocity.magnitude, returnT);

            AudioManager.instance.PlaySoundEffect(AudioManager.instance.defaultThud, soundMultiplier * collision.relativeVelocity.magnitude);
        }
    }
}
