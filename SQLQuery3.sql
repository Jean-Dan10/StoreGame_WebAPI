-- Insert data into the Wishlist table
INSERT INTO Wishlist ([User])
VALUES ('admin'); -- Replace 'user123' with the actual user value

-- Insert more records into the Wishlist table as needed
INSERT INTO Wishlist ([User])
VALUES ('Grimworld');

INSERT INTO JeuWishlist (JeuxIdJeu, WhislistsId)
VALUES (1, 1); -- Replace 1 and 2 with the actual IDs you want to associate

-- Insert another record
INSERT INTO JeuWishlist (JeuxIdJeu, WhislistsId)
VALUES (2, 1); 

INSERT INTO JeuWishlist (JeuxIdJeu, WhislistsId)
VALUES (3, 1); 

INSERT INTO JeuWishlist (JeuxIdJeu, WhislistsId)
VALUES (4, 1); 

INSERT INTO JeuWishlist (JeuxIdJeu, WhislistsId)
VALUES (1, 2); 

INSERT INTO JeuWishlist (JeuxIdJeu, WhislistsId)
VALUES (2, 2);