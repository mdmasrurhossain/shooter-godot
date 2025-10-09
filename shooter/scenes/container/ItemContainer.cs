using Godot;
using System;

public partial class ItemContainer : StaticBody2D
{
    [Signal]
    public delegate void OpenEventHandler(Vector2 Pos, Vector2 Direction);

    public Vector2 CurrentDirection;
    public bool Opened = false;

    public override void _Ready()
    {
        CurrentDirection = Vector2.Down.Rotated(Rotation);
    }

}
