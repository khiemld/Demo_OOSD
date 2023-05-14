using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project
{
    public class HeThongDieuKhien
    {
        DieuKhienCSDL db = new DieuKhienCSDL();
        public void DangNhap()
        {
            string email;
            string password;
            Console.WriteLine("[Vui long dang nhap]");
            Console.Write("Tai khoan: ");
            email = Console.ReadLine();
            Console.Write("Mat Khau ");
            password = Console.ReadLine();
            bool test = db.authLogin(email, password);
            if (test)
            {
                Console.Clear();
                HienThiMenu();
            }
            else{
                Console.WriteLine("Dang nhap that bai");
            }
        }

        public void HienThiMenu()
        {
            int luaChon;
            Console.WriteLine("============CHUC NANG QUAN LY==========");
            Console.WriteLine("1. Quan ly Sach");
            Console.WriteLine("2. Quan ly NhanVien");
            Console.WriteLine("Vui long chon chuc nang");
            Console.WriteLine("========================================");

            luaChon = Convert.ToInt32(Console.ReadLine());

            if(luaChon == 1)
            {
                Console.Clear();
                hienThiDanhSachQuanLySach();
            }    

        }

        public void hienThiDanhSachQuanLySach()
        {
            int luaChon;
            Console.WriteLine("======CHUC NANG QUAN LY SACH===========");
            Console.WriteLine("1. Them Sach");
            Console.WriteLine("2. Chinh sua Sach");
            Console.WriteLine("3. Xem thong tin Sach");
            Console.WriteLine("========================================");

            luaChon = Convert.ToInt32(Console.ReadLine());

            if(luaChon == 1)
            {
                Console.WriteLine("Ban dang thuc hien chuc nang Them Sach. Nhan Enter de tiep tuc");
                Console.WriteLine("Nhap ten sach: ");
                string tenSach = Console.ReadLine();
                Console.WriteLine("Nhap mo ta: ");
                string moTa = Console.ReadLine();
                Console.WriteLine("Nhap loai sach: ");
                string loaiSach = Console.ReadLine();
                Console.WriteLine("Nhap ngay xuat ban: ");
                string ngayXB = Console.ReadLine();
                Console.WriteLine("Nhap ten tac gia: ");
                string tenTG = Console.ReadLine();
                Console.WriteLine("Nhap ten nha xuat ban: ");
                string tenNXB = Console.ReadLine();
                Console.WriteLine("Nhap gia sach: ");
                int giaSach = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap so luong: ");
                int soLuong = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Ban co muon luu thong tin khong? Nhan 'Y' de xac nhan hoac 'N' la khong xac nhan");

                char xacnhan = Convert.ToChar(Console.ReadLine());

                if(xacnhan == 'Y')
                {
                    bool test = db.themSach(tenSach, moTa, loaiSach, ngayXB, tenTG, tenNXB, giaSach, soLuong);

                    if (test)
                    {
                        Console.WriteLine("Thong tin da luu vao co so du lieu thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("Them sach khong thanh cong");
                    }
                }
                else if(xacnhan == 'N')
                {
                    Console.WriteLine("Them sach khong thanh cong");
                }
            }
        }
    }
}
