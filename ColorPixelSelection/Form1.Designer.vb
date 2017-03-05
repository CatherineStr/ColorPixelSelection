<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gui_form
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.resultImg_pb = New System.Windows.Forms.PictureBox()
        Me.sourceImg_pb = New System.Windows.Forms.PictureBox()
        Me.loadImage_btn = New System.Windows.Forms.Button()
        Me.hue_min_nud = New System.Windows.Forms.NumericUpDown()
        Me.hue_max_nud = New System.Windows.Forms.NumericUpDown()
        Me.saturation_max_nud = New System.Windows.Forms.NumericUpDown()
        Me.saturation_min_nud = New System.Windows.Forms.NumericUpDown()
        Me.luminance_max_nud = New System.Windows.Forms.NumericUpDown()
        Me.luminance_min_nud = New System.Windows.Forms.NumericUpDown()
        Me.hue_lbl = New System.Windows.Forms.Label()
        Me.saturation_lbl = New System.Windows.Forms.Label()
        Me.luminance_lbl = New System.Windows.Forms.Label()
        Me.SelectPixels_btn = New System.Windows.Forms.Button()
        Me.Save_btn = New System.Windows.Forms.Button()
        CType(Me.resultImg_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sourceImg_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hue_min_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hue_max_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saturation_max_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saturation_min_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luminance_max_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luminance_min_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'resultImg_pb
        '
        Me.resultImg_pb.BackColor = System.Drawing.SystemColors.ControlDark
        Me.resultImg_pb.Location = New System.Drawing.Point(590, 82)
        Me.resultImg_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.resultImg_pb.Name = "resultImg_pb"
        Me.resultImg_pb.Size = New System.Drawing.Size(569, 452)
        Me.resultImg_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.resultImg_pb.TabIndex = 10
        Me.resultImg_pb.TabStop = False
        '
        'sourceImg_pb
        '
        Me.sourceImg_pb.BackColor = System.Drawing.SystemColors.ControlDark
        Me.sourceImg_pb.Location = New System.Drawing.Point(13, 82)
        Me.sourceImg_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.sourceImg_pb.Name = "sourceImg_pb"
        Me.sourceImg_pb.Size = New System.Drawing.Size(569, 452)
        Me.sourceImg_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.sourceImg_pb.TabIndex = 9
        Me.sourceImg_pb.TabStop = False
        '
        'loadImage_btn
        '
        Me.loadImage_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.loadImage_btn.Location = New System.Drawing.Point(13, 11)
        Me.loadImage_btn.Margin = New System.Windows.Forms.Padding(4)
        Me.loadImage_btn.Name = "loadImage_btn"
        Me.loadImage_btn.Size = New System.Drawing.Size(102, 39)
        Me.loadImage_btn.TabIndex = 12
        Me.loadImage_btn.Text = "Загрузить изображение"
        Me.loadImage_btn.UseVisualStyleBackColor = True
        '
        'hue_min_nud
        '
        Me.hue_min_nud.Location = New System.Drawing.Point(254, 16)
        Me.hue_min_nud.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
        Me.hue_min_nud.Minimum = New Decimal(New Integer() {359, 0, 0, -2147483648})
        Me.hue_min_nud.Name = "hue_min_nud"
        Me.hue_min_nud.Size = New System.Drawing.Size(54, 20)
        Me.hue_min_nud.TabIndex = 13
        '
        'hue_max_nud
        '
        Me.hue_max_nud.Location = New System.Drawing.Point(403, 16)
        Me.hue_max_nud.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
        Me.hue_max_nud.Name = "hue_max_nud"
        Me.hue_max_nud.Size = New System.Drawing.Size(54, 20)
        Me.hue_max_nud.TabIndex = 14
        Me.hue_max_nud.Value = New Decimal(New Integer() {359, 0, 0, 0})
        '
        'saturation_max_nud
        '
        Me.saturation_max_nud.Location = New System.Drawing.Point(662, 15)
        Me.saturation_max_nud.Name = "saturation_max_nud"
        Me.saturation_max_nud.Size = New System.Drawing.Size(54, 20)
        Me.saturation_max_nud.TabIndex = 16
        Me.saturation_max_nud.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'saturation_min_nud
        '
        Me.saturation_min_nud.Location = New System.Drawing.Point(475, 15)
        Me.saturation_min_nud.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.saturation_min_nud.Name = "saturation_min_nud"
        Me.saturation_min_nud.Size = New System.Drawing.Size(54, 20)
        Me.saturation_min_nud.TabIndex = 15
        '
        'luminance_max_nud
        '
        Me.luminance_max_nud.Location = New System.Drawing.Point(873, 14)
        Me.luminance_max_nud.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.luminance_max_nud.Name = "luminance_max_nud"
        Me.luminance_max_nud.Size = New System.Drawing.Size(54, 20)
        Me.luminance_max_nud.TabIndex = 18
        Me.luminance_max_nud.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'luminance_min_nud
        '
        Me.luminance_min_nud.Location = New System.Drawing.Point(735, 14)
        Me.luminance_min_nud.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.luminance_min_nud.Name = "luminance_min_nud"
        Me.luminance_min_nud.Size = New System.Drawing.Size(54, 20)
        Me.luminance_min_nud.TabIndex = 17
        '
        'hue_lbl
        '
        Me.hue_lbl.AutoSize = True
        Me.hue_lbl.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.hue_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.hue_lbl.Location = New System.Drawing.Point(310, 19)
        Me.hue_lbl.Name = "hue_lbl"
        Me.hue_lbl.Size = New System.Drawing.Size(91, 13)
        Me.hue_lbl.TabIndex = 19
        Me.hue_lbl.Text = "<= Тон (град.) <="
        '
        'saturation_lbl
        '
        Me.saturation_lbl.AutoSize = True
        Me.saturation_lbl.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.saturation_lbl.Location = New System.Drawing.Point(531, 17)
        Me.saturation_lbl.Name = "saturation_lbl"
        Me.saturation_lbl.Size = New System.Drawing.Size(129, 13)
        Me.saturation_lbl.TabIndex = 20
        Me.saturation_lbl.Text = "<= Насыщенность(%) <="
        '
        'luminance_lbl
        '
        Me.luminance_lbl.AutoSize = True
        Me.luminance_lbl.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.luminance_lbl.Location = New System.Drawing.Point(791, 16)
        Me.luminance_lbl.Name = "luminance_lbl"
        Me.luminance_lbl.Size = New System.Drawing.Size(80, 13)
        Me.luminance_lbl.TabIndex = 21
        Me.luminance_lbl.Text = "<= Яркость <="
        '
        'SelectPixels_btn
        '
        Me.SelectPixels_btn.Location = New System.Drawing.Point(252, 44)
        Me.SelectPixels_btn.Name = "SelectPixels_btn"
        Me.SelectPixels_btn.Size = New System.Drawing.Size(679, 31)
        Me.SelectPixels_btn.TabIndex = 22
        Me.SelectPixels_btn.Text = "Отфильтровать"
        Me.SelectPixels_btn.UseVisualStyleBackColor = True
        '
        'Save_btn
        '
        Me.Save_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Save_btn.Location = New System.Drawing.Point(1057, 11)
        Me.Save_btn.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(102, 41)
        Me.Save_btn.TabIndex = 23
        Me.Save_btn.Text = "Сохранить результат"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'gui_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 703)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.SelectPixels_btn)
        Me.Controls.Add(Me.luminance_lbl)
        Me.Controls.Add(Me.saturation_lbl)
        Me.Controls.Add(Me.hue_lbl)
        Me.Controls.Add(Me.luminance_max_nud)
        Me.Controls.Add(Me.luminance_min_nud)
        Me.Controls.Add(Me.saturation_max_nud)
        Me.Controls.Add(Me.saturation_min_nud)
        Me.Controls.Add(Me.hue_max_nud)
        Me.Controls.Add(Me.hue_min_nud)
        Me.Controls.Add(Me.loadImage_btn)
        Me.Controls.Add(Me.resultImg_pb)
        Me.Controls.Add(Me.sourceImg_pb)
        Me.IsMdiContainer = True
        Me.Name = "gui_form"
        Me.Text = "ColorPixelSelection"
        CType(Me.resultImg_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sourceImg_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.hue_min_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.hue_max_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saturation_max_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saturation_min_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luminance_max_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luminance_min_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents resultImg_pb As System.Windows.Forms.PictureBox
    Private WithEvents sourceImg_pb As System.Windows.Forms.PictureBox
    Private WithEvents loadImage_btn As System.Windows.Forms.Button
    Friend WithEvents hue_min_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents hue_max_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents saturation_max_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents saturation_min_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents luminance_max_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents luminance_min_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents hue_lbl As System.Windows.Forms.Label
    Friend WithEvents saturation_lbl As System.Windows.Forms.Label
    Friend WithEvents luminance_lbl As System.Windows.Forms.Label
    Friend WithEvents SelectPixels_btn As System.Windows.Forms.Button
    Private WithEvents Save_btn As System.Windows.Forms.Button

End Class
