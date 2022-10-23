using System;
using System.Collections.Generic;
using Verse;

namespace LingGame;

public class LingIntVec3Unity
{
    public List<Pawn> GetAllPawn(IntVec3 intVec, Map map)
    {
        var list = new List<Pawn>();
        foreach (var thing in intVec.GetThingList(map))
        {
            if (thing is not Pawn item)
            {
                continue;
            }

            list.Add(item);
        }

        return list;
    }

    public List<IntVec3> GetRound(IntVec3 center, float radius, Map map)
    {
        var list = new List<IntVec3>();
        var x = map.Size.x;
        var x2 = center.x;
        var z = center.z;
        for (var i = -(int)radius; i < radius; i++)
        {
            var item = new IntVec3(center.x, 0, center.z)
            {
                x = x2 + i
            };
            for (var j = -(int)radius; j < radius; j++)
            {
                item.z = z + j;
                if (!z.Inbounds(0, x) && !x2.Inbounds(0, x))
                {
                    continue;
                }

                var num = (x2 - item.x) * (x2 - item.x);
                var num2 = (z - item.z) * (z - item.z);
                var num3 = Math.Pow(num2 + num, 0.5);
                if (num3 <= radius)
                {
                    list.Add(item);
                }
            }
        }

        return list;
    }
}