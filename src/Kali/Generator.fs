module Kali.Generator

open Weaver

let pickOne (items: 'a list) =
    items
    |> List.randomChoice
    
let pickSome count (items: 'a list) =
    items
    |> List.randomChoices count

let randomVox kind =    
    match kind with
    | Intro | Outro ->
        pickOne [
            Whispering
            Kawaii
            Vox.Ethereal
            Shouto
        ]
    | Build ->
        pickOne [
            Shouto
            Growling
            Barking
            VisualKey
        ]
    | Main | Drop ->
        pickOne [
            Growling
            Screaming
            Barking
            Enka
            Aegyo
        ]     
    
let randomTextures count kind =
    let common = [
        Bitcrush
        Stutter
        DataCorrupt
    ]
    let ethereal = [
        Ethereal
        FutureGlimpses
        PastGlimpses
        PhaseTear
    ]
    let heavy = [
        BufferDrag
        GrainBurst
        PulseWave
        SyntaxError
    ]
    let pool =
        match kind with
        | Intro | Outro ->
            common @ ethereal
        | Build ->
            common @ heavy
        | Main | Drop ->
            heavy @ ethereal @ [DataCorrupt]
    pickSome count pool
    |> List.distinct
    
let randomLanguage () =
    pickOne [
        Some Japanese
        Some Sindarin
        Some Dutch
        Some English
        Some Quenya
        Some Finnish
        None
    ]

let randomEnergy kind =
    match kind with
    | Intro | Outro ->
        pickOne [Low; Medium]
    | Build ->
        pickOne [Medium; High]
    | Main | Drop ->
        pickOne [High; Extreme]

let randomDirection kind =
    match kind with
    | Intro ->
        "atmospheric and creeping"
    | Build ->
        "building tension"
    | Main ->
        "full emotional weight"
    | Drop ->
        "explosive and glitchy"
    | Outro ->
        "fading into the void"
    
let randomLines kind =
    match kind with
    | Intro | Outro ->
        (4, 8)
    | Build | Drop ->
        (4, 8)
    | Main ->
        (8, 12)
    
let generateSection name kind theme =
    { Name = name
      Kind = kind
      Vox = randomVox kind
      Language = randomLanguage ()
      Energy = randomEnergy kind
      Textures = randomTextures 2 kind
      Theme = theme
      Notes = []
      Lines = randomLines kind
      Direction = randomDirection kind }
