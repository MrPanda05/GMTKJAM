using Commons.Components;
using Commons.Singletons;
using Godot;
using System;

namespace Interactables
{
	public partial class FlushToilet : Node3D
	{
        private InteractableArea area;
        [Export] SoundPool3d soundPool;
        public override void _Ready()
        {
            area = GetNode<InteractableArea>("InteractableArea");
            area.OnInteract += PlaySound;
        }

        public void PlaySound()
        {
            soundPool.PlaySingleSound();
        }

        public override void _ExitTree()
        {
            area.OnInteract -= PlaySound;

        }
    }
}
