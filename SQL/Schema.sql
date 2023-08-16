CREATE TABLE planets (
  id int NOT NULL,
  name varchar(100) NOT NULL,
  climate varchar(200) NOT NULL,
  diameter int NOT NULL,
  population bigint NOT NULL,
  PRIMARY KEY (id)
);

INSERT INTO planets (id, name, climate, diameter, population) 
VALUES
  (1000, 'Coruscant', 'temperate', 12240, 1000000000000),
  (2000, 'Kashyyyk', 'tropical', 12765, 45000000),
  (3000, 'Nal Hutta', 'temperate', 12150, 7000000000),
  (4000, 'Mon Cala', 'temperate', 11030, 27000000000),
  (5000, 'Endor', 'temperate', 4900, 30000000)

CREATE TABLE species (
  id int NOT NULL,
  name varchar(100) NOT NULL,
  classification varchar(200) NOT NULL,
  is_sentient bit NOT NULL,
  average_height int NOT NULL,
  language varchar(100) NOT NULL,
  homeworld int NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_species_planet FOREIGN KEY (homeworld)
    REFERENCES planets (id)
      ON DELETE CASCADE
      ON UPDATE CASCADE
);

INSERT INTO species (id, name, classification, is_sentient, average_height, [language], homeworld) 
VALUES
  (1, 'Human', 'mammal', 1, 180, 'Galactic Basic', 1000),
  (2, 'Wookie', 'mammal', 1, 210, 'Shyriiwook', 2000),
  (3, 'Droid', 'artificial', 0, 80, 'n/a', null),
  (4, 'Hutt', 'gastropod', 1, 300, 'Huttese', 3000),
  (5, 'Mon Calamari', 'amphibian', 0, 160, 'Mon Calamarian', 4000),
  (6, 'Ewok', 'mammal', 1, 100, 'Ewokese', 5000);