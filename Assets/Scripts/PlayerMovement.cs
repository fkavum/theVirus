using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject CollidingTrail;
    public GameObject ColliderTrailInst;
    public GameObject[] traills;
    private int activeTrail;

    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float döngüBekleme;

    public float speed = 1f;

    void Start()
    {
        StartCoroutine(Olustur());
      
        TrailRenderer tr;
        foreach (GameObject trailEffect in traills)
        {
            tr = trailEffect.GetComponentInChildren<TrailRenderer>();
            tr.emitting = false;
        }

        


        activeTrail = 4;

        tr = traills[3].GetComponentInChildren<TrailRenderer>();
        tr.emitting = true;
    }


    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while (true)
        {
            for (int i = 0; i < 25; i++)
            {
                createTrailCollider();
                yield return new WaitForSeconds(olusturmaBekleme);

            }
            yield return new WaitForSeconds(döngüBekleme);

        }
    }

    private void createTrailCollider()
    {

        SoundManager sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();

        if (Input.GetKey(KeyCode.Alpha1))
        {
            turnOnTheTrail(1);
            sm.PlaySalgi();
            Vector3 vec = new Vector3(ColliderTrailInst.transform.position.x, 0, ColliderTrailInst.transform.position.z);
            GameObject trailObj = Instantiate(CollidingTrail, vec, Quaternion.identity) as GameObject;

            trailObj.GetComponent<CollidingTrail>().trailType = TrailType.Red;
            trailObj.transform.name = "RedTrail";
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            turnOnTheTrail(2);
            sm.PlaySalgi();

            Vector3 vec = new Vector3(ColliderTrailInst.transform.position.x, 0, ColliderTrailInst.transform.position.z);
            GameObject trailObj = Instantiate(CollidingTrail, vec, Quaternion.identity) as GameObject;

            trailObj.GetComponent<CollidingTrail>().trailType = TrailType.Yellow;
            trailObj.transform.name = "YellowTrail";
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            turnOnTheTrail(3);
            sm.PlaySalgi();
            Vector3 vec = new Vector3(ColliderTrailInst.transform.position.x, 0, ColliderTrailInst.transform.position.z);
            GameObject trailObj = Instantiate(CollidingTrail, vec, Quaternion.identity) as GameObject;

            trailObj.GetComponent<CollidingTrail>().trailType = TrailType.Blue;
            trailObj.transform.name = "BlueTrail";
        }
        else
        {
            sm.StopSalgi();
            turnOnTheTrail(4);
        }
    }







    private void turnOnTheTrail(int effectToActive)
    {
        if (effectToActive != activeTrail)
        {
            activeTrail = effectToActive;
            foreach (GameObject trailEffect in traills)
            {
                TrailRenderer ps = trailEffect.GetComponentInChildren<TrailRenderer>();
                ps.emitting = false;
                //trailEffect.SetActive(false);
            }
            if (effectToActive != 0)
            {
                //trailEffects[effectToActive - 1].SetActive(true);
                TrailRenderer ps = traills[effectToActive - 1].GetComponentInChildren<TrailRenderer>();
                ps.emitting = true;

            }

        }
    }

    void Update()
    {


        
        if (Input.GetMouseButton(0)) { 
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) //check if the ray hit something
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(hit.point.x,transform.position.y,hit.point.z), step);
            transform.LookAt(new Vector3(hit.point.x,transform.position.y,hit.point.z));
        }
        }

        
    }
}
