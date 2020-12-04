module D04
open System.IO


type Passport = {
    mutable BirthYear: Option<int>
    mutable IssueYear: Option<int>
    mutable ExpirYear: Option<int>
    mutable Height: Option<string>
    mutable HairColor: Option<string>
    mutable EyeColor: Option<string>
    mutable PassportID: Option<string>
    mutable CountryID: Option<string>
}

let getInput filename =
    let input = File.ReadAllText(filename)
    let passportStrs = input.Split("\n\n")

    let getPassport (passport:string) =
        let mutable p = {
            BirthYear = None;
            IssueYear = None;
            ExpirYear = None;
            Height = None;
            HairColor = None;
            EyeColor = None;
            PassportID = None;
            CountryID = None;
            }
        passport.Split (' ', '\n') |> Array.iter (fun field ->
            let kv = field.Split(':')
            let kv' = (kv.[0], kv.[1])
            match kv' with
            | ("byr", v) -> p.BirthYear <- Some (int v)
            | ("iyr", v) -> p.IssueYear <- Some (int v)
            | ("eyr", v) -> p.ExpirYear <- Some (int v)
            | ("hgt", v) -> p.Height <- Some v
            | ("hcl", v) -> p.HairColor <- Some v
            | ("ecl", v) -> p.EyeColor <- Some v
            | ("pid", v) -> p.PassportID <- Some v
            | ("cid", v) -> p.CountryID <- Some v
            | _ -> ()
            )
        p

    passportStrs |> Array.map getPassport

let firstHalf () = 
    let passports = getInput "inputs/d04.txt"
    // printfn "%A" passports
    passports |> Array.filter (fun p -> 
        p.BirthYear.IsSome &&
        p.IssueYear.IsSome &&
        p.ExpirYear.IsSome &&
        p.Height.IsSome &&
        p.HairColor.IsSome &&
        p.EyeColor.IsSome &&
        p.PassportID.IsSome
    ) |> Array.length