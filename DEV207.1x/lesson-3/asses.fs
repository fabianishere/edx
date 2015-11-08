open System
 
type ProductResult =
        | Product of string * float
        | Error of string * string
 
let golden_ratio = (1.0 + Math.Sqrt(5.0)) / 2.0
 
let to_tuple (s:string): ProductResult =
    let isParsed, value = Double.TryParse(s)
    if isParsed then Product(s, value * golden_ratio) else Error(s, "Is not a valid number")
 
[<EntryPoint>]
let main argv =
 
    Console.Write("Enter space delimited numbers: ")
    let input = Console.ReadLine()
 
    let tuples = input.Split(' ')
                    |> Seq.filter(not << String.IsNullOrWhiteSpace)  // fun s -> not String.IsNullOrWhiteSpace(s)
                    |> Seq.map( to_tuple )
                    |> Seq.toList // i would prefer to materialize seq to list here
 
    if tuples.IsEmpty then
        Console.WriteLine("No numbers to process")
    else
        for tuple in tuples do
            match tuple with
            | Product(value, product) -> printf "%s\t-> %f\n" value product
            | Error(strval, message) -> Console.Error.WriteLine(strval + "\t-> " + message)
 
    Console.WriteLine("Press any key to exit");
    Console.ReadKey()
    0 // return an integer exit code