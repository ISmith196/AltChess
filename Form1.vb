Imports System.Threading
Public Class Form1


    Private m_boolPlayer1Turn As Boolean = True 'if true, it is player1's turn. Player2's turn if false
    Private m_boolGameRunning As Boolean = False 'will be set to true when game is running. Will be set false when game ends.
    Private m_objBoardSpaces(10, 10) As Spaces 'Object array for tiles containing position and what is occupying the space.
    Private m_boolHasMoved As Boolean = False

    Private m_p1Pieces As List(Of Piece) = New List(Of Piece)
    Private m_p2Pieces As List(Of Piece) = New List(Of Piece)

    Public Property P1Turn() As Boolean
        Get
            Return m_boolPlayer1Turn
        End Get
        Set(value As Boolean)
            m_boolPlayer1Turn = value
        End Set
    End Property

    Public Property GameRunning() As Boolean
        Get
            Return m_boolGameRunning
        End Get
        Set(value As Boolean)
            m_boolGameRunning = value
        End Set
    End Property

    Private Sub btnStartGame_Click(sender As Object, e As EventArgs) Handles btnStartGame.Click
        btnEndTurn.Enabled = True
        'Create board
        DrawBoard()
        'pbxGameBoard.SendToBack()

        'Create board spaces
        CreateSpaces()


        'Create pieces
        'p1Pieces
        m_p1Pieces = CreatePieces(m_p1Pieces, True)
        'For Each pc In m_p1Pieces
        'AddHandler pc.Click, AddressOf Me.Piece_Click
        'Next


        'p2Pieces
        m_p2Pieces = CreatePieces(m_p2Pieces, False)
        ' For Each pc In m_p2Pieces
        'AddHandler pc.Click, AddressOf Me.Piece_Click
        ' Next

        'place pieces


        'turn system
        'loop through
        'start p1 turn


        Dim tempPiece As New Piece
        'Dim tempPieces As New List(Of Piece)
        'tempPieces = CreatePieces(tempPieces, True)
        'tempPiece = New Piece()


        GameRunning() = True

        btnStartGame.Enabled = False
        btnStartGame.Visible = False ' disables and gets rid of start button

        btnEndTurn.Visible = True
        btnEndTurn.Enabled = True 'end turn button now usable

        turnTimer.Enabled = True

        'Dim p1Pieces As List(Of Piece)
        'CreatePieces(p1Pieces, True)
        'p1Pieces(0).m_pictureBox.Location = (m_objBoardSpaces(0, 0).PointLocation + pbxGameBoard.Location)
        'p1Pieces(0)
        pbxP1piece1.Size = New Size(50, 50)

        Dim p2Pieces(8) As Piece

        'CreatePieces(p2Pieces, False)

        'Dim piece1 As Piece = New Piece(True, 3, pbxP1piece1, Me)
        'Me.Controls.Add(piece1.Pbx)


        'piece1.Pbx.m_pictureBox.Location = (m_objBoardSpaces(0, 0).PointLocation + pbxGameBoard.Location)
        'piece1.Pbx.Location = (m_objBoardSpaces(0, 0).PointLocation + pbxGameBoard.Location)

        'DrawBoard() ' creates the board
        'CreateSpaces() ' initializes the m_objBoardSpaces with positions
        pbxGameBoard.SendToBack()
        'DrawSpace(m_objBoardSpaces(0, 0))
        Dim exPiece = New Piece(True, 3, 1, m_objBoardSpaces(0, 0), pbxGameBoard.Location, m_objBoardSpaces, Me, 20)
        'Dim exPiece2 = New Piece(True, 3, New PictureBox, Me)
        'Dim exPiece3 = CreatePiece(True)
        'exPiece3.Location = New Point(400, 400)
        'Dim exPieces As Piece
        exPiece.CurrentSpace = m_objBoardSpaces(7, 7)
        AddHandler exPiece.Click, AddressOf Me.Piece_Click

        exPiece.Name = "exPiece"
        ActiveControl = pbxLastSpace
        'pbxGameBoard.Enabled = False

        'm_activePiece = exPiece

        'ActiveControl = exPiece

        'MsgBox(" " & exPiece.MovableSpaces(0).ToString)


        Dim exSpaces As List(Of Spaces) = exPiece.MovableSpaces()
        'MsgBox("" & exPiece.AttackRange)
        DrawSpace(exSpaces, True)

        pbxGameBoard.SendToBack()

    End Sub

    Function GetNewTime(time As String) As String
        Dim arrTime() As String = time.Split(":")
        Dim intNewTime As Integer = (CInt(arrTime(0)) * 60) + CInt(arrTime(1) - 1)
        Dim newTime As String = (intNewTime \ 60) & ":" & (intNewTime Mod 60)
        Return (newTime)
    End Function

    Private Sub turnTimer_Tick(sender As Object, e As EventArgs) Handles turnTimer.Tick
        If P1Turn = True Then
            lblP1Time.Text = GetNewTime(lblP1Time.Text)
        Else
            lblP2Time.Text = GetNewTime(lblP2Time.Text)
        End If
    End Sub

    Private Sub btnEndTurn_Click(sender As Object, e As EventArgs) Handles btnEndTurn.Click
        'turnTimer.
        P1Turn = Not P1Turn
        m_boolHasMoved = False
        ActiveControl = pbxLastSpace
        Dim strPlayerTurn As String
        DrawBoard()
        If P1Turn Then
            strPlayerTurn = "Player 1"
        Else
            strPlayerTurn = "Player 2"
        End If
        MsgBox("It is now " & strPlayerTurn & "'s turn.", MsgBoxStyle.Exclamation, "Turn Over")


    End Sub

    Private Sub DrawBoard()
        Const SQUARE_SIZE = 50
        Const BOARD_WIDTH = 500
        Const BOARD_HEIGHT = 500

        Dim boolOdd As Boolean = False

        Dim grBoard As Graphics
        grBoard = pbxGameBoard.CreateGraphics

        pbxGameBoard.Width = BOARD_WIDTH
        pbxGameBoard.Height = BOARD_HEIGHT

        For intX = 0 To BOARD_WIDTH - 1 Step SQUARE_SIZE
            For intY = 0 To BOARD_HEIGHT - 1 Step SQUARE_SIZE
                grBoard.DrawRectangle(Pens.Gray, intX, intY, SQUARE_SIZE, SQUARE_SIZE)

                If boolOdd Then
                    grBoard.FillRectangle(Brushes.Black, intX, intY, SQUARE_SIZE, SQUARE_SIZE)
                Else
                    grBoard.FillRectangle(Brushes.White, intX, intY, SQUARE_SIZE, SQUARE_SIZE)
                End If

                boolOdd = Not boolOdd
            Next
            boolOdd = Not boolOdd
        Next

        'grBoard.DrawRectangle(Pens.Red, 0, 50, SQUARE_SIZE, SQUARE_SIZE)
    End Sub

    Private Sub DrawSpace(space As Spaces)
        Const SQUARE_SIZE = 50

        Dim grSpace As Graphics
        grSpace = pbxGameBoard.CreateGraphics

        grSpace.DrawRectangle(Pens.Gray, space.PointLocation.X, space.PointLocation.Y, SQUARE_SIZE, SQUARE_SIZE)

        Dim spaceNum As Integer = (space.xCoordinate) + (space.yCoordinate)
        'MsgBox("x: " & space.PointLocation.X & "    y: " & space.PointLocation.Y)
        If spaceNum Mod 2 = 0 Then

            grSpace.FillRectangle(Brushes.White, space.PointLocation.X, space.PointLocation.Y, SQUARE_SIZE, SQUARE_SIZE)
        Else
            grSpace.FillRectangle(Brushes.Black, space.PointLocation.X, space.PointLocation.Y, SQUARE_SIZE, SQUARE_SIZE)
        End If

    End Sub

    Private Sub DrawSpace(lstSpaces As List(Of Spaces), moveOrAttack As Boolean)
        Const SQUARE_SIZE = 50
        For Each thing In lstSpaces
            Dim grSpace As Graphics

            grSpace = pbxGameBoard.CreateGraphics

            If moveOrAttack = True Then
                grSpace.DrawRectangle(Pens.ForestGreen, thing.PointLocation.X, thing.PointLocation.Y, SQUARE_SIZE, SQUARE_SIZE)
                grSpace.FillRectangle(Brushes.LightGreen, thing.PointLocation.X + 1, thing.PointLocation.Y + 1, SQUARE_SIZE - 1, SQUARE_SIZE - 1)
            Else
                grSpace.DrawRectangle(Pens.Red, thing.PointLocation.X, thing.PointLocation.Y, SQUARE_SIZE, SQUARE_SIZE)
                grSpace.FillRectangle(Brushes.Salmon, thing.PointLocation.X + 1, thing.PointLocation.Y + 1, SQUARE_SIZE - 1, SQUARE_SIZE - 1)
            End If
            'grSpace.DrawRectangle(Pens.ForestGreen, thing.PointLocation.X, thing.PointLocation.Y, SQUARE_SIZE, SQUARE_SIZE)
            'grSpace.FillRectangle(Brushes.LightGreen, thing.PointLocation.X + 1, thing.PointLocation.Y + 1, SQUARE_SIZE - 1, SQUARE_SIZE - 1)

        Next
    End Sub


    Private Function FindNearbySpaces(space As Spaces, range As Integer) As List(Of Spaces)
        Dim nearbySpaces As List(Of Spaces) = New List(Of Spaces)

        For x = 0 - range To range
            If (space.xCoordinate + x) >= 0 And (space.xCoordinate + x) <= 9 Then

                For y = 0 - (range - Math.Abs(x)) To (range - Math.Abs(x))
                    If (space.yCoordinate + y) >= 0 And (space.yCoordinate + y) <= 9 Then
                        nearbySpaces.Add(m_objBoardSpaces(space.xCoordinate + x, space.yCoordinate + y))
                    End If
                Next

            End If
        Next

        Return nearbySpaces
    End Function

    Private Sub CreateSpaces()
        'Dim BoardSpaces(10, 10) As Spaces
        For intx = 0 To 9
            For inty = 0 To 9
                m_objBoardSpaces(intx, inty) = New Spaces(intx, inty)
            Next
        Next
    End Sub

    Private Function CreatePieces(pieces As List(Of Piece), player As Boolean) As List(Of Piece)
        'Dim newPieces As List(Of Piece) = pieces

        Dim numPieces = 8
        For x = 1 To numPieces
            pieces.Add(CreatePiece(player, x))
        Next

        Return pieces
    End Function

    Private Function CreatePiece(player As Boolean, piececNum As Integer) As Piece
        Dim sideCoord As Integer

        If player Then ' determine side
            sideCoord = 0
        Else
            sideCoord = 9
        End If

        m_objBoardSpaces(piececNum, sideCoord).Status = "Occupied" 'update space in form game spaces where new piece will 

        Dim pieceSpace As Spaces = m_objBoardSpaces(piececNum, sideCoord) ' get copy of the space to set the pieces's current location to
        Dim newPiece = New Piece(player, 3, 1, pieceSpace, pbxGameBoard.Location, m_objBoardSpaces, Me, piececNum)
        ' create piece
        AddHandler newPiece.Click, AddressOf Me.Piece_Click

        'm_objBoardSpaces(piececNum, sideCoord)
        'newPiece.BackColor = Color.Red
        'AddHandler .Click, AddressOf pbxP1piece1_Click

        Return newPiece ' return created piece
    End Function


    Private Sub Piece_Click(sender As Object, e As EventArgs) Handles pbxP1piece1.Click, pbxP2piece1.Click
        'probably drawBoard again
        DrawBoard()

        Dim activePiece As Piece = sender

        '1: player clicks own piece first time - (sender =! activecontrol / sender.player = m_playerturn
        '2: player clicks enemy piece to attack - (sender =! activecontrol / sender.player =! m_playerturn
        '3: player clicks own piece after first click but before clicking board to  move (sender = active control /has not moved)
        '4: player clicks own piece after first click and after moving (sender = active control/ has moved


        'option 1:
        'player turn has started
        'all of players buttons were available to click before this sub called

        'before: active control should be none(or follow piece) after: active control should be sender
        'is active piece empty
        '-ActiveControl = activePiece
        '-DrawSpace(activePiece.MovableSpaces, True)
        'option1 done I think

        'MsgBox("active before: " & ActiveControl.Name)
        'MsgBox("sender before: " & sender.Name)

        If ActiveControl.Name.Equals(activePiece.Name) = False Then 'either option 1 or 2
            'MsgBox("first if is working")
            'option 5: click from one pl pc to another
            If activePiece.Name(4).Equals(ActiveControl.Name(4)) Then

                'activePiece'
                ActiveControl = activePiece

                DrawSpace(activePiece.MovableSpaces, True)

            ElseIf activePiece.Player1or2 = m_boolPlayer1Turn Then 'option 1
                'MsgBox("second if is working")

                ActiveControl = activePiece

                DrawSpace(activePiece.MovableSpaces, True)

                'And hasMoved = False Then
                'activePiece.Player1or2 = True And m_boolPlayer1Turn = True

                MsgBox("active after: " & ActiveControl.Name)

                'm_boolPlayer1Turn = Not m_boolPlayer1Turn

            ElseIf ActiveControl.Name.Equals(pbxLastSpace.Name) = False Then 'option 2

                'is the sender piece's space within the list of attackable spaces for activecontrol
                'either the sender piece will not be clickable because of board click to move( this might cause
                MsgBox("" & activePiece.Name)
                MsgBox("" & ActiveControl.Name)
                Dim attackingPiece As Piece = ActiveControl ' piece that is attacking
                Dim tempSpace1 As Spaces
                Dim tempSpace2 As Spaces
                Dim isAttackable As Boolean = False
                For Each sp In attackingPiece.AttackableSpaces 'spaces that piece can attack
                    tempSpace1 = sp 'an attackable space
                    tempSpace2 = activePiece.CurrentSpace 'space that clicked piece is in
                    If tempSpace2.PointLocation = tempSpace1.PointLocation Then ' if they are the same
                        isAttackable = True
                        Dim removedPiece As Piece = New Piece()
                        'do damage calc/ or just get rid of piece
                        If m_boolPlayer1Turn Then 'if player1' turn remove piece from p2 otherwise remove from p1 
                            For Each pc In m_p2Pieces
                                If pc.Name.Equals(activePiece.Name) Then
                                    removedPiece = pc
                                End If
                            Next
                            If m_p2Pieces.Contains(removedPiece) Then
                                m_p2Pieces.Remove(removedPiece)
                                Me.Controls.Remove(removedPiece)
                            End If
                        Else
                            For Each pc In m_p1Pieces
                                If pc.Name.Equals(activePiece.Name) Then
                                    removedPiece = pc
                                End If
                            Next
                            If m_p1Pieces.Contains(removedPiece) Then
                                m_p1Pieces.Remove(removedPiece)
                                Me.Controls.Remove(removedPiece)
                            End If
                        End If

                        ActiveControl = pbxLastSpace

                        m_boolPlayer1Turn = Not m_boolPlayer1Turn
                        m_boolHasMoved = False
                        'lastspace move/change
                    End If

                Next

                'If m_boolPlayer1Turn Then
                '    For Each pc In m_p1Pieces
                '        If activePiece.CurrentSpace() Then
                '            If activePiece.Name.Equals(pc.Name) Then

                '        End If
                '    Next
                'End If
                'For Each pc In m_p2Pieces

                'Next

                'If activePiece.CurrentSpace.pointLocation Then
                'do option 2

                'If m_boolPlayer1Turn Then

                'activePiece.Visible = False


                'activePiece.Location = New Point(100, 100)
                ' MsgBox("the thing")

                'm_p1Pieces.Remove(activePiece)
                ActiveControl = pbxLastSpace

                'End If
                'maybe subroutine 

            End If

            'if last space clicked was the 
            'ElseIf activePiece.Name(4).Equals(ActiveControl.Name(4)) Then


        Else 'currently sender name and active control name are same( so option 3 or 4)
            ' 1: piece has been clicked to show movable spaces or to end piece's turn without attacking
            DrawBoard()

            If m_boolHasMoved Then
                m_boolHasMoved = False
            End If
            'm_boolHasMoved = False
            ActiveControl = pbxLastSpace
            m_boolPlayer1Turn = Not m_boolPlayer1Turn
            MsgBox("piece turn over")
            'do end turn stuff

            'If m_boolHasMoved Then
            '    m_boolHasMoved = False
            'Else
            '    ActiveControl = pbxLastSpace
            'End If

        End If
        'should draw the sender's movable spaces
        'other player pieces should be made unclickable(smaybe still clickable to change
        'board becomes clickable(note for later:enemy pieces in range should be come clickable after board is clicked)

        'option 2:
        'player has moved piece by clicking board
        'player called this sub by clicking enemy piece in range of (ex: player1 moves piece one in range of player two piece and clicked it)
        'sender



        'End If


        'Attack stuff happens(either one shot or damage calc)
        '



        'm_activePiece = sender

        ''DrawSpace(m_objBoardSpaces(9, 9))
        ''sender.Location = (m_objBoardSpaces(5, 5).PointLocation + pbxGameBoard.Location)
        ''sender.BringToFront()
        'm_activePiece.Location = (m_objBoardSpaces(5, 5).PointLocation + pbxGameBoard.Location)

        'DrawSpace(m_objBoardSpaces(0, 0))
        'pbxP1piece1.Visible = True
        'Thread.Sleep(1000)
        'DrawSpace(m_objBoardSpaces(9, 9))

    End Sub

    Private Sub pbxGameBoard_MouseClick(sender As Object, e As MouseEventArgs) Handles pbxGameBoard.MouseClick
        ' get mouse location and convert to board spaces coord
        Dim mousePos As Point = Me.PointToClient(MousePosition) - pbxGameBoard.Location

        Dim mousePointX = (mousePos.X \ 50)
        Dim mousePointY = (mousePos.Y \ 50)

        Dim mousePoint = New Point(mousePointX, mousePointY)

        'this area of code should be the only one that allows movement that isn't removing a space
        'if the activecontrol isn't pbxlastspace, do stuff(makes sure a piece has been selected already
        'if active control is pbxlastspace do nothing(no piece is active)
        'if activecontorl is a piece, then it must have been clicked already and this code moves it
        If ActiveControl.Name.Equals(pbxLastSpace.Name) = False Then

            'if bool has moved is false, move the activecontrol piece to the clicked area

            If m_boolHasMoved = False Then
                'MsgBox("Omg")
                m_boolHasMoved = True 'because the piece will move

                Dim activePiece As Piece = ActiveControl ' get clone of active control i guess

                Dim allowedMoves As List(Of Spaces) = activePiece.MovableSpaces() ' get the moveable spaces
                'Dim targetedSpaces As List(Of Spaces) = activePiece.AttackableSpaces()

                Dim validMove = False 'will be set to true if mouseclick location is in a space that active piece can move to

                For Each sp In allowedMoves ' loop through each allowed space

                    'compare mouse click space coords to coords of each movable spaces
                    If sp.xCoordinate = mousePoint.X And sp.yCoordinate = mousePointY Then
                        ' ibelieve that i need to update the the boardspaces and the movable spaces of each piece
                        ' the attackable spaces might be fine as is 
                        Dim oldSpace As Spaces = activePiece.CurrentSpace()
                        m_objBoardSpaces(oldSpace.xCoordinate, oldSpace.yCoordinate).Status = "Empty"

                        m_objBoardSpaces(sp.xCoordinate, sp.yCoordinate).Status = "Occupied"

                        'if the mouse space does match a space, move the active piece there
                        activePiece.CurrentSpace = sp
                        'ActiveControl = act

                        'activePiece.MovableSpaces(New Spacessp.xCoordinate, sp.yCoordinate)
                        'make sure future code knows this move is valid/ took place
                        validMove = True

                        'MsgBox("the thing")

                        DrawBoard() 'draw board again to get rid of movable spaces

                        'now get attack spaces and draw them around active piece
                        Dim attackSpaces As List(Of Spaces) = activePiece.AttackableSpaces
                        DrawSpace(attackSpaces, False)

                        'm_activePiece = New Piece()
                        'pbxP1piece1.Enabled = False
                        'Me.ActiveControl = sender
                    End If
                Next

                If validMove = False Then
                    MsgBox("Please select a highlighted square", MsgBoxStyle.Exclamation, "Invalid Move")
                End If
            Else

                MsgBox("You can't attack an empty space. Click the active piece to end your turn", MsgBoxStyle.Exclamation, "Invalid Attack Target")

                'm_boolHasMoved = False
                'ActiveControl = pbxLastSpace
            End If

        End If

        'Dim mousePos As Point = Me.PointToClient(MousePosition) - pbxGameBoard.Location

    End Sub
End Class