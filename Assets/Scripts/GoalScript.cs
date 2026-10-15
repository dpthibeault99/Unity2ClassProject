using UnityEngine;

public class GoalScript : MonoBehaviour
{
    bool _reached = false;

    private void OnTriggerEnter(Collider other)
    {
        if(_reached) return;
        if(other.CompareTag("player"))
        {
            if (GameManager.instance.collectedPickUps != GameManager.instance.totalPickUps) return;
            _reached = true;
            GameManager.instance?.OnGoalReached();
        }
    }
}
