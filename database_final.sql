-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 19, 2020 at 01:52 PM
-- Server version: 10.4.10-MariaDB
-- PHP Version: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `viovasof_cse`
--

-- --------------------------------------------------------

--
-- Table structure for table `access`
--

DROP TABLE IF EXISTS `access`;
CREATE TABLE IF NOT EXISTS `access` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `user_id` int(12) NOT NULL,
  `pass` varchar(300) NOT NULL,
  `type` varchar(12) NOT NULL,
  `faculty_id` int(11) DEFAULT NULL,
  `department_id` int(12) DEFAULT NULL,
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `access`
--

INSERT INTO `access` (`id`, `name`, `surname`, `user_id`, `pass`, `type`, `faculty_id`, `department_id`, `updated_at`) VALUES
(1, '666', '666', 666, '666', '0', NULL, NULL, '2020-06-18 15:45:02'),
(2, '123', '2', 123, '123', '2', 2, 7, '2020-06-18 18:02:41'),
(3, '111', '', 111, '111', '1', NULL, NULL, '2020-06-18 15:47:25'),
(4, '555', '', 555, '555', '1', NULL, NULL, '2020-06-18 16:17:48'),
(5, '222', '', 222, '222', '1', NULL, NULL, '2020-06-18 16:19:23'),
(7, '19', '', 19, '19', '2', NULL, NULL, '2020-06-18 18:28:15'),
(8, '521521', '', 521521, '521521', '1', NULL, NULL, '2020-06-18 22:48:29');

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
CREATE TABLE IF NOT EXISTS `courses` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `instructor_id` int(12) NOT NULL,
  `department_id` int(12) NOT NULL,
  `start_end` int(2) NOT NULL,
  `day` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=102 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`id`, `code`, `name`, `instructor_id`, `department_id`, `start_end`, `day`) VALUES
