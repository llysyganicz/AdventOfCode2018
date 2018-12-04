module Part1
  open System
  open System.Drawing
  open System.IO

  type Rect = { Id: int; Rectangle: Rectangle }

  let parseLine (line: string) =
    let splittedLine = line.Split([| "@"; ","; ":"; "x" |], StringSplitOptions.RemoveEmptyEntries)
    new Rectangle(int(splittedLine.[1]), int(splittedLine.[2]), int(splittedLine.[3]), int(splittedLine.[4]))

  let rectangles = File.ReadLines "input.txt" |> Seq.mapi (fun i line -> { Id = i + 1; Rectangle = parseLine line }) |> Seq.toList

  let getIntersection r1 r2 intersect =
    let rect = Rectangle.Intersect(r1.Rectangle, r2.Rectangle)
    match rect.IsEmpty with
    | true -> intersect
    | false ->
      let result = List.allPairs [rect.Left + 1..rect.Right] [rect.Top + 1..rect.Bottom]
      Set.union intersect (Set.ofList result)

  let rec getIntersectionsForRectangle r remainingRectangles intersect =
    match remainingRectangles with
    | h::t -> getIntersectionsForRectangle r t (getIntersection r h intersect)
    | [] -> intersect
  
  let rec getAllIntersections rects intersection =
    match rects with
    | h::t -> getAllIntersections t (getIntersectionsForRectangle h rectangles intersection )
    | [] -> intersection
  
  let getResult() =
   getAllIntersections rectangles Set.empty |> Set.count
