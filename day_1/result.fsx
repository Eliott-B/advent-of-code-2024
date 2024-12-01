open System.IO

let file = "./input"
let lines = File.ReadAllLines(file)

let firstColumn = ResizeArray<int>()
let secondColumn = ResizeArray<int>()

for line in lines do
    if (line.Length <> 0) then
        let parts = line.Split("   ")
        firstColumn.Add(int parts.[0])
        secondColumn.Add(int parts.[1])

printfn "Part one"
let mutable res = 0
let sortedFirstColumn = List.sort (List.ofSeq firstColumn)
let sortedSecondColumn = List.sort (List.ofSeq secondColumn)
for i in 0..sortedFirstColumn.Length-1 do
    res <- res + abs(sortedFirstColumn.[i] - sortedSecondColumn.[i])
printfn "Result: %d\n" res

printfn "Part two"
res <- 0
for i in 0..sortedFirstColumn.Length-1 do
    res <- res + sortedFirstColumn.[i] * (sortedSecondColumn |> List.filter (fun x -> x = sortedFirstColumn.[i]) |> List.length)
printfn "Result: %d" res
