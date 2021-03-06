using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    //
    public GameObject[] waypoints;
    int currentWP = 0;
    //velocidade do cubo
    public float speed = 1.0f;
    //precisao
    public float accuracy = 1.0f;
    //velocidade de rotação 
    public float rotSpeed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        //faz o cubo encontrar objetos com a tag waypoint
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }


   // Update is called once per frame

    void LateUpdate()
    {
        //
        if (waypoints.Length == 0) return;
        //
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x,
        this.transform.position.y,
        waypoints[currentWP].transform.position.z);

        //
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        Quaternion.LookRotation(direction),
        Time.deltaTime * rotSpeed);

        //
        if (direction.magnitude < accuracy)
        {
            //
            currentWP++;
            //
            if (currentWP >= waypoints.Length)
            {
                //
                currentWP = 0;
            }
        }
        //
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
