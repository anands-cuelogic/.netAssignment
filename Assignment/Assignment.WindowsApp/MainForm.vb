Imports System.Windows.Forms
Imports System.IO
Imports System
Imports Assignment.WindowsApp.Model

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim dialogOpenFolder As FolderBrowserDialog = New FolderBrowserDialog
        If dialogOpenFolder.ShowDialog = DialogResult.OK Then
            Dim tree = CreateTreeBud(dialogOpenFolder.SelectedPath, TreeBudType.Root)
            GetDirectoryContent(tree)
            DisplayTree(tree)
            FillTree(tree)
        End If
    End Sub

    Private Sub FillTree(tree As TreeBud)
        Dim root = CreateTreeNode(Nothing, tree)
        TreeView.Nodes.Clear()
        TreeView.Nodes.Add(root)
    End Sub

    Private Function CreateTreeNode(parent As TreeNode, tree As TreeBud) As TreeNode
        Dim treeItem As TreeNode = New TreeNode(tree.Name)
        treeItem.ImageKey = tree.Path
        If tree.Type = TreeBudType.File Then

        End If
        If (tree.TreeBuds.Count > 0) Then
            For Each item In tree.TreeBuds
                treeItem.Nodes.Add(CreateTreeNode(treeItem, item))
            Next
        End If
        Return treeItem
    End Function

    Private Shared Sub DisplayTree(tree As TreeBud)
        For Each item In tree.TreeBuds
            Console.WriteLine(item.Name)
            If (item.TreeBuds.Count > 0) Then
                DisplayTree(item)
            End If
        Next
    End Sub

    Private Sub GetDirectoryContent(node As TreeBud)
        If Directory.Exists(node.Path) Then
            For Each item As String In Directory.EnumerateFileSystemEntries(node.Path)
                If Directory.Exists(item) Then
                    Dim child = CreateTreeBud(item, TreeBudType.Directory)
                    node.Add(child)
                    GetDirectoryContent(child)
                Else
                    node.Add(CreateTreeBud(item, TreeBudType.File))
                End If
            Next
        End If
    End Sub

    Private Function CreateTreeBud(item As String, type As TreeBudType) As TreeBud
        Dim node = New TreeBud()
        node.Name = item.Split("\").Last()
        node.Path = item
        node.Type = type
        Return node
    End Function

    Private Sub TreeView_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView.NodeMouseDoubleClick

        If (e.Node.LastNode Is Nothing And File.Exists(e.Node.FullPath)) Then
            Dim fileEventObj As New DynamicEvent
            AddHandler fileEventObj.FileClicked, AddressOf FileClick_Event
            fileEventObj.OnFileClicked(e.Node.FullPath)
        End If
    End Sub

    Private Sub FileClick_Event(fileName As String)
        Dim content As String = ""
        Try
            Using textReader As New StreamReader(fileName)
                content = textReader.ReadToEnd
            End Using
            TextBox1.Text = content
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Sub

    Private Sub FileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem1.Click
        Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
        Try
            If openFileDialog.ShowDialog <> DialogResult.Cancel Then
                Dim editForm As New Edit
                editForm.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

Public Class DynamicEvent
    Public Event FileClicked(fileName As String)

    Public Sub OnFileClicked(fileName As String)
        RaiseEvent FileClicked(fileName)
    End Sub

End Class
