# Switch Gift Data Manager
![immagine](https://github.com/Manu098vm/Switch-Gift-Data-Manager/assets/52102823/2c327c72-d34a-41c2-b912-fe290ea00446)

## About
This tool aims to bring back past Mystery Gift event content in all Pokémon games for Nintendo Switch.
Since these games don't allow event injection in the save file, this tool creates a forged BCAT package, which can be injected using homebrew tools like [JKSV](https://github.com/J-D-K/JKSV/releases).
This allows wondercards to be redeemed through the in-game Mystery Gift menu. The use of this tool does not involve hacking the game ROM or modifying the game save file.

### Compatible files
* Let's Go Pikachu and Let's Go Eevee wondercard full files (.wb7full)
* Sword and Shield wondercard files (.wc8)
* Brilliant Diamond and Shining Pearl wondercard files (.wb8)
* Legends Arceus wondercard files (.wa8)
* Scarlet & Violet wondercard files (.wc9)
* Legends Z-A wondercard files (.wa9)
* BCAT wondercard files, containing either multiple or single wondercards (no file format extension)

### Compatible games
* Pokémon Let's Go Pikachu and Eevee
* Pokémon Sword and Shield
* Pokémon Brilliant Diamond and Shining Pearl
* Pokémon Legends Arceus
* Pokémon Scarlet and Violet
* Pokémon Legends Z-A

## Disclosure
Neither I nor the Project Pokémon staff take any responsibility for possible adverse outcomes or bans resulting from the use of this tool. Use it at your own discretion.

**N.B.:** Some BCAT files contain sensitive console-specific information that you should keep secure. Do not share your BCAT with others!

## Usage
This section refers to the Windows Form app. The Command Line app usage is similar and should be fairly intuitive.
* Ensure you have the required [.NET 9.0 Desktop Runtime](https://dotnet.microsoft.com/it-it/download/dotnet/9.0) installed correctly.
* Dump your game's BCAT with [JKSV](https://github.com/J-D-K/JKSV/releases) and keep some copies in a safe place.
* Open the tool and select your game of choice.
* Import the wondercard files of your choice (by drag & drop or by clicking the `Open Files` button).
* Optionally, edit the wondercard ID (WCID) if you have duplicate WCs, then click `Apply`.
* Click the `Save as BCAT Package` button and browse to your dumped BCAT.
* A folder called "Forged_BCAT_{Game}" should appear next to your dumped BCAT.
* Restore the forged BCAT using JKSV.
* To redeem the old event gifts, open your game -> Menu -> Mystery Gift -> Redeem via Internet.
* When you're done, restore your original BCAT package with JKSV (not doing so may cause sync issues).

**N.B.:** BCAT sync usually occurs between 12:00 AM (UTC) and 01:00 AM (UTC). I recommend avoiding this procedure during that timeframe to prevent desynchronization.
If you experience a desync, follow one of these methods to resync:
* Open JKSV, select BCAT, hover over your game, press X to open the menu, then click `Reset Save Data`.
* Download the latest BCAT for your game from [citrusbolt](https://github.com/citrusbolt)'s [website](http://citrusbolt.net/bcat/) and add the missing files to your dumped BCAT, then restore it with JKSV.

## Support/Troubleshooting
If you find any bugs or need support, please post in the [relevant topic on the Project Pokémon forums](https://projectpokemon.org/home/forums/topic/62491-switch-gift-data-manager-import-wondercards-into-switch-games-by-faking-bcat-packages/).
Alternatively, feel free to contact me on my [Discord server](https://discord.gg/yWveAjKbKt).

[<img src="https://canary.discordapp.com/api/guilds/693083823197519873/widget.png?style=banner2">](https://discord.gg/yWveAjKbKt)

## Building
* All Switch Gift Data Manager projects require .NET 9.0.
* `.WinForm` is a Windows Form application and can only be built on Windows operating systems.
* `.Core` and `.CommandLine` can be built on any platform.
* Use the Debug build configuration when editing or developing code related to the `.WinForm` project. Build as Release only once the code is finalized.
* To build the projects, open the `.sln` file in the root directory with an IDE such as Visual Studio 2022, then click `Build` -> `Build Solution`.

The `.CommandLine` project is currently just a simple script that calls the `.Core` functionalities and can run on any popular OS. Feel free to improve it and/or submit a pull request if you'd like :-)

## Credits
* [PNZeml](https://github.com/PNZeml) for the CRC-16/CCITT-FALSE with lookup table [implementation](https://gist.github.com/tijnkooijmans/10981093?permalink_comment_id=3996072#gistcomment-3996072).
* [kwsch](https://github.com/kwsch), [sora10pls](https://github.com/sora10pls), and all the [PKHeX](https://github.com/kwsch/PKHeX) and [pkNX](https://github.com/kwsch/pkNX) developers and contributors for various offsets and resources.
* [PP-theSLAYER](https://github.com/PP-theSLAYER) and [pasqualenardiello](https://github.com/pasqualenardiello) for their research on the Sword & Shield fashion block and the Scarlet & Violet fashion block, respectively.
* All the Project Pokémon staff and the [Event Gallery](https://github.com/projectpokemon/EventsGallery) contributors for their archival efforts that made this project possible.

## License
![gplv3-with-text-136x68](https://user-images.githubusercontent.com/52102823/199572700-4e02ed70-74ef-4d67-991e-3168d93aac0d.png)

Copyright © 2025 Manu098vm

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
