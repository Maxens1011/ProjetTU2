using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;
        /// <summary>
        /// Niveau du pokemon
        /// </summary>
        int _level;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType, int level = 1)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            _level = level;
            CurrentEquipment = null;
            CurrentHealth = MaxHealth;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                if(CurrentEquipment is null)
                {
                    return _baseHealth;
                }
                return _baseHealth + CurrentEquipment.BonusHealth;
            }
        }

        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                if (CurrentEquipment is null)
                {
                    return _baseAttack;
                }
                return _baseAttack + CurrentEquipment.BonusAttack;
            }
        }

        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                if (CurrentEquipment is null)
                {
                    return _baseDefense;
                }
                return _baseDefense + CurrentEquipment.BonusDefense;
            }
        }

        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                if (CurrentEquipment is null)
                {
                    return _baseSpeed;
                }
                return _baseSpeed + CurrentEquipment.BonusSpeed;
            }
        }

        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }

        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive => CurrentHealth > 0;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        public void ReceiveAttack(Skill s, Character attacker)
        {
            if (!attacker.IsAlive) return;
            if (attacker.CurrentStatus is not null ? !attacker.CurrentStatus.CanAttack : false) return;
            CurrentHealth -= Math.Min(CurrentHealth, Math.Max(0, s.Power - Defense));
            if (attacker.CurrentStatus is not null)
            {
                attacker.CurrentHealth -= (int)(attacker.CurrentStatus.DamageOnAttack * (s.Power - Defense));
            }
            if (CurrentStatus is null && s.Status != StatusPotential.NONE)
                CurrentStatus = StatusEffect.GetNewStatusEffect(s.Status);
        }

        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment is null)
            {
                throw new ArgumentNullException();
            }
            CurrentEquipment = newEquipment;
        }

        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
        }
        
        /// <summary>
        /// Apply the status effect on the character at the end of the turn
        /// </summary>
        public void ApplyStatus()
        {
            if (CurrentStatus is null || !IsAlive) return;
            CurrentHealth -= CurrentStatus.DamageEachTurn;
            if (CurrentStatus.EndTurn()) CurrentStatus = null;
        }
    }
}
