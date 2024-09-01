using Commons.Components;
using Godot;
using System;
namespace Interactables
{

	public partial class InteractableArea : Area3D, IInteractable
	{
        [Export] public bool unique { get ; set ; }
        public Action OnInteract { get ; set ; }
        [Export] public string TextOnInteract { get; set; }

        [Export] private SoundPool SoundPool { get; set; }
        [Export] private SoundPool3d SoundPool3D { get; set; }



        public void PlaySoundPool()
        {
            SoundPool.PlayRandomSound();
        }
        public void PlaySoundPool3D()
        {
            SoundPool3D.PlaySingleSound();
        }
        public void DisableSelf()
        {
            ProcessMode = ProcessModeEnum.Disabled;
        }
        public void EnableSelf()
        {
            ProcessMode = ProcessModeEnum.Inherit;
        }

    }
}
