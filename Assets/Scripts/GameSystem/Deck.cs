using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public Deck()
    {
        races = new List<Race>() {
            new Amazones(), new Dwarf(), new Elven(),
            new Orcs(), new Giants(), new Humans(),
            new Skaven(), new Amazones(), new Dwarf(),
            new Elven(), new Orcs(), new Giants(), new Humans(),
            new Skaven(), new Amazones(), new Dwarf(), new Elven(),
            new Orcs(), new Giants(), new Humans(), new Skaven()
            };
        powers = new List<Power>() {
             new Alchemists(), new Armed(), new FromCave(),
             new FromForest(), new FromHils(), new FromSwamp(),
             new Merchant(), new Alchemists(), new Armed(), new FromCave(),
             new FromForest(), new FromHils(), new FromSwamp(), new Merchant(),
             new Alchemists(), new Armed(), new FromCave(), new FromForest(), new FromHils(),
             new FromSwamp(), new Merchant()
            };

        races.Shuffle();
        powers.Shuffle();
        racesShortList = new List<Race>();
        powersShortList = new List<Power>();

        for (int i = 0; i < 6; i++)
        {
            racesShortList.Add(races[races.Count - 1]);
            powersShortList.Add(powers[powers.Count - 1]);
            races.RemoveAt(races.Count - 1);
            powers.RemoveAt(powers.Count - 1);
        }

    }

    public List<Race> races { get; set; }
    public List<Power> powers { get; set; }

    public List<Race> racesShortList { get; set; }
    public List<Power> powersShortList { get; set; }

    public void PickRaceAndPower(int pos, out Race race, out Power power)
    {
        race = racesShortList[pos];
        power = powersShortList[pos];

        for (int i = 0; i < pos; i++)
        {
            racesShortList[i].victoryPointAtPick += 1;
        }

        racesShortList.RemoveAt(pos);
        powersShortList.RemoveAt(pos);

        if (races.Count == 0)
        {
            races = new List<Race>() {
            new Amazones(), new Dwarf(), new Elven(),
            new Orcs(), new Giants(), new Humans(),
            new Skaven(), new Amazones(), new Dwarf(),
            new Elven(), new Orcs(), new Giants(), new Humans(),
            new Skaven(), new Amazones(), new Dwarf(), new Elven(),
            new Orcs(), new Giants(), new Humans(), new Skaven()
            };
            powers = new List<Power>() {
             new Alchemists(), new Armed(), new FromCave(),
             new FromForest(), new FromHils(), new FromSwamp(),
             new Merchant(), new Alchemists(), new Armed(), new FromCave(),
             new FromForest(), new FromHils(), new FromSwamp(), new Merchant(),
             new Alchemists(), new Armed(), new FromCave(), new FromForest(), new FromHils(),
             new FromSwamp(), new Merchant()
            };

        }
        races.Shuffle();
        powers.Shuffle();


        racesShortList.Add(races[races.Count - 1]);
        powersShortList.Add(powers[powers.Count - 1]);


        races.RemoveAt(races.Count - 1);
        powers.RemoveAt(powers.Count - 1);

    }


}

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}

