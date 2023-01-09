using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepAtackMove : MonoBehaviour
{
    //manager
    private GOFinder find;

    //team
    [SerializeField]
    private int _team = 1;

    //move
    [SerializeField]
    private float _moveSpeed;

    private WayPointsScript _waypoints;

    private int _wpIndex;

    private string wayPointsTag;

    //attack fire rate

    [SerializeField]
    private float _fireRate;

    private float _nextFire = 0.0f;

    //hitpoints
    [SerializeField]
    private float _hitPoints = 10;

    //attack range
    [SerializeField]
    private AttackRangeScript _ar;
    //aggro range
    [SerializeField]
    private AggroRangeScript _agr;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private HitBoxScript _hb;

    //target

    private string targetHitboxTag;

    void Start()
    {
        find = GameObject.Find("GameManager").GetComponent<GOFinder>();


        //sets do prefab
        _hb.hitPoints = _hitPoints;
        if(_team == 1)
        {
            targetHitboxTag = "Team2HitBox";
            wayPointsTag = "Team1WayPoints";
            _agr.targetHitboxTag = targetHitboxTag;
            _ar.targetHitboxTag = targetHitboxTag;
            _hb.otherProjectileTag = "Team2Projectile";

            _hb.tag = "Team1HitBox";
        }
        else
        {
            targetHitboxTag = "Team1HitBox";
            wayPointsTag = "Team2WayPoints";
            _agr.targetHitboxTag = targetHitboxTag;
            _ar.targetHitboxTag = targetHitboxTag;
            _hb.otherProjectileTag = "Team1Projectile";

            _hb.tag = "Team2HitBox";
        }

        //procurar pelos waypoints
        _waypoints = GameObject.FindGameObjectWithTag(wayPointsTag).GetComponent<WayPointsScript>();

        //tempo de vida
        //StartCoroutine(LifeTime());
    }

    void Update()
    {
        //se estiver no range de attack
        if (_ar.inAttackRange)
        {
            //atirar se possivel
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                Transform location = GetComponent<Transform>();
                Instantiate(_bulletPrefab, location);
            }

            //definir alvo
            GameObject target = find.ClosestTarget(this.gameObject, targetHitboxTag);

            //olhar para alvo
            //transform.up = (Vector2)target.transform.position - (Vector2)transform.position;
        }
        else if (_agr.inAggroRange)
        {
            //se estiver no aggro range, aproxime-se do alvo

            //definir alvo
            GameObject target = find.ClosestTarget(this.gameObject, targetHitboxTag);

            //aproximar-se
            float step = _moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);

            //olhar para alvo
            transform.up = (Vector2)target.transform.position - (Vector2)transform.position;
        }
        else
        {
            move();
        }
    }

    private void move()
    {
        //waypoint atual
        Vector2 currentWayPoint = _waypoints.wayPoints[_wpIndex].position;

        float step = _moveSpeed * Time.deltaTime;

        //se move para o waypoint atual
        transform.position = Vector2.MoveTowards(transform.position, currentWayPoint, step);

        //ao atingir o waypoint atual, muda para o proximo
        if (Vector2.Distance(transform.position, currentWayPoint) < 0.1f)
        {
            //checar se chegou ao fim
            if (_wpIndex < _waypoints.wayPoints.Length - 1)
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
