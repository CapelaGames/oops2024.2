using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/glue")]
public class GluePowerup : Powerup
{
    public override void UsePowerup(Rigidbody rb)
    {
        Rigidbody[] otherRbs = FindObjectsOfType<Rigidbody>();

        
        HighscoreSystem.instance.StartCoroutine(StickyTime(rb,otherRbs));

        /*foreach (var otherRb in otherRbs)
        {
             otherRb.velocity *= 0.95f;
        }*/
    }
    
    IEnumerator StickyTime(Rigidbody rb, Rigidbody[] otherRbs)
    {
        float startTime = Time.time;

        while (startTime + duration > Time.time)
        {
            for (int i = 0; i < otherRbs.Length; i++)
            {
                Rigidbody otherRb = otherRbs[i];

                if (otherRb == rb) continue;
                if (otherRb.gameObject.layer != LayerMask.NameToLayer("Marble"))
                {
                    continue; 
                }
                float reduction = Mathf.Clamp01( Mathf.InverseLerp(100,0,power) );
                otherRb.velocity *= reduction;
            }
            yield return new WaitForFixedUpdate();
        }

    }
}
