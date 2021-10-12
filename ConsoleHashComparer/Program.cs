using System;

var currentDir = Environment.CurrentDirectory;
var path = Path.Combine(currentDir, "testFiles");

var results = HashComparer.HashComparer.Compare(
    "11EAAC10092C1DCBA4EB52D33B7F92CAD6B32B40803805054BF321F4C22B3AA1",
   // @"C:\Users\coche\source\repos\HashComparer\HashComparerTests\bin\Debug\net6.0\testFiles",
   path,
    "sha256");
foreach(var result in results)
    Console.WriteLine(result);