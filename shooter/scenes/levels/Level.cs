using Godot;
using System;

public partial class Level : Node2D
{
	public PackedScene LaserScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/laser.tscn");
	public PackedScene GrenadeScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/grenade.tscn");

	public void OnGatePlayerEnteredGate(Node2D body)
	{
		GD.Print("Player has entered gate");
		GD.Print($"{body.Name}: {body}");
	}

	public void OnPlayerLaserFired(Vector2 pos, Vector2 direction)
	{
		var laser = LaserScene.Instantiate<Laser>();
		laser.Position = pos;
		laser.RotationDegrees =  Mathf.RadToDeg(direction.Angle()) + 90;
		laser.Direction = direction;
		GetNode<Node2D>("Projectiles").AddChild(laser, true);
	}

	public void OnPlayerGrenadeThrown(Vector2 pos, Vector2 direction)
	{
		var grenade = GrenadeScene.Instantiate<Grenade>();
		grenade.Position = pos;
		grenade.LinearVelocity = direction * grenade.Speed;
		GetNode<Node2D>("Projectiles").AddChild(grenade, true);
	}

}
