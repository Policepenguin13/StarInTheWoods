using UnityEngine;

public class MushroamMove : MonoBehaviour
{
    // public float timewander;
    // public float speed;
    // public float direct;
    public bool WanderActive;
    public float wanderSpeed = 10f;
    public float wanderDirection;

    public Rigidbody rb;


    // public void MoveUpdate(float WanderSpeed)
    // {
    //    wanderSped = WanderSpeed;
    // rb.position += transform.forward * Time.deltaTime * WanderSpeed;
    // rb.AddForce(Vector3.forward * WanderSpeed, ForceMode.Impulse);
    // }

    private void FixedUpdate()
    {
        this.transform.position += this.transform.forward * wanderSpeed * Time.deltaTime;
    }

    public void Roam()
    {
        wanderDirection = Random.Range(0f, 360f);
        this.transform.Rotate(0, wanderDirection, 0);
    }

    public void WanderStop()
    {
        WanderActive = false;
    }

    // public void FeedDirection(float WanderDirection)
    // {
    //    this.transform.Rotate(0, WanderDirection, 0);
    // }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("COLLIDED WITH PLAYER, startling");
            this.GetComponent<Animator>().SetTrigger("Startle");
        } else if (collision.gameObject.CompareTag("FLOWER") == true)
        {
            Debug.Log("COLLIDED WITH FLOWER, startling");
            this.GetComponent<Animator>().SetTrigger("Startle");
        }
        else
        {
            // Debug.Log("COLLIDED WITH SOMETHING THAT DOESN'T HAVE A PLAYER OR FLOWER TAG");
        }
    }
}
