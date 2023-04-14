using System;

public enum HealingType { NONE = 0, SLEEP = 1, BURN = 2, CRAZY = 4, All = 7 }

public abstract class HealObject
{
    public HealObject(int healAmount, HealingType healingType) 
    {
        HealAmount = Math.Max(0, healAmount);
        HealingType = healingType;
    }

    public int HealAmount { get; private set; }
    public HealingType HealingType { get; private set; }
}

public class Potion : HealObject
{
    public Potion() : base(20, HealingType.NONE) { }
}

public class SuperPotion : HealObject
{
    public SuperPotion() : base(50, HealingType.NONE) { }
}

public class HyperPotion : HealObject
{
    public HyperPotion() : base(100, HealingType.NONE) { }
}

public class Reveil : HealObject
{
    public Reveil() : base(0, HealingType.SLEEP) { }
}

public class Guerison : HealObject
{
    public Guerison() : base(0, HealingType.All) { }
}