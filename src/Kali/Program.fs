namespace Kali

open Weaver

module Program =
    let example = {
        Name = "Kali Weaver"
        Sections = [
            { defaultSection with
                Name = "boot sequence"
                Direction = Introductory
                Energy = Low }
            { defaultSection with
                Name = "system uplink"
                Direction = Connecting
                Energy = High }
            { defaultSection with
                Name = "core dump 1"
                Direction = Impact
                Energy = Extreme }
            { defaultSection with
                Name = "data surge"
                Direction = Surge
                Energy = High }
            { defaultSection with
                Name = "memory fragment"
                Direction = Reflective
                Energy = Medium }
            { defaultSection with
                Name = "overclock"
                Direction = Strain
                Energy = Low }
            { defaultSection with
                Name = "core dump 2"
                Direction = Collapse
                Energy = Extreme }
            { defaultSection with
                Name = "kernel panic"
                Energy = Low }
            { defaultSection with
                Name = "final echo"
                Direction = Outro
                Energy = High }                
        ]
    }

    let compileSection (s: Section) =
        printf $"%A{s}"

    let compileTrack (t: Track) =
        t.Sections
        |> List.iter compileSection

    [<EntryPoint>]
    let main argv =
        compileTrack example
        0