using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatedObject : MonoBehaviour
{
    Vector3 _initialScale;
    Vector3 _previousRotation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scale(float scaleBy)
    {
        transform.localScale = _initialScale * scaleBy;
    }

    public void RotateX(float rotateBy)
    {
        var delta = rotateBy - _previousRotation.x;
        transform.Rotate(Vector3.right * delta * 360);
        _previousRotation.x = rotateBy;
    }

    public void RotateY(float rotateBy)
    {
        var delta = rotateBy - _previousRotation.y;
        transform.Rotate(Vector3.up * delta * 360);
        _previousRotation.y = rotateBy;
    }

    public void RotateZ(float rotateBy)
    {
        var delta = rotateBy - _previousRotation.z;
        transform.Rotate(Vector3.forward * delta * 360);
        _previousRotation.z = rotateBy;
    }
}
