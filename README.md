# Switch Gift Data Manager
![immagine](https://github.com/Manu098vm/Switch-Gift-Data-Manager/assets/52102823/2c327c72-d34a-41c2-b912-fe290ea00446)

## About
This tool aims to make past Mystery Gift event contents back again in all the Pokémon games for Nintendo Switch.
Since those games won't allow event injection in the SAV file, this tool creates a forged BCAT package, injectable with homebrews like [JKSV](https://github.com/J-D-K/JKSV/releases).
This allows wondercards to be redeemed through the In-Game Mystery Gift Menu. The use of this tool does not involve hacking the game ROM nor hacking the game SAV. 

### Compatible files
* Let's Go Pikachu and Let's Go Eevee wondercard full files (.wb7full)
* Sword and Shield wondercard files (.wc8)
* Brilliant Diamond and Shining Pearl wondercard files (.wb8)
* Legends Arceus wondercard files (.wa8)
* Scarlet & Violet wondercard files (.wc9) 
* BCAT wondercard files, either with mutiple or single wondercards (no file format extension)

### Compatible games
* Pokémon Let's Go Pikachu and Eevee
* Pokémon Sword and Shield
* Pokémon Brilliant Diamond and Shining Pearl
* Pokémon Legends Arceus
* Pokémon Scarlet and Violet 

## Disclosure
Neither I nor the Project Pokémon staff takes any responsibility for possible adverse outcomes or bans due to the use of this tool. Use at your own discretion.
**N.B:** Some BCAT files contain sensible console-specific informations, which you should keep safe. Don't share your BCAT to others!

## Usage
This paragraph refers to the Windows Form app. The Command Line app usage is similar and should be fairly intuitive.
* Ensure you have the required [.NET 7.0 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) correctly installed
* Dump your game's BCAT with [JKSV](https://github.com/J-D-K/JKSV/releases) and keep some copies somewhere safe
* Open the tool and select your game of choice
* Import wondercard files of your choice (by drag & drop or by clicking the `Open Files` button)
* Eventually edit the wondercard id (WCID) if you have duplicated WCs and click `Apply`
* Click the `Save as BCAT Package` button and browse to your dumped BCAT
* A folder called "Forged_BCAT_{Game}" should appear next to your dumped BCAT
* Restore the Forged Bcat with JKSV
* To redeem the old fashion events, open your game -> Menu -> Mystery Gift -> redeem via Internet
* When you're done, restore your original BCAT package with JKSV (not doing so may cause sync issues)

**N.B**: BCAT Sync usually occurs between 12:00 AM (UTC) and 01:00 AM (UTC). I suggest to not follow this procedure during that timeframe to avoid a desync.
If you experience a desync, follow one of these methods to resync:
* Open JKSV, select BCAT, hover over your game and press X to open the menu, then click `Reset Save Data`. 
* Download the latest BCAT for your game from my [bcat_updates](https://github.com/Manu098vm/bcat_updates) repo or from [citrusbolt](https://github.com/citrusbolt)'s [website](http://citrusbolt.net/bcat/) and add the missing files to your dumped BCAT, then restore it with JKSV.

## Support/Troubleshooting
If you find any bug or you need support, please write in the [relevant topic on the Project Pokémon forums](https://projectpokemon.org/home/forums/topic/62491-switch-gift-data-manager-import-wondercards-into-switch-games-by-faking-bcat-packages/).
Alternatively, feel free to contact me in my [Discord server](https://discord.gg/yWveAjKbKt).

[<img src="https://canary.discordapp.com/api/guilds/693083823197519873/widget.png?style=banner2">](https://discord.gg/yWveAjKbKt)

## Building
* All the Switch Gift Data Manager projects require .NET 7.0.
* .WinForm is a Windows Form application and can only be built in Windows Operating Systems. 
* .Core and .CommandLine can be built in any platform OS.
* Use the Debug build configuration when editing or developing code related to the .WinForm project. Build as Release only once the code is finished.
* To build the projects, open the .sln file in the root directory with an IDE such as Visual Studio 2022, click `Build` -> `Build Solution`.

The .CommandLine project is currently just a simple script that calls the .Core functionalities and can run on any popular OS. Feel free to improve it and/or submit a pull request if you'd like :-)

## Credits
* [PNZeml](https://github.com/PNZeml) for the CRC-16/CCITT-FALSE with lookup table [implementation](https://gist.github.com/tijnkooijmans/10981093?permalink_comment_id=3996072#gistcomment-3996072)
* [kwsch](https://github.com/kwsch), [sora10pls](https://github.com/sora10pls) and all the [PKHeX](https://github.com/kwsch/PKHeX) and [pkNX](https://github.com/kwsch/pkNX) devs and contributors
for a lot of offsets and resources
* [PP-theSLAYER](https://github.com/PP-theSLAYER) and [pasqualenardiello](https://github.com/pasqualenardiello) for their researches on the Sword & Shield fashion block and on the Scarlet and Violet fashion block respectively
* All the Project Pokémon Staff and the [Event Gallery](https://github.com/projectpokemon/EventsGallery) contributors for their archival efforts that made this possible

## License
![gplv3-with-text-136x68](https://user-images.githubusercontent.com/52102823/199572700-4e02ed70-74ef-4d67-991e-3168d93aac0d.png)

Copyright © 2023 Manu098vm

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
