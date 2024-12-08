using Godot;
using System;

public partial class Ball : RigidBody2D
{
    [Export] public float Speed = 400f; // export variable for ball speed

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

