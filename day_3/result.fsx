open System.IO
open System.Text.RegularExpressions

let file = "./input"
let lines = File.ReadAllLines(file)

let reMul = new Regex(@"mul\([0-9]+\,[0-9]+\)")
let mutable res = 0

for line in lines do
    let matches = reMul.Matches(line)

    for m in matches do
        let parts = m.Value.Split(",")
        let a = int (parts.[0].Substring(4))
        let b = int (parts.[1].Substring(0, parts.[1].Length - 1))
        res <- res + a * b

printfn "Part one"
printfn "Result: %d\n" res
