module Kali.Weaver

open System

type Language =
    | Japanese
    | Sindarin
    | English
    | Finnish
    | Quenya
    | Dutch

type Vox =
    | Growling
    | Whispering
    | Screaming
    | Barking
    | Grunting
    | Shouting
    | Cute
    | Kawaii
    | Aegyo
    | VisualKey
    | Shouto
    | Enka
    | Ethereal

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

let formatSunoStyle (track: Track) =
    let textureStyles =
        track.Sections
        |> List.collect (fun s -> s.Textures)
        |> List.map (fun t -> $"{t}")
        |> List.distinct
    let allStyles = track.Style @ textureStyles
    allStyles
    |> String.concat ", "
    |> (fun s -> s.ToLower())
    
