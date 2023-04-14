
using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Défintion simple d'un équipement apportant des boost de stats
    /// </summary>
    public class Equipment
    {
        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed)
        {
            this.BonusHealth = Math.Max(0, bonusHealth);
            this.BonusAttack = Math.Max(0, bonusAttack);
            this.BonusDefense = Math.Max(0, bonusDefense);
            this.BonusSpeed = Math.Max(0, bonusSpeed);
        }

        public int BonusHealth { get; protected set; }
        public int BonusAttack { get; protected set; }
        public int BonusDefense { get; protected set; }
        public int BonusSpeed { get; protected set; }

    }
}
