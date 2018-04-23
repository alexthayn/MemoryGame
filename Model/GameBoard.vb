Public Class GameBoard
    Private cards(11) As String
    ' This function initializes the game 
    Public Sub SetupGame()
        'Assign initial values to each card
        cards(0) = cards(1) = "Apple"
        cards(2) = cards(3) = "Banana"
        cards(4) = cards(5) = "Cherry"
        cards(6) = cards(7) = "Orange"
        cards(8) = cards(9) = "Strawberry"
        cards(10) = cards(11) = "Pineapple"

        For index As Integer = 0 To 11
            Console.WriteLine("Cards " + index + "= " + cards(index))
        Next
    End Sub

    'This function shuffles the gameboard
    Public Sub ShuffleCards()
        Dim rand(11) As Integer
        For index As Integer = 0 To 11
            rand(index) = Int(Rnd() * 12)
        Next

        For index As Integer = 0 To 11
            'If they aren't the same index, switch the cards
            If (rand(index) <> index) Then
                Dim temp As String = rand(index)
                cards(index) = cards(rand(index))
                cards(rand(index)) = temp
            End If
        Next

        For index As Integer = 0 To 11
            Console.WriteLine("Shuffled Cards " + index + "= " + cards(index))
        Next
    End Sub
End Class
