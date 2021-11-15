using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Player player;
    [SerializeField] private CheckGrounded checkGrounded;
    [SerializeField] private float offset, firstVal;
    private float z;
    private void Start(){
        player = target.GetComponent<Player>();
        z = firstVal;
    }

    private void FixedUpdate() {
        if(!target){ return ; }
        transform.position = new Vector3(target.position.x, target.position.y, z);    
        if(!checkGrounded.isGrounded){
            z = Mathf.Lerp(z, offset, .2f);
            return ;
        }
        z = Mathf.Lerp(z, firstVal, .2f);
    }
}
