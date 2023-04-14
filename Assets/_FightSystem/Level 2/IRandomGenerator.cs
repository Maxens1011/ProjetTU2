using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomGenerator
{
    int Next();
}

public class RandomGenerator : IRandomGenerator
{
    int IRandomGenerator.Next()
    {
        return UnityEngine.Random.Range(0, 101);
    }
}
