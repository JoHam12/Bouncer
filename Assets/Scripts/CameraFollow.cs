using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CheckGrounded checkGrounded;
    [SerializeField] private float offset, firstVal;
    private float z, shakeDuration;
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
        z = Mathf.Lerp(z, firstVal, .2f);
    }

    public void SetTarget(Transform target){ this.target = target; }
    public void SetGroundCheck(CheckGrounded checkGrounded){ this.checkGrounded = checkGrounded; }

    public void ShakeCamera(){
        if (shakeDuration > 0)
		{
			transform.position = transform.position + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
    }
}
