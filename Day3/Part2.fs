module Part2
  open System
  open System.Drawing
  open System.IO
  open Part1
  open Part1

  type Rect = { Id: int; Rectangle: Rectangle }

  let parseLine (line: string) =
    let splittedLine = line.Split([| "@"; ","; ":"; "x" |], StringSplitOptions.RemoveEmptyEntries)
    new Rectangle(int(splittedLine.[1]) + 1, int(splittedLine.[2]) + 1, int(splittedLine.[3]) - 1, int(splittedLine.[4]) - 1)

  let rectangles = File.ReadLines "input.txt" |> Seq.mapi (fun i line -> { Id = i + 1; Rectangle = parseLine line }) |> Seq.toList

  let haveIntersection r1 r2 intersect =
    if r1.Id = r2.Id then intersect
    else
      let rect = Rectangle.Intersect(r1.Rectangle, r2.Rectangle)
      match rect.IsEmpty with
      | true -> intersect
      | false ->
        let result = List.allPairs [rect.Left..rect.Right] [rect.Top..rect.Bottom]
        not(result.IsEmpty) || intersect

  let rec isRectangleIntersect r rects result =
    match rects with
    | h::t -> isRectangleIntersect r t (haveIntersection r h result)
    | [] -> result

  let rec getIntersections rects result =
    match rects with
    | h::t -> 
      let intersect = isRectangleIntersect h rectangles false
      match intersect with
      | true -> getIntersections t ((h.Id, true)::result)
      | false -> getIntersections t ((h.Id, false)::result)
    | [] -> result

  let getResult() =
    let i = getIntersections rectangles List.empty
    let found = getIntersections rectangles List.empty |> List.tryFind (fun x -> snd x = false)
    match found with
    | Some x -> fst x
    | None -> 0