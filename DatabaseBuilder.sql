CREATE SCHEMA discord_monsters;

USE discord_monsters;

CREATE TABLE `discord_monsters`.`player` (
`PlayerId` INT NOT NULL AUTO_INCREMENT,
`DiscordId` VARCHAR(128) NOT NULL,
`Level` INT NOT NULL DEFAULT 1,
`Experience` INT NOT NULL DEFAULT 0,
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
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('2', '400');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('3', '800');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('4', '1200');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('5', '1600');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('6', '2100');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('8', '2600');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('9', '3100');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('10', '3700');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('11', '4300');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('12', '4900');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('13', '5500');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('14', '6100');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('15', '6800');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('16', '7500');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('17', '8200');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('18', '8900');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('19', '9600');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('20', '15000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('21', '25000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('22', '35000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('23', '45000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('24', '55000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('25', '65000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('26', '75000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('27', '85000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('28', '95000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('29', '105000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('30', '115000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('31', '130000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('32', '145000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('33', '170000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('34', '185000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('35', '200000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('36', '215000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('37', '230000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('38', '245000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('39', '270000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('40', '295000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('41', '350000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('42', '400000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('43', '450000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('44', '500000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('45', '550000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('46', '600000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('47', '650000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('48', '700000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('49', '750000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('50', '800000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('51', '900000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('52', '1000000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('53', '1100000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('54', '1200000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('55', '1300000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('56', '1400000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('57', '1500000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('58', '1600000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('59', '1700000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('60', '1800000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('61', '1900000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('62', '2000000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('63', '2100000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('64', '2200000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('65', '2300000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('66', '2400000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('67', '2500000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('68', '2600000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('69', '2700000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('70', '2800000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('71', '2900000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('72', '3000000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('73', '3100000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('74', '3200000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('75', '3300000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('76', '3400000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('77', '3500000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('78', '3600000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('79', '3700000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('80', '3800000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('81', '3900000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('82', '4000000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('83', '4100000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('84', '4200000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('85', '4300000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('86', '4400000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('87', '4500000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('88', '4600000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('89', '4700000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('90', '4800000');

INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('91', '4900000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('92', '5000000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('93', '5100000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('94', '5200000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('95', '5300000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('96', '5400000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('97', '5500000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('98', '5600000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('99', '5700000');
INSERT INTO `discord_monsters`.`level_experience` (`Level`, `ExperienceRequired`) VALUES ('100', '5800000');