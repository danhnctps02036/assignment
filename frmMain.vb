Public Class frmMain

    Private Sub ChỉnhSữaKHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChỉnhSữaKHToolStripMenuItem.Click
        frmKhachHang.Show()
    End Sub

    Private Sub SảnPhẩmToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SảnPhẩmToolStripMenuItem1.Click
        frmSanPham.Show()
    End Sub

    Private Sub XemSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemSảnPhẩmToolStripMenuItem.Click
        frmXemsanpham.Show()
    End Sub

    Private Sub ThêmSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmSảnPhẩmToolStripMenuItem.Click
        FrmLoaiSanPham.Show()
    End Sub

    Private Sub HóaĐơnKHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HóaĐơnKHToolStripMenuItem.Click
        FrmHoaDon.Show()
    End Sub

    Private Sub ChiTiếtHĐToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiTiếtHĐToolStripMenuItem.Click
        FrmChiTietHoaDon.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class