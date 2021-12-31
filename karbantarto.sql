-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Dec 31. 17:17
-- Kiszolgáló verziója: 10.4.14-MariaDB
-- PHP verzió: 7.3.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `karbantarto`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `karbantartasok`
--

DROP TABLE IF EXISTS `karbantartasok`;
CREATE TABLE `karbantartasok` (
  `karbantartas_id` int(11) NOT NULL,
  `szerelo_id` int(2) DEFAULT NULL,
  `megrendelo_id` int(2) DEFAULT NULL,
  `datum` date DEFAULT NULL,
  `javido` int(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `karbantartasok`
--

INSERT INTO `karbantartasok` (`karbantartas_id`, `szerelo_id`, `megrendelo_id`, `datum`, `javido`) VALUES
(6, 10, 5, '2015-01-13', 2),
(7, 7, 8, '2015-01-13', 3),
(8, 2, 9, '2015-01-15', 3),
(9, 10, 7, '2015-01-15', 6),
(10, 2, 2, '2015-01-16', 3),
(11, 9, 6, '2015-01-18', 3),
(12, 5, 5, '2015-01-20', 2),
(13, 9, 6, '2015-01-25', 5),
(14, 6, 7, '2015-01-26', 4),
(15, 8, 8, '2015-02-05', 3),
(16, 10, 4, '2015-02-11', 5),
(17, 8, 4, '2015-02-12', 2),
(18, 4, 8, '2015-02-15', 6),
(19, 1, 1, '2015-02-19', 2),
(20, 6, 1, '2015-02-23', 4),
(21, 3, 2, '2015-02-25', 4),
(22, 7, 3, '2015-02-27', 4),
(23, 3, 6, '2015-03-02', 5),
(24, 2, 2, '2015-03-08', 6),
(25, 2, 6, '2015-03-14', 2),
(26, 2, 7, '2015-03-15', 4),
(27, 8, 3, '2015-03-17', 4),
(28, 7, 5, '2015-03-18', 4),
(29, 8, 3, '2015-03-21', 2),
(30, 10, 4, '2015-03-24', 4),
(31, 8, 6, '2015-03-27', 5),
(32, 2, 7, '2015-04-07', 3),
(33, 4, 8, '2015-04-11', 3),
(34, 8, 4, '2015-04-16', 6),
(35, 2, 9, '2015-04-18', 6),
(36, 1, 5, '2015-04-26', 4),
(37, 5, 2, '2015-04-27', 4),
(38, 2, 1, '2015-04-27', 2),
(39, 4, 9, '2015-04-28', 6),
(40, 1, 3, '2015-05-05', 5),
(41, 5, 5, '2015-05-09', 4),
(42, 5, 3, '2015-05-09', 3),
(125, 3, 6, '2021-12-31', 4),
(126, 3, 5, '2021-12-31', 6),
(127, 3, 6, '2022-01-01', 5),
(131, 10, 1, '2021-12-31', 4),
(130, 10, 3, '2021-12-31', 3),
(129, 3, 9, '2022-01-01', 5),
(128, 3, 7, '2022-01-01', 5),
(123, 5, 7, '2021-12-30', 8),
(118, 3, 5, '2021-12-29', 6),
(120, 1, 1, '2021-12-29', 3),
(124, 1, 1, '2021-12-30', 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `megrendelok`
--

DROP TABLE IF EXISTS `megrendelok`;
CREATE TABLE `megrendelok` (
  `megrendelo_id` int(5) NOT NULL,
  `nev` varchar(18) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `cim` varchar(40) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `kedvezmeny` int(1) DEFAULT NULL,
  `telefon` varchar(14) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `megrendelok`
--

INSERT INTO `megrendelok` (`megrendelo_id`, `nev`, `cim`, `kedvezmeny`, `telefon`) VALUES
(1, 'Verpeléti Kitty', 'Jászberény Miklos u 5', 5, '(70) 301-94-97'),
(2, 'Lukács Lilla', 'Jászapáti Dió köz 1', 3, '(70) 536-80-44'),
(3, 'Solymos Sámuel', 'Jászberény Petőfi út 33', 10, '(70) 857-69-49'),
(4, 'Szabó András', 'Jászol Széna tér 3', 8, '(70) 393-54-66'),
(5, 'Braun Zsanett', 'Budapest Sehol nincs u. 42', 7, '(70) 111-62-88'),
(6, 'Cseszneki Julianna', 'Orosháza Kossuth tér 4', 5, '(20) 513-89-86'),
(7, 'Balogh Adrián', 'Gyöngyös Tigris köz 2', 2, '(20) 169-73-57'),
(8, 'Halmos Bálint', 'Hatvan Ötvenkettesek tere 40', 4, '(70) 802-81-31'),
(9, 'Jászai Linda', 'Jászapáti János u. 22.', 4, '(20) 581-38-50'),
(10, 'Hertelendi Mariann', 'Budapest Oroszlán tér 2', 2, '(30) 678-93-23');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szakteruletek`
--

DROP TABLE IF EXISTS `szakteruletek`;
CREATE TABLE `szakteruletek` (
  `szakterulet_id` int(5) NOT NULL,
  `megnevezes` varchar(30) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szakteruletek`
--

INSERT INTO `szakteruletek` (`szakterulet_id`, `megnevezes`) VALUES
(1, 'Vízszerelő'),
(2, 'Gázszerelő'),
(3, 'Villanyszerelő'),
(4, 'Mindenes');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szerelok`
--

DROP TABLE IF EXISTS `szerelok`;
CREATE TABLE `szerelok` (
  `szerelo_id` int(5) NOT NULL,
  `szakterulet_id` int(5) DEFAULT NULL,
  `nev` varchar(17) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `telefon` varchar(14) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `oradij` int(5) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szerelok`
--

INSERT INTO `szerelok` (`szerelo_id`, `szakterulet_id`, `nev`, `telefon`, `oradij`) VALUES
(1, 1, 'Keller János', '(30) 834-47-72', 3000),
(2, 2, 'Megyeri György', '(20) 716-19-54', 4000),
(3, 3, 'Eszes Lehel', '(70) 599-12-77', 2500),
(4, 4, 'Csikós László', '(20) 825-55-55', 3500),
(5, 4, 'Verpeléti Bence', '(70) 611-94-92', 5000),
(6, 3, 'Józsa Sándor', '(30) 394-33-50', 4500),
(7, 4, 'Lukács Pál', '(20) 302-85-17', 3000),
(8, 1, 'Madarász Bálint', '(20) 256-60-58', 3500),
(9, 3, 'Szabó Mátyás', '(70) 115-20-98', 2000),
(10, 2, 'Kalányos Lajos', '(20) 696-11-95', 2500);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `karbantartasok`
--
ALTER TABLE `karbantartasok`
  ADD PRIMARY KEY (`karbantartas_id`);

--
-- A tábla indexei `megrendelok`
--
ALTER TABLE `megrendelok`
  ADD PRIMARY KEY (`megrendelo_id`);

--
-- A tábla indexei `szakteruletek`
--
ALTER TABLE `szakteruletek`
  ADD PRIMARY KEY (`szakterulet_id`);

--
-- A tábla indexei `szerelok`
--
ALTER TABLE `szerelok`
  ADD PRIMARY KEY (`szerelo_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `karbantartasok`
--
ALTER TABLE `karbantartasok`
  MODIFY `karbantartas_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=132;

--
-- AUTO_INCREMENT a táblához `megrendelok`
--
ALTER TABLE `megrendelok`
  MODIFY `megrendelo_id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT a táblához `szakteruletek`
--
ALTER TABLE `szakteruletek`
  MODIFY `szakterulet_id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `szerelok`
--
ALTER TABLE `szerelok`
  MODIFY `szerelo_id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
