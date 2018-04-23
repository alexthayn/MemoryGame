Public Class Model
    Private cards As String() = {"Apple", "Apple", "Banana", "Banana", "Cherry", "Cherry",
        "Orange", "Orange", "Strawberry", "Strawberry", "Pineapple", "Pineapple"}

    Public Sub New()
        ShuffleCards()
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
                'Temporarily store the string at this index
                Dim temp As String = cards(index)
                cards(index) = cards(rand(index))
                cards(rand(index)) = temp
            End If
        Next

        For index As Integer = 0 To 11
            'If they aren't the same index, switch the cards
            If (rand(index) <> index) Then
                'Temporarily store the string at this index
                Dim temp As String = cards(index)
                cards(index) = cards(rand(index))
                cards(rand(index)) = temp
            End If
        Next

        For Each value As String In cards
            Console.WriteLine(value)
        Next
    End Sub
End Class
