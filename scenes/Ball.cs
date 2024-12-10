using Godot;
using System;

public partial class Ball : RigidBody2D
{
    [Export] public float Speed = 300f; // export variable for ball speed

    private Vector2 _velocity = Vector2.Zero; // variable to store ball's velocity

    public override void _Ready()
    {
        ResetBall(); // reset the ball's position and velocity when the game starts
    }

    public override void _PhysicsProcess(double delta)
    {
        // move the ball and check for collisions
        var collision = MoveAndCollide(_velocity * (float)delta);
        if (collision != null)
        {
            // bounce the ball off the surface it collides with
            _velocity = _velocity.Bounce(collision.GetNormal());

            // get the object the ball collided with
            var collider = collision.GetCollider();

            // if the collider has a "Hit" method, call it
            if (collider.HasMethod("Hit"))
            {
                collider.Call("Hit");
            }
        }
    }

    private void ResetBall()
    {
        // debug print to check the parent node
        GD.Print("Parent of Ball: ", GetParent().Name);

        // safely try to get the BallStart node
        var ballStartNode = GetParent().GetNodeOrNull<Node2D>("BallStart");

        // if the BallStart node is not found, print an error and exit
        if (ballStartNode == null)
        {
            GD.PrintErr("BallStart node not found! Please ensure it exists in the scene.");
            return; // exit the method if BallStart is missing
        }

        // set the ball's position to that of the BallStart node
        Position = ballStartNode.Position;

        // initialize the ball's velocity moving to the right with the specified speed
        _velocity = new Vector2(Speed, 100);
    }
}
