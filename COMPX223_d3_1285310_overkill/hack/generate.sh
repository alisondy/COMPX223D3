rm -rf Views/Animals
rm -rf Views/Traps
rm -rf Views/TrapUsers
rm -rf Views/Landowners
rm -rf Views/TrapTypes
rm -rf Views/TrapCatchEvents

rm -rf Controllers/AnimalsController.cs
rm -rf Controllers/TrapsController.cs
rm -rf Controllers/TrapUsersController.cs
rm -rf Controllers/LandownersController.cs
rm -rf Controllers/TrapTypesController.cs
rm -rf Controllers/TrapCatchEventsController.cs
 
dotnet aspnet-codegenerator controller -name AnimalsController -m Animal -dc MyTrapAppContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name LandownersController -m Landowner -dc MyTrapAppContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TrapUsersController  -m TrapUser -dc MyTrapAppContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TrapTypesController  -m TrapType -dc MyTrapAppContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TrapsController  -m Trap -dc MyTrapAppContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TrapCatchEventsController -m TrapCatchEvent -dc MyTrapAppContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
