using Godot;
using System;

public partial class Globals : Node
{
    [Signal]
    public delegate void HealthChangeEventHandler();

    public int LaserAmount = 20;
    public int GrenadeAmount = 5;
    private int _health = 60;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            EmitSignal(SignalName.HealthChange);
        }

    }
    public static Globals Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

}
