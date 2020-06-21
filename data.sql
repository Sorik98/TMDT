USE [TMDT]
GO
SET IDENTITY_INSERT [dbo].[Producers] ON 
GO
INSERT [dbo].[Producers] ([ProducerId], [Name], [Desc], [AuthBy], [AuthDate], [AuthStatus], [CreateBy], [CreateDate], [LastUpdateBy], [LastUpdateDate]) VALUES (1, N'Gigabyte', N'GIGABYTE Technology Co., Ltd. là một nhà sản xuất và phân phối các thiết bị phần cứng máy tính có trụ sở ở Đài Loan.
GIGABYTE là nhà cung cấp bo mạch chủ, với 4.8 triệu bo mạch chủ được bán ra trong Quý 1/2015, trong khi đó ASUS bán được khoảng 4.5 triệu bo mạch chủ trong cùng quý. GIGABYTE được xếp hạng 17 tại “Taiwan’s 2010 Top 20 Global Brands” bởi Taiwan External Trade Development Council.

Được thành lập năm 1986 với Pei-Cheng Yeh. Các sản phẩm của GIGABYTE được sử dụng trong Alienware, Falcon Northwest, và Origin PC.

Một tính năng quan trọng của GIGABYTE quay trở lại vào năm 2006 là bo mạch chủ Ultra-Durable. Vào ngày 8 tháng 8 năm 2006 GIGABYTE công bố một liên doanh với ASUS. GIGABYTE phát triển chương trình quản lý điện năng đầu tiên trên thế giới trong tháng 7 năm 2007.

Một phương thức sáng tạo để sạc iPad và iPhonetrên máy tính được giới thiệu bởi GIGABYTE vào tháng 4/2010.Gigabyte ra mắt bo mạch chủ Z68 đầu tiên trên thế giới vào 31/5/2011, với mSATA Onboad cho Intel® SSDs and Smart Response TechnologyNgày 02 tháng 4 năm 2012, Gigabyte phát triển bo mạch chủ đầu tiên trên thế giới với 60A IC chuẩn quốc tế.

GIGABYTE cam kết cung cấp các giải pháp hàng đầu để “nâng cấp cuộc sống của bạn”. Được coi là nhà sản xuất tiên phong trong sự đột phá về đổi mới công nghệ với công nghệ Ultra Durable – một công nghệ mang tính cách mạng của ngành công nghiệp máy tính, bên cạnh đó là thiết kế về hệ thống tản nhiệt WINDFORCE, và công nghệ máy tính mini đa năng với BRIX. Tham gia vào cuộc chạy đua về sản phẩm gaming, GIGABYTE cho ra mắt dòng sản phẩm AORUS – Dòng sản phẩm dành riêng cho giới game thủ.', N'daochihao98@gmail.com', CAST(N'2020-06-19T17:21:59.9465512' AS DateTime2), N'Approved', N'daochihao98@gmail.com', CAST(N'2020-06-19T17:21:59.9476735' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Producers] ([ProducerId], [Name], [Desc], [AuthBy], [AuthDate], [AuthStatus], [CreateBy], [CreateDate], [LastUpdateBy], [LastUpdateDate]) VALUES (2, N'MSI', N'motaMSI', N'vyphat@gmail.com', CAST(N'2020-06-19T17:22:00.0422051' AS DateTime2), N'Approved', N'vyphat@gmail.com', CAST(N'2020-06-19T17:22:00.0422123' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Producers] ([ProducerId], [Name], [Desc], [AuthBy], [AuthDate], [AuthStatus], [CreateBy], [CreateDate], [LastUpdateBy], [LastUpdateDate]) VALUES (3, N'ASUS', N'motaASUS', N'vyphat@gmail.com', CAST(N'2020-06-19T17:22:00.0427868' AS DateTime2), N'Approved', N'vyphat@gmail.com', CAST(N'2020-06-19T17:22:00.0427882' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Producers] ([ProducerId], [Name], [Desc], [AuthBy], [AuthDate], [AuthStatus], [CreateBy], [CreateDate], [LastUpdateBy], [LastUpdateDate]) VALUES (4, N'DELL', N'motaDELL', N'vyphat@gmail.com', CAST(N'2020-06-19T17:22:00.0428533' AS DateTime2), N'Approved', N'vyphat@gmail.com', CAST(N'2020-06-19T17:22:00.0428540' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Producers] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING MSI GF63 THIN 9SCXR 075VN', N'CPU	
Intel Core i5 9300H

GPU	
Geforce GTX 1650 MaxQ

Màn hình	
15.6" FHD (1920×1080), IPS

Hệ điều hành	
Windows 10 64Bit Home

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 4

Ổ cứng HDD	
1 slot HDD 2.5''

Ổ đĩa quang	
No ODD

Lan	
Gigabit Lan

Wireless Lan	
AC 9560 (2*2 a/c) + BT5

Các cổng kết nối	
1x (4K @ 30Hz) HDMI, 1x RJ45, 1x Type-C USB3.2 Gen1, 3x Type-A USB3.2 Gen1

Bàn phím	
Backlight Keyboard ( Red )
Pin	
3 Cell

Kích thước	
359 x 254 x 21.7 mm

Trọng lượng	
1.8 kg', N'Laptop', CAST(20290000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T17:36:28.0318954' AS DateTime2), 4, N'vyphat@gmail.com', CAST(N'2020-06-19T17:47:07.1463052' AS DateTime2), 2, NULL, NULL, CAST(20290000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N' GEFORCE GTX1650 4GB INTEL CORE I5 9300H 8GB 512GB 15.6” IPS FHD BACKLIGHT KEYBOARD WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING MSI GF63 THIN 9SCXR 075VN', N'CPU	
Intel Core i5 9300H

GPU	
Geforce GTX 1650 MaxQ

Màn hình	
15.6" FHD (1920×1080), IPS

Hệ điều hành	
Windows 10 64Bit Home

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 4

Ổ cứng HDD	
1 slot HDD 2.5''

Ổ đĩa quang	
No ODD

Lan	
Gigabit Lan

Wireless Lan	
AC 9560 (2*2 a/c) + BT5

Các cổng kết nối	
1x (4K @ 30Hz) HDMI, 1x RJ45, 1x Type-C USB3.2 Gen1, 3x Type-A USB3.2 Gen1

Bàn phím	
Backlight Keyboard ( Red )
Pin	
3 Cell

Kích thước	
359 x 254 x 21.7 mm

Trọng lượng	
1.8 kg', N'Laptop', CAST(18261000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T17:45:16.6826255' AS DateTime2), 5, N'vyphat@gmail.com', CAST(N'2020-06-19T17:47:11.2247820' AS DateTime2), 2, NULL, NULL, CAST(20290000 AS Decimal(18, 0)), CAST(10 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(15 AS Decimal(10, 0)), N'GEFORCE GTX1650 4GB INTEL CORE I5 9300H 8GB 512GB 15.6” IPS FHD BACKLIGHT KEYBOARD WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING MSI GF63 THIN 9SCXR 075VN', N'CPU	
Intel Core i5 9300H

GPU	
Geforce GTX 1650 MaxQ

Màn hình	
15.6" FHD (1920×1080), IPS

Hệ điều hành	
Windows 10 64Bit Home

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 4

Ổ cứng HDD	
1 slot HDD 2.5''

Ổ đĩa quang	
No ODD

Lan	
Gigabit Lan

Wireless Lan	
AC 9560 (2*2 a/c) + BT5

Các cổng kết nối	
1x (4K @ 30Hz) HDMI, 1x RJ45, 1x Type-C USB3.2 Gen1, 3x Type-A USB3.2 Gen1

Bàn phím	
Backlight Keyboard ( Red )
Pin	
3 Cell

Kích thước	
359 x 254 x 21.7 mm

Trọng lượng	
1.8 kg', N'Laptop', CAST(18261000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T17:46:13.0968989' AS DateTime2), 6, N'vyphat@gmail.com', CAST(N'2020-06-19T17:47:14.0405823' AS DateTime2), 2, NULL, NULL, CAST(20290000 AS Decimal(18, 0)), CAST(10 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(15 AS Decimal(10, 0)), N'GEFORCE GTX1650 4GB INTEL CORE I5 9300H 8GB 512GB 15.6” IPS FHD BACKLIGHT KEYBOARD WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING MSI BRAVO 15 A4DC 052VN', N'CPU	
AMD Ryzen 5 – 4600H

GPU	
Radeon RX5300M 3GB

Màn hình	
15.6" FHD (1920×1080), IPS

Hệ điều hành	
Windows 10 SL 64 Bit

RAM	
DDR4 8GB (1 x 8GB) 3200MHz; 2 slots, up to 32GB

Ổ cứng SSD	
256GB SSD NVMe M.2 PCIe Gen 3×2

Ổ cứng HDD	
1 slot HDD 2.5''

Ổ đĩa quang	
No ODD

Lan	
Gigabit Lan

Wireless Lan	
Intel Wi-Fi 6 AX201(2*2 ax) + BT5

Các cổng kết nối	
1x (4K @ 30Hz) HDMI, 1x RJ45, 1x Type-C USB3.2 Gen1, 3x Type-A USB3.2 Gen1

Bàn phím	
Backlight Keyboard ( Red )
Pin	
3 Cell

Kích thước	
359 x 254 x 21.7 mm

Trọng lượng	
1.8 kg', N'Laptop', CAST(18441000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T17:49:07.5217545' AS DateTime2), 7, N'vyphat@gmail.com', CAST(N'2020-06-19T17:54:45.8705142' AS DateTime2), 2, NULL, NULL, CAST(20490000 AS Decimal(18, 0)), CAST(10 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(20 AS Decimal(10, 0)), N'RADEON RX5300M RYZEN 5 4600H 8GB 256GB 15.6” IPS FHD BACKLIGHT KEYBOARD WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING MSI GL65 9SDK 254VN', N'CPU	
Intel Core i7 9750H

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

GPU	
Geforce GTX 1660Ti

Màn hình	
15.6" Full HD ( 1920 x 1080 ), 120Hz, IPS Panel

Hệ điều hành	
Windows 10 SL 64 Bit

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 2

Ổ cứng HDD	
1 slot HDD 2.5''

Ổ đĩa quang	
No ODD

Lan	
Killer Gb LAN

Wireless Lan	
802.11 ac Wi-Fi + Bluetooth v5

Các cổng kết nối	
1x (4K @ 60Hz) HDMI, 1x Mini-DisplayPort, 1x RJ45, 1x SD (XC/HC), 1x Type-A USB3.2 Gen2, 1x Type-C USB3.2 Gen2, 2x Type-A USB3.2 Gen1

Bàn phím	
Per-key RGB Keyboard
Pin	
6 Cell

Kích thước	
383 x 260 x 27~29 mm

Trọng lượng	
2.3 kg', N'Laptop', CAST(24690500 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T17:51:38.7030676' AS DateTime2), 8, N'vyphat@gmail.com', CAST(N'2020-06-19T17:54:50.2457766' AS DateTime2), 2, NULL, NULL, CAST(25990000 AS Decimal(18, 0)), CAST(5 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'GEFORCE GTX 1660TI 6GB INTEL CORE I7 9750H 8GB 512GB 15.6” FHD 120HZ IPS PERKEY MULTICOLOR WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING MSI GE66 RAIDER 10SF 044VN', N'CPU	
Intel Core i7 10750H

Hệ điều hành	
Windows 10 SL 64 Bit

RAM	
DDR4 16GB (2 x 8GB) 2666MHz, 2 slots, up to 32GB

GPU	
Geforce RTX 2070 8GB

Màn hình	
15.6" FHD (1920×1080) IPS, 240Hz

Ổ cứng SSD	
1TB SSD NVMe M.2 PCIe Gen 3 x 4

Lan	
Killer Gb LAN

Wireless Lan	
Killer Wi-Fi 6 AX1650i (2*2 ax) + BT5

Bàn phím	
SteelSeries Backlight Keyboard (Per-Key RGB, Full-Color)
Pin	
4 Cells, 99.9Whrs

Kích thước	
397 x 268.5 x 27.5 mm

Trọng lượng	
2.4 kg', N'Laptop', CAST(49491000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T17:52:59.2887499' AS DateTime2), 9, N'vyphat@gmail.com', CAST(N'2020-06-19T17:54:58.4142906' AS DateTime2), 2, NULL, NULL, CAST(54990000 AS Decimal(18, 0)), CAST(10 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(5 AS Decimal(10, 0)), N'RTX2070 8GB INTEL CORE I7 10750H 16GB SSD 1TB 15.6″ IPS 240HZ 3MS PERKEY RGB WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING MSI GS65 STEALTH 9SE 1000VN', N'CPU	
Intel Core i7 9750H

Hệ điều hành	
Windows 10 SL 64 Bit

RAM	
DDR4 16GB (2 x 8GB) 2666MHz, 2 slots, up to 32GB

GPU	
Geforce RTX 2060 6GB

Màn hình	
15.6" FHD IPS (1920×1080), 240Hz 3ms, 100% sRGB

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 4, 1 slot SSD NVMe M.2 PCIe Gen3 X4 hoặc M.2 SATA III

Lan	
Killer Gb LAN

Wireless Lan	
Killer Wireless-AC 1550i (2*2 a/c) + BT5

Bàn phím	
SteelSeries Backlight Keyboard (Per-Key RGB, Full-Color)
Pin	
4 Cells, 82WHrs

Kích thước	
357.7 x 247.7 x 17.9 mm

Trọng lượng	
1.9 kg', N'Laptop', CAST(4319100 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T17:54:35.8854268' AS DateTime2), 10, N'vyphat@gmail.com', CAST(N'2020-06-19T17:55:03.3095563' AS DateTime2), 2, NULL, NULL, CAST(4799000 AS Decimal(18, 0)), CAST(10 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'RTX2060 6GB INTEL CORE I7 9750H 16GB 512GB 15.6″ IPS 240HZ PERKEY RGB WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING ASUS TUF FX505DD-AL186T ', N'CPU	
AMD Ryzen 5 – 3550H

Hệ điều hành	
Windows 10 SL 64 Bit

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

GPU	
Geforce GTX 1050 3GB

Màn hình	
15.6" Full HD ( 1920 x 1080 ), 120Hz, IPS Panel

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 2

Ổ cứng HDD	
1 slot HDD 2.5''

Ổ đĩa quang	
No ODD

Lan	
Gigabit Lan

Wireless Lan	
802.11ac 2×2 Wi-Fi

Các cổng kết nối	
1 x 3.5mm Audio Jack, 1 x Type-A USB2.0, 1x (4K @ 30Hz) HDMI, 1x RJ45, 2 x Type-A USB 3.1 (Gen 1)

Bàn phím	
Backlight Keyboard Multicolor
Pin	
4 Cell , 48 Whr

Kích thước	
360.4 x 262.0 x 25.8 ~26.8 mm (WxDxH)

Trọng lượng	
2.2 kg', N'Laptop', CAST(21000000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T18:52:31.3461241' AS DateTime2), 11, N'vyphat@gmail.com', CAST(N'2020-06-19T19:12:13.2723401' AS DateTime2), 3, NULL, NULL, CAST(21000000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'GEFORCE GTX 1050 3GB RYZEN 5-3550H 8GB 512GB 15.6″ 120HZ IPS WIN 10 GOLD STEEL RGB
')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Laptop Asus TUF Gaming FX504GM-EN303T Geforce', N'CPU	
Intel Core i7 8750H

Hệ điều hành	
Windows 10 SL 64 Bit

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

GPU	
GeForce GTX 1060 6GB

Màn hình	
15.6" FHD (1920×1080), 120Hz 94% NTSC color Anti-glare

Ổ cứng SSD	
256GB SSD NVMe M.2 PCIe Gen 3×2

Ổ cứng HDD	
1TB-5400rpm SSH8G

Ổ đĩa quang	
No ODD

Lan	
Gigabit Lan

Wireless Lan	
802.11ac 2×2 Wi-Fi

Bàn phím	
Illuminated Chiclet Keyboard
Pin	
4 Cell , 48 Whr

Kích thước	
384 x 262 x 24 mm (WxDxH)

Trọng lượng	
2.2 kg', N'Laptop', CAST(20123900 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T18:57:38.2235115' AS DateTime2), 12, N'vyphat@gmail.com', CAST(N'2020-06-19T19:12:22.3155497' AS DateTime2), 3, NULL, NULL, CAST(32990000 AS Decimal(18, 0)), CAST(39 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(20 AS Decimal(10, 0)), N'GTX1060 6GB Intel Core i7 8750H 8GB 256GB 1TB 15.6″ FHD 120Hz Win 10 Premium Steel')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING ASUS TUF FA506IH-AL018T', N'CPU	
AMD Ryzen 5 – 4600H

