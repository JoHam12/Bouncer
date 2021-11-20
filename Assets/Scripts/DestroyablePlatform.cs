using UnityEngine;
using System.Collections.Generic;

public class DestroyablePlatform : MonoBehaviour
{
    private bool activate;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private int numOfSpriteRenderers;
    [SerializeField] private float timeUntilDestruction;
    private float time;
    private void Start(){
        activate = false;
        spriteRenderers = new SpriteRenderer[numOfSpriteRenderers];
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if(!activate){ return ; }
        if(time <= timeUntilDestruction){
            foreach(SpriteRenderer spriter in spriteRenderers){
                spriter.enabled = !spriter.enabled;
            } 
            time += Time.fixedDeltaTime;   
            return ; 
        }
        this.gameObject.SetActive(false);
    }
    /// <summary> Reactivates this platform (used at restart) </summary>
    public void Reactivate(){
        activate = false;
        foreach(SpriteRenderer spriter in spriteRenderers){
            spriter.enabled = true;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            activate = true;
            time = 0;
        }    
    }

}
