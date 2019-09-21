/*
SQLyog Community v11.12 Beta1 (32 bit)
MySQL - 5.1.36-community-log : Database - cakeshop
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`cakeshop` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `cakeshop`;

/*Table structure for table `datakue` */

DROP TABLE IF EXISTS `datakue`;

CREATE TABLE `datakue` (
  `KodeKue` varchar(10) NOT NULL,
  `NamaKue` varchar(30) DEFAULT NULL,
  `Jenis` varchar(20) DEFAULT NULL,
  `Stok` varchar(10) DEFAULT NULL,
  `HargaSatuan` varchar(20) DEFAULT NULL,
  `HargaJual` varchar(30) DEFAULT NULL,
  `GambarKue` text,
  PRIMARY KEY (`KodeKue`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `datakue` */

insert  into `datakue`(`KodeKue`,`NamaKue`,`Jenis`,`Stok`,`HargaSatuan`,`HargaJual`,`GambarKue`) values ('4','kasasa','Anniversary','0','3555','5555','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\Debug\\New folder\\images (2).jpg'),('1','blackforest','Ulang Tahun','0','50000','75000','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\Debug\\New folder\\big-cake2090.jpg'),('3','Bika Ambon','Kue Basah','0','60000','80000','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\Debug\\New folder\\cemilan-nusantara_f_e6a5bd5ce2efca50329f4919c406fadd.jpg'),('2','Roti Boy','Roti','73','4000','5000','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\Debug\\New folder\\images (6).jpg');

/*Table structure for table `login` */

DROP TABLE IF EXISTS `login`;

CREATE TABLE `login` (
  `User` varchar(15) DEFAULT NULL,
  `Password` varchar(20) DEFAULT NULL,
  `Type` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `login` */

insert  into `login`(`User`,`Password`,`Type`) values ('admin','admin','Administrator'),('david','kasir','Kasir');

/*Table structure for table `pembelian` */

DROP TABLE IF EXISTS `pembelian`;

CREATE TABLE `pembelian` (
  `NoFaktur` varchar(20) DEFAULT NULL,
  `Tanggal` datetime DEFAULT NULL,
  `KodeKue` varchar(20) DEFAULT NULL,
  `NamaKue` varchar(50) DEFAULT NULL,
  `Jenis` varchar(20) DEFAULT NULL,
  `Stok` varchar(20) DEFAULT NULL,
  `Harga` varchar(20) DEFAULT NULL,
  `JumlahBeli` varchar(20) DEFAULT NULL,
  `TotalBelanja` varchar(20) DEFAULT NULL,
  `Bayar` varchar(20) DEFAULT NULL,
  `Kembali` varchar(20) DEFAULT NULL,
  `GambarKue` varchar(50) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `pembelian` */

insert  into `pembelian`(`NoFaktur`,`Tanggal`,`KodeKue`,`NamaKue`,`Jenis`,`Stok`,`Harga`,`JumlahBeli`,`TotalBelanja`,`Bayar`,`Kembali`,`GambarKue`) values ('1512220004','2015-12-22 12:52:23','2','Roti Boy','Roti','78','5000','5','25000','30000','5000','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\'),('1512220003','2015-12-22 12:51:43','4','kasasa','Anniversary','5','5555','5','','','','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\'),('1512220004','2015-12-22 12:52:23','2','Roti Boy','Roti','78','5000','5','','','','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\'),('1512220002','2015-12-22 12:50:16','3','Bika Ambon','Kue Basah','6','80000','6','480000','80000','400000','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\'),('1512220002','2015-12-22 12:50:16','3','Bika Ambon','Kue Basah','6','80000','6','','','','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\'),('1512220001','2015-12-22 12:49:45','4','kasasa','Anniversary','5','5555','4','','','','C:\\Users\\alpin\\Music\\CakeShop - Copy\\CakeShop\\bin\\');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
