CREATE DATABASE BanHang

Use BanHang

CREATE TABLE tblLoaiHang(
    iIDLoai INT PRIMARY KEY,
    sHang NVARCHAR(255),
    sDang NVARCHAR(255) 
);

CREATE TABLE tblPhanQuyen(
    iIDNguoiDung INT PRIMARY KEY,
	sTenNguoiDung NVARCHAR(255),
	iCapDo INT,
	sChucVu NVARCHAR(30)
);

CREATE TABLE tblNguoiDung(
    iIDNguoiDung INT PRIMARY KEY,
	sTenNguoiDung NVARCHAR(255),
	sTenDangNhap NVARCHAR(20),
	sMatKhau NVARCHAR(14),
	sSoDienThoai NVARCHAR(10),
	sDiaChi NVARCHAR(255),
	FOREIGN KEY (iIDNguoiDung) REFERENCES tblPhanQuyen(iIDNguoiDung)
);

CREATE TABLE tblHang(
    iIDHang INT PRIMARY KEY,
	iIDLoai INT, 
    iIDNguoiDung INT,
	FOREIGN KEY (iIDNguoiDung) REFERENCES tblNguoiDung(iIDNguoiDung),
	FOREIGN KEY (iIDLoai) REFERENCES tblLoaiHang(iIDLoai)
);

CREATE TABLE tblCTHang(
    iIDHang INT PRIMARY KEY,
	sTenHang NVARCHAR(255),
	fGiaTien FLOAT,
	iSoLuongCon INT,
	FOREIGN KEY (iIDHang) REFERENCES tblHang(iIDHang)
);

CREATE TABLE tblAnh(
	iIDHang INT PRIMARY KEY,
	iIDAnh INT,
	FOREIGN KEY (iIDHang) REFERENCES tblCTHang(iIDHang)

);

CREATE TABLE tblGiamGia(
    iIDMaGiam INT PRIMARY KEY,
	fGiaGiam FLOAT,
	iIDHang INT,
	FOREIGN KEY (iIDHang) REFERENCES tblCTHang(iIDHang)
);

CREATE TABLE tblGioHang(
    iIDNguoiDung INT PRIMARY KEY,
	iSoLuongHang INT,
	FOREIGN KEY (iIDNguoiDung) REFERENCES tblNguoiDung(iIDNguoiDung)
);



CREATE TABLE tblTrangThaiHang(
	iIDNguoiDung INT  PRIMARY KEY, 
	iIDHang INT,
    sthanhToan NVARCHAR(255),
    iIDMaGiam INT,
	FOREIGN KEY (iIDNguoiDung) REFERENCES tblGioHang(iIDNguoiDung),
	FOREIGN KEY (iIDHang) REFERENCES tblHang(iIDHang),
	FOREIGN KEY (iIDMaGiam) REFERENCES tblGiamGia(iIDMaGiam)
);

CREATE TABLE tblDanhGia(
    iIDDanhGia INT PRIMARY KEY,
	iSoSao INT,
	sDanhGia NVARCHAR(255),
	dThoiGian DATETIME,
	iIDHang INT,
	iIDNguoiDung INT,
	FOREIGN KEY (iIDHang) REFERENCES tblHang(iIDHang),
	FOREIGN KEY (iIDNguoiDung) REFERENCES tblNguoiDung(iIDNguoiDung)
);


