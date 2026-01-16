module Kali.Weaver

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
    Language: Language
    Energy: Energy
    Textures: Texture list
    Theme: string
    Notes: string list 
}

let weave () =
    failwith "Not implemented"