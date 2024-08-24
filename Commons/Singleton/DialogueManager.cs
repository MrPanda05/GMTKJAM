using Godot;
using System;

namespace Commons.Singletons
{
    public partial class DialogueManager : Node
    {
        public static DialogueManager Instance { get; private set; }

        private Label dialogueLabel;

        private Timer timer;
        public override void _Ready()
        {
            Instance = this;
            timer = GetNode<Timer>("ShowTextTimer");
            TryToGetLabel();
        }
        public void TryToGetLabel()
        {
            if (dialogueLabel != null) return;
            dialogueLabel = GetTree().GetFirstNodeInGroup("MonologueLabel") as Label;
        }
        public void SetLabelVisibility(bool visible)
        {
            dialogueLabel.Visible = visible;
        }
        public void SetTextDialogue(string text)
        {
            if(dialogueLabel == null) 
            {
                TryToGetLabel();
            }
            dialogueLabel.Text = text;
        }
        public void OnShowTextTimerTimeout() 
        {
            GD.Print("TimerStoped");
            SetTextDialogue("");
            SetLabelVisibility(false);
        }
        public void ShowPlayerText(string text)
        {
            SetTextDialogue(text);
            if (!dialogueLabel.Visible)
            {
                SetLabelVisibility(true);
            }
            timer.Start();
        }
    }
}
