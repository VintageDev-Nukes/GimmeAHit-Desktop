<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudMinChannel = New System.Windows.Forms.NumericUpDown()
        Me.nudMaxChannel = New System.Windows.Forms.NumericUpDown()
        Me.nudMaxTime = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudRefreshTime = New System.Windows.Forms.NumericUpDown()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        CType(Me.nudMinChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRefreshTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Leer canales"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desde"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(98, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "hasta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Tiempo máximo por petición"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "segundos"
        '
        'nudMinChannel
        '
        Me.nudMinChannel.Location = New System.Drawing.Point(52, 32)
        Me.nudMinChannel.Name = "nudMinChannel"
        Me.nudMinChannel.Size = New System.Drawing.Size(40, 20)
        Me.nudMinChannel.TabIndex = 8
        '
        'nudMaxChannel
        '
        Me.nudMaxChannel.Location = New System.Drawing.Point(137, 31)
        Me.nudMaxChannel.Name = "nudMaxChannel"
        Me.nudMaxChannel.Size = New System.Drawing.Size(40, 20)
        Me.nudMaxChannel.TabIndex = 9
        '
        'nudMaxTime
        '
        Me.nudMaxTime.Location = New System.Drawing.Point(12, 75)
        Me.nudMaxTime.Name = "nudMaxTime"
        Me.nudMaxTime.Size = New System.Drawing.Size(40, 20)
        Me.nudMaxTime.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 31)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tiempo de comprobación de nuevas peticiones"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(58, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "segundos"
        '
        'nudRefreshTime
        '
        Me.nudRefreshTime.Location = New System.Drawing.Point(12, 132)
        Me.nudRefreshTime.Name = "nudRefreshTime"
        Me.nudRefreshTime.Size = New System.Drawing.Size(40, 20)
        Me.nudRefreshTime.TabIndex = 13
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(46, 210)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(100, 40)
        Me.btnSaveSettings.TabIndex = 14
        Me.btnSaveSettings.Text = "Guardar"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 262)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.nudRefreshTime)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nudMaxTime)
        Me.Controls.Add(Me.nudMaxChannel)
        Me.Controls.Add(Me.nudMinChannel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.Text = "Opciones"
        CType(Me.nudMinChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRefreshTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudMinChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMaxChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMaxTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudRefreshTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
End Class
