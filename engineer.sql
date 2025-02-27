-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Feb 27, 2025 at 08:50 AM
-- Server version: 8.0.30
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `engineer`
--

-- --------------------------------------------------------

--
-- Table structure for table `annual_inspection`
--

CREATE TABLE `annual_inspection` (
  `id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `barangay` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `structure` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `date` date NOT NULL,
  `or_number` int NOT NULL,
  `date_paid` date NOT NULL,
  `amount` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `annual_inspection`
--

INSERT INTO `annual_inspection` (`id`, `name`, `barangay`, `structure`, `date`, `or_number`, `date_paid`, `amount`) VALUES
(4, 'sdf', 'sdf', 'sdf', '2025-02-26', 123, '2025-02-26', 0),
(5, 'sdf', 'sdf', 'sdf', '2025-02-21', 123, '2025-02-27', 0),
(6, 'asda', 'asdd', 'asd', '2025-02-26', 123213, '2025-02-26', 0),
(7, 'erw', 'werwe', 'wer', '2025-02-26', 324, '2025-02-26', 0),
(8, 'ygytf', 'Poblacion', 'althea\'s Fisbolan', '2025-02-26', 123, '2025-02-26', 0),
(9, 'asd', 'asd', 'asdas', '2025-02-26', 234234, '2025-02-26', 0),
(10, 'jay', 'poblacion', 'althea\'s fisbolan', '2025-02-27', 123, '2025-02-27', 300),
(11, 'ASssdfsd', 'Poblacion', 'sdfsdf', '2025-02-27', 12312, '2025-02-27', 32);

-- --------------------------------------------------------

--
-- Table structure for table `building_permit`
--

CREATE TABLE `building_permit` (
  `id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `date` date NOT NULL,
  `type_of_application` varchar(255) NOT NULL,
  `status_of_application` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `certificate`
--

CREATE TABLE `certificate` (
  `id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `company` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `date` date NOT NULL,
  `purpose` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `certificate`
--

INSERT INTO `certificate` (`id`, `name`, `company`, `date`, `purpose`) VALUES
(6, 'Mary Grechelle A. Algo', 'DOH-EVCHD', '2025-02-26', 'Follow-up ducoments for infra projects under GAA 2023'),
(7, 'Michael L. Villero', 'DOH-EVCHD', '2025-02-26', 'Follow-up ducoments for infra projects under GAA 2023'),
(8, 'Danilo Gorilla', 'DOH-EVCHD', '2025-02-26', 'Follow-up ducoments for infra projects under GAA 2023'),
(9, 'jay sabalo', 'althea fisbolan ', '2025-02-27', 'secret'),
(10, 'jay sabalo', 'althea fisbolan ', '2025-02-27', 'secret'),
(11, 'asd', 'asd', '2025-02-27', ''),
(12, 'dfs', 'sdf', '2025-02-27', 'sdfsdfsdf');

-- --------------------------------------------------------

--
-- Table structure for table `maintenance_work`
--

CREATE TABLE `maintenance_work` (
  `id` int NOT NULL,
  `request_by` varchar(255) NOT NULL,
  `office` varchar(255) NOT NULL,
  `work` varchar(255) NOT NULL,
  `date_request` date NOT NULL,
  `date_completed` date NOT NULL,
  `remarks` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `annual_inspection`
--
ALTER TABLE `annual_inspection`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `building_permit`
--
ALTER TABLE `building_permit`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `certificate`
--
ALTER TABLE `certificate`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `maintenance_work`
--
ALTER TABLE `maintenance_work`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `annual_inspection`
--
ALTER TABLE `annual_inspection`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `building_permit`
--
ALTER TABLE `building_permit`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `certificate`
--
ALTER TABLE `certificate`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `maintenance_work`
--
ALTER TABLE `maintenance_work`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
