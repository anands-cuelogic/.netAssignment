Namespace Model
    Public Class TreeBud
        Public Property Name As String

        Public Property Path As String

        Public Property Type As TreeBudType

        Public TreeBuds As List(Of TreeBud) = New List(Of TreeBud)

        Public Sub Add(node As TreeBud)
            TreeBuds.Add(node)
        End Sub
    End Class

    Public Enum TreeBudType
        Root
        Directory
        File
    End Enum

End Namespace
