using Godot;
using System;

public partial class ItemContainer : Node2D
{
    public virtual void Hit()
    {
        GD.Print("Object");
    }
}
