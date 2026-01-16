module Kali.Weaver

open System

type Language =
    | Japanese
    | Sindarin
    | Dutch

type Vox =
    | Growling
    | Whispering
    | Screaming
    | Barking
    | Grunting
    | Cute
    | Kawaii
    | Aegyo
    | VisualKey
    | Shouto
    | Enka   

type Energy =
    | Low
    | Medium
    | High
    | Extreme
    
type Texture =
    | Bitcrush
    | Stutter
    | Crackle
    | ChipMelody
    | PulseWave
    | TimeSlip
    | PitchShift
    | DataCorrupt
    | SyntaxError
    | FutureGlimpses
    | PastGlimpses
    | Ethereal
    | BufferDrag
    | PulseWeave
    | PhaseTear
    | GrainBurst

type SectionKind =
    | Intro
    | Build
    | Main
    | Drop
    | Outro

type Section = {
    Name: string
    Kind: SectionKind
    Vox: Vox
    Language: Language option
    Energy: Energy
    Textures: Texture list
    Theme: string
    Notes: string list
    Lines: int * int
    Direction: string
}

type Track = {
    Title: string
    Style: string list
    Sections: Section list
}

module private Helpers =
    let formatVox (vox: Vox) (lang: Language option) =
        match lang with
        | Some l -> $"{vox}, {l}"
        | None -> $"{vox}"

    let formatTextures (textures: Texture list) (notes: string list) =
        let all = (textures |> List.map (fun t -> $"{t}")) @ notes
        all |> String.concat ", "
            
let compileSection (s: Section) =
        let (min, max) = s.Lines
        let voxStr = Helpers.formatVox s.Vox s.Language
        let texStr = Helpers.formatTextures s.Textures s.Notes
        $"""[{s.Name.ToUpper()}]
Vox: {voxStr}
Energy: {s.Energy}
Texture: {texStr}
Theme: {s.Theme}
Lines: {min}-{max}
Direction: {s.Direction}"""
            
let weave (track: Track) =
    let header = $"# {track.Title.ToUpper()}"
    let sections =
        track.Sections
        |> List.map compileSection
        |> String.concat Environment.NewLine
    $"{header}{Environment.NewLine}{sections}"
            
let weaveOld (sections: Section list) =
    sections
    |> List.map compileSection
    |> String.concat Environment.NewLine
