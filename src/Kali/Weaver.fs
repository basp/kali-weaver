namespace Kali

// For each section, include:
// * 1 vocal identity
// * 1 language
// * 1 energy level
// * 1 emotional direction
// * 1-2 stylistic cues max

// Suno treats parentheses as non-singing metadata,
// so it won't try to vocalize them.
// You can use:
// * (no lyrics)
// * (instrumental only)
// * (vocalise)
// * (breath / texture only)

module Weaver =
    type Language =
        | English
        | Dutch
        | Finnish
        | Japanese
        | Quenya
        | Sindarin

    type Energy =
        | Low
        | Medium
        | High
        | Extreme

    type Voice =
        | Whispering | Soft
        | Cute | Light
        | Spoken | Narrative
        | Growling | Aggressive
        | Grunting | Raw
        | Processed | Digital
        | Neutral | Unemotional
        | Ethereal | Atmospheric

    type Vox = (Language * Voice list)

    type Texture =
        | Ethereal
        | PhaseTear
        | PulseWave
        | GrainBurst
        | DataCorrupt
        | Overdrive
        | GlitchPop
        | BufferDrag
        | PastGlimpses
        | Stutter
        | CircuitBend
        | FutureGlimpses
        | VaporTrail

    type Direction =
        | Introductory | Awakening
        | Connecting | Building
        | Impact | Burst
        | Surge | Acceleration
        | Reflective | Fragmented
        | Strain | Overload
        | Collapse | Failure
        | Outro | Dissipation
        | Static | Steady
        | Functional | Transitional
        | Ambient | Background
        | LoopLike | Mechanical
        | Emotionless | Analytical

    type Section =
        { Name: string
          Vox: Voice option
          Language: Language option
          Energy: Energy
          Direction: Direction
          Style: Texture list }
        
    type Track =
        { Name: string
          Sections: Section list }

    module Vox =
        // These keep the vocal presence light and atmospheric.
        let whispering = [
            "whispering"
            "soft spoken"
            "breathy tone"
            "hushed delivery"
        ]
        
        // Great for contract against glitchy or harsh production.
        let cute = [
            "cute tone"
            "light delivery"
            "soft melodic phrasing"
            "gentle brightness"
        ]
        
        // Useful for system logs, monologues, or diagnostic-style sections.
        let spoken = [
            "spoken cadence"
            "narrative tone"
            "speech-like delivery"
            "low-melody phrasing"
        ]
        
        // Pars extremely well with demoscene and bit-crush aesthetics.
        let growling = [
            "growling tone"
            "aggressive delivery"
            "rough vocal texture"
            "gritty resonance"
        ]
        
        // Raw energy class - great for core dumps and overclock sections.
        let grunting = [
            "grunting tone"
            "raw vocal attack"
            "percussive delivery"
            "low-melody growl"
        ]
        
        // Perfect for demoscene, cracktro, and system-themed tracks.
        let processed = [
            "digital-processed tone"
            "glitch-vocal texture"
            "synthetic resonance"
            "bit-crushed voice"
        ]
        
        // Great for intros, outros, or memory-fragmented sections.
        let ethereal = [
            "ethereal tone"
            "floating delivery"
            "soft atmospheric voice"
            "reverb-washed phrasing"
        ]
        
        // Usxeful for system messages, logs, or diagnostic sequences.
        let neutral = [
            "nutral tone"
            "emotionless delivery"
            "flat vocal presence"
            "analytical phrasing"
        ]
        
    module Directions =              
        let introductory = [
            "soft emergence"
            "gentle initialization"
            "rising awareness"
            "quiet activation"
        ]

        let connecting = [
            "rising tension"
            "signal alignment"
            "gathering momentum"
            "expanding motion"
        ]

        let impact = [
            "data overflow"
            "energy burst"
            "forceful release"
            "system rupture"
        ]

        let surge = [
            "glitch bloom"
            "voltage surge"
            "unstable expansion"
            "accelerated escalation"
        ]

        let reflective = [
            "fractured recall"
            "echoed memory"
            "broken reflection"
            "fading impressions"
        ]

        let strain = [
            "system strain"
            "pressure buildup"
            "overloaded circuits"
            "critical instability"
        ]
        
        let collapse = [
            "system collapse"
            "critical failure"
            "structural breakdown"
            "terminal instability"
        ]
        
        let outro = [
            "fading residue"
            "dissolving signal"
            "quiet decay"
            "soft shutdown"
        ]
        
        // These keep the music from rising or falling emotionally.
        let steady = [
            "steady state"
            "static texture"
            "continuous motion"
            "stable atmosphere"
        ]
        
        // This is perfect for bridges or mid-track resets.
        let functional = [
            "neutral transition"
            "functional movement"
            "simple connective flow"
            "unbiased progression"        
        ]
        
        // These keep the section from feeling empty while avoiding emotional cues.
        let ambient = [
            "ambient presence"
            "background texture"
            "soft neutral layer"
            "non-directive atmosphere"
        ]
        
        // Fits with demoscene aesthetic.
        let mechanical = [
            "mechanical repetition"
            "neutral loop motion"
            "algorithmic flow"
            "steady patterning"
        ]
        
        // Great for system-like or diagnostic movements.
        let analytical = [
            "emotionless signal"
            "analytical tone"
            "unbiased processing"
            "flat digital presence"
        ]

    module Energies1 =    
        let low = [        
            "slow tempo"
            "low-pulse rhythm"
            "drifting pace"
            "unhurried movement"
        ]

        let medium = [
            "steady tempo"
            "mid-pulse groove"
            "moderate rhythm drive"
            "balanced pacing"
        ]

        let high = [
            "fast bpm"
            "driving tempo"
            "accelerated pulse"
            "high-energy rythm"
        ]

        let extreme = [
            "hyper-tempo"
            "rapid-fire rhythm"
            "breakneck pulse"
            "extreme bpm energy"
        ]   

    module Energies2 =
        let low = [
            "low-slow drift"
            "soft-slow pulse"
            "quiet-slow motion"
            "low-tempo haze"
        ]
        
        let medium = [
            "mid-steady flow"
            "medium-steady pulse"
            "balanced-tempo motion"
            "steady-mid presence"
        ]
        
        let high = [
            "high-fast drive"
            "fast-high intensity"
            "rapid-high pulse"
            "fast-energy burst"
        ]
        
        let extreme = [
            "extreme-accelerated surge"
            "hyper-accelerated pulse"
            "breakneck-energy spike"
            "accelerated-extreme burst"
        ]

    let pickDirection d =
        let tags =
            match d with
            | Introductory | Awakening -> Directions.introductory
            | Connecting | Building -> Directions.connecting
            | Impact | Burst -> Directions.impact
            | Surge | Acceleration -> Directions.surge
            | Reflective | Fragmented -> Directions.reflective
            | Strain | Overload -> Directions.strain
            | Collapse | Failure -> Directions.collapse
            | Outro | Dissipation-> Directions.outro
            | Static | Steady -> Directions.steady
            | Functional | Transitional -> Directions.functional
            | Ambient | Background -> Directions.ambient
            | LoopLike | Mechanical -> Directions.mechanical
            | Emotionless | Analytical -> Directions.analytical
        tags |> List.randomChoice   
        
    let pickEnergy e =
        let tags =
            match e with
            | Low -> Energies2.low
            | Medium -> Energies2.medium
            | High -> Energies2.high
            | Extreme -> Energies2.extreme
        tags |> List.randomChoice
        
    let pickVocals v =
        let tags =
            match v with
            | Whispering  | Soft -> Vox.whispering
            | Cute | Light -> Vox.cute
            | Spoken | Narrative -> Vox.spoken
            | Growling | Aggressive -> Vox.growling
            | Grunting | Raw -> Vox.grunting
            | Processed | Digital -> Vox.processed
            | Neutral | Unemotional -> Vox.neutral
            | Voice.Ethereal | Atmospheric -> Vox.ethereal
        tags |> List.randomChoice
        
    let defaultSection =
        { Name = "untitled"
          Vox = None
          Language = None
          Energy = Energy.Medium
          Direction = Direction.Steady
          Style = [] }
