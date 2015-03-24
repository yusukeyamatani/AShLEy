using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
	GameObject parent;
	public GameObject item;
	
    bool isDead;


    void Awake ()
    {
        currentHealth = startingHealth;
		parent = transform.parent.gameObject;
    }

	
    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        currentHealth -= amount;
		Debug.Log ("###################currentHealth" + currentHealth);
            
        if(currentHealth <= 0)
        {
            Death ();
        }
    }

    void Death ()
    {
        isDead = true;
		StartSinking ();
    }


    void StartSinking ()
    {
		parent.GetComponent <NavMeshAgent> ().enabled = false;
		parent.GetComponent <Rigidbody> ().isKinematic = true;
		Instantiate (item, (parent.transform.position - new Vector3(0, 0.7f ,0)), parent.transform.rotation);
		Destroy (parent);
    }
}
