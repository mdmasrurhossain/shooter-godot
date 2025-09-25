using Godot;
using System;

public partial class Inside : Level
{
    public void OnExitGateAreaBodyEntered(Node2D _body)
    {
        var tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Player>("Player"), "Speed", 0, 0.5);
    }
}
