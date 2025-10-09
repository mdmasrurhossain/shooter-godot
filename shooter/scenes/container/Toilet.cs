using Godot;
using System;

public partial class Toilet : ItemContainer
{
    public void Hit()
    {
        while (!Opened)
        {
            GetNode<Sprite2D>("LidSprite").Hide();
            Vector2 Position = GetNode<Marker2D>("SpawnPositions/Marker2D").GlobalPosition;
            EmitSignal(SignalName.Open, Position, CurrentDirection);
            Opened = true;
        }

        
    }
}
