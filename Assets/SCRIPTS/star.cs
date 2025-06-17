using UnityEngine;

public class star : MonoBehaviour
{
    public int StarNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("player detected by star!");
            other.gameObject.GetComponent<Player>().AddItemToInventory("STARS", 1);
            this.gameObject.SetActive(false);
        }
    }

    public void Starfall(int number)
    {
        // Debug.Log(this.gameObject.ToString() + " starfall triggered!");
        // activate this gameobject if number == starnumber
        if (number == StarNumber)
        {
            this.gameObject.SetActive(true);
        }
        
    }
}
