
[System.Serializable]
public class Data 
{
    public int levelId {get ;}
    public float time {get ;}
    public int score {get ;}
    public Data(Player player, GameController gameController){
        levelId = gameController.GetLevel();
        time = gameController.GetTime();
        score = player.GetScore();
    }
}
