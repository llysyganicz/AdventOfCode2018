module Program
  open System

  [<EntryPoint>]
  let main argv =
    printfn " Part 1: %d" (Part1.getResult())
    printfn " Part 2: %s" (Part2.getResult())
    0
