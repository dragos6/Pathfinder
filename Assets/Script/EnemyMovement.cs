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
    [SerializeField] ParticleSystem explosionParticles;

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
            yield return new WaitForSeconds(.8f);

        }
        SelfDescruct();
        //isExecuting = false;


    }
    private void SelfDescruct()
    {
        var vfx = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
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
