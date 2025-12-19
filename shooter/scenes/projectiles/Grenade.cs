using Godot;
using System;

public partial class Grenade : RigidBody2D
{
    public int Speed { get; set; } = 750;
    public bool ExplosionActive = false;
    public int ExplosionRadius = 400;

    public void Explode()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("Explosion");
        ExplosionActive = true;
    }

    public override void _Process(double _delta)
    {
        if (ExplosionActive)
        {
            var targets = GetTree().GetNodesInGroup("Container") + GetTree().GetNodesInGroup("Entity");
            
            foreach (Node2D target in targets)
            {
                var inRange = target.GlobalPosition.DistanceTo(GlobalPosition) < ExplosionRadius;
                if (target.HasMethod("Hit") && inRange)
                {
                    target.Call("Hit");
                }
            }
        }
    }

}
