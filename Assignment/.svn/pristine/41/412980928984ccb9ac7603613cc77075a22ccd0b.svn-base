
Module MainModule

    Sub Main()
        'MagicNumber()
        Dim fruitList = New ArrayList

        fruitList.Add("Apple")
        fruitList.Add("Banana")
        fruitList.Add("Pineapple")

        Dim fruitListObj1 As Fruit = New Fruit
        fruitListObj1.AddFruit(fruitList)


        Dim fruitList2 = New ArrayList

        fruitList2.Add("Apple")
        fruitList2.Add("Banana")
        fruitList2.Add("Orange")
        fruitList2.Add("Orange")

        Dim fruitListObj2 As Fruit = New Fruit
        fruitListObj2.AddFruit(fruitList2)

        System.Console.WriteLine("Occurence is")
        System.Console.WriteLine("Element" + vbTab + " Count")
        For Each result As KeyValuePair(Of String, Integer) In 
            New Fruit().FruitNameOccurence(fruitListObj1.GetFruit, fruitListObj2.GetFruit)
            System.Console.WriteLine(result.Key + vbTab + result.Value.ToString)
        Next

        System.Console.ReadKey()
    End Sub

    Private Sub MagicNumber()
        System.Console.WriteLine("Magic Number")
        For i As ULong = 1000 To 999999999
            Dim flag As Boolean = True
            Dim result As ULong = 0

            For j As ULong = 2 To 6
                result = Number.Generate(i, j)
                If (Number.Match(i, result) = False) Then
                    flag = False
                    Exit For
                End If
            Next

            If flag = True Then
                System.Console.WriteLine("The number is " + i.ToString)
            End If

        Next
    End Sub
End Module

Module Number
    Function Generate(number As ULong, factor As Integer) As ULong
        Return number * factor
    End Function

    Function Match(num As ULong, result As ULong) As Boolean
        Dim numChar() As Char = num.ToString.ToCharArray
        Dim resultChar() As Char = result.ToString.ToCharArray

        Array.Sort(numChar)
        Array.Sort(resultChar)

        If (numChar = resultChar) Then
            Return True
        End If
        Return False
    End Function


End Module

