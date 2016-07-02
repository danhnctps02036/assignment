Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class frmKhachHang
    Dim db As New DataTable
    Dim chuoiketnoi As String = "server=DANHNGUYEN;database=QL_DT;trusted_connection=false;uid=sa;pwd=123456"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        reset()
    End Sub
    Private Sub LoadData()
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        conn.Open()
        Dim refesh As SqlDataAdapter = New SqlDataAdapter("select MaKH as 'Mã KH' ,TenKH as 'Tên KH', NgaySinh as 'Ngày Sinh', DiaChi as 'Địa Chỉ', SDT as 'Số ĐT' from KHACHHANG", conn)
        db.Clear()
        refesh.Fill(db)
        DataGridView1.DataSource = db.DefaultView
        conn.Close()
    End Sub
    Private Sub reset()
        txtMaKH.Text = ""
        txtTenKH.Text = ""
        txtNgaySinh.Text = ""
        txtDiaChi.Text = ""
        txtSDT.Text = ""
        txtMaKH.Focus()
    End Sub
    Private Sub frmSanPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If txtMaKH.Text = "" Then
            MessageBox.Show("Chua nhap mã khách hàng")
            txtMaKH.Focus()
        ElseIf txtTenKH.Text = "" Then
            MessageBox.Show("Chua nhap Tên khách hàng")
            txtTenKH.Focus()
        ElseIf txtNgaySinh.Text = "" Then
            MessageBox.Show("Chua nhap ngày sinh")
            txtNgaySinh.Focus()
        ElseIf txtDiaChi.Text = "" Then
            MessageBox.Show("Chua nhap địa chỉ")
            txtDiaChi.Focus()
        ElseIf txtSDT.Text = "" Then
            MessageBox.Show("Chua nhap số điện thoại")
            txtSDT.Focus()
        Else
            Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
            Dim query As String = "insert into KHACHHANG values(@MAKH,@TENKH,@NGAYSINH,@DIACHI,@SDT)"
            Dim save As SqlCommand = New SqlCommand(query, conn)
            conn.Open()
            save.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
            save.Parameters.AddWithValue("@TENKH", txtTenKH.Text)
            save.Parameters.AddWithValue("@NGAYSINH", txtNgaySinh.Text)
            save.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text)
            save.Parameters.AddWithValue("@SDT", txtSDT.Text)
            save.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Lưu thành công")
            LoadData()
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If txtMaKH.Text = "" Then
            MessageBox.Show("Nhap MaSP cần xóa")
            txtTenKH.Focus()
        Else
            Dim delquery As String = "delete from KHACHHANG where MaKH=@MAKH"
            Dim delete As SqlCommand = New SqlCommand(delquery, conn)
            Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resulft = Windows.Forms.DialogResult.Yes Then
                conn.Open()
                delete.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
                delete.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Xóa thành công")
                LoadData()
            End If
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If btnSua.Text = "Sửa" Then
            txtMaKH.ReadOnly = True
            btnSua.Text = "Update"
            txtTenKH.Focus()
        ElseIf btnSua.Text = "Update" Then
            Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
            Dim query As String = "update KHACHHANG set TenKH=@TENKH,NgaySinh=@NgaySinh,  DiaChi=@DIACHI , SDT=@SDT where MaKH=@MAKH"
            Dim save As SqlCommand = New SqlCommand(query, conn)
            conn.Open()
            save.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
            save.Parameters.AddWithValue("@TENKH", txtTenKH.Text)
            save.Parameters.AddWithValue("@NGAYSINH", txtNgaySinh.Text)
            save.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text)
            save.Parameters.AddWithValue("@SDT", txtSDT.Text)
            save.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Update thành công")
            txtMaKH.ReadOnly = False
            btnSua.Text = "Sửa"
            LoadData()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim click As Integer = DataGridView1.CurrentCell.RowIndex
        txtMaKH.Text = DataGridView1.Item(0, click).Value
        txtTenKH.Text = DataGridView1.Item(1, click).Value
        txtNgaySinh.Text = DataGridView1.Item(2, click).Value
        txtDiaChi.Text = DataGridView1.Item(3, click).Value
        txtSDT.Text = DataGridView1.Item(4, click).Value

    End Sub
End Class