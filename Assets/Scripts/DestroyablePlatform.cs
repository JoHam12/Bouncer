using UnityEngine;
using System.Collections.Generic;

public class DestroyablePlatform : MonoBehaviour
{
    private bool activate;
    [SerializeField] private float timeUntilDestruction;

    [SerializeField] private SpriteRenderer[] spriteRenderers;
    private float time;
    private void Start(){
        activate = false;
        spriteRenderers = new SpriteRenderer[2];
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
