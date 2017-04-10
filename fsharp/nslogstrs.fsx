#r "r2pipe.dll"
#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"

open System
open System.Globalization
open System.IO
open r2pipe
open FSharp.Data
open FSharp.Data.JsonExtensions

[<EntryPoint>]
let main argv =
    let r2p = new RlangPipe()

    (r2p.RunCommand "is ~NSLog")
      .Split [|' '; '\n'; '\r'|] 
      |> Array.toList
      |> List.filter ( fun(a) -> a.Contains("vaddr=") )
      |> List.map ( fun(a) -> 
          (JsonValue.Parse ( r2p.RunCommand("pdj 1 @" + a.Replace("vaddr=","")) )).[0]
        )
      |> List.filter ( fun(a) -> a.TryGetProperty("xrefs") <> None )
      |> List.map ( fun(a) -> 
          [ for xref in a?xrefs -> 
               (r2p.RunCommand("pd -10 @" + xref?addr.AsString()))
                .Split [|' '; '\n'; '\r'|]
                |> Array.toList
                |> List.filter ( fun(a) -> a.Contains("str.cstr") || a.Contains("reloc") )
                |> List.map ( fun(a) -> r2p.RunCommand ("pd 1 @" + a) )
                |> List.map ( fun(a) -> printfn "%A" a)
          ]
        )
      |> ignore
    0 
