using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Level System")]
    private int whichlevel = 0;
    private int levelTextInt;
    public Text levelText;
    public bool gameStarted = false;

    [SerializeField] public List<Scriptable> levels = new List<Scriptable>();

    //[SerializeField] public List<GameObject> level = new List<GameObject>();

    //public GameObject MainPlayer;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        //PlayerPrefs.GetInt("levelTextInt");

        whichlevel = PlayerPrefs.GetInt("whichlevel");

        if (PlayerPrefs.GetInt("randomlevel") > 0)
        {
            whichlevel = Random.Range(0, levels.Count);
        }


        Instantiate(levels[whichlevel].LevelPrefab, Vector3.zero, Quaternion.identity);

        //level[whichlevel].SetActive(true);
        //MainPlayer = Instantiate(levels[whichlevel].Player, Vector3.zero, Quaternion.identity);

        levelText.text = "Level " + (whichlevel + 1);
    }

    public void NextLevel()
    {
        whichlevel++;
        PlayerPrefs.SetInt("whichlevel", whichlevel);

        if (whichlevel >= levels.Count)
        {
            whichlevel--;
            PlayerPrefs.SetInt("randomlevel", 1);
        }

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public int Whichlevel()
    {
        return whichlevel;
    }
}