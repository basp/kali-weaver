// For each section, include:
// * 1 vocal identity
// * 1 language
// * 1 energy level
// * 1 emotional direction
// * 1-2 stylistic cues max

// Suno treats parentheses as non-singing metadata so it won't
// try to vocalize them.
// You can use:
// * (no lyrics)
// * (instrumental only)
// * (vocalise)
// * (breath / texture only)

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

type Vox =
    | Grunting
    | Growling
    | Screaming
    | Whispering
    | Cute
    | VisualKey

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

type Tempo =
    | Slow
    | Medium
    | Fast
    | Extreme

let slowTempo = [
    "slow tempo"
    "low-pulse rhythm"
    "drifting pase"
    "unhurried movement"
]

let mediumTempo = [
    "steady tempo"
    "mid-pulse groove"
    "moderate rhythm drive"
    "balanced pacing"
]

let fastTempo = [
    "fast bpm"
    "driving tempo"
    "accelerated pulse"
    "high-energy rythm"
]

let extremeTempo = [
    "hyper-tempo"
    "rapid-fire rhythm"
    "breakneck pulse"
    "extreme bpm energy"
]

type Section =
    { Name: string
      Vox: Vox option
      Language: Language option
      Energy: Energy
      Direction: string
      Style: Texture list }
    
type Track =
    { Name: string
      Sections: Section list }
    
let defaultSection =
    { Name = "untitled"
      Vox = None
      Language = Option.None
      Energy = Energy.Medium
      Direction = "neutral"
      Style = [] }

let sections = [
    // intro
    { defaultSection with
        Name = "boot sequence"
        Energy = Low
        Direction = "awakening from static, slow system initialization"
        Style = [Ethereal; PhaseTear] }
    
    // build 1
    { defaultSection with
        Name = "system uplink"
        Energy = Energy.Medium
        Direction = "signal rising, channels opening, tension forming"
        Style = [PulseWave; GrainBurst] }
    
    // main 1
    { defaultSection with
        Name ="core dump 1"
        Energy = High
        Direction = "raw data overflow, emotional rupture"
        Style = [DataCorrupt; Overdrive] }
    
    // drop 1
    { defaultSection with
        Name = "data surge"
        Energy = Energy.Medium
        Direction = "glitch bloom, sudden voltage spike"
        Style = [GlitchPop; BufferDrag] }
    
    // break
    { defaultSection with
        Name = "memory fragment"
        Energy = High
        Direction = "fractured recall, shimmering instability"
        Style = [PastGlimpses; Stutter] }
    
    // build 2
    { defaultSection with
        Name = "overclock"
        Energy = Energy.Medium
        Direction = "pressure rising, system strain, heat building"
        Style = [PulseWave; CircuitBend] }
    
    // main 2
    { defaultSection with
        Name = "core dump 2"
        Energy = High
        Direction = "full emotional release, catastrophic overflow"
        Style = [DataCorrupt; Ethereal]}
    
    // drop 2
    { defaultSection with
        Name = "kernel panic"
        Energy = Energy.Medium
        Direction = "violent glitch collapse, system failure cascade"
        Style = [GrainBurst; FutureGlimpses] }
    
    // outro
    { defaultSection with
        Name = "final echo"
        Energy = Low
        Direction = "dissolving into silence, fading system residue"
        Style = [Stutter; VaporTrail] }
]