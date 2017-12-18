using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BatAI : MonoBehaviour
{
    public float visionRange = 20;
    public float attackRange = 8;
    public int idleRange = 2;

    private FollowTarget FollowTarget;
    private PatrolRandomWaypoints IdleRandomWaypoints;
    private PolyNavAgent PolyNavAgent;
    private PatrolWaypoints PatrolWaypoints;

    public Transform target;
    private Transform bat;

    private float BatTargetDistance;

    private bool following;
    private bool attackWaypointsSet;
    private bool passedFirstWaypoint;

    Vector2 batPos;
    Vector2 targetPos;

    #region PolyNav stuff
    private PolyNavAgent _agent;
    private PolyNavAgent agent
    {
        get { return _agent != null ? _agent : _agent = GetComponent<PolyNavAgent>(); }
    }
    #endregion

    void Awake()
    {
        bat = transform;

        //Scripts
        FollowTarget = GetComponent<FollowTarget>();
        IdleRandomWaypoints = GetComponent<PatrolRandomWaypoints>();
        PolyNavAgent = GetComponent<PolyNavAgent>();
        PatrolWaypoints = GetComponent<PatrolWaypoints>();
    }


    // Update is called once per frame
    void Update()
    {
        //Get Bat and Player Positions
        batPos = new Vector2(bat.position.x, bat.position.y);
        targetPos = new Vector2(target.position.x, target.position.y);

        //Get distance between Bat and Target
        BatTargetDistance = Vector2.Distance(batPos, targetPos);

        //If the target is in attack range.
        if (BatTargetDistance <= attackRange) //Attack!
        {
            //Check if the bat was following the player.
            if (following)
            {
                //Set bats destination to itself to stop it from moving.
                agent.SetDestination(batPos);

                toggleScripts(false, false, false);

                //Decrease speed to Idle speed.
                PolyNavAgent.maxSpeed = 10;
                PolyNavAgent.accelerationRate = 3;
                PolyNavAgent.mass = 1;
                PolyNavAgent.slowingDistance = 0;

                //Now the bat is no longer following the player for it will start attacking.
                following = false;
            }

            //Attack.
            attack();
        }
        else if (BatTargetDistance <= visionRange) //Follow.
        {
            //Enable Follow player script.
            toggleScripts(true, false, false);

            attackWaypointsSet = false;
            passedFirstWaypoint = false;

            //Increase speed.
            PolyNavAgent.maxSpeed = 4;
            PolyNavAgent.accelerationRate = 2;
            PolyNavAgent.mass = 20;
            PolyNavAgent.slowingDistance = 0.1f;

            //Set the bats destination to the players position.
            agent.SetDestination(target.position);

            following = true;
        }
        else //Idle.
        {
            //Check if the bat was following the player.
            if (following)
            {
                //Set bats destination to itself to stop it from moving.
                agent.SetDestination(batPos);

                //Now the bat is no longer following the player.
                following = false;
            }

            toggleScripts(false, true, false);

            //Decrease speed to Idle speed.
            PolyNavAgent.maxSpeed = 2;
            PolyNavAgent.accelerationRate = 1;

            //Clear previous waypoints and create new ones for the bat to follow while Idling.
            IdleRandomWaypoints.WPoints.Clear();
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x - idleRange, batPos.y));
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x - idleRange, batPos.y - idleRange));
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x, batPos.y - idleRange));
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x + idleRange, batPos.y - idleRange));
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x + idleRange, batPos.y));
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x + idleRange, batPos.y + idleRange));
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x, batPos.y + idleRange));
            IdleRandomWaypoints.WPoints.Add(new Vector2(batPos.x - idleRange, batPos.y + idleRange));
        }

        if (PatrolWaypoints.enabled == true)
        {
            Debug.DrawLine(PatrolWaypoints.WPoints[0], PatrolWaypoints.WPoints[1], Color.red);
            Debug.DrawLine(PatrolWaypoints.WPoints[1], PatrolWaypoints.WPoints[2], Color.yellow);
            Debug.DrawLine(PatrolWaypoints.WPoints[2], PatrolWaypoints.WPoints[3], Color.green);
            Debug.DrawLine(PatrolWaypoints.WPoints[3], PatrolWaypoints.WPoints[4], Color.cyan);
            Debug.DrawLine(PatrolWaypoints.WPoints[4], PatrolWaypoints.WPoints[5], Color.blue);
            Debug.DrawLine(PatrolWaypoints.WPoints[5], PatrolWaypoints.WPoints[6], Color.magenta);
            Debug.DrawLine(PatrolWaypoints.WPoints[6], PatrolWaypoints.WPoints[7], Color.black);
        }     
    }

    void attack()
    {
        //Calculate diffrence between Bat and Player position.
        Vector2 difference = batPos - targetPos;

        //Attack            
        ////  Increase speed.
        ////  Fly toward player in curved line.
        ////  Do damage on hit.
        ////  Unblock Initiate

        float X = targetPos.x - batPos.x;
        float Y = targetPos.y - batPos.y;

        if (!attackWaypointsSet)
        {
            //Change the bats destination.
            if (X < 0 && Y > 0)
            {
                //print("top left");
                moveWaypoints(difference, "top");
            }
            else if (X > 0 && Y > 0)
            {
                //print("top right");
                moveWaypoints(difference, "top");
            }
            else if (X < 0 && Y < 0)
            {
                //print("bot left");
                moveWaypoints(difference, "bot");
            }
            else if (X > 0 && Y < 0)
            {
                //print("bot right");
                moveWaypoints(difference, "bot");
            }
            attackWaypointsSet = true;
        }

        if (agent.nextPoint == PatrolWaypoints.WPoints[0] && passedFirstWaypoint)
        {
            PatrolWaypoints.enabled = false;
            agent.SetDestination(batPos);

            attackWaypointsSet = false;
            passedFirstWaypoint = false;
        }
        else if (agent.nextPoint == PatrolWaypoints.WPoints[1])
        {
            passedFirstWaypoint = true;
        }
        else if (agent.nextPoint == PatrolWaypoints.WPoints[7])
        {
            PatrolWaypoints.enabled = false;

            attackWaypointsSet = false;
            passedFirstWaypoint = false;
        }


        float distance = Vector2.Distance(batPos, targetPos);

        if (distance < 0.1f)
        {
            print("Ouch! I got hit!");
        }
    }

    void moveWaypoints(Vector2 diff, string Location)
    {
        if (Location == "top")
        {
            float diffNegX = diff.x - diff.x - diff.x;

            PatrolWaypoints.WPoints.Clear();
            PatrolWaypoints.WPoints.Add(new Vector2(diff.x / 2 + targetPos.x, diff.y / 2.5f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diff.x / 3.5f + targetPos.x, diff.y / 5.8f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diff.x / 6 + targetPos.x, diff.y / 10 + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(targetPos.x, targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX / 6 + targetPos.x, diff.y / 10 + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX / 3.5f + targetPos.x, diff.y / 5.8f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX / 2 + targetPos.x, diff.y / 2.5f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX + targetPos.x, diff.y + targetPos.y));

        }
        else if (Location == "bot")
        {
            float diffNegX = diff.x - diff.x - diff.x;

            PatrolWaypoints.WPoints.Clear();
            PatrolWaypoints.WPoints.Add(new Vector2(diff.x / 2 + targetPos.x, diff.y / 2.5f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diff.x / 3.5f + targetPos.x, diff.y / 5.8f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diff.x / 6 + targetPos.x, diff.y / 10 + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(targetPos.x, targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX / 6 + targetPos.x, diff.y / 10 + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX / 3.5f + targetPos.x, diff.y / 5.8f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX / 2 + targetPos.x, diff.y / 2.5f + targetPos.y));
            PatrolWaypoints.WPoints.Add(new Vector2(diffNegX + targetPos.x, diff.y + targetPos.y));


        }

        PatrolWaypoints.enabled = true;
    }

    void toggleScripts(bool FollowTargetBool, bool IdleRandomWaypointsBool, bool PatrolWaypointsBool)
    {
        FollowTarget.enabled = FollowTargetBool;
        IdleRandomWaypoints.enabled = IdleRandomWaypointsBool;
        PatrolWaypoints.enabled = PatrolWaypointsBool;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}