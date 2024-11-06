using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : TriggerZone, IClickable
{
    public Powerup[] powerup;

    public float speed = 20;
    public int totalPUChances;

    float cooldown = 0;

    public void Start()
    {
        totalPUChances = 0;
        foreach (Powerup PU in powerup)
        {
            totalPUChances += PU.chance;
        }
    }
    public override void Activate(Collider collider)
    {
        if (cooldown > 0) return;

        Powerup chosenPU = null;
        int PUCountdown = Random.Range(0, totalPUChances);
        foreach (Powerup PU in powerup)
        {
            PUCountdown -= PU.chance;
            if(PUCountdown < 0)
            {
                chosenPU = PU;
                break;
            }
        }
        if (chosenPU == null) return;
        chosenPU.UsePowerup(collider.attachedRigidbody);
        cooldown = chosenPU.cooldown;
    }

    private void Update()
    {
       // current += speed * Time.deltaTime;
       //transform.rotation = Quaternion.AngleAxis(current , Vector3.up);
       transform.Rotate(Vector3.up, speed * Time.deltaTime);
       cooldown -= Time.deltaTime;
    }

    public void OnClick()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        speed += 200f;
        yield return new WaitForSeconds(2f);
        speed -= 200f;
    }    
}
