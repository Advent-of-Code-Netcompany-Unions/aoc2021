using AoC2021;
using AoC2021.Challenges;

Console.WriteLine("Advent of Code 2021");

var challenges = new List<AoCTask>();

challenges.Add(new AoCTask01("AoC01"));
challenges.Add(new AoCTask02("AoC02"));
challenges.Add(new AoCTask03("AoC03"));
challenges.Add(new AoCTask04("AoC04"));
challenges.Add(new AoCTask05("AoC05"));

challenges.ForEach(challenge => challenge.RunChallenge());