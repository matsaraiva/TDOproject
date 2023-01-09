using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GOFinder find;

    private GameObject _target;

    [SerializeField]
    private float _speed;

    public string targetTag;

    public float damage;


    void Start()
    {
        find = GameObject.Find("GameManager").GetComponent<GOFinder>();
        //acha o alvo mais proximo
        _target = find.ClosestTarget(this.gameObject, targetTag);

        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        float step = _speed * Time.deltaTime;

        //se o alvo não tiver sido destruido
        if (_target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, step);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

}
