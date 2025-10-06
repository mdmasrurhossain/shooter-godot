using Godot;
using System;

public partial class TransitionLayer : CanvasLayer
{
    public static TransitionLayer Instance { get; private set; }
    public ColorRect TransitionColor { get; private set; }

    public override void _Ready()
    {
        Instance = this;
        Instance.TransitionColor.Color = new Color(0, 0, 0, 0);

    } 

    public async void ChangeScene(string target)
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("fade_to_black");
        await ToSignal(GetNode<AnimationPlayer>("AnimationPlayer"), "animation_finished");
        GetTree().ChangeSceneToFile(target);
        GetNode<AnimationPlayer>("AnimationPlayer").PlayBackwards("fade_to_black");
    }
}
