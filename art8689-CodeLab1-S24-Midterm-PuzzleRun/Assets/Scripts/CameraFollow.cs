using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;

    private Vector3 offset;

    public static CameraFollow instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = targetPlayer.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = targetPlayer.position - offset;
    }
}
