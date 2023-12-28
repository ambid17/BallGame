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
        Cursor.lockState = CursorLockMode.Locked;

        mainCamera = Camera.main.gameObject;
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
