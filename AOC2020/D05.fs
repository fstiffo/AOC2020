module D05
open System.IO

let firstHalf () =
    let input = File.ReadAllLines("inputs/D05.txt")
    let binaryPartions = input |> Array.map (fun l -> 
        let rowBinPart = l.[..6].Replace('B','1').Replace('F','0') 
        let colBinPart = l.[7..].Replace('R','1').Replace('L','0')
        System.Convert.ToByte(rowBinPart,2), System.Convert.ToByte(colBinPart,2)
        )
    binaryPartions |> Array.map (fun (rowBinPart, colBinPart) ->
        let row, col = rowBinPart &&& byte(127), colBinPart &&& byte(7) // find row and column of the seat
        int(row) * 8 + int(col) // calculates seat ID
        ) |> Array.max
        

let secondHalf () =
    let input = File.ReadAllLines("inputs/D05.txt")
    let binaryPartions = input |> Array.map (fun l -> 
        let rowBinPart = l.[..6].Replace('B','1').Replace('F','0') 
        let colBinPart = l.[7..].Replace('R','1').Replace('L','0')
        System.Convert.ToByte(rowBinPart,2), System.Convert.ToByte(colBinPart,2)
        )
    let sortedIDs = 
        binaryPartions
        |> Array.map (fun (rowBinPart, colBinPart) ->
                let row, col = rowBinPart &&& byte(127), colBinPart &&& byte(7) // find row and column of the seat
                int(row), int(col))
        |> Array.filter (fun (row,_) -> row > 0 && row < 127) // removes very front and very back rows
        |> Array.map (fun (row, col) -> row * 8 + col ) // calculates seat ID
        |> Array.sort |> Array.indexed
    sortedIDs 
        |> Array.find (fun (i, id) -> 
        let _, nextID = sortedIDs.[i + 1]
        nextID <> (id + 1)
        ) 
        |> snd |> ((+) 1)
