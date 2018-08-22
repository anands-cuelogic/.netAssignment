Public Class Fruit
    Private fruitList As ArrayList

    Public Sub AddFruit(name As ArrayList)
        fruitList = name
    End Sub

    Public Function GetFruit() As ArrayList
        Return fruitList
    End Function

    Public Sub Display()
        Dim name As String
        For Each name In fruitList
            System.Console.WriteLine(name)
        Next
    End Sub

    Public Function FruitNameOccurence(fruitList1 As ArrayList, fruitList2 As ArrayList) As Dictionary(Of String, Integer)

        Dim Result As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        For Each firstFruitListName In fruitList1
            FruitNameMatch(firstFruitListName, Result)
        Next
        For Each secondFruitListName In fruitList2
            FruitNameMatch(secondFruitListName, Result)
        Next
        Return Result

    End Function

    Private Sub FruitNameMatch(fruitName As String, Result As Dictionary(Of String, Integer))
        Dim flag As Boolean = True
        For Each resultList As KeyValuePair(Of String, Integer) In Result
            If (fruitName = resultList.Key) Then
                flag = False
                Result(resultList.Key) += 1
                Exit For
            End If
        Next

        If (flag) Then
            Result.Add(fruitName, 1)
        End If
    End Sub

End Class
