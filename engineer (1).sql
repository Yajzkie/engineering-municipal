-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 07, 2025 at 08:20 AM
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
(5, 'sdf', 'Baugo', 'sdf', '2025-02-21', 123, '2025-02-27', 0),
(6, 'asda', 'asdd', 'asd', '2025-02-26', 123213, '2025-02-26', 0),
(7, 'erw', '', 'wer', '2025-02-26', 324, '2025-02-27', 0),
(8, 'ygytf', '', 'althea\'s Fisbolan', '2025-02-26', 123, '2025-02-26', 0),
(9, 'asd', 'asd', 'asdas', '2025-02-26', 234234, '2025-02-26', 0),
(10, 'jay', 'poblacion', 'althea\'s fisbolan', '2025-02-27', 123, '2025-02-27', 300),
(11, 'ASssdfsd', 'Poblacion', 'sdfsdf', '2025-02-27', 12312, '2025-02-27', 32),
(13, 'a', 'Banahao', 'b', '2025-03-07', 123, '2025-02-27', 100);

-- --------------------------------------------------------

--
-- Table structure for table `barangay_program_work`
--

CREATE TABLE `barangay_program_work` (
  `id` int NOT NULL,
  `barangay` varchar(255) NOT NULL,
  `endorsed_by` varchar(255) NOT NULL,
  `date_endorsed` date NOT NULL,
  `title_of_project` varchar(255) NOT NULL,
  `amount_of_project` int NOT NULL,
  `source_of_funds` varchar(255) NOT NULL,
  `pow` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ded` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `target_date_completion` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `barangay_program_work`
--

INSERT INTO `barangay_program_work` (`id`, `barangay`, `endorsed_by`, `date_endorsed`, `title_of_project`, `amount_of_project`, `source_of_funds`, `pow`, `ded`, `status`, `target_date_completion`) VALUES
(3, 'd', 'e', '2025-03-04', 'f', 1534, 'dfdsfsdf', 'YJCL', '', 'ON-GOING', '2025-03-04'),
(4, 'g', 'h', '2025-03-04', 'i', 1, 'dsfsdf', 'RCE', 'YJCL', 'NOT YET STRARTED', '2025-03-04'),
(5, 'sdfsd', 'sdfsd', '2025-03-07', 'sdfsd', 345, 'dsfsf', 'YJCL', '', 'ON-GOING', '2025-03-07'),
(6, '6456', 'ffgd', '2025-03-07', 'dfg', 234, 'dfg', 'YJCL', '', 'ON-GOING', '2025-03-07'),
(7, 'retert', 'erter', '2025-03-07', 'erter', 23234, 'asdasd', 'YJCL', 'YJCL', 'ON-GOING', '2025-03-07'),
(8, 'sdfsd', 'sdfsd', '2025-03-07', 'sdfsd', 23423, 'sdfsdf', 'YJCL', 'GRN', 'NOT YET STRARTED', '2025-03-28'),
(9, 'Cawayanan', 'sdfsd', '2025-03-07', 'sdf', 42343, 'sdfds', 'YJCL', 'YJCL', 'ON-GOING', '2025-03-07'),
(10, 'Baugo', 'fdgfdg', '2025-03-07', 'dfgfd', 23423, 'sdsfsfds', 'YJCL', 'RCE', 'ON-GOING', '2025-03-07');

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

--
-- Dumping data for table `building_permit`
--

INSERT INTO `building_permit` (`id`, `name`, `date`, `type_of_application`, `status_of_application`) VALUES
(3, 'sdfds', '2025-03-03', 'Excavation Permit', 'sdfdsf'),
(5, 'HFGH', '2025-03-04', 'Occupancy Permit', 'DSFDS');

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
(10, 'jay sabalo', 'althea fisbolan ', '2025-02-21', 'secret'),
(11, 'asd', 'asd', '2025-02-27', ''),
(12, 'dfs', 'sdf', '2025-02-27', 'sdfsdfsdf'),
(13, 'fgh', 'fghfg', '2025-02-28', 'fghf'),
(15, 'dsf', 'sdf', '2025-03-07', 'sdfsd');

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
  `date_complete` date NOT NULL,
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `maintenance_work`
--

INSERT INTO `maintenance_work` (`id`, `request_by`, `office`, `work`, `date_request`, `date_complete`, `remark`) VALUES
(2, 'jay', 'sd', 'sdf', '2025-03-04', '2025-03-04', 'sdf'),
(3, 'a', 'b', 'c', '2025-03-06', '2025-03-06', 'd'),
(4, 'e', 'f', 'g', '2025-03-06', '2025-03-06', 'h');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `annual_inspection`
--
ALTER TABLE `annual_inspection`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `barangay_program_work`
--
ALTER TABLE `barangay_program_work`
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
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `barangay_program_work`
--
ALTER TABLE `barangay_program_work`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `building_permit`
--
ALTER TABLE `building_permit`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `certificate`
--
ALTER TABLE `certificate`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `maintenance_work`
--
ALTER TABLE `maintenance_work`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
