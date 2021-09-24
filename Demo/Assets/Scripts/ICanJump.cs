/// <summary>
/// Interfaces are intermediate C#. If you're in the CS Program here, you will learn about them
/// Spring of Freshman year or Fall of Sophomore year.
/// 
/// I'll post notes on them in #resources.
/// </summary>
public interface ICanJump
{
    /// <summary>
    /// Basically, any class that implements this interface, must implement this function.
    /// </summary>
    /// <param name="onGround">
    /// A boolean telling us if we're on the ground or not.
    /// </param>
    void Grounded(bool onGround);
}
