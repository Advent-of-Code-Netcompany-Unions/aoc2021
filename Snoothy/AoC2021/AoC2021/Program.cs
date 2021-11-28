using AoC2021;
using AoC2021.Challenges;

Console.WriteLine("Advent of Code 2021");

var challenges = new List<AoCTask>();

challenges.Add(new AoCTask01("AoC01"));

challenges.ForEach(challenge => challenge.RunChallenge());