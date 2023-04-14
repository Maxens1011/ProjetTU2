using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomGenerator
{
    int Next();
}

public class RandomGenerator : IRandomGenerator
{
    public RandomGenerator() { }

    int IRandomGenerator.Next() => UnityEngine.Random.Range(0, 100);
}

public class FakeGenerator : IRandomGenerator
{
    int _incrementValue;

    public FakeGenerator() => _incrementValue = 0;

    public int Next() => _incrementValue = (_incrementValue + 1) % 100;
}

public enum RandomGeneratorType
{
    RealGenerator,
    FakeGenerator
}