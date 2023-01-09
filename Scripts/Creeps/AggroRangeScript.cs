using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRangeScript : MonoBehaviour
{
    public bool inAggroRange = false;

    public string targetHitboxTag;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == targetHitboxTag)
        {
            inAggroRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == targetHitboxTag)
        {
            inAggroRange = false;
        }
    }
}
