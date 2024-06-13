using UnityEngine;
public class MissileController : MonoBehaviour
{
    public int score;
    private GameObject scoreTextUI;
    public float missileSpeed = 15f;

    void Start()
    {
        scoreTextUI = GameObject.FindGameObjectWithTag("ScoreUITag");
    }
    void Update()
    {
        transform.Translate(Vector3.up * missileSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject gm =Instantiate(GameManager.instance.explosion,transform.position,transform.rotation);
            CameraShake.Shake(0.2f,0.2f);
            scoreTextUI.GetComponent<GameScore>().Score += score;
            Destroy(gm,2f);
            Destroy(this.gameObject);      
            Destroy(collision.gameObject);        
        }
    }
}
