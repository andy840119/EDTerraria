﻿/*
  _____                 ____                 
 | ____|_ __ ___  _   _|  _ \  _____   _____ 
 |  _| | '_ ` _ \| | | | | | |/ _ \ \ / / __|
 | |___| | | | | | |_| | |_| |  __/\ V /\__ \
 |_____|_| |_| |_|\__,_|____/ \___| \_/ |___/
          <http://emudevs.com>
             Terraria 1.3
*/

using Terraria.ID;

namespace Terraria.GameContent
{
    public class ChildSafety
    {
        private static SetFactory factoryDust = new SetFactory(268);
        private static SetFactory factoryGore = new SetFactory(907);
        private static readonly bool[] SafeGore = ChildSafety.factoryGore.CreateBoolSet(11, 12, 13, 16, 17, 42, 53, 44, 51, 52, 53, 54, 55, 56, 57, 61, 62, 63, 67, 68, 69, 99, 106, 120, 130, 131, 147, 148, 149, 150, 156, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 213, 217, 218, 219, 220, 221, 222, 257, 265, 266, 267, 268, 269, 276, 277, 278, 279, 280, 281, 282, 314, 321, 322, 326, 331, 360, 361, 362, 363, 364, 365, 366, 367, 368, 369, 370, 375, 376, 377, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 418, 419, 420, 421, 422, 423, 424, 425, 426, 427, 428, 429, 430, 435, 436, 437, 521, 522, 523, 525, 526, 527, 542, 570, 571, 572, 580, 581, 582, 603, 604, 605, 606, 610, 611, 612, 613, 614, 615, 616, 617, 618, 639, 704, 705, 706, 707, 708, 709, 710, 711, 712, 713, 714, 715, 716, 717, 718, 719, 720, 721, 734, 728, 729, 730, 731, 732, 733, 825, 826, 827, 848, 849, 850, 851, 853, 854, 855, 856, 857, 858, 859, 860, 861, 862, 892, 893, 898, 899);
        private static readonly bool[] SafeDust = ChildSafety.factoryDust.CreateBoolSet(1 != 0, 5, 227);
        public static bool Disabled = true;

        public static bool DangerousGore(int id)
        {
            return !SafeGore[id];
        }

        public static bool DangerousDust(int id)
        {
            return !SafeDust[id];
        }
    }
}
