type MyRecord =
    { IP : string
      MAC : string
      FriendlyName : string
      ID : int }

let IsMatchByName record name =
    match record with
    | { FriendlyName = nameFound; ID = id; IP = ip } when nameFound = name -> Some((id,ip))
    | _ -> None  

let checkmatch input =
    match input with
    | Some(x, y) -> printfn "%A" x  
    | None -> printfn "%A" "Sorry no match"  

[<EntryPoint>] 
let main argv = 
        checkmatch (IsMatchByName {IP ="127.0.0.1"; MAC ="FF:FF:FF:FF:FF:FF"; FriendlyName = "Home";ID = 229229} "Home")
        0
