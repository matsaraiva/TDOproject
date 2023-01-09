using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //gamemanager
    private GameObject gameManager;
    private GOFinder find;
    //movement
    [SerializeField]
    private float _moveSpeed;

    private EnemyWayPoints _waypoints;

    private int _wpIndex;

    //attack

    [SerializeField]
    private float _fireRate;

    private float _nextFire = 0.0f;

    private bool _inAttackRange;

    [SerializeField]
    private GameObject _bulletPrefab;


    void Start()
    {
        //gamemanager
        gameManager = GameObject.Find("GameManager");
        find = gameManager.GetComponent<GOFinder>();

        //procurar pelos waypoints
        _waypoints = GameObject.FindGameObjectWithTag("EnemyWayPoints").GetComponent<EnemyWayPoints>();
        StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {

        if (_inAttackRange)
        {
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                Transform location = GetComponent<Transform>();
                Instantiate(_bulletPrefab, location);
            }
        }
        else
        {
            move();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "AllyHitBox")
        {
            _inAttackRange = true;
            //olhar para alvo
            GameObject target = find.ClosestTarget(this.gameObject, "AllyHitBox");
            transform.up = (Vector2)target.transform.position - (Vector2)transform.position;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "AllyHitBox")
        {
            _inAttackRange = false;
        }
    }

    private void move()
    {
        //waypoint atual
        Vector2 currentWayPoint = _waypoints.enemyWayPoints[_wpIndex].position;

        float step = _moveSpeed * Time.deltaTime;

        //se move para o waypoint atual
        transform.position = Vector2.MoveTowards(transform.position, currentWayPoint, step);

        //ao atingir o waypoint atual, muda para o proximo
        if (Vector2.Distance(transform.position, currentWayPoint) < 0.1f)
        {
            //checar se chegou ao fim
            if (_wpIndex < _waypoints.enemyWayPoints.Length - 1)
            {
                _wpIndex++;
            }
            //chegou ao fim
            else
            {
                Destroy(this.gameObject);
            }
        }

        //olhar para o waypoint atual
        transform.up = currentWayPoint - (Vector2)transform.position;
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(14.95f);
        Destroy(this.gameObject);
    }

}
