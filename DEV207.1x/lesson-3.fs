module Introduction.Lesson3
open System

// Golden ratio
let phi = (1.0 + Math.Sqrt(5.0)) / 2.0

[<EntryPoint>] 
let main argv =
            printf "Enter numbers separated by spaces: "
            Console.ReadLine().Split(' ')
            |> Seq.filter (Double.TryParse >> fst)
            |> Seq.map (float >> fun x -> x, x * phi)
            |> Seq.toList
            |> printfn "%A"
            0