using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    public PlayerMover playerMover1;
    public PlayerMover playerMover2;
    private int round = 0; //用01记录是谁的回合，先设成private，估计以后会用到，到时再改public
    public Text diceText;

    public void RollDice(){
        switch (round) {
            case 0: //玩家1的回合
                if (!playerMover2.isMove){
                    int diceResult = Random.Range(1, 7);
                    diceText.text = "" + diceResult;
                    playerMover1.Move(diceResult);
                    round = (round + 1) % 2;
                }
                break;
            case 1: //玩家2的回合
                if (!playerMover1.isMove){
                    int diceResult = Random.Range(1, 7);
                    diceText.text = "" + diceResult;
                    playerMover2.Move(diceResult);
                    round = (round + 1) % 2;
                }
                break;
        }
        
        
    }
}
