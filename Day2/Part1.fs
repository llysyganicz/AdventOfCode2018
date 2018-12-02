module Part1
  open System.IO  
  
  let data = File.ReadLines("input.txt") |> Seq.toList

  let getLettersCount (text: string) = 
    let counts = text.ToCharArray() |> Seq.countBy id |> Seq.map (fun (key, count) -> count) |> Seq.distinct
    match counts with 
    | x when Seq.contains 3 x && Seq.contains 2 x -> 5
    | x when Seq.contains 3 x -> 3
    | x when Seq.contains 2 x -> 2
    | _ -> 0
    

  let getResult() =
    let counts = data |> List.map getLettersCount |> List.filter (fun x -> x <> 0)
    let twos = (counts |> List.filter (fun x -> x = 2)).Length
    let threes = (counts |> List.filter (fun x -> x = 3)).Length
    let fives = (counts |> List.filter (fun x -> x = 5)).Length
    (twos + fives) * (threes + fives)