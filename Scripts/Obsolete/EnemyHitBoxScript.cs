using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBoxScript : MonoBehaviour
{
    private GameObject gameManager;
    private GoldScript gold;

    [SerializeField]
    private float _hitPoints;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gold = gameManager.GetComponent<GoldScript>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AllyProjectile")
        {
            if (_hitPoints > 1)
            {
                BulletScript bulletScript = other.GetComponent<BulletScript>();
                _hitPoints -= bulletScript.damage;
            }
            else
            {
                gold.gold += 5;
                Destroy(transform.parent.gameObject);
            }
            //destroy projectile
            Destroy(other);
        }
    }
}
