using Godot;
using System;

public partial class Level : Node2D
{
	public PackedScene LaserScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/laser.tscn");
	public PackedScene GrenadeScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/grenade.tscn");
	public PackedScene ItemScene = ResourceLoader.Load<PackedScene>("res://scenes/items/item.tscn");

	public override void _Ready()
	{
		foreach (Node2D container in GetTree().GetNodesInGroup("Container"))
		{
			container.Connect(ItemContainer.SignalName.Open, new Callable(this, MethodName.OnContainerOpened));
		}

		foreach (Node2D scout in GetTree().GetNodesInGroup("Scouts"))
        {
			scout.Connect(Scout.SignalName.Laser, new Callable(this, MethodName.OnScoutLaser));
        }

	}

	public void OnContainerOpened(Vector2 pos, Vector2 direction)
	{
		Item item = ItemScene.Instantiate<Item>();
		item.Position = pos;
		item.Direction = direction;
		GetNode<Node2D>("Items").CallDeferred("add_child", item);
	}


	public void OnPlayerLaserFired(Vector2 pos, Vector2 direction)
	{
		CreateLaser(pos, direction);
	}

	public void OnScoutLaser(Vector2 pos, Vector2 direction)
	{
		CreateLaser(pos, direction);
	}

	public void CreateLaser(Vector2 pos, Vector2 direction)
	{
		var laser = LaserScene.Instantiate<Laser>();
		laser.Position = pos;
		laser.RotationDegrees = Mathf.RadToDeg(direction.Angle()) + 90;
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