Hệ điều hành	
Windows 10 SL 64 Bit

RAM	
DDR4 8GB (1 x 8GB) 3200MHz; 2 slots, up to 32GB

GPU	
Geforce GTX 1650 4GB

Màn hình	
15.6" FullHD (1920 x 1080). 144Hz, IPS Panel

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 4

Ổ cứng HDD	
1 slot HDD 2.5''

Lan	
Gigabit Lan

Wireless Lan	
802.11ac 2×2 Wi-Fi

Các cổng kết nối	
1 x 3.5mm Audio Jack, 1 x Type C USB3.1 (GEN2) support DP function, 1 x Type-A USB2.0, 1x (4K @ 30Hz) HDMI, 1x RJ45, 2 x Type-A USB 3.1 (Gen 1)

Bàn phím	
Backlight Keyboard Multicolor
Pin	
3 Cell, 48 Whr

Kích thước	
(WxDxH) 35.9 x 25.6 x 2.47 ~ 2.49 cm

Trọng lượng	
2.3 kg', N'Laptop', CAST(20490000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T18:59:32.2198800' AS DateTime2), 13, N'vyphat@gmail.com', CAST(N'2020-06-19T19:12:35.9260197' AS DateTime2), 3, NULL, NULL, CAST(20490000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'GTX 1650 4GB RYZEN 5-4600H 8GB 512GB 15.6″ FHD IPS 144HZ FORTRESS GRAY RGB')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'LAPTOP GAMING ASUS TUF FX705DD-AU100T', N'CPU	
AMD Ryzen 5 – 3550H

