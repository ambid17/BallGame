using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject marblePrefab;
    public Transform spawnLocation;
    public GameObject mainCamera;

    public GameObject marbleInstance;
    public float moveSpeed;
    public float sensitivity = 2;
    void Start()
    {
        marbleInstance = Instantiate(marblePrefab);
        marbleInstance.transform.position = spawnLocation.position;
        Cursor.lockState = CursorLockMode.Confined;

        mainCamera = Camera.main.gameObject;
       // CreateCube(); 
    }
    private void CreateCube()
    {
        GameObject cube = new GameObject();
        cube.name = "Cubie";
        MeshFilter filter =cube.AddComponent<MeshFilter>();
        cube.AddComponent<MeshRenderer>();
        Mesh myMesh = new Mesh();
        myMesh.vertices = new Vector3[8];
        myMesh.vertices[0] = new Vector3(0, 0, 0);
        myMesh.vertices[1] = new Vector3(0, 1, 0);
        myMesh.vertices[2] = new Vector3(1, 1, 0);
        myMesh.vertices[3] = new Vector3(1, 0, 0);
        myMesh.vertices[4] = new Vector3(0, 0, 1);
        myMesh.vertices[5] = new Vector3(0, 1, 1);
        myMesh.vertices[6] = new Vector3(1, 1, 1);
        myMesh.vertices[7] = new Vector3(1, 0, 1);

        myMesh.triangles= new int[36]; //6sides X 2 Tri per side X 3 Verticies per Triangle
        myMesh.triangles [0] = 0;
        myMesh.triangles [1] = 1;
        myMesh.triangles [2] = 2;


        filter.mesh = myMesh;
    }




    void Update()
    {
        Vector3 newCameraPosition = mainCamera.transform.position;
        float speedThisframe = moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            newCameraPosition += mainCamera.transform.forward * speedThisframe;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newCameraPosition += - mainCamera.transform.forward * speedThisframe;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newCameraPosition += - mainCamera.transform.right * speedThisframe;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newCameraPosition += mainCamera.transform.right  * speedThisframe;
        }
        if (Input.GetKey(KeyCode.E))
        {
            newCameraPosition += mainCamera.transform.up * speedThisframe;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newCameraPosition += -mainCamera.transform.up * speedThisframe;
        }

        mainCamera.transform.position = newCameraPosition;

        var rotation = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        var targetEuler = mainCamera.transform.rotation.eulerAngles + (Vector3)rotation * sensitivity;

        if (targetEuler.x > 180)
        {
            targetEuler.x -= 360;
        }

        targetEuler.x = Mathf.Clamp(targetEuler.x, -90, 90);
        Quaternion newRotation = Quaternion.Euler(targetEuler);

        mainCamera.transform.rotation = newRotation;
    }
}
