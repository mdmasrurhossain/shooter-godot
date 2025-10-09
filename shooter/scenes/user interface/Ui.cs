using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Ui : CanvasLayer
{
	// Colors
	public Color Green = new Color("6bbfa3");
	public Color Red = new Color((float)0.9, 0, 0, 1);

	public Label LaserLabel;
	public Label GrenadeLabel;
	public TextureRect LaserIcon;
	public TextureRect GrenadeIcon;
	public TextureProgressBar HealthBar;


	public override void _Ready()
	{
		LaserLabel = GetNode<Label>("LaserCounter/VBoxContainer/Label");
		GrenadeLabel = GetNode<Label>("GrenadeCounter/VBoxContainer/Label");
		LaserIcon = GetNode<TextureRect>("LaserCounter/VBoxContainer/TextureRect");
		GrenadeIcon = GetNode<TextureRect>("GrenadeCounter/VBoxContainer/TextureRect");
		HealthBar = GetNode<TextureProgressBar>("MarginContainer/TextureProgressBar");

		Globals.Instance.Connect(Globals.SignalName.StatChange, new Callable(this, MethodName.UpdateStatText));

		UpdateStatText();

	}

	public void UpdateLaserText()
	{
		LaserLabel.Text = (Globals.Instance.LaserAmount).ToString();
		UpdateColor(Globals.Instance.LaserAmount, LaserLabel, LaserIcon);

	}

	public void UpdateGrenadeText()
	{
		GrenadeLabel.Text = (Globals.Instance.GrenadeAmount).ToString();
		UpdateColor(Globals.Instance.GrenadeAmount, GrenadeLabel, GrenadeIcon);
	}

	public void UpdateHealthText()
	{
		HealthBar.Value = Globals.Instance.Health;
	}

	public void UpdateStatText()
	{
		UpdateLaserText();
		UpdateGrenadeText();
		UpdateHealthText();
	}

	public void UpdateColor(int amount, Label label, TextureRect icon)
	{
		if (amount <= 0)
		{
			label.Modulate = Red;
			icon.Modulate = Red;
		}
		else
		{
			label.Modulate = Green;
			icon.Modulate = Green;
		}
	}

}