Hệ điều hành	
Windows 10 SL 64 Bit

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

GPU	
Geforce GTX 1050 3GB

Màn hình	
17.3" Full HD (1920 x 1080), IPS Panel

Ổ cứng SSD	
512GB SSD NVMe M.2 PCIe Gen 3 x 2

Ổ cứng HDD	
1 slot HDD 2.5''

Ổ đĩa quang	
No ODD

Lan	
Gigabit Lan

Wireless Lan	
802.11ac 2×2 Wi-Fi

Các cổng kết nối	
1 x 3.5mm Audio Jack, 1 x Type-A USB2.0, 1x (4K @ 30Hz) HDMI, 1x RJ45, 2 x Type-A USB 3.1 (Gen 1)

Bàn phím	
Backlight Keyboard Multicolor
Pin	
4 Cell , 48 Whr

Kích thước	
399.8 x 279.4 x 26.6 ~27.6 cm (WxDxH)

Trọng lượng	
2.6 kg', N'Laptop', CAST(17991000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:03:29.7866394' AS DateTime2), 14, N'vyphat@gmail.com', CAST(N'2020-06-19T19:12:41.7236497' AS DateTime2), 3, NULL, NULL, CAST(19990000 AS Decimal(18, 0)), CAST(10 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(50 AS Decimal(10, 0)), N'GEFORCE GTX 1050 3GB RYZEN 5-3550H 8GB 512GB 17.3″ FHD IPS WIN 10 GOLD STEEL RGB')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'ASUS ROG MOTHERSHIP GZ700GX-EV002R', N'CPU	
Intel Core i9 9980HK

