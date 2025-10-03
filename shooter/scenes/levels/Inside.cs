using Godot;
using System;

public partial class Inside : Level
{
    [Export]
    PackedScene OutsideLevelScene;

    public void OnExitGateAreaBodyEntered(Node2D _body)
    {
        var tween = GetTree().CreateTween();
        tween.TweenProperty(GetNode<Player>("Player"), "Speed", 0, 0.5);
        tween.BindNode(_body);
        // GetTree().CallDeferred("change_scene_to_file", "scenes/levels/outside.tscn");
        GetTree().CallDeferred("change_scene_to_packed", OutsideLevelScene);
    }
}
