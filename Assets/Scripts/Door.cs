using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    public bool activate, hasKey;
    [Header("Key UI")] [SerializeField] private Image keyImage;
    [SerializeField] private Sprite keyImageBefore;
    [Header("Positional variables")]
    [SerializeField] private float distance, movementTime;
    private float y, initialPosY;
    private void Start() {
        activate = false;
        hasKey = false;
        initialPosY = targetTransform.localPosition.y;
        y = initialPosY;
    }
    private void FixedUpdate() {
        if(targetTransform.localPosition.y >= distance-.1f){
            activate = false;
        }
        if(!activate){ return ; }
        OpenDoor();
    }
    ///<summary> Opens door (using transform) </summary>
    public void OpenDoor(){
        y = Mathf.Lerp(y, distance, movementTime);
        targetTransform.localPosition = new Vector3(targetTransform.localPosition.x, y, targetTransform.localPosition.z);
    }
    /// <summary> Closes door (using transform)(used in restart)</summary>
    public void CloseDoor(){
        targetTransform.localPosition = new Vector3(targetTransform.localPosition.x, initialPosY, targetTransform.localPosition.z);
        y = initialPosY;
        activate = false;
        hasKey = false;
    }
    /// <summary> Changes door UI </summary>
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
