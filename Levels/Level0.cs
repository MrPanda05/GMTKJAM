using Godot;
using System;

public partial class Level0 : Node3D
{
	public void OnButtonButtonDown()
	{
        GetTree().ChangeSceneToFile("res://Levels/Level1.tscn");
    }
}
