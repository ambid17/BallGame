using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGameManager : MonoBehaviour
{
    public GameObject DestructablePrefab;
    public GameObject DestructableParent;
    public Collider spawnarea;
    public int SpawnCount;
    public List<Mesh> SpawnableObjects;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            GameObject GO = Instantiate(DestructablePrefab,DestructableParent.transform);
            float x = Random.Range(spawnarea.bounds.min.x, spawnarea.bounds.max.x);
            float y = Random.Range(50,150);
            float z = Random.Range(spawnarea.bounds.min.z, spawnarea.bounds.max.z);
            GO.transform.position = new Vector3(x,y,z);

             x = Random.Range(0,360);
             y = Random.Range(0, 360);
             z = Random.Range(0, 360);
            GO.transform.rotation.SetEulerAngles (new Vector3(x, y, z));

            MeshFilter MyMeshFilter = GO.GetComponent<MeshFilter>();
            int RandomIndex = Random.Range(0, SpawnableObjects.Count);
            MyMeshFilter.mesh = SpawnableObjects[RandomIndex];

            MeshCollider MyMeshCollider = GO.GetComponent<MeshCollider>();
            MyMeshCollider.sharedMesh = SpawnableObjects[RandomIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
