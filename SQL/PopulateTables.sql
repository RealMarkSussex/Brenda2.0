insert into Level(LevelNumber) VALUES (1), (2), (3), (4)

iNSERT INTO sKILL(Name, [Description]) values ('C#', 'Good'), ('SQL', 'Cool')

INSERT INTO [Role](Name, Department) VALUES ('Trainee Software Engineer', 'Tech'), ('Graduate Software Engineer', 'Tech'), ('MidLevel Software Engineer', 'Tech')

INSERT INTO [User](Email, FirstName, LastName, [Password], RoleId, DesiredRoleID) 
VALUES ('mark.sussex@gcompare.com', 'Mark', 'Sussex', 'HeskeyLol', 1, 3), ('james.tobias@gocompare.com', 'James', 'Tobias', 'qwertyuio', 1, 3)

INSERT INTO SkillLevel(SkillId, LevelId, [Description]) VALUES (1, 1, 'Bad'), (1, 2, 'Ok'), (1, 3, 'Good'), (1, 4, 'Great'),
(2, 1, 'Bad'), (2, 2, 'Ok'), (2, 3, 'Good'), (2, 4, 'Great')

INSERT INTO UserSkill VALUES (1, 2), (1, 6), (2, 2), (2, 7)