(98, 'CLASSCODEBOX', 'coursenameBox', 1, 3, 2, 'wednesday'),
(2, 'CSE103', 'English 1', 1, 1, 1, 'monday'),
(3, 'CSE104', 'Database', 1, 1, 2, 'Tuesday'),
(4, 'CSE201', 'english II', 104, 1, 1, 'Tuesday'),
(5, 'CSE202', 'OOP', 1, 1, 1, 'wednesday'),
(6, 'CSE105', 'Math I', 106, 1, 1, 'Wednesday'),
(7, 'CSE106', 'Physic I', 107, 1, 2, 'Thursday'),
(8, 'CSE107', 'History ', 108, 1, 1, 'Thursday'),
(9, 'CSE108', 'Turkish', 109, 1, 1, 'Friday'),
(10, 'CSE205', 'C++', 110, 1, 2, 'Friday'),
(11, 'CSE309', 'web progrramming', 111, 1, 1, 'Monday'),
(12, 'CSE302', 'Python', 111, 1, 1, 'Friday'),
(13, 'CSE401', 'Software Engineerning', 2, 1, 1, 'wednesday'),
(14, 'CSE307', 'operating system', 115, 1, 2, 'Thursday'),
(15, 'CSE407', 'C# programming language', 103, 1, 1, 'Tuesday'),
(16, 'INE101', 'Math1', 201, 2, 1, 'Monday'),
(17, 'INE102', 'Turkish I', 202, 2, 1, 'Monday'),
(18, 'INE201', 'English ', 203, 2, 2, 'Monday'),
(19, 'INE202', 'Matlab ', 204, 2, 1, 'Monday'),
(20, 'INE301', 'statistic', 205, 2, 1, 'Monday'),
(21, 'INE401', 'Statistic learning & data analysis', 206, 2, 2, 'Monday'),
(22, 'INE103', 'Introdaction to Statistics', 207, 2, 1, 'Tuesday'),
(23, 'INE104', 'english', 208, 2, 1, 'Tuesday'),
(99, 'CSE1034', 'English 1', 2, 1, 1, 'monday'),
(25, 'INE204', 'probibialty', 209, 2, 1, 'Tuesday'),
(26, 'INE402', 'Project', 210, 2, 1, 'Tuesday'),
(27, 'INE302', 'industrial engineering', 210, 2, 1, 'Tuesday'),
(28, 'INE105', 'History', 211, 2, 1, 'Wednesday'),
(29, 'INE205', 'Math', 204, 2, 1, 'Wednesday'),
(30, 'INE304', 'Lab1', 212, 2, 1, 'Thursday'),
(31, 'INE404', 'Staj', 0, 2, 1, ''),
(32, 'INE207', 'Health and safty', 214, 2, 1, 'Friday'),
(33, 'ECON101', 'INTRODACTION TO ECONOMICS', 301, 7, 1, 'Monday'),
(34, 'MATH105', 'INTRODACTION TO CALCULUS', 302, 7, 1, 'Monday'),
(35, 'SOC101', 'INTRODACTION TO SCOCIOLOGY', 303, 7, 1, 'Tuesday'),
(36, 'MAN101', 'Introdaction to Business', 301, 7, 1, 'Tuesday'),
(37, 'ENG101', 'English and Composition', 305, 7, 1, 'Wednesday'),
(38, 'TUR101', 'Turkish', 306, 7, 1, 'Friday'),
(39, 'MAN213', 'Principles of Financial Accounting', 307, 7, 1, 'Monday'),
(40, 'MATH227', 'Introdaction to Linear Algebra', 302, 7, 1, 'Tuesday'),
(41, 'ECON221', 'Introdaction to Prob', 308, 7, 1, 'Tuesday'),
(42, 'HUM200', '', 0, 0, 1, ''),
(43, 'ECON101', 'INTRODACTION TO ECONOMICS', 301, 7, 1, 'Monday'),
(44, 'MATH105', 'INTRODACTION TO CALCULUS', 302, 7, 1, 'Monday'),
(45, 'SOC101', 'INTRODACTION TO SCOCIOLOGY', 303, 7, 1, 'Tuesday'),
(46, 'MAN101', 'Introdaction to Business', 301, 7, 1, 'Tuesday'),
(47, 'ENG101', 'English and Composition', 305, 7, 1, 'Wednesday'),
(48, 'TUR101', 'Turkish', 306, 7, 1, 'Friday'),
(49, 'MAN213', 'Principles of Financial Accounting', 307, 7, 1, 'Monday'),
(50, 'MATH227', 'Introdaction to Linear Algebra', 302, 7, 1, 'Tuesday'),
(51, 'ECON221', 'Introdaction to Prob', 308, 7, 1, 'Tuesday'),
(52, 'HUM200', 'Cultures Civilization ', 309, 7, 1, 'Wednesday'),
(53, 'GE250', 'Collegiate Activites program I', 310, 7, 1, 'Thursday'),
(54, 'LAW313', 'Business Law', 311, 7, 1, 'Monday'),
(55, 'MAN321', 'Corporate Finance', 311, 7, 1, 'Tuesday'),
(56, 'MAN316', 'Organization Theory', 312, 7, 1, 'Wednesday'),
(57, 'MAN403', 'International Business', 313, 7, 1, 'Friday'),
(58, 'PSIR101', 'Interduction to Global Politics', 401, 8, 1, 'Monday'),
(59, 'MGMT171', 'Introduction to Information Technology', 402, 8, 1, 'Tuesday'),
(60, 'MATH105', 'Mathmatics', 403, 8, 1, 'Tuesday'),
(61, 'ENG181', 'Academic English', 404, 8, 1, 'Wednesday'),
(62, '', '', 0, 0, 1, ''),
(63, 'HIST208', 'History', 405, 8, 1, 'Friday'),
(64, 'TUR181', 'Turkish', 406, 8, 1, 'Friday'),
(65, 'PSIR201', 'Theory and Practice of International Relations', 402, 8, 1, 'Tuesday'),
(66, 'PSIR203', 'Politics and Society', 407, 8, 1, 'Wednesday'),
(67, 'STAT201', 'Statistics', 409, 8, 1, 'Wednesday'),
(68, 'MGMT211', ' Business Communication', 410, 8, 1, 'Thursday'),
(69, 'PSIR301', 'Politics of the Middle East', 411, 8, 1, 'Thursday'),
(70, 'PSIR305', 'Foreign Policy Analysis', 412, 8, 1, 'Friday'),
(71, 'PSIR311', 'International Political Economy', 412, 8, 1, 'Friday'),
(72, 'PSIR405', 'International Law ', 414, 8, 1, 'Tuesday'),
(97, 'PHYS429', ' STATISTICAL MECHANICS ', 510, 12, 1, 'Friday'),
(96, 'PHYS425', ' INTRODUCTION TO LASER PHYSICS', 509, 12, 1, 'Thursday'),
(95, 'PHYS301 ', ' INTRODUCTION TO ARCHAEOMETRY', 508, 12, 1, 'Wednesday'),
(94, 'PHYS300 ', 'QUANTUM PHYSICS', 507, 12, 1, 'Wednesday'),
(93, 'PHYS109 ', 'MECHANICS', 506, 12, 1, 'Tuesday'),
(92, 'PHYS110 ', 'ELECTROMAGNETISM', 505, 12, 1, 'Tuesday'),
(91, 'PHYS202 ', 'MODERN PHYSICS', 504, 12, 1, 'Tuesday'),
(90, 'PHYS200', ' BASICS OF SCIENTIFIC COMPUTATION', 503, 12, 1, 'Monday'),
(88, 'PHYS101', 'Physics1', 501, 12, 1, 'Monday'),
(89, 'MATH101', 'Mathmatics', 502, 12, 1, 'Monday'),
(100, 'CSE10345', 'English 3', 1, 1, 2, 'friday'),
(101, 'CSE103456', 'English 34', 3, 1, 2, 'wednesday');

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
CREATE TABLE IF NOT EXISTS `departments` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `faculty_id` int(12) NOT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `departments`
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
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
CREATE TABLE IF NOT EXISTS `faculties` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `faculties`
--

