using UnityEngine;

/// <summary>
/// When something happens to the character, this is where it'll be handled.
/// </summary>
public class CharController : MonoBehaviour, ICanJump
{
    /*
     * This "#region" is a compiler directive. They allow you to provide custom code
     * optimization, or - in this case - make code look prettier.
     * 
     * If you're in the CS program, you'll cover these in more detail Spring Sophomore year.
     * "#region" is the only one you should care about for now though.
     */
    #region Serialization
    /*
     * This "[SerializeField]" is called an attribute. Attributes can do a variety of things,
     * in this case it allows us to change our moveSpeed and jumpForce in the Unity Editor.
     * 
     * Variables that are public will be automatically serialized. If you want your variable to
     * be public, but not editable in the Editor, use the "[HideInInspector]" Attribute.
     */
    [SerializeField]
    private float moveSpeed, jumpForce;
    #endregion

    private bool onGround;

    // A rigidbody is how we interact with the physics engine.
    private Rigidbody2D rb;

    /// <summary>
    /// Remember, Awake is good for getting components attached to OURSELVES, and 
    /// for instantiating variables.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Remember, Start is good for communicating with OTHER GameObjects.
    /// </summary>
    private void Start()
    {
        // Subscribe our Move and Jump functions to the InputManager.
        InputManager.instance.OnMove += dir => Move(dir);
        InputManager.instance.OnJump += () => Jump();
    }

    private void Move(float direction)
    {
        // add velocity in whichever direction we input, scaled by our moveSpeed.
        rb.velocity += new Vector2(direction, 0) * moveSpeed;
    }

    private void Jump()
    {
        /*
         * If we're on the ground, jump!
         * We're changing the ForceMode to Impulse, because we want our jump to be snappy.
         */
        if(onGround)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// We implemented ICanJump, and therefore must implement it's function.
    /// </summary>
    /// <param name="onGround">
    /// A boolean telling us if we're on the ground or not.
    /// </param>
    public void Grounded(bool onGround)
    {
        this.onGround = onGround;
    }
}
