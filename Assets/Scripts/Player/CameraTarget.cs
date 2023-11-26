using UnityEngine;

public class CameraTarget : MonoBehaviour {
    
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;
    
    void FixedUpdate() {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition() {
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        UpdateCameraPosition();
    }
#endif
}