Hệ điều hành	
Windows 10 64Bit Pro

RAM	
DDR4 64GB (4x16GB) 2666Mhz; 4 slot, upto 128GB

GPU	
Geforce RTX 2080 8GB

Màn hình	
17.3" FHD (1920×1080) IPS, Non-Glare, 300nits, 144Hz G-sync

Ổ cứng SSD	
1.5TB (512GB*3) SSD PCIe NVMe Gen 3 x 4

Ổ đĩa quang	
No ODD

Lan	
Killer Gb LAN

Wireless Lan	
802.11ac 2×2 Wi-Fi, Bluetooth 4.1

Các cổng kết nối	
1 x USB 3.1 Gen1 (Type-C); 4 x USB 3.1 Gen1; 1 x mDP 1.2; 1 x HDMI 1.4; 1 x RJ-45 Jack; 1 x 2-in-1 card reader; 1 x 3.5mm headphone and microphone combo jack; 1 x Kensington lock

Bàn phím	
RGB Perky Keyboard
Pin	
8 Cell, 71WHrs

Kích thước	
42.5(W) x 31.9(D) x 4.75 ~ 5.10 (H) cm

Trọng lượng	
4.7 KG', N'Laptop', CAST(179990000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:05:36.3601347' AS DateTime2), 15, N'vyphat@gmail.com', CAST(N'2020-06-19T19:12:48.6921846' AS DateTime2), 3, NULL, NULL, CAST(179990000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(5 AS Decimal(10, 0)), N'GEFORCE RTX 2080 8GB INTEL CORE I9 9980HK 64GB 512GB*3 SSD 17.3″ FHD IPS 144HZ 3MS G-SYNC WIN 10')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Bàn phím cơ ASUS ROG Strix Scope RGB Cherry MX Blue', N'Keyboard Type	
Full Size

Keyboard Switches	
Cherry MX Blue, Cherry MX Red

Keyboard Switch Durability	
50 million keystrokes

Keyboard Key Rollover	
104

Keyboard Tactile	
Non-Tactile, Tactile

Keyboard Clicky	
Clicky, Non-Clicky

Keyboard Backlighting	
RGB

Keyboard Backplate	
Aluminum

Keyboard Cable	
1.8 M', N'Keyboard', CAST(2907900 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:09:39.9831711' AS DateTime2), 16, N'vyphat@gmail.com', CAST(N'2020-06-19T19:12:55.5626203' AS DateTime2), 3, NULL, NULL, CAST(3590000 AS Decimal(18, 0)), CAST(19 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Bàn phím cao cấp của Asus
Thiết kế dành cho games FPS với phím Ctrl được X2 độ rộng
Mặt kim loại cứng cáp
Switch Cherry Blue
LED RGB cực đẹp, đồng bộ ')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Bàn phím cơ ASUS ROG Strix Scope RGB Cherry MX Red', N'Keyboard Type	
Full Size

Keyboard Switches	
Cherry MX Blue, Cherry MX Red

Keyboard Switch Durability	
50 million keystrokes

Keyboard Key Rollover	
104

Keyboard Tactile	
Non-Tactile, Tactile

Keyboard Clicky	
Clicky, Non-Clicky

Keyboard Backlighting	
RGB

Keyboard Backplate	
Aluminum

Keyboard Cable	
1.8 M', N'Keyboard', CAST(2907900 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:11:09.5025527' AS DateTime2), 17, N'vyphat@gmail.com', CAST(N'2020-06-19T19:13:00.3613875' AS DateTime2), 3, NULL, NULL, CAST(3590000 AS Decimal(18, 0)), CAST(19 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(110 AS Decimal(10, 0)), N'Bàn phím cao cấp của Asus
Thiết kế dành cho games FPS với phím Ctrl được X2 độ rộng
Mặt kim loại cứng cáp
Switch Cherry Red
LED RGB cực đẹp, đồng bộ A')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Bàn phím cơ ASUS ROG Strix Flare RGB Cherry Blue', N'Keyboard Type	
Full Size

Keyboard Switches	
Cherry MX Blue, Cherry MX Red

Keyboard Switch Durability	
50 million keystrokes

Keyboard Key Rollover	
104

Keyboard Tactile	
Non-Tactile, Tactile

Keyboard Clicky	
Clicky, Non-Clicky

Keyboard Backlighting	
RGB

Keyboard Backplate	
Aluminum

Keyboard Cable	
1.8 M', N'Keyboard', CAST(3990000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:16:20.4443289' AS DateTime2), 18, N'vyphat@gmail.com', CAST(N'2020-06-19T19:18:41.0172798' AS DateTime2), 3, NULL, NULL, CAST(3990000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'Switch Cherry Blue
Led RGB cực đẹp, đồng bộ Aura Sync
Kê tay đi kèm, có thể tháo rời
Tích hợp cụm phím đa phương tiện')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Bàn phím cơ ASUS ROG Claymore Aura RGB Cherry MX Red', N'Keyboard Type	
Full Size

Keyboard Switches	
Cherry MX Blue, Cherry MX Red

Keyboard Switch Durability	
50 million keystrokes

Keyboard Key Rollover	
104

Keyboard Tactile	
Non-Tactile, Tactile

Keyboard Clicky	
Clicky, Non-Clicky

Keyboard Backlighting	
RGB

Keyboard Backplate	
Aluminum

Keyboard Cable	
1.8 M', N'Keyboard', CAST(4500000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:18:31.0657426' AS DateTime2), 19, N'vyphat@gmail.com', CAST(N'2020-06-19T19:18:47.6257437' AS DateTime2), 3, NULL, NULL, CAST(4500000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Bàn phím cao cấp nhất của Asus
Switch Cherry Red
Phần numpad có thể tháo rời, gắn qua lại trái phải cực kì thuận tiện
')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Bàn phím GIGABYTE AORUS K9 Optical RGB Gaming Keyboard', N'Keyboard Type	
Full Size

Keyboard Switches	
FlareTech Optical

Keyboard Switch Durability	
100 Millions

Keyboard Tactile	
Non-Tactile, Tactile

Keyboard Clicky	
Clicky, Non-Clicky

Keyboard Backlighting	
RGB

Keyboard Backplate	
Aluminum

Keyboard Cable	
1.8 M', N'Keyboard', CAST(3087500 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:21:43.8811717' AS DateTime2), 20, N'vyphat@gmail.com', CAST(N'2020-06-19T19:24:40.5019151' AS DateTime2), 1, NULL, NULL, CAST(3250000 AS Decimal(18, 0)), CAST(5 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'Bảo hành 12 tháng chính hãng')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Bàn phím cơ không dây Gigabyte SK621 RGB CherryMX Red', N'Switch cơ học Cherry MX RED Low Profile
Layout 60% cực gọn gàng và di động
Tính năng không dây với Bluetooth 4.0 hỗ trợ cùng lúc 3 thiết bị
Các phím điều khiển tích hợp sẵn.
Siêu mỏng, siêu nhẹ.
Bảo hành chính hãng 24 tháng.', N'Keyboard', CAST(2691000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:24:06.1184251' AS DateTime2), 22, N'vyphat@gmail.com', CAST(N'2020-06-19T19:24:31.2971650' AS DateTime2), 1, NULL, NULL, CAST(2990000 AS Decimal(18, 0)), CAST(10 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), N'Switch cơ học Cherry MX RED Low Profile
Layout 60% cực gọn gàng và di động
Tính năng không dây với Bluetooth 4.0 hỗ trợ cùng lúc 3 thiết bị')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Chuột MSI Gaming CLUTCH GM40', N'Mouse Max. resolution	
5000 DPI

