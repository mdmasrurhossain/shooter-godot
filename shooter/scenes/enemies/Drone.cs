using Godot;
using System;

public partial class Drone : CharacterBody2D
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		var Direction = Vector2.Right;
		Velocity = Direction * 100;
		MoveAndSlide();		
	}
}
