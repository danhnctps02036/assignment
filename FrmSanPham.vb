Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class frmSanPham
    Dim db As New DataTable
    Dim chuoiketnoi As String = "server=DANHNGUYEN;database=QL_DT;trusted_connection=false;uid=sa;pwd=123456"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        reset()
    End Sub
    Private Sub LoadData()
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        conn.Open()
        Dim refesh As SqlDataAdapter = New SqlDataAdapter("select MaSP as 'Mã SP' ,MaLSP as 'Mã LSP', TenSP as 'Tên SP', NoiDung as 'Nội Dung', NgayDang as 'Ngày Đăng', TrangThai as 'Trạng Thái' from SANPHAM", conn)
        db.Clear()
        refesh.Fill(db)
        DataGridView1.DataSource = db.DefaultView
        conn.Close()
    End Sub
    Private Sub reset()
        txtMaSP.Text = ""
        txtMaLSP.Text = ""
        txtTenSP.Text = ""
        txtNoiDung.Text = ""
        txtNgayDang.Text = ""
        txtTrangThai.Text = ""
        txtMaSP.Focus()
    End Sub
    Private Sub frmSanPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If txtMaSP.Text = "" Then
            MessageBox.Show("Chua nhap mã sản phẩm")
            txtMaSP.Focus()
        ElseIf txtMaLSP.Text = "" Then
            MessageBox.Show("Chua nhap mã loại sản phẩm")
            txtMaLSP.Focus()
        ElseIf txtTenSP.Text = "" Then
            MessageBox.Show("Chua nhap tên sản phẩm")
            txtTenSP.Focus()
        ElseIf txtNoiDung.Text = "" Then
            MessageBox.Show("Chua nhap nội dung")
            txtNoiDung.Focus()
        ElseIf txtNgayDang.Text = "" Then
            MessageBox.Show("Chua nhap ngày đăng")
            txtNgayDang.Focus()
        ElseIf txtTrangThai.Text = "" Then
            MessageBox.Show("Chua nhap trạng thái")
            txtTrangThai.Focus()
        Else
            Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
            Dim query As String = "insert into SANPHAM values(@MASP,@MALSP,@TENSP,@NOIDUNG,@NGAYDANG,@TRANGTHAI)"
            Dim save As SqlCommand = New SqlCommand(query, conn)
            conn.Open()
            save.Parameters.AddWithValue("@MASP", txtMaSP.Text)
            save.Parameters.AddWithValue("@MALSP", txtMaLSP.Text)
            save.Parameters.AddWithValue("@TENSP", txtTenSP.Text)
            save.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Text)
            save.Parameters.AddWithValue("@NGAYDANG", txtNgayDang.Text)
            save.Parameters.AddWithValue("@TRANGTHAI", txtTrangThai.Text)
            save.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Lưu thành công")
            LoadData()
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If txtMaSP.Text = "" Then
            MessageBox.Show("Nhap MaSP cần xóa")
            txtMaSP.Focus()
        Else
            Dim delquery As String = "delete from SANPHAM where MaSP=@MASP"
            Dim delete As SqlCommand = New SqlCommand(delquery, conn)
            Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resulft = Windows.Forms.DialogResult.Yes Then
                conn.Open()
                delete.Parameters.AddWithValue("@MASP", txtMaSP.Text)
                delete.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Xóa thành công")
                LoadData()
            End If
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If btnSua.Text = "Sửa" Then
            txtMaSP.ReadOnly = True
            btnSua.Text = "Update"
            txtTenSP.Focus()
        ElseIf btnSua.Text = "Update" Then
            Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
            Dim query As String = "update SANPHAM set MaLSP=@MALSP, TenSP=@TENSP, NoiDung=@NOIDUNG, NgayDang=@NGAYDANG, TrangThai=@TRANGTHAI where MaSP=@MASP"
            Dim save As SqlCommand = New SqlCommand(query, conn)
            conn.Open()
            save.Parameters.AddWithValue("@MASP", txtMaSP.Text)
            save.Parameters.AddWithValue("@MALSP", txtMaLSP.Text)
            save.Parameters.AddWithValue("@TENSP", txtTenSP.Text)
            save.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Text)
            save.Parameters.AddWithValue("@NGAYDANG", txtNgayDang.Text)
            save.Parameters.AddWithValue("@TRANGTHAI", txtTrangThai.Text)
            save.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Update thành công")
            txtMaSP.ReadOnly = False
            btnSua.Text = "Sửa"
            LoadData()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim click As Integer = DataGridView1.CurrentCell.RowIndex
        txtMaSP.Text = DataGridView1.Item(0, click).Value
        txtMaLSP.Text = DataGridView1.Item(1, click).Value
        txtTenSP.Text = DataGridView1.Item(2, click).Value
        txtNoiDung.Text = DataGridView1.Item(3, click).Value
        txtNgayDang.Text = DataGridView1.Item(4, click).Value
        txtTrangThai.Text = DataGridView1.Item(5, click).Value
    End Sub

    Private Sub btnĐóng_Click(sender As Object, e As EventArgs) Handles btnĐóng.Click
        Me.Close()
    End Sub
End Class