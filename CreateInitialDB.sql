CREATE DATABASE `OpenLibraryLabelImg` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `OpenLibraryLabelImg`;

CREATE TABLE `AnnotationClasses` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `ColorArgb` int(11) NOT NULL,
  `Description` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Title` (`Title`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `AnnotationCollections` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `Description` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `BasePath` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `AnnotationImages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileName` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `State` int(11) NOT NULL,
  `Excluded` tinyint(1) NOT NULL,
  `AnnotationCollection_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AnnotationCollection_Id` (`AnnotationCollection_Id`),
  CONSTRAINT `FK_AnnotationImage_AnnotationCollection_Id` FOREIGN KEY (`AnnotationCollection_Id`) REFERENCES `AnnotationCollections` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `YoloNets` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `Description` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `ObjFilePath` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `YoloFilePath` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `WeightFolderPath` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `DataFolderPath` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `TargetResolution` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `AnnotationBoxes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Width` double NOT NULL,
  `Height` double NOT NULL,
  `X` double NOT NULL,
  `Y` double NOT NULL,
  `ClassId` int(11) NOT NULL,
  `AnnotaionImageId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ClassId` (`ClassId`),
  KEY `IX_AnnotaionImageId` (`AnnotaionImageId`),
  CONSTRAINT `FK_AnnotationBoxes_AnnotationClasses_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `AnnotationClasses` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_AnnotationBoxes_AnnotationImages_AnnotaionImageId` FOREIGN KEY (`AnnotaionImageId`) REFERENCES `AnnotationImages` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `AnnotationCollectionAnnotationClasses` (
  `AnnotationCollection_Id` int(11) NOT NULL,
  `AnnotationClass_Id` int(11) NOT NULL,
  PRIMARY KEY (`AnnotationCollection_Id`,`AnnotationClass_Id`),
  KEY `IX_AnnotationCollection_Id` (`AnnotationCollection_Id`),
  KEY `IX_AnnotationClass_Id` (`AnnotationClass_Id`),
  CONSTRAINT `FK_AnnotationClass_Id` FOREIGN KEY (`AnnotationClass_Id`) REFERENCES `AnnotationClasses` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_AnnotationCollection_Id` FOREIGN KEY (`AnnotationCollection_Id`) REFERENCES `AnnotationCollections` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `ClassMaps` (
  `AnnotationClassId` int(11) NOT NULL,
  `MappedId` int(11) NOT NULL,
  `YoloNet_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`AnnotationClassId`,`MappedId`),
  KEY `IX_AnnotationClassId` (`AnnotationClassId`),
  KEY `IX_YoloNet_Id` (`YoloNet_Id`),
  CONSTRAINT `FK_ClassMaps_AnnotationClasses_AnnotationClassId` FOREIGN KEY (`AnnotationClassId`) REFERENCES `AnnotationClasses` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_ClassMaps_YoloNets_YoloNet_Id` FOREIGN KEY (`YoloNet_Id`) REFERENCES `YoloNets` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `YoloNetAnnotationCollections` (
  `YoloNet_Id` int(11) NOT NULL,
  `AnnotationCollection_Id` int(11) NOT NULL,
  PRIMARY KEY (`YoloNet_Id`,`AnnotationCollection_Id`),
  KEY `IX_YoloNet_Id` (`YoloNet_Id`),
  KEY `IX_AnnotationCollection_Id` (`AnnotationCollection_Id`),
  CONSTRAINT `FK_YoloNetAnnotationCollections_YoloNets_YoloNet_Id` FOREIGN KEY (`YoloNet_Id`) REFERENCES `YoloNets` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_YoloNet_AnnotationCollection_Id` FOREIGN KEY (`AnnotationCollection_Id`) REFERENCES `AnnotationCollections` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `__MigrationHistory` (
  `MigrationId` varchar(150) COLLATE utf8_bin NOT NULL,
  `ContextKey` varchar(300) COLLATE utf8_bin NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;