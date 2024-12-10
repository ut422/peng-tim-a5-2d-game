using Godot;
using System;

public partial class Paddle2 : RigidBody2D
{
    [Export] public float Speed = 300f; // paddle speed
    private Vector2 _velocity = Vector2.Zero;

    public override void _PhysicsProcess(double delta)
    {
        // get input for up/down movement
        float input = 0;

        if (Input.IsActionPressed("paddle2_up"))
        {
            input -= 1;
        }
        if (Input.IsActionPressed("paddle2_down"))
        {
            input += 1;
        }

        // set velocity for up/down movement
        _velocity = new Vector2(0, input * Speed);

        // move the paddle
        MoveAndCollide(_velocity * (float)delta);

        // lock horizontal position by overriding the x position
        Position = new Vector2(Position.X, Position.Y);
    }
}
