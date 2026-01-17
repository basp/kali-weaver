module Kali.Templates

open Weaver

let electronicGlitch theme =
    { Title = "Glitch Experiment"
      Style = ["Glitch"; "IDM"; "Electronic"]
      Sections = [
          { Name = "Intro"
            Kind = Intro
            Vox = Whispering
            Language = None
            Energy = Low
            Textures = [Bitcrush; GrainBurst]
            Theme = theme
            Notes = ["Slow build"]
            Lines = (2, 4)
            Direction = "Atmospheric" }
          { Name = "Main"
            Kind = Main
            Vox = Growling
            Language = Some Japanese
            Energy = High
            Textures = [DataCorrupt; PhaseTear]
            Theme = theme
            Notes = ["Heavy glitching"]
            Lines = (8, 12)
            Direction = "Aggressive" }
      ] }