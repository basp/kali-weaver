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
}

let weave () =
    failwith "Not implemented"