using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.LaSoTuVi.Extern;
using Nop.Plugin.LaSoTuVi.Extern.Json;
using Nop.Plugin.LaSoTuVi.Models;
using Nop.Plugin.LaSoTuVi.Models.LaSoTuVi;
using Nop.Plugin.LaSoTuVi.TuViSerives.Data;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Web.Controllers;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Security;

namespace Nop.Plugin.LaSoTuVi.Controllers
{
    public partial class TVHomeController : BasePublicController
    {


        private string _controllerViews = "~/Plugins/LaSoTuVi/Views/TVHome/{0}.cshtml";
        public virtual IActionResult Test()
        {
            return PartialView("~/Themes/DefaultClean/Views/Home/Test.cshtml");
        }

        List<DiaChi> ListDiaChi = new List<DiaChi>() { DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi };
        List<NguHanh> ListNguHanh = new List<NguHanh>() { NguHanh.Thuy, NguHanh.Tho, NguHanh.Moc, NguHanh.Moc, NguHanh.Tho, NguHanh.Hoa, NguHanh.Hoa, NguHanh.Tho, NguHanh.Kim, NguHanh.Kim, NguHanh.Tho, NguHanh.Thuy };

        int timeZone = 7;

    
        public LaSo Init_LaSo(LaSo laso, CreateLaSoDuongLichModel model)
        {
            DateTime duonglich = new DateTime(model.Nam, model.Thang, model.Ngay, model.Gio, model.Phut, 1);
            NgayAm ngayAm = AmLichHelpers.DuongLich2AmLich(duonglich, timeZone);

            laso.NgaySinh_DuongLich = duonglich;
            laso.CungLaSo = new List<CungLaSo>();
            laso.Ten = model.Ten;

            laso.ThienCan_NamSinh = ngayAm.ThienCan_Nam();
            laso.DiaChi_NamSinh = ngayAm.DiaChi_Nam();

            laso.ThienCan_ThangSinh = ngayAm.ThienCan_Thang();
            laso.DiaChi_ThangSinh = ngayAm.DiaChi_Thang();

            laso.ThienCan_NgaySinh = ngayAm.ThienCan_Ngay();
            laso.DiaChi_NgaySinh = ngayAm.DiaChi_Ngay();

            laso.ThienCan_GioSinh = ngayAm.ThienCan_Gio();
            laso.DiaChi_GioSinh = ngayAm.Gio;

            laso.GioiTinh = model.GioiTinh ? GioiTinh.Nam : GioiTinh.Nu;
            laso.AmDuongNamNu = laso.GioiTinh == GioiTinh.Nam && laso.ThienCan_NamSinh.AmDuong() == AmDuong.Duong ? AmDuongNamNu.DuongNam : laso.GioiTinh == GioiTinh.Nu && laso.ThienCan_NamSinh.AmDuong() == AmDuong.Am ? AmDuongNamNu.AmNu : laso.GioiTinh == GioiTinh.Nam && laso.ThienCan_NamSinh.AmDuong() == AmDuong.Am ? AmDuongNamNu.AmNam : AmDuongNamNu.DuongNu;

            laso.ThangSinh_AmLich = ngayAm.Thang;
            laso.NgaySinh_AmLich = ngayAm.Ngay;

            laso.ThienCan_NamXem = LaSoHelpers.ThienCan_Nam(model.NamXemHan);
            laso.DiaChi_NamXem = LaSoHelpers.DiaChi_Nam(model.NamXemHan);

            laso.GioSinh = model.Gio;
            laso.Phut = model.Phut;

            laso.Tuoi = model.NamXemHan - ngayAm.Nam + 1;
            laso.NamXemHan = model.NamXemHan;

            laso.BanMenh = LaSoHelpers.BanMenh(laso.ThienCan_NamSinh, laso.DiaChi_NamSinh);
            laso.NguHanhMenh = LaSoHelpers.NguHanhMenh(laso.ThienCan_NamSinh, laso.DiaChi_NamSinh);

            for (int i = 0; i < 12; i++)
            {
                var temp = new CungLaSo()
                {
                    AmDuong = (AmDuong)(i % 2), //khởi tạo âm dương từng cung
                    DiaChi = ListDiaChi[i], // địa chi của từng cung
                    SaoTuVi = new List<SaoTuVi>(),// khởi tạo danh sách các sao
                    NguHanh = ListNguHanh[i],// khởi tạo ngũ hành của từng cung
                    Cung = new List<Cung>(),
                };
                laso.CungLaSo.Add(temp);
            }

            List<ThienCan> ListThienCan = new List<ThienCan>() { ThienCan.Binh, ThienCan.Mau, ThienCan.Canh, ThienCan.Nham, ThienCan.Giap, ThienCan.Binh, ThienCan.Mau, ThienCan.Canh, ThienCan.Nham, ThienCan.Giap };
            for (int i = 0; i < 12; i++)
            {
                laso.CungLaSo[i.ViTri(2)].ThienCan = (ThienCan)(((int)ListThienCan[(int)laso.ThienCan_NamSinh] + i) % 10);
            }
            return laso;
        }

        /// <summary>
        /// cách an mệnh:
        /// b1: tính từ cung Dần coi như tháng giêng đến xuôi từng cung đến tháng sinh
        /// b2: từ cung tháng sinh đêm ngược về từng cung đến giờ sinh
        /// b1: tính từ cung Dần coi như tháng giêng đến xuôi từng cung đến tháng sinh
        /// b2: từ cung tháng sinh đêm xuôi về từng cung đến giờ sinh
        /// -> an Thân tại cung dừng lại
        /// </summary>
        /// <param name="laso"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public LaSo Init_AnMenhThan(LaSo laso)
        {
            int demxuoi = (((int)laso.ThangSinh_AmLich - 1) + 2) % 12;
            int demnguoc = (demxuoi + (12 - (int)laso.DiaChi_GioSinh)) % 12;// mệnh thì đếm ngược
            int demxuoithan = (demxuoi + ((int)laso.DiaChi_GioSinh)) % 12;// than thì đếm xuôi
            for (int i = 0; i < 12; i++)// cung lá sô đếm từ tý nhưng an sao tính từ tháng một là dần, nên phải +2 nữa tức là độ lệch bằng 2
            {
                laso.CungLaSo[(i + demnguoc).ViTri(0)].Cung.Add((Cung)i);
            }

            laso.CungLaSo[demxuoithan].Cung.Add(Cung.Than);
            return laso;
        }
        public LaSo Init_XacDinhCuc(LaSo laso)
        {
            #region an theo sách cũ
            //var IndexMenh = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.Cung.FirstOrDefault() == Cung.Menh));

            //ThienCan CanKhoi = laso.ThienCan_NamSinh;// tìm can khởi
            //#region Tìm can khởi
            //switch (laso.ThienCan_NamSinh)
            //{
            //    case ThienCan.Giap:
            //    case ThienCan.Ky:
            //        CanKhoi = ThienCan.Binh;
            //        break;

            //    case ThienCan.At:
            //    case ThienCan.Canh:
            //        CanKhoi = ThienCan.Mau;
            //        break;

            //    case ThienCan.Binh:
            //    case ThienCan.Tan:
            //        CanKhoi = ThienCan.Canh;
            //        break;

            //    case ThienCan.Dinh:
            //    case ThienCan.Nham:
            //        CanKhoi = ThienCan.Nham;
            //        break;

            //    case ThienCan.Mau:
            //    case ThienCan.Quy:
            //        CanKhoi = ThienCan.Giap;
            //        break;
            //}
            //#endregion

            //var IndexSearch = ((10 - 1) - (int)CanKhoi) + 2;
            //if (IndexSearch < IndexMenh)// nhỏ hơn thì đếm tiếp 1 vòng thiên can, tức là + 10, 
            //{
            //    IndexSearch = (IndexSearch + 10) - 12;
            //}

            //IndexSearch = IndexSearch + 3; // từ cung dừng đếm 1,2,3,4
            //List<Cuc> ListCuc = new List<Cuc>();
            //if (laso.CungLaSo[IndexSearch].DiaChi == DiaChi.Ti || laso.CungLaSo[IndexSearch].DiaChi == DiaChi.Ngo)
            //{
            //    //Ngân (Kim) Đăng (Hỏa) Giá (Mộc) Bích (Thổ) Câu (Kim)
            //    ListCuc = new List<Cuc>() { Cuc.KimTuCuc, Cuc.KimTuCuc, Cuc.HoaLucCuc, Cuc.HoaLucCuc, Cuc.MocTamCuc, Cuc.MocTamCuc, Cuc.ThoNguCuc, Cuc.ThoNguCuc, Cuc.KimTuCuc, Cuc.KimTuCuc };

            //}
            //else if (laso.CungLaSo[IndexSearch].DiaChi == DiaChi.Thin || laso.CungLaSo[IndexSearch].DiaChi == DiaChi.Tuat)
            //{
            //    //Yên (Hỏa) Mãn (Thủy) Tự (Mộc) Chung (Kim) Lâu (Mộc)
            //    ListCuc = new List<Cuc>() { Cuc.HoaLucCuc, Cuc.HoaLucCuc, Cuc.ThuyNhiCuc, Cuc.ThuyNhiCuc, Cuc.MocTamCuc, Cuc.MocTamCuc, Cuc.KimTuCuc, Cuc.KimTuCuc, Cuc.MocTamCuc, Cuc.MocTamCuc };

            //}
            //else if (laso.CungLaSo[IndexSearch].DiaChi == DiaChi.Dan || laso.CungLaSo[IndexSearch].DiaChi == DiaChi.Than)
            //{
            //    //Hán (Thuỷ) Địa (Thổ) Thiêu (Hỏa) Sài (Mộc) Thấp (Thủy)
            //    ListCuc = new List<Cuc>() { Cuc.ThuyNhiCuc, Cuc.ThuyNhiCuc, Cuc.ThoNguCuc, Cuc.ThoNguCuc, Cuc.HoaLucCuc, Cuc.HoaLucCuc, Cuc.MocTamCuc, Cuc.MocTamCuc, Cuc.ThuyNhiCuc, Cuc.ThuyNhiCuc };

            //}
            //laso.Cuc = ListCuc[IndexMenh >= IndexSearch ? IndexMenh - IndexSearch : ((IndexMenh + 12) - IndexSearch)];
            #endregion

            var cunganmenh = laso.CungLaSo.FirstOrDefault(_ => _.Cung.Any(m => m == Cung.Menh));

            if (cunganmenh.DiaChi == DiaChi.Ti || cunganmenh.DiaChi == DiaChi.Suu)
            {
                List<Cuc> rs = new List<Cuc>() { Cuc.ThuyNhiCuc, Cuc.HoaLucCuc, Cuc.ThoNguCuc, Cuc.MocTamCuc, Cuc.KimTuCuc };
                laso.Cuc = rs[((int)laso.ThienCan_NamSinh) % 5];
            }
            else if (cunganmenh.DiaChi == DiaChi.Dan || cunganmenh.DiaChi == DiaChi.Mao || cunganmenh.DiaChi == DiaChi.Tuat || cunganmenh.DiaChi == DiaChi.Hoi)
            {
                List<Cuc> rs = new List<Cuc>() { Cuc.HoaLucCuc, Cuc.ThoNguCuc, Cuc.MocTamCuc, Cuc.KimTuCuc, Cuc.ThuyNhiCuc };
                laso.Cuc = rs[((int)laso.ThienCan_NamSinh) % 5];
            }
            else if (cunganmenh.DiaChi == DiaChi.Thin || cunganmenh.DiaChi == DiaChi.Ty)
            {
                List<Cuc> rs = new List<Cuc>() { Cuc.MocTamCuc, Cuc.KimTuCuc, Cuc.ThuyNhiCuc, Cuc.HoaLucCuc, Cuc.ThoNguCuc };
                laso.Cuc = rs[((int)laso.ThienCan_NamSinh) % 5];
            }
            else if (cunganmenh.DiaChi == DiaChi.Ngo || cunganmenh.DiaChi == DiaChi.Mui)
            {
                List<Cuc> rs = new List<Cuc>() { Cuc.ThoNguCuc, Cuc.MocTamCuc, Cuc.KimTuCuc, Cuc.ThuyNhiCuc, Cuc.HoaLucCuc };
                laso.Cuc = rs[((int)laso.ThienCan_NamSinh) % 5];
            }
            else// if (cunganmenh.DiaChi == DiaChi.Than || cunganmenh.DiaChi == DiaChi.Dau)
            {
                List<Cuc> rs = new List<Cuc>() { Cuc.KimTuCuc, Cuc.ThuyNhiCuc, Cuc.HoaLucCuc, Cuc.ThoNguCuc, Cuc.MocTamCuc };
                laso.Cuc = rs[((int)laso.ThienCan_NamSinh) % 5];
            }
            return laso;
        }
        public LaSo Init_XacDinhDaiVan(LaSo laso)
        {
            int start = 2;
            if (laso.Cuc == Cuc.ThuyNhiCuc)
                start = 2;
            else if (laso.Cuc == Cuc.MocTamCuc)
                start = 3;
            else if (laso.Cuc == Cuc.KimTuCuc)
                start = 4;
            else if (laso.Cuc == Cuc.ThoNguCuc)
                start = 5;
            else if (laso.Cuc == Cuc.HoaLucCuc)
                start = 6;

            var IndexMenh = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.Cung.FirstOrDefault() == Cung.Menh));

            for (int i = 0; i < 12; i++)
            {
                laso.CungLaSo[(IndexMenh + (laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu ? i : (12 - i))).ViTri(0)].DaiVanNam = start + (10 * i);
            }
            return laso;
        }
        public LaSo Init_XacDinhTieuVan(LaSo laso)
        {
            if (laso.DiaChi_NamSinh == DiaChi.Dan || laso.DiaChi_NamSinh == DiaChi.Ngo || laso.DiaChi_NamSinh == DiaChi.Tuat)
            {
                for (int i = 0; i < 12; i++)
                {
                    //4 là index của cung thìn
                    laso.CungLaSo[((laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu ? i : (12 - i)) + 4).ViTri(0)].TieuHanNam = (DiaChi)((i + (int)laso.DiaChi_NamSinh).ViTri(0));
                }
            }
            else if (laso.DiaChi_NamSinh == DiaChi.Ty || laso.DiaChi_NamSinh == DiaChi.Dau || laso.DiaChi_NamSinh == DiaChi.Suu)
            {
                for (int i = 0; i < 12; i++)
                {
                    //7 là index của cung mùi
                    laso.CungLaSo[((laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu ? i : (12 - i)) + 7).ViTri(0)].TieuHanNam = (DiaChi)((i + (int)laso.DiaChi_NamSinh).ViTri(0));
                }
            }
            else if (laso.DiaChi_NamSinh == DiaChi.Than || laso.DiaChi_NamSinh == DiaChi.Ty || laso.DiaChi_NamSinh == DiaChi.Thin)
            {
                for (int i = 0; i < 12; i++)
                {
                    //10 là index của cung tuất
                    laso.CungLaSo[((laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu ? i : (12 - i)) + 10).ViTri(0)].TieuHanNam = (DiaChi)((i + (int)laso.DiaChi_NamSinh).ViTri(0));
                }
            }
            else if (laso.DiaChi_NamSinh == DiaChi.Hoi || laso.DiaChi_NamSinh == DiaChi.Mao || laso.DiaChi_NamSinh == DiaChi.Mui)
            {
                for (int i = 0; i < 12; i++)
                {
                    //1 là index của cung sửu
                    laso.CungLaSo[((laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu ? i : (12 - i)) + 1).ViTri(0)].TieuHanNam = (DiaChi)((i + (int)laso.DiaChi_NamSinh).ViTri(0));
                }
            }
            return laso;
        }
        public LaSo Init_AnSaoChinhTinh(LaSo laso)
        {
            var List_ThuyNhiCuc = new List<DiaChi>() { DiaChi.Suu, DiaChi.Dan, DiaChi.Dan, DiaChi.Mao, DiaChi.Mao, DiaChi.Thin, DiaChi.Thin, DiaChi.Ty, DiaChi.Ty, DiaChi.Ngo, DiaChi.Ngo, DiaChi.Mui, DiaChi.Mui, DiaChi.Than, DiaChi.Than, DiaChi.Dau, DiaChi.Dau, DiaChi.Tuat, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Hoi, DiaChi.Ty, DiaChi.Ty, DiaChi.Suu, DiaChi.Suu, DiaChi.Dan, DiaChi.Dan, DiaChi.Mao, DiaChi.Mao, DiaChi.Thin };
            var List_MocTamCuc = new List<DiaChi>() { DiaChi.Thin, DiaChi.Suu, DiaChi.Dan, DiaChi.Ty, DiaChi.Dan, DiaChi.Mao, DiaChi.Ngo, DiaChi.Mao, DiaChi.Thin, DiaChi.Mui, DiaChi.Thin, DiaChi.Ty, DiaChi.Than, DiaChi.Ty, DiaChi.Ngo, DiaChi.Dau, DiaChi.Ngo, DiaChi.Mui, DiaChi.Tuat, DiaChi.Mui, DiaChi.Than, DiaChi.Hoi, DiaChi.Than, DiaChi.Dau, DiaChi.Ti, DiaChi.Dau, DiaChi.Tuat, DiaChi.Suu, DiaChi.Tuat, DiaChi.Hoi };
            var List_KimTuCuc = new List<DiaChi>() { DiaChi.Hoi, DiaChi.Thin, DiaChi.Suu, DiaChi.Dan, DiaChi.Ti, DiaChi.Ty, DiaChi.Dan, DiaChi.Mao, DiaChi.Suu, DiaChi.Ngo, DiaChi.Mao, DiaChi.Thin, DiaChi.Dan, DiaChi.Mui, DiaChi.Thin, DiaChi.Ty, DiaChi.Mao, DiaChi.Than, DiaChi.Ty, DiaChi.Ngo, DiaChi.Thin, DiaChi.Dau, DiaChi.Ngo, DiaChi.Mui, DiaChi.Ty, DiaChi.Tuat, DiaChi.Mui, DiaChi.Than, DiaChi.Ngo, DiaChi.Hoi };
            var List_ThoNguCuc = new List<DiaChi>() { DiaChi.Ngo, DiaChi.Hoi, DiaChi.Thin, DiaChi.Suu, DiaChi.Dan, DiaChi.Mui, DiaChi.Ti, DiaChi.Ty, DiaChi.Dan, DiaChi.Mao, DiaChi.Than, DiaChi.Suu, DiaChi.Ngo, DiaChi.Mao, DiaChi.Thin, DiaChi.Dau, DiaChi.Dan, DiaChi.Mui, DiaChi.Thin, DiaChi.Ty, DiaChi.Tuat, DiaChi.Mao, DiaChi.Than, DiaChi.Ty, DiaChi.Ngo, DiaChi.Hoi, DiaChi.Thin, DiaChi.Dau, DiaChi.Ngo, DiaChi.Mui };
            var List_HoaLucCuc = new List<DiaChi>() { DiaChi.Dau, DiaChi.Ngo, DiaChi.Hoi, DiaChi.Thin, DiaChi.Suu, DiaChi.Dan, DiaChi.Tuat, DiaChi.Mui, DiaChi.Ti, DiaChi.Ty, DiaChi.Dan, DiaChi.Mao, DiaChi.Hoi, DiaChi.Than, DiaChi.Suu, DiaChi.Ngo, DiaChi.Mao, DiaChi.Thin, DiaChi.Ti, DiaChi.Dau, DiaChi.Dan, DiaChi.Mui, DiaChi.Thin, DiaChi.Ty, DiaChi.Suu, DiaChi.Tuat, DiaChi.Mao, DiaChi.Than, DiaChi.Ty, DiaChi.Ngo };
            var cung_tuvi = new CungLaSo();
            if (laso.Cuc == Cuc.ThuyNhiCuc)
            {
                laso.CungLaSo[(int)List_ThuyNhiCuc[laso.NgaySinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.TuVi]);
                cung_tuvi = laso.CungLaSo[(int)List_ThuyNhiCuc[laso.NgaySinh_AmLich - 1]];
            }
            else if (laso.Cuc == Cuc.MocTamCuc)
            {
                laso.CungLaSo[(int)List_MocTamCuc[laso.NgaySinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.TuVi]);
                cung_tuvi = laso.CungLaSo[(int)List_MocTamCuc[laso.NgaySinh_AmLich - 1]];
            }
            else if (laso.Cuc == Cuc.KimTuCuc)
            {
                laso.CungLaSo[(int)List_KimTuCuc[laso.NgaySinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.TuVi]);
                cung_tuvi = laso.CungLaSo[(int)List_KimTuCuc[laso.NgaySinh_AmLich - 1]];
            }
            else if (laso.Cuc == Cuc.ThoNguCuc)
            {
                laso.CungLaSo[(int)List_ThoNguCuc[laso.NgaySinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.TuVi]);
                cung_tuvi = laso.CungLaSo[(int)List_ThoNguCuc[laso.NgaySinh_AmLich - 1]];
            }
            else if (laso.Cuc == Cuc.HoaLucCuc)
            {
                laso.CungLaSo[(int)List_HoaLucCuc[laso.NgaySinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.TuVi]);
                cung_tuvi = laso.CungLaSo[(int)List_HoaLucCuc[laso.NgaySinh_AmLich - 1]];
            }

            var List_ChinhTinh = new List<Sao>() { Sao.TuVi, Sao.LiemTrinh, Sao.ThienDong, Sao.VuKhuc, Sao.ThaiDuong, Sao.ThienCo, Sao.ThienPhu, Sao.ThaiAm, Sao.ThamLang, Sao.CuMon, Sao.ThienTuong, Sao.ThienLuong, Sao.ThatSat, Sao.PhaQuan };
            var List = new List<DiaChi>();
            if (cung_tuvi.DiaChi == DiaChi.Ti) { List = new List<DiaChi>() { DiaChi.Ti, DiaChi.Thin, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Hoi, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Dan }; }
            else if (cung_tuvi.DiaChi == DiaChi.Suu) { List = new List<DiaChi>() { DiaChi.Suu, DiaChi.Ty, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Ti, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Suu }; }
            else if (cung_tuvi.DiaChi == DiaChi.Dan) { List = new List<DiaChi>() { DiaChi.Dan, DiaChi.Ngo, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Ti }; }
            else if (cung_tuvi.DiaChi == DiaChi.Mao) { List = new List<DiaChi>() { DiaChi.Mao, DiaChi.Mui, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Dan, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Hoi }; }
            else if (cung_tuvi.DiaChi == DiaChi.Thin) { List = new List<DiaChi>() { DiaChi.Thin, DiaChi.Than, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Mao, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Tuat }; }
            else if (cung_tuvi.DiaChi == DiaChi.Ty) { List = new List<DiaChi>() { DiaChi.Ty, DiaChi.Dau, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Thin, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Dau }; }
            else if (cung_tuvi.DiaChi == DiaChi.Ngo) { List = new List<DiaChi>() { DiaChi.Ngo, DiaChi.Tuat, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Ty, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Than }; }
            else if (cung_tuvi.DiaChi == DiaChi.Mui) { List = new List<DiaChi>() { DiaChi.Mui, DiaChi.Hoi, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ngo, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Mui }; }
            else if (cung_tuvi.DiaChi == DiaChi.Than) { List = new List<DiaChi>() { DiaChi.Than, DiaChi.Ti, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Ngo }; }
            else if (cung_tuvi.DiaChi == DiaChi.Dau) { List = new List<DiaChi>() { DiaChi.Dau, DiaChi.Suu, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Than, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Ty }; }
            else if (cung_tuvi.DiaChi == DiaChi.Tuat) { List = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Dan, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Dau, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Thin }; }
            else if (cung_tuvi.DiaChi == DiaChi.Hoi) { List = new List<DiaChi>() { DiaChi.Hoi, DiaChi.Mao, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Tuat, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Mao }; }

            for (int i = 1; i < 14; i++)
            {
                laso.CungLaSo[(int)List[i]].SaoTuVi.Add(TuViDataServices.DIC_SAO[List_ChinhTinh[i]]);
            }
            return laso;
        }
        public LaSo Init_AnTrangSinh(LaSo laso)
        {
            int index = 0;

            if (laso.Cuc == Cuc.HoaLucCuc) { index = (int)DiaChi.Dan; }
            else if (laso.Cuc == Cuc.KimTuCuc) { index = (int)DiaChi.Ty; }
            else if (laso.Cuc == Cuc.MocTamCuc) { index = (int)DiaChi.Hoi; }
            else if (laso.Cuc == Cuc.ThoNguCuc || laso.Cuc == Cuc.ThuyNhiCuc) { index = (int)DiaChi.Than; }


            for (int i = 0; i < 12; i++)
            {
                laso.CungLaSo[(index + (12 + ((laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu) ? (-i) : (i)))).ViTri(0)].TrangSinh = (TrangSinh)i;
            }


            return laso;
        }
        public LaSo Init_XacDinhDoAnhHuong(LaSo laso)
        {
            foreach (var item in laso.CungLaSo)
            {
                foreach (var sao in item.SaoTuVi)
                {
                    sao.CungToaThu = item.DiaChi;
                    if (TuViDataServices.DIC_DoAnhHuong.ContainsKey(sao.Sao))
                        sao.DoAnhHuong = TuViDataServices.DIC_DoAnhHuong[sao.Sao][item.DiaChi];
                }
            }
            return laso;
        }
        public LaSo Init_AnVongThaiTue(LaSo laso)
        {
            List<Sao> ThaiTue = new List<Sao>() { Sao.ThaiTue, Sao.ThieuDuong, Sao.TangMon, Sao.ThieuAm, Sao.QuanPhu, Sao.TuPhu, Sao.TuePha, Sao.LongDuc, Sao.BachHo, Sao.PhucDuc, Sao.DieuKhach, Sao.TrucPhu };
            var cungIndex = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.DiaChi == laso.DiaChi_NamSinh));

            for (int i = 0; i < 12; i++)
            {
                laso.CungLaSo[i.ViTri(cungIndex)].SaoTuVi.Add(TuViDataServices.DIC_SAO[ThaiTue[i]]);
            }

            return laso;
        }
        public LaSo Init_AnVongLocTon(LaSo laso)
        {
            List<DiaChi> ViTriCungLocTon = new List<DiaChi>() { DiaChi.Dan, DiaChi.Mao, DiaChi.Ty, DiaChi.Ngo, DiaChi.Ty, DiaChi.Ngo, DiaChi.Than, DiaChi.Dau, DiaChi.Hoi, DiaChi.Ti };
            //laso.CungLaSo[(int)ViTriCungLocTon[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LocTon]);
            //laso.CungLaSo[(int)ViTriCungLocTon[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.BacSy]);
            List<Sao> VongLocTon = new List<Sao>() { Sao.LocTon, Sao.LucSi, Sao.ThanhLong, Sao.TieuHao, Sao.TuongQuan, Sao.TauThu, Sao.PhiLiem, Sao.HiThan, Sao.BenhPhu, Sao.DaiHao, Sao.PhucBinh, Sao.QuanPhuR, Sao.BacSi };
            int vitriLocTon = (int)ViTriCungLocTon[(int)laso.ThienCan_NamSinh];
            for (int i = 0; i < VongLocTon.Count; i++)
            {
                laso.CungLaSo[((int)ViTriCungLocTon[(int)laso.ThienCan_NamSinh]).ViTri(laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu ? i : (12 - i))].SaoTuVi.Add(TuViDataServices.DIC_SAO[VongLocTon[i]]);
            }
            return laso;
        }
        public LaSo Init_LucSatTinh(LaSo laso)
        {
            #region An Địa Không & Địa Kiếp
            laso.CungLaSo[(11).ViTri(12 - ((int)laso.DiaChi_GioSinh))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DiaKhong]);
            laso.CungLaSo[(11).ViTri((int)laso.DiaChi_GioSinh)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DiaKiep]);
            #endregion

            #region An Hỏa Tinh & Linh Tinh
            List<DiaChi> CungDinhTruoc_HoaTinh = new List<DiaChi>() { DiaChi.Dan, DiaChi.Mao, DiaChi.Suu, DiaChi.Dau, DiaChi.Dan, DiaChi.Mao, DiaChi.Suu, DiaChi.Dau, DiaChi.Dan, DiaChi.Mao, DiaChi.Suu, DiaChi.Dau };
            List<DiaChi> CungDinhTruoc_LinhTinh = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Tuat, DiaChi.Mao, DiaChi.Tuat, DiaChi.Tuat, DiaChi.Tuat, DiaChi.Mao, DiaChi.Tuat, DiaChi.Tuat, DiaChi.Tuat, DiaChi.Mao, DiaChi.Tuat };
            if (laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu)
            {
                laso.CungLaSo[((int)CungDinhTruoc_HoaTinh[(int)laso.DiaChi_NamSinh]).ViTri((int)laso.DiaChi_GioSinh)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HoaTinh]);
                laso.CungLaSo[((int)CungDinhTruoc_LinhTinh[(int)laso.DiaChi_NamSinh]).ViTri((12 - (int)laso.DiaChi_GioSinh))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LinhTinh]);
            }
            else
            {
                laso.CungLaSo[((int)CungDinhTruoc_HoaTinh[(int)laso.DiaChi_NamSinh]).ViTri((12 - (int)laso.DiaChi_GioSinh))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HoaTinh]);
                laso.CungLaSo[((int)CungDinhTruoc_LinhTinh[(int)laso.DiaChi_NamSinh]).ViTri((int)laso.DiaChi_GioSinh)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LinhTinh]);
            }
            #endregion

            #region An Kình Dương & Đà La
            int ViTriLocTon = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.SaoTuVi.Any(m => m.Sao == Sao.LocTon)));
            laso.CungLaSo[ViTriLocTon.ViTri(1)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.KinhDuong]);
            laso.CungLaSo[ViTriLocTon.ViTri(12 - 1)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DaLa]);
            #endregion

            return laso;
        }


        public LaSo Init_XetCucMenh(LaSo laso)
        {
            laso.CucMenh = laso.XetCucMenh();
            return laso;
        }
        public LaSo Init_XetThuanNghich(LaSo laso)
        {
            laso.ThuanNghichLy = laso.XetThuanNghich();
            return laso;
        }
        public LaSo Init_XetChuMenh(LaSo laso)
        {
            List<Sao> ChuMenh = new List<Sao>() { Sao.ThamLang, Sao.CuMon, Sao.LocTon, Sao.VanKhuc, Sao.LiemTrinh, Sao.VuKhuc, Sao.PhaQuan, Sao.VuKhuc, Sao.LiemTrinh, Sao.VanKhuc, Sao.LocTon, Sao.CuMon };
            laso.ChuMenh = ChuMenh[(int)laso.DiaChi_NamSinh];
            return laso;
        }
        public LaSo Init_XetChuThan(LaSo laso)
        {
            List<Sao> ChuThan = new List<Sao>() { Sao.HoaTinh, Sao.ThienTuong, Sao.ThienLuong, Sao.ThienDong, Sao.VanXuong, Sao.ThienCo, Sao.LinhTinh, Sao.ThienTuong, Sao.ThienLuong, Sao.ThienDong, Sao.VanXuong, Sao.ThienCo };
            laso.ChuThan = ChuThan[(int)laso.DiaChi_NamSinh];
            return laso;
        }
        public LaSo Init_AnSaoTheoHangCanNamSinh(LaSo laso)
        {
            List<DiaChi> quocan = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Hoi, DiaChi.Suu, DiaChi.Dan, DiaChi.Suu, DiaChi.Dan, DiaChi.Thin, DiaChi.Ty, DiaChi.Mui, DiaChi.Than };
            List<DiaChi> duongphu = new List<DiaChi>() { DiaChi.Mui, DiaChi.Than, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Suu, DiaChi.Dan, DiaChi.Thin, DiaChi.Ty };
            List<DiaChi> thienkhoi = new List<DiaChi>() { DiaChi.Suu, DiaChi.Ty, DiaChi.Hoi, DiaChi.Hoi, DiaChi.Suu, DiaChi.Ty, DiaChi.Ngo, DiaChi.Ngo, DiaChi.Mao, DiaChi.Mao };
            List<DiaChi> thienviet = new List<DiaChi>() { DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Dan, DiaChi.Mui, DiaChi.Than, DiaChi.Dan, DiaChi.Dan, DiaChi.Ty, DiaChi.Ty };
            List<DiaChi> thienquang = new List<DiaChi>() { DiaChi.Mui, DiaChi.Thin, DiaChi.Ty, DiaChi.Dan, DiaChi.Mao, DiaChi.Dau, DiaChi.Hoi, DiaChi.Dau, DiaChi.Tuat, DiaChi.Ngo };
            List<DiaChi> thienphuc = new List<DiaChi>() { DiaChi.Dau, DiaChi.Than, DiaChi.Ti, DiaChi.Hoi, DiaChi.Mao, DiaChi.Dan, DiaChi.Ngo, DiaChi.Ty, DiaChi.Ngo, DiaChi.Ty };
            List<DiaChi> luuha = new List<DiaChi>() { DiaChi.Dau, DiaChi.Tuat, DiaChi.Mui, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Than, DiaChi.Mao, DiaChi.Hoi, DiaChi.Dan };
            List<DiaChi> thientru = new List<DiaChi>() { DiaChi.Ty, DiaChi.Ngo, DiaChi.Ti, DiaChi.Ty, DiaChi.Ngo, DiaChi.Than, DiaChi.Dan, DiaChi.Ngo, DiaChi.Dau, DiaChi.Tuat };
            List<DiaChi> luunienvantinh = new List<DiaChi>() { DiaChi.Ty, DiaChi.Ngo, DiaChi.Than, DiaChi.Dau, DiaChi.Than, DiaChi.Dau, DiaChi.Hoi, DiaChi.Ti, DiaChi.Dan, DiaChi.Mao };

            laso.CungLaSo[(int)quocan[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.QuocAn]);
            laso.CungLaSo[(int)duongphu[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DuongPhu]);
            laso.CungLaSo[(int)thienkhoi[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienKhoi]);
            laso.CungLaSo[(int)thienviet[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienViet]);
            laso.CungLaSo[(int)thienquang[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienQuan]);
            laso.CungLaSo[(int)thienphuc[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienPhuc]);
            laso.CungLaSo[(int)luuha[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuHa]);
            laso.CungLaSo[(int)thientru[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienTru]);
            laso.CungLaSo[(int)luunienvantinh[(int)laso.ThienCan_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuNienVanTinh]);

            return laso;
        }

        public LaSo Init_AnSaoTheoHangChiNamSinh(LaSo laso)
        {
            List<DiaChi> longtri = new List<DiaChi>() { DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao };
            List<DiaChi> phuongcac = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Dau, DiaChi.Than, DiaChi.Mui, DiaChi.Ngo, DiaChi.Ty, DiaChi.Thin, DiaChi.Mao, DiaChi.Dan, DiaChi.Suu, DiaChi.Ti, DiaChi.Hoi };
            List<DiaChi> giaithan = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Dau, DiaChi.Than, DiaChi.Mui, DiaChi.Ngo, DiaChi.Ty, DiaChi.Thin, DiaChi.Mao, DiaChi.Dan, DiaChi.Suu, DiaChi.Ti, DiaChi.Hoi };
            List<DiaChi> thienkhoc = new List<DiaChi>() { DiaChi.Ngo, DiaChi.Ty, DiaChi.Thin, DiaChi.Mao, DiaChi.Dan, DiaChi.Suu, DiaChi.Ti, DiaChi.Hoi, DiaChi.Tuat, DiaChi.Dau, DiaChi.Than, DiaChi.Mui };
            List<DiaChi> thienhu = new List<DiaChi>() { DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty };
            List<DiaChi> thienduc = new List<DiaChi>() { DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than };
            List<DiaChi> nguyetduc = new List<DiaChi>() { DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin };
            List<DiaChi> hongloan = new List<DiaChi>() { DiaChi.Mao, DiaChi.Dan, DiaChi.Suu, DiaChi.Ti, DiaChi.Hoi, DiaChi.Tuat, DiaChi.Dau, DiaChi.Than, DiaChi.Mui, DiaChi.Ngo, DiaChi.Ty, DiaChi.Thin };
            List<DiaChi> thienhy = new List<DiaChi>() { DiaChi.Dau, DiaChi.Than, DiaChi.Mui, DiaChi.Ngo, DiaChi.Ty, DiaChi.Thin, DiaChi.Mao, DiaChi.Dan, DiaChi.Suu, DiaChi.Ti, DiaChi.Hoi, DiaChi.Tuat };
            List<DiaChi> cothan = new List<DiaChi>() { DiaChi.Dan, DiaChi.Dan, DiaChi.Ty, DiaChi.Ty, DiaChi.Ty, DiaChi.Than, DiaChi.Than, DiaChi.Than, DiaChi.Hoi, DiaChi.Hoi, DiaChi.Hoi, DiaChi.Dan };
            List<DiaChi> quatu = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Tuat, DiaChi.Suu, DiaChi.Suu, DiaChi.Suu, DiaChi.Thin, DiaChi.Thin, DiaChi.Thin, DiaChi.Mui, DiaChi.Mui, DiaChi.Mui, DiaChi.Tuat };
            List<DiaChi> daohoa = new List<DiaChi>() { DiaChi.Dau, DiaChi.Ngo, DiaChi.Mao, DiaChi.Ti, DiaChi.Dau, DiaChi.Ngo, DiaChi.Mao, DiaChi.Ti, DiaChi.Dau, DiaChi.Ngo, DiaChi.Mao, DiaChi.Ti };
            List<DiaChi> thienma = new List<DiaChi>() { DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty, DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty, DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty };
            List<DiaChi> kiepsat = new List<DiaChi>() { DiaChi.Ty, DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty, DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty, DiaChi.Dan, DiaChi.Hoi, DiaChi.Than };
            List<DiaChi> hoacai = new List<DiaChi>() { DiaChi.Thin, DiaChi.Suu, DiaChi.Tuat, DiaChi.Mui, DiaChi.Thin, DiaChi.Suu, DiaChi.Tuat, DiaChi.Mui, DiaChi.Thin, DiaChi.Suu, DiaChi.Tuat, DiaChi.Mui };
            List<DiaChi> phatoai = new List<DiaChi>() { DiaChi.Ty, DiaChi.Suu, DiaChi.Dau, DiaChi.Ty, DiaChi.Suu, DiaChi.Dau, DiaChi.Ty, DiaChi.Suu, DiaChi.Dau, DiaChi.Ty, DiaChi.Suu, DiaChi.Dau };
            List<DiaChi> tkhong = new List<DiaChi>() { DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti };



            laso.CungLaSo[(int)longtri[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LongTri]);
            laso.CungLaSo[(int)phuongcac[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.PhuongCac]);
            laso.CungLaSo[(int)giaithan[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.GiaiThan]);
            laso.CungLaSo[(int)thienkhoc[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienKhoc]);
            laso.CungLaSo[(int)thienhu[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienHu]);
            laso.CungLaSo[(int)thienduc[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienDuc]);
            laso.CungLaSo[(int)nguyetduc[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.NguyetDuc]);
            laso.CungLaSo[(int)hongloan[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HongLoan]);
            laso.CungLaSo[(int)thienhy[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienHy]);
            laso.CungLaSo[(int)cothan[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.CoThan]);
            laso.CungLaSo[(int)quatu[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.QuaTu]);
            laso.CungLaSo[(int)daohoa[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DaoHoa]);
            laso.CungLaSo[(int)thienma[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienMa]);
            laso.CungLaSo[(int)kiepsat[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.KiepSat]);
            laso.CungLaSo[(int)hoacai[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HoaCai]);
            laso.CungLaSo[(int)phatoai[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.PhaToai]);
            laso.CungLaSo[(int)tkhong[(int)laso.DiaChi_NamSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienKhong]);

            return laso;
        }
        public LaSo Init_AnSaoTheoThangSinh(LaSo laso)
        {
            List<DiaChi> taphu = new List<DiaChi>() { DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao };
            List<DiaChi> huubat = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Dau, DiaChi.Than, DiaChi.Mui, DiaChi.Ngo, DiaChi.Ty, DiaChi.Thin, DiaChi.Mao, DiaChi.Dan, DiaChi.Suu, DiaChi.Ti, DiaChi.Hoi };
            List<DiaChi> thienhinh = new List<DiaChi>() { DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than };
            List<DiaChi> thienrieu = new List<DiaChi>() { DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti };
            List<DiaChi> thieny = new List<DiaChi>() { DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti };
            List<DiaChi> thiengiai = new List<DiaChi>() { DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui };
            List<DiaChi> diagiai = new List<DiaChi>() { DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo };

            laso.CungLaSo[(int)taphu[(int)laso.ThangSinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.TaPhu]);
            laso.CungLaSo[(int)huubat[(int)laso.ThangSinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HuuBat]);
            laso.CungLaSo[(int)thienhinh[(int)laso.ThangSinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienHinh]);
            laso.CungLaSo[(int)thienrieu[(int)laso.ThangSinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienDieu]);
            laso.CungLaSo[(int)thieny[(int)laso.ThangSinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienY]);
            laso.CungLaSo[(int)thiengiai[(int)laso.ThangSinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienGiai]);
            laso.CungLaSo[(int)diagiai[(int)laso.ThangSinh_AmLich - 1]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DiaGiai]);

            laso.CungLaSo[((int)taphu[(int)laso.ThangSinh_AmLich - 1]).ViTri(laso.NgaySinh_AmLich - 1)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.TamThai]);
            laso.CungLaSo[((int)huubat[(int)laso.ThangSinh_AmLich - 1]).ViTri(12 - ((laso.NgaySinh_AmLich - 1) % 12))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.BatToa]);
            return laso;
        }
        public LaSo Init_AnSaoTheoGioSinh(LaSo laso)
        {
            List<DiaChi> vanxuong = new List<DiaChi>() { DiaChi.Tuat, DiaChi.Dau, DiaChi.Than, DiaChi.Mui, DiaChi.Ngo, DiaChi.Ty, DiaChi.Thin, DiaChi.Mao, DiaChi.Dan, DiaChi.Suu, DiaChi.Ti, DiaChi.Hoi };
            List<DiaChi> vankhuc = new List<DiaChi>() { DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao };
            List<DiaChi> thaiphu = new List<DiaChi>() { DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu, DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty };
            List<DiaChi> phongcao = new List<DiaChi>() { DiaChi.Dan, DiaChi.Mao, DiaChi.Thin, DiaChi.Ty, DiaChi.Ngo, DiaChi.Mui, DiaChi.Than, DiaChi.Dau, DiaChi.Tuat, DiaChi.Hoi, DiaChi.Ti, DiaChi.Suu };
            //List<DiaChi> diakhong     = new List<DiaChi>() { DiaChi.Hoi,DiaChi.Tuat,DiaChi.Dau,DiaChi.Than,DiaChi.Mui,DiaChi.Ngo,DiaChi.Ty,DiaChi.Thin,DiaChi.Mao,DiaChi.Dan,DiaChi.Suu,DiaChi.Ti };
            //List<DiaChi> diakiep     = new List<DiaChi>() { DiaChi.Hoi,DiaChi.Ti,DiaChi.Suu,DiaChi.Dan,DiaChi.Mao,DiaChi.Thin,DiaChi.Ty,DiaChi.Ngo,DiaChi.Mui,DiaChi.Than,DiaChi.Dau,DiaChi.Tuat };

            laso.CungLaSo[(int)vanxuong[(int)laso.DiaChi_GioSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.VanXuong]);
            laso.CungLaSo[(int)vankhuc[(int)laso.DiaChi_GioSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.VanKhuc]);
            laso.CungLaSo[(int)thaiphu[(int)laso.DiaChi_GioSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThaiPhu]);
            laso.CungLaSo[(int)phongcao[(int)laso.DiaChi_GioSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.PhongCao]);
            //laso.CungLaSo[(int)diakhong[(int)laso.DiaChi_GioSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DiaKhong]);
            //laso.CungLaSo[(int)diakiep [(int)laso.DiaChi_GioSinh]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DiaKiep]);

            laso.CungLaSo[((int)vanxuong[(int)laso.DiaChi_GioSinh]).ViTri((laso.NgaySinh_AmLich - 1) + 11)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.AnQuang]);
            laso.CungLaSo[((int)vankhuc[(int)laso.DiaChi_GioSinh]).ViTri((12 - ((laso.NgaySinh_AmLich - 1) % 12)) + 1)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienQuy]);
            return laso;
        }

        public LaSo Init_AnSaoCoDinh(LaSo laso)
        {
            laso.CungLaSo[4].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienLa]);
            laso.CungLaSo[10].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DiaVong]);

            var indexCungNoBoc = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.Cung.Any(m => m == Cung.NoBoc)));
            laso.CungLaSo[indexCungNoBoc].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienThuong]);

            #region an đẩu quân
            var indexThaiTue = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.DiaChi == laso.DiaChi_NamSinh));
            laso.CungLaSo[indexThaiTue.ViTri((12 - ((int)laso.ThangSinh_AmLich - 1))).ViTri((int)laso.DiaChi_GioSinh)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.DauQuan]);
            #endregion

            #region an Thiên tài
            var indexMenh = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.Cung.Any(m => m == Cung.Menh)));
            laso.CungLaSo[indexMenh.ViTri((int)laso.DiaChi_NamSinh)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienTai]);
            #endregion

            #region an Thiên Thọ
            var indexThan = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.Cung.Any(m => m == Cung.Than)));
            laso.CungLaSo[indexThan.ViTri((int)laso.DiaChi_NamSinh)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienTho]);
            #endregion

            #region an Thiên sứ
            var indexTatAch = laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.Cung.Any(m => m == Cung.TatAch)));
            laso.CungLaSo[indexTatAch].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.ThienSu]);
            #endregion
            return laso;
        }
        public LaSo Init_AnTuHoa(LaSo laso)
        {
            List<Sao> hoaloc = new List<Sao>() { Sao.LiemTrinh, Sao.ThienCo, Sao.ThienDong, Sao.ThaiAm, Sao.ThamLang, Sao.VuKhuc, Sao.ThaiDuong, Sao.CuMon, Sao.ThienLuong, Sao.PhaQuan };
            List<Sao> hoaquyen = new List<Sao>() { Sao.PhaQuan, Sao.ThienLuong, Sao.ThienCo, Sao.ThienDong, Sao.ThaiAm, Sao.ThamLang, Sao.VuKhuc, Sao.ThaiDuong, Sao.TuVi, Sao.CuMon };
            List<Sao> hoakhoa = new List<Sao>() { Sao.VuKhuc, Sao.TuVi, Sao.VanXuong, Sao.ThienCo, Sao.HuuBat, Sao.ThienLuong, Sao.ThaiAm, Sao.VanKhuc, Sao.TaPhu, Sao.ThaiAm };
            List<Sao> hoaky = new List<Sao>() { Sao.ThaiDuong, Sao.ThaiAm, Sao.LiemTrinh, Sao.CuMon, Sao.ThienCo, Sao.VanKhuc, Sao.ThienDong, Sao.VanXuong, Sao.VuKhuc, Sao.ThamLang };

            laso.CungLaSo[laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.SaoTuVi.Any(m => m.Sao == hoaloc[(int)laso.ThienCan_NamSinh])))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HoaLoc]);
            laso.CungLaSo[laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.SaoTuVi.Any(m => m.Sao == hoakhoa[(int)laso.ThienCan_NamSinh])))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HoaKhoa]);
            laso.CungLaSo[laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.SaoTuVi.Any(m => m.Sao == hoaquyen[(int)laso.ThienCan_NamSinh])))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HoaQuyen]);
            laso.CungLaSo[laso.CungLaSo.IndexOf(laso.CungLaSo.FirstOrDefault(_ => _.SaoTuVi.Any(m => m.Sao == hoaky[(int)laso.ThienCan_NamSinh])))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.HoaKy]);
            return laso;
        }
        public LaSo Init_AnTuanTriet(LaSo laso)
        {
            #region an tuần
            List<int> can = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> chi = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int i = 0;
            for (; i < 60; i++)
            {
                if (can[i] == (int)laso.ThienCan_NamSinh && chi[i] == (int)laso.DiaChi_NamSinh)
                    break;
            }
            if ((i / 10) == 0)
            {
                laso.CungLaSo[10].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
                laso.CungLaSo[11].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
            }
            else if ((i / 10) == 1)
            {
                laso.CungLaSo[8].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
                laso.CungLaSo[9].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
            }
            else if ((i / 10) == 2)
            {
                laso.CungLaSo[6].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
                laso.CungLaSo[7].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
            }
            else if ((i / 10) == 3)
            {
                laso.CungLaSo[5].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
                laso.CungLaSo[4].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
            }
            else if ((i / 10) == 4)
            {
                laso.CungLaSo[3].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
                laso.CungLaSo[2].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
            }
            else if ((i / 10) == 5)
            {
                laso.CungLaSo[1].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
                laso.CungLaSo[0].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Tuan]);
            }
            #endregion

            #region An triệt
            if (((int)laso.ThienCan_NamSinh) % 5 == 0)
            {
                laso.CungLaSo[8].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
                laso.CungLaSo[9].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
            }
            else if (((int)laso.ThienCan_NamSinh) % 5 == 1)
            {
                laso.CungLaSo[6].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
                laso.CungLaSo[7].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
            }
            else if (((int)laso.ThienCan_NamSinh) % 5 == 2)
            {
                laso.CungLaSo[4].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
                laso.CungLaSo[5].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
            }
            else if (((int)laso.ThienCan_NamSinh) % 5 == 3)
            {
                laso.CungLaSo[2].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
                laso.CungLaSo[3].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
            }
            else if (((int)laso.ThienCan_NamSinh) % 5 == 4)
            {
                laso.CungLaSo[0].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
                laso.CungLaSo[1].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.Triet]);
            }

            #endregion
            return laso;
        }
        public LaSo Init_AnCacSaoLuu(LaSo laso)
        {

            laso.CungLaSo[(int)laso.DiaChi_NamXem].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuThaiTue]);
            laso.CungLaSo[((int)laso.DiaChi_NamXem).ViTri(6)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuTuePha]);
            laso.CungLaSo[((int)laso.DiaChi_NamXem).ViTri(6)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuThienHu]);
            laso.CungLaSo[((int)laso.DiaChi_NamXem).ViTri(2)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuTangMon]);
            laso.CungLaSo[((int)laso.DiaChi_NamXem).ViTri(2).ViTri(6)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuBachHo]);
            laso.CungLaSo[(6).ViTri(12 - ((int)laso.DiaChi_NamXem))].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuThienKhoc]);

            List<DiaChi> ViTriCungLocTon = new List<DiaChi>() { DiaChi.Dan, DiaChi.Mao, DiaChi.Ty, DiaChi.Ngo, DiaChi.Ty, DiaChi.Ngo, DiaChi.Than, DiaChi.Dau, DiaChi.Hoi, DiaChi.Ti };
            int viTriLuuLocTon = (int)ViTriCungLocTon[(int)laso.ThienCan_NamXem];
            laso.CungLaSo[viTriLuuLocTon].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuLocTon]);

            List<DiaChi> LuuThienMa = new List<DiaChi>() { DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty, DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty, DiaChi.Dan, DiaChi.Hoi, DiaChi.Than, DiaChi.Ty };
            laso.CungLaSo[(int)LuuThienMa[(int)laso.DiaChi_NamXem]].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuThienMa]);

            #region An Kình Dương & Đà La

            laso.CungLaSo[viTriLuuLocTon.ViTri(1)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuKinhDuong]);
            laso.CungLaSo[viTriLuuLocTon.ViTri(12 - 1)].SaoTuVi.Add(TuViDataServices.DIC_SAO[Sao.LuuDaLa]);
            #endregion
            return laso;
        }
        public LaSo Init_AnNguyetHan(LaSo laso)
        {
            if (laso.AmDuongNamNu == AmDuongNamNu.DuongNam || laso.AmDuongNamNu == AmDuongNamNu.AmNu)
            {
                for (int i = 0; i < 12; i++)
                {
                    laso.CungLaSo[((int)laso.DiaChi_NamXem).ViTri(((int)laso.DiaChi_ThangSinh).ViTri(10)).ViTri((int)laso.DiaChi_GioSinh).ViTri(i)].NguyetHan = (NguyetHan)i;
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    laso.CungLaSo[((int)laso.DiaChi_NamXem).ViTri(((int)laso.DiaChi_ThangSinh).ViTri(10)).ViTri(12 - ((int)laso.DiaChi_GioSinh)).ViTri(i)].NguyetHan = (NguyetHan)i;
                }
            }
            return laso;
        }

        public LaSo PrepareLaSo(LaSo laso, CreateLaSoDuongLichModel model)
        {
            laso = Init_LaSo(laso, model);
            laso = Init_AnMenhThan(laso);
            laso = Init_XacDinhCuc(laso);
            laso = Init_XetCucMenh(laso);
            laso = Init_XetChuMenh(laso);
            laso = Init_XetChuThan(laso);
            laso = Init_XetThuanNghich(laso);
            laso = Init_XacDinhDaiVan(laso);
            laso = Init_XacDinhTieuVan(laso);
            laso = Init_AnSaoChinhTinh(laso);
            laso = Init_AnTrangSinh(laso);
            laso = Init_AnVongLocTon(laso);
            laso = Init_LucSatTinh(laso);
            laso = Init_AnVongThaiTue(laso);
            laso = Init_AnSaoTheoHangCanNamSinh(laso);
            laso = Init_AnSaoTheoHangChiNamSinh(laso);
            laso = Init_AnSaoTheoThangSinh(laso);
            laso = Init_AnSaoTheoGioSinh(laso);
            laso = Init_AnSaoCoDinh(laso);
            laso = Init_AnTuHoa(laso);
            laso = Init_AnTuanTriet(laso);
            laso = Init_AnCacSaoLuu(laso);
            laso = Init_AnNguyetHan(laso);



            laso = Init_XacDinhDoAnhHuong(laso);
            return laso;
        }

        [HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult Index()
        {
            CreateLaSoDuongLichModel model = new CreateLaSoDuongLichModel
            {
                GioiTinh = true,
                Ngay = 24,
                Thang = 1,
                Ten = "Phú",
                Gio = 16,
                Phut = 40,
                Nam = 1991,
                NamXemHan = 2018
            };
            LaSo laso = new LaSo();
            laso = PrepareLaSo(laso, model);
            TempData["GioiTinh"] = model.GioiTinh;
            return View(string.Format(_controllerViews, "TVIndex"), laso);
        }
        public IActionResult Index2(string ten, bool gioitinh, int ngay, int thang, int nam, int gio, int phut, int namhan)
        {

            CreateLaSoDuongLichModel model = new CreateLaSoDuongLichModel
            {
                GioiTinh = gioitinh,
                Ngay = ngay,
                Thang = thang,
                Ten = ten,
                Gio = gio,
                Phut = phut,
                Nam = nam,
                NamXemHan = namhan
            };
            LaSo laso = new LaSo();
            laso = PrepareLaSo(laso, model);
            TempData["GioiTinh"] = model.GioiTinh;
            return View(string.Format(_controllerViews, "TVIndex"), laso);
        }
        public IActionResult LapLaSo(CreateLaSoDuongLichModel model)
        {
            try
            {
                DateTime d = new DateTime(model.Nam, model.Thang, model.Ngay, model.Gio, model.Phut, 0);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("NamXemHan", "Ngày nhập sai, kiểm tra lại!");
            }
            TempData["GioiTinh"] = model.GioiTinh;
            if (ModelState.IsValid)
            {

                LaSo laso = new LaSo();
                laso = PrepareLaSo(laso, model);
                return Json(new RespondData
                {
                    Status = true,
                    Data = RenderPartialViewToString(string.Format(_controllerViews, "_Partial_LaSo"), laso)
                });
            }
            return Json(new RespondData
            {
                Status = true,
                Data = RenderPartialViewToString( string.Format(_controllerViews, "_LapLaSoForm"), model)
            });
        }
    }
}