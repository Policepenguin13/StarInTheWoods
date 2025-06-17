using UnityEngine;

public class BerryBush : MonoBehaviour
{
    // When bush's trigger collides with the player, deactivate the Berries child-object,
    // deactivate the trigger collider and start 1 min timer (or 6 seconds when testing)
    // give the player a random number of berries between 3 and 7
    // once the timer is up, activate Berries child-object and trigger-collider

    private float targetTime = 6f; // meant to be 60f
    public float timer = 0f;

    public GameObject berries;
    public bool TimerStarted = false;
    public GameObject player;

    private void Update()
    {
        if (TimerStarted)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f) 
            {
                TimesUp();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!TimerStarted)
            {
                // Debug.Log("Player detected!!! Starting timer!!");
                TimerStarted = true;
                GetComponent<CapsuleCollider>().enabled = false;
                Collected();
            }
        }
        else
        {
            return;
        }
    }

    public void Collected()
    {
        timer = targetTime;
        berries.SetActive(false);
        var quantity = UnityEngine.Random.Range(4, 7);
        // Debug.Log("Randomized " + quantity.ToString() + " berries!");
        player.GetComponent<Player>().AddItemToInventory("BERRIES", quantity);
    }

    public void TimesUp()
    {
        TimerStarted = false;
        berries.SetActive(true);
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
