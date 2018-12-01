module Program

  open Part1
  open Part2

  [<EntryPoint>]
  let main argv =
    printfn " Part 1: %d" (Part1.getResult())
    printfn " Part 2: %d" (Part2.getResult())
    0 
