module Program

  open System
  open Part1

  [<EntryPoint>]
  let main argv =
    printfn "%d" (Part1.getFrequency())
    0 
