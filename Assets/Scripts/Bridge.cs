using UnityEngine;

public class Bridge : MonoBehaviour
{
    public bool activated, getDown;
    private float y;
    [SerializeField] private float finalPos, movementTime, initialPosY;
    private void Start() {
        activated = false;
        getDown = false;
        initialPosY = transform.position.y;
        y = initialPosY;
    }
    private void Update() {
        if(transform.position.y >= finalPos-.1f){
            getDown = true;
            activated = false;
        }
        if(getDown){
            y = Mathf.Lerp(y, initialPosY, movementTime);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        if(activated){
            y = Mathf.Lerp(y, finalPos, movementTime);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        
    }

}
