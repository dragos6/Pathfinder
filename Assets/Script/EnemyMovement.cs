using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintAllBlockCords());
    }

   IEnumerator PrintAllBlockCords()
    {
        foreach (var item in path)
        {
            transform.position = item.transform.position;
                yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
