-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 17, 2024 at 02:20 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `waffle_workout_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `equipment`
--

CREATE TABLE `equipment` (
  `equipment_id` int(10) UNSIGNED NOT NULL,
  `equipment_name` varchar(64) NOT NULL,
  `equipment_img_path` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `goals`
--

CREATE TABLE `goals` (
  `goal_id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL,
  `workout_id` int(10) UNSIGNED NOT NULL,
  `goal_weight` decimal(4,2) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `muscles`
--

CREATE TABLE `muscles` (
  `muscle_id` int(10) UNSIGNED NOT NULL,
  `muscle_name` varchar(64) NOT NULL,
  `muscle_img_path` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `routines`
--

CREATE TABLE `routines` (
  `routine_id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `routine_details`
--

CREATE TABLE `routine_details` (
  `routine_id` int(10) UNSIGNED NOT NULL,
  `week_day_id` int(10) UNSIGNED NOT NULL,
  `workout_day_id` int(10) UNSIGNED NOT NULL,
  `workout_after_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `selected_routines`
--

CREATE TABLE `selected_routines` (
  `user_id` int(10) UNSIGNED NOT NULL,
  `routine_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `types`
--

CREATE TABLE `types` (
  `type_id` int(10) UNSIGNED NOT NULL,
  `type_name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(10) UNSIGNED NOT NULL,
  `user_name` varchar(32) NOT NULL,
  `email` varchar(128) NOT NULL,
  `email_verified` tinyint(1) UNSIGNED NOT NULL DEFAULT 0,
  `password` varchar(256) NOT NULL,
  `remember_token` varchar(64) DEFAULT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_details`
--

CREATE TABLE `user_details` (
  `user_id` int(10) UNSIGNED NOT NULL,
  `weight` decimal(4,2) UNSIGNED NOT NULL,
  `fat_mass` decimal(4,2) UNSIGNED NOT NULL,
  `muscle_mass` decimal(4,2) UNSIGNED NOT NULL,
  `height` decimal(4,2) UNSIGNED NOT NULL,
  `gender` enum('male','female','rather not say') NOT NULL,
  `birthday` date NOT NULL,
  `system` enum('imperial','metric') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `week_days`
--

CREATE TABLE `week_days` (
  `week_day_id` int(10) UNSIGNED NOT NULL,
  `day_name` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `weight_logs`
--

CREATE TABLE `weight_logs` (
  `weight_log_id` int(10) UNSIGNED NOT NULL,
  `weight_log` decimal(4,2) UNSIGNED NOT NULL,
  `fat_mass_log` decimal(4,2) UNSIGNED NOT NULL,
  `muscle_mass_log` decimal(4,2) UNSIGNED NOT NULL,
  `updated_at` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `weight_logs_timeline`
--

CREATE TABLE `weight_logs_timeline` (
  `user_id` int(10) UNSIGNED NOT NULL,
  `weight_log_id` int(10) UNSIGNED NOT NULL,
  `updated_at` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workouts`
--

CREATE TABLE `workouts` (
  `workout_id` int(10) UNSIGNED NOT NULL,
  `workout_name` varchar(64) NOT NULL,
  `workout_img_path` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout_days`
--

CREATE TABLE `workout_days` (
  `workout_day_id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout_day_afters`
--

CREATE TABLE `workout_day_afters` (
  `workout_after_id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout_day_after_details`
--

CREATE TABLE `workout_day_after_details` (
  `workout_after_id` int(10) UNSIGNED NOT NULL,
  `workout_id` int(10) UNSIGNED NOT NULL,
  `weight` decimal(4,2) NOT NULL,
  `workout_time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout_day_details`
--

CREATE TABLE `workout_day_details` (
  `workout_day_id` int(10) UNSIGNED NOT NULL,
  `workout_id` int(10) UNSIGNED NOT NULL,
  `workout_day_name` varchar(64) NOT NULL,
  `workout_weight` decimal(4,2) UNSIGNED DEFAULT NULL,
  `reps` int(10) UNSIGNED NOT NULL,
  `sets` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout_details`
--

CREATE TABLE `workout_details` (
  `workout_id` int(10) UNSIGNED NOT NULL,
  `muscle_id` int(10) UNSIGNED NOT NULL,
  `type_id` int(10) UNSIGNED NOT NULL,
  `equipment_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout_logs`
--

CREATE TABLE `workout_logs` (
  `workout_log_id` int(10) UNSIGNED NOT NULL,
  `workout_id` int(10) UNSIGNED NOT NULL,
  `weight` decimal(4,2) UNSIGNED NOT NULL,
  `reps` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout_logs_timeline`
--

CREATE TABLE `workout_logs_timeline` (
  `user_id` int(10) UNSIGNED NOT NULL,
  `workout_log_id` int(10) UNSIGNED NOT NULL,
  `updated_at` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `equipment`
--
ALTER TABLE `equipment`
  ADD PRIMARY KEY (`equipment_id`),
  ADD UNIQUE KEY `equipment_name` (`equipment_name`);

--
-- Indexes for table `goals`
--
ALTER TABLE `goals`
  ADD PRIMARY KEY (`goal_id`),
  ADD UNIQUE KEY `user_id` (`user_id`,`workout_id`),
  ADD KEY `g_workout_id` (`workout_id`);

--
-- Indexes for table `muscles`
--
ALTER TABLE `muscles`
  ADD PRIMARY KEY (`muscle_id`),
  ADD UNIQUE KEY `muscle_name` (`muscle_name`);

--
-- Indexes for table `routines`
--
ALTER TABLE `routines`
  ADD PRIMARY KEY (`routine_id`),
  ADD KEY `r_user_id` (`user_id`);

--
-- Indexes for table `routine_details`
--
ALTER TABLE `routine_details`
  ADD KEY `routine_id` (`routine_id`),
  ADD KEY `workout_day_id` (`workout_day_id`),
  ADD KEY `workout_after_id` (`workout_after_id`),
  ADD KEY `rd_week_day_id` (`week_day_id`);

--
-- Indexes for table `selected_routines`
--
ALTER TABLE `selected_routines`
  ADD PRIMARY KEY (`user_id`),
  ADD KEY `sr_routine_id` (`routine_id`);

--
-- Indexes for table `types`
--
ALTER TABLE `types`
  ADD PRIMARY KEY (`type_id`),
  ADD UNIQUE KEY `type_name` (`type_name`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `user_name` (`user_name`);

--
-- Indexes for table `user_details`
--
ALTER TABLE `user_details`
  ADD UNIQUE KEY `ui_user_details_user_id` (`user_id`);

--
-- Indexes for table `week_days`
--
ALTER TABLE `week_days`
  ADD PRIMARY KEY (`week_day_id`);

--
-- Indexes for table `weight_logs`
--
ALTER TABLE `weight_logs`
  ADD PRIMARY KEY (`weight_log_id`);

--
-- Indexes for table `weight_logs_timeline`
--
ALTER TABLE `weight_logs_timeline`
  ADD PRIMARY KEY (`user_id`,`weight_log_id`),
  ADD KEY `weight_log_id` (`weight_log_id`);

--
-- Indexes for table `workouts`
--
ALTER TABLE `workouts`
  ADD PRIMARY KEY (`workout_id`),
  ADD UNIQUE KEY `workout_name` (`workout_name`);

--
-- Indexes for table `workout_days`
--
ALTER TABLE `workout_days`
  ADD PRIMARY KEY (`workout_day_id`),
  ADD KEY `wd_user_id` (`user_id`);

--
-- Indexes for table `workout_day_afters`
--
ALTER TABLE `workout_day_afters`
  ADD PRIMARY KEY (`workout_after_id`),
  ADD KEY `wda_user_id` (`user_id`);

--
-- Indexes for table `workout_day_after_details`
--
ALTER TABLE `workout_day_after_details`
  ADD UNIQUE KEY `workout_after_id` (`workout_after_id`,`workout_id`),
  ADD KEY `workout_id` (`workout_id`);

--
-- Indexes for table `workout_day_details`
--
ALTER TABLE `workout_day_details`
  ADD UNIQUE KEY `workout_day_id_2` (`workout_day_id`,`workout_id`),
  ADD KEY `workout_id` (`workout_id`),
  ADD KEY `workout_day_id` (`workout_day_id`);

--
-- Indexes for table `workout_details`
--
ALTER TABLE `workout_details`
  ADD UNIQUE KEY `workout_id` (`workout_id`,`muscle_id`,`type_id`,`equipment_id`),
  ADD KEY `wd_equipment_id` (`equipment_id`),
  ADD KEY `wd_muscle_id` (`muscle_id`),
  ADD KEY `wd_type_id` (`type_id`);

--
-- Indexes for table `workout_logs`
--
ALTER TABLE `workout_logs`
  ADD PRIMARY KEY (`workout_log_id`),
  ADD KEY `wl_workout_id` (`workout_id`);

--
-- Indexes for table `workout_logs_timeline`
--
ALTER TABLE `workout_logs_timeline`
  ADD PRIMARY KEY (`user_id`,`workout_log_id`),
  ADD KEY `workout_log_id` (`workout_log_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `equipment`
--
ALTER TABLE `equipment`
  MODIFY `equipment_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `goals`
--
ALTER TABLE `goals`
  MODIFY `goal_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `muscles`
--
ALTER TABLE `muscles`
  MODIFY `muscle_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `routines`
--
ALTER TABLE `routines`
  MODIFY `routine_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `types`
--
ALTER TABLE `types`
  MODIFY `type_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `week_days`
--
ALTER TABLE `week_days`
  MODIFY `week_day_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `weight_logs`
--
ALTER TABLE `weight_logs`
  MODIFY `weight_log_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workouts`
--
ALTER TABLE `workouts`
  MODIFY `workout_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workout_days`
--
ALTER TABLE `workout_days`
  MODIFY `workout_day_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workout_day_afters`
--
ALTER TABLE `workout_day_afters`
  MODIFY `workout_after_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workout_logs`
--
ALTER TABLE `workout_logs`
  MODIFY `workout_log_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `goals`
--
ALTER TABLE `goals`
  ADD CONSTRAINT `g_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `g_workout_id` FOREIGN KEY (`workout_id`) REFERENCES `workouts` (`workout_id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `routines`
--
ALTER TABLE `routines`
  ADD CONSTRAINT `r_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `routine_details`
--
ALTER TABLE `routine_details`
  ADD CONSTRAINT `rd_routine_id` FOREIGN KEY (`routine_id`) REFERENCES `routines` (`routine_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rd_week_day_id` FOREIGN KEY (`week_day_id`) REFERENCES `week_days` (`week_day_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rd_workout_after_id` FOREIGN KEY (`workout_after_id`) REFERENCES `workout_day_afters` (`workout_after_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rd_workout_day_id` FOREIGN KEY (`workout_day_id`) REFERENCES `workout_days` (`workout_day_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `selected_routines`
--
ALTER TABLE `selected_routines`
  ADD CONSTRAINT `sr_routine_id` FOREIGN KEY (`routine_id`) REFERENCES `routines` (`routine_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `sr_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user_details`
--
ALTER TABLE `user_details`
  ADD CONSTRAINT `ud_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `weight_logs_timeline`
--
ALTER TABLE `weight_logs_timeline`
  ADD CONSTRAINT `wlt_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `wlt_weight_log_id` FOREIGN KEY (`weight_log_id`) REFERENCES `weight_logs` (`weight_log_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `workout_days`
--
ALTER TABLE `workout_days`
  ADD CONSTRAINT `wd_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `workout_day_afters`
--
ALTER TABLE `workout_day_afters`
  ADD CONSTRAINT `wda_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `workout_day_after_details`
--
ALTER TABLE `workout_day_after_details`
  ADD CONSTRAINT `wdad_workout_after_id` FOREIGN KEY (`workout_after_id`) REFERENCES `workout_day_afters` (`workout_after_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `wdad_workout_id` FOREIGN KEY (`workout_id`) REFERENCES `workouts` (`workout_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `workout_day_details`
--
ALTER TABLE `workout_day_details`
  ADD CONSTRAINT `wdd_workout_day_id` FOREIGN KEY (`workout_day_id`) REFERENCES `workout_days` (`workout_day_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `wdd_workout_id` FOREIGN KEY (`workout_id`) REFERENCES `workouts` (`workout_id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `workout_details`
--
ALTER TABLE `workout_details`
  ADD CONSTRAINT `wd_equipment_id` FOREIGN KEY (`equipment_id`) REFERENCES `equipment` (`equipment_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `wd_muscle_id` FOREIGN KEY (`muscle_id`) REFERENCES `muscles` (`muscle_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `wd_type_id` FOREIGN KEY (`type_id`) REFERENCES `types` (`type_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `wd_workout_id` FOREIGN KEY (`workout_id`) REFERENCES `workouts` (`workout_id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `workout_logs`
--
ALTER TABLE `workout_logs`
  ADD CONSTRAINT `wl_workout_id` FOREIGN KEY (`workout_id`) REFERENCES `workouts` (`workout_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `workout_logs_timeline`
--
ALTER TABLE `workout_logs_timeline`
  ADD CONSTRAINT `wlt_workout_logs_id` FOREIGN KEY (`workout_log_id`) REFERENCES `workout_logs` (`workout_log_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `wolt_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
