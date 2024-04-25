<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnStartGame = New System.Windows.Forms.Button()
        Me.pbxGameBoard = New System.Windows.Forms.PictureBox()
        Me.lblPlayer2 = New System.Windows.Forms.Label()
        Me.lblPlayer1 = New System.Windows.Forms.Label()
        Me.btnEndTurn = New System.Windows.Forms.Button()
        Me.turnTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblP1Time = New System.Windows.Forms.Label()
        Me.lblP2Time = New System.Windows.Forms.Label()
        Me.pbxP1piece1 = New System.Windows.Forms.PictureBox()
        Me.pbxP2piece1 = New System.Windows.Forms.PictureBox()
        Me.pbxLastSpace = New System.Windows.Forms.PictureBox()
        CType(Me.pbxGameBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxP1piece1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxP2piece1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLastSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStartGame
        '
        Me.btnStartGame.Location = New System.Drawing.Point(32, 46)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(206, 52)
        Me.btnStartGame.TabIndex = 0
        Me.btnStartGame.Text = "Start Game"
        Me.btnStartGame.UseVisualStyleBackColor = True
        '
        'pbxGameBoard
        '
        Me.pbxGameBoard.BackColor = System.Drawing.Color.DarkGray
        Me.pbxGameBoard.Location = New System.Drawing.Point(270, 39)
        Me.pbxGameBoard.Name = "pbxGameBoard"
        Me.pbxGameBoard.Size = New System.Drawing.Size(500, 500)
        Me.pbxGameBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbxGameBoard.TabIndex = 1
        Me.pbxGameBoard.TabStop = False
        '
        'lblPlayer2
        '
        Me.lblPlayer2.AutoSize = True
        Me.lblPlayer2.Location = New System.Drawing.Point(188, 149)
        Me.lblPlayer2.Name = "lblPlayer2"
        Me.lblPlayer2.Size = New System.Drawing.Size(29, 17)
        Me.lblPlayer2.TabIndex = 2
        Me.lblPlayer2.Text = "P2:"
        '
        'lblPlayer1
        '
        Me.lblPlayer1.AutoSize = True
        Me.lblPlayer1.Location = New System.Drawing.Point(54, 149)
        Me.lblPlayer1.Name = "lblPlayer1"
        Me.lblPlayer1.Size = New System.Drawing.Size(29, 17)
        Me.lblPlayer1.TabIndex = 3
        Me.lblPlayer1.Text = "P1:"
        '
        'btnEndTurn
        '
        Me.btnEndTurn.Enabled = False
        Me.btnEndTurn.Location = New System.Drawing.Point(70, 251)
        Me.btnEndTurn.Name = "btnEndTurn"
        Me.btnEndTurn.Size = New System.Drawing.Size(134, 43)
        Me.btnEndTurn.TabIndex = 4
        Me.btnEndTurn.Text = "End Turn"
        Me.btnEndTurn.UseVisualStyleBackColor = True
        '
        'turnTimer
        '
        Me.turnTimer.Interval = 1000
        '
        'lblP1Time
        '
        Me.lblP1Time.AutoSize = True
        Me.lblP1Time.Location = New System.Drawing.Point(47, 203)
        Me.lblP1Time.Name = "lblP1Time"
        Me.lblP1Time.Size = New System.Drawing.Size(36, 17)
        Me.lblP1Time.TabIndex = 5
        Me.lblP1Time.Text = "5:00"
        '
        'lblP2Time
        '
        Me.lblP2Time.AutoSize = True
        Me.lblP2Time.Location = New System.Drawing.Point(181, 203)
        Me.lblP2Time.Name = "lblP2Time"
        Me.lblP2Time.Size = New System.Drawing.Size(36, 17)
        Me.lblP2Time.TabIndex = 6
        Me.lblP2Time.Text = "5:00"
        '
        'pbxP1piece1
        '
        Me.pbxP1piece1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.pbxP1piece1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxP1piece1.Enabled = False
        Me.pbxP1piece1.Location = New System.Drawing.Point(184, 326)
        Me.pbxP1piece1.Name = "pbxP1piece1"
        Me.pbxP1piece1.Size = New System.Drawing.Size(67, 63)
        Me.pbxP1piece1.TabIndex = 7
        Me.pbxP1piece1.TabStop = False
        Me.pbxP1piece1.Visible = False
        Me.pbxP1piece1.WaitOnLoad = True
        '
        'pbxP2piece1
        '
        Me.pbxP2piece1.BackColor = System.Drawing.Color.Lime
        Me.pbxP2piece1.Enabled = False
        Me.pbxP2piece1.Location = New System.Drawing.Point(0, 326)
        Me.pbxP2piece1.Name = "pbxP2piece1"
        Me.pbxP2piece1.Size = New System.Drawing.Size(67, 63)
        Me.pbxP2piece1.TabIndex = 8
        Me.pbxP2piece1.TabStop = False
        Me.pbxP2piece1.Visible = False
        '
        'pbxLastSpace
        '
        Me.pbxLastSpace.Location = New System.Drawing.Point(105, 326)
        Me.pbxLastSpace.Name = "pbxLastSpace"
        Me.pbxLastSpace.Size = New System.Drawing.Size(50, 50)
        Me.pbxLastSpace.TabIndex = 10
        Me.pbxLastSpace.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.pbxLastSpace)
        Me.Controls.Add(Me.pbxP2piece1)
        Me.Controls.Add(Me.pbxP1piece1)
        Me.Controls.Add(Me.lblP2Time)
        Me.Controls.Add(Me.lblP1Time)
        Me.Controls.Add(Me.btnEndTurn)
        Me.Controls.Add(Me.lblPlayer1)
        Me.Controls.Add(Me.lblPlayer2)
        Me.Controls.Add(Me.pbxGameBoard)
        Me.Controls.Add(Me.btnStartGame)
        Me.Name = "Form1"
        Me.Text = "GameBoard"
        CType(Me.pbxGameBoard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxP1piece1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxP2piece1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLastSpace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStartGame As Button
    Friend WithEvents lblPlayer2 As Label
    Friend WithEvents lblPlayer1 As Label
    Friend WithEvents btnEndTurn As Button
    Friend WithEvents turnTimer As Timer
    Friend WithEvents lblP1Time As Label
    Friend WithEvents lblP2Time As Label
    Friend WithEvents pbxP1piece1 As PictureBox
    Friend WithEvents pbxP2piece1 As PictureBox
    Friend WithEvents pbxGameBoard As PictureBox
    Friend WithEvents pbxLastSpace As PictureBox
End Class
