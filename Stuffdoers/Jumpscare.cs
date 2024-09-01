using Commons.Components;
using Commons.Singletons;
using Godot;
using Interactables;
using LePlayer;
using System;

namespace StuffDoer
{
	public partial class Jumpscare : Node3D
	{
		[Export] AnimationPlayer killerAnim, cutsceneAnim;

		[Export] SoundPool3d soundPool;

		[Export] Node3D killer;

		[Export] JumpscareTrigger trigger;

		[Export] Player player;
        public override void _Ready()
        {
            killer.Visible = false;
			trigger.OnJumpScareReady += JumpScare;
        }
		public void OnAnimationPlayerAnimationFinished(string anim_name)
		{
            GetTree().ChangeSceneToFile("res://Levels/Level2.tscn");
            GD.Print("cHANGE to tittleskeen");
		}
        public void JumpScare()
		{
			DialogueManager.Instance.ShowPlayerText("");
			killer.Visible = true;
			player.disableMovement = true;
			soundPool.PlaySingleSound();
			cutsceneAnim.Play("ForceOpen");
			killerAnim.Play("jumpScare");

        }
	}
}
