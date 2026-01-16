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

let operaTrack = {
    Title = "NEON_VIBRATO // ACT_I"
    Style = ["visual-kei"; "symphonic-glitch"; "cyberpunk-opera"; "dramatic"]
    Sections = [
        {
            Name = "Curtain Rise"
            Kind = Intro
            Vox = VisualKey
            Language = Some Japanese
            Energy = Medium
            Textures = [Crackle; PastGlimpses]
            Theme = "An old vinyl recording of a theater performance playing in a ruin"
            Notes = ["hissing needle"; "distant reverb"]
            Lines = (2, 4)
            Direction = "operatic, theatrical, nostalgic"
        }
        {
            Name = "Neural Link"
            Kind = Build
            Vox = Aegyo
            Language = Some Japanese
            Energy = High
            Textures = [PulseWeave; ChipMelody]
            Theme = "Suddenly being pulled into a neon simulation"
            Notes = ["accelerating pulses"; "high-pitched chirps"]
            Lines = (3, 5)
            Direction = "playful, hyper-active, synthetic"
        }
        {
            Name = "The Grand Stage"
            Kind = Main
            Vox = Enka
            Language = Some Japanese
            Energy = Extreme
            Textures = [PhaseTear; PitchShift]
            Theme = "The main performance where the singer's soul fragments"
            Notes = ["heavy vibrato"; "digital tearing"]
            Lines = (8, 12)
            Direction = "soulful, climactic, overwhelming"
        }
        {
            Name = "Critical Error"
            Kind = Drop
            Vox = Barking
            Language = Some Dutch
            Energy = Extreme
            Textures = [DataCorrupt; Stutter; Bitcrush]
            Theme = "The simulation crashes under the emotional weight"
            Notes = ["machine-gun rhythms"; "raw distortion"]
            Lines = (2, 3)
            Direction = "violent, rhythmic, percussive"
        }
        {
            Name = "The Memory Remains"
            Kind = Outro
            Vox = Whispering
            Language = Some Sindarin
            Energy = Low
            Textures = [Ethereal; FutureGlimpses]
            Theme = "A quiet elven lament for the lost digital world"
            Notes = ["echoing whispers"; "fading light"]
            Lines = (2, 3)
            Direction = "sad, haunting, disappearing"
        }
    ]
}

let prompt = weave operaTrack
printfn $"%s{prompt}"