using UnityEngine;

public class WanderState : StateMachineBehaviour
{

    public float WanderTime = 0f;
    // public float WanderDirection = 0f;
    // public float WanderSpeed = 5f;

    // public MushroamMove Move;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("entering wander state");
        animator.GetComponent<MushroamMove>().WanderActive = true;
        animator.GetComponent<MushroamMove>().Roam();
        // ChooseDirection(animator);
        // Move.Rotate(0, WanderDirection, 0);
        // Move = animator.GetComponent<MushroamMove>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("updating wander state");
        WanderTime -= Time.fixedDeltaTime;
        // animator.GetComponent<MushroamMove>().wanderTime = WanderTime;

        if (WanderTime < 0f)
        {
            animator.GetComponent<MushroamMove>().Roam();
            WanderTime = Random.Range(5f, 10f);
            // ChooseDirection(animator);
            // Debug.Log("WANDER TIME < 0, RESETTING?");
        }

        // else
        // {
        // ChooseDirection(animator);
        // Debug.Log("Chosen a new direction!");
        //    WanderTime = Random.Range(2f, 7f);
        //    WanderDirection = Random.Range(0f, 360f);
        //    animator.GetComponent<MushroamMove>().FeedDirection(WanderDirection);
        // }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("exiting wander state");
        animator.GetComponent<MushroamMove>().WanderActive = false;
        animator.GetComponent<MushroamMove>().WanderStop();
    }

    // public void ChooseDirection(Animator animator)
    // {
    //    WanderTime = Random.Range(2f, 7f);
    //    WanderDirection = Random.Range(0f, 360f);
        // Debug.Log("Wander time = " + WanderTime.ToString());
    //    animator.GetComponent<MushroamMove>().FeedDirection(WanderDirection);
        // Debug.Log("Wander direction = " + WanderDirection.ToString());
    // }
}
