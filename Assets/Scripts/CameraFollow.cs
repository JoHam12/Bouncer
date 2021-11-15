using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void FixedUpdate() {
        transform.position = new Vector3(target.position.x, target.position.y, -10);    
    }
}
