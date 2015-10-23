module Introduction.Lesson3
open System

// Golden ratio
let phi = (1.0 + Math.Sqrt(5.0)) / 2.0

[<EntryPoint>] 
let main argv =
            printfn "Enter your numbers separated by newlines. To end input, enter a blank line."
            fun _ -> Console.ReadLine()
            |> Seq.initInfinite
            |> Seq.takeWhile ((<>) "") 
            |> Seq.map (fun x -> (x, x * phi))
            |> Seq.toList
            |> printfn "%A"
            0