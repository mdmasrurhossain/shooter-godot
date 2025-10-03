using Godot;
using System;

public partial class Ui : CanvasLayer
{
	public Label LaserLabel;
	public Label GrenadeLabel;

	public override void _Ready()
	{
		LaserLabel = GetNode<Label>("LaserCounter/VBoxContainer/Label");
		GrenadeLabel = GetNode<Label>("GrenadeCounter/VBoxContainer/Label");
		UpdateLaserText();
		UpdateGrenadeText();

	}

	public void UpdateLaserText()
	{
		LaserLabel.Text = (Globals.Instance.LaserAmount).ToString();

	}

	public void UpdateGrenadeText()
	{
		GrenadeLabel.Text = (Globals.Instance.GrenadeAmount).ToString();
	}

}
