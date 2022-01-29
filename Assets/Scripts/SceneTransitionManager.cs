using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private PlayerController player;
    private Scenery scenery;

    public static SceneTransitionManager Instance;

    private string NextScene;

    public int MaxLives;
    public int Lives;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        player = FindObjectOfType<PlayerController>();
        scenery = FindObjectOfType<Scenery>();

        if (player == null)
        {
            Debug.LogError($"No player object found in {SceneManager.GetActiveScene().name}");
        }

        if (scenery == null)
        {
            Debug.LogError($"No scenery object found in {SceneManager.GetActiveScene().name}");
        }

        player.LockPlayer();
    }

    private void OnLevelWasLoaded(int level)
    {
        player = FindObjectOfType<PlayerController>();
        scenery = FindObjectOfType<Scenery>();

        if (player == null)
        {
            Debug.LogError($"No player object found in {SceneManager.GetActiveScene().name}");
        }

        if (scenery == null)
        {
            Debug.LogError($"No scenery object found in {SceneManager.GetActiveScene().name}");
        }

        player.LockPlayer();
    }

    public void LoadScene(string SceneName)
    {
        player.LockPlayer();
        scenery.EndLevel();
        NextScene = SceneName;
        scenery.FinishedClosing.AddListener(SceneLoadReady);
    }

    public void SceneLoadReady()
    {
        SceneManager.LoadScene(NextScene);
    }

    public void ReloadScene()
    {
        player.LockPlayer();
        scenery.EndLevel();
        scenery.FinishedClosing.AddListener(SceneReloadReady);
    }

    public void SceneReloadReady()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
