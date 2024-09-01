using Commons.Components;
using Commons.Singletons;
using Godot;
using System;

namespace Interactables
{

	public partial class EatAllInteractable : Node3D
	{
		[Export]
		private InteractableArea area1, area2, area3, frontdoorlock, frontDoorBlock;

		public Action DoSomething;
		[Export] private SoundPool3d soundPool;
		private int count = 0;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
            area1.OnInteract += IncrementCounter1;
			area2.OnInteract += IncrementCounter2;
			area3.OnInteract += IncrementCounter3;
        }
		public void IsThree()
		{
			if(count == 3)
			{
				DoSomething?.Invoke();
				DialogueManager.Instance.ShowPlayerText("W-what was that? I better investigate");
                frontdoorlock.DisableSelf();
                frontDoorBlock.EnableSelf();
                soundPool.PlaySingleSound();
            }
		}

        public void IncrementCounter1()
		{
			area1.DisableSelf();
			area1.PlaySoundPool3D();
            Node3D test = area1.GetParent() as Node3D;//change to node3d
			test.Visible = false;
			count++;
			IsThree();

        }
        public void IncrementCounter2()
        {
            area2.DisableSelf();
            area2.PlaySoundPool3D();
            Node3D test = area2.GetParent() as Node3D;
            test.Visible = false;
            count++;
            IsThree();
        }
        public void IncrementCounter3()
        {
			area3.DisableSelf();
            area3.PlaySoundPool3D();
            Node3D test = area3.GetParent() as Node3D;
            test.Visible = false;
            count++;
			IsThree();
        }

    }
}
