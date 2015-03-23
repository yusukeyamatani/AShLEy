using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;
	public AudioSource BackgroundMugic ;


    Animator anim;
	float restartTimer;
	

    void Awake()
    {
        anim = GetComponent<Animator>();
//		BackgroundMugic = GetComponent <AudioSource> ();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			BackgroundMugic.Stop();

			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel );
			}
        }
    }
}
