using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScript : MonoBehaviour
{
    public float hitPoints;

    //projetil que causara dano
    public string otherProjectileTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == otherProjectileTag)
        {
            //take demage
            if (hitPoints > 1)
            {
                BulletScript bulletScript = other.GetComponent<BulletScript>();
                hitPoints -= bulletScript.damage;
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
            //destroy projectile
            Destroy(other);
        }
    }

}
