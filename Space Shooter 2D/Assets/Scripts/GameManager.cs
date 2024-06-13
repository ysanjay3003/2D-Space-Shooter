using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject userScore;

    public GameObject enemyPrefab;
    public float slowness = 20f;
    

    [Header("Particle Effects")]
    public GameObject explosion;
    public GameObject muzzleFlash;

    [Header("Panels")]
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject imageScore;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        imageScore.SetActive(false);
        
        Time.timeScale = 0f;
        InvokeRepeating("InstantiateEnemy",1f,0.6f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(true);
        }
    } 
    void InstantiateEnemy()
        {
            Vector3 enemypos = new Vector3(Random.Range(-5.5f, 5.5f), 6f, 0f);
            GameObject enemy = Instantiate(enemyPrefab, enemypos, Quaternion.Euler(0f, 0f, 180f));
            Destroy(enemy, 5f);
        }
     public void StartGameButton()
    {
        startMenu.SetActive(false);
        imageScore.SetActive(true);
        Time.timeScale = 1f;
    }
    public void PauseGame(bool isPaused)
    {
            if (isPaused == true)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1f/slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        
        yield return new WaitForSeconds(6f/slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
}
 