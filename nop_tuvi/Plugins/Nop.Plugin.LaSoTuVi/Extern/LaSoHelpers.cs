using Nop.Plugin.LaSoTuVi.TuViSerives.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Plugin.LaSoTuVi.Extern
{
    public static class LaSoHelpers
    {
        public static int ViTri(this int dauvao, int dolechsovoicungti)
        {
            return (dauvao + dolechsovoicungti) % 12;
        }
        public static int ViTri10(this int dauvao, int dolechsovoicungti)
        {
            return (dauvao + dolechsovoicungti) % 10;
        }
        public static string MauSac_NguHanh_CSS(this SaoTuVi sao)
        {
            var nguhanh = sao.NguHanh.FirstOrDefault();
            return nguhanh.MauSac_NguHanh_CSS();
        }

        public static string MauSac_NguHanh_CSS(this NguHanh NguHanh)
        {
            switch (NguHanh)
            {
                case NguHanh.Kim: return "#a3a3a3";
                case NguHanh.Moc: return "#077d07";
                case NguHanh.Thuy: return "black";
                case NguHanh.Hoa: return "red";
                case NguHanh.Tho: return "#ff9b3e";
            }
            return "black";
        }

        public static string TenDoAnhHuong(this SaoTuVi sao)
        {

            if (TuViDataServices.DIC_DoAnhHuong.ContainsKey(sao.Sao))
            {
                return TuViDataServices.DIC_DoAnhHuong[sao.Sao][sao.CungToaThu].FullName();
            }
            return "";
        }


        public static string FullName(this DoAnhHuong doanhhuong)
        {
            switch (doanhhuong)
            {
                case DoAnhHuong.BinhHoa: return "(B)";
                case DoAnhHuong.DacDia: return "(Đ)";
                case DoAnhHuong.HamDia: return "(H)";
                case DoAnhHuong.MieuDia: return "(M)";
                case DoAnhHuong.VuongDia: return "(V)";
            }
            return "";
        }

        public static string FullName(this Cung cung, bool? gioitinh = null)
        {
            switch (cung)
            {
                case Cung.Menh: return "Mệnh";
                case Cung.HuynhDe: return "Huynh Đệ";
                case Cung.PhuThe: return gioitinh.HasValue ? gioitinh.Value ? "Thê" : "Phu" : "Phu Thê";
                case Cung.TuTuc: return "Tử Tức";
                case Cung.TaiBach: return "Tài Bạch";
                case Cung.TatAch: return "Tật Ách";
                case Cung.ThienDi: return "Thiên Di";
                case Cung.NoBoc: return "Nô Bộc";
                case Cung.QuanLoc: return "Quan Lộc";
                case Cung.DienTrach: return "Điền Trạch";
                case Cung.PhucDuc: return "Phúc Đức";
                case Cung.PhuMau: return "Phụ Mẫu";
                case Cung.Than: return "Thân";
            }
            return "--/--";
        }

        public static string FullName(this DiaChi cung)
        {
            switch (cung)
            {
                case DiaChi.Ti: return "Tý";
                case DiaChi.Suu: return "Sửu";
                case DiaChi.Dan: return "Dần";
                case DiaChi.Mao: return "Mão";
                case DiaChi.Thin: return "Thìn";
                case DiaChi.Ty: return "Tỵ";
                case DiaChi.Ngo: return "Ngọ";
                case DiaChi.Mui: return "Mùi";
                case DiaChi.Than: return "Thân";
                case DiaChi.Dau: return "Dậu";
                case DiaChi.Tuat: return "Tuất";
                case DiaChi.Hoi: return "Hợi";
            }
            return "--/--";
        }
        public static string FullName(this ThienCan can)
        {
            switch (can)
            {
                case ThienCan.Giap: return "Giáp";
                case ThienCan.At: return "Ất";
                case ThienCan.Binh: return "Bính";
                case ThienCan.Dinh: return "Đinh";
                case ThienCan.Mau: return "Mậu";
                case ThienCan.Ky: return "Kỷ";
                case ThienCan.Canh: return "Canh";
                case ThienCan.Tan: return "Tân";
                case ThienCan.Nham: return "Nhâm";
                case ThienCan.Quy: return "Quý";
            }
            return "--/--";
        }
        public static string FullName(this Cuc cuc)
        {
            switch (cuc)
            {
                case Cuc.ThuyNhiCuc: return "Thủy Nhị Cục";
                case Cuc.MocTamCuc: return "Mộc Tam Cục";
                case Cuc.KimTuCuc: return "Kim Tứ Cục";
                case Cuc.ThoNguCuc: return "Thổ Ngũ Cục";
                case Cuc.HoaLucCuc: return "Hỏa Lục Cục";

            }
            return "--/--";
        }

        public static AmDuong AmDuong(this ThienCan can)
        {
            return (AmDuong)(((int)can) % 2);
        }

        public static AmDuong AmDuong(this DiaChi chi)
        {
            return (AmDuong)(((int)chi) % 2);
        }

        public static ThienCan ThienCan_Nam(int Nam)
        {
            return (ThienCan)(((Nam % 10) + 6) % 10);
        }
        public static DiaChi DiaChi_Nam(int Nam)
        {
            return (DiaChi)(((Nam % 12) + 8) % 12);
        }

        public static ThienCan ThienCan_Nam(this NgayAm ngayam)
        {
            return (ThienCan)(((ngayam.Nam % 10) + 6) % 10);
        }
        public static DiaChi DiaChi_Nam(this NgayAm ngayam)
        {
            return (DiaChi)(((ngayam.Nam % 12) + 8) % 12);
        }

        public static ThienCan ThienCan_Thang(this NgayAm ngayam)
        {
            ThienCan CanNam = ngayam.ThienCan_Nam();
            if (CanNam == ThienCan.Giap || CanNam == ThienCan.Ky)
            {
                return (ThienCan)(ngayam.Thang - 1).ViTri10(2);
            }
            else if (CanNam == ThienCan.At || CanNam == ThienCan.Canh)
            {
                return (ThienCan)(ngayam.Thang - 1).ViTri10(4);
            }
            else if (CanNam == ThienCan.Binh || CanNam == ThienCan.Tan)
            {
                return (ThienCan)(ngayam.Thang - 1).ViTri10(6);
            }
            else if (CanNam == ThienCan.Dinh || CanNam == ThienCan.Nham)
            {
                return (ThienCan)(ngayam.Thang - 1).ViTri10(8);
            }
            else // if (CanNam == ThienCan.Mau || CanNam == ThienCan.Quy)
            {
                return (ThienCan)(ngayam.Thang - 1).ViTri10(0);
            }
        }
        public static DiaChi DiaChi_Thang(this NgayAm ngayam)
        {
            return (DiaChi)(ngayam.Thang - 1).ViTri(2);
        }

        public static ThienCan ThienCan_Ngay(this NgayAm ngayam)
        {
            DateTime duong = AmLichHelpers.AmLich2DuongLich(ngayam.Ngay, ngayam.Thang, ngayam.Nam, 7);
            int totaldate = (int)(duong - (new DateTime(1975, 1, 14))).TotalDays;
            return totaldate >= 0 ? (ThienCan)(((totaldate % 10) + 6) % 10) : (ThienCan)(10 - (((totaldate % 10) + 6) % 10));
        }
        public static DiaChi DiaChi_Ngay(this NgayAm ngayam)
        {
            DateTime duong = AmLichHelpers.AmLich2DuongLich(ngayam.Ngay, ngayam.Thang, ngayam.Nam, 7);
            int totaldate = (int)(duong - (new DateTime(1975, 1, 14))).TotalDays;
            return totaldate >= 0 ? (DiaChi)(((totaldate % 12) + 8) % 12) : (DiaChi)(12 - (((totaldate % 12) + 8) % 12));
        }

        public static ThienCan ThienCan_Gio(this NgayAm ngay)
        {
            ThienCan canngay = ngay.ThienCan_Ngay();
            return ngay.ThienCan_Gio(canngay);
        }

        public static ThienCan ThienCan_Gio(this NgayAm ngay, ThienCan canngay)
        {
            if (canngay == ThienCan.Giap || canngay == ThienCan.Ky)
            {
                return (ThienCan)(((int)ngay.Gio).ViTri10(0));
            }
            else if (canngay == ThienCan.At || canngay == ThienCan.Canh)
            {
                return (ThienCan)(((int)ngay.Gio).ViTri10(2));
            }
            else if (canngay == ThienCan.Binh || canngay == ThienCan.Tan)
            {
                return (ThienCan)(((int)ngay.Gio).ViTri10(4));
            }
            else if (canngay == ThienCan.Dinh || canngay == ThienCan.Nham)
            {
                return (ThienCan)(((int)ngay.Gio).ViTri10(6));
            }
            else // if (canngay == ThienCan.Mau || canngay == ThienCan.Quy)
            {
                return (ThienCan)(((int)ngay.Gio).ViTri10(8));
            }
        }

        public static ThienCan ConvertThangThienCanDiaChi(ThienCan canNam, int thang)
        {
            if (canNam == ThienCan.Giap || canNam == ThienCan.Ky)
            {
                return (ThienCan)((thang - 1).ViTri10(3));
            }
            else if (canNam == ThienCan.At || canNam == ThienCan.Canh)
            {
                return (ThienCan)((thang - 1).ViTri10(5));
            }
            else if (canNam == ThienCan.Binh || canNam == ThienCan.Tan)
            {
                return (ThienCan)((thang - 1).ViTri10(7));
            }
            else if (canNam == ThienCan.Dinh || canNam == ThienCan.Nham)
            {
                return (ThienCan)((thang - 1).ViTri10(9));
            }
            //else if (canNam == ThienCan.Mau || canNam == ThienCan.Quy)
            //{
            return (ThienCan)((thang - 1).ViTri10(1));
            //}
        }

        public static bool Check_CanChi(ThienCan can, DiaChi chi)
        {
            return (((int)can % 2 == 0 && (int)chi % 2 == 0) || ((int)can % 2 == 1 && (int)chi % 2 == 1));
        }

        public static int ConvertCanChi(ThienCan can, DiaChi chi)
        {
            if (!Check_CanChi(can, chi))
                return -1;
            var currentdate = new DateTime((DateTime.Now.Year / 10) + ((int)can).ViTri10(6), 5, 5);

            var _ThienCan = LaSoHelpers.ThienCan_Nam(new NgayAm(currentdate.Day, currentdate.Month, currentdate.Year, DiaChi.Ti));
            var _DiaChi = LaSoHelpers.DiaChi_Nam(new NgayAm(currentdate.Day, currentdate.Month, currentdate.Year, DiaChi.Ti));

            while (_ThienCan != can || _DiaChi != chi)
            {
                currentdate = currentdate.AddYears(-10);
            }
            return currentdate.Year;
        }

        public static string FullName(this AmDuongNamNu amduong)
        {
            if (amduong == AmDuongNamNu.DuongNam) { return "Dương Nam"; }
            else if (amduong == AmDuongNamNu.AmNu) { return "Âm Nữ"; }
            else if (amduong == AmDuongNamNu.AmNam) { return "Âm Nam"; }
            else { return "Dương Nữ"; }
        }

        public static BanMenh BanMenh(ThienCan can, DiaChi chi)
        {
            List<int> List = new List<int>() { 0, 11, 22, 33, 44, 55, 66, 77, 88, 99, 100, 111, 2, 13, 24, 35, 46, 57, 68, 79, 80, 91, 102, 113, 4, 15, 26, 37, 48, 59, 60, 71, 82, 93, 104, 115, 6, 17, 28, 39, 40, 51, 62, 73, 84, 95, 106, 117, 8, 19, 20, 31, 42, 53, 64, 75, 86, 97, 108, 119 };

            return (BanMenh)(List.FindIndex(_ => _ == (((int)chi) * 10) + ((int)can)) / 2);
        }

        public static NguHanh NguHanhMenh(ThienCan can, DiaChi chi)
        {
            List<NguHanh> nguhanh = new List<NguHanh>() { NguHanh.Kim, NguHanh.Thuy, NguHanh.Hoa, NguHanh.Tho, NguHanh.Moc };
            List<int> giatrithiencan = new List<int>() { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
            List<int> giatridiachi = new List<int>() { 0, 0, 1, 1, 2, 2, 0, 0, 1, 1, 2, 2 };

            return nguhanh[(giatrithiencan[(int)can] + giatridiachi[(int)chi]) % 5];
        }
        public static string FullName(this NguHanh nguhanh)
        {
            if (nguhanh == NguHanh.Kim) { return "Kim"; }
            else if (nguhanh == NguHanh.Moc) { return "Mộc"; }
            else if (nguhanh == NguHanh.Thuy) { return "Thủy"; }
            else if (nguhanh == NguHanh.Hoa) { return "Hỏa"; }
            else { return "Thổ"; }
        }

        public static string FullName(this BanMenh banmenh)
        {
            if (banmenh == TuViSerives.Data.BanMenh.HaiTrungKim) { return "Hải Trung Kim"; }
            else if (banmenh == TuViSerives.Data.BanMenh.LoTrungHoa) { return "Lô Trung Hỏa"; }
            else if (banmenh == TuViSerives.Data.BanMenh.DaiLamMoc) { return "Đại Lâm Mộc"; }
            else if (banmenh == TuViSerives.Data.BanMenh.LoBangTho) { return "Lộ Bàng Thổ"; }
            else if (banmenh == TuViSerives.Data.BanMenh.KiemPhongKim) { return "Kiếm Phong Kim"; }
            else if (banmenh == TuViSerives.Data.BanMenh.SonDauHoa) { return "Sơn Đầu Hỏa"; }
            else if (banmenh == TuViSerives.Data.BanMenh.GianHaThuy) { return "Giản Hạ Thủy"; }
            else if (banmenh == TuViSerives.Data.BanMenh.ThanhDauTho) { return "Thành Đầu Thổ"; }
            else if (banmenh == TuViSerives.Data.BanMenh.BachLapKim) { return "Bạch Lạp Kim"; }
            else if (banmenh == TuViSerives.Data.BanMenh.DuongLieuMoc) { return "Dương Liễu Mộc"; }
            else if (banmenh == TuViSerives.Data.BanMenh.TuyenTrungThuy) { return "Tuyền Trung Thủy"; }
            else if (banmenh == TuViSerives.Data.BanMenh.OcThuongTho) { return "Ốc Thượng Thổ"; }
            else if (banmenh == TuViSerives.Data.BanMenh.TichLichHoa) { return "Tích Lịch Hỏa"; }
            else if (banmenh == TuViSerives.Data.BanMenh.TungBachMoc) { return "Tùng Bách Mộc"; }
            else if (banmenh == TuViSerives.Data.BanMenh.TrangLuuThuy) { return "Tràng Lưu Thủy"; }
            else if (banmenh == TuViSerives.Data.BanMenh.SaTrungKim) { return "Sa Trung Kim"; }
            else if (banmenh == TuViSerives.Data.BanMenh.SonHaHoa) { return "Sơn Hạ Hỏa"; }
            else if (banmenh == TuViSerives.Data.BanMenh.BinhDiaMoc) { return "Bình Địa Mộc"; }
            else if (banmenh == TuViSerives.Data.BanMenh.BichThuongTho) { return "Bích Thượng Thổ"; }
            else if (banmenh == TuViSerives.Data.BanMenh.KimBachKim) { return "Kim Bạch Kim"; }
            else if (banmenh == TuViSerives.Data.BanMenh.PhuDangHoa) { return "Phú Đăng Hỏa"; }
            else if (banmenh == TuViSerives.Data.BanMenh.ThienThuongThuy) { return "Thiên Thượng Thủy"; }
            else if (banmenh == TuViSerives.Data.BanMenh.DaiTrachTho) { return "Đại Trạch Thổ"; }
            else if (banmenh == TuViSerives.Data.BanMenh.XuyenThoaKim) { return "Xuyến Thoa Kim"; }
            else if (banmenh == TuViSerives.Data.BanMenh.TangKhoMoc) { return "Tang Khô Mộc"; }
            else if (banmenh == TuViSerives.Data.BanMenh.DaiKheThuy) { return "Đại Khuê Thủy"; }
            else if (banmenh == TuViSerives.Data.BanMenh.SaTrungTho) { return "Sa Trung Thổ"; }
            else if (banmenh == TuViSerives.Data.BanMenh.ThienThuongToa) { return "Thiên Thượng Hỏa"; }
            else if (banmenh == TuViSerives.Data.BanMenh.ThachLuuMoc) { return "Thạch Lựu Mộc"; }
            else //if (banmenh == DBServices.DataServices.BanMenh.DaiHaiThuy      )
            { return "Đại Hải Thủy"; }
        }

        public static string FullName(this TrangSinh trangsinh)
        {
            if (trangsinh == TrangSinh.TruongSinh) { return "Trường Sinh"; }
            else if (trangsinh == TrangSinh.Duong) { return "Dưỡng"; }
            else if (trangsinh == TrangSinh.Thai) { return "Thai"; }
            else if (trangsinh == TrangSinh.Tuyet) { return "Tuyệt"; }
            else if (trangsinh == TrangSinh.Mo) { return "Mộ"; }
            else if (trangsinh == TrangSinh.Tu) { return "Tử"; }
            else if (trangsinh == TrangSinh.Benh) { return "Bệnh"; }
            else if (trangsinh == TrangSinh.Suy) { return "Suy"; }
            else if (trangsinh == TrangSinh.DeVuong) { return "Đế Vượng"; }
            else if (trangsinh == TrangSinh.LamQuan) { return "Lâm Quan"; }
            else if (trangsinh == TrangSinh.QuanDoi) { return "Quan Đới"; }
            else// if (trangsinh == TrangSinh.MocDuc                   )
            { return "Mộc Dục"; }

        }

        public static string ThanCu(this LaSo laso)
        {
            var cungAnThan = laso.CungLaSo.FirstOrDefault(_ => _.Cung.Any(m => m == Cung.Than));
            if (cungAnThan.Cung.Any(_ => _ == Cung.Menh))
                return "Thân Mệnh Đồng Cung";
            return $"Thân cư {cungAnThan.Cung.FirstOrDefault().FullName()}";
        }

        public static ThuanNghichLy XetThuanNghich(this LaSo laso)
        {
            var cungmenh = laso.CungLaSo.FirstOrDefault(_ => _.Cung.Any(m => m == Cung.Menh));
            if ((cungmenh.AmDuong == TuViSerives.Data.AmDuong.Am && (laso.AmDuongNamNu == AmDuongNamNu.AmNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu)) ||
                (cungmenh.AmDuong == TuViSerives.Data.AmDuong.Duong && (laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.DuongNam)))
                return ThuanNghichLy.AmDuongThuanLy;
            return ThuanNghichLy.AmDuongNghichLy;
        }
        public static string FullName(this ThuanNghichLy thuan)
        {
            if (thuan == ThuanNghichLy.AmDuongNghichLy) { return "Âm Dương nghịch lý"; }
            else { return "Âm Dương thuận lý"; }
        }

        public static CucMenh XetCucMenh(this LaSo laso)
        {
            List<NguHanh> menh = new List<NguHanh>() {
                NguHanh.Kim, NguHanh.Moc, NguHanh.Thuy, NguHanh.Hoa, NguHanh.Tho,
                NguHanh.Kim, NguHanh.Moc, NguHanh.Thuy, NguHanh.Hoa, NguHanh.Tho,
                NguHanh.Kim, NguHanh.Moc, NguHanh.Thuy, NguHanh.Hoa, NguHanh.Tho,
                NguHanh.Kim, NguHanh.Moc, NguHanh.Thuy, NguHanh.Hoa, NguHanh.Tho,
                NguHanh.Kim, NguHanh.Moc, NguHanh.Thuy, NguHanh.Hoa, NguHanh.Tho};
            List<Cuc> cuc = new List<Cuc>() {
                Cuc.ThuyNhiCuc, // menh sinh cuc
                Cuc.HoaLucCuc,
                Cuc.MocTamCuc,
                Cuc.ThoNguCuc,
                Cuc.KimTuCuc,

                Cuc.MocTamCuc, //menh khac cuc
                Cuc.ThoNguCuc,
                Cuc.HoaLucCuc,
                Cuc.KimTuCuc,
                Cuc.ThuyNhiCuc,

                Cuc.KimTuCuc, //menh cuc binh hoa
                Cuc.MocTamCuc,
                Cuc.ThuyNhiCuc,
                Cuc.HoaLucCuc,
                Cuc.ThoNguCuc,

                Cuc.ThoNguCuc, //cuc sinh menh
                Cuc.ThuyNhiCuc,
                Cuc.KimTuCuc,
                Cuc.MocTamCuc,
                Cuc.HoaLucCuc,

                Cuc.HoaLucCuc, // cuc khac menh
                Cuc.KimTuCuc,
                Cuc.ThoNguCuc,
                Cuc.ThuyNhiCuc,
                Cuc.MocTamCuc};
            int i = 0;
            for (; i < 25; i++)
            {
                if (laso.NguHanhMenh == menh[i] && laso.Cuc == cuc[i])
                    break;
            }
            if (i < 5) { return CucMenh.MenhSinhCuc; }
            else if (i < 10) { return CucMenh.MenhKhacCuc; }
            else if (i < 15) { return CucMenh.MenhCucBinhHoa; }
            else if (i < 20) { return CucMenh.CucSinhMenh; }
            else { return CucMenh.CucKhacMenh; }
        }
        public static string FullName(this CucMenh cucmenh)
        {
            var listTrangsinh = new List<string>() { "Cục Sinh Mệnh", "Mệnh sinh Cục", "Mệnh cục Bình Hòa", "Mệnh khắc Cục", "Cục khắc Mệnh" };
            return listTrangsinh[(int)cucmenh];
        }

        public static string FullName(this Sao sao)
        {
            if (TuViDataServices.DIC_SAO.ContainsKey(sao))
            {
                return TuViDataServices.DIC_SAO[sao].Ten;
            }
            return sao.ToString();
        }
        public static bool IsInDam(this Sao sao)
        {
            if (TuViDataServices.DIC_SaoInDam.ContainsKey(sao))
                return true;
            return false;
        }

        public static string classCSSAll(this SaoTuVi sao)
        {
            if (sao == null)
                return "";
            string rs = "";
            rs += sao.AmDuong + " ";
            rs += sao.CungToaThu + " ";

            rs += sao.DoAnhHuong != null ? sao.DoAnhHuong + " " : "";
            if (sao.LoaiDacTinh != null)
                foreach (var item in sao.LoaiDacTinh)
                {
                    rs += item + " ";
                }
            if (sao.LoaiSao != null)
                foreach (var item in sao.LoaiSao)
                {
                    rs += item + " ";
                }
            rs += sao.LoaiViTri + " ";
            if (sao.NguHanh != null)
                foreach (var item in sao.NguHanh)
                {
                    rs += item + " ";
                }
            rs += sao.PhuongVi + " ";
            rs += sao.Sao + " ";
            return rs;
        }

        public static string FullName(this NguyetHan nguyet)
        {
            var NguyetHan = new List<string>() { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            return NguyetHan[(int)nguyet];
        }
        public static string FullName(this LoaiDacTinh loaidactinh)
        {
            var loai = new List<string>() {"Qúy Tinh", "Đế Tinh", "Thiện Tinh", "Tài Tinh", "Quyền Tinh", "Phúc Tinh", "Đào Hoa Tinh", "Tù Tinh", "Phù Tinh", "Hung Tinh", "Dâm Tinh", "Ám Tinh", "Ấn Tinh", "Tho Tinh", "Dũng Tinh", "Hao Tinh",
            "Sát Tinh", "Hình Tinh", "Bại Tinh", "Văn Tinh", "Ác Tinh", "Cát Tinh", "Ẩm Thực", "Hộ Tinh", "Tùy Tinh"};
            return loai[(int)loaidactinh];
        }

        public static string FullName(this List<LoaiDacTinh> loaidactinh)
        {
            return string.Join(", ", loaidactinh.Select(_ => _.FullName()).ToList());
        }
    }
}
