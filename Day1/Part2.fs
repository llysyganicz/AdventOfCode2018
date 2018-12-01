module Part2
  open System.IO

  let startSequence = File.ReadLines("input.txt") |> Seq.map(fun x -> int x) |> Seq.toList

  let rec iterate frequencies i oldValue =
    let index = i % startSequence.Length
    let value = oldValue + startSequence.[index]
    if Set.contains value frequencies then ([value], i)
    else iterate (frequencies |> Set.add(value)) (i + 1) value

  let getResult() =
    match iterate (Set.empty.Add(0)) 0 0 with
    | ([x], i) when i > 0 -> x
    | _ -> 0