-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 31 May 2020, 18:03:34
-- Sunucu sürümü: 10.2.26-MariaDB-cll-lve
-- PHP Sürümü: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `viovasof_cse`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `access`
--

CREATE TABLE `access` (
  `id` int(12) NOT NULL,
  `user_id` int(12) NOT NULL,
  `pass` varchar(300) NOT NULL,
  `type` varchar(12) NOT NULL,
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `assistans`
--

CREATE TABLE `assistans` (
  `id` int(12) NOT NULL,
  `name` varchar(50) NOT NULL,
  `number` varchar(50) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `courses`
--

CREATE TABLE `courses` (
  `id` int(12) NOT NULL,
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `instructor_id` int(12) NOT NULL,
  `hour` varchar(50) NOT NULL,
  `day` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `instructors`
--

CREATE TABLE `instructors` (
  `id` int(12) NOT NULL,
  `name` varchar(50) NOT NULL,
  `number` varchar(50) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `labs`
--

CREATE TABLE `labs` (
  `id` int(12) NOT NULL,
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `assistan_id` int(12) NOT NULL,
  `hour` varchar(50) NOT NULL,
  `day` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `lecture_rooms`
--

CREATE TABLE `lecture_rooms` (
  `id` int(12) NOT NULL,
  `room_name` varchar(50) NOT NULL,
  `user_id` int(12) NOT NULL,
  `type` varchar(12) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `students`
--

CREATE TABLE `students` (
  `id` int(12) NOT NULL,
  `name` varchar(50) NOT NULL,
  `number` varchar(50) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `access`
--
ALTER TABLE `access`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `assistans`
--
ALTER TABLE `assistans`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `instructors`
--
ALTER TABLE `instructors`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `labs`
--
ALTER TABLE `labs`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `lecture_rooms`
--
ALTER TABLE `lecture_rooms`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `access`
--
ALTER TABLE `access`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `assistans`
--
ALTER TABLE `assistans`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `courses`
--
ALTER TABLE `courses`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `instructors`
--
ALTER TABLE `instructors`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `labs`
--
ALTER TABLE `labs`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `lecture_rooms`
--
ALTER TABLE `lecture_rooms`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `students`
--
ALTER TABLE `students`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
