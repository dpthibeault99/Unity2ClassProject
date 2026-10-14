using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton pattern
    public static GameManager instance { get; private set; }

    [Header("PickUps")]
    public int totalPickUps = 5;
    public int collectedPickUps = 0;

    bool _gameOver = false;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        // use if ou want game manager to persist between scences
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPickUpCollected()
    {
        if(_gameOver) return;
        collectedPickUps++;
    }
}
