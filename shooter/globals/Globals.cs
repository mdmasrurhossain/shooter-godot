using Godot;
using System;

public partial class Globals : Node
{
    public int LaserAmount = 20;
    public int GrenadeAmount = 5;
    public static Globals Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

}
