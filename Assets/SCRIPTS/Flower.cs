using UnityEngine;

public class Flower : MonoBehaviour
{
    // FLOWERS:
    // Collectibles. Give the player +1 Flower if hit and teleports to a random space.
    // Waypoints?
    // adds or subtracts random between 20 and 50 from position of waypoint, randomizing
    // again if it collides with an object.

    public GameObject[] flowerPatches;

    public int choosing;

    public int minWPdist = 5;
    public int maxWPdist = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RunAway();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Debug.Log(this.gameObject + "Collided with " + collision.gameObject);

        if(collision.gameObject.CompareTag("Player"))
        {
            // Debug.Log(this.gameObject + "Collided with THE PLAYER!1!");
            collision.gameObject.GetComponent<Player>().AddItemToInventory("FLOWERS", 1);
            RunAway();
        }
        else if (collision.gameObject.CompareTag("MUSHROAM"))
        {
            // Debug.Log(this.gameObject + "Collided with a Mushroom!!!!");
            RunAway();
        }
        else if (collision.gameObject.CompareTag("FLOWER"))
        {
            // Debug.Log(this.gameObject + "Collided with a flower...");
            ShuffleAway();
        }
        else if (collision.gameObject.CompareTag("ENVIRON"))
        {
            // Debug.Log(this.gameObject + "collided with environment");
            ShuffleAway();
        }
    }

    public void ShuffleAway()
    {
        // Debug.Log("Shuffling Away!!!!!");
        transform.Translate(Random.Range(minWPdist, maxWPdist), 0, Random.Range(minWPdist, maxWPdist));
        // float Xdist = flowerPatches[choosing].transform.position.x - transform.position.x;
        // float Zdist = flowerPatches[choosing].transform.position.z - transform.position.z;
        // Debug.Log("changed position by " + Xdist.ToString() + ", 0, " + Zdist.ToString());
    }

    public void RunAway()
    {
        choosing = Random.Range(0, flowerPatches.Length);
        transform.position = flowerPatches[choosing].transform.position;
        // Debug.Log(this.gameObject + "choosing = " + choosing.ToString());
        transform.Translate(Random.Range(minWPdist, maxWPdist), 0, Random.Range(minWPdist, maxWPdist));
        // float Xdist = flowerPatches[choosing].transform.position.x - transform.position.x;
        // float Zdist = flowerPatches[choosing].transform.position.z - transform.position.z;
        // Debug.Log(this.gameObject + "changed position by " + Xdist.ToString() + ", 0, " + Zdist.ToString());
    }
}
