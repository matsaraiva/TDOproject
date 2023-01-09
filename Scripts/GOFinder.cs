using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOFinder : MonoBehaviour
{
    // reference 2 of https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    public GameObject ClosestTarget(GameObject reference, string targetTag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = reference.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
