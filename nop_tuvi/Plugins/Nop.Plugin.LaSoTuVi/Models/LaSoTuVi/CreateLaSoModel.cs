using Nop.Plugin.LaSoTuVi.TuViSerives.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nop.Plugin.LaSoTuVi.Models.LaSoTuVi
{
    public class CreateLaSoAmLichModel
    {
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }

        public ThienCan ThienCanNam { get; set; }
        public DiaChi DiaChiNam { get; set; }

        public int Thang { get; set; }
        public int Ngay { get; set; }
        public DiaChi Gio { get; set; }

        public ThienCan ThienCanNamXem { get; set; }
        public DiaChi DiaChiNamXem { get; set; }

    }
    public class CreateLaSoDuongLichModel
    {
        [Required]
        public string Ten { get; set; }
        public bool GioiTinh { get; set; } = true;

        public int Nam { get; set; } = DateTime.Now.Year;
        public int Thang { get; set; } = 1;
        public int Ngay { get; set; } = 1;
        public int Gio { get; set; } = 0;
        public int Phut { get; set; } = 0;

        public int NamXemHan { get; set; } = DateTime.Now.Year;
    }
}