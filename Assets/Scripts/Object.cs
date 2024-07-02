using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private float objectSpeed = 1f;
    [SerializeField] private float resetPosition = 20.8f;
    [SerializeField] private float startPosition = -94.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!GameManager.Instance.GameOver)
        {
            transform.Translate(Vector3.forward * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.z >= resetPosition)
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, startPosition);
                transform.position = newPos;
            }
        }
        
    }
}

