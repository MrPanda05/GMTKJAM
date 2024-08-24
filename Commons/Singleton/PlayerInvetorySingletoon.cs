using Godot;
using System;
using System.Collections.Generic;

namespace Commons.Singletons
{
    public partial class PlayerInvetorySingletoon : Node
    {
        public List<int> myKeys = new List<int>();

        public static PlayerInvetorySingletoon Instance { get; private set; }

        public override void _Ready()
        {
            Instance = this;
        }

        public int GetKey(int myId)
        {
            int possibleResult = myKeys.Find(x => x == myId);
            GD.Print(possibleResult);
            if (possibleResult == 0)
            {
                GD.Print("Key does not exist on inventory");
                return 0;
            }
            GD.Print("Key does exist on inventory");
            return possibleResult;
        }

        public void AddKey(int myId)
        {
            if(myKeys.Exists(x => x == myId))
            {
                GD.Print("Already has key");
                return;
            }
            myKeys.Add(myId);
        }
        public void RemoveKey(int myId) 
        {
            if(!myKeys.Exists(x => x == myId))
            {
                GD.Print("Does not have key to remove it");
                return;
            }
            GD.Print($"Removing {myId}");
            myKeys.Remove(myId);
        }
    }
}
