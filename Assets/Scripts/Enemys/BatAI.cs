using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{
    public Transform target;
    public float visionRange = 20;
    public float attackRange = 8;
    private float Range;

    private Transform myTransform;

    private PolyNavAgent _agent;
    private PolyNavAgent agent
    {
        get { return _agent != null ? _agent : _agent = GetComponent<PolyNavAgent>(); }
    }

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
            toggleMovement(false);
            attack();
        }
        else if (Range <= visionRange)
        {
            toggleMovement(true);

            //Move Towards Target
            Vector3 start = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
            Vector3 end = new Vector3(target.position.x, target.position.y, target.position.z);

            //Raycast(start, end, Mathf.Infinity, DefaultRaycastLayers, queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);

            Vector2 fwd = transform.TransformDirection(Vector2.left);

            if (Physics.Raycast(transform.position, fwd, 10))
                print("There is something in front of the object!");

            Debug.DrawLine(start, end, Color.yellow);
        }
        else
        {
            toggleMovement(false);
        }
    }

    void toggleMovement(bool toggle)
    {
        var script = GetComponent<FollowTarget>();

        if (toggle)
        {
            agent.SetDestination(target.position);
            script.enabled = true;
        } else if (!toggle)
        {
            agent.SetDestination(myTransform.position);
            script.enabled = false;
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