using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Block> path;
    bool isExecuting = false;

    Transform end;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        path = pathfinder.GetPath();
        startTime = Time.time;
        Debug.Log(journeyLength);

    }

    IEnumerator FollowPath(List<Block> path)
    {
        Debug.Log("im in coroutine");
        foreach (Block block in path)
        {
            end = block.transform;
            yield return new WaitForSeconds(2f);

        }
        //isExecuting = false;
        Debug.Log("after coroutine");


    }

    // Update is called once per frame
    void Update()
    {

        float distCovered = (Time.time - startTime) * speed * Time.deltaTime;
        float fractionOfJourney = distCovered / journeyLength;

        if (!isExecuting)
        {
            isExecuting = true;
            StartCoroutine(FollowPath(path));
        }
        if (fractionOfJourney == 0)
        {
            Debug.Log("over");
        }
        transform.position = Vector3.Lerp(transform.position, end.position, journeyLength * Time.deltaTime);
/*        if (end.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 5f);

        }
        else if (end.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5f);

        }
        if (end.position.z > transform.position.z)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f);

        }
        if (end.position.z < transform.position.z)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -180, 0), Time.deltaTime * 5f);

        }*/
        // if x >  => y = 90
        // if z >re  y= 0w
        // if x<  y -90ww
        // if z<re y -180
    }
}
