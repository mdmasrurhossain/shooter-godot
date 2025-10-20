using Godot;
using System;

public partial class Outside : Level
{
    public void OnGatePlayerEnteredGate(Node2D _body)
    {
        var tween = GetTree().CreateTween();
        tween.TweenProperty(GetNode<Player>("Player"), "Speed", 0, 0.5);
        tween.BindNode(_body);
        TransitionLayer.Instance.ChangeScene("res://scenes/levels/inside.tscn");
    }

    public void OnHousePlayerEntered()
	{
		var tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Camera2D>("Player/Camera2D"), "zoom", new Vector2(1.0f, 1.0f), 1.0f).SetTrans(Tween.TransitionType.Quad);
	}

	public void OnHousePlayerExited()
	{
		var tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Camera2D>("Player/Camera2D"), "zoom", new Vector2(0.6f, 0.6f), 2.0f);
	}
    
}
