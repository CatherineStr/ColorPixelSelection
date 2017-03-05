Imports Bwl.Imaging
Imports System.Threading
Imports System.ComponentModel
Imports Bwl.Framework

Public Class gui_form

    Dim sourceImg As Bitmap
    Dim _resImg As Bitmap
    Dim hsl As New HSLMatrix
    Dim lform As LoggerForm

    Private Sub resImgChanged_in_pb(ByVal sender As Object, ByVal e As EventArgs)
        resultImg_pb.Image = _resImg
    End Sub
    Private Sub OnResImgChanged(ByVal e As EventArgs)
        Dim handler As EventHandler = resImgChangedEvent
        If handler IsNot Nothing Then
            handler(Me, e)
        End If
    End Sub
    Public Event resImgChanged As EventHandler

    Public Property ResImg As Bitmap
        Get
            Return _resImg
        End Get
        Set(ByVal value As Bitmap)
            If value IsNot Nothing Then
                _resImg = value
                OnResImgChanged(New PropertyChangedEventArgs("ResImg"))
            End If
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler resImgChanged, AddressOf resImgChanged_in_pb
        lform = New LoggerForm(hsl.Logger)
        lform.MdiParent = Me
        lform.Dock = DockStyle.Bottom
        lform.Height = 200
        lform.FormBorderStyle = FormBorderStyle.None
        lform.Show()
    End Sub

    Private Sub loadImage_btn_Click(sender As Object, e As EventArgs) Handles loadImage_btn.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Jpeg|*.jpg|Bitmap|*.bmp|All files|*.*"
            dialog.Title = "Open an Image file"

            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    sourceImg = New Bitmap(dialog.FileName)
                Catch
                    MessageBox.Show("Ошибка при попытке открыть файл с заданным именем.", "Ошибка")
                    Return
                End Try
            End If
        End Using
        Dim db As DisplayBitmap
        Dim dbc As DisplayBitmapControl
        If sourceImg IsNot Nothing Then
            db = New DisplayBitmap(sourceImg)
            dbc = New DisplayBitmapControl()
            dbc.DisplayBitmap = db
            dbc._pictureBox = sourceImg_pb
            dbc.Refresh()
        End If

        hsl.fromRGBMatrix(BitmapConverter.BitmapToRGBMatrix(sourceImg))
    End Sub

    Private Sub hue_min_nud_ValueChanged(sender As Object, e As EventArgs) Handles hue_min_nud.ValueChanged
        hue_max_nud.Minimum = hue_min_nud.Value
        hue_max_nud.Maximum = IIf(hue_min_nud.Value <= 0, hue_min_nud.Value + 359, 359)
    End Sub

    Private Sub saturation_min_nud_ValueChanged(sender As Object, e As EventArgs) Handles saturation_min_nud.ValueChanged
        'saturation_max_nud.Minimum = saturation_min_nud.Value
    End Sub

    Private Sub luminance_min_nud_ValueChanged(sender As Object, e As EventArgs) Handles luminance_min_nud.ValueChanged
        ' luminance_max_nud.Minimum = luminance_min_nud.Value
    End Sub

    Private Sub selectPixels()
        If IsNothing(sourceImg) Then
            MessageBox.Show("Отсутствует исходное изображение")
        End If

        Dim hMin = IIf(hue_min_nud.Value < 0, 360 + hue_min_nud.Value, hue_min_nud.Value)
        Dim hMax = IIf(hue_max_nud.Value < 0, 360 + hue_max_nud.Value, hue_max_nud.Value)
        ResImg = BitmapConverter.RGBMatrixToBitmap(hsl.getFilteredRGBMatrix(hMin, hMax, saturation_min_nud.Value / 100, saturation_max_nud.Value / 100, luminance_min_nud.Value, luminance_max_nud.Value))
        MessageBox.Show("Вычисления завершены")
    End Sub

    Private Sub SelectPixels_btn_Click(sender As Object, e As EventArgs) Handles SelectPixels_btn.Click
        Dim selectionThread = New Thread(AddressOf selectPixels)
        selectionThread.Start()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If ResImg Is Nothing Then
            MessageBox.Show("Нет данных для сохранения")
            Return
        End If
        Using dialog As New SaveFileDialog()
            dialog.Filter = "PNG|*.png|Bitmap|*.bmp|All files|*.*"
            dialog.Title = "Save an Image file"
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    ResImg.Save(dialog.FileName)
                Catch
                    MessageBox.Show("Ошибка при попытке сохранения файла с заданным именем", "Ошибка")
                End Try
            End If
        End Using
    End Sub
End Class
