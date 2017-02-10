DELETE FROM Product
DELETE FROM Brands

--Insert Brands
INSERT INTO Brands (Name)
	VALUES ('Corsair');
INSERT INTO Brands (Name)
	VALUES ('Razer');
INSERT INTO Brands (Name)
	VALUES ('SteelSeries');
INSERT INTO Brands (Name)
	VALUES ('Logitech');

--Get the IDs of the different brands
DECLARE @Corsair int;
SELECT @Corsair = Id FROM Brands WHERE Name = 'Corsair';
DECLARE @Razer int;
SELECT @Razer = Id FROM Brands WHERE Name = 'Razer';
DECLARE @SteelSeries int;
SELECT @SteelSeries = Id FROM Brands WHERE Name = 'SteelSeries';
DECLARE @Logitech int;
SELECT @Logitech = Id FROM Brands WHERE Name = 'Logitech';

--Insert Products
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('BR7PQ', @Corsair, 'Corsair M65 PRO RGB',
	'Corsair_M65.jpg', 60.00, 79.99, 12, 2, 
	'The M65 PRO RGB features a 12000 DPI optical sensor that provides pixel-precise tracking and advanced surface calibration support. The aircraft-grade aluminum frame gives it low weight, and at the same time, extremely high durability. Use the advanced weight tuning system to set the center of gravity to match your play style, and harness the power of CUE for advanced button configuration, macro programming, and three-zone RGB backlighting customization.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('0ENAE', @Corsair, 'Corsair Sabre RGB',
	'Corsair_Sabre.jpg', 55.00, 69.99, 1, 6, 
	'Light weight at just 100g, the Corsair Gaming Sabre RGB 10000 DPI gaming mouse offers easy comfort and fluid reach balanced by consistently accurate tracking, a 1,000 Hz refresh rate, eight configurable buttons, and super-responsive switches. Four-zone 16.8M color backlighting creates a beautiful, personalized look that matches your style.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('LKF8J', @Corsair, 'Corsair SCIMITAR RGB',
	'Corsair_Scimitar.jpg', 75.00, 109.99, 0, 10, 
	'The Scimitar RGB gaming mouse revolutionizes game play with its Key Slider control system, 12 mechanical side buttons, and pro-proven 12,000 DPI optical sensor. It’s purpose built to deliver the ultimate MOBA and MMO gaming experience.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('26R9W', @Corsair, 'Corsair Raptor M30',
	'Corsair_Rap_M30.jpg', 40.00, 56.99, 9, 0, 
	'Corsair Raptor M30 is designed for FPS performance, with an FPS-optimized 4000 DPI optical gaming sensor, extra-large PTFE glide pads, and fast response time for superior control and deadly accuracy. With six buttons, you can set up one-click access to critical game functions, and on-the-fly DPI switching with a DPI LED indicator lets you instantly switch to a lower sensor resolution for better long-range weapon accuracy.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('G1RXK', @Corsair, 'Corsair KATAR',
	'Corsair_Katar.jpg', 40.00, 56.99, 9, 0, 
	'Ultra-responsive hardware, compact and light weight design, and configuration settings developed by the world''s top players make Katar the gaming mouse in its purest, most essential form.');

INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('J7BOE', @Razer, 'Razer Naga Chroma',
	'Razer_Naga_Chro.jpg', 85.00, 99.99, 2, 21, 
	'The Razer Naga Chroma''s original 12 button thumb grid is outfitted with mechanical switches to give you tactile and audible feedback, so you can be assured of every actuation. Boasting the world''s most precise True 16,000 DPI 5G Laser gaming mouse sensor, with 0 interpolation, the Razer Naga Chroma provides you with unsurpassable accuracy, so you''ll have an even greater edge over your competition.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('BLEM3', @Razer, 'Razer Mamba Chroma',
	'Razer_Mamba_Chro.jpg', 180.00, 219.99, 2, 2, 
	'Boasting the world''s most precise 16,000 DPI gaming mouse sensor, the Razer Mamba provides you with unsurpassable accuracy, so you''ll have an even greater edge over your competition. With its ability to track 1 DPI increments and a lift-off cut-off distance as precise as 0.1 mm, the Razer Mamba helps you to react instantly while you skillfully maneuver your way to victory.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('U708F', @Razer, 'Razer Ouroboros',
	'Razer_Ouroboros.jpg', 180.00, 219.99, 3, 0, 
	'From an adjustable arched palm rest, to a retractable back, as well as four interchangeable side panels, the Razer Ouroboros is fully customizable to your personal needs. It fits perfectly with any hand length, shape and grip-style – maximize your comfort and reduce fatigue over extended play.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('FL32E', @Razer, 'Razer Mamba Tournament Ed.',
	'Razer_Mamba_Tour.jpg', 99.00, 119.99, 4, 1, 
	'Designed for the most natural hand position, the Razer Mamba Tournament Edition boasts impressive ergonomics that reduce stress on your fingers when you’re actuating buttons and eliminate unnecessary finger drag points. Whether you’re training for a tournament or playing an overnight raid session, your Razer Mamba Tournament Edition gives you an extremely comfortable gaming experience the whole time.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('HER6E', @Razer, 'Razer Overwatch DeathAdder',
	'Razer_DeathAdder.jpg', 110.00, 141.49, 1, 5, 
	'The Razer DeathAdder features a 6400dpi optical sensor capable of accurate tracking with zero interpolation. The iconic right-handed ergonomic design remains the same, but is improved with rubber side grips for better mouse control. Razer Synapse rounds off the Razer DeathAdder package – delivering capabilities such as driver settings saved in the cloud, surface calibration, Z-axis tracking, and more.');

INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('G5H58', @SteelSeries, 'SteelSeries Rival 300',
	'SteelSeries_Riv3.jpg', 60.00, 79.99, 4, 5, 
	'The Rival 300 optical gaming mouse brings together unmatched performance and high levels of customization for the best professional-grade, right-handed gaming mouse. It features 6 programmable buttons and RGB illumination.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('49KOE', @SteelSeries, 'SteelSeries Rival 100',
	'SteelSeries_Riv1.jpg', 45.00, 54.99, 1, 2, 
	'The Rival 100 optical gaming mouse brings unmatched performance to PC and Mac gaming, armed with illumination, a best in class sensor, and six programmable buttons at the best price.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('1Y0EL', @SteelSeries, 'SteelSeries Sensei',
	'SteelSeries_SenW.jpg', 220.00, 264.44, 4, 0, 
	'Sensei Wireless uses the latest in wireless technology to deliver exactly the same performance of our wired Sensei tournament-grade mouse. We equipped the mouse with the highest polling rate on the market (1000Hz), delivering a 1ms response time that eliminates wireless lag. The Pixart ADNS 9800 laser sensor allows you to ramp up the CPI to 8200. To top it off, we also added new, highly-responsive SteelSeries switches that have an industry leading lifespan of 30 million clicks.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('Q9MWY', @SteelSeries, 'SteelSeries Sensei RAW',
	'SteelSeries_SenR.jpg', 60.00, 84.99, 9, 2, 
	'With tournament-grade components and focused intent, the Sensei [RAW] is born for tournament victory. The gaming-grade laser sensor empowers you through the battle. Scalable pointer speed from 90 up to 5670 in increments of 90 ensures you can be exact as you want. White illumination lights up your wheel, CPI indicator, or SteelSeries logo. Or you can turn it all off. The powerful SteelSeries Engine Software enables you to program your buttons, record macros, define your sensitivity, and create unlimited profiles for the ultimate in gaming prowess.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('8657T', @SteelSeries, 'SteelSeries Rival Dota',
	'SteelSeries_RivD.jpg', 110.00, 122.99, 9, 2, 
	'We took a look at the landscape of high-performance mice and felt we could do a better job. So we did. The performance of the SteelSeries Rival Dota 2 Edition reigns over the competition thanks to a cutting edge sensor, newly developed switches engineered by SteelSeries, and a suite of tweaks to give you the edge over your rivals.');

INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('9M95K', @Logitech, 'Logitech G502',
	'Logitech_G502.jpg', 80.00, 99.99, 3, 6, 
	'G502 features our most advanced optical sensor for maximum tracking accuracy. Customize RGB lighting or sync it with other Logitech G products, set up custom profiles for your games, adjust sensitivity from 200 up to 12,000 DPI* and position five 3.6g weights for just the right balance and feel. No matter your gaming style, it’s easy to tweak Proteus Spectrum to match you.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('KPPZX', @Logitech, 'Logitech G900',
	'Logitech_G900.jpg', 110.00, 122.99, 9, 2, 
	'Professional-Grade Wired/Wireless Gaming Mouse: Ultra-fast lag-free wired or wireless connection trusted by professional eSports gamers. Customizable physical button layout: Ambidextrous design for left or right hand and any mouse grip style.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('1NZP6', @Logitech, 'Logitech MX Master',
	'Logitech_MX.jpg', 105.00, 119.99, 3, 5, 
	'The perfectly sculpted, hand crafted shape* of this comfort mouse supports your hand and wrist in a comfortable, natural position. Experience fine-motion control and fluid experience with well-positioned buttons and wheels.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('1MDJ5', @Logitech, 'Logitech G300S',
	'Logitech_G300S.jpg', 45.00, 59.99, 2, 5, 
	'Achieve great results with the default configuration straight out of the box. Or, set up one-button triggers for actions that typically require digging into menus. Put push-to-talk communications in easier reach. Temporarily down-shift DPI. Reassign any game command or multi-command macro to any one of nine programmable buttons with optional Logitech Gaming Software.');
INSERT INTO Product (Id, BrandId, ProductName, GraphicName, CostPrice, MSRP, QtyOnHand, QtyOnBackOrder, Description)
	VALUES ('2KE9X', @Logitech, 'Logitech G402',
	'Logitech_G402.jpg', 64.00, 74.99, 5, 1, 
	'Hyperion Fury combines an optical sensor featuring Logitech Delta Zero™ technology with our exclusive Fusion Engine™ hybrid sensor to enable tracking speeds in excess of 500 IPS.');

SELECT * FROM Product
SELECT * FROM Brands