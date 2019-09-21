/*
SQLyog Ultimate v11.11 (32 bit)
MySQL - 5.0.51b-community-nt-log : Database - siswa
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`siswa` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `siswa`;

/*Table structure for table `dataguru` */

DROP TABLE IF EXISTS `dataguru`;

CREATE TABLE `dataguru` (
  `NIP` varchar(20) NOT NULL,
  `NamaGuru` varchar(35) default NULL,
  `JenisKelamin` varchar(20) default NULL,
  `Pendidikan` varchar(20) default NULL,
  `Prodi` varchar(20) default NULL,
  `Alamat` tinytext,
  `NoTelepon` varchar(18) default NULL,
  PRIMARY KEY  (`NIP`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `dataguru` */

LOCK TABLES `dataguru` WRITE;

insert  into `dataguru`(`NIP`,`NamaGuru`,`JenisKelamin`,`Pendidikan`,`Prodi`,`Alamat`,`NoTelepon`) values ('1','AYU','Perempuan','SMP/Sederajat','IPA','JAMBI','08988'),('2','AYI','Perempuan','D3/Sederajat','B. INGGRIS','JAMBI','988'),('3','AYA','Perempuan','D3/Sederajat','B. INDO','JBI','867'),('4','AYEW','Perempuan','SMA/Sederajat','IPS','JBI','09988'),('5','AYIB','Laki-laki','S2/Sederajat','Kesenian','JBI','6'),('6','JOJON','Laki-laki','S2/Sederajat','MTK','JBI','76');

UNLOCK TABLES;

/*Table structure for table `datanilai` */

DROP TABLE IF EXISTS `datanilai`;

CREATE TABLE `datanilai` (
  `NIS` varchar(15) default NULL,
  `NamaSiswa` varchar(35) default NULL,
  `Kelas` varchar(4) default NULL,
  `Mapel1` varchar(4) default NULL,
  `Nilai1` varchar(4) default NULL,
  `Mapel2` varchar(4) default NULL,
  `Nilai2` varchar(4) default NULL,
  `Mapel3` varchar(4) default NULL,
  `Nilai3` varchar(4) default NULL,
  `Mapel4` varchar(4) default NULL,
  `Nilai4` varchar(4) default NULL,
  `Mapel5` varchar(4) default NULL,
  `Nilai5` varchar(4) default NULL,
  `Mapel6` varchar(4) default NULL,
  `Nilai6` varchar(4) default NULL,
  `JumlahNilai` varchar(4) default NULL,
  `RataRata` varchar(4) default NULL,
  `NilaiHuruf` varchar(4) default NULL,
  `Keterangan` varchar(35) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `datanilai` */

LOCK TABLES `datanilai` WRITE;

UNLOCK TABLES;

/*Table structure for table `datasiswa` */

DROP TABLE IF EXISTS `datasiswa`;

CREATE TABLE `datasiswa` (
  `NIS` varchar(10) NOT NULL,
  `NamaSiswa` varchar(35) default NULL,
  `JenisKelamin` varchar(20) default NULL,
  `TanggalLahir` date default NULL,
  `Kelas` varchar(4) default NULL,
  `Alamat` varchar(40) default NULL,
  `NoTelepon` decimal(18,0) default NULL,
  PRIMARY KEY  (`NIS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `datasiswa` */

LOCK TABLES `datasiswa` WRITE;

insert  into `datasiswa`(`NIS`,`NamaSiswa`,`JenisKelamin`,`TanggalLahir`,`Kelas`,`Alamat`,`NoTelepon`) values ('10','kjj','Laki-laki','2015-07-01','1','jambi',8),('1010','ajaj','Laki-laki','2015-07-08','1','k',2),('2','Ana','Perempuan','2015-07-01','2','jj',2),('43','hdkjak','Laki-laki','0000-00-00','1','dassaa',121),('66666','jjjjjjj','Laki-laki','0000-00-00','1','hhhhhh',9999999),('87','jjjk','Laki-laki','2015-07-08','1','kks',2332),('888','hhhhhhh','Laki-laki','0000-00-00','3','jjjj',0),('9','susan','Perempuan','2015-07-01','1','jambi',992),('9000','ayam','Laki-laki','2015-07-09','2','ijj',8889),('dsd','sds','Laki-laki','0000-00-00','1','dfsd',2232323);

UNLOCK TABLES;

/*Table structure for table `login` */

DROP TABLE IF EXISTS `login`;

CREATE TABLE `login` (
  `Username` varchar(10) NOT NULL,
  `Password` varchar(10) default NULL,
  `Type` varchar(15) default NULL,
  PRIMARY KEY  (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `login` */

LOCK TABLES `login` WRITE;

insert  into `login`(`Username`,`Password`,`Type`) values ('Eko','Eko','Teacher'),('Heri','Heri','Student'),('Mawan','Mawan','Student'),('Melli','Melli','Administrator'),('Shinta','123','Super User');

UNLOCK TABLES;

/*Table structure for table `matapelajaran` */

DROP TABLE IF EXISTS `matapelajaran`;

CREATE TABLE `matapelajaran` (
  `KodeMapel` varchar(15) NOT NULL,
  `Mapel` varchar(30) default NULL,
  `NIP` varchar(20) default NULL,
  `NamaGuru` varchar(30) default NULL,
  `Kelas` varchar(4) default NULL,
  PRIMARY KEY  (`KodeMapel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `matapelajaran` */

LOCK TABLES `matapelajaran` WRITE;

UNLOCK TABLES;

/*Table structure for table `prodi` */

DROP TABLE IF EXISTS `prodi`;

CREATE TABLE `prodi` (
  `NamaProdi` varchar(30) NOT NULL,
  PRIMARY KEY  (`NamaProdi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `prodi` */

LOCK TABLES `prodi` WRITE;

insert  into `prodi`(`NamaProdi`) values ('B. INDO'),('B. INGGRIS'),('B. JEPANG'),('IPA'),('IPS'),('Kesenian'),('MTK');

UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
