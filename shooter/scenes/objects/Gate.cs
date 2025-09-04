using Godot;
using System;

public partial class Gate : StaticBody2D
{
	[Signal]
	public delegate void PlayerEnteredGateEventHandler(Node2D body);

	public void OnArea2DBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.PlayerEnteredGate, body);
	}
}
