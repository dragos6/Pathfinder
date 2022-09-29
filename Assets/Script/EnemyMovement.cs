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

    }

    IEnumerator FollowPath(List<Block> path)
    {
        foreach (Block block in path)
        {
            end = block.transform;
            yield return new WaitForSeconds(2f);

        }
        //isExecuting = false;


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
        }
        transform.position = Vector3.Lerp(transform.position, end.position, journeyLength * Time.deltaTime);

    }
}
