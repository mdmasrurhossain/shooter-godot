using Godot;
using System;

public partial class Globals : Node
{
    [Signal]
    public delegate void StatChangeEventHandler();

    private int _laserAmount = 20;
    private int _grenadeAmount = 5;
    private int _health = 60;

    public int LaserAmount
    {
        get
        {
            return _laserAmount;
        }

        set
        {
            _laserAmount = value;
            EmitSignal(SignalName.StatChange);
        }
    }
    public int GrenadeAmount
    {
        get
        {
            return _grenadeAmount;
        }

        set
        {
            _grenadeAmount = value;
            EmitSignal(SignalName.StatChange);
        }
    }
    
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            EmitSignal(SignalName.StatChange);
        }

    }
    public static Globals Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

}
