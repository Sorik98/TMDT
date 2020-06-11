using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Const;
using WebApi.Database.Context;
using WebApi.Infrastructure.Models;

namespace WebApi.Database.Seed
{
    public class SeedData
    {
        public static async Task InitializeAync(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Producers.Any())
            {
                await context.Producers.AddAsync(
                    new Producer
                    {
                        Name = "Gigabyte",
                        Desc = @"GIGABYTE Technology Co., Ltd. là một nhà sản xuất và phân phối các thiết bị phần cứng máy tính có trụ sở ở Đài Loan.
GIGABYTE là nhà cung cấp bo mạch chủ, với 4.8 triệu bo mạch chủ được bán ra trong Quý 1/2015, trong khi đó ASUS bán được khoảng 4.5 triệu bo mạch chủ trong cùng quý. GIGABYTE được xếp hạng 17 tại “Taiwan’s 2010 Top 20 Global Brands” bởi Taiwan External Trade Development Council.

Được thành lập năm 1986 với Pei-Cheng Yeh. Các sản phẩm của GIGABYTE được sử dụng trong Alienware, Falcon Northwest, và Origin PC.

Một tính năng quan trọng của GIGABYTE quay trở lại vào năm 2006 là bo mạch chủ Ultra-Durable. Vào ngày 8 tháng 8 năm 2006 GIGABYTE công bố một liên doanh với ASUS. GIGABYTE phát triển chương trình quản lý điện năng đầu tiên trên thế giới trong tháng 7 năm 2007.

Một phương thức sáng tạo để sạc iPad và iPhonetrên máy tính được giới thiệu bởi GIGABYTE vào tháng 4/2010.Gigabyte ra mắt bo mạch chủ Z68 đầu tiên trên thế giới vào 31/5/2011, với mSATA Onboad cho Intel® SSDs and Smart Response TechnologyNgày 02 tháng 4 năm 2012, Gigabyte phát triển bo mạch chủ đầu tiên trên thế giới với 60A IC chuẩn quốc tế.

GIGABYTE cam kết cung cấp các giải pháp hàng đầu để “nâng cấp cuộc sống của bạn”. Được coi là nhà sản xuất tiên phong trong sự đột phá về đổi mới công nghệ với công nghệ Ultra Durable – một công nghệ mang tính cách mạng của ngành công nghiệp máy tính, bên cạnh đó là thiết kế về hệ thống tản nhiệt WINDFORCE, và công nghệ máy tính mini đa năng với BRIX. Tham gia vào cuộc chạy đua về sản phẩm gaming, GIGABYTE cho ra mắt dòng sản phẩm AORUS – Dòng sản phẩm dành riêng cho giới game thủ."
 ,
                        AuthStatus = AuthStatus.Approved,
                        AuthBy = "daochihao98@gmail.com",
                        AuthDate = DateTime.Now,
                        CreateBy = "daochihao98@gmail.com",
                        CreateDate = DateTime.Now
                    }
                );

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
               var productId =  await context.Products.AddAsync(
                    new Product
                    {
                        Name = @"Laptop Gaming Acer Nitro 5 2020 AN515-43 R9FD",
                        Desc = @"Tất cả các sản phẩm Gaming Acer (*) được cam kết bảo hành trong vòng 03 ngày (72 giờ) bao gồm cả ngày thứ bảy và ngày chủ nhật (**). Acer cam kết sẽ đổi sản phẩm mới cùng loại hoặc tương đương (1 đổi 1) cho các trường hợp không hoàn thành bảo hành trong 03 ngày. 

                                Đặc biệt sản phẩm Máy tính để bàn Gaming và Màn hình máy tính Gaming được bảo hành tận nơi (On-site) tại 02 thành phố Hồ Chí Minh và Hà Nội. Các sản phẩm Gaming khác áp dụng hình thức dịch vụ khách hàng mang sản phẩm đến Trung tâm Bảo hành (Carry-in) tại các tỉnh thành có Trung tâm Bảo hành của Acer (***). 

                                (*) Danh sách các sản phẩm Gaming Acer 

                                Máy tính xách tay Gaming (Notebook)

                                Predator 21X (GX21-71)
                                Predator 17X (GX-792)
                                Predator Triton 700 (PT715-51)
                                Predator Helios 300 (G3-572)
                                Acer Nitro 5 (AN515-51)
                                Acer A7 (A715-71G)
                                Acer VX5 (VX5-591G)
                                Máy tính để bàn Gaming (Desktop)

                                Predator Orion 9000
                                Predator G9         
                                Predator G6 
                                Predator G3                        
                                Predator G1         
                                Màn hình máy tính Gaming (Monitor)

                                Acer XR382 (XR382CQK)
                                Predator Z35P (Z35P)
                                Predator X34 (X34A)
                                Predator XB27 (XB271H, XB270H)
                                Predator XF240 (XF240H)
                                (**) Thời gian bảo hành

                                Carry-in: Từ khi nhận sản phẩm đến khi sản phẩm được sửa chữa hoàn thành (có thể trả sản phẩm tốt cho khách hàng).
                                Onsite: Từ khi nhận yêu cầu dịch vụ thông qua tổng đài 1900-969601 hoặc email acercare.vn@acer.com đến khi sản phẩm được sửa chữa hoàn thành.
                                Ghi chú: Thời gian bảo hành được tính từ thời điểm khách hàng cung cấp chứng từ mua hàng cho các trường hợp sản phẩm cần chứng minh ngày mua do sản phẩm đã quá thời hạn bảo hành dựa theo ngày sản xuất. ",
                                Price = 20690000,
                                ProducerId = 5,
                                Type = "Laptop",
                                AuthStatus = AuthStatus.Submitted,
                                CreateBy = "daochihao98@gmail.com",
                                CreateDate = DateTime.Now
                    }
                );
                await context.SaveChangesAsync();
                //  await context.ImageUrls.AddRangeAsync(
                    
                // );
                // productId
                // await context.SaveChangesAsync();
            }
            if(!context.ImageUrls.Any()){
                await context.ImageUrls.AddRangeAsync(new ImageUrl[] {
                    new ImageUrl{
                        ProductId = 18,
                        Url = "assets/img/Laptop/Acer/Laptop_Acer_1_1.png"
                    },
                    new ImageUrl{
                        ProductId = 18,
                        Url = "assets/img/Laptop/Acer/Laptop_Acer_1_2.png"
                    },
                    new ImageUrl{
                        ProductId = 18,
                        Url = "assets/img/Laptop/Acer/Laptop_Acer_1_3.png"
                    },
                    new ImageUrl{
                        ProductId = 18,
                        Url = "assets/img/Laptop/Acer/Laptop_Acer_1_4.png"
                    },
                    new ImageUrl{
                        ProductId = 18,
                        Url = "assets/img/Laptop/Acer/Laptop_Acer_1_5.png"
                    },
                });
                await context.SaveChangesAsync();
            }
        }

    }
}