open System.IO

let file = "./input"
let lines = File.ReadAllLines(file)

let mutable count = lines.Length

for line in lines do
    if (line.Length <> 0) then
        let parts = line.Split(" ")
        let mutable isIncreasing = -1
        let mutable i = 0
        let mutable isSafe = true
        while (i < parts.Length - 1 && isSafe) do
            if (isIncreasing = -1 && int parts[i] <= int parts[i+1]) then
                isIncreasing <- 1
            else if (isIncreasing = -1 && int parts[i] >= int parts[i+1]) then
                isIncreasing <- 0
            
            if (isIncreasing = 1 && int parts[i] >= int parts[i+1]) then
                count <- count - 1
                isSafe <- false
            else if (isIncreasing = 1 && (int parts[i+1] - int parts[i]) > 3) then
                count <- count - 1
                isSafe <- false
            
            if (isIncreasing = 0 && int parts[i] <= int parts[i+1]) then
                count <- count - 1
                isSafe <- false
            else if (isIncreasing = 0 && (int parts[i] - int parts[i+1]) > 3) then
                count <- count - 1
                isSafe <- false
            
            i <- i + 1

printfn "Part one"
printfn "Result: %d\n" count
