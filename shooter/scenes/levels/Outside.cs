using Godot;
using System;

public partial class Outside : Level
{
    public void OnGatePlayerEnteredGate(Node2D _body)
	{
		var tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Player>("Player"), "Speed", 0, 0.5);
	}
    
}
