using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    public float CameraUpdateSpeed;
    private Vector3 TargetOffset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.position;
        TargetOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        offset = Vector3.MoveTowards(offset, TargetOffset,CameraUpdateSpeed * Time.deltaTime);
        transform.position = Player.position + offset;
    }

    public void AddOffset()
    {
        TargetOffset *= 1.1F; 
    }

    [ContextMenu("Snap to Default")]
    public void SnaptoDefault()
    {
        transform.position = Player.position + new Vector3(0,5,-10);
        transform.LookAt(transform.position);
    }
}
