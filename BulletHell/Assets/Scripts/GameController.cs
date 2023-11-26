using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnLevelFinish;
    public UnityEvent OnLevelFail;

    [SerializeField] private bool isGodMode;

    private static GameController gameController;
    public static GameController Instance
    {
        get { return gameController; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            gameController = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        if (isGodMode)
        {
            GodMode();
        }
    }

    private void GodMode()
    {
        //GameObject player = PlayerController.PlayerInputInstance.gameObject;
        GameObject player = PlayerController.playerTest;

        player.GetComponent<HealthBehaviour>().enabled = false;
        GameObject shield = player.GetComponent<ShieldBehaviour>().EnableShield();
        shield.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void LevelFinished()
    {
        StartCoroutine(WaitLevelFinished());
    }

    public void LevelFailed()
    {
        StartCoroutine(WaitLevelFailed());
    }

    IEnumerator WaitLevelFinished()
    {
        yield return new WaitForSeconds(2f);
        OnLevelFinish.Invoke();
        Debug.Log("Level Finished");
    }

    IEnumerator WaitLevelFailed()
    {
        yield return new WaitForSeconds(2f);
        OnLevelFail.Invoke();
        Debug.Log("Level Failed");
    }
}
