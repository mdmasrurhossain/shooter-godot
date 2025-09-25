using Godot;
using System;

public partial class Toilet : ItemContainer
{
    public override void Hit()
    {
        GD.Print("toilet");
    }
}
