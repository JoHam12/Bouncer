using UnityEngine;

public class Bridge : MonoBehaviour
{
    public bool activated, getDown;
    private float y;
    [SerializeField] private float distance, movementTime, initialPosY;
    private void Start() {
        activated = false;
        getDown = false;
        initialPosY = transform.position.y;
    }
    private void Update() {
        if(transform.position.y >= distance-.1f){
            getDown = true;
            activated = false;
        }
        if(getDown){
            y = Mathf.Lerp(y, initialPosY, movementTime);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        if(activated){
            y = Mathf.Lerp(y, distance, movementTime);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        
    }

}
