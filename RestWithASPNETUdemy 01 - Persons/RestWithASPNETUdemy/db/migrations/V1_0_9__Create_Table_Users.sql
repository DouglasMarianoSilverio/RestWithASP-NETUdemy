CREATE TABLE IF NOT EXISTS `users` (
  `id`INT(10) AUTO_INCREMENT PRIMARY KEY,
  `login` varchar(50) unique not null,  
  `AccessKey` VarChar(50) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;