Public Class Spaces


    Private m_intXCoord As Integer
    Private m_intYCoord As Integer
    Private m_pntLocation As Point

    Private m_strStatus As String

    Public Sub New()
        'defaults. This should happen probably.
        m_intXCoord = 0
        m_intYCoord = 0
        m_pntLocation = New Point(550, 550)
        m_strStatus = "Empty"

    End Sub

    Public Sub New(x As Integer, y As Integer)
        m_intXCoord = x
        m_intYCoord = y
        m_pntLocation = New Point(x * 50, y * 50)
        m_strStatus = "Empty"
    End Sub

    Public Property xCoordinate() As Integer
        Get
            Return m_intXCoord
        End Get
        Set(value As Integer)
            m_intXCoord = value
        End Set
    End Property

    Public Property yCoordinate() As Integer
        Get
            Return m_intYCoord
        End Get
        Set(value As Integer)
            m_intYCoord = value
        End Set
    End Property

    Public Property PointLocation() As Point
        Get
            Return m_pntLocation
        End Get
        Set(value As Point)
            m_pntLocation = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return m_strStatus
        End Get
        Set(value As String)
            m_strStatus = value
        End Set
    End Property
End Class
