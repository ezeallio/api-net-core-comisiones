insert into Packages(Description) values ('Mar del plata'), ('Carlos Paz'), ('Bariloche');

insert into Items(Description, Type, Price, Category)
values ('2-Star Hotel', 1, 20, 0),
('Escarabajo', 2, 30, 3),
('Standard class', 3, 30, 0),

('4-Star Hotel', 1, 30, 0),
('Audi TT', 2, 80, 1),
('Business class', 3, 40, 0),

('3-Star Hotel', 1, 40, 0),
('Fitito', 2, 10, 1),
('First class', 3, 50, 0);

insert into PackageItems(PackageId, ItemId)
values (1, 1), (1, 2), (1, 3),
(2, 4), (2, 5), (2, 6),
(3, 7), (3, 8), (3, 9);