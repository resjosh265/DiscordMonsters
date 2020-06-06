CREATE SCHEMA discord_monsters;

USE discord_monsters;

CREATE TABLE `discord_monsters`.`player` (
`PlayerId` INT NOT NULL AUTO_INCREMENT,
`DiscordId` VARCHAR(128) NOT NULL,
`Level` INT NOT NULL DEFAULT 1,
`Experience` INT NOT NULL DEFAULT 0,
`IsAdmin` BIT NOT NULL DEFAULT 0,
PRIMARY KEY (`PlayerId`),
UNIQUE INDEX `PlayerId_UNIQUE` (`PlayerId` ASC) VISIBLE,
UNIQUE INDEX `DiscordId_UNIQUE` (`DiscordId` ASC) VISIBLE);

CREATE TABLE `discord_monsters`.`item` (
`ItemId` INT NOT NULL AUTO_INCREMENT,
`Name` VARCHAR(128) NOT NULL,
`Description` VARCHAR(512) NULL,
PRIMARY KEY (`ItemId`),
UNIQUE INDEX `ItemId_UNIQUE` (`ItemId` ASC) VISIBLE);

CREATE TABLE `discord_monsters`.`player_inventory` (
`PlayerInventoryId` INT NOT NULL AUTO_INCREMENT,
`PlayerId` INT NOT NULL,
`ItemId` INT NOT NULL,
`Count` INT NOT NULL,
PRIMARY KEY (`PlayerInventoryId`),
INDEX (PlayerId),
INDEX (ItemId),
FOREIGN KEY (PlayerId) REFERENCES player(PlayerId),
FOREIGN KEY (ItemId) REFERENCES item(ItemId),
UNIQUE INDEX `PlayerInventoryId_UNIQUE` (`PlayerInventoryId` ASC) VISIBLE);

CREATE TABLE `discord_monsters`.`monster` (
`MonsterId` INT NOT NULL AUTO_INCREMENT,
`Name` VARCHAR(128) NOT NULL,
`MinLevel` INT NOT NULL DEFAULT 1,
`MaxLevel` INT NOT NULL DEFAULT 100,
`BaseExperienceAward` INT NOT NULL DEFAULT 10,
`ImageUrl` VARCHAR(2048) NULL,
PRIMARY KEY (`MonsterId`),
UNIQUE INDEX `MonsterId_UNIQUE` (`MonsterId` ASC) VISIBLE);

CREATE TABLE `discord_monsters`.`level_experience` (
`LevelExperienceId` INT NOT NULL AUTO_INCREMENT,
`Level` INT NOT NULL,
`ExperienceRequired` INT NOT NULL,
PRIMARY KEY (`LevelExperienceId`),
UNIQUE INDEX `LevelExperienceId_UNIQUE` (`LevelExperienceId` ASC) VISIBLE);

CREATE TABLE `discord_monsters`.`player_catch` (
`PlayerCatchId` INT NOT NULL AUTO_INCREMENT,
`PlayerId` INT NOT NULL,
`MonsterId` INT NOT NULL,
`Level` INT NOT NULL,
PRIMARY KEY (`PlayerCatchId`),
INDEX (PlayerId),
INDEX (MonsterId),
FOREIGN KEY (PlayerId) REFERENCES player(PlayerId),
FOREIGN KEY (MonsterId) REFERENCES monster(MonsterId),
UNIQUE INDEX `PlayerCatchId_UNIQUE` (`PlayerCatchId` ASC) VISIBLE);



INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('1', '1');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('2', '100');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('3', '200');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('4', '300');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('5', '500');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('6', '700');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('8', '900');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('9', '1100');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('10', '1500');
