namespace KaliWeaver.Tests

open Xunit
open Kali.Weaver

module AstTests =

    [<Fact>]
    let ``section can be created with basic fields`` () =
        let section = {
            Name = "Cold Start"
            Kind = Intro
            Vox = Growling
            Language = Some Japanese
            Energy = High
            Textures = [Bitcrush; Stutter]
            Theme = "Beleriand"
            Notes = ["no drums"; "kawaii"]
            Lines = (2, 4)
            Direction = "short, primal"
        }

        Assert.Equal("Cold Start", section.Name)
        Assert.Equal(Intro, section.Kind)
        Assert.Equal(Growling, section.Vox)
        Assert.Equal(Some Japanese, section.Language)
        Assert.Equal(High, section.Energy)

    [<Fact>]
    let ``section can have empty textures`` () =
        let section = {
            Name = "Silent Void"
            Kind = Intro
            Vox = Whispering
            Language = Some Sindarin
            Energy = Low
            Textures = []
            Theme = "Silence"
            Notes = []
            Lines = (1, 1)
            Direction = "long, primal"
        }

        Assert.Empty(section.Textures)

    [<Fact>]
    let ``notes can store arbitrary metadata`` () =
        let section = {
            Name = "Experimental"
            Kind = Build
            Vox = Screaming
            Language = Some Dutch
            Energy = Extreme
            Textures = []
            Theme = "Chaos"
            Notes = ["weird timing"; "glitchy"]
            Lines = (1, 1)
            Direction = "long, chaotic"
        }

        Assert.Contains("glitchy", section.Notes)

    [<Fact>]
    let ``weave procues expected format`` () =
        let section = {
            Name = "Cold Start"
            Kind = Intro
            Vox = Growling
            Language = Some Japanese
            Energy = High
            Textures = [Bitcrush]
            Theme = "Beleriand"
            Notes = ["no drums"]
            Lines = (2, 4)
            Direction = "primal"
        }
        
        let output = compileSection section
        Assert.Contains("[COLD START]", output)
        Assert.Contains("Vox: Growling, Japanese", output)
        Assert.Contains("Texture: Bitcrush, no drums", output)
