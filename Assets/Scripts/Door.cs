using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    public bool activate, hasKey;
    [SerializeField] private Image keyImage;
    [SerializeField] private Sprite keyImageBefore;
    [SerializeField] private float distance, movementTime;
    private float y;

    private void Start() {
        activate = false;
        hasKey = false;
        y = targetTransform.localPosition.y;
    }
    private void FixedUpdate() {
        if(targetTransform.localPosition.y >= distance-.1f){
            activate = false;
        }
        if(!activate){ return ; }
        OpenDoor();
    }
    public void OpenDoor(){
        y = Mathf.Lerp(y, distance, movementTime);
        targetTransform.localPosition = new Vector3(targetTransform.localPosition.x, y, targetTransform.localPosition.z);
    }
    public void SetOpen(){
        activate = true;
        keyImage.sprite = keyImageBefore;
    }
    public void SetHasKey(){ hasKey = true; }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && hasKey){
            SetOpen();
            hasKey = false;
        }
    }
}
