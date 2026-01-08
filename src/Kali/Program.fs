open System.Globalization

type Language =
    | Dutch
    | English
    | Quenya
    | Sindarin

type SectionType =
    | Intro
    | Build
    | Main
    | Drop
    | Outro
    
type EnergyLevel =
    | Low
    | Medium
    | High
    | Extreme

type VocalStyle =
    | None
    | SoftFemale
    | AggressiveFemale
    | Choir
    | Screaming
    | Grunting
    | Barking
    | Growling
    | Whispering

type GlitchEffect =
    | Bitcrush
    | Stutter
    | TimeSlip
    | BufferDrag
    | DataCorrupt
    | PacketLoss
    | PhaseTear
    | GrainBurst
    | HardClip
    | SoftClip
    | ReverseShard
    | PitchWarp
    | FrameDrop
    | StaticBloom
    
type Section = {
    Name: string
    Kind: SectionType
    Energy: EnergyLevel
    Vocals: VocalStyle
    Language: Language option
    Tags: string list
    Variations: string list
    Glitches: GlitchEffect list
}


type Track = {
    Title: string
    GlobalTags: string list
    Constraints: string list
    Sections: Section list
}

type PromptFragment = string

module Rng =
    let private rng = System.Random()

    let pick (items: 'a list) =
        let i = rng.Next(items.Length)
        items[i]

    let chance p =
        rng.NextDouble() < p

module EnergyText =
    let low = [
        "subtle, restrained, atmospheric"
        "soft pulses in the dark"
        "a quiet tension under the surface"
    ]

    let medium = [
        "driving, tense, rhythmic"
        "pressure rising under the skin"
        "a heartbeat pushing forward"
    ]

    let high = [
        "intense, powerful, high-impact"
        "surging energy tearing through"
        "a force you can’t contain"
    ]

    let extreme = [
        "relentless, punishing, maximalist"
        "a violent surge of raw force"
        "total overload, no restraint"
    ]

    let describe = function
        | Low -> Rng.pick low
        | Medium -> Rng.pick medium
        | High -> Rng.pick high
        | Extreme -> Rng.pick extreme

module Vocals =
    let aggressiveSindarin = [
        "feral, razor-edged Sindarin screams"
        "wild, elven war‑cries in broken Sindarin"
        "raw female vocals twisting through Sindarin syllables"
    ]

    let softDutch = [
        "zachte, fluisterende Nederlandse lijnen"
        "breekbare Nederlandse melodieën"
        "intiem gezongen woorden in het Nederlands"
    ]

    let whisperSindarin = [
        "breath‑thin Sindarin fragments"
        "fluisterende elvenschaduwen"
        "zachte, onheilspellende Sindarin klanken"
    ]

    let describe vocal language =
        match vocal, language with
        | AggressiveFemale, Some Sindarin -> Rng.pick aggressiveSindarin
        | SoftFemale, Some Dutch -> Rng.pick softDutch
        | Whispering, Some Sindarin -> Rng.pick whisperSindarin
        | _ -> "instrumental focus"

module Generator =
    let describeEnergy = function
        | Low -> "subtle, restrained, atmospheric"
        | Medium -> "driving, tense, rhythmic"
        | High -> "intense, powerful, high-impact"
        | Extreme -> "relentless, punishing, maximalist"

    let vocalPhrase vocal language =
        match vocal, language with
        | AggressiveFemale, Some Sindarin ->
            "feral, elven war-chant in Sindarin, screamed female vocals"
        | SoftFemale, Some Dutch ->
            "intimate Dutch female vocals"
        | Choir, Some Quenya ->
            "ethereal Quenya choir"
        | None, _ -> "instrumental focus"
        | _ -> "emotional, expressive vocals"

module Variation =
    let glitchExtras = [
        "digital stutters tearing through the beat"
        "fragmented noise bursts"
        "bit‑crushed echoes spiraling outward"
    ]

    let maybeAddGlitch baseText =
        if Rng.chance 0.3 then
            baseText + ", " + Rng.pick glitchExtras
        else
            baseText

module GlitchText =
    let describe = function
        | Bitcrush -> "bit‑crushed fragments"
        | Stutter -> "rapid glitch stutters"
        | TimeSlip -> "time‑slipped echoes"
        | BufferDrag -> "dragged buffer smears"
        | DataCorrupt -> "corrupted digital bursts"
        | PacketLoss -> "packet‑loss dropouts"
        | PhaseTear -> "phase‑torn transients"
        | GrainBurst -> "granular noise bursts"
        | HardClip -> "hard‑clipped distortion"
        | SoftClip -> "soft‑clipped saturation"
        | ReverseShard -> "reverse‑shard slices"
        | PitchWarp -> "pitch‑warped artifacts"
        | FrameDrop -> "frame‑dropped pulses"
        | StaticBloom -> "static blooms"

module Compiler =    
    let describeGlitches glitches =
        glitches
        |> List.map GlitchText.describe
        |> String.concat ", "

    let compileSection (s: Section) =
        let energy = EnergyText.describe s.Energy
        let vocals = Vocals.describe s.Vocals s.Language
        let tags = String.concat ", " s.Tags
        let glitchText =
            if List.isEmpty s.Glitches
            then ""
            else ", " + describeGlitches s.Glitches
        let baseText =
            $"{s.Name}: {energy}, {vocals}, {tags}"

        Variation.maybeAddGlitch baseText
    
    let compileTrack (t: Track) =
        let title = $"Title: {t.Title}"
        let tags = "Style: " + (String.concat ", " t.GlobalTags)
        let constraints = "Constraints: " + (String.concat "; " t.Constraints)
        let sections =
            t.Sections
            |> List.map compileSection
            |> String.concat " | "

        $"{title}. {tags}. {constraints}. Sections: {sections}."

let myTrack =
    {
        Title = "Glitch Ritual Overdrive"
        GlobalTags = [
            "glitch-techno"; "DnB"; "raw guitars"; "distorted bass";
            "female aggressive vocals"; "ritual energy"
        ]
        Constraints = [
            "no chanting intro"
            "vocals start after the first build"
        ]
        Sections = [
            {
                Name = "Cold Start"
                Glitches = [Bitcrush; Stutter]
                Kind = Intro
                Energy = Medium
                Vocals = Grunting
                Language = Some Sindarin
                Tags = ["mechanical ambience"; "distant sub"; "no drums"]
                Variations = []
            }
            {
                Name = "First Surge"
                Glitches = [Bitcrush; TimeSlip; Stutter]
                Kind = Build
                Energy = Medium
                Vocals = Grunting
                Language = Some Quenya
                Tags = ["syncopated hats"; "rising noise"; "tension"]
                Variations = ["add glitch stutters"; "filter sweep"]
            }
            {
                Name = "Main Assault"
                Glitches = [FrameDrop; DataCorrupt; PhaseTear]
                Kind = Main
                Energy = Extreme
                Vocals = Screaming
                Language = Some Sindarin
                Tags = ["4x4 kick"; "screamed chorus"; "raw guitars"; "bass growl"]
                Variations = ["double-time drums"; "vocal call-and-response"]
            }
            {           
                Name = "First Drop"
                Kind = Drop
                Glitches = [Bitcrush; Stutter]
                Energy = High
                Vocals = AggressiveFemale
                Language = Some Dutch
                Tags = ["4x4 kick"; "screamed chorus"; "raw guitars"; "bass growl"]
                Variations = ["double-time drums"; "vocal call-and-response"]
            }
            {           
                Name = "First Build"
                Glitches = [FrameDrop; DataCorrupt ]
                Kind = Build
                Energy = High
                Vocals = AggressiveFemale
                Language = Some Sindarin
                Tags = ["4x4 kick"; "screamed chorus"; "raw guitars"; "bass growl"]
                Variations = ["double-time drums"; "vocal call-and-response"]
            }
            {           
                Name = "Second Drop"
                Glitches = [Bitcrush; Stutter; DataCorrupt]
                Kind = Drop
                Energy = Medium
                Vocals = Grunting
                Language = Some Dutch
                Tags = ["4x4 kick"; "screamed chorus"; "raw guitars"; "bass growl"]
                Variations = ["double-time drums"; "vocal call-and-response"]
            }
            {           
                Name = "Second Build"
                Glitches = [FrameDrop; DataCorrupt]
                Kind = Build
                Energy = High
                Vocals = AggressiveFemale
                Language = Some Quenya
                Tags = ["4x4 kick"; "screamed chorus"; "raw guitars"; "bass growl"]
                Variations = ["double-time drums"; "vocal call-and-response"]
            }
            {
                Name = "Big Build"
                Glitches = [FrameDrop; DataCorrupt]
                Kind = Build
                Energy = Extreme
                Vocals = Growling
                Language = Some Quenya
                Tags = ["syncopated hats"; "rising noise"; "tension"]
                Variations = ["add glitch stutters"; "filter sweep"]
            }
            {
                Name = "Big Drop"
                Glitches = [Bitcrush; Stutter]
                Kind = Drop
                Energy = Medium
                Vocals = AggressiveFemale
                Language = Some Sindarin
                Tags = ["4x4 kick"; "screamed chorus"; "raw guitars"; "bass growl"]
                Variations = ["double-time drums"; "vocal call-and-response"]                
            }
            {           
                Name = "Outro"
                Glitches = [FrameDrop; DataCorrupt]
                Kind = Outro
                Energy = Extreme
                Vocals = SoftFemale
                Language = Some Sindarin
                Tags = ["4x4 kick"; "screamed chorus"; "raw guitars"; "bass growl"]
                Variations = ["double-time drums"; "vocal call-and-response"]
            }
        ]
    }

let prompt = Compiler.compileTrack myTrack
printfn $"{prompt}"