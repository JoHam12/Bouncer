using UnityEngine;

public class Bridge : MonoBehaviour
{
    [Header("Bridge State")] 
    public bool activated, getDown;
    private float y;

    [Header("Movement Variables")]
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
        if(getDown){ MoveDown(); }
        if(activated){ MoveUp(); }
    }
    ///<summary> Moves Bridge Down (with transform) </summary>
    public void MoveDown(){
        y = Mathf.Lerp(y, initialPosY, movementTime);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    ///<summary> Moves Bridge Up (with transform) </summary>
    public void MoveUp(){
        y = Mathf.Lerp(y, finalPos, movementTime);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

}
