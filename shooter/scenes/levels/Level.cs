using Godot;
using System;

public partial class Level : Node2D
{
	public PackedScene LaserScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/laser.tscn");
	public PackedScene GrenadeScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/grenade.tscn");

	public void OnPlayerLaserFired(Vector2 pos, Vector2 direction)
	{
		var laser = LaserScene.Instantiate<Laser>();
		laser.Position = pos;
		laser.RotationDegrees = Mathf.RadToDeg(direction.Angle()) + 90;
		laser.Direction = direction;
		GetNode<Node2D>("Projectiles").AddChild(laser, true);
		GetNode<Ui>("UI").UpdateLaserText();
	}

	public void OnPlayerGrenadeThrown(Vector2 pos, Vector2 direction)
	{
		var grenade = GrenadeScene.Instantiate<Grenade>();
		grenade.Position = pos;
		grenade.LinearVelocity = direction * grenade.Speed;
		GetNode<Node2D>("Projectiles").AddChild(grenade, true);
		GetNode<Ui>("UI").UpdateGrenadeText();
	}

	public void OnHousePlayerEntered()
	{
		var tween = GetTree().CreateTween();
		tween.SetParallel(true);
		tween.TweenProperty(GetNode<Camera2D>("Player/Camera2D"), "zoom", new Vector2(1.0f, 1.0f), 1.0f).SetTrans(Tween.TransitionType.Quad);
		// tween.TweenProperty(GetNode<CharacterBody2D>("Player"), "modulate:a", 0.0f, 2.0f).From(0.5f);
	}

	public void OnHousePlayerExited()
	{
		var tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Camera2D>("Player/Camera2D"), "zoom", new Vector2(0.6f, 0.6f), 2.0f);
	}

	public void OnPlayerUpdateStats()
	{
		GetNode<Ui>("UI").UpdateLaserText();
		GetNode<Ui>("UI").UpdateGrenadeText();
	}

}
