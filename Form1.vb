Public Class Form1

    Private Sub button_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_cari.Click
        Dim filePath As String = textbox_lokasi.Text
        If System.IO.File.Exists(filePath) Then
            RichTextBox1.Text = System.IO.File.ReadAllText(filePath)
        Else
            MessageBox.Show("File tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_simpan.Click
        Dim filePath As String = textbox_lokasi.Text
        Dim newText As String = RichTextBox1.Text ' Ambil teks yang diubah di RichTextBox
        Dim encryptedText As String = EncryptText(newText, 3) ' Enkripsi teks tersebut (menggunakan shift 3 sebagai contoh)
        System.IO.File.WriteAllText(filePath, newText) ' Simpan teks terenkripsi ke file
        RichTextBox1.Text = encryptedText ' Tampilkan teks terenkripsi di RichTextBox
    End Sub

    Private Function EncryptText(ByVal input As String, ByVal shift As Integer) As String
        Dim result As String = ""
        For Each c As Char In input
            If Char.IsLetter(c) Then
                Dim offset As Integer = Asc(If(Char.IsUpper(c), "A"c, "a"c))
                result &= Chr(((Asc(c) + shift - offset) Mod 26) + offset)
            Else
                result &= c ' Tetap menambahkan karakter non-huruf
            End If
        Next
        Return result
    End Function

End Class
