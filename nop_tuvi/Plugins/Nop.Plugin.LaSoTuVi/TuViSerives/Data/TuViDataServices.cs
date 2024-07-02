using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Plugin.LaSoTuVi.TuViSerives.Data
{
    public static class TuViDataServices
    {

        public readonly static Dictionary<Sao, SaoTuVi> DIC_SAO = new Dictionary<Sao, SaoTuVi>()
        {
            //
            {Sao.TuVi ,           new SaoTuVi{Ten = "Tử Vi",       AmDuong = AmDuong.Duong,Sao =Sao.TuVi,       LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.CaNamLanBacDauTinh,NguHanh =new List<NguHanh>(){ NguHanh.Tho }, LoaiDacTinh = new List<LoaiDacTinh>(){ LoaiDacTinh.DeTinh},                                                               } },
            {Sao.ThienCo ,        new SaoTuVi{Ten = "Thiên Cơ",    AmDuong = AmDuong.Am,   Sao =Sao.ThienCo,    LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.NamDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Moc }, LoaiDacTinh        = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },                                                   } },
            {Sao.ThaiDuong ,      new SaoTuVi{Ten = "Thái Dương",  AmDuong = AmDuong.Duong,Sao =Sao.ThaiDuong,  LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.NamDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Hoa }, LoaiDacTinh   = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh },                                                          } },
            {Sao.VuKhuc ,         new SaoTuVi{Ten = "Vũ Khúc",     AmDuong = AmDuong.Am,   Sao =Sao.VuKhuc,     LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.BacDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Kim }, LoaiDacTinh         = new List<LoaiDacTinh>(){  LoaiDacTinh.TaiTinh,LoaiDacTinh.QuyenTinh},                               } },
            {Sao.ThienDong ,      new SaoTuVi{Ten = "Thiên Đồng",  AmDuong = AmDuong.Duong,Sao =Sao.ThienDong,  LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.NamDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh  = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh },                                                          } },
            {Sao.LiemTrinh ,      new SaoTuVi{Ten = "Liêm Trinh",  AmDuong = AmDuong.Am,   Sao =Sao.LiemTrinh,  LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.BacDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Hoa }, LoaiDacTinh      = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyenTinh,LoaiDacTinh.DaoHoaTinh,LoaiDacTinh.TuTinh},            } },
            {Sao.ThienPhu ,       new SaoTuVi{Ten = "Thiên Phủ",   AmDuong = AmDuong.Duong,Sao =Sao.ThienPhu,   LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.NamDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Tho }, LoaiDacTinh    = new List<LoaiDacTinh>(){  LoaiDacTinh.TaiTinh , LoaiDacTinh.QuyenTinh },                                 } },
            {Sao.ThaiAm ,         new SaoTuVi{Ten = "Thái Âm",     AmDuong = AmDuong.Am,   Sao =Sao.ThaiAm,     LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.BacDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh        = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh , LoaiDacTinh.PhuTinh},                               } },
            {Sao.ThamLang ,       new SaoTuVi{Ten = "Tham Lang",   AmDuong = AmDuong.Am,   Sao =Sao.ThamLang,   LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.BacDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh      = new List<LoaiDacTinh>(){  LoaiDacTinh.HungTinh, LoaiDacTinh.DamTinh },                                 } },
            {Sao.CuMon ,          new SaoTuVi{Ten = "Cự Môn",      AmDuong = AmDuong.Am,   Sao =Sao.CuMon,      LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.BacDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh         = new List<LoaiDacTinh>(){  LoaiDacTinh.AmTinh},                                                      } },
            {Sao.ThienTuong ,     new SaoTuVi{Ten = "Thiên Tướng", AmDuong = AmDuong.Duong,Sao =Sao.ThienTuong, LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.NamDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AnTinh    , LoaiDacTinh.QuyenTinh },                                  } },
            {Sao.ThienLuong ,     new SaoTuVi{Ten = "Thiên Lương", AmDuong = AmDuong.Am,   Sao =Sao.ThienLuong, LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.NamDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Moc }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh  ,LoaiDacTinh.ThoTinh },                                 } },
            {Sao.ThatSat ,        new SaoTuVi{Ten = "Thất Sát",    AmDuong = AmDuong.Duong,Sao =Sao.ThatSat,    LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.NamDauTinh,NguHanh =       new List<NguHanh>(){  NguHanh.Kim }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyenTinh ,LoaiDacTinh.DungTinh },                                } },
            {Sao.PhaQuan ,        new SaoTuVi{Ten = "Phá Quân",    AmDuong = AmDuong.Am,   Sao =Sao.PhaQuan,    LoaiSao =  new List<LoaiSao>(){ LoaiSao.ChinhTinh},LoaiViTri = LoaiViTri.ChinhDieu, PhuongVi = PhuongVi.PhaVoChiaRoi,NguHanh =     new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyenTinh ,LoaiDacTinh.HaoTinh },                                 } },

            {Sao.KinhDuong,       new SaoTuVi{Ten = "Kình Dương",        Sao = Sao.KinhDuong,  LoaiSao = new List<LoaiSao>(){LoaiSao.LucSatTinh },LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                               new List<NguHanh>(){NguHanh.Kim }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.HinhTinh ,LoaiDacTinh.HungTinh },                                          } },
            {Sao.DaLa,            new SaoTuVi{Ten = "Đà La",             Sao = Sao.DaLa,       LoaiSao = new List<LoaiSao>(){LoaiSao.LucSatTinh},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                new List<NguHanh>(){NguHanh.Kim}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.SatTinh  },                                                                 } },
            {Sao.DiaKhong,        new SaoTuVi{Ten = "Địa Không",         Sao = Sao.DiaKhong,   LoaiSao = new List<LoaiSao>(){LoaiSao.LucSatTinh},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                new List<NguHanh>(){NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.SatTinh  },                                                                 } },
            {Sao.DiaKiep,         new SaoTuVi{Ten = "Địa Kiếp",          Sao = Sao.DiaKiep,    LoaiSao = new List<LoaiSao>(){LoaiSao.LucSatTinh},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                new List<NguHanh>(){NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.SatTinh  },                                                                 } },
            {Sao.HoaTinh,         new SaoTuVi{Ten = "Hỏa Tinh",          Sao = Sao.HoaTinh,    LoaiSao = new List<LoaiSao>(){LoaiSao.LucSatTinh},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                new List<NguHanh>(){NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.HungTinh, LoaiDacTinh.SatTinh},                                             } },
            {Sao.LinhTinh,        new SaoTuVi{Ten = "Linh Tinh",         Sao = Sao.LinhTinh,   LoaiSao = new List<LoaiSao>(){LoaiSao.LucSatTinh},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                new List<NguHanh>(){NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.SatTinh ,LoaiDacTinh.HaoTinh },                                             } },

            {Sao.TieuHao,         new SaoTuVi{Ten = "Tiểu Hao",          Sao = Sao.TieuHao,    LoaiSao = new List<LoaiSao>(){LoaiSao.LucBaiTinh, LoaiSao.VongLocTon, LoaiSao.SongHao},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                 new List<NguHanh>(){NguHanh.Hoa }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.HaoTinh ,LoaiDacTinh.BaiTinh },       } },
            {Sao.DaiHao,          new SaoTuVi{Ten = "Đại Hao",           Sao = Sao.DaiHao,     LoaiSao = new List<LoaiSao>(){LoaiSao.LucBaiTinh, LoaiSao.VongLocTon, LoaiSao.SongHao},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                 new List<NguHanh>(){NguHanh.Hoa }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.HaoTinh ,LoaiDacTinh.BaiTinh  },      } },
            {Sao.TangMon,         new SaoTuVi{Ten = "Tang Môn",          Sao = Sao.TangMon,    LoaiSao = new List<LoaiSao>(){LoaiSao.LucBaiTinh, LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                 new List<NguHanh>(){NguHanh.Moc }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                                                } },
            {Sao.BachHo,          new SaoTuVi{Ten = "Bạch Hổ",           Sao = Sao.BachHo,     LoaiSao = new List<LoaiSao>(){LoaiSao.LucBaiTinh, LoaiSao.TuLinh, LoaiSao.ThaiTue}, PhuongVi = PhuongVi.BacDauTinh,LoaiViTri = LoaiViTri.SaoXau, NguHanh = new List<NguHanh>(){NguHanh.Kim }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                                                } },
            {Sao.ThienKhoc,       new SaoTuVi{Ten = "Thiên Khốc",        Sao = Sao.ThienKhoc,  LoaiSao = new List<LoaiSao>(){LoaiSao.LucBaiTinh},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                 new List<NguHanh>(){NguHanh.Kim}, LoaiDacTinh    = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                                                                   } },
            {Sao.ThienHu,         new SaoTuVi{Ten = "Thiên Hư",          Sao = Sao.ThienHu,    LoaiSao = new List<LoaiSao>(){LoaiSao.LucBaiTinh},LoaiViTri = LoaiViTri.SaoXau, NguHanh =                                                 new List<NguHanh>(){NguHanh.Thuy}, LoaiDacTinh    = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                                                                  } },

            {Sao.Tuan,            new SaoTuVi{Ten = "Tuần",              Sao = Sao.Tuan,       LoaiSao = new List<LoaiSao>(){LoaiSao.TuanTriet},LoaiViTri = LoaiViTri.TuanTriet, LoaiDacTinh    = new List<LoaiDacTinh>(){  LoaiDacTinh.AmTinh },                                                                                                                                                              } },
            {Sao.Triet,           new SaoTuVi{Ten = "Triệt",             Sao = Sao.Triet,      LoaiSao = new List<LoaiSao>(){LoaiSao.TuanTriet},LoaiViTri = LoaiViTri.TuanTriet, LoaiDacTinh    = new List<LoaiDacTinh>(){  LoaiDacTinh.TuyTinh },                                                                                                                                                             } },

            {Sao.HoaKhoa,         new SaoTuVi{Ten = "Hóa Khoa",          Sao = Sao.HoaKhoa,    LoaiSao = new List<LoaiSao>(){LoaiSao.TuHoa},LoaiViTri = LoaiViTri.SaoTot,NguHanh =new List<NguHanh>(){ NguHanh.Moc,NguHanh.Thuy }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.VanTinh ,LoaiDacTinh.PhucTinh },                                                                                    } },
            {Sao.HoaQuyen,        new SaoTuVi{Ten = "Hóa Quyền",         Sao = Sao.HoaQuyen,   LoaiSao = new List<LoaiSao>(){LoaiSao.TuHoa},LoaiViTri = LoaiViTri.SaoTot,NguHanh =new List<NguHanh>(){ NguHanh.Moc }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyenTinh },                                                                                                                     } },
            {Sao.HoaLoc,          new SaoTuVi{Ten = "Hóa Lộc",           Sao = Sao.HoaLoc,     LoaiSao = new List<LoaiSao>(){LoaiSao.TuHoa},LoaiViTri = LoaiViTri.SaoTot,NguHanh =new List<NguHanh>(){ NguHanh.Moc, NguHanh.Tho }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh },                                                                                                         } },
            {Sao.HoaKy,           new SaoTuVi{Ten = "Hóa Kỵ",            Sao = Sao.HoaKy,      LoaiSao = new List<LoaiSao>(){LoaiSao.TuHoa},LoaiViTri = LoaiViTri.SaoXau,NguHanh =new List<NguHanh>(){ NguHanh.Thuy }, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },                                                                                                                       } },

            {Sao.LongTri,         new SaoTuVi{Ten = "Long Trì",          Sao = Sao.LongTri,    LoaiSao = new List<LoaiSao>(){LoaiSao.TuLinh},LoaiViTri = LoaiViTri.SaoTot, PhuongVi = PhuongVi.BacDauTinh, NguHanh =new List<NguHanh>(){ NguHanh.Thuy }, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyenTinh ,LoaiDacTinh.HaoTinh },                                                                } },
            {Sao.PhuongCac,       new SaoTuVi{Ten = "Phượng Các",        Sao = Sao.PhuongCac,  LoaiSao = new List<LoaiSao>(){LoaiSao.TuLinh},LoaiViTri = LoaiViTri.SaoTot, PhuongVi = PhuongVi.BacDauTinh, NguHanh =new List<NguHanh>(){ NguHanh.Thuy}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyenTinh ,LoaiDacTinh.HaoTinh },                                                                 } },
            {Sao.HoaCai,          new SaoTuVi{Ten = "Hoa Cái",           Sao = Sao.HoaCai,     LoaiSao = new List<LoaiSao>(){LoaiSao.TuLinh},LoaiViTri = LoaiViTri.SaoTot, PhuongVi = PhuongVi.BacDauTinh, NguHanh =new List<NguHanh>(){ NguHanh.Kim}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyenTinh ,LoaiDacTinh.HaoTinh },                                                                  } },

            {Sao.ThaiTue,         new SaoTuVi{Ten = "Thái Tuế",          Sao = Sao.ThaiTue,   LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhuTinh, LoaiDacTinh.HinhTinh },                                                                                                 } },
            {Sao.ThieuDuong,      new SaoTuVi{Ten = "Thiếu Dương",       Sao = Sao.ThieuDuong,LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoTot, NguHanh =new List<NguHanh>(){ NguHanh.Hoa}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },                                                                                                                  } },
            {Sao.ThieuAm,         new SaoTuVi{Ten = "Thiếu Âm",          Sao = Sao.ThieuAm,   LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoTot, NguHanh =new List<NguHanh>(){ NguHanh.Thuy}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },                                                                                                                    } },
            {Sao.QuanPhu,         new SaoTuVi{Ten = "Quan Phù",          Sao = Sao.QuanPhu,   LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue, LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhuTinh, LoaiDacTinh.HinhTinh },                                                                             } },
            {Sao.TuPhu,           new SaoTuVi{Ten = "Tử Phù",            Sao = Sao.TuPhu,     LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa, NguHanh.Kim}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.HungTinh },                                                                                                           } },
            {Sao.TuePha,          new SaoTuVi{Ten = "Tuế Phá",           Sao = Sao.TuePha,    LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                                                                                                                        } },
            {Sao.LongDuc,         new SaoTuVi{Ten = "Long Đức",          Sao = Sao.LongDuc,   LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoTot, NguHanh =new List<NguHanh>(){ NguHanh.Thuy}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },                                                                                                                    } },
            {Sao.PhucDuc,         new SaoTuVi{Ten = "Phúc Đức",          Sao = Sao.PhucDuc,   LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoTot, NguHanh =new List<NguHanh>(){ NguHanh.Tho}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh },                                                                                                                      } },
            {Sao.DieuKhach,       new SaoTuVi{Ten = "Điếu Khách",        Sao = Sao.DieuKhach, LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh},                                                                                                                      } },
            {Sao.TrucPhu,         new SaoTuVi{Ten = "Trực Phù",          Sao = Sao.TrucPhu,   LoaiSao = new List<LoaiSao>(){LoaiSao.ThaiTue},LoaiViTri = LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa, NguHanh.Kim}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },                                                                                                           } },

            {Sao.LocTon,          new SaoTuVi{Ten = "Lộc Tồn",           Sao = Sao.LocTon,    LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoTot, PhuongVi = PhuongVi.BacDauTinh,NguHanh =     new List<NguHanh>(){  NguHanh.Tho}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh},                                                                            } },
            {Sao.BacSi ,          new SaoTuVi{Ten = "Bác sĩ",            Sao = Sao.BacSi,     LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoTot,NguHanh =     new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                            } },
            {Sao.LucSi ,          new SaoTuVi{Ten = "Lực Sĩ",            Sao = Sao.LucSi,     LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoTot,NguHanh =     new List<NguHanh>(){  NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                             } },
            {Sao.ThanhLong ,      new SaoTuVi{Ten = "Thanh Long",        Sao = Sao.ThanhLong, LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoTot,NguHanh =     new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                        } },
            {Sao.TuongQuan ,      new SaoTuVi{Ten = "Tướng Quân",        Sao = Sao.TuongQuan, LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoXau,NguHanh =     new List<NguHanh>(){  NguHanh.Moc}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                         } },
            {Sao.TauThu ,         new SaoTuVi{Ten = "Tấu Thư",           Sao = Sao.TauThu,    LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoTot,NguHanh =     new List<NguHanh>(){  NguHanh.Kim}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                            } },
            {Sao.PhiLiem ,        new SaoTuVi{Ten = "Phi Liêm",          Sao = Sao.PhiLiem ,  LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoXau,NguHanh =     new List<NguHanh>(){  NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                          } },
            {Sao.HiThan ,         new SaoTuVi{Ten = "Hỉ Thần",           Sao = Sao.HiThan,    LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoTot,NguHanh =     new List<NguHanh>(){  NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                            } },
            {Sao.BenhPhu ,        new SaoTuVi{Ten = "Bệnh Phù",          Sao = Sao.BenhPhu,   LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoXau,NguHanh =     new List<NguHanh>(){  NguHanh.Tho}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                           } },
            {Sao.PhucBinh ,       new SaoTuVi{Ten = "Phục Binh",         Sao = Sao.PhucBinh,  LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoXau,NguHanh =     new List<NguHanh>(){  NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                          } },
            {Sao.QuanPhuR ,       new SaoTuVi{Ten = "Quan Phủ",          Sao = Sao.QuanPhuR,   LoaiSao =  new List<LoaiSao>(){ LoaiSao.VongLocTon},LoaiViTri = LoaiViTri.SaoXau,NguHanh =     new List<NguHanh>(){  NguHanh.Hoa}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh},                                                                                                           } },

            {Sao.VanXuong ,       new SaoTuVi{Ten = "Văn Xương",         Sao = Sao.VanXuong,  LoaiSao =  new List<LoaiSao>(){ LoaiSao.XuongKhuc},LoaiViTri = LoaiViTri.SaoTot,NguHanh =     new List<NguHanh>(){  NguHanh.Kim}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.VanTinh},                                                                                                            } },
            {Sao.VanKhuc ,        new SaoTuVi{Ten = "Văn Khúc",          Sao = Sao.VanKhuc,   LoaiSao =  new List<LoaiSao>(){ LoaiSao.XuongKhuc},LoaiViTri = LoaiViTri.SaoTot,NguHanh =     new List<NguHanh>(){  NguHanh.Thuy}, LoaiDacTinh     = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh},                                                                                                           } },

            {Sao.QuocAn ,           new SaoTuVi{Ten = "Quốc Ấn",         Sao =Sao.QuocAn ,          NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh },  }},
            {Sao.DuongPhu ,         new SaoTuVi{Ten = "Đường Phù",       Sao =Sao.DuongPhu ,        NguHanh =     new List<NguHanh>(){NguHanh.Moc},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh },  }},
            {Sao.ThienKhoi ,        new SaoTuVi{Ten = "Thiên Khôi",      Sao =Sao.ThienKhoi ,       NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh},  }},
            {Sao.ThienViet ,        new SaoTuVi{Ten = "Thiên Việt",      Sao =Sao.ThienViet ,       NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh },  }},
            {Sao.ThienQuan ,        new SaoTuVi{Ten = "Thiên Quan  ",    Sao =Sao.ThienQuan ,       NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh },  }},
            {Sao.ThienPhuc ,        new SaoTuVi{Ten = "Thiên Phúc",      Sao =Sao.ThienPhuc ,       NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh },  }},
            {Sao.LuuHa ,            new SaoTuVi{Ten = "Lưu Hà",          Sao =Sao.LuuHa ,           NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },  }},
            {Sao.ThienTru ,         new SaoTuVi{Ten = "Thiên Trù",       Sao =Sao.ThienTru ,        NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AmThuc },  }},

            {Sao.GiaiThan ,         new SaoTuVi{Ten = "Giải Thần",       Sao =Sao.GiaiThan ,        NguHanh =     new List<NguHanh>(){NguHanh.Moc},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },  }},
            {Sao.ThienDuc ,         new SaoTuVi{Ten = "Thiên Đức",       Sao =Sao.ThienDuc ,        NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },  }},
            {Sao.NguyetDuc ,        new SaoTuVi{Ten = "Nguyệt Đức",      Sao =Sao.NguyetDuc ,       NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },  }},
            {Sao.HongLoan ,         new SaoTuVi{Ten = "Hồng Loan",       Sao =Sao.HongLoan ,        NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.DamTinh },  }},
            {Sao.ThienHy ,          new SaoTuVi{Ten = "Thiên Hỷ",        Sao =Sao.ThienHy ,         NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.ThienTinh },  }},
            {Sao.CoThan ,           new SaoTuVi{Ten = "Cô Thần",         Sao =Sao.CoThan ,          NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AmTinh },  }},
            {Sao.QuaTu ,            new SaoTuVi{Ten = "Quả Tú",          Sao =Sao.QuaTu ,           NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AmTinh },  }},
            {Sao.DaoHoa ,           new SaoTuVi{Ten = "Đào Hoa",         Sao =Sao.DaoHoa ,          NguHanh =     new List<NguHanh>(){NguHanh.Moc},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.DamTinh },  }},
            {Sao.ThienMa ,          new SaoTuVi{Ten = "Thiên Mã",        Sao =Sao.ThienMa ,         NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh },  }},
            {Sao.KiepSat ,          new SaoTuVi{Ten = "Kiếp Sát",        Sao =Sao.KiepSat ,         NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },  }},
            {Sao.PhaToai,           new SaoTuVi{Ten = "Phá Toái",        Sao =Sao.PhaToai,          NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.HungTinh },  }},
            {Sao.ThienKhong ,       new SaoTuVi{Ten = "Thiên Không",     Sao =Sao.ThienKhong ,      NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },  }},

            {Sao.TaPhu ,            new SaoTuVi{Ten = "Tả Phù",          Sao =Sao.TaPhu ,           NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhuTinh, LoaiDacTinh.HoTinh },  }},
            {Sao.HuuBat ,           new SaoTuVi{Ten = "Hữu Bật",         Sao =Sao.HuuBat ,          NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhuTinh, LoaiDacTinh.HoTinh },  }},
            {Sao.ThienHinh,         new SaoTuVi{Ten = "Thiên Hình",      Sao =Sao.ThienHinh,        NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.HungTinh },  }},
            {Sao.ThienDieu ,        new SaoTuVi{Ten = "Thiên Diêu",      Sao =Sao.ThienDieu ,       NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.DamTinh },  }},
            {Sao.ThienY ,           new SaoTuVi{Ten = "Thiên Y",         Sao =Sao.ThienY ,          NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.TuyTinh },  }},
            {Sao.ThienGiai ,        new SaoTuVi{Ten = "Thiên Giải",      Sao =Sao.ThienGiai ,       NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh },  }},
            {Sao.DiaGiai ,          new SaoTuVi{Ten = "Địa Giải",        Sao =Sao.DiaGiai ,         NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh },  }},
            {Sao.ThaiPhu ,          new SaoTuVi{Ten = "Thai Phụ",        Sao =Sao.ThaiPhu ,         NguHanh =     new List<NguHanh>(){NguHanh.Kim},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.VanTinh },  }},
            {Sao.PhongCao ,         new SaoTuVi{Ten = "Phong Cáo",       Sao =Sao.PhongCao ,        NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.VanTinh, LoaiDacTinh.QuyTinh },  }},
            {Sao.TamThai ,          new SaoTuVi{Ten = "Tam Thai",        Sao =Sao.TamThai ,         NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh },  }},
            {Sao.BatToa ,           new SaoTuVi{Ten = "Bát Tọa",         Sao =Sao.BatToa ,          NguHanh =     new List<NguHanh>(){NguHanh.Moc},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh },  }},
            {Sao.AnQuang ,          new SaoTuVi{Ten = "Ân Quang",        Sao =Sao.AnQuang ,         NguHanh =     new List<NguHanh>(){NguHanh.Moc},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh },  }},
            {Sao.ThienQuy ,         new SaoTuVi{Ten = "Thiên Quý",       Sao =Sao.ThienQuy ,        NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhucTinh },  }},
            {Sao.DauQuan ,          new SaoTuVi{Ten = "Đẩu Quân",        Sao =Sao.DauQuan ,         NguHanh =     new List<NguHanh>(){NguHanh.Hoa},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },  }},
            {Sao.ThienTai ,         new SaoTuVi{Ten = "Thiên Tài",       Sao =Sao.ThienTai ,        NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.HoTinh },  }},
            {Sao.ThienTho ,         new SaoTuVi{Ten = "Thiên Thọ",       Sao =Sao.ThienTho ,        NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.CatTinh },  }},
            {Sao.ThienLa ,          new SaoTuVi{Ten = "Thiên La",        Sao =Sao.ThienLa ,         NguHanh =     new List<NguHanh>(){NguHanh.Kim},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },  }},
            {Sao.DiaVong ,          new SaoTuVi{Ten = "Địa Võng",        Sao =Sao.DiaVong ,         NguHanh =     new List<NguHanh>(){NguHanh.Kim},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.AcTinh },  }},
            {Sao.ThienThuong ,      new SaoTuVi{Ten = "Thiên Thương",    Sao =Sao.ThienThuong ,     NguHanh =     new List<NguHanh>(){NguHanh.Tho},     LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.HungTinh },  }},
            {Sao.ThienSu ,          new SaoTuVi{Ten = "Thiên Sứ",        Sao =Sao.ThienSu ,         NguHanh =     new List<NguHanh>(){NguHanh.Thuy},    LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoXau, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.HungTinh },  }},

            {Sao.LuuThaiTue,        new SaoTuVi{Ten = "L.Thái Tuế",      Sao = Sao.LuuThaiTue,           LoaiSao = new List<LoaiSao>(){LoaiSao.Khac},  LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa},  LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.PhuTinh, LoaiDacTinh.HinhTinh },  } },
            {Sao.LuuTangMon,        new SaoTuVi{Ten = "L.Tang Môn",      Sao = Sao.LuuTangMon,           LoaiSao = new List<LoaiSao>(){LoaiSao.Khac},  LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Moc },  LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                        } },
            {Sao.LuuTuePha,         new SaoTuVi{Ten = "L.Tuế Phá",       Sao = Sao.LuuTuePha,            LoaiSao = new List<LoaiSao>(){LoaiSao.Khac},  LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Hoa},  LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                        } },
            {Sao.LuuThienHu,        new SaoTuVi{Ten = "L.Thiên Hư",      Sao = Sao.LuuThienHu,           LoaiSao = new List<LoaiSao>(){LoaiSao.Khac},  LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Thuy},  LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                        } },
            {Sao.LuuThienKhoc,      new SaoTuVi{Ten = "L.Thiên Khốc",    Sao = Sao.LuuThienKhoc,         LoaiSao = new List<LoaiSao>(){LoaiSao.Khac},  LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Kim},   LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                        } },
            {Sao.LuuDaLa,           new SaoTuVi{Ten = "L.Đà La",         Sao = Sao.LuuDaLa,              LoaiSao = new List<LoaiSao>(){LoaiSao.Khac},  LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Kim},   LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.SatTinh  },                       } },
            {Sao.LuuBachHo,         new SaoTuVi{Ten = "L.Bạch Hổ",       Sao = Sao.LuuBachHo,            LoaiSao = new List<LoaiSao>(){LoaiSao.Khac},  LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Kim },  LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.BaiTinh },                        } },
            {Sao.LuuKinhDuong,      new SaoTuVi{Ten = "L.Kình Dương",    Sao = Sao.LuuKinhDuong,         LoaiSao = new List<LoaiSao>(){LoaiSao.Khac }, LoaiViTri =LoaiViTri.SaoXau, NguHanh =new List<NguHanh>(){ NguHanh.Kim },  LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.HinhTinh ,LoaiDacTinh.HungTinh }, } },
            {Sao.LuuThienMa ,       new SaoTuVi{Ten = "L.Thiên Mã",      Sao = Sao.LuuThienMa ,          LoaiSao =  new List<LoaiSao>(){ LoaiSao.Khac},LoaiViTri =LoaiViTri.SaoTot, NguHanh =new List<NguHanh>(){ NguHanh.Hoa} ,  LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh},                         } },
            {Sao.LuuLocTon,         new SaoTuVi{Ten = "L.Lộc Tồn",       Sao = Sao.LuuLocTon,            LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac}, LoaiViTri =LoaiViTri.SaoTot, NguHanh =new List<NguHanh>(){ NguHanh.Tho}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh},                         } },
            {Sao.LuuNienVanTinh,    new SaoTuVi{Ten = "LN Văn Tinh",     Sao = Sao.LuuNienVanTinh,       LoaiSao =  new List<LoaiSao>(){LoaiSao.Khac}, LoaiViTri =LoaiViTri.SaoTot, NguHanh =new List<NguHanh>(){ NguHanh.Kim}, LoaiDacTinh = new List<LoaiDacTinh>(){  LoaiDacTinh.QuyTinh},                         } },

        };

        public static Dictionary<Sao, Dictionary<DiaChi, DoAnhHuong>> DIC_DoAnhHuong = new Dictionary<Sao, Dictionary<DiaChi, DoAnhHuong>>
        {
            #region Tử vi
            { Sao.TuVi, new Dictionary<DiaChi, DoAnhHuong>(){
                { DiaChi.Ty , DoAnhHuong.MieuDia}     ,
                { DiaChi.Ngo , DoAnhHuong.MieuDia }     ,
                { DiaChi.Dan , DoAnhHuong.MieuDia }     ,
                { DiaChi.Than , DoAnhHuong.MieuDia }    ,
                { DiaChi.Thin , DoAnhHuong.VuongDia}    ,
                { DiaChi.Tuat , DoAnhHuong.VuongDia }   ,
                { DiaChi.Suu , DoAnhHuong.DacDia}       ,
                { DiaChi.Mui , DoAnhHuong.DacDia }      ,
                { DiaChi.Hoi , DoAnhHuong.BinhHoa}      ,
                { DiaChi.Ti , DoAnhHuong.BinhHoa}       ,
                { DiaChi.Mao , DoAnhHuong.BinhHoa}      ,
                { DiaChi.Dau , DoAnhHuong.BinhHoa}
            }},

            #endregion
            #region Thiên Cơ
            { Sao.ThienCo, new Dictionary<DiaChi, DoAnhHuong>(){
                { DiaChi.Thin , DoAnhHuong.MieuDia}     ,
                { DiaChi.Tuat , DoAnhHuong.MieuDia }    ,
                { DiaChi.Mao , DoAnhHuong.MieuDia }     ,
                { DiaChi.Dau , DoAnhHuong.MieuDia }     ,
                { DiaChi.Ty , DoAnhHuong.VuongDia}      ,
                { DiaChi.Than , DoAnhHuong.VuongDia }   ,
                { DiaChi.Ti , DoAnhHuong.DacDia}        ,
                { DiaChi.Ngo , DoAnhHuong.DacDia }      ,
                { DiaChi.Suu , DoAnhHuong.DacDia }      ,
                { DiaChi.Mui , DoAnhHuong.DacDia }      ,
                { DiaChi.Dan , DoAnhHuong.HamDia}       ,
                { DiaChi.Hoi , DoAnhHuong.HamDia }
            } },

            #endregion
            #region Thái Dương
            { Sao.ThaiDuong, new Dictionary<DiaChi, DoAnhHuong>(){
                { DiaChi.Ty , DoAnhHuong.MieuDia}     ,
                { DiaChi.Ngo , DoAnhHuong.MieuDia }   ,
                { DiaChi.Dan , DoAnhHuong.VuongDia }  ,
                { DiaChi.Mao , DoAnhHuong.VuongDia }  ,
                { DiaChi.Thin , DoAnhHuong.VuongDia}  ,
                { DiaChi.Suu, DoAnhHuong.DacDia}      ,
                { DiaChi.Mui, DoAnhHuong.DacDia }     ,
                { DiaChi.Ti , DoAnhHuong.HamDia }     ,
                { DiaChi.Hoi , DoAnhHuong.HamDia }    ,
                { DiaChi.Tuat , DoAnhHuong.HamDia}    ,
                { DiaChi.Dau , DoAnhHuong.HamDia }    ,
                { DiaChi.Than , DoAnhHuong.HamDia }   ,
            } },
            #endregion
            #region Vũ Khúc
            { Sao.VuKhuc, new Dictionary<DiaChi, DoAnhHuong>(){
                { DiaChi.Thin, DoAnhHuong.MieuDia}   ,
                { DiaChi.Tuat , DoAnhHuong.MieuDia } ,
                { DiaChi.Suu , DoAnhHuong.MieuDia }  ,
                { DiaChi.Mui , DoAnhHuong.MieuDia }  ,
                { DiaChi.Dan , DoAnhHuong.VuongDia}  ,
                { DiaChi.Than, DoAnhHuong.VuongDia } ,
                { DiaChi.Ti, DoAnhHuong.VuongDia }   ,
                { DiaChi.Ngo , DoAnhHuong.VuongDia } ,
                { DiaChi.Mao , DoAnhHuong.DacDia }   ,
                { DiaChi.Dau , DoAnhHuong.DacDia}    ,
                { DiaChi.Ty , DoAnhHuong.HamDia }    ,
                { DiaChi.Hoi , DoAnhHuong.HamDia }   ,
            } },
            #endregion
            #region Thiên Đồng
            { Sao.ThienDong, new Dictionary<DiaChi, DoAnhHuong>(){
                { DiaChi.Ti   ,DoAnhHuong.VuongDia}  ,
                { DiaChi.Suu  ,DoAnhHuong.HamDia  }  ,
                { DiaChi.Dan  ,DoAnhHuong.MieuDia  } ,
                { DiaChi.Mao  ,DoAnhHuong.DacDia  }  ,
                { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                { DiaChi.Ty   ,DoAnhHuong.DacDia  }  ,
                { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                { DiaChi.Mui  ,DoAnhHuong.HamDia  }  ,
                { DiaChi.Than ,DoAnhHuong.MieuDia  } ,
                { DiaChi.Dau  ,DoAnhHuong.HamDia  }  ,
                { DiaChi.Tuat ,DoAnhHuong.HamDia  }  ,
                { DiaChi.Hoi  ,DoAnhHuong.DacDia  }  ,
            } },

            #endregion
            #region Liêm Trinh
            { Sao.LiemTrinh, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }    ,
                 { DiaChi.Dan  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia}     ,
                 { DiaChi.Thin ,DoAnhHuong.MieuDia}    ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Ngo  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}     ,
                 { DiaChi.Than ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Tuat ,DoAnhHuong.MieuDia }   ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia }    ,
            } },
            #endregion
            #region Thiên Phủ
            { Sao.ThienPhu, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.MieuDia }    ,
                 { DiaChi.Suu  ,DoAnhHuong.BinhHoa }    ,
                 { DiaChi.Dan  ,DoAnhHuong.MieuDia }    ,
                 { DiaChi.Mao  ,DoAnhHuong.BinhHoa }    ,
                 { DiaChi.Thin ,DoAnhHuong.VuongDia}    ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia}      ,
                 { DiaChi.Ngo  ,DoAnhHuong.MieuDia }    ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia }     ,
                 { DiaChi.Than ,DoAnhHuong.MieuDia }    ,
                 { DiaChi.Dau  ,DoAnhHuong.BinhHoa}     ,
                 { DiaChi.Tuat ,DoAnhHuong.VuongDia }   ,
                 { DiaChi.Hoi  ,DoAnhHuong.DacDia }     ,
            } },
            #endregion
            #region Thái Âm
            { Sao.ThaiAm, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.VuongDia } ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia}    ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}    ,
                 { DiaChi.Than ,DoAnhHuong.VuongDia}  ,
                 { DiaChi.Dau  ,DoAnhHuong.MieuDia}   ,
                 { DiaChi.Tuat ,DoAnhHuong.MieuDia }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.MieuDia }  ,
            } },
            #endregion
            #region Tham Lang
            { Sao.ThamLang, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia}    ,
                 { DiaChi.Suu  ,DoAnhHuong.MieuDia}   ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia}    ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Thin ,DoAnhHuong.VuongDia}  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Mui  ,DoAnhHuong.MieuDia }  ,
                 { DiaChi.Than ,DoAnhHuong.DacDia }   ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia }   ,
                 { DiaChi.Tuat ,DoAnhHuong.VuongDia } ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia }   ,
            } },
     
            #endregion
            #region Cự môn
            { Sao.CuMon, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.VuongDia}   ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia}     ,
                 { DiaChi.Dan  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Mao  ,DoAnhHuong.MieuDia}    ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Ngo  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Than ,DoAnhHuong.DacDia }    ,
                 { DiaChi.Dau  ,DoAnhHuong.MieuDia}    ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Hoi  ,DoAnhHuong.DacDia}     ,
            } },
            #endregion
            #region Thiên Tướng 
            { Sao.ThienTuong, new Dictionary<DiaChi, DoAnhHuong>(){
                { DiaChi.Ti   ,DoAnhHuong.VuongDia}    ,
                { DiaChi.Suu  ,DoAnhHuong.DacDia}      ,
                { DiaChi.Dan  ,DoAnhHuong.MieuDia }    ,
                { DiaChi.Mao  ,DoAnhHuong.HamDia}      ,
                { DiaChi.Thin ,DoAnhHuong.VuongDia }   ,
                { DiaChi.Ty   ,DoAnhHuong.DacDia }     ,
                { DiaChi.Ngo  ,DoAnhHuong.VuongDia }   ,
                { DiaChi.Mui  ,DoAnhHuong.DacDia }     ,
                { DiaChi.Than ,DoAnhHuong.MieuDia }    ,
                { DiaChi.Dau  ,DoAnhHuong.HamDia}      ,
                { DiaChi.Tuat ,DoAnhHuong.VuongDia}    ,
                { DiaChi.Hoi  ,DoAnhHuong.DacDia }     ,
            } },
            #endregion
            #region Thiên Lương
            { Sao.ThienLuong, new Dictionary<DiaChi, DoAnhHuong>(){

                { DiaChi.Ti   ,DoAnhHuong.VuongDia} ,
                { DiaChi.Suu  ,DoAnhHuong.DacDia}   ,
                { DiaChi.Dan  ,DoAnhHuong.VuongDia },
                { DiaChi.Mao  ,DoAnhHuong.VuongDia },
                { DiaChi.Thin ,DoAnhHuong.MieuDia } ,
                { DiaChi.Ty   ,DoAnhHuong.HamDia}   ,
                { DiaChi.Ngo  ,DoAnhHuong.MieuDia}  ,
                { DiaChi.Mui  ,DoAnhHuong.DacDia }  ,
                { DiaChi.Than ,DoAnhHuong.VuongDia },
                { DiaChi.Dau  ,DoAnhHuong.DacDia }  ,
                { DiaChi.Tuat ,DoAnhHuong.MieuDia } ,
                { DiaChi.Hoi  ,DoAnhHuong.DacDia }  ,
            } },
            #endregion
            #region Thất sát
            { Sao.ThatSat , new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.MieuDia }   ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia}     ,
                 { DiaChi.Dan  ,DoAnhHuong.MieuDia }   ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia}     ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Ty   ,DoAnhHuong.VuongDia}   ,
                 { DiaChi.Ngo  ,DoAnhHuong.MieuDia }   ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia }    ,
                 { DiaChi.Than ,DoAnhHuong.MieuDia }   ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia }    ,
                 { DiaChi.Hoi  ,DoAnhHuong.VuongDia }  ,
            } },
            #endregion
            #region Phá Quân
            { Sao.PhaQuan, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.MieuDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.MieuDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },

            #endregion

            #region Tang Môn
            { Sao.TangMon, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Dan   ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Than  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ti ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Suu   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Ngo ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Bạch Hổ
            { Sao.BachHo, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Dan   ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Than  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ti ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Suu   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Ngo ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Lộc Tồn
                { Sao.LocTon, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.MieuDia  }  ,
                 { DiaChi.Dan  ,DoAnhHuong.MieuDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.MieuDia   }  ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.MieuDia  }  ,
                 { DiaChi.Than ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.DacDia   }  ,
            } },

            #endregion
            #region Kình Dương
            { Sao.KinhDuong, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Đà La
            { Sao.DaLa, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Địa Không
            { Sao.DiaKhong, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia}  ,
                 { DiaChi.Than ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.DacDia   }  ,
            } },
            #endregion
            #region Địa Kiếp
            { Sao.DiaKiep, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia}  ,
                 { DiaChi.Than ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.DacDia   }  ,
            } },
            #endregion
            #region Hỏa Tinh
            { Sao.HoaTinh, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region LinhTinh
            { Sao.LinhTinh, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Thiên Khốc
            { Sao.ThienKhoc, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Thiên Hư
            { Sao.ThienHu, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
             #region Văn Xương
            { Sao.VanXuong, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.DacDia   }  ,
            } },
            #endregion
            #region Văn Khúc
            { Sao.VanKhuc, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.DacDia   }  ,
            } },
            #endregion
            #region Tiểu hao
            { Sao.TieuHao, new Dictionary<DiaChi, DoAnhHuong>(){
                { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia}  ,
                 { DiaChi.Than ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Đại Hao
            { Sao.DaiHao, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia}  ,
                 { DiaChi.Than ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Thiên Mã
            { Sao.ThienMa, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.BinhHoa  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.BinhHoa }  ,
                 { DiaChi.Dan  ,DoAnhHuong.MieuDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Thin ,DoAnhHuong.BinhHoa  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.MieuDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.BinhHoa  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.BinhHoa}  ,
                 { DiaChi.Than ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion
            #region Thiên Diêu
            { Sao.ThienDieu, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.HamDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.HamDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion 

            #region Hóa kỵ
            { Sao.HoaKy, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.DacDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.DacDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.DacDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.DacDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.HamDia   }  ,
            } },
            #endregion

            #region Hóa Lộc
            { Sao.HoaLoc, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.VuongDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.VuongDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.BinhHoa   }  ,
            } },
            #endregion
             #region Hóa khoa
            { Sao.HoaKhoa, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.VuongDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.VuongDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.BinhHoa   }  ,
            } },
            #endregion
             #region Hóa quyền
            { Sao.HoaQuyen, new Dictionary<DiaChi, DoAnhHuong>(){
                 { DiaChi.Ti   ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Suu  ,DoAnhHuong.VuongDia }  ,
                 { DiaChi.Dan  ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Mao  ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Thin ,DoAnhHuong.VuongDia  }  ,
                 { DiaChi.Ty   ,DoAnhHuong.BinhHoa   }  ,
                 { DiaChi.Ngo  ,DoAnhHuong.HamDia  }  ,
                 { DiaChi.Mui  ,DoAnhHuong.VuongDia}  ,
                 { DiaChi.Than ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Dau  ,DoAnhHuong.HamDia   }  ,
                 { DiaChi.Tuat ,DoAnhHuong.VuongDia   }  ,
                 { DiaChi.Hoi  ,DoAnhHuong.BinhHoa   }  ,
            } },
            #endregion
        };

        public static Dictionary<Sao, bool> DIC_SaoInDam = new Dictionary<Sao, bool>() {
            {Sao.ThienViet, true },
            {Sao.HoaLoc, true },
            {Sao.HoaTinh, true },
            {Sao.VanKhuc, true },
            {Sao.VanXuong, true },
            {Sao.HoaKhoa, true },
            {Sao.HoaKy, true },
            {Sao.ThienHinh, true },
            {Sao.HongLoan, true },
            {Sao.DiaKhong, true },
            {Sao.DaLa, true },
            {Sao.ThienKhong, true },
            {Sao.CoThan, true },
            {Sao.LocTon, true },
            {Sao.HoaQuyen, true },
            {Sao.KinhDuong, true },
            {Sao.ThienDieu, true },
            {Sao.HuuBat, true },
            {Sao.DaoHoa, true },
            {Sao.LinhTinh, true },
            {Sao.DiaKiep, true },
            {Sao.ThienKhoi, true },
            {Sao.TaPhu, true },
            {Sao.ThienHy, true },
            {Sao.QuaTu, true },
            {Sao.TuVi       , true },
            {Sao.ThienCo    , true },
            {Sao.ThaiDuong  , true },
            {Sao.VuKhuc     , true },
            {Sao.ThienDong  , true },
            {Sao.LiemTrinh  , true },
            {Sao.ThienPhu   , true },
            {Sao.ThaiAm     , true },
            {Sao.ThamLang   , true },
            {Sao.CuMon      , true },
            {Sao.ThienTuong , true },
            {Sao.ThienLuong , true },
            {Sao.ThatSat    , true },
            {Sao.PhaQuan    , true },

        };
    }
    public enum Sao
    {
        TuVi = 0,
        ThienCo = 1,
        ThaiDuong = 2,
        VuKhuc = 3,
        ThienDong = 4,
        LiemTrinh = 5,
        ThienPhu = 6,
        ThaiAm = 7,
        ThamLang = 8,
        CuMon = 9,
        ThienTuong = 10,
        ThienLuong = 11,
        ThatSat = 12,
        PhaQuan = 13,

        KinhDuong = 14,
        DaLa = 15,
        DiaKhong = 16,
        DiaKiep = 17,
        LinhTinh = 18,
        HoaTinh = 19,

        TieuHao = 20,
        DaiHao = 21,
        TangMon = 22,
        BachHo = 23,
        ThienKhoc = 24,
        ThienHu = 25,
        Tuan = 26,
        Triet = 27,
        HoaKhoa = 28,
        HoaQuyen = 29,
        HoaLoc = 30,
        HoaKy = 31,
        LongTri = 32,
        PhuongCac = 33,
        HoaCai = 34,
        ThaiTue = 35,
        ThieuDuong = 36,
        ThieuAm = 37,
        QuanPhu = 38,
        TuPhu = 39,
        TuePha = 40,
        LongDuc = 41,
        PhucDuc = 42,
        DieuKhach = 43,
        TrucPhu = 44,
        LocTon = 45,
        BacSi = 46,
        VanKhuc = 47,
        VanXuong = 48,
        LucSi = 49,
        ThanhLong = 50,
        TuongQuan = 51,
        PhucBinh,
        BenhPhu,
        HiThan,
        PhiLiem,
        TauThu,
        QuanPhuR,
        QuocAn,
        DuongPhu,
        ThienKhoi,
        ThienViet,
        ThienQuan,
        ThienPhuc,
        LuuHa,
        ThienTru,

        GiaiThan,
        ThienDuc,
        NguyetDuc,
        HongLoan,
        ThienHy,
        CoThan,
        QuaTu,
        DaoHoa,
        ThienMa,
        KiepSat,
        PhaToai,
        ThienKhong,

        TaPhu,
        HuuBat,
        ThienHinh,
        ThienDieu,
        ThienY,
        ThienGiai,
        DiaGiai,
        ThaiPhu,
        PhongCao,
        TamThai,
        BatToa,
        AnQuang,
        ThienQuy,
        DauQuan,
        ThienTai,
        ThienTho,
        ThienLa,
        DiaVong,
        ThienThuong,
        ThienSu,

        LuuThaiTue,
        LuuTangMon,
        LuuTuePha,
        LuuThienHu,
        LuuThienKhoc,
        LuuDaLa,
        LuuBachHo,
        LuuKinhDuong,
        LuuThienMa,
        LuuLocTon,
        LuuNienVanTinh,
    }

    public class SaoTuVi
    {
        public Sao Sao { get; set; }
        public string Ten { get; set; }
        public DiaChi CungToaThu { get; set; }
        public List<NguHanh> NguHanh { get; set; }
        public AmDuong AmDuong { get; set; }
        public DoAnhHuong? DoAnhHuong { get; set; } = null;
        public LoaiViTri LoaiViTri { get; set; }
        public List<LoaiSao> LoaiSao { get; set; }
        public List<LoaiDacTinh> LoaiDacTinh { get; set; }
        public PhuongVi PhuongVi { get; set; }
        //public List<DacTinh> DacTinh { get; set; }
    }
    public enum AmDuongNamNu
    {
        DuongNam = 0,
        AmNu = 1,
        AmNam = 2,
        DuongNu = 3
    }
    public class LaSo
    {

        public string Ten { get; set; }
        public AmDuong AmDuong { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public BanMenh BanMenh { get; set; }
        public NguHanh NguHanhMenh { get; set; }
        public Cuc Cuc { get; set; }
        public Sao ChuMenh { get; set; }
        public Sao ChuThan { get; set; }
        public AmDuongNamNu AmDuongNamNu { get; set; }
        public List<CungLaSo> CungLaSo { get; set; }

        public ThienCan ThienCan_NamSinh { get; set; }
        public DiaChi DiaChi_NamSinh { get; set; }

        public ThienCan ThienCan_ThangSinh { get; set; }
        public DiaChi DiaChi_ThangSinh { get; set; }

        public ThienCan ThienCan_NgaySinh { get; set; }
        public DiaChi DiaChi_NgaySinh { get; set; }

        public ThienCan ThienCan_GioSinh { get; set; }
        public DiaChi DiaChi_GioSinh { get; set; }

        public int ThangSinh_AmLich { get; set; }
        public int NgaySinh_AmLich { get; set; }

        public int Tuoi { get; set; }
        public int NamXemHan { get; set; }

        public ThienCan ThienCan_NamXem { get; set; }
        public DiaChi DiaChi_NamXem { get; set; }
        public int GioSinh { get; set; }
        public int Phut { get; set; }
        public DateTime NgaySinh_DuongLich { get; set; }
        public CucMenh CucMenh { get; set; }
        public ThuanNghichLy ThuanNghichLy { get; set; }
    }
    public class CungLaSo
    {
        public AmDuong AmDuong { get; set; }
        public NguHanh NguHanh { get; set; }
        public ThienCan ThienCan { get; set; }
        public DiaChi DiaChi { get; set; }
        public DiaChi TieuHanNam { get; set; }
        public TrangSinh TrangSinh { get; set; }
        public List<Cung> Cung { get; set; }
        public NguyetHan NguyetHan { get; set; }
        public List<SaoTuVi> SaoTuVi { get; set; }
        public int DaiVanNam { get; set; } = 1;
    }
    public enum Cuc
    {
        ThuyNhiCuc = 0,
        MocTamCuc = 1,
        KimTuCuc = 2,
        ThoNguCuc = 3,
        HoaLucCuc = 4
    }
    public enum BanMenh
    {
        HaiTrungKim = 0,
        LoTrungHoa = 1,
        DaiLamMoc = 2,
        LoBangTho = 3,
        KiemPhongKim = 4,
        SonDauHoa = 5,
        GianHaThuy = 6,
        ThanhDauTho = 7,
        BachLapKim = 8,
        DuongLieuMoc = 9,
        TuyenTrungThuy = 10,
        OcThuongTho = 11,
        TichLichHoa = 12,
        TungBachMoc = 13,
        TrangLuuThuy = 14,
        SaTrungKim = 15,
        SonHaHoa = 16,
        BinhDiaMoc = 17,
        BichThuongTho = 18,
        KimBachKim = 19,
        PhuDangHoa = 20,
        ThienThuongThuy = 21,
        DaiTrachTho = 22,
        XuyenThoaKim = 23,
        TangKhoMoc = 24,
        DaiKheThuy = 25,
        SaTrungTho = 26,
        ThienThuongToa = 27,
        ThachLuuMoc = 28,
        DaiHaiThuy = 29
    }

    public enum GioiTinh
    {
        Nu = 0,
        Nam = 1
    }

    public enum NguyetHan
    {
        Thang1 = 0,
        Thang2 = 1,
        Thang3 = 2,
        Thang4 = 3,
        Thang5 = 4,
        Thang6 = 5,
        Thang7 = 6,
        Thang8 = 7,
        Thang9 = 8,
        Thang10 = 9,
        Thang11 = 10,
        Thang12 = 11,
    }


    public enum LoaiDacTinh
    {
        QuyTinh = 0, //Quý tinh
        DeTinh = 1, //đế tinh
        ThienTinh = 2, //thiện tinh
        TaiTinh = 3,//tài tinh
        QuyenTinh = 4,//Quyền tinh
        PhucTinh = 5,//Phúc Tinh
        DaoHoaTinh = 6,//Đào hoa tinh
        TuTinh = 7,//Tù Tinh
        PhuTinh = 8,//Phú Tinh
        HungTinh = 9,
        DamTinh = 10,//Dâm Tinh
        AmTinh = 11, //Ám Tinh
        AnTinh = 12, // Ấn Tinh
        ThoTinh = 13,//Thọ Tinh
        DungTinh = 14,//Dũng Tinh
        HaoTinh = 15,
        SatTinh = 16,
        HinhTinh = 17,
        BaiTinh = 18,
        VanTinh = 19,
        AcTinh = 20,
        CatTinh = 21,
        AmThuc = 22,
        HoTinh = 23,
        TuyTinh = 24
    }
    public enum PhuongVi
    {
        BacDauTinh = 0,
        NamDauTinh = 1,
        CaNamLanBacDauTinh = 2,
        PhaVoChiaRoi = 3
    }
    public enum LoaiSao
    {
        ChinhTinh = 0,
        LucSatTinh = 1,
        LucBaiTinh = 2,
        TuanTriet = 3,
        TuHoa = 4,
        TuLinh = 5,
        Khac = 6,
        ThaiTue,
        XuongKhuc,
        VongLocTon,
        SongHao,
        SaoLuu
    }

    public enum Cung
    {
        Menh = 0,
        PhuMau,
        PhucDuc,
        DienTrach,
        QuanLoc,
        NoBoc,
        ThienDi,
        TatAch,
        TaiBach,
        TuTuc,
        PhuThe,
        HuynhDe,
        Than

    }

    public enum LoaiViTri
    {
        ChinhDieu = 0,
        SaoTot = 1,
        SaoXau = 2,
        TuanTriet = 3
    }

    public enum TrangSinh
    {
        TruongSinh = 0,
        Duong,
        Thai,
        Tuyet,
        Mo,
        Tu,
        Benh,
        Suy,
        DeVuong,
        LamQuan,
        QuanDoi,
        MocDuc,
    }

    public enum DoAnhHuong
    {
        HamDia = 0,
        BinhHoa = 1,
        DacDia = 2,
        VuongDia = 3,
        MieuDia = 4
    }

    public enum NguHanh
    {
        Kim = 0,
        Moc = 1,
        Thuy = 2,
        Hoa = 3,
        Tho = 4
    }
    public enum AmDuong
    {
        Duong = 0,
        Am = 1
    }

    public enum DiaChi
    {
        Ti = 0,
        Suu = 1,
        Dan = 2,
        Mao = 3,
        Thin = 4,
        Ty = 5,
        Ngo = 6,
        Mui = 7,
        Than = 8,
        Dau = 9,
        Tuat = 10,
        Hoi = 11
    }
    public enum ThienCan
    {
        Giap = 0,
        At = 1,
        Binh = 2,
        Dinh = 3,
        Mau = 4,
        Ky = 5,
        Canh = 6,
        Tan = 7,
        Nham = 8,
        Quy = 9
    }
    public enum ThuanNghichLy
    {
        AmDuongThuanLy = 0,
        AmDuongNghichLy = 1
    }
    public enum CucMenh
    {
        CucSinhMenh = 0,
        MenhSinhCuc,
        MenhCucBinhHoa,
        MenhKhacCuc,
        CucKhacMenh
    }

}
