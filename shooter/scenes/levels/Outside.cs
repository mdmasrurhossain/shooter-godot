using Godot;
using System;

public partial class Outside : Level
{
    PackedScene InsideLevelScene = ResourceLoader.Load<PackedScene>("res://scenes/levels/inside.tscn");


    public void OnGatePlayerEnteredGate(Node2D _body)
    {
        var tween = GetTree().CreateTween();
        tween.TweenProperty(GetNode<Player>("Player"), "Speed", 0, 0.5);
        tween.BindNode(_body);
        // GetTree().CallDeferred("change_scene_to_file", "scenes/levels/inside.tscn");
        GetTree().CallDeferred("change_scene_to_packed", InsideLevelScene);
    }
    
}