Mouse Buttons	
9

Mouse Led	
RED

Mouse Weight	
129g

Mouse Width	
125 mm

Mouse Depth	
69 mm

Mouse Height	
39 mm

Mouse Cable Length	
2 M

Mouse Buttons Durability (Left / Right)	
50 million clicks
Mouse USB report rate	
1000 Hz', N'Mouse', CAST(790000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:35:18.5230810' AS DateTime2), 23, N'vyphat@gmail.com', CAST(N'2020-06-19T19:38:50.0977278' AS DateTime2), 2, NULL, NULL, CAST(790000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(200 AS Decimal(10, 0)), N'Bảo hành 12 tháng')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Chuột Gaming không dây ASUS ROG Chakram', N'Trọng lượng 126g

Điều chỉnh DPI nhanh, DPI tối đa 16,000

Nút analog đặc biệt

Kết nối không dây 2.4Ghz, Bluetooth Low-Energy

Kết nối qua dây, kiêm sạc USB-C

Sạc nhanh, sạc không dây Qi

Thời lượng pin 79 tiếng một lần sạc, sạc nhanh 15 phút cho thời lượng 12 tiếng', N'Mouse', CAST(3890000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:38:40.4088690' AS DateTime2), 24, N'vyphat@gmail.com', CAST(N'2020-06-19T19:38:55.5118197' AS DateTime2), 3, NULL, NULL, CAST(3890000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(50 AS Decimal(10, 0)), N'Trọng lượng 126g

Điều chỉnh DPI nhanh, DPI tối đa 16,000

Nút analog đặc biệt

Kết nối không dây 2.4Ghz, Bluetooth Low-Energy

')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Chuột Gaming không dây ASUS ROG Strix Carry', N'Chuột chơi game không dây kích thước bỏ túi trang bị công nghệ hiệu năng cao bao gồm khả năng kết nối không dây kép thông qua sóng RF 2,4GHz độ trễ 1ms và Bluetooth
Dung lượng pin cực khủng trên 300+ giờ ở băng tần 2,4 Ghz và 400+ giờ khi kết nối Bluetooth
Cảm biến quang học PMW3330 đẳng cấp chơi game lên tới 7200 DPI
Công nghệ SmartHop hỗ trợ chuyển đổi khả năng kết nối liền mạch sang các kênh mượt nhất
Thiết kế ổ cắm độc quyền ROG cho phép thay thế công tắc dễ dàng để tùy chỉnh lực nhấp chuột', N'Mouse', CAST(1385800 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:46:52.5302161' AS DateTime2), 25, N'vyphat@gmail.com', CAST(N'2020-06-19T20:03:24.8538588' AS DateTime2), 3, NULL, NULL, CAST(1690000 AS Decimal(18, 0)), CAST(18 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Chuột chơi game không dây kích thước bỏ túi trang bị công nghệ hiệu năng cao bao gồm khả năng kết nối không dây kép thông qua sóng RF 2,4GHz độ trễ 1m')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Chuột Gaming ASUS ROG Strix Impact', N'Mouse Max. resolution	
5000 DPI

Mouse Buttons	
Adjustable

Mouse Led	
RGB

Mouse Weight	
112g

Mouse Width	
62mm

Mouse Depth	
39 mm

Mouse Height	
115mm

Mouse Buttons Durability (Left / Right)	
50 million clicks
Mouse USB report rate	
1000 Hz', N'Mouse', CAST(693000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T19:50:43.1495374' AS DateTime2), 26, N'vyphat@gmail.com', CAST(N'2020-06-19T20:03:29.2293998' AS DateTime2), 3, NULL, NULL, CAST(990000 AS Decimal(18, 0)), CAST(30 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Thiết kế đối xứng
LED RGB cực đẹp
Hỗ trợ Aura Sync
5000 DPI
')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Màn hình LCD Dell P2719H 27” IPS FullHD', N'Monitor Type	
LED

Monitor Panel	
AH-IPS

Monitor Size	
27''''

Monitor Resolution	
1920×1080

Monitor Refresh rate	
60Hz

Monitor Aspect Ratio	
16:9

Monitor Contrast Ratio	
1000 :1

Monitor Color Depth	
16.7M

Monitor Brightness	
300 cd/m2

Monitor Response time	
5ms, 8ms

Monitor Ports	
D-Sub, DisplayPort, HDMI, USB

Monitor Wall Mount	
100mm x 100mm

Monitor Brand	
Dell', N'Others', CAST(4988200 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:00:02.3210742' AS DateTime2), 27, N'vyphat@gmail.com', CAST(N'2020-06-19T20:03:33.3174116' AS DateTime2), 4, NULL, NULL, CAST(5090000 AS Decimal(18, 0)), CAST(2 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'
Bảo hành chính hãng 36 tháng')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Laptop Dell G3 Inspiron 3579 70167040 (Black)', N'CPU	
Intel Core i7 8750H

Hệ điều hành	
Free Dos

RAM	
DDR4 8GB (1 x 8GB) 2666MHz; 2 slots, up to 32GB

GPU	
GeForce GTX 1050Ti 4GB

Màn hình	
15.6" FHD (1920×1080), IPS

Ổ cứng SSD	
SSD M.2 128GB

Ổ cứng HDD	
1TB HDD 5400 rpm

Ổ đĩa quang	
No ODD

Lan	
Gigabit Ethernet

Wireless Lan	
802.11ac 2×2 Wi-Fi

Các cổng kết nối	
1x 2-in-1 SD/MicroMedia card 2x SuperSpeed USB 3.1 Gen 1 Type-A 1x Power/DC-in Jack 1x HDMI 2.0 1x Gigabit Ethernet RJ-45 1x Headphone/Mic

Bàn phím	
Backlit keyboard
Pin	
4 Cells, 56WHrs

Kích thước	
389 x 274 x 24.95 mm

Trọng lượng	
2.5 kg', N'Laptop', CAST(23510400 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:01:41.7351287' AS DateTime2), 28, N'vyphat@gmail.com', CAST(N'2020-06-19T20:03:39.2522125' AS DateTime2), 4, NULL, NULL, CAST(24490000 AS Decimal(18, 0)), CAST(4 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(20 AS Decimal(10, 0)), N'Geforce GTX1050Ti 4GB Intel Core i7 8750H 128GB 8GB 1TB HDD 15.6 FHD')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'BALO LAPTOP XGEAR MẪU DELL 17″', N'Balo laptop tiện lợi, chất liệu vải cứng cáp

Gồm 2 ngăn chính, trong đó có 1 ngăn chứa vừa laptop lên đến 17″

Có chỗ để bình nước bên hông

Lớp lót mút sau lưng cực kì thoáng khí và êm ái', N'Others', CAST(400000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:03:12.3903697' AS DateTime2), 29, N'vyphat@gmail.com', CAST(N'2020-06-19T20:03:44.4451252' AS DateTime2), 4, NULL, NULL, CAST(400000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Balo laptop tiện lợi, chất liệu vải cứng cáp')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Màn hình Dell Alienware 25″ AW2518H 240Hz G-sync 1ms', N'Monitor Type	
LCD, LED

Monitor Panel	
TN

Monitor Size	
25''''

Monitor Resolution	
1920×1080

Monitor Refresh rate	
240 Hz

Monitor Aspect Ratio	
16:9

Monitor Contrast Ratio	
1000 :1

Monitor Color Depth	
16.7M

Monitor Color Gamut	
82% NTSC

Monitor Brightness	
400 cs/m2

Monitor Response time	
1ms

Monitor Ports	
DisplayPort, HDMI, USB

Monitor Technology	
G-Sync

Monitor Wall Mount	
100mm x 100mm

Monitor Brand	
Allienware, Dell', N'Others', CAST(15490000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:05:52.3494267' AS DateTime2), 30, N'vyphat@gmail.com', CAST(N'2020-06-19T20:12:39.5545294' AS DateTime2), 4, NULL, NULL, CAST(15490000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(2 AS Decimal(10, 0)), N'Màn hình Dell Alienware 25″ AW2518H 240Hz G-sync 1ms')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Nguồn Deepcool DN550 550W – 80 Plus White', N'Modello	DN550
Tipo	ATX 12V V2.31
Total Output	550W
Voltaggio di alimentazione	230V
Corrente di alimentazione	4.0A
Range di frequenza in ingresso	47~63Hz
Dimensionie della Ventola	120mm
Fattore di correzione di potenza	Active Fattore di correzione di potenza (>0.99)
Segnale Power Good (ms)	100-500ms
Tempo di Hold Up	>16ms
Efficienza	85% Under Typical Load
Protezioni	OVP/UVP/SCP/OPP
Temperatura operativa	0~40°C
Regolatore	CE/CB/EAC/CCC
MTBF	100,000 Hours', N'Others', CAST(1000000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:07:21.2844501' AS DateTime2), 31, N'vyphat@gmail.com', CAST(N'2020-06-19T20:12:45.8883926' AS DateTime2), 4, NULL, NULL, CAST(1000000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(10 AS Decimal(10, 0)), N'Bảo hành 36 tháng.')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Màn hình LCD Dell P2419HC 24” USB-C IPS FullHD', N'Monitor Type	
LCD

