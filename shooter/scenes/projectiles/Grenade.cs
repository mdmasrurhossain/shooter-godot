using Godot;
using System;

public partial class Grenade : RigidBody2D
{
    public int Speed { get; set; } = 750;

    public void Explode()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("Explosion");
    }
}
