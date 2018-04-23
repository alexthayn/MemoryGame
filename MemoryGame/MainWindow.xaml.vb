Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Threading

Class MainWindow
    Dim board As GameBoard = New GameBoard()
    Dim firstPick As String
    Dim secondPick As String
    Dim btn1 As Button
    Dim btn2 As Button
    Dim hasSelected1Card As Boolean = False
    Dim hasSelected2Cards As Boolean = False
    Dim isCardMatched As String() = {False, False, False, False, False, False, False, False, False, False, False, False}
    Dim isGameOver As Boolean = False
    Dim CardPlacement As String()
    Private backgroundWorker As New BackgroundWorker()
    Dim CardSelected As Button
    Dim NeedToBeHidden As Boolean

    Private Sub Application_Startup()
        NewGame()
        'AddHandler backgroundWorker.DoWork, AddressOf Background_Handler

    End Sub

    'This function handles the exit game button
    Private Sub ExitGame()
        Application.Current.Shutdown()
    End Sub

    'This function handles the new game button
    Private Sub NewGame()
        board.NewGame()
        CardPlacement = board.CardLocation
        SetImage00(CardPlacement(0))
        SetImage01(CardPlacement(1))
        SetImage02(CardPlacement(2))
        SetImage10(CardPlacement(3))
        SetImage11(CardPlacement(4))
        SetImage12(CardPlacement(5))
        SetImage20(CardPlacement(6))
        SetImage21(CardPlacement(7))
        SetImage22(CardPlacement(8))
        SetImage30(CardPlacement(9))
        SetImage31(CardPlacement(10))
        SetImage32(CardPlacement(11))
    End Sub

    Private Sub CardClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim card As Button = CType(sender, Button)
        ShowCard(card)
        Me.CardSelected = card
        'AddHandler backgroundWorker.DoWork, AddressOf Background_CardSelection
        Background_CardSelection(sender, e)
        If NeedToBeHidden Then
            HideCards()
        End If
    End Sub

    Private Sub Background_CardSelection(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CardSelected As Button = CType(sender, Button)
        Dim cardName = GetCardImageName(CardSelected.Name)


        'Check if this is the first or second card selected
        If Not hasSelected1Card Then
            hasSelected1Card = True
            firstPick = cardName
            btn1 = CardSelected
            NeedToBeHidden = False
        ElseIf Not hasSelected2Cards Then
            hasSelected2Cards = True
            secondPick = cardName
            btn2 = CardSelected

            If firstPick = secondPick Then
                FoundAMatch(firstPick)
                FoundAMatch(secondPick)
                NeedToBeHidden = False
            Else
                NeedToBeHidden = True
                Me.InvalidateVisual()

                PauseScreen()
            End If

            Me.hasSelected1Card = False
            Me.hasSelected2Cards = False

            If checkIfGameIsOver() Then

            End If

        End If
    End Sub


    Private Sub ShowCard(card As Button)
        card.Visibility = Visibility.Hidden
    End Sub

    Private Sub HideCards()
        btn1.Visibility = Visibility.Visible
        btn2.Visibility = Visibility.Visible
    End Sub

    Private Function checkIfGameIsOver()
        Dim gameIsOver As Boolean = True
        For Each element As Boolean In isCardMatched
            If Not element Then
                gameIsOver = False
            End If
        Next

        Return gameIsOver
    End Function

    Private Sub PauseScreen()
        Threading.Thread.Sleep(500)
    End Sub

    Public Sub SetImage00(card As String)
        Me.Img00.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage01(card As String)
        Me.Img01.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage02(card As String)
        Me.Img02.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage10(card As String)
        Me.Img10.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage11(card As String)
        Me.Img11.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage12(card As String)
        Me.Img12.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage20(card As String)
        Me.Img20.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage21(card As String)
        Me.Img21.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage22(card As String)
        Me.Img22.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage30(card As String)
        Me.Img30.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage31(card As String)
        Me.Img31.Source = GetCardImage(card)
    End Sub

    Public Sub SetImage32(card As String)
        Me.Img32.Source = GetCardImage(card)
    End Sub

    Private Function GetCardImage(name As String)

        Select Case name
            Case "Apple"
                Dim src As Uri = New Uri("\Images\apple.png", UriKind.Relative)
                Return New BitmapImage(src)
            Case "Banana"
                Dim src As Uri = New Uri("\Images\banana.png", UriKind.Relative)
                Return New BitmapImage(src)
            Case "Cherry"
                Dim src As Uri = New Uri("\Images\cherry.png", UriKind.Relative)
                Return New BitmapImage(src)
            Case "Orange"
                Dim src As Uri = New Uri("\Images\orange.png", UriKind.Relative)
                Return New BitmapImage(src)
            Case "Pineapple"
                Dim src As Uri = New Uri("\Images\pineapple.png", UriKind.Relative)
                Return New BitmapImage(src)
            Case "Strawberry"
                Dim src As Uri = New Uri("\Images\strawberry.png", UriKind.Relative)
                Return New BitmapImage(src)
            Case Else
                Return vbNullChar
        End Select
    End Function

    Private Function GetCardImageName(card As String)

        Select Case card
            Case "Btn00"
                Return CardPlacement(0)
            Case "Btn01"
                Return CardPlacement(1)
            Case "Btn02"
                Return CardPlacement(2)
            Case "Btn10"
                Return CardPlacement(3)
            Case "Btn11"
                Return CardPlacement(4)
            Case "Btn12"
                Return CardPlacement(5)
            Case "Btn20"
                Return CardPlacement(6)
            Case "Btn21"
                Return CardPlacement(7)
            Case "Btn22"
                Return CardPlacement(8)
            Case "Btn30"
                Return CardPlacement(9)
            Case "Btn31"
                Return CardPlacement(10)
            Case "Btn32"
                Return CardPlacement(11)
        End Select
    End Function

    Private Sub FoundAMatch(card As String)
        Select Case card
            Case "Btn00"
                isCardMatched(0) = True
            Case "Btn01"
                isCardMatched(1) = True
            Case "Btn02"
                isCardMatched(2) = True
            Case "Btn10"
                isCardMatched(3) = True
            Case "Btn11"
                isCardMatched(4) = True
            Case "Btn12"
                isCardMatched(5) = True
            Case "Btn20"
                isCardMatched(6) = True
            Case "Btn21"
                isCardMatched(7) = True
            Case "Btn22"
                isCardMatched(8) = True
            Case "Btn30"
                isCardMatched(9) = True
            Case "Btn31"
                isCardMatched(10) = True
            Case "Btn32"
                isCardMatched(11) = True
        End Select
    End Sub

End Class
