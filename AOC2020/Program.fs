open System.IO
open D04


// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    printfn "Advent of Code\n   0xffff&2020\n"
    printfn "--- Day 4: Passport Processing ---\nYour puzzle answer was %d" (D04.firstHalf  ()) 

    0 // return an integer exit code