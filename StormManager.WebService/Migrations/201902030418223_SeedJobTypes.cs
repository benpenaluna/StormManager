namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedJobTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (1, 'Air Observations and Assessment', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (2, 'Aircraft Incident', 'Aircraft in Difficulty', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (3, 'Aircraft Incident', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (4, 'Aircraft Incident', 'No Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (5, 'Aircraft Incident', 'No injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (6, 'Aircraft Incident', 'With Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (7, 'Aircraft Incident', 'With Injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (8, 'Alpine Rescue', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (9, 'Animal Rescue', 'From Dam', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (10, 'Animal Rescue', 'From in or under Structure', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (11, 'Animal Rescue', 'From Mobile Property', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (12, 'Animal Rescue', 'From River to Creek', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (13, 'Animal Rescue', 'From Tree', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (14, 'Animal Rescue', 'From Well or Mine', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (15, 'Animal Rescue', 'Other', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (16, 'Assist Ambulance', 'Casualty Handling Only', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (17, 'Assist Ambulance', 'Drive Ambulance', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (18, 'Assist Ambulance', 'First Aid & Casualty Handling', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (19, 'Assist Ambulance', 'First Aid Only', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (20, 'Assist Ambulance', 'Specialist Resource Response - Lighting or Other', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (21, 'Assist Ambulance', 'Specialist Resource Response - Mass Casualty', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (22, 'Assist AMSA', 'Missing Person', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (23, 'Assist AMSA', 'Missing Plane or Boat', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (24, 'Assist DELWP', 'Non-Fire', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (25, 'Assist DELWP', 'Primary Industry', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (26, 'Assist DHS', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (27, 'Assist Fire', 'Damage to Structure - Permanent or Mobile Property', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (28, 'Assist Fire', 'Landing Zone Management or Support', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (29, 'Assist Fire', 'Logistics Support', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (30, 'Assist Fire', 'Staging Area Management or Support', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (31, 'Assist Local Council', 'Shire', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (32, 'Assist Other Government Agency', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (33, 'Assist Police', 'Crime Scene', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (34, 'Assist Police', 'Damage to Structure - Permanent or Mobile Property', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (35, 'Assist Police', 'Emergency Coordination Centre - Divisional (DECC)', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (36, 'Assist Police', 'Emergency Coordination Centre - Municipal (MECC)', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (37, 'Assist Police', 'Evacuation', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (38, 'Assist Police', 'Missing Person', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (39, 'Assist Red Cross', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (40, 'Assist Service Club', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (41, 'Building Damage', 'Multi Storey - External', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (42, 'Building Damage', 'Multi Storey - Including Sheeting Iron Roof', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (43, 'Building Damage', 'Multi Storey - Including Tiles Roof', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (44, 'Building Damage', 'Multi Storey - Internal', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (45, 'Building Damage', 'Shed, Outbuilding, etc.', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (46, 'Building Damage', 'Single Storey - External', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (47, 'Building Damage', 'Single Storey - Including Sheeting Iron Roof', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (48, 'Building Damage', 'Single Storey - Including Tiles Roof', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (49, 'Building Damage', 'Single Storey - Internal', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (50, 'Community Education', 'Other', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (51, 'Control Centre', 'Assist Agency', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (52, 'Control Centre', 'Earthquake', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (53, 'Control Centre', 'Flood', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (54, 'Control Centre', 'RAIR Rescue', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (55, 'Control Centre', 'Rescue Other', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (56, 'Control Centre', 'Storm', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (57, 'Control Centre', 'Tsunami', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (58, 'Control Centre', 'Unclassified', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (59, 'Cover Assignment', 'Standby at LHQ', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (60, 'Dispatched and Cancelled En-Route', 'Assist Agency', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (61, 'Dispatched and Cancelled En-Route', 'Earthquake', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (62, 'Dispatched and Cancelled En-Route', 'Flood', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (63, 'Dispatched and Cancelled En-Route', 'RAIR Rescue', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (64, 'Dispatched and Cancelled En-Route', 'Rescue Other', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (65, 'Dispatched and Cancelled En-Route', 'Storm', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (66, 'Dispatched and Cancelled En-Route', 'Tsunami', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (67, 'Dispatched and Cancelled En-Route', 'Unclassified', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (68, 'Driver Reviver', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (69, 'Duress', 'Accidental Activation', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (70, 'Duress', 'Hostile Situation', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (71, 'Duress', 'Misuse', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (72, 'Duress', 'Rescue Required', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (73, 'Duress', 'Serious Accident - MVA', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (74, 'Duress', 'Serious Injuries', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (75, 'Fire Agency Liaison', 'CFA', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (76, 'Fire Agency Liaison', 'DELWP', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (77, 'Fire Agency Liaison', 'MFB', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (78, 'Flood Smart', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (79, 'Flooding', 'Appliance Failure', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (80, 'Flooding', 'Burst Water Pipe or Main', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (81, 'Flooding', 'Dam Incident or Failure', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (82, 'Flooding', 'Flash Flooding', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (83, 'Flooding', 'Mitigation', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (84, 'Flooding', 'Other (Bath Overflow, etc.)', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (85, 'Flooding', 'Riverina', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (86, 'Fundraising', 'Charity', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (87, 'Fundraising', 'Community Group', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (88, 'Fundraising', 'Other ESO', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (89, 'Fundraising', 'SES', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (90, 'Good Intent Call', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (91, 'Good Intent Call', 'Not Classified', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (92, 'Ground Observations and Assessment', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (93, 'Industrial Accident', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (94, 'Industrial Accident', 'No Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (95, 'Industrial Accident', 'No injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (96, 'Industrial Accident', 'With Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (97, 'Industrial Accident', 'With Injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (98, 'Medical Assistance', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (99, 'Medical Assistance', 'Not Classified', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (100, 'Medical Assistance', 'With CPR-EAR', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (101, 'Medical Assistance', 'With Oxygen Therapy', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (102, 'Other Condition', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (103, 'Other Service Call', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (104, 'Other Service Call', 'Not Classified', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (105, 'PR', 'Church/Charity', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (106, 'PR', 'Local Community Festival, Event, Show', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (107, 'PR', 'Local Community Group', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (108, 'PR', 'Major Event - Avalon Airshow', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (109, 'PR', 'Major Event - F1 Grand Prix', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (110, 'PR', 'Major Event - Melbourne Show', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (111, 'PR', 'Major Event - Moto Grand Prix', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (112, 'PR', 'School, University, TAFE', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (113, 'PR', 'Service Club, Lions, Rotary, Probus', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (114, 'Rail Incident', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (115, 'Rail Incident', 'No Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (116, 'Rail Incident', 'No injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (117, 'Rail Incident', 'With Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (118, 'Rail Incident', 'With Injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (119, 'Relief', 'Earthquake', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (120, 'Relief', 'Fire', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (121, 'Relief', 'Health Event', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (122, 'Relief', 'Other', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (123, 'Relief', 'Storm & Flood', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (124, 'Relief', 'Tsunami', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (125, 'Rescue', 'Coverage of another Provider', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (126, 'Rescue Persons', 'Confined Space Rescue', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (127, 'Rescue Persons', 'Domestic', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (128, 'Rescue Persons', 'Elevator or Escalator - Removal of Victims', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (129, 'Rescue Persons', 'Elevator or Escalator - No Occupants', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (130, 'Rescue Persons', 'Extrication of Victim(s) from Structural Collapse', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (131, 'Rescue Persons', 'Marine Rescue', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (132, 'Rescue Persons', 'Rope Rescue', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (133, 'Rescue Persons', 'Trench Rescue', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (134, 'Rescue Standby at Public Event', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (135, 'Rescue, EMS Calls', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (136, 'Rescue, EMS Calls', 'Not Classified', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (137, 'Road Rescue', 'Insufficient Information to Classify', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (138, 'Road Rescue', 'No Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (139, 'Road Rescue', 'No injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (140, 'Road Rescue', 'With Injuries, Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (141, 'Road Rescue', 'With Injuries, No Extrication', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (142, 'Storm Smart', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (143, 'Traffic Management', 'Fire Control Agency', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (144, 'Traffic Management', 'Police Control Agency', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (145, 'Traffic Management', 'SES Control Agency', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (146, 'Tree Down', 'Limiting Access', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (147, 'Tree Down', 'Mobile Property', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (148, 'Tree Down', 'Non Threatening (backyard, etc.)', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (149, 'Tree Down', 'Non-Structure (arch, fence, hedge, hooked up in another tree, etc.)', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (150, 'Tree Down', 'Passed to Council', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (151, 'Tree Down', 'Passed to DELWP or Parks Victoria', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (152, 'Tree Down', 'Permanent Property', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (153, 'Tree Down Traffic Hazard', 'Blocked Roadway (Fully)', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (154, 'Tree Down Traffic Hazard', 'Blocked Roadway (Partially)', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (155, 'Tree Down Traffic Hazard', 'Passed to Council', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (156, 'Tree Down Traffic Hazard', 'Passed to DELWP or Parks Victoria', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (157, 'Tree Down Traffic Hazard', 'Passed to Federal Authority', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (158, 'Tree Down Traffic Hazard', 'Passed to Roadway Operator (Citylink, Eastlink etc.)', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (159, 'Tree Down Traffic Hazard', 'Passed to VICROADS', 1, 0xFF90EE90, 0xFF008000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (160, 'Type of Incident not Reported due to Industrial Action', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (161, 'Type of Incident Undetermined', '', 1, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (162, 'Warning', 'Fire', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (163, 'Warning', 'Flood', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (164, 'Warning', 'Other', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (165, 'Warning', 'Storm', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (166, 'Warning', 'Tsunami', 0, 0xFF696969, 0xFF000000)");
            Sql("INSERT INTO JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb) VALUES (167, 'Wrong Location', '', 0, 0xFF696969, 0xFF000000)");
        }

        public override void Down()
        {
            Sql("DELETE FROM JobTypes");
        }
    }
}
