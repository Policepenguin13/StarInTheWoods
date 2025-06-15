using Unity.VisualScripting;
using UnityEngine;

public class StartleState : StateMachineBehaviour
{
    // [formerly] Mushroom finds the direction / looks at the thing it just collided with,
    // then looks in the opposite direction and goes for like 8 seconds or something
    // then it exits the state

    // this script is only in charge of the 8 second FleeingTime really

    public float FleeingTime = 8f;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FleeingTime = 8f;
        Debug.Log("entering startle state");
        animator.GetComponent<MushroamMove>().wanderSpeed += 5;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FleeingTime -= Time.fixedDeltaTime;

        if (FleeingTime < 0f)
        {
            animator.GetComponent<MushroamMove>().CalmDown();
            Debug.Log("triggering Calm!");
            animator.SetTrigger("Calm");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exiting startle state");
        animator.GetComponent<MushroamMove>().wanderSpeed -= 5;
    }
}
