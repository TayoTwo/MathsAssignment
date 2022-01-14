using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    float m_RotationSpeed = 10f;

    Quaternion m_InitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        m_InitialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = m_InitialRotation;
        }
    }


    private void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * m_RotationSpeed * Mathf.Deg2Rad;
        transform.RotateAround(Vector3.down, x);
        float y = Input.GetAxis("Mouse Y") * m_RotationSpeed * Mathf.Deg2Rad;
        transform.RotateAround(Vector3.right, y);
    }
}
