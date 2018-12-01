module Part1
  open System.IO
  
  let getData() =
    let lines = File.ReadLines("input.txt")
    lines |> Seq.map(fun x -> int x)

  let getFrequency() =
    getData() |> Seq.sum