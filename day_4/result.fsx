open System.IO
open System.Text.RegularExpressions

let file = "./input"
let lines = File.ReadAllLines(file)

let mutable res = 0

for i in 0..lines.Length-1 do
    let line = lines.[i]
    for j in 0..line.Length-1 do
        if j < line.Length-3 && line.[j] = 'X' && line.[j+1] = 'M' && line.[j+2] = 'A' && line.[j+3] = 'S' then
            res <- res + 1
        if j < line.Length-3 && line.[j] = 'S' && line.[j+1] = 'A' && line.[j+2] = 'M' && line.[j+3] = 'X' then
            res <- res + 1
        if i < lines.Length-3 && lines.[i].[j] = 'X' && lines.[i+1].[j] = 'M' && lines.[i+2].[j] = 'A' && lines.[i+3].[j] = 'S' then
            res <- res + 1
        if i < lines.Length-3 && lines.[i].[j] = 'S' && lines.[i+1].[j] = 'A' && lines.[i+2].[j] = 'M' && lines.[i+3].[j] = 'X' then
            res <- res + 1
        if i < lines.Length-3 && j < line.Length-3 && lines.[i].[j] = 'X' && lines.[i+1].[j+1] = 'M' && lines.[i+2].[j+2] = 'A' && lines.[i+3].[j+3] = 'S' then
            res <- res + 1
        if i < lines.Length-3 && j < line.Length-3 && lines.[i].[j] = 'S' && lines.[i+1].[j+1] = 'A' && lines.[i+2].[j+2] = 'M' && lines.[i+3].[j+3] = 'X' then
            res <- res + 1
        if i < lines.Length-3 && j >= 3 && lines.[i].[j] = 'X' && lines.[i+1].[j-1] = 'M' && lines.[i+2].[j-2] = 'A' && lines.[i+3].[j-3] = 'S' then
            res <- res + 1
        if i < lines.Length-3 && j >= 3 && lines.[i].[j] = 'S' && lines.[i+1].[j-1] = 'A' && lines.[i+2].[j-2] = 'M' && lines.[i+3].[j-3] = 'X' then
            res <- res + 1

printfn "Part one"
printfn "Result: %d\n" res
