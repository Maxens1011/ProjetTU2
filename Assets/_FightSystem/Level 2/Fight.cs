
using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    public class Fight
    {
        public Fight(Character character1, Character character2, RandomGeneratorType generatorType = RandomGeneratorType.RealGenerator)
        {
            if (character1 is null || character2 is null)
            {
                throw new ArgumentNullException();
            }
            switch (generatorType)
            {
                case RandomGeneratorType.FakeGenerator:
                    RandomGeneratorClass = new FakeGenerator();
                    break;
                case RandomGeneratorType.RealGenerator:
                default:
                    RandomGeneratorClass = new RandomGenerator();
                    break;
            }
            Character1 = character1;
            Character2 = character2;
        }

        private IRandomGenerator RandomGeneratorClass { get; set; }
        public Character Character1 { get; }
        public Character Character2 { get; }

        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished => !(Character1.IsAlive && Character2.IsAlive);

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2, HealObject healObjectFromCharacter1= null, HealObject healObjectFromCharacter2 = null)
        {
            if (healObjectFromCharacter1 != null)
            {
                Character1.ApplyHeal(healObjectFromCharacter1);
                if (healObjectFromCharacter2 != null)
                {
                    Character2.ApplyHeal(healObjectFromCharacter2);
                }
                else
                {
                    Character1.ReceiveAttack(skillFromCharacter2, Character2);
                }
            }
            else if (healObjectFromCharacter2 != null)
            {
                Character2.ApplyHeal(healObjectFromCharacter2);
                Character2.ReceiveAttack(skillFromCharacter1, Character1);
            }
            else
            {
                if (Character1.Speed < Character2.Speed)
                {
                    Character1.ReceiveAttack(skillFromCharacter2, Character2);
                    Character2.ReceiveAttack(skillFromCharacter1, Character1);
                }
                else if (Character1.Speed > Character2.Speed)
                {
                    Character2.ReceiveAttack(skillFromCharacter1, Character1);
                    Character1.ReceiveAttack(skillFromCharacter2, Character2);
                }
                else
                {
                    if (RandomGeneratorClass.Next()%2 == 0)
                    {
                        Character1.ReceiveAttack(skillFromCharacter2, Character2);
                        Character2.ReceiveAttack(skillFromCharacter1, Character1);
                    }
                    else
                    {
                        Character2.ReceiveAttack(skillFromCharacter1, Character1);
                        Character1.ReceiveAttack(skillFromCharacter2, Character2);
                    }
                }
            }
            Character1.ApplyStatus();
            Character2.ApplyStatus();
        }
    }
}
