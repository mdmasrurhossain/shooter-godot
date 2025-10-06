using Godot;
using System;
using System.Linq;

public partial class Player : CharacterBody2D
{

	[Signal]
	public delegate void LaserFiredEventHandler(Vector2 Position, Vector2 Direction);

	[Signal]
	public delegate void GrenadeThrownEventHandler(Vector2 Position, Vector2 Direction);

	[Signal]
	public delegate void UpdateStatsEventHandler();

	public bool CanLaser = true;
	public bool CanGrenade = true;

	[Export]
	public int MaxSpeed;
	public int Speed;

	public override void _Ready()
	{
		MaxSpeed = 500;
		Speed = MaxSpeed;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		var LaserTimer = GetNode<Timer>("LaserTimer");
		var GrenadeTimer = GetNode<Timer>("GrenadeTimer");
		// input
		var Direction = Input.GetVector("left", "right", "up", "down");
		Velocity = Direction * Speed;
		MoveAndSlide();

		// rotate player
		LookAt(GetGlobalMousePosition());

		var PlayerDirection = (GetGlobalMousePosition() - Position).Normalized();

		// laser shooting input
		if (Input.IsActionPressed("primary_action") && CanLaser && Globals.Instance.LaserAmount > 0)
		{
			Globals.Instance.LaserAmount -= 1;
			GetNode<GpuParticles2D>("GPUParticles2D").Emitting = true;
			var LaserMarkers = GetNode<Node2D>("LaserStartPositions").GetChildren();
			var SelectedLaser = (Node2D)LaserMarkers[(int)(GD.Randi() % LaserMarkers.Count)];

			CanLaser = false;
			LaserTimer.Start();


			EmitSignal(SignalName.LaserFired, SelectedLaser.GlobalPosition, PlayerDirection);

		}

		if (Input.IsActionPressed("secondary_action") && CanGrenade && Globals.Instance.GrenadeAmount > 0)
		{
			Globals.Instance.GrenadeAmount -= 1;
			var GrenadeMarkers = GetNode<Node2D>("GrenadeStartPositions").GetChildren();
			var SelectedGrenade = (Node2D)GrenadeMarkers[(int)(GD.Randi() % GrenadeMarkers.Count)];

			CanGrenade = false;
			GrenadeTimer.Start();

			EmitSignal(SignalName.GrenadeThrown, SelectedGrenade.GlobalPosition, PlayerDirection);
		}

	}

	private void OnLaserTimerTimeout()
	{
		CanLaser = true;
	}

	private void OnGrenadeTimerTimeout()
	{
		CanGrenade = true;
	}

	public void AddItem(string type)
	{
		if (type == "laser")
			Globals.Instance.LaserAmount += 5;
		if (type == "grenade")
			Globals.Instance.GrenadeAmount += 1;
		EmitSignal(SignalName.UpdateStats);
	}
}
