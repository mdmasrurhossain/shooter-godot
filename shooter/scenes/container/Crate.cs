using Godot;
using System;

public partial class Crate : ItemContainer
{
    public override void Hit()
    {
        GD.Print("box");
    }
}