Monitor Panel	
IPS

Monitor Size	
24''''

Monitor Resolution	
1920×1080

Monitor Refresh rate	
60Hz

Monitor Aspect Ratio	
16:9

Monitor Contrast Ratio	
1000 :1

Monitor Color Depth	
16.7M

Monitor Color Gamut	
82% NTSC

Monitor Brightness	
250 cd/m2

Monitor Response time	
6ms

Monitor Ports	
DP, HDMI, USB, VGA

Monitor Technology	
Blue Light Filter, Flicker-Free

Monitor Brand	
Dell

Monitor Wall Mount	
100mm x 100mm', N'Others', CAST(5490000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:08:44.2518100' AS DateTime2), 32, N'vyphat@gmail.com', CAST(N'2020-06-19T20:12:50.3456225' AS DateTime2), 4, NULL, NULL, CAST(5490000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Bảo hành chính hãng 36 tháng.')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Chuột Gigabyte Aorus M2', N'Chuột gaming với trọng lượng siêu nhẹ
Mắt đọc quang học với DPI 6200
Switch Omron 50 triệu lần nhấn
RGB Fusion 2.0 – sync với các phần cứng Aorus khác của bạn
Thiết kế công thái học
Phù hợp cả 2 tay
Nút chỉnh DPI nhanh trên thân chuột
Bảo hành 24 tháng', N'Mouse', CAST(519200 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:11:08.5633399' AS DateTime2), 33, N'vyphat@gmail.com', CAST(N'2020-06-19T20:12:54.3933520' AS DateTime2), 1, NULL, NULL, CAST(590000 AS Decimal(18, 0)), CAST(12 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Chuột gaming với trọng lượng siêu nhẹ')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Chuột Gigabyte Aorus M4 RGB', N'Thiết kế đối xứng phù hợp với cả 2 tay
Mắt đọc quang học cao cấp 6400DPI cho phép tăng từng nấc 50dpi
Omron switch với 50 triệu lần nhấn
RGB Fusion 2.0 – đồng bộ với các thiết bị Aorus khác
Các nút đều có thể lập trình và lưu trực tiếp trên chuột
Tích hợp nút chuyển DPI nhanh
Bảo hành chính hãng 12 tháng', N'Mouse', CAST(950000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:12:32.9151760' AS DateTime2), 34, N'vyphat@gmail.com', CAST(N'2020-06-19T20:12:58.2731999' AS DateTime2), 1, NULL, NULL, CAST(950000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Thiết kế đối xứng phù hợp với cả 2 tay')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Chuột Gigabyte Aorus M5 RGB', N'Thiết kế công thái học phù hợp với người thuận tay phải
Mắt đọc quang học cao cấp Pixart 3389 với 16000DPI
Omron switch Nhật Bản với 50 triệu lần nhấn
RGB Fusion 2.0 – đồng bộ với các thiết bị Aorus khác
Các nút đều có thể lập trình và lưu trực tiếp trên chuột
Tích hợp nút chuyển DPI nhanh
Bảo hành chính hãng 12 tháng', N'Mouse', CAST(1390000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:14:24.6177893' AS DateTime2), 35, N'vyphat@gmail.com', CAST(N'2020-06-19T20:25:55.6445965' AS DateTime2), 1, NULL, NULL, CAST(1390000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Thiết kế công thái học phù hợp với người thuận tay phải')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Màn hình cong 32″ Gigabyte', N'Monitor Type	
curved monitor, LED

Monitor Panel	
VA

Monitor Size	
32''''

Monitor Resolution	
2560 x 1440

Monitor Refresh rate	
165 Hz

Monitor Aspect Ratio	
16:9

Monitor Contrast Ratio	
3000:1

Monitor Color Depth	
16.7M

Monitor Brightness	
250 cd/m2

Monitor Response time	
1ms MPRT

Monitor Ports	
DisplayPort, HDMI, USB

Monitor Technology	
Free Sync, G-sync Compatible

Monitor Wall Mount	
100mm x 100mm

Monitor Brand	
Gigabyte', N'Others', CAST(9890100 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T13:20:57.2780000' AS DateTime2), 36, N'vyphat@gmail.com', CAST(N'2020-06-19T20:26:18.8436194' AS DateTime2), 1, N'vyphat@gmail.com', CAST(N'2020-06-19T20:26:12.2549998' AS DateTime2), CAST(9990000 AS Decimal(18, 0)), CAST(1 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Bảo hành chính hãng 36 tháng')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Màn hình cong 27″ Gigabyte G27FC FullHD 165Hz 1ms MPRT G-sync Compatible', N'Monitor Type	
curved monitor, LED

Monitor Panel	
VA

Monitor Size	
27''''

Monitor Resolution	
1920×1080

Monitor Refresh rate	
165 Hz

Monitor Aspect Ratio	
16:9

Monitor Contrast Ratio	
3000:1

Monitor Color Depth	
16.7M

Monitor Brightness	
250 cd/m2

Monitor Response time	
1ms MPRT

Monitor Ports	
DisplayPort, HDMI, USB

Monitor Technology	
Free Sync, G-sync Compatible

Monitor Wall Mount	
100mm x 100mm

Monitor Brand	
Gigabyte

', N'Others', CAST(6490000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:22:36.0059722' AS DateTime2), 37, N'vyphat@gmail.com', CAST(N'2020-06-19T20:26:04.0103167' AS DateTime2), 1, NULL, NULL, CAST(6490000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'Bảo hành chính hãng 36 tháng')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'CASE GIGABYTE AORUS AC300G Temperess Glass ATX Mid-tower', N'Case Form Factor: Mid Tower
M/B Type: mini-ITX/m-ATX/ATX
Color: Black
Materials: Steel, Plastic, Temperess Glass
Dimensions: H469*W211*D458 mm
3.5“/2.5” Driver Bays: 2
2.5″ Driver Bays: 3 (Behind the MB tray)
I/O Panel
HDMI x1
USB Type-C x1
USB 3.0 x 2
Audio in & out (supports AC97 / HD Audio)
Expansion Slot: 7 or 2 (requires PCIE riser cable)
Fan Support
Front : 120mm*3 / 140mm *2 
Top :    120 mm*2/ 140mm*2 
Rear :  120mm*1 / 140mm*1 
(Default: Rear 120mm*1+ Front 120mm*1)
Power Supply Type: Standard ATX (Not included)
Maximum Compatibility
CPU Height : 170mm
VGA Length : 400mm
PSU Length : 180mm', N'Others', CAST(2390000 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:24:20.6527364' AS DateTime2), 38, N'vyphat@gmail.com', CAST(N'2020-06-19T20:26:25.4029885' AS DateTime2), 1, NULL, NULL, CAST(2390000 AS Decimal(18, 0)), CAST(0 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'CASE GIGABYTE AORUS AC300G TEMPERESS GLASS ATX MID-TOWER')
GO
INSERT [dbo].[Products] ([Name], [Desc], [Type], [Price], [CreateBy], [AuthStatus], [CreateDate], [Id], [AuthBy], [AuthDate], [ProducerId], [LastUpdateBy], [LastUpdateDate], [OriginalPrice], [Sale], [Sold], [Stock], [ShortDesc]) VALUES (N'Nguồn Gigabyte PB500 500W 80Plus Bronze', N'80 PLUS Bronze certified
120mm Silent Fan
Single +12V rail
OPP/UVP/OVP/SCP/OCP/OTP Fully protection
Bảo hành 3 năm chính hãng', N'Others', CAST(987500 AS Decimal(18, 0)), N'vyphat@gmail.com', N'Approved', CAST(N'2020-06-19T20:25:49.0271372' AS DateTime2), 39, N'vyphat@gmail.com', CAST(N'2020-06-19T20:26:29.9945841' AS DateTime2), 1, NULL, NULL, CAST(1250000 AS Decimal(18, 0)), CAST(21 AS Decimal(2, 0)), CAST(0 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), N'80 PLUS Bronze certified
120mm Silent Fan
Single +12V rail
OPP/UVP/OVP/SCP/OCP/OTP Fully protection
Bảo hành 3 năm chính hãng')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ImageUrls] ON 
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (2, 4, N'http://localhost:5000/Image/Laptop_Asus_02_01.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (3, 5, N'http://localhost:5000/Image/Laptop_Asus_02_01.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (4, 6, N'http://localhost:5000/Image/Laptop_Asus_04_01.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (5, 7, N'http://localhost:5000/Image/Laptop_Asus_05_01.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (6, 8, N'http://localhost:5000/Image/Laptop_MSI_01_01.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (7, 9, N'http://localhost:5000/Image/Laptop_MSI_02_01.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (8, 10, N'http://localhost:5000/Image/Laptop_MSI_03_01.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (9, 11, N'http://localhost:5000/Image/Laptop_Asus_06_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (10, 11, N'http://localhost:5000/Image/Laptop_Asus_06_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (11, 12, N'http://localhost:5000/Image/Laptop_Asus_07_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (12, 12, N'http://localhost:5000/Image/Laptop_Asus_07_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (13, 13, N'http://localhost:5000/Image/Laptop_Asus_08_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (14, 13, N'http://localhost:5000/Image/Laptop_Asus_08_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (15, 14, N'http://localhost:5000/Image/Laptop_Asus_09_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (16, 14, N'http://localhost:5000/Image/Laptop_Asus_09_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (17, 14, N'http://localhost:5000/Image/Laptop_Asus_09_3.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (18, 15, N'http://localhost:5000/Image/Laptop_Asus_10_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (19, 15, N'http://localhost:5000/Image/Laptop_Asus_10_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (20, 15, N'http://localhost:5000/Image/Laptop_Asus_10_3.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (21, 16, N'http://localhost:5000/Image/Keyboard_Asus_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (22, 16, N'http://localhost:5000/Image/Keyboard_Asus_01_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (23, 17, N'http://localhost:5000/Image/Keyboard_Asus_02_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (24, 17, N'http://localhost:5000/Image/Keyboard_Asus_02_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (25, 18, N'http://localhost:5000/Image/Keyboard_Asus_03_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (26, 18, N'http://localhost:5000/Image/Keyboard_Asus_03_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (27, 19, N'http://localhost:5000/Image/Keyboard_Asus_04_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (28, 19, N'http://localhost:5000/Image/Keyboard_Asus_04_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (29, 20, N'http://localhost:5000/Image/Keyboard_Gigabyte_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (30, 20, N'http://localhost:5000/Image/Keyboard_Gigabyte_01_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (33, 22, N'http://localhost:5000/Image/Keyboard_Gigabyte_02_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (34, 22, N'http://localhost:5000/Image/Keyboard_Gigabyte_02_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (35, 23, N'http://localhost:5000/Image/Mouse_MSI_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (36, 23, N'http://localhost:5000/Image/Mouse_MSI_01_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (37, 24, N'http://localhost:5000/Image/Mouse_ASUS_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (38, 24, N'http://localhost:5000/Image/Mouse_ASUS_01_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (39, 25, N'http://localhost:5000/Image/Mouse_ASUS_02_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (40, 25, N'http://localhost:5000/Image/Mouse_ASUS_02_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (41, 26, N'http://localhost:5000/Image/Mouse_ASUS_03_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (42, 26, N'http://localhost:5000/Image/Mouse_ASUS_03_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (43, 27, N'http://localhost:5000/Image/Others_Dell_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (44, 27, N'http://localhost:5000/Image/Others_Dell_01_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (45, 27, N'http://localhost:5000/Image/Others_Dell_01_3.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (46, 28, N'http://localhost:5000/Image/Laptop_Dell_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (47, 28, N'http://localhost:5000/Image/Laptop_Dell_01_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (48, 29, N'http://localhost:5000/Image/Others_Dell_02_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (49, 29, N'http://localhost:5000/Image/Others_Dell_02_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (50, 30, N'http://localhost:5000/Image/Others_Dell_03_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (51, 30, N'http://localhost:5000/Image/Others_Dell_03_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (52, 30, N'http://localhost:5000/Image/Others_Dell_03_3.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (53, 31, N'http://localhost:5000/Image/Others_Dell_04_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (54, 31, N'http://localhost:5000/Image/Others_Dell_04_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (55, 32, N'http://localhost:5000/Image/Others_Dell_05_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (56, 32, N'http://localhost:5000/Image/Others_Dell_05_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (57, 33, N'http://localhost:5000/Image/Mouse_Gigabyte_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (58, 33, N'http://localhost:5000/Image/Mouse_Gigabyte_01_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (59, 34, N'http://localhost:5000/Image/Mouse_Gigabyte_02_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (60, 34, N'http://localhost:5000/Image/Mouse_Gigabyte_02_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (61, 35, N'http://localhost:5000/Image/Mouse_Gigabyte_03_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (62, 35, N'http://localhost:5000/Image/Mouse_Gigabyte_03_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (65, 37, N'http://localhost:5000/Image/Others_Gigabyte_02_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (66, 37, N'http://localhost:5000/Image/Others_Gigabyte_02_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (67, 38, N'http://localhost:5000/Image/Others_Gigabyte_03_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (68, 38, N'http://localhost:5000/Image/Others_Gigabyte_03_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (69, 39, N'http://localhost:5000/Image/Others_Gigabyte_04_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (70, 39, N'http://localhost:5000/Image/Others_Gigabyte_04_2.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (71, 36, N'http://localhost:5000/Image/Others_Gigabyte_01_1.png')
GO
INSERT [dbo].[ImageUrls] ([Id], [ProductId], [Url]) VALUES (72, 36, N'http://localhost:5000/Image/Others_Gigabyte_01_2.png')
GO
SET IDENTITY_INSERT [dbo].[ImageUrls] OFF
GO
