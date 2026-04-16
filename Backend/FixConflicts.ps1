Add-Type -TypeDefinition @"
using System;
using System.IO;
using System.Collections.Generic;

public class GitFixer
{
    public static void Fix(string dir)
    {
        var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
        foreach(var file in files) {
            if(!file.EndsWith(".cs") && !file.EndsWith(".csproj") && !file.EndsWith(".yml")) continue;
            var content = File.ReadAllText(file);
            if(!content.Contains("<<<<<<< HEAD")) continue;
            
            var lines = File.ReadAllLines(file);
            var newLines = new List<string>();
            string state = "NORMAL";
            foreach(var line in lines) {
                if(line.StartsWith("<<<<<<< HEAD")) { state = "IN_HEAD"; continue; }
                if(line.StartsWith("=======")) { state = "IN_REMOTE"; continue; }
                if(line.StartsWith(">>>>>>>")) { state = "NORMAL"; continue; }
                
                if(state == "NORMAL" || state == "IN_HEAD") newLines.Add(line);
            }
            File.WriteAllLines(file, newLines);
            Console.WriteLine("Cleaned " + file);
        }
    }
}
"@
[GitFixer]::Fix("c:\Users\dabba\OneDrive\Desktop\PetShop\Backend")
