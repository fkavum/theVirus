using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public TrailType enemyColor;
    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavmesh;
    public float checkRate = 0.01f;
    float nextCheck;
    public float lifetime;
    private float sickness = 0f;
    public float fallowingDistance = 7f;
    int sicknessScaler= 0;
    public ParticleSystem particleSystem;

    public GameObject[] Virusses;

    Vector3 vec1 = new Vector3(1, 0, 1);
    Vector3 vec2 = new Vector3(-1, 0, -1);

    Vector3 previousPosition;
    private bool virusDropped = false;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerTransform = player.transform;
        }


        myNavmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        myNavmesh.speed = Random.Range(3.10f, 4.30f);
        previousPosition = transform.position;

    }

    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            FollowPlayer();
        }

        if (sicknessScaler == 1) { 
        sickness += Time.deltaTime;
            startParticle();
            //Debug.Log(sickness);
            sicknessScaler = 0;
        }
        else if (sicknessScaler == -1)
        {
            stopParticle();
            if (sickness > 0f) {
               
            sickness -= Time.deltaTime;
            //Debug.Log(sickness);
            sicknessScaler = 0;
            }
        }
        else if (sicknessScaler == 0)
        {
            stopParticle();
          
        }
    }

    private void startParticle()
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();

        }
    }
    private void stopParticle()
    {
        if (!particleSystem.isPaused) { 
        particleSystem.Pause();
        }
    }

    void FollowPlayer()
    {
        if(playerTransform != null) {
            //myNavmesh.transform.LookAt(playerTransform);
            if (Vector3.Distance(playerTransform.position, transform.position) < fallowingDistance) { 
        myNavmesh.destination = playerTransform.position;

        myNavmesh.transform.LookAt(previousPosition+(transform.position-previousPosition));
        previousPosition = transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ColliderTrail"))
        {
            CollidingTrail collidingTrailObj = other.gameObject.GetComponent<CollidingTrail>();
            if (collidingTrailObj != null)
            {

                TrailType colliderType = collidingTrailObj.trailType;
                if(colliderType == enemyColor)
                {
                     sicknessScaler = 1;
                    if(sickness > 3f)
                    {
                        sickness = 0f;
                        Destroy(gameObject);
                        dropVirus();
                        
                    }

                }
                else
                {
                     sicknessScaler = -1;
                }
            }

        }

        }

    

    private void dropVirus()
    {
        SoundManager sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
        sm.PlayZzz();
        if (!virusDropped) { 
        Instantiate(Virusses[Random.Range(0, Virusses.Length)], transform.position+new Vector3(Random.Range(-1f,-0.5f),0, Random.Range(0.5f, +1f)), transform.rotation);
        Instantiate(Virusses[Random.Range(0, Virusses.Length)], transform.position+ new Vector3(Random.Range(0.5f, +1f), 0, Random.Range(0.5f, +1f)), transform.rotation);
        Instantiate(Virusses[Random.Range(0, Virusses.Length)], transform.position, transform.rotation);
        }
        virusDropped = true;
    }
}