dotnet publish ./src/AGameInVbNetAboutColorBeingTheMostImportantMechanic/AGameInVbNetAboutColorBeingTheMostImportantMechanic.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/AGameInVbNetAboutColorBeingTheMostImportantMechanic/AGameInVbNetAboutColorBeingTheMostImportantMechanic.vbproj -o ./pub-windows -c Release --sc -r win-x64
dotnet publish ./src/AGameInVbNetAboutColorBeingTheMostImportantMechanic/AGameInVbNetAboutColorBeingTheMostImportantMechanic.vbproj -o ./pub-mac -c Release --sc -r osx-x64
butler push pub-windows thegrumpygamedev/a-game-in-vbnet-about-color-being-the-most-important-mechanic:windows
butler push pub-linux thegrumpygamedev/a-game-in-vbnet-about-color-being-the-most-important-mechanic:linux
butler push pub-mac thegrumpygamedev/a-game-in-vbnet-about-color-being-the-most-important-mechanic:mac
git add -A
git commit -m "shipped it!"