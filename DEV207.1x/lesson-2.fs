module Introduction.Lesson2
open System

let out age =
    match age with
    | age when age < 13 -> "this person is a child"
    | age when age < 20 -> "this person is is a teenager"
    | age -> "this person is no longer a teenager"
    
let rec stop() =
    printf "Continue [Y/N]: "
    match Console.ReadLine().ToUpper() with
    | "Y" -> false
    | "N" -> true
    | _ -> stop()
    
[<EntryPoint>] 
let rec main argv =
    printf "Enter your name: "
    let name = Console.ReadLine()
    printf "Enter your age: "
    let age = Console.ReadLine()
    match Int32.TryParse(age) with
    | (false, _) -> printfn "The given age is not an age."
    | (true, age) when age < 0 -> printfn "The given age is incorrect."
    | (true, age) -> printfn "%s: %s." name (out age)
    if stop() then 0 else main Array.empty
