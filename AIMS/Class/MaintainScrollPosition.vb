Public Class MaintainScrollPosition


    Private Shared vposition As Integer

    Private Shared hposition As Integer



    Shared Sub GetvSBarPos(ByVal dg As DataGridView)

        vposition = dg.FirstDisplayedScrollingRowIndex

    End Sub



    Shared Sub SetvSBarPos(ByVal dg As DataGridView)

        'dg.FirstDisplayedScrollingRowIndex() = vposition

        If vposition = -1 Then
            dg.FirstDisplayedScrollingRowIndex = 0
        Else
            dg.FirstDisplayedScrollingRowIndex = vposition
        End If
    End Sub



    Shared Sub GethSBarPos(ByVal dg As DataGridView)

        hposition = dg.FirstDisplayedScrollingColumnIndex

    End Sub



    Shared Sub SethSBarPos(ByVal dg As DataGridView)

        If hposition = -1 Then
            dg.FirstDisplayedScrollingColumnIndex = 1
        Else
            dg.FirstDisplayedScrollingColumnIndex = hposition
        End If

    End Sub

End Class

