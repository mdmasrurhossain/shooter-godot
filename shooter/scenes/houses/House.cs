using Godot;
using System;

public partial class House : Area2D
{
    [Signal]
    public delegate void PlayerEnteredEventHandler();

    [Signal]
    public delegate void PlayerExitedEventHandler();

    private void OnBodyEntered(Node2D _body)
    {
        EmitSignal(SignalName.PlayerEntered);
    }

    private void OnBodyExited(Node2D _body)
    {
        EmitSignal(SignalName.PlayerExited);
    }
}
