using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		// input
		var Direction = Input.GetVector("left", "right", "up", "down");
		Velocity = Direction * 500;
		MoveAndSlide();

		// laser shooting input
		if (Input.IsActionPressed("primary_action"))
		{
			GD.Print("Shoot Laser");
		}
		if (Input.IsActionPressed("secondary_action"))
		{
			GD.Print("Throw Grenade");
		}
	}
}
