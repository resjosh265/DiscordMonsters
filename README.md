# Discord Monsters

Discord Monsters is a bot game that spawns monsters at random and allows users to catch them.

## Installation

1. Run the script at DatabaseBuilder.sql
2. Fill the monster table with whatever you would like
3. Create your discord bot and give it the Send Messages and Read Message History permissions.
4. Once the bot is created and has joined your server, right click the text channel you wish to have run the game and copy the ID. This is your channel ID (guide here https://discordpy.readthedocs.io/en/latest/discord.html)
5. Configure the appsettings.json with the channel ID and the bots auth token

## Usage

publish the project, configure your settings in the appsettings.json and run the executable.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Be sure to NOT remove appsettings.json from the .gitignore. This WILL have sensitive information and your pull request will be denied.

## License
[MIT](https://choosealicense.com/licenses/mit/)