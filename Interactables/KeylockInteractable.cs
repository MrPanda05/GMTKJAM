using Commons.Singletons;
using Godot;
using Interactables;
using System;

namespace Interactables
{
    public partial class KeylockInteractable : StaticBody3D, IInteractable
    {
        public bool unique { get; set; }
        public Action MyInteraction { get ; set; }
        public string TextOnInteract { get; set; }


        private KeyLock keyLock;

        public override void _Ready()
	    {
            keyLock = GetParent().GetParent() as KeyLock;
            MyInteraction += OnInteract;
	    }

        public void NoKeyNeed()
        {
            OnInteractionFinish();
            keyLock.OnOpen?.Invoke();
        }

        public void NeedKey()
        {
            int possibleKey = PlayerInvetorySingletoon.Instance.GetKey(keyLock.GetMyId());
            if (possibleKey == 0 || possibleKey != keyLock.GetMyId())
            {
                DialogueManager.Instance.ShowPlayerText("I don't have a key");
                GD.Print("Invalid or does not have key");
                return;
            }
            GD.Print("has key");
            DialogueManager.Instance.ShowPlayerText("Unlocked");
            OnInteractionFinish();
            keyLock.OnOpen?.Invoke();
            keyLock.QueueFree();//Change this
        }
        public void OnInteract()
        {
            if (keyLock.GetIfNeedKey())
            {
                NeedKey();
            }
            else
            {
                NoKeyNeed();
            }
        }

        public void OnInteractionFinish()
        {
            MyInteraction -= OnInteract;
            PlayerInvetorySingletoon.Instance.RemoveKey(keyLock.GetMyId());
        }
    }
}
