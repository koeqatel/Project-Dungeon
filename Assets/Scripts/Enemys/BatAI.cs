using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public float visionRange = 15;
    public float attackRange = 8;
    private float Range;

    private Transform myTransform;

    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Range = Vector2.Distance(myTransform.transform.position, target.transform.position);
        if (Range <= attackRange)
        {
            attack();
        }
        else if (Range <= visionRange)
        {
            //Move Towards Target
            myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
            Vector3 start = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
            Vector3 end = new Vector3(target.position.x, target.position.y, target.position.z);

            //Raycast(start, end, Mathf.Infinity, DefaultRaycastLayers, queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);

            Vector2 fwd = transform.TransformDirection(Vector2.left);

            if (Physics.Raycast(transform.position, fwd, 10))
                print("There is something in front of the object!");

            Debug.DrawLine(start, end, Color.yellow);
        }
    }

    void attack()
    {
        Vector3 start = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
        Vector3 end = new Vector3(target.position.x, target.position.y, target.position.z);

        Debug.DrawLine(start, end, Color.red);
        //Stop moving.
        //Draw curved line.        
        //Increase speed.
        //Fly toward player in curved line.
        //Do damage on hit.
        //Repeat.
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

   
}