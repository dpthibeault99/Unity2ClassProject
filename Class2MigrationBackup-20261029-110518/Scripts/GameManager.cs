using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

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


    public bool _gameOver = false;

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
        DontDestroyOnLoad(winPanel);
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
        Debug.Log("pick ups " + collectedPickUps);
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
            restartGame();
        }
    }
    
    public void restartGame()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForSeconds(0.1f);
        itemDisplay = GameObject.Find("Pickups").GetComponent<TMP_Text>();
        winPanel = GameObject.Find("winPanel");
        collectedPickUps = 0;
        UpdateUI();
        _gameOver = false;
    }
}
