using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFFToggle
{
    public class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            Server.FriendlyFire = false;
        }

        public void OnRoundEnded(RoundEndedEventArgs _)
        {
            Server.FriendlyFire = true;
            foreach (Player ply in Player.List)
            {
                if (MainPlugin.Singleton.Config.ItemsToGive.Count > 0)
                {
                    foreach (ItemType item in MainPlugin.Singleton.Config.ItemsToGive)
                        ply.AddItem(item);
                }
            }
        }
    }
}
