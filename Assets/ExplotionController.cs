using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionController : MonoBehaviour
{
    public float Lifetime;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > Lifetime)
        {
            Destroy(gameObject);
        }
    }
}
