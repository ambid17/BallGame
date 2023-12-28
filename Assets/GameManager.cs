using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject marblePrefab;
    public Transform spawnLocation;
    public GameObject mainCamera;

    public GameObject marbleInstance;

    void Start()
    {
        marbleInstance = Instantiate(marblePrefab);
        marbleInstance.transform.position = spawnLocation.position;


        mainCamera = Camera.main.gameObject;
    }

    void Update()
    {
        Vector3 newCameraPosition = marbleInstance.transform.position;
        newCameraPosition.y += 10;
        mainCamera.transform.position = newCameraPosition;

        mainCamera.transform.LookAt(marbleInstance.transform);
    }
}
