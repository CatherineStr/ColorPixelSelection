Imports Bwl.Imaging
Imports Bwl.Framework

Public Class HSLMatrix

    Private _hue As UInteger(,)
    Private _saturation As Single(,)
    Private _luminance As Byte(,)
    Private _width As Integer
    Private _height As Integer
    Private _logger As New Logger

    Public ReadOnly Property Hue As UInteger(,)
        Get
            Return _hue
        End Get
    End Property

    Public ReadOnly Property Saturation As Single(,)
        Get
            Return _saturation
        End Get
    End Property

    Public ReadOnly Property Luminance As Byte(,)
        Get
            Return _luminance
        End Get
    End Property

    Public ReadOnly Property Width As Integer
        Get
            Return _width
        End Get
    End Property

    Public ReadOnly Property Height As Integer
        Get
            Return _height
        End Get
    End Property

    Public ReadOnly Property Logger() As Logger
        Get
            Return _logger
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub fromRGBMatrix(rgbMatrix As RGBMatrix)
        _logger.AddMessage("Конвертация из RGB в HSL")
        _width = rgbMatrix.Width
        _height = rgbMatrix.Height

        _hue = New UInteger(rgbMatrix.Width - 1, rgbMatrix.Height - 1) {}
        _luminance = New Byte(rgbMatrix.Width - 1, rgbMatrix.Height - 1) {}
        _saturation = New Single(rgbMatrix.Width - 1, rgbMatrix.Height - 1) {}

        For y As Integer = 0 To rgbMatrix.Height - 1
            For x As Integer = 0 To rgbMatrix.Width - 1
                Dim r As Integer = rgbMatrix.Red(x, y)
                Dim g As Integer = rgbMatrix.Green(x, y)
                Dim b As Integer = rgbMatrix.Blue(x, y)

                'Dim underSqrt As Double =  ' Math.Pow(r - g, 2) + (r - b) * (g - b)
                Dim divisor = Math.Sqrt(r * r + g * g + b * b - r * g - r * b - g * b)
                If divisor <> 0 Then
                    _hue(x, y) = Math.Acos((r - g / 2 - b / 2) / divisor) * 180 / Math.PI
                Else : _hue(x, y) = Math.Acos(0)
                End If

                If g < b Then
                    _hue(x, y) = 360 - _hue(x, y)
                End If

                _luminance(x, y) = (r + g + b) / 3

                If _luminance(x, y) <> 0 Then
                    _saturation(x, y) = 1 - Math.Min(r, Math.Min(g, b)) / _luminance(x, y)
                Else
                    _saturation(x, y) = 0
                End If

            Next x
        Next y
        _logger.AddMessage("Конвертация из RGB в HSL завершена")
    End Sub

    Private Sub filter(Optional hMin As Integer = 0, Optional hMax As Integer = 359, Optional sMin As Single = 0, Optional sMax As Single = 1, Optional lMin As Single = 0, Optional lMax As Single = 255)
        _logger.AddMessage("Фильтрация пикселей")
        Dim hueRequirement As Boolean
        Dim saturationRequirement As Boolean
        Dim luminanceRequirement As Boolean

        For y As Integer = 0 To _height - 1
            For x As Integer = 0 To _width - 1
                If hMin <= hMax Then
                    hueRequirement = _hue(x, y) >= hMin And _hue(x, y) <= hMax
                Else : hueRequirement = _hue(x, y) <= hMax And _hue(x, y) >= 0 Or _hue(x, y) >= hMin And _hue(x, y) < 360
                End If

                If sMin <= sMax Then
                    saturationRequirement = _saturation(x, y) >= sMin And _saturation(x, y) <= sMax
                Else : saturationRequirement = _saturation(x, y) <= sMax And _saturation(x, y) >= 0 Or _saturation(x, y) >= sMin And _saturation(x, y) <= 1
                End If

                If lMin <= lMax Then
                    luminanceRequirement = _luminance(x, y) >= lMin And _luminance(x, y) <= lMax
                Else : luminanceRequirement = _luminance(x, y) <= lMax And _luminance(x, y) >= 0 Or _luminance(x, y) >= lMin And _luminance(x, y) <= 255
                End If

                If Not hueRequirement Or Not saturationRequirement Or Not luminanceRequirement Then
                    _luminance(x, y) = 0
                End If
            Next x
        Next y
        _logger.AddMessage("Фильтрация пикселей завершена")
    End Sub

    Public Function getFilteredRGBMatrix(Optional hMin As Integer = 0, Optional hMax As Integer = 359, Optional sMin As Single = 0, Optional sMax As Single = 1, Optional lMin As Single = 0, Optional lMax As Single = 255) As RGBMatrix
        filter(hMin, hMax, sMin, sMax, lMin, lMax)

        _logger.AddMessage("Конвертация из HSL в RGB")
        Dim r = New Byte(_width - 1, _height - 1) {}
        Dim g = New Byte(_width - 1, _height - 1) {}
        Dim b = New Byte(_width - 1, _height - 1) {}

        For y As Integer = 0 To _height - 1
            For x As Integer = 0 To _width - 1
                Dim l = _luminance(x, y)
                Dim s = _saturation(x, y)
                Dim h = _hue(x, y)

                If h = 0 Then
                    Dim temp = l - l * s
                    Dim temp_1 = l + 2 * l * s
                    r(x, y) = CByte(IIf(temp_1 >= Byte.MinValue And temp_1 <= Byte.MaxValue, temp_1, IIf(temp_1 < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    g(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    b(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                ElseIf h > 0 And h < 120 Then
                    Dim temp = l + l * s * Math.Cos(h * Math.PI / 180) \ Math.Cos((60 - h) * Math.PI / 180)
                    Dim temp_1 = l + l * s * (1 - Math.Cos(h * Math.PI / 180) \ Math.Cos((60 - h) * Math.PI / 180))
                    r(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    g(x, y) = CByte(IIf(temp_1 >= Byte.MinValue And temp_1 <= Byte.MaxValue, temp_1, IIf(temp_1 < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    b(x, y) = CByte(l - l * s)
                ElseIf h = 120 Then
                    Dim temp = l - l * s
                    Dim temp_1 = l + 2 * l * s
                    r(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    g(x, y) = CByte(IIf(temp_1 >= Byte.MinValue And temp_1 <= Byte.MaxValue, temp_1, IIf(temp_1 < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    b(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                ElseIf h > 120 And h < 240 Then
                    Dim temp = l + l * s * Math.Cos((h - 120) * Math.PI / 180) \ Math.Cos((180 - h) * Math.PI / 180)
                    Dim temp_1 = l + l * s * (1 - Math.Cos((h - 120) * Math.PI / 180) \ Math.Cos((180 - h) * Math.PI / 180))
                    r(x, y) = CByte(l - l * s)
                    g(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    b(x, y) = CByte(IIf(temp_1 >= Byte.MinValue And temp_1 <= Byte.MaxValue, temp_1, IIf(temp_1 < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                ElseIf h = 240 Then
                    Dim temp = l - l * s
                    Dim temp_1 = l + 2 * l * s
                    r(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    g(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    b(x, y) = CByte(IIf(temp_1 >= Byte.MinValue And temp_1 <= Byte.MaxValue, temp_1, IIf(temp_1 < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                ElseIf h > 240 And h < 360 Then
                    Dim temp = l + l * s * Math.Cos((h - 240) * Math.PI / 180) \ Math.Cos((300 - h) * Math.PI / 180)
                    Dim temp_1 = l + l * s * (1 - Math.Cos((h - 240) * Math.PI / 180) \ Math.Cos((300 - h) * Math.PI / 180))
                    r(x, y) = CUInt(IIf(temp_1 >= Byte.MinValue And temp_1 <= Byte.MaxValue, temp_1, IIf(temp_1 < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                    g(x, y) = CByte(l - l * s)
                    b(x, y) = CByte(IIf(temp >= Byte.MinValue And temp <= Byte.MaxValue, temp, IIf(temp < Byte.MinValue, Byte.MinValue, Byte.MaxValue)))
                End If
            Next x
        Next y

        _logger.AddMessage("Конвертация из HSL в RGB завершена")
        Return New RGBMatrix(r, g, b)
    End Function
End Class
