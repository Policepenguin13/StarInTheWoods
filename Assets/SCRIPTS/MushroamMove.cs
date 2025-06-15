using UnityEngine;

public class MushroamMove : MonoBehaviour
{

    // Controls the mushroom's movement and direction, and to some degree state-swapping 


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
        if (WanderActive)
        {
            this.transform.position += this.transform.forward * wanderSpeed * Time.fixedDeltaTime;
        }
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

    public void CalmDown()
    {
        WanderActive = true;
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
            collision.gameObject.GetComponent<Player>().AddItemToInventory("MUSHROOMS", 1);

            this.transform.LookAt(collision.gameObject.transform);
            // this.transform.eulerAngles = new Vector3(-transform.eulerAngles.x, -transform.eulerAngles.y, -transform.eulerAngles.z);
            
            // float yrot = this.transform.rotation.eulerAngles.y;
            // this.transform.Rotate(0, -yrot, 0);

        } else if (collision.gameObject.CompareTag("FLOWER") == true)
        {
            Debug.Log("COLLIDED WITH FLOWER, startling");
            this.GetComponent<Animator>().SetTrigger("Startle");

            this.transform.LookAt(collision.gameObject.transform);
            float yrot = this.transform.rotation.eulerAngles.y;
            this.transform.Rotate(0, -yrot, 0);
        }
        else
        {
            // Debug.Log("COLLIDED WITH SOMETHING THAT DOESN'T HAVE A PLAYER OR FLOWER TAG");
        }
    }
}
