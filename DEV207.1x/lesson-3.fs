module Introduction.Lesson3
open System

// Golden ratio
let phi = (1.0 + Math.Sqrt(5.0)) / 2.0

// Utilities
let inline dup x = (x, x)
let inline map f (a, b) = (f a, f b)
let inline mapRight f (a, b) = (a, f b)

[<EntryPoint>] 
let main argv =
            printfn "Enter your numbers separated by newlines. To end input, enter a blank line."
            fun _ -> Console.ReadLine()
            |> Seq.initInfinite
            |> Seq.takeWhile ((<>) "") 
            |> Seq.map (dup >> map float >> mapRight ((*) phi))
            |> Seq.toList
            |> printfn "%A"
            0