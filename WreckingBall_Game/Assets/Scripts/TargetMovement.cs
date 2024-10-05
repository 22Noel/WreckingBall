using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 targetDestination;

    // Start is called before the first frame update
    void Start()
    {
        targetDestination = transform.position + new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, targetDestination) < 0.1f)
        {
            targetDestination = transform.position + new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
        }  
        transform.position = Vector3.MoveTowards(transform.position, targetDestination, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall hit");
            targetDestination = transform.position - targetDestination;
        }
    }


}
