open System.IO
open System.Collections.Generic

let file = "./input"
let lines = File.ReadAllLines(file)

let rules = Dictionary<int, List<int>>()
let mutable isFillingRules = true
let ok = List<int>()

for line in lines do
    if (line.Length<>0 && isFillingRules) then
        let parts = line.Split("|")
        let key = int parts.[0]
        let value = int (parts.[1].Trim())
        if (not (rules.ContainsKey(key))) then
            rules.Add(key, List<int>())
        rules.[key].Add(value)

    if (line.Length = 0) then
        isFillingRules <- not isFillingRules

    if (line.Length <> 0 && not isFillingRules) then
        let parts = line.Split(',')
        let element = List<int>()
        let mutable isOk = true
        let mutable middleElt = 0
        for i in 0..parts.Length-1 do
            let elt = int parts.[i]
            for k in element do
                if (rules.ContainsKey(elt)) then
                    for j in rules.[elt] do
                        if (j = k) then
                            isOk <- false
            element.Add(elt)
            
            if (parts.Length % 2 = 0) then
                if (i+1 = parts.Length/2) then
                    middleElt <- elt
            else
                if (i+1 = (parts.Length+1)/2) then
                    middleElt <- elt
        if (isOk) then
            ok.Add(middleElt)

let mutable res = 0
for i in ok do
    res <- res + i

printfn "Part one"
printfn "Result: %d\n" res
