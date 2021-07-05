Public Partial Class LunchOrder
    Inherits System.Web.UI.Page

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsPostBack Then

        Else

            'Fill the main coarse for the dishes for the selected date
            ReloadDataToScreen()
        End If

    End Sub

    Private Sub ReloadDataToScreen()

        'Load the main dish combo
        clsDBAccess.Fill_LO_DropDownLists(Me.ddlMainDish, cdrActionDate.SelectedDate.Day, 1)

        'Load the side dish 1 combo
        clsDBAccess.Fill_LO_DropDownLists(Me.ddlSideDish1, cdrActionDate.SelectedDate.Day, 2)

        'Load the side dish 2 combo
        clsDBAccess.Fill_LO_DropDownLists(Me.ddlSideDish2, cdrActionDate.SelectedDate.Day, 3)

        'Load the salad 1 combo
        clsDBAccess.Fill_LO_DropDownLists(Me.ddlSalad2, cdrActionDate.SelectedDate.Day, 4)

        'Load the salad 2 combo
        clsDBAccess.Fill_LO_DropDownLists(Me.ddlSalad2, cdrActionDate.SelectedDate.Day, 4)

    End Sub

End Class