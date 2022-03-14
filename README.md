# maisim

A free and open-source, community-powered clone of SEGA's Maimai game powered by the [osu!framework](https://github.com/ppy/osu-framework).

Note : project name isn't final (yet?).

## Project Status

The project is still in an infancy stage. Current priorities are creating UI pieces from the figma designs and getting basic gameplay working. Stuff like UI adjustment and etc. might come later.

There are plans to develop along this a website so the game can be a whole experience by itself, offering you things Maimai doesn't.

Figma designs are available at the [project's wiki](https://github.com/HelloYeew/maisim/wiki/Figma-link).

## Contributing

Want to contribute? That's cool ! We got a lot of things to do at all scales :

- Got an idea ? Pitch it in a discussion !
- Want to improve the design ? Start a discussion about design improvements !
- Wanna contribute to implementing parts of the gameplay ? Let us know in a discussion thread !
- Found a bug or something not working as it should ? Open an issue to let us know !

Don't hesitate to make a discussion and we will try to answer as fast as we can.

You know C# ? You can try picking an issue up and make a pull request and we will review it.

## Developing maisim

The following items are required to be installed on your computer in order to develop maisim:

- The [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download) or higher
- Developing for mobile requires a Xamarin installation, which ships with Visual Studio 2019+ or Visual Studio for Mac.
- The use of a C# IDE (Rider, Visual Studio) is highly recommended to browse through the codebase.

Getting started with developing maisim is as follows:


### Grabbing the code from the repository
```sh
git clone https://github.com/HelloYeew/maisim
cd maisim/maisim
```

### Running the game

```sh
cd maisim.Desktop

# restore nuget packages for the solution
dotnet restore

# run the game with the debug profile
dotnet run 

# if you ever want to run the game with the release profile
dotnet run -c:Release
```

### Running visual tests

```sh
cd maisim.Game.Tests

# restore nuget packages for the solution
dotnet restore

# run the visual tests with the debug profile
dotnet run 
```

If you're using an IDE, it should be automatically picking the development profiles when opening the solution files.


## Licence

This project is licensed under the MIT license. Please see [the licence file](LICENSE) for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.

Original idea for Maimai from SEGA(TM).
