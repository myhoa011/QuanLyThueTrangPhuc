﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using BAITAPCUOIKY.Class;

namespace QuanLyThueTrangPhuc.Model
{
    class DangNhap
    {
        ConnectFile FileXML = new ConnectFile();
        public bool kiemtraTTDN(string duongdan, string MaNhanVien, string MatKhau)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = FileXML.HienThi(duongdan);
                dt.DefaultView.RowFilter = "MaNV ='" + MaNhanVien + "' AND MatKhau ='" + MatKhau + "'";
                if (dt.DefaultView.Count > 0)
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        internal void DoiMatKhau(string tenDNMain, string matKhauMoi)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\TaiKhoan.xml");
            XmlNode node1 = doc1.SelectSingleNode("//TaiKhoan[MaNV = '" + tenDNMain + "']");
            if (node1 != null)
            {
                node1.ChildNodes[1].InnerText = matKhauMoi;
                doc1.Save(Application.StartupPath + "\\TaiKhoan.xml");
            }
        }
    }
}
