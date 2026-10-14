using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // singleton pattern
    public static GameManager instance { get; private set; }

    [Header("PickUps")]
    public int totalPickUps = 5;
    public int collectedPickUps = 0;

    [Header("UI Elements")]
    public TMP_Text itemDisplay;
    public GameObject winPanel;


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
        if(itemDisplay != null)
        {
            UpdateUI();
        }
        if(winPanel != null) winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("pick ups" + collectedPickUps);
    }

    public void onPickUpCollected()
    {
        collectedPickUps++;
        if (_gameOver) return;
    }

     void UpdateUI()
    {
        if (itemDisplay != null) itemDisplay.text = $"Items {collectedPickUps} / {totalPickUps}";

    }

    public void OnGoalReached()
    { 

        if (_gameOver) return;
        _gameOver = true;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
            winPanel.GetComponentInChildren<TMP_Text>().text = $"All {collectedPickUps} items collected!";
        }
    }

}
