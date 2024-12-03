open System.IO
open System.Text.RegularExpressions

let file = "./input"
let lines = File.ReadAllLines(file)

let reMul = new Regex(@"mul\([0-9]+\,[0-9]+\)")
let reDo = new Regex(@"do\(\)")
let reDont = new Regex(@"don't\(\)")

let reGeneral = new Regex(@"mul\([0-9]+\,[0-9]+\)|do\(\)|don't\(\)")

let mutable res = 0
let mutable isAuthorized = true

for line in lines do
    let matches = reGeneral.Matches(line)

    for m in matches do
        if (isAuthorized && reMul.IsMatch(m.Value)) then
            let parts = m.Value.Split(",")
            let a = int (parts.[0].Substring(4))
            let b = int (parts.[1].Substring(0, parts.[1].Length - 1))
            res <- res + a * b
        elif (reDo.IsMatch(m.Value)) then
            isAuthorized <- true
        elif (reDont.IsMatch(m.Value)) then
            isAuthorized <- false

printfn "Part two"
printfn "Result: %d\n" res
