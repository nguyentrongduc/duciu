﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyQuanCafe.GUI
{
    public partial class fBaoCaoChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public fBaoCaoChiTiet()
        {
            InitializeComponent();
        }

        QLCaFeDataContext db = new QLCaFeDataContext();
        private void fThongKeDoanhThu_Load(object sender, EventArgs e)
        {

        }
        private void dulieu()
        {
            //var T1 = db.TKDoanhThus.Where(tkdt => tkdt.NgayLap >= DateTime.Parse("2017/01/12") && tkdt.NgayLap <= DateTime.Parse("2017/12/12")).Sum(tkdt => tkdt.ThanhTien);
            //XtraMessageBox.Show(T1.ToString());
            var TKDT = (from tkdt in db.TKDoanhThus
                        where tkdt.NgayLap >= DateTime.Parse(dtpReportTuNgay.Text) && tkdt.NgayLap <= DateTime.Parse(dtpReportToiNgay.Text)
                        select tkdt).ToList();
            var count = TKDT.Count();
            if (count == 0)
            {
                XtraMessageBox.Show("Không có dữ liệu trong khoảng thời gian vừa chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReportCT.Enabled = false;
            }
            else
            {
                btnReportCT.Enabled = true;
            }
        }

        private void btnReportCT_Click(object sender, EventArgs e)
        {

            if (dtpReportTuNgay.Text != "")
            {
                if (dtpReportToiNgay.Text != "")
                {
                    dulieu();
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa nhập đến ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập từ ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}