module Introduction.Lesson1
open System

let volume r h = Math.PI * Math.Pow(r, 2.0) * h

[<EntryPoint>] 
let main argv = 
    let r = Console.ReadLine()
    let h = Console.ReadLine()
    let r = float r
    let h = float h
    let vol = volume r h
    printfn "%f" vol
    0
