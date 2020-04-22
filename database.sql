-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 23 Nis 2020, 01:37:45
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
-- Tablo için tablo yapısı `Access`
--

CREATE TABLE `Access` (
  `id` int(11) NOT NULL,
  `userid` varchar(45) NOT NULL,
  `pass` varchar(45) NOT NULL,
  `tac_id` varchar(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Attendance`
--

CREATE TABLE `Attendance` (
  `id` int(11) NOT NULL,
  `take_id` int(11) NOT NULL,
  `dol` date NOT NULL,
  `presentee` tinyint(1) NOT NULL,
  `thOrPr` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `AttMarks`
--

CREATE TABLE `AttMarks` (
  `id` int(11) NOT NULL,
  `take_id` int(11) NOT NULL,
  `marks` varchar(45) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `CA`
--

CREATE TABLE `CA` (
  `id` int(11) NOT NULL,
  `take_id` int(11) NOT NULL,
  `marks` varchar(45) NOT NULL,
  `expno` int(2) NOT NULL,
  `assignno` int(2) NOT NULL,
  `attendance` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Course`
--

CREATE TABLE `Course` (
  `course_id` int(11) NOT NULL,
  `sse` varchar(45) NOT NULL,
  `sem` varchar(10) NOT NULL,
  `PR` int(2) NOT NULL,
  `ORR` int(2) NOT NULL,
  `TH` int(3) NOT NULL,
  `TW` int(2) NOT NULL,
  `IA` int(2) NOT NULL,
  `totalM` int(3) NOT NULL,
  `THCr` int(2) NOT NULL,
  `PRCr` int(2) NOT NULL,
  `TutCr` int(11) NOT NULL,
  `totalC` varchar(45) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Department`
--

CREATE TABLE `Department` (
  `dept_id` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `hod` varchar(10) NOT NULL,
  `budget` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Faculty`
--

CREATE TABLE `Faculty` (
  `fac_id` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `per_adress` mediumtext NOT NULL,
  `nes_adress` mediumtext NOT NULL,
  `phoneno` varchar(11) NOT NULL,
  `email` varchar(60) NOT NULL,
  `qualification` varchar(45) NOT NULL,
  `experiance` int(2) NOT NULL,
  `doj` date NOT NULL,
  `dob` date NOT NULL,
  `salary` int(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Grade`
--

CREATE TABLE `Grade` (
  `id` int(11) NOT NULL,
  `take_id` int(11) NOT NULL,
  `TH` int(3) NOT NULL,
  `ORR` int(2) NOT NULL,
  `TW` int(2) NOT NULL,
  `PR` int(2) NOT NULL,
  `IA` int(2) NOT NULL,
  `total` int(3) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `OUTCOMES`
--

CREATE TABLE `OUTCOMES` (
  `id` int(11) NOT NULL,
  `tlo_id` int(11) NOT NULL,
  `outcome` mediumtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Student`
--

CREATE TABLE `Student` (
  `rollno` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `adress` mediumtext NOT NULL,
  `class` varchar(4) NOT NULL,
  `sem` varchar(10) NOT NULL,
  `doa` date NOT NULL,
  `dob` date NOT NULL,
  `phoneno` varchar(10) NOT NULL,
  `dept` varchar(6) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Takes`
--

CREATE TABLE `Takes` (
  `take_id` int(11) NOT NULL,
  `roll_no` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `year` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Teaches`
--

CREATE TABLE `Teaches` (
  `id` int(11) NOT NULL,
  `fac_id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `year` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Test`
--

CREATE TABLE `Test` (
  `id` int(11) NOT NULL,
  `take_id` int(11) NOT NULL,
  `t1` int(2) NOT NULL,
  `t2` int(2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `TLO`
--

CREATE TABLE `TLO` (
  `tlo_id` int(11) NOT NULL,
  `parent` int(11) NOT NULL,
  `topic` mediumtext NOT NULL,
  `course_id` varchar(10) NOT NULL,
  `topic_id` varchar(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `Access`
--
ALTER TABLE `Access`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `Attendance`
--
ALTER TABLE `Attendance`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `AttMarks`
--
ALTER TABLE `AttMarks`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `CA`
--
ALTER TABLE `CA`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `Course`
--
ALTER TABLE `Course`
  ADD PRIMARY KEY (`course_id`);

--
-- Tablo için indeksler `Department`
--
ALTER TABLE `Department`
  ADD PRIMARY KEY (`dept_id`);

--
-- Tablo için indeksler `Faculty`
--
ALTER TABLE `Faculty`
  ADD PRIMARY KEY (`fac_id`);

--
-- Tablo için indeksler `Grade`
--
ALTER TABLE `Grade`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `OUTCOMES`
--
ALTER TABLE `OUTCOMES`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `Student`
--
ALTER TABLE `Student`
  ADD PRIMARY KEY (`rollno`);

--
-- Tablo için indeksler `Takes`
--
ALTER TABLE `Takes`
  ADD PRIMARY KEY (`take_id`);

--
-- Tablo için indeksler `Teaches`
--
ALTER TABLE `Teaches`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `Test`
--
ALTER TABLE `Test`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `TLO`
--
ALTER TABLE `TLO`
  ADD PRIMARY KEY (`tlo_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `Access`
--
ALTER TABLE `Access`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Attendance`
--
ALTER TABLE `Attendance`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `AttMarks`
--
ALTER TABLE `AttMarks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `CA`
--
ALTER TABLE `CA`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Course`
--
ALTER TABLE `Course`
  MODIFY `course_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Department`
--
ALTER TABLE `Department`
  MODIFY `dept_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Faculty`
--
ALTER TABLE `Faculty`
  MODIFY `fac_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Grade`
--
ALTER TABLE `Grade`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `OUTCOMES`
--
ALTER TABLE `OUTCOMES`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Student`
--
ALTER TABLE `Student`
  MODIFY `rollno` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Takes`
--
ALTER TABLE `Takes`
  MODIFY `take_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Teaches`
--
ALTER TABLE `Teaches`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `Test`
--
ALTER TABLE `Test`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `TLO`
--
ALTER TABLE `TLO`
  MODIFY `tlo_id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
