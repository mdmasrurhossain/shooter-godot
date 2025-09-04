using Godot;
using System;

public partial class Laser : Area2D
{
    [Export]
    public int Speed { get; set; } = 200;

    public Vector2 Direction = Vector2.Up;

    public override void _Process(double delta)
    {
        Position += Direction * Speed * (float)delta;
    }

}
