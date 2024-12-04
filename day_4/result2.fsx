open System.IO
open System.Text.RegularExpressions

let file = "./input"
let lines = File.ReadAllLines(file)

let mutable res = 0

for i in 1..lines.Length-2 do
    let line = lines.[i]
    for j in 1..line.Length-2 do
        let first = string lines.[i-1].[j-1] + string lines.[i].[j] + string lines.[i+1].[j+1]
        let second = string lines.[i-1].[j+1] + string lines.[i].[j] + string lines.[i+1].[j-1]
        if (first = "MAS" || first = "SAM") && (second = "MAS" || second = "SAM") then
            res <- res + 1

printfn "Part two"
printfn "Result: %d\n" res
