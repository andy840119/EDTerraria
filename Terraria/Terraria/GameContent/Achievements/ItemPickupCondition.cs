﻿/*
  _____                 ____                 
 | ____|_ __ ___  _   _|  _ \  _____   _____ 
 |  _| | '_ ` _ \| | | | | | |/ _ \ \ / / __|
 | |___| | | | | | |_| | |_| |  __/\ V /\__ \
 |_____|_| |_| |_|\__,_|____/ \___| \_/ |___/
          <http://emudevs.com>
             Terraria 1.3
*/

using System.Collections.Generic;
using Terraria;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
    internal class ItemPickupCondition : AchievementCondition
    {
        private static Dictionary<short, List<ItemPickupCondition>> _listeners = new Dictionary<short, List<ItemPickupCondition>>();
        private static bool _isListenerHooked = false;
        private const string Identifier = "ITEM_PICKUP";
        private short[] _itemIds;

        private ItemPickupCondition(short itemId)
            : base("ITEM_PICKUP_" + (object)itemId)
        {
            this._itemIds = new short[1]
      {
        itemId
      };
            ItemPickupCondition.ListenForPickup(this);
        }

        private ItemPickupCondition(short[] itemIds)
            : base("ITEM_PICKUP_" + (object)itemIds[0])
        {
            this._itemIds = itemIds;
            ItemPickupCondition.ListenForPickup(this);
        }

        private static void ListenForPickup(ItemPickupCondition condition)
        {
            if (!ItemPickupCondition._isListenerHooked)
            {
                AchievementsHelper.OnItemPickup += new AchievementsHelper.ItemPickupEvent(ItemPickupCondition.ItemPickupListener);
                ItemPickupCondition._isListenerHooked = true;
            }
            for (int index = 0; index < condition._itemIds.Length; ++index)
            {
                if (!ItemPickupCondition._listeners.ContainsKey(condition._itemIds[index]))
                    ItemPickupCondition._listeners[condition._itemIds[index]] = new List<ItemPickupCondition>();
                ItemPickupCondition._listeners[condition._itemIds[index]].Add(condition);
            }
        }

        private static void ItemPickupListener(Player player, short itemId, int count)
        {
            if (player.whoAmI != Main.myPlayer || !ItemPickupCondition._listeners.ContainsKey(itemId))
                return;
            foreach (AchievementCondition achievementCondition in ItemPickupCondition._listeners[itemId])
                achievementCondition.Complete();
        }

        public static AchievementCondition Create(params short[] items)
        {
            return (AchievementCondition)new ItemPickupCondition(items);
        }

        public static AchievementCondition Create(short item)
        {
            return (AchievementCondition)new ItemPickupCondition(item);
        }

        public static AchievementCondition[] CreateMany(params short[] items)
        {
            AchievementCondition[] achievementConditionArray = new AchievementCondition[items.Length];
            for (int index = 0; index < items.Length; ++index)
                achievementConditionArray[index] = (AchievementCondition)new ItemPickupCondition(items[index]);
            return achievementConditionArray;
        }
    }
}
