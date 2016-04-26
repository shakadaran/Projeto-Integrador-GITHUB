using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public GameObject[] cameraPositions;
    private int indexPosition = 0;
    public float movementVelocity = 2;
    private RaycastHit hit;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.LookAt(target.transform);

        //Collision check
        if (!Physics.Linecast(target.transform.position, cameraPositions[indexPosition].transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, cameraPositions[indexPosition].transform.position, movementVelocity * Time.deltaTime);
            Debug.DrawLine(target.transform.position, cameraPositions[indexPosition].transform.position);
        }
        else if (Physics.Linecast(target.transform.position, cameraPositions[indexPosition].transform.position, out hit))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, (movementVelocity * 2) * Time.deltaTime);
            Debug.DrawLine(target.transform.position, hit.point);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && indexPosition < (cameraPositions.Length - 1))
        {
            indexPosition++;
        }
        else if (Input.GetKeyDown("e") && indexPosition >= (cameraPositions.Length - 1))
        {
            indexPosition = 0;
        }
    }
}