
using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;
using System;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer les TU sur le reste et de les implémenter

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type



        [Test]

        public void CharacterReceiveTypeAffectedSkill()
        {
            var poussifeu = new Character(100, 50, 20, 60, TYPE.FIRE);
            var fb = new FireBall();
            var arcko = new Character(100, 40, 10, 70, TYPE.GRASS);
            var mg = new MagicalGrass();
            var oldHealth = poussifeu.CurrentHealth;

            arcko.ReceiveAttack(fb, poussifeu); // hp : 100 => 52
            Assert.That(arcko.CurrentHealth, Is.EqualTo(52));
            Assert.True(arcko.CurrentStatus is BurnStatus);
            Assert.That(arcko.IsAlive, Is.EqualTo(true));

            poussifeu.ReceiveAttack(mg, arcko); // hp : 100 => 
            Assert.That(poussifeu.CurrentHealth, Is.EqualTo(60));
            Assert.True(poussifeu.CurrentStatus is SleepStatus);
            Assert.That(poussifeu.IsAlive, Is.EqualTo(true));
        }
    }
    }
