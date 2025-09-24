using Godot;
using System;

public partial class Laser : Area2D
{
    [Export]
    public int Speed { get; set; } = 1000;

    public Vector2 Direction = Vector2.Up;

    public override void _Ready()
    {
        GetNode<Timer>("SelfDestructTimer").Start();
    }


    public override void _Process(double delta)
    {
        Position += Direction * Speed * (float)delta;
    }

    public void OnBodyEntered(Node2D _body)
    {
        if (_body.HasMethod("Hit"))
        {
            _body.Call("Hit");
        }
        QueueFree();

    }

    public void OnSelfDestructTimerTimeout()
    {
        QueueFree();
    }

}
