using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Player player;
    [SerializeField] private float value;

    public void OnPointerDown(PointerEventData eventData){
        if(!player){ return ; }
        if(value == 2){
            player.isJumping = true;
            return ;
        }
        player.horizontal = value;
    }
    public void OnPointerUp(PointerEventData eventData){
        if(!player){ return ; }
        if(value == 2){
            player.isJumping = false;
            return ;
        }
        player.horizontal = 0;
    }
    public void SetPlayer(Player player){
        this.player = player;
    }    
}
