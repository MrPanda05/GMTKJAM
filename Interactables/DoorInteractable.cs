using Commons.Singletons;
using Godot;
using System;

namespace Interactables
{
	public partial class DoorInteractable : Node3D
	{
        private InteractableArea area;

        [Export] public bool isLocked { get; private set; }
        [Export] public int myKeyId { get; private set; } = -1;

        [Export] public bool closeAutomtic { get; private set; }

        private bool isOpen;

        private Timer timer;

        private AnimationPlayer animPlayer;
        public override void _Ready()
        {
            area = GetNode<InteractableArea>("Hinge/InteractableArea");
            animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
            timer = GetNode<Timer>("Timer");
            area.OnInteract += DoorLogic;
        }
        public void DoorLogic()
        {
            if (isOpen)
            {
                CloseDoor();
                return;
            }
            if(!isLocked && !isOpen) 
            {
                OpenDoor();
                return;
            }
            DoorKeyLogic();

        }
        public void DoorKeyLogic()
        {
            int possibleKey = PlayerInvetorySingletoon.Instance.GetKey(myKeyId);
            if (possibleKey == 0 || possibleKey != myKeyId)
            {
                DialogueManager.Instance.ShowPlayerText(area.TextOnInteract);
                GD.Print("Invalid or does not have key");
                return;
            }
            GD.Print("has key");
            OpenDoor();
            isLocked = false;
        }
        public void OpenDoor()
        {
            if (animPlayer.IsPlaying()) return;
            if (closeAutomtic)
            {
                timer.Start();
            }
            animPlayer.Play("Open");
            isOpen = true;
            area.PlaySoundPool3D();
            GD.Print("Opening");
        }
        public void CloseDoor()
        {
            if (animPlayer.IsPlaying()) return;
            animPlayer.Play("Close");
            isOpen = false;
            area.PlaySoundPool3D();
            GD.Print("Closing");
        }
        public void OnTimerTimeout()
        {
            if (animPlayer.IsPlaying()) return;
            if (!isOpen) return;
            CloseDoor();
        }
        public override void _ExitTree()
        {
            area.OnInteract -= DoorLogic;
        }
    }
}
