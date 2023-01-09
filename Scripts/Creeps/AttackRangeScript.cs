using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeScript : MonoBehaviour
{
    public bool inAttackRange = false;

    public string targetHitboxTag;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == targetHitboxTag)
        {
            inAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == targetHitboxTag)
        {
            inAttackRange = false;
        }
    }
}
