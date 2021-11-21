using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [Header("Target values")]
    [SerializeField] private Transform target;
    [SerializeField] private CheckGrounded checkGrounded;
    [Header("Camera Movement Values")]
    [SerializeField] private float offset, firstVal, onLiftOffset;
    private float z, shakeDuration;
    private bool isOnLift;
    [Header("Camera Shake Values")]
    [SerializeField] private float shakeAmount, decreaseFactor, shakeMaxDuration;
    private void Start(){
        z = firstVal;
        shakeDuration = shakeMaxDuration;
    }

    private void FixedUpdate() {
        
        if(!target){ 
            ShakeCamera();
            return ; 
        }        
        shakeDuration = shakeMaxDuration;
        transform.position = new Vector3(target.position.x, target.position.y, z);    
        if(!checkGrounded.isGrounded){
            z = Mathf.Lerp(z, offset, .2f);
            return ;
        }
        if(isOnLift){
            z = Mathf.Lerp(z, onLiftOffset, .2f);
            return ;
        }
        z = Mathf.Lerp(z, firstVal, .2f);
    }
    ///<summary> Sets camera target </summary>
    ///<param name="traget"> value to set target to </param>
    public void SetTarget(Transform target){ this.target = target; }

    ///<summary> Sets checkGroundded attribute </summary>
    ///<param name="checkGrounded"> value to set checkGrounded to </param>
    public void SetGroundCheck(CheckGrounded checkGrounded){ this.checkGrounded = checkGrounded; }

    ///<summary> Shakes camera (used after death of player) </summary>
    public void ShakeCamera(){
        if (shakeDuration > 0)
		{
			transform.position = transform.position + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
    }

    public void SetIsOnLift(bool state){
        isOnLift = state;
    }
}
