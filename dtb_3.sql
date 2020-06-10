-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 10 Haz 2020, 10:22:17
-- Sunucu sürümü: 10.2.31-MariaDB-cll-lve
-- PHP Sürümü: 7.3.6

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
  `name` varchar(50) NOT NULL,
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
  `department_id` int(12) NOT NULL,
  `faculty` varchar(50) NOT NULL,
  `start` varchar(50) NOT NULL,
  `end` varchar(50) NOT NULL,
  `day` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `courses`
--

INSERT INTO `courses` (`id`, `code`, `name`, `instructor_id`, `department_id`, `faculty`, `start`, `end`, `day`) VALUES
(1, 'BTO310', 'Katı modelleme', 0, 3, 'educationF', '09.00', '12.00', 'monday'),
(2, 'BTO406', 'Öğretmenlik Uygulaması', 0, 3, 'educationF', '08.00', '15.00', 'tuesday'),
(3, 'BTO436', 'Teknoloji Atıkları ve Çevre Bilinci', 0, 3, 'educationF', '13.00', '15.00', 'monday'),
(4, 'EGT404', 'Rehberlik', 0, 3, 'educationF', '13.00', '15.00', 'tuesday');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `educationF`
--

CREATE TABLE `educationF` (
  `id` int(12) NOT NULL,
  `department` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `educationF`
--

INSERT INTO `educationF` (`id`, `department`) VALUES
(1, 'classroom teaching'),
(2, 'preschool teaching'),
(3, 'computer teaching');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `engineeringF`
--

CREATE TABLE `engineeringF` (
  `id` int(12) NOT NULL,
  `department` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `engineeringF`
--

INSERT INTO `engineeringF` (`id`, `department`) VALUES
(1, 'computer engineering'),
(2, 'electric and electronic engineering'),
(3, 'machine engineering');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `instructors`
--

CREATE TABLE `instructors` (
  `id` int(12) NOT NULL,
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
-- Tablo için tablo yapısı `scienceF`
--

CREATE TABLE `scienceF` (
  `id` int(12) NOT NULL,
  `department` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `scienceF`
--

INSERT INTO `scienceF` (`id`, `department`) VALUES
(1, 'physics'),
(2, 'biology'),
(3, 'psychology');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `students`
--

CREATE TABLE `students` (
  `id` int(12) NOT NULL,
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
-- Tablo için indeksler `educationF`
--
ALTER TABLE `educationF`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `engineeringF`
--
ALTER TABLE `engineeringF`
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
-- Tablo için indeksler `scienceF`
--
ALTER TABLE `scienceF`
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
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `educationF`
--
ALTER TABLE `educationF`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `engineeringF`
--
ALTER TABLE `engineeringF`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
-- Tablo için AUTO_INCREMENT değeri `scienceF`
--
ALTER TABLE `scienceF`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `students`
--
ALTER TABLE `students`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
