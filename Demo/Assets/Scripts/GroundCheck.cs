using UnityEngine;

/// <summary>
/// Determine if we're on the ground and alert our parent.
/// This component must be attached to a CHILD GAMEOBJECT to the thing that's jumping.
/// See the heirarchy in the Game Engine.
/// </summary>
public class GroundCheck : MonoBehaviour
{
    // The thing we'll be telling if we're in the air or not.
    private ICanJump papa;

    private void Awake()
    {
        /*
         * When there is a parent - child relationship in the Unity Heirarchy, access them
         * via the transform.
         */
        papa = transform.GetComponentInParent<ICanJump>();
    }

    /// <summary>
    /// A trigger is a special collider for when you don't want things to "bump" into each other,
    /// but you do want to know when they're touching. To make a collider into a trigger, check the
    /// box in the component menu.
    /// </summary>
    /// <param name="collision">
    /// The thing we just collided with.
    /// </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we collided with the ground, tell papa we're grounded.
        if (collision.CompareTag("Ground"))
        {
            papa.Grounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If we've left the ground, tell papa we're no longer grounded.
        if (collision.CompareTag("Ground"))
        {
            papa.Grounded(false);
        }
    }
}
