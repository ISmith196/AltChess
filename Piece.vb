Public Class Piece
    Inherits PictureBox

    Private m_player1or2 As Boolean
    Private m_numMoves As Integer
    Private m_attackRange As Integer
    Private m_movableSpaces As List(Of Spaces)
    Private m_attackableSpaces As List(Of Spaces)
    Private m_occupiedSpace As Spaces
    Private m_boardOffset As Point
    Private m_boardSpaces(,) As Spaces

    Public Sub New()
        m_player1or2 = True
        m_numMoves = 0
        Me.Location = New Point(0, 0)
        Me.BackColor = Color.Transparent
        Me.Size = New Size(50, 50)
        Me.Visible = True
        Me.Enabled = False
        m_occupiedSpace = New Spaces
        m_movableSpaces = New List(Of Spaces)
        m_attackableSpaces = New List(Of Spaces)
        m_boardOffset = New Point(0, 0)
    End Sub

    Public Sub New(player As Boolean, moves As Integer, atRange As Integer, sp As Spaces, offset As Point, boardsp(,) As Spaces, sender As Form, pcNum As Integer)
        m_player1or2 = player
        m_numMoves = moves
        m_attackRange = atRange

        m_occupiedSpace = sp
        m_boardOffset = offset
        m_boardSpaces = boardsp

        Me.Location = (m_occupiedSpace.PointLocation + m_boardOffset)
        Me.Size = New Size(50, 50)
        Me.Visible = True
        Me.Enabled = True
        Me.BackColor = Color.Red
        Me.BorderStyle = BorderStyle.FixedSingle
        Dim plyr As String
        If player Then
            plyr = "P1"
        Else
            plyr = "P2"
        End If
        Me.Name = ("pbx" & plyr & "piece" & pcNum)
        sender.Controls.Add(Me)

        m_movableSpaces = FindNearbySpaces(boardsp, m_numMoves)
        m_attackableSpaces = FindNearbySpaces(boardsp, m_attackRange)


        'm_pictureBox = pbx

        'sender.Controls.Add(Me)
    End Sub

    Public Property CurrentSpace
        Set(value)
            m_occupiedSpace = value
            Me.Location = (m_occupiedSpace.PointLocation + m_boardOffset)
            m_movableSpaces = FindNearbySpaces(m_boardSpaces, m_numMoves)
            m_attackableSpaces = FindNearbySpaces(m_boardSpaces, m_attackRange)
        End Set
        Get
            Return m_occupiedSpace
        End Get
    End Property

    Public Property MovableSpaces
        Get
            Return m_movableSpaces
        End Get
        Set(value)
            m_movableSpaces = value
        End Set
    End Property

    Public Property AttackableSpaces
        Get
            Return m_attackableSpaces
        End Get
        Set(value)
            m_attackableSpaces = value
        End Set
    End Property

    Public Property Player1or2
        Set(value)
            m_player1or2 = value
        End Set
        Get
            Return m_player1or2
        End Get
    End Property

    Public Property AttackRange
        Get
            Return m_attackRange
        End Get
        Set(value)
            m_attackRange = value
        End Set
    End Property

    Public Property numMoves
        Get
            Return m_numMoves
        End Get
        Set(value)
            m_numMoves = value
        End Set
    End Property

    Private Function FindNearbySpaces(boardSpaces(,) As Spaces, range As Integer) As List(Of Spaces)
        Dim nearbySpaces As List(Of Spaces) = New List(Of Spaces)
        Dim spacesOnBoard(,) As Spaces
        spacesOnBoard = boardSpaces
        'spacesOnBoard = boardSpaces

        For x = 0 - range To range
            If (Me.m_occupiedSpace.xCoordinate + x) >= 0 And (Me.m_occupiedSpace.xCoordinate + x) <= 9 Then

                For y = 0 - (range - Math.Abs(x)) To (range - Math.Abs(x))
                    If (Me.m_occupiedSpace.yCoordinate + y) >= 0 And (Me.m_occupiedSpace.yCoordinate + y) <= 9 Then
                        nearbySpaces.Add(spacesOnBoard(Me.m_occupiedSpace.xCoordinate + x, Me.m_occupiedSpace.yCoordinate + y))
                    End If
                Next

            End If
        Next

        Return nearbySpaces
    End Function
End Class
