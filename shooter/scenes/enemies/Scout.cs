using Godot;
using System;
using System.Collections.Generic;

public partial class Scout : CharacterBody2D
{
	[Signal]
	public delegate void LaserEventHandler(Vector2 Position, Vector2 Direction);

	public bool PlayerNearby = false;
	public bool CanLaser = true;
	public bool RightGunUse = true;

	public override void _Process(double _delta)
	{
		if (PlayerNearby)
		{
			LookAt(Globals.Instance.PlayerPos);
			if(CanLaser)
			{
				Marker2D MarkerNode = (Marker2D)GetNode<Node2D>("LaserSpawnPositions").GetChild(Convert.ToInt32(RightGunUse));
				RightGunUse = !RightGunUse;
				Vector2 Position = MarkerNode.GlobalPosition;
				Vector2 Direction = (Globals.Instance.PlayerPos - Position).Normalized();
				EmitSignal(SignalName.Laser, Position, Direction);
				CanLaser = false;
				GetNode<Timer>("LaserCooldown").Start();
            }
        }
	}

	public void OnAttackAreaBodyEntered(Node2D _body)
	{
		PlayerNearby = true;
	}

	public void OnAttackAreaBodyExited(Node2D _body)
	{
		PlayerNearby = false;
	}
	
	public void OnLaserCooldownTimeout()
    {
        CanLaser = true;
    }

}
