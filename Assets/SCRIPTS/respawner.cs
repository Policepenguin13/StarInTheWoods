using UnityEngine;

public class respawner : MonoBehaviour
{
    // respawns any errant mushrooms or players that fall down

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.ToString() + " hit the respawner!");

        other.gameObject.transform.position = new Vector3(0f, 6f, 0f);
        other.gameObject.transform.eulerAngles = Vector3.zero;
        // Debug.Log("object should have respawned");
    }
}
