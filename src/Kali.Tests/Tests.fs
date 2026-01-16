namespace KaliWeaver.Tests

open Xunit
open Kali.Weaver

module AstTests =

    [<Fact>]
    let ``Section can be created with basic fields`` () =
        let section = {
            Name = "Cold Start"
            Kind = Intro
            Vox = Growling
            Language = Some Japanese
            Energy = High
            Textures = [Bitcrush; Stutter]
            Theme = "Beleriand"
            Notes = ["no drums"; "kawaii"]
        }

        Assert.Equal("Cold Start", section.Name)
        Assert.Equal(Intro, section.Kind)
        Assert.Equal(Growling, section.Vox)
        Assert.Equal(Some Japanese, section.Language)
        Assert.Equal(High, section.Energy)

    [<Fact>]
    let ``Section can have empty textures`` () =
        let section = {
            Name = "Silent Void"
            Kind = Intro
            Vox = Whispering
            Language = Some Sindarin
            Energy = Low
            Textures = []
            Theme = "Silence"
            Notes = []
        }

        Assert.Empty(section.Textures)

    [<Fact>]
    let ``Notes can store arbitrary metadata`` () =
        let section = {
            Name = "Experimental"
            Kind = Build
            Vox = Screaming
            Language = Some Dutch
            Energy = Extreme
            Textures = []
            Theme = "Chaos"
            Notes = ["weird timing"; "glitchy"]
        }

        Assert.Contains("glitchy", section.Notes)
