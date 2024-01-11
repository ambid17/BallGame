using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGameManager : MonoBehaviour
{
    public GameObject DestructablePrefab;
    public BoxCollider spawnarea;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject GO = Instantiate(DestructablePrefab);
            float x = Random.Range(spawnarea.bounds.min.x, spawnarea.bounds.max.x);
            float y = Random.Range(1,10);
            float z = Random.Range(spawnarea.bounds.min.z, spawnarea.bounds.max.z);
            GO.transform.position = new Vector3(x,y,z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
