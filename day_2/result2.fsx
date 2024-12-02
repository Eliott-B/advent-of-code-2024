open System.IO

let file = "./input"
let lines = File.ReadAllLines(file)

let mutable count = 0

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
                isSafe <- false
            else if (isIncreasing = 1 && (int parts[i+1] - int parts[i]) > 3) then
                isSafe <- false
            
            if (isIncreasing = 0 && int parts[i] <= int parts[i+1]) then
                isSafe <- false
            else if (isIncreasing = 0 && (int parts[i] - int parts[i+1]) > 3) then
                isSafe <- false
            
            i <- i + 1
        
        if (isSafe) then
            count <- count + 1
        else 
            i <- 0
            while (not isSafe && i < parts.Length) do
                let partsBis = parts |> Array.mapi (fun index x -> (index, x)) |> Array.filter (fun (index, _) -> index <> i) |> Array.map snd
                isSafe <- true
                isIncreasing <- -1
                let mutable j = 0
                while (j < partsBis.Length - 1 && isSafe) do
                    if (isIncreasing = -1 && int partsBis[j] <= int partsBis[j+1]) then
                        isIncreasing <- 1
                    else if (isIncreasing = -1 && int partsBis[j] >= int partsBis[j+1]) then
                        isIncreasing <- 0
                    
                    if (isIncreasing = 1 && int partsBis[j] >= int partsBis[j+1]) then
                        isSafe <- false
                    else if (isIncreasing = 1 && (int partsBis[j+1] - int partsBis[j]) > 3) then
                        isSafe <- false
                    
                    if (isIncreasing = 0 && int partsBis[j] <= int partsBis[j+1]) then
                        isSafe <- false
                    else if (isIncreasing = 0 && (int partsBis[j] - int partsBis[j+1]) > 3) then
                        isSafe <- false
                    
                    j <- j + 1
                
                i <- i + 1
            
            if (isSafe) then
                count <- count + 1


printfn "Part two"
printfn "Result: %d\n" count
