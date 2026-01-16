open Kali.Weaver

let myTrack = {
    Title = "VOID_WALKER // 001"
    Style = ["cyber-glitch"; "industrial-enka"; "breakcore"; "experimental"]
    Sections = [
        {
            Name = "System Boot"
            Kind = Intro
            Vox = Whispering
            Language = Some Japanese
            Energy = Low
            Textures = [DataCorrupt; SyntaxError]
            Theme = "Waking up in a digital afterlife"
            Notes = ["static hiss"; "distorted hum"]
            Lines = (2, 3)
            Direction = "glitchy, breathy, fragmented"
        }
        {
            Name = "Data Stream"
            Kind = Build
            Vox = Shouto
            Language = Some Sindarin
            Energy = High
            Textures = [TimeSlip; PitchShift]
            Theme = "The flow of ancient memories through a fiber-optic cable"
            Notes = ["rising pitch"; "accelerating tempo"]
            Lines = (4, 6)
            Direction = "urgent, rhythmic, ascending"
        }
        {
            Name = "The Core"
            Kind = Main
            Vox = Enka
            Language = Some Japanese
            Energy = Extreme
            Textures = [PhaseTear; GrainBurst; PulseWave]
            Theme = "A traditional song colliding with a collapsing server"
            Notes = ["vocal vibrato vs digital noise"]
            Lines = (6, 8)
            Direction = "emotional, powerful, chaotic"
        }
        {
            Name = "Buffer Overflow"
            Kind = Drop
            Vox = Screaming
            Language = Some Dutch
            Energy = Extreme
            Textures = [Bitcrush; Stutter; BufferDrag]
            Theme = "Total system failure and ego death"
            Notes = ["heavy bass hits"; "rhythmic silence"]
            Lines = (2, 4)
            Direction = "explosive, aggressive, broken"
        }
        {
            Name = "Ghost in the Shell"
            Kind = Outro
            Vox = Kawaii
            Language = Some Japanese
            Energy = Low
            Textures = [FutureGlimpses; Ethereal]
            Theme = "A single clean signal remains in the void"
            Notes = ["reverb heavy"; "fading to static"]
            Lines = (1, 2)
            Direction = "sweet, haunting, final"
        }
    ]
}

let prompt = weave myTrack
printfn $"%s{prompt}"