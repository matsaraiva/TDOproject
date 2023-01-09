using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipHitboxScript : MonoBehaviour
{
    [SerializeField]
    private float _hitPoints;

    [SerializeField]
    private string _enemyTeam;

    [SerializeField]
    private GameController _gameController;

    public string otherProjectileTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == otherProjectileTag)
        {
            //take demage
            if (_hitPoints > 1)
            {
                BulletScript bulletScript = other.GetComponent<BulletScript>();
                _hitPoints -= bulletScript.damage;
            }
            else
            {
                Debug.Log("Game Over");
                _gameController.GameEnd(_enemyTeam);
            }
            //destroy projectile
            Destroy(other);
        }
    }
}
