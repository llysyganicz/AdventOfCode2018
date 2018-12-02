module Part2
  open System
  open System.IO  
      
  let data = File.ReadLines("input.txt") |> Seq.toList

  let findDiffIndex (string1: string) (string2: string) =
   let mutable index = 0
   for n = 0 to string1.Length - 1 do
     if string2.[n] <> string1.[n] then index <- n
   index
       
  let compare (string1: string) (string2: string) index =
    let mutable diff = 0
    for n = 0 to string1.Length - 1 do
      if string2.[n] <> string1.[n] then diff <- diff + 1
    if diff = 1 then (true, index)
    else (false, 0)
  
  let isSimillar (text: string) =
    let result = data |> List.mapi (fun i e-> compare text e i)
    let found = result |> List.tryFind (fun x -> fst x = true)
    match found with 
    | Some x -> (text, data.[snd x])
    | None -> ("", "")
  
  let getResult() =
    let result = data |> List.map (fun x -> isSimillar x)
    match result |> List.tryFind (fun x -> fst x <> "") with 
    | Some x -> 
      let index = findDiffIndex (fst x) (snd x)
      let s = fst x
      s.ToCharArray() |> Seq.where (fun c -> c <> s.[index]) |> String.Concat
    | None -> ""