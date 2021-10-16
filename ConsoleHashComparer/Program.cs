using System;

var comparedHash = args[0];
var hashType = args[1];
var currentDir = Environment.CurrentDirectory;

var results = HashComparer.HashComparer.Compare(comparedHash, currentDir, hashType);
    
foreach(var result in results)
    Console.WriteLine(result);