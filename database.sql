-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 17 Haz 2020, 11:10:54
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
  `surname` varchar(50) NOT NULL,
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
  `status` int(11) NOT NULL DEFAULT 0,
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
  `start` varchar(50) NOT NULL,
  `end` varchar(50) NOT NULL,
  `day` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `courses`
--

INSERT INTO `courses` (`id`, `code`, `name`, `instructor_id`, `department_id`, `start`, `end`, `day`) VALUES
(1, 'CSE102', 'INTRODACTION TO Software engineering', 101, 1, '9:00 ', '12:00', 'monday'),
(2, 'CSE103', 'English 1', 102, 1, '13:00', '16:00', 'monday'),
(3, 'CSE104', 'Database', 103, 1, '13:00', '15:00', 'Tuesday'),
(4, 'CSE201', 'english II', 104, 1, '9:00', '12:00', 'Tuesday'),
(5, 'CSE202', 'OOP', 105, 1, '9:00', '12:00', 'Wednesday'),
(6, 'CSE105', 'Math I', 106, 1, '13:00', '16:00', 'Wednesday'),
(7, 'CSE106', 'Physic I', 107, 1, '9:00', '12:00', 'Thursday'),
(8, 'CSE107', 'History ', 108, 1, '13:00', '15:00', 'Thursday'),
(9, 'CSE108', 'Turkish', 109, 1, '10:00', '12:00', 'Friday'),
(10, 'CSE205', 'C++', 110, 1, '13:00', '17:00', 'Friday'),
(11, 'CSE309', 'web progrramming', 111, 1, '9:00', '12:00', 'Monday'),
(12, 'CSE302', 'Python', 111, 1, '13::00', '15:00', 'Friday'),
(13, 'CSE401', 'Software Engineerning', 110, 1, '9:00', '13:00', 'wednesday'),
(14, 'CSE307', 'operating system', 115, 1, '13:00', '17:00', 'Thursday'),
(15, 'CSE407', 'C# programming language', 103, 1, '9:00', '12:00', 'Tuesday'),
(16, 'INE101', 'Math1', 201, 2, '9:00', '12:00', 'Monday'),
(17, 'INE102', 'Turkish I', 202, 2, '13:00', '15:00', 'Monday'),
(18, 'INE201', 'English ', 203, 2, '9:00', '12:00', 'Monday'),
(19, 'INE202', 'Matlab ', 204, 2, '13:00', '17:00', 'Monday'),
(20, 'INE301', 'statistic', 205, 2, '9:00', '12:00', 'Monday'),
(21, 'INE401', 'Statistic learning & data analysis', 206, 2, '13:00', '16:00', 'Monday'),
(22, 'INE103', 'Introdaction to Statistics', 207, 2, '9:00', '12:00', 'Tuesday'),
(23, 'INE104', 'english', 208, 2, '13:00', '17:00', 'Tuesday'),
(24, 'INE203', 'Physic', 209, 2, '9:00', '11:00', 'Tuesday'),
(25, 'INE204', 'probibialty', 209, 2, '13:00', '15:00', 'Tuesday'),
(26, 'INE402', 'Project', 210, 2, '9:00', '11:00', 'Tuesday'),
(27, 'INE302', 'industrial engineering', 210, 2, '13:00', '15:00', 'Tuesday'),
(28, 'INE105', 'History', 211, 2, '9:00', '11:00', 'Wednesday'),
(29, 'INE205', 'Math', 204, 2, '9:00', '12:00', 'Wednesday'),
(30, 'INE304', 'Lab1', 212, 2, '9:00', '12:00', 'Thursday'),
(31, 'INE404', 'Staj', 0, 2, '', '', ''),
(32, 'INE207', 'Health and safty', 214, 2, '13:00', '15:00', 'Friday'),
(33, 'ECON101', 'INTRODACTION TO ECONOMICS', 301, 7, '9:00', '12:00', 'Monday'),
(34, 'MATH105', 'INTRODACTION TO CALCULUS', 302, 7, '13:00', '17:00', 'Monday'),
(35, 'SOC101', 'INTRODACTION TO SCOCIOLOGY', 303, 7, '9:00', '11:00', 'Tuesday'),
(36, 'MAN101', 'Introdaction to Business', 301, 7, '13:00', '15:00', 'Tuesday'),
(37, 'ENG101', 'English and Composition', 305, 7, '10:00', '12:00', 'Wednesday'),
(38, 'TUR101', 'Turkish', 306, 7, '13:00', '15:00', 'Friday'),
(39, 'MAN213', 'Principles of Financial Accounting', 307, 7, '9:00', '12:00', 'Monday'),
(40, 'MATH227', 'Introdaction to Linear Algebra', 302, 7, '9:00', '12:00', 'Tuesday'),
(41, 'ECON221', 'Introdaction to Prob', 308, 7, '13:00', '16:00', 'Tuesday'),
(42, 'HUM200', '', 0, 0, '', '', ''),
(43, 'ECON101', 'INTRODACTION TO ECONOMICS', 301, 7, '9:00', '12:00', 'Monday'),
(44, 'MATH105', 'INTRODACTION TO CALCULUS', 302, 7, '13:00', '17:00', 'Monday'),
(45, 'SOC101', 'INTRODACTION TO SCOCIOLOGY', 303, 7, '9:00', '11:00', 'Tuesday'),
(46, 'MAN101', 'Introdaction to Business', 301, 7, '13:00', '15:00', 'Tuesday'),
(47, 'ENG101', 'English and Composition', 305, 7, '10:00', '12:00', 'Wednesday'),
(48, 'TUR101', 'Turkish', 306, 7, '13:00', '15:00', 'Friday'),
(49, 'MAN213', 'Principles of Financial Accounting', 307, 7, '9:00', '12:00', 'Monday'),
(50, 'MATH227', 'Introdaction to Linear Algebra', 302, 7, '9:00', '12:00', 'Tuesday'),
(51, 'ECON221', 'Introdaction to Prob', 308, 7, '13:00', '16:00', 'Tuesday'),
(52, 'HUM200', 'Cultures Civilization ', 309, 7, '9:00', '12:00', 'Wednesday'),
(53, 'GE250', 'Collegiate Activites program I', 310, 7, '13:00', '17:00', 'Thursday'),
(54, 'LAW313', 'Business Law', 311, 7, '9:00', '12:00', 'Monday'),
(55, 'MAN321', 'Corporate Finance', 311, 7, '13:00', '16:00', 'Tuesday'),
(56, 'MAN316', 'Organization Theory', 312, 7, '9:00', '12:00', 'Wednesday'),
(57, 'MAN403', 'International Business', 313, 7, '9:00', '12:00', 'Friday'),
(58, 'PSIR101', 'Interduction to Global Politics', 401, 8, '9:00', '12:00', 'Monday'),
(59, 'MGMT171', 'Introduction to Information Technology', 402, 8, '9:00', '12:00', 'Tuesday'),
(60, 'MATH105', 'Mathmatics', 403, 8, '13:00', '16:00', 'Tuesday'),
(61, 'ENG181', 'Academic English', 404, 8, '10:00', '12:00', 'Wednesday'),
(62, '', '', 0, 0, '', '', ''),
(63, 'HIST208', 'History', 405, 8, '10:00', '12:00', 'Friday'),
(64, 'TUR181', 'Turkish', 406, 8, '13:00', '15:00', 'Friday'),
(65, 'PSIR201', 'Theory and Practice of International Relations', 402, 8, '13:00', '16:00', 'Tuesday'),
(66, 'PSIR203', 'Politics and Society', 407, 8, '9:00', '11:00', 'Wednesday'),
(67, 'STAT201', 'Statistics', 409, 8, '13:00', '16:00', 'Wednesday'),
(68, 'MGMT211', ' Business Communication', 410, 8, '9:00', '12:00', 'Thursday'),
(69, 'PSIR301', 'Politics of the Middle East', 411, 8, '9:00', '12:00', 'Thursday'),
(70, 'PSIR305', 'Foreign Policy Analysis', 412, 8, '9:00', '12:00', 'Friday'),
(71, 'PSIR311', 'International Political Economy', 412, 8, '13:00', '17:00', 'Friday'),
(72, 'PSIR405', 'International Law ', 414, 8, '14:00', '17:00', 'Tuesday'),
(97, 'PHYS429', ' STATISTICAL MECHANICS ', 510, 12, '9:00', '12:00', 'Friday'),
(96, 'PHYS425', ' INTRODUCTION TO LASER PHYSICS', 509, 12, '13:00', '15:00', 'Thursday'),
(95, 'PHYS301 ', ' INTRODUCTION TO ARCHAEOMETRY', 508, 12, '13:00', '17:00', 'Wednesday'),
(94, 'PHYS300 ', 'QUANTUM PHYSICS', 507, 12, '9:00', '12:00', 'Wednesday'),
(93, 'PHYS109 ', 'MECHANICS', 506, 12, '13:00', '16:00', 'Tuesday'),
(92, 'PHYS110 ', 'ELECTROMAGNETISM', 505, 12, '9:00', '12:00', 'Tuesday'),
(91, 'PHYS202 ', 'MODERN PHYSICS', 504, 12, '13:00', '17:00', 'Tuesday'),
(90, 'PHYS200', ' BASICS OF SCIENTIFIC COMPUTATION', 503, 12, '9:00', '12:00', 'Monday'),
(88, 'PHYS101', 'Physics1', 501, 12, '9:00', '12:00', 'Monday'),
(89, 'MATH101', 'Mathmatics', 502, 12, '13:00', '15:00', 'Monday');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `departments`
--

CREATE TABLE `departments` (
  `id` int(12) NOT NULL,
  `faculty_id` int(12) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `departments`
--

INSERT INTO `departments` (`id`, `faculty_id`, `name`) VALUES
(1, 1, 'computer and software engineering'),
(2, 1, 'Industrail  Engineering'),
(3, 1, 'Civil Engineering'),
(7, 2, 'Business'),
(8, 2, 'International Relations'),
(12, 3, 'Mathmatics Department'),
(11, 3, 'Physics Department'),
(13, 3, 'Chemistry Department');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `faculties`
--

CREATE TABLE `faculties` (
  `id` int(12) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `faculties`
--

INSERT INTO `faculties` (`id`, `name`) VALUES
(1, 'Engineerings faculty'),
(2, 'Business  Faculty'),
(3, 'Faculty of Science');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `instructors`
--

CREATE TABLE `instructors` (
  `id` int(12) NOT NULL,
  `number` varchar(50) NOT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
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
-- Tablo için tablo yapısı `notes`
--

CREATE TABLE `notes` (
  `id` int(12) NOT NULL,
  `period` varchar(50) NOT NULL,
  `course_id` int(12) NOT NULL,
  `percentage` varchar(10) NOT NULL,
  `student_id` int(12) NOT NULL,
  `type` varchar(40) NOT NULL,
  `note` varchar(40) NOT NULL,
  `date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `students`
--

CREATE TABLE `students` (
  `id` int(12) NOT NULL,
  `number` varchar(50) NOT NULL,
  `faculty_id` int(12) NOT NULL,
  `department_id` int(12) NOT NULL,
  `year` varchar(40) NOT NULL,
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
-- Tablo için indeksler `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `faculties`
--
ALTER TABLE `faculties`
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
-- Tablo için indeksler `notes`
--
ALTER TABLE `notes`
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
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=98;

--
-- Tablo için AUTO_INCREMENT değeri `departments`
--
ALTER TABLE `departments`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Tablo için AUTO_INCREMENT değeri `faculties`
--
ALTER TABLE `faculties`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
-- Tablo için AUTO_INCREMENT değeri `notes`
--
ALTER TABLE `notes`
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
