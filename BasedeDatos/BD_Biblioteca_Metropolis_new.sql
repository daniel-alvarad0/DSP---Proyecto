-- Crear la base de datos
CREATE DATABASE Biblioteca_Metropolis_new;
GO
USE Biblioteca_Metropolis_new;
GO

-- Tablas existentes
CREATE TABLE Pais(
    IdPais VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Editorial (
    IdEdit INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Autor(
    IdAutor INT PRIMARY KEY IDENTITY(1,1), 
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL
);

-- Nuevas tablas para diferentes tipos de recursos
CREATE TABLE Libro (
    IdLibro INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(200) NOT NULL,
    AnnoPublic INT NOT NULL,
    IdEdit INT,
    Edicion VARCHAR(10),
    IdPais VARCHAR(10),
    PalabraBusqueda VARCHAR(100),
    CONSTRAINT FK_Libro_Editorial FOREIGN KEY(IdEdit) REFERENCES Editorial(IdEdit),
    CONSTRAINT FK_Libro_Pais FOREIGN KEY(IdPais) REFERENCES Pais(IdPais)
);

CREATE TABLE Enciclopedia (
    IdEnciclopedia INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(200) NOT NULL,
    AnnoPublic INT NOT NULL,
    IdEdit INT,
    Edicion VARCHAR(10),
    IdPais VARCHAR(10),
    PalabraBusqueda VARCHAR(100),
    CONSTRAINT FK_Enciclopedia_Editorial FOREIGN KEY(IdEdit) REFERENCES Editorial(IdEdit),
    CONSTRAINT FK_Enciclopedia_Pais FOREIGN KEY(IdPais) REFERENCES Pais(IdPais)
);

CREATE TABLE Revista (
    IdRevista INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(200) NOT NULL,
    AnnoPublic INT NOT NULL,
    IdEdit INT,
    Edicion VARCHAR(10),
    IdPais VARCHAR(10),
    PalabraBusqueda VARCHAR(100),
    CONSTRAINT FK_Revista_Editorial FOREIGN KEY(IdEdit) REFERENCES Editorial(IdEdit),
    CONSTRAINT FK_Revista_Pais FOREIGN KEY(IdPais) REFERENCES Pais(IdPais)
);

CREATE TABLE Tesis (
    IdTesis INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(200) NOT NULL,
    AnnoPublic INT NOT NULL,
    InstitucionEducativa VARCHAR(200) NOT NULL,
    IdPais VARCHAR(10),
    PalabraBusqueda VARCHAR(100),
    CONSTRAINT FK_Tesis_Pais FOREIGN KEY(IdPais) REFERENCES Pais(IdPais)
);

CREATE TABLE DVD (
    IdDVD INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(200) NOT NULL,
    AnnoPublic INT NOT NULL,
    IdEdit INT,
    IdPais VARCHAR(10),
    PalabraBusqueda VARCHAR(100),
    CONSTRAINT FK_DVD_Editorial FOREIGN KEY(IdEdit) REFERENCES Editorial(IdEdit),
    CONSTRAINT FK_DVD_Pais FOREIGN KEY(IdPais) REFERENCES Pais(IdPais)
);

-- Tabla para manejar la relación muchos a muchos entre autores y recursos
CREATE TABLE AutoresRecursos(
    IdRecAutor INT IDENTITY PRIMARY KEY,
    IdRecurso INT,
    TipoRecurso VARCHAR(20),
    IdAutor INT,
    EsPrincipal BIT,
    CONSTRAINT FK_AutoresRecursos_Autor FOREIGN KEY (IdAutor) REFERENCES Autor(IdAutor)
);

-- Los INSERT INTO para la tabla Pais permanecen iguales
INSERT INTO Pais(IdPais, Nombre) VALUES(1, 'Afghanistan');
INSERT INTO Pais(IdPais, Nombre) VALUES(2, 'Aland Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(3, 'Albania');
INSERT INTO Pais(IdPais, Nombre) VALUES(4, 'Algeria');
INSERT INTO Pais(IdPais, Nombre) VALUES(5, 'American Samoa');
INSERT INTO Pais(IdPais, Nombre) VALUES(6, 'Andorra');
INSERT INTO Pais(IdPais, Nombre) VALUES(7, 'Angola');
INSERT INTO Pais(IdPais, Nombre) VALUES(8, 'Anguilla');
INSERT INTO Pais(IdPais, Nombre) VALUES(9, 'Antarctica');
INSERT INTO Pais(IdPais, Nombre) VALUES(10, 'Antigua and Barbuda');
INSERT INTO Pais(IdPais, Nombre) VALUES(11, 'Argentina');
INSERT INTO Pais(IdPais, Nombre) VALUES(12, 'Armenia');
INSERT INTO Pais(IdPais, Nombre) VALUES(13, 'Aruba');
INSERT INTO Pais(IdPais, Nombre) VALUES(14, 'Australia');
INSERT INTO Pais(IdPais, Nombre) VALUES(15, 'Austria');
INSERT INTO Pais(IdPais, Nombre) VALUES(16, 'Azerbaijan');
INSERT INTO Pais(IdPais, Nombre) VALUES(18, 'Bahrain');
INSERT INTO Pais(IdPais, Nombre) VALUES(19, 'Bangladesh');
INSERT INTO Pais(IdPais, Nombre) VALUES(20, 'Barbados');
INSERT INTO Pais(IdPais, Nombre) VALUES(21, 'Belarus');
INSERT INTO Pais(IdPais, Nombre) VALUES(22, 'Belgium');
INSERT INTO Pais(IdPais, Nombre) VALUES(23, 'Belize');
INSERT INTO Pais(IdPais, Nombre) VALUES(24, 'Benin');
INSERT INTO Pais(IdPais, Nombre) VALUES(25, 'Bermuda');
INSERT INTO Pais(IdPais, Nombre) VALUES(26, 'Bhutan');
INSERT INTO Pais(IdPais, Nombre) VALUES(27, 'Bolivia');
INSERT INTO Pais(IdPais, Nombre) VALUES(155, 'Bonaire, Sint Eustatius and Saba');
INSERT INTO Pais(IdPais, Nombre) VALUES(28, 'Bosnia and Herzegovina');
INSERT INTO Pais(IdPais, Nombre) VALUES(29, 'Botswana');
INSERT INTO Pais(IdPais, Nombre) VALUES(30, 'Bouvet Island');
INSERT INTO Pais(IdPais, Nombre) VALUES(31, 'Brazil');
INSERT INTO Pais(IdPais, Nombre) VALUES(32, 'British Indian Ocean Territory');
INSERT INTO Pais(IdPais, Nombre) VALUES(33, 'Brunei');
INSERT INTO Pais(IdPais, Nombre) VALUES(34, 'Bulgaria');
INSERT INTO Pais(IdPais, Nombre) VALUES(35, 'Burkina Faso');
INSERT INTO Pais(IdPais, Nombre) VALUES(36, 'Burundi');
INSERT INTO Pais(IdPais, Nombre) VALUES(37, 'Cambodia');
INSERT INTO Pais(IdPais, Nombre) VALUES(38, 'Cameroon');
INSERT INTO Pais(IdPais, Nombre) VALUES(39, 'Canada');
INSERT INTO Pais(IdPais, Nombre) VALUES(40, 'Cape Verde');
INSERT INTO Pais(IdPais, Nombre) VALUES(41, 'Cayman Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(42, 'Central African Republic');
INSERT INTO Pais(IdPais, Nombre) VALUES(43, 'Chad');
INSERT INTO Pais(IdPais, Nombre) VALUES(44, 'Chile');
INSERT INTO Pais(IdPais, Nombre) VALUES(45, 'China');
INSERT INTO Pais(IdPais, Nombre) VALUES(46, 'Christmas Island');
INSERT INTO Pais(IdPais, Nombre) VALUES(47, 'Cocos (Keeling) Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(48, 'Colombia');
INSERT INTO Pais(IdPais, Nombre) VALUES(49, 'Comoros');
INSERT INTO Pais(IdPais, Nombre) VALUES(50, 'Congo');
INSERT INTO Pais(IdPais, Nombre) VALUES(52, 'Cook Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(53, 'Costa Rica');
INSERT INTO Pais(IdPais, Nombre) VALUES(54, 'Cote D Ivoire');
INSERT INTO Pais(IdPais, Nombre) VALUES(55, 'Croatia');
INSERT INTO Pais(IdPais, Nombre) VALUES(56, 'Cuba');
INSERT INTO Pais(IdPais, Nombre) VALUES(249, 'Curaçao');
INSERT INTO Pais(IdPais, Nombre) VALUES(57, 'Cyprus');
INSERT INTO Pais(IdPais, Nombre) VALUES(58, 'Czech Republic');
INSERT INTO Pais(IdPais, Nombre) VALUES(51, 'Democratic Republic of the Congo');
INSERT INTO Pais(IdPais, Nombre) VALUES(59, 'Denmark');
INSERT INTO Pais(IdPais, Nombre) VALUES(60, 'Djibouti');
INSERT INTO Pais(IdPais, Nombre) VALUES(61, 'Dominica');
INSERT INTO Pais(IdPais, Nombre) VALUES(62, 'Dominican Republic');
INSERT INTO Pais(IdPais, Nombre) VALUES(64, 'Ecuador');
INSERT INTO Pais(IdPais, Nombre) VALUES(65, 'Egypt');
INSERT INTO Pais(IdPais, Nombre) VALUES(66, 'El Salvador');
INSERT INTO Pais(IdPais, Nombre) VALUES(67, 'Equatorial Guinea');
INSERT INTO Pais(IdPais, Nombre) VALUES(68, 'Eritrea');
INSERT INTO Pais(IdPais, Nombre) VALUES(69, 'Estonia');
INSERT INTO Pais(IdPais, Nombre) VALUES(212, 'Eswatini');
INSERT INTO Pais(IdPais, Nombre) VALUES(70, 'Ethiopia');
INSERT INTO Pais(IdPais, Nombre) VALUES(71, 'Falkland Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(72, 'Faroe Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(73, 'Fiji Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(74, 'Finland');
INSERT INTO Pais(IdPais, Nombre) VALUES(75, 'France');
INSERT INTO Pais(IdPais, Nombre) VALUES(76, 'French Guiana');
INSERT INTO Pais(IdPais, Nombre) VALUES(77, 'French Polynesia');
INSERT INTO Pais(IdPais, Nombre) VALUES(78, 'French Southern Territories');
INSERT INTO Pais(IdPais, Nombre) VALUES(79, 'Gabon');
INSERT INTO Pais(IdPais, Nombre) VALUES(81, 'Georgia');
INSERT INTO Pais(IdPais, Nombre) VALUES(82, 'Germany');
INSERT INTO Pais(IdPais, Nombre) VALUES(83, 'Ghana');
INSERT INTO Pais(IdPais, Nombre) VALUES(84, 'Gibraltar');
INSERT INTO Pais(IdPais, Nombre) VALUES(85, 'Greece');
INSERT INTO Pais(IdPais, Nombre) VALUES(86, 'Greenland');
INSERT INTO Pais(IdPais, Nombre) VALUES(87, 'Grenada');
INSERT INTO Pais(IdPais, Nombre) VALUES(88, 'Guadeloupe');
INSERT INTO Pais(IdPais, Nombre) VALUES(89, 'Guam');
INSERT INTO Pais(IdPais, Nombre) VALUES(90, 'Guatemala');
INSERT INTO Pais(IdPais, Nombre) VALUES(91, 'Guernsey and Alderney');
INSERT INTO Pais(IdPais, Nombre) VALUES(92, 'Guinea');
INSERT INTO Pais(IdPais, Nombre) VALUES(93, 'Guinea-Bissau');
INSERT INTO Pais(IdPais, Nombre) VALUES(94, 'Guyana');
INSERT INTO Pais(IdPais, Nombre) VALUES(95, 'Haiti');
INSERT INTO Pais(IdPais, Nombre) VALUES(96, 'Heard Island and McDonald Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(97, 'Honduras');
INSERT INTO Pais(IdPais, Nombre) VALUES(98, 'Hong Kong S.A.R.');
INSERT INTO Pais(IdPais, Nombre) VALUES(99, 'Hungary');
INSERT INTO Pais(IdPais, Nombre) VALUES(100, 'Iceland');
INSERT INTO Pais(IdPais, Nombre) VALUES(101, 'India');
INSERT INTO Pais(IdPais, Nombre) VALUES(102, 'Indonesia');
INSERT INTO Pais(IdPais, Nombre) VALUES(103, 'Iran');
INSERT INTO Pais(IdPais, Nombre) VALUES(104, 'Iraq');
INSERT INTO Pais(IdPais, Nombre) VALUES(105, 'Ireland');
INSERT INTO Pais(IdPais, Nombre) VALUES(106, 'Israel');
INSERT INTO Pais(IdPais, Nombre) VALUES(107, 'Italy');
INSERT INTO Pais(IdPais, Nombre) VALUES(108, 'Jamaica');
INSERT INTO Pais(IdPais, Nombre) VALUES(109, 'Japan');
INSERT INTO Pais(IdPais, Nombre) VALUES(110, 'Jersey');
INSERT INTO Pais(IdPais, Nombre) VALUES(111, 'Jordan');
INSERT INTO Pais(IdPais, Nombre) VALUES(112, 'Kazakhstan');
INSERT INTO Pais(IdPais, Nombre) VALUES(113, 'Kenya');
INSERT INTO Pais(IdPais, Nombre) VALUES(114, 'Kiribati');
INSERT INTO Pais(IdPais, Nombre) VALUES(248, 'Kosovo');
INSERT INTO Pais(IdPais, Nombre) VALUES(117, 'Kuwait');
INSERT INTO Pais(IdPais, Nombre) VALUES(118, 'Kyrgyzstan');
INSERT INTO Pais(IdPais, Nombre) VALUES(119, 'Laos');
INSERT INTO Pais(IdPais, Nombre) VALUES(120, 'Latvia');
INSERT INTO Pais(IdPais, Nombre) VALUES(121, 'Lebanon');
INSERT INTO Pais(IdPais, Nombre) VALUES(122, 'Lesotho');
INSERT INTO Pais(IdPais, Nombre) VALUES(123, 'Liberia');
INSERT INTO Pais(IdPais, Nombre) VALUES(124, 'Libya');
INSERT INTO Pais(IdPais, Nombre) VALUES(125, 'Liechtenstein');
INSERT INTO Pais(IdPais, Nombre) VALUES(126, 'Lithuania');
INSERT INTO Pais(IdPais, Nombre) VALUES(127, 'Luxembourg');
INSERT INTO Pais(IdPais, Nombre) VALUES(128, 'Macau S.A.R.');
INSERT INTO Pais(IdPais, Nombre) VALUES(130, 'Madagascar');
INSERT INTO Pais(IdPais, Nombre) VALUES(131, 'Malawi');
INSERT INTO Pais(IdPais, Nombre) VALUES(132, 'Malaysia');
INSERT INTO Pais(IdPais, Nombre) VALUES(133, 'Maldives');
INSERT INTO Pais(IdPais, Nombre) VALUES(134, 'Mali');
INSERT INTO Pais(IdPais, Nombre) VALUES(135, 'Malta');
INSERT INTO Pais(IdPais, Nombre) VALUES(136, 'Man (Isle of)');
INSERT INTO Pais(IdPais, Nombre) VALUES(137, 'Marshall Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(138, 'Martinique');
INSERT INTO Pais(IdPais, Nombre) VALUES(139, 'Mauritania');
INSERT INTO Pais(IdPais, Nombre) VALUES(140, 'Mauritius');
INSERT INTO Pais(IdPais, Nombre) VALUES(141, 'Mayotte');
INSERT INTO Pais(IdPais, Nombre) VALUES(142, 'Mexico');
INSERT INTO Pais(IdPais, Nombre) VALUES(143, 'Micronesia');
INSERT INTO Pais(IdPais, Nombre) VALUES(144, 'Moldova');
INSERT INTO Pais(IdPais, Nombre) VALUES(145, 'Monaco');
INSERT INTO Pais(IdPais, Nombre) VALUES(146, 'Mongolia');
INSERT INTO Pais(IdPais, Nombre) VALUES(147, 'Montenegro');
INSERT INTO Pais(IdPais, Nombre) VALUES(148, 'Montserrat');
INSERT INTO Pais(IdPais, Nombre) VALUES(149, 'Morocco');
INSERT INTO Pais(IdPais, Nombre) VALUES(150, 'Mozambique');
INSERT INTO Pais(IdPais, Nombre) VALUES(151, 'Myanmar');
INSERT INTO Pais(IdPais, Nombre) VALUES(152, 'Namibia');
INSERT INTO Pais(IdPais, Nombre) VALUES(153, 'Nauru');
INSERT INTO Pais(IdPais, Nombre) VALUES(154, 'Nepal');
INSERT INTO Pais(IdPais, Nombre) VALUES(156, 'Netherlands');
INSERT INTO Pais(IdPais, Nombre) VALUES(157, 'New Caledonia');
INSERT INTO Pais(IdPais, Nombre) VALUES(158, 'New Zealand');
INSERT INTO Pais(IdPais, Nombre) VALUES(159, 'Nicaragua');
INSERT INTO Pais(IdPais, Nombre) VALUES(160, 'Niger');
INSERT INTO Pais(IdPais, Nombre) VALUES(161, 'Nigeria');
INSERT INTO Pais(IdPais, Nombre) VALUES(162, 'Niue');
INSERT INTO Pais(IdPais, Nombre) VALUES(163, 'Norfolk Island');
INSERT INTO Pais(IdPais, Nombre) VALUES(115, 'North Korea');
INSERT INTO Pais(IdPais, Nombre) VALUES(129, 'North Macedonia');
INSERT INTO Pais(IdPais, Nombre) VALUES(164, 'Northern Mariana Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(165, 'Norway');
INSERT INTO Pais(IdPais, Nombre) VALUES(166, 'Oman');
INSERT INTO Pais(IdPais, Nombre) VALUES(167, 'Pakistan');
INSERT INTO Pais(IdPais, Nombre) VALUES(168, 'Palau');
INSERT INTO Pais(IdPais, Nombre) VALUES(169, 'Palestinian Territory Occupied');
INSERT INTO Pais(IdPais, Nombre) VALUES(170, 'Panama');
INSERT INTO Pais(IdPais, Nombre) VALUES(171, 'Papua New Guinea');
INSERT INTO Pais(IdPais, Nombre) VALUES(172, 'Paraguay');
INSERT INTO Pais(IdPais, Nombre) VALUES(173, 'Peru');
INSERT INTO Pais(IdPais, Nombre) VALUES(174, 'Philippines');
INSERT INTO Pais(IdPais, Nombre) VALUES(175, 'Pitcairn Island');
INSERT INTO Pais(IdPais, Nombre) VALUES(176, 'Poland');
INSERT INTO Pais(IdPais, Nombre) VALUES(177, 'Portugal');
INSERT INTO Pais(IdPais, Nombre) VALUES(178, 'Puerto Rico');
INSERT INTO Pais(IdPais, Nombre) VALUES(179, 'Qatar');
INSERT INTO Pais(IdPais, Nombre) VALUES(180, 'Reunion');
INSERT INTO Pais(IdPais, Nombre) VALUES(181, 'Romania');
INSERT INTO Pais(IdPais, Nombre) VALUES(182, 'Russia');
INSERT INTO Pais(IdPais, Nombre) VALUES(183, 'Rwanda');
INSERT INTO Pais(IdPais, Nombre) VALUES(184, 'Saint Helena');
INSERT INTO Pais(IdPais, Nombre) VALUES(185, 'Saint Kitts and Nevis');
INSERT INTO Pais(IdPais, Nombre) VALUES(186, 'Saint Lucia');
INSERT INTO Pais(IdPais, Nombre) VALUES(187, 'Saint Pierre and Miquelon');
INSERT INTO Pais(IdPais, Nombre) VALUES(188, 'Saint Vincent and the Grenadines');
INSERT INTO Pais(IdPais, Nombre) VALUES(189, 'Saint-Barthelemy');
INSERT INTO Pais(IdPais, Nombre) VALUES(190, 'Saint-Martin (French part)');
INSERT INTO Pais(IdPais, Nombre) VALUES(191, 'Samoa');
INSERT INTO Pais(IdPais, Nombre) VALUES(192, 'San Marino');
INSERT INTO Pais(IdPais, Nombre) VALUES(193, 'Sao Tome and Principe');
INSERT INTO Pais(IdPais, Nombre) VALUES(194, 'Saudi Arabia');
INSERT INTO Pais(IdPais, Nombre) VALUES(195, 'Senegal');
INSERT INTO Pais(IdPais, Nombre) VALUES(196, 'Serbia');
INSERT INTO Pais(IdPais, Nombre) VALUES(197, 'Seychelles');
INSERT INTO Pais(IdPais, Nombre) VALUES(198, 'Sierra Leone');
INSERT INTO Pais(IdPais, Nombre) VALUES(199, 'Singapore');
INSERT INTO Pais(IdPais, Nombre) VALUES(250, 'Sint Maarten (Dutch part)');
INSERT INTO Pais(IdPais, Nombre) VALUES(200, 'Slovakia');
INSERT INTO Pais(IdPais, Nombre) VALUES(201, 'Slovenia');
INSERT INTO Pais(IdPais, Nombre) VALUES(202, 'Solomon Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(203, 'Somalia');
INSERT INTO Pais(IdPais, Nombre) VALUES(204, 'South Africa');
INSERT INTO Pais(IdPais, Nombre) VALUES(205, 'South Georgia');
INSERT INTO Pais(IdPais, Nombre) VALUES(116, 'South Korea');
INSERT INTO Pais(IdPais, Nombre) VALUES(206, 'South Sudan');
INSERT INTO Pais(IdPais, Nombre) VALUES(207, 'Spain');
INSERT INTO Pais(IdPais, Nombre) VALUES(208, 'Sri Lanka');
INSERT INTO Pais(IdPais, Nombre) VALUES(209, 'Sudan');
INSERT INTO Pais(IdPais, Nombre) VALUES(210, 'Suriname');
INSERT INTO Pais(IdPais, Nombre) VALUES(211, 'Svalbard and Jan Mayen Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(213, 'Sweden');
INSERT INTO Pais(IdPais, Nombre) VALUES(214, 'Switzerland');
INSERT INTO Pais(IdPais, Nombre) VALUES(215, 'Syria');
INSERT INTO Pais(IdPais, Nombre) VALUES(216, 'Taiwan');
INSERT INTO Pais(IdPais, Nombre) VALUES(217, 'Tajikistan');
INSERT INTO Pais(IdPais, Nombre) VALUES(218, 'Tanzania');
INSERT INTO Pais(IdPais, Nombre) VALUES(219, 'Thailand');
INSERT INTO Pais(IdPais, Nombre) VALUES(17, 'The Bahamas');
INSERT INTO Pais(IdPais, Nombre) VALUES(80, 'The Gambia ');
INSERT INTO Pais(IdPais, Nombre) VALUES(63, 'Timor-Leste');
INSERT INTO Pais(IdPais, Nombre) VALUES(220, 'Togo');
INSERT INTO Pais(IdPais, Nombre) VALUES(221, 'Tokelau');
INSERT INTO Pais(IdPais, Nombre) VALUES(222, 'Tonga');
INSERT INTO Pais(IdPais, Nombre) VALUES(223, 'Trinidad and Tobago');
INSERT INTO Pais(IdPais, Nombre) VALUES(224, 'Tunisia');
INSERT INTO Pais(IdPais, Nombre) VALUES(225, 'Turkey');
INSERT INTO Pais(IdPais, Nombre) VALUES(226, 'Turkmenistan');
INSERT INTO Pais(IdPais, Nombre) VALUES(227, 'Turks and Caicos Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(228, 'Tuvalu');
INSERT INTO Pais(IdPais, Nombre) VALUES(229, 'Uganda');
INSERT INTO Pais(IdPais, Nombre) VALUES(230, 'Ukraine');
INSERT INTO Pais(IdPais, Nombre) VALUES(231, 'United Arab Emirates');
INSERT INTO Pais(IdPais, Nombre) VALUES(232, 'United Kingdom');
INSERT INTO Pais(IdPais, Nombre) VALUES(233, 'United States');
INSERT INTO Pais(IdPais, Nombre) VALUES(234, 'United States Minor Outlying Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(235, 'Uruguay');
INSERT INTO Pais(IdPais, Nombre) VALUES(236, 'Uzbekistan');
INSERT INTO Pais(IdPais, Nombre) VALUES(237, 'Vanuatu');
INSERT INTO Pais(IdPais, Nombre) VALUES(238, 'Vatican City State (Holy See)');
INSERT INTO Pais(IdPais, Nombre) VALUES(239, 'Venezuela');
INSERT INTO Pais(IdPais, Nombre) VALUES(240, 'Vietnam');
INSERT INTO Pais(IdPais, Nombre) VALUES(241, 'Virgin Islands (British)');
INSERT INTO Pais(IdPais, Nombre) VALUES(242, 'Virgin Islands (US)');
INSERT INTO Pais(IdPais, Nombre) VALUES(243, 'Wallis and Futuna Islands');
INSERT INTO Pais(IdPais, Nombre) VALUES(244, 'Western Sahara');
INSERT INTO Pais(IdPais, Nombre) VALUES(245, 'Yemen');
INSERT INTO Pais(IdPais, Nombre) VALUES(246, 'Zambia');
INSERT INTO Pais(IdPais, Nombre) VALUES(247, 'Zimbabwe');

GO