using Godot;
using System;

public partial class Goal : Area2D
{
    // Called when the area is ready to use
    public override void _Ready()
    {
        // Connect the "body_entered" signal of the Area2D to the function in this script
        BodyEntered += _on_Goal_body_entered;
    }

    // Called when a body enters the goal area
    private void _on_Goal_body_entered(Node body)
    {
        // check if the body entering the area is the ball
        if (body is Ball)
        {
            // print an error message in the console
            GD.PrintErr("Ball touched the goal. Quitting the game!");

            // quit the game
            GetTree().Quit();  // This will close the game immediately
        }
    }
}
