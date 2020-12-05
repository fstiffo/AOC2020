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
        let row, col = rowBinPart &&& byte(127), colBinPart &&& byte(7)
        int(row) * 8 + int(col)
        ) |> Array.max
        

let secondHalf () =
    let input = File.ReadAllLines("inputs/D05.txt")
    let binaryPartions = input |> Array.map (fun l -> 
        let rowBinPart = l.[..6].Replace('B','1').Replace('F','0') 
        let colBinPart = l.[7..].Replace('R','1').Replace('L','0')
        System.Convert.ToByte(rowBinPart,2), System.Convert.ToByte(colBinPart,2)
        )
    let sortedIds = 
        binaryPartions
        |> Array.map (fun (rowBinPart, colBinPart) ->
                let row, col = rowBinPart &&& byte(127), colBinPart &&& byte(7)
                int(row), int(col))
        |> Array.filter (fun (row,_) -> row > 0 && row < 127) 
        |> Array.map (fun (row, col) -> row * 8 + col )
        |> Array.sort |> Array.indexed
    sortedIds 
        |> Array.find (fun (i, id) -> 
        let _, nextId = sortedIds.[i+1]
        nextId <> (id + 1)
        ) 
        |> snd |> ((+) 1)
