using Godot;
using System;

public partial class Level2 : Node3D
{
	[Export] private Label label1, label2, label3;

    [Export] private AnimationPlayer anim;

    public void OnAnimationPlayerAnimationFinished(string name)
    {
        GetTree().Quit();
    }
    public override void _Ready()
    {
        anim.Play("fadein");
    }
}
