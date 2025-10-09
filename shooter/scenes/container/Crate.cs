using Godot;
using System;

public partial class Crate : ItemContainer
{
    public void Hit()
    {
        while (!Opened)
        {
            GetNode<Sprite2D>("LidSprite").Hide();

            for (int i = 0; i < 5; i++)
            {
                Vector2 Position = GetNode<Node2D>("SpawnPositions").GetChild<Node2D>((int)GD.Randi() % GetNode<Node2D>("SpawnPositions").GetChildCount()).GlobalPosition;
                EmitSignal(SignalName.Open, Position, CurrentDirection);
            }
            Opened = true;
        }

        
    }
}
