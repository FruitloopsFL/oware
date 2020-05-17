module Oware
    
type StartingPosition =
    | South
    | North
 
type board = {houses: int*int*int*int*int*int*int*int*int*int*int*int; score: int*int; turn: int}

let getSeeds n board =
    let (h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12) = board
    match n with
    | 1 -> h1| 2 -> h2 | 3 -> h3 | 4 -> h4 | 5 -> h5 | 6 -> h6 
    | 7 -> h7 | 8 -> h8 | 9 -> h9 | 10 -> h10 | 11 -> h11 | 12 -> h12 | _ -> failwith "Invalid number on board"
    
let gameState board = 
    let (playerN, playerS) = board.score 
    match (playerN = 24 && playerS = 24),(playerN > 24 && playerS < 24),(playerN < 24 && playerS > 24) with
    | (true, false, false) -> "Game ended in a draw"
    | (false, true, false) -> "South won"  
    | (false, false, true) -> "North won" 
    | _ ->
        match board.turn with
        | 1 -> "North's turn"
        | -1 -> "South's turn"
        | _ -> failwith "invalid"
 
let useHouse n board = 
    let x = board[n]
    match x with
    | _ -> 
        let rec MoveIt g board =
            match (g > 0) with
            | false -> board
            | true -> 
                let n = n + 1
                let board[n] = board[n] + 1
                MoveIt (g - 1) board
        MoveIt x board
    | 0 -> board


let start position = 
    let initial = {houses = (4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4); score = (0, 0); turn = -1}
    match position with
    | North -> {initial with turn = 1}
    | South -> {initial with turn = -1}

let score board = board.score
    

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
    
    