INSERT INTO `faculties` (`id`, `name`) VALUES
(1, 'Engineerings faculty'),
(2, 'Business  Faculty'),
(3, 'Faculty of Science');

-- --------------------------------------------------------

--
-- Table structure for table `instructors`
--

DROP TABLE IF EXISTS `instructors`;
CREATE TABLE IF NOT EXISTS `instructors` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `number` varchar(50) NOT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `instructors`
--

INSERT INTO `instructors` (`id`, `number`, `status`, `created_at`, `updated_at`) VALUES
(1, '111', 1, '2020-06-18 15:47:25', '2020-06-18 15:47:43'),
(2, '555', 1, '2020-06-18 16:17:48', '2020-06-18 16:17:58'),
(3, '222', 1, '2020-06-18 16:19:23', '2020-06-18 16:19:32'),
(4, '521521', 0, '2020-06-18 22:48:29', '2020-06-18 22:48:29');

-- --------------------------------------------------------

--
-- Table structure for table `notes`
--

DROP TABLE IF EXISTS `notes`;
CREATE TABLE IF NOT EXISTS `notes` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `course_id` int(12) NOT NULL,
  `student_id` int(12) NOT NULL,
  `date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `note1` varchar(50) DEFAULT NULL,
  `note2` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notes`
--

INSERT INTO `notes` (`id`, `course_id`, `student_id`, `date`, `note1`, `note2`) VALUES
(3, 2, 123, '2020-06-19 12:53:09', '5', '1'),
(4, 10, 123, '2020-06-18 22:35:28', NULL, NULL),
(5, 5, 123, '2020-06-19 13:05:52', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
CREATE TABLE IF NOT EXISTS `students` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `number` varchar(50) NOT NULL,
  `year` varchar(40) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`id`, `number`, `year`, `created_at`, `updated_at`) VALUES
(1, '123', '2020', '2020-06-18 15:46:13', '2020-06-18 18:02:41'),
(3, '19', '2020', '2020-06-18 18:28:15', '2020-06-18 18:28:15');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
