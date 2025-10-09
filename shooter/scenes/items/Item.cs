using Godot;
using System;

public partial class Item : Area2D
{
    public int RotationSpeed = 4;
    public string[] AvailableOptions = ["laser", "laser", "laser", "laser", "grenade", "health"];
    public string Type;
    public Random RandomNumber = new Random();
    public Vector2 Direction;
    public int Distance = GD.RandRange(150, 250);

    public Item()
    {
        Type = AvailableOptions[RandomNumber.Next(0, AvailableOptions.Length)];
        // Type = "health";
    }

    public override void _Ready()
    {
        if (Type == "laser")
            GetNode<Sprite2D>("Sprite2D").Modulate = new Color((float)0.1, (float)0.2, (float)0.8);
        if (Type == "grenade")
            GetNode<Sprite2D>("Sprite2D").Modulate = new Color((float)0.8, (float)0.2, (float)0.1);
        if (Type == "health")
            GetNode<Sprite2D>("Sprite2D").Modulate = new Color((float)0.1, (float)0.8, (float)0.1);

        // tween
        var TargetPos = Position + Direction * Distance;
        var Tween = CreateTween();
        Tween.SetParallel(true);
        Tween.TweenProperty(this, "position", TargetPos, 0.5);
        Tween.TweenProperty(this, "scale", new Vector2(1, 1), 0.3).From(new Vector2(0, 0));
    }


    public override void _Process(double delta)
    {
        Rotation += RotationSpeed * (float)delta;
    }

    public void OnBodyEntered(Node _body)
    {
		if (Type == "laser")  
			Globals.Instance.LaserAmount += 5;
		if (Type == "grenade")
			Globals.Instance.GrenadeAmount += 1;
        if (Type == "health")
            Globals.Instance.Health += 10;
        QueueFree();
    }

}
