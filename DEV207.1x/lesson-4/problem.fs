open System
open System.IO

type Shot = { 
    angle : float;
    speed : float;
    distance : float;
    name : string 
}
    
let ParseShot (values : string array) = { 
    angle = Math.Atan(float(values.[1]) / float(values.[0]));
    speed = float(values.[2]); 
    distance = float(values.[3]); 
    name = values.[4] 
}

let ProcessFile path = File.ReadLines(path) |> Seq.map (fun line -> line.Split(',')) |> Seq.map ParseShot

let AngleOfReach shot = (shot, 0.5 * Math.Asin((9.81 * shot.distance) / (shot.speed * shot.speed)))

let Result (shot, angle) = 
    match angle with
    | angle when Double.IsNaN angle -> sprintf "%s: impossible to hit this shot" shot.name
    | _ when shot.angle = nan -> sprintf "%s: invalid angle for shot" shot.name
    | angle when abs(shot.angle - angle) < 0.00000001 -> sprintf "%s: hit" shot.name
    | _ -> sprintf "%s: miss (angle of %f required degrees; %f degrees given)" shot.name (angle * 180.0/Math.PI) (shot.angle * 180.0/Math.PI)

[<EntryPoint>]    
let main argv = 
    match argv.Length with
    | 0 -> printfn "usage: ./program file1 file2 ..."; 0
    | _ ->
        try
            Seq.ofArray argv
            |> Seq.map (ProcessFile >> Seq.map (AngleOfReach >> Result))
            |> Seq.concat
            |> Seq.iter (printfn "%s")
            0
        with
        | :? System.IO.FileNotFoundException ->
            printfn "error: file not found."
            -1
        | Failure msg ->
            printfn "error: %s" msg
            -1