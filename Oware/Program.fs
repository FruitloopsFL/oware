module Oware

type StartingPosition =
    | South
    | North

let getSeeds n board = 
    board[n]

let useHouse n board = 
    let x = getSeeds n board
    board[n] = board[n] - x
    

let start position = failwith "Not implemented"

let score board = failwith "Not implemented"

let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
