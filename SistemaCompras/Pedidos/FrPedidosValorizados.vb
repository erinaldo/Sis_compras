﻿Imports System.Collections
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports SistemaCompras.MontagneAdministracion

Public Class FrPedidosValorizados


    Public Session1 As Session = XpoHelper.GetNewSession()
    Public Idpedido As Integer
    Dim report As New RpPedidos()
    Dim tool As ReportPrintTool = New ReportPrintTool(report)
    Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT * from Vistalistaprecios")
    
    Dim obs As String
   
    Private Sub FrMasterDetailPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pedidos.Session = Session1
        proyecto.Session = Session1
        DetallePedido.Session = Session1
        Sectores.Session = Session1
        Estados.Session = Session1
        Productos.Session = Session1
        PreciosProductos.Session = Session1
        proveedor.Session = Session1
        listadeprecios.Session = Session1
        impuestos.Session = session1
        Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT * from Vistalistaprecios")
        XpDataView1.LoadData(resultSet)
        'If Cotiza = 10 Then
        '    Pedidos.CriteriaString = "Estado = 8"
        '    SimpleButton3.Enabled = true
        '    SimpleButton6.Visible = false
        'End If
        If Cotiza = 3 Then
            Pedidos.CriteriaString = ("Estado = 7" & " And Sector = " & Sectorid)
            ComboBoxEdit1.Visible = True
            'ComboBoxEdit1.Enabled = false
            LabelControl2.Visible = True
            colPrecio.Visible = False
            colTotal.Visible = False
            colIdproveedor.Visible = False
            imprimirtodos.Visible = True
            'imprimirtodos.Enabled = false

        ElseIf Cotiza = 1 Then
            Pedidos.CriteriaString = "Estado = 1 and AutorizadoPor is not null"
            SimpleButton3.Visible = False
            SimpleButton4.Visible = False
            SimpleButton7.Visible = true
            SimpleButton6.Visible = false

        End If
       
        GridView5.Columns("GridColumn3").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "GridColumn3", "<Color=red>SUBTOTAL</color>={0}")
        GridView5.Columns("GridColumn5").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "GridColumn5", "<Color=red>TOTAL</color>={0}")

    End Sub
    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles GridControl1.EmbeddedNavigator.ButtonClick
        If Not GridControl1.FocusedView.IsDetailView Then
            If (e.Button.ButtonType = NavigatorButtonType.Append) Then
                GridView1.AddNewRow()
                GridView1.ShowEditForm()
            End If
            If (e.Button.ButtonType = NavigatorButtonType.Edit) Then
                GridView1.ShowEditForm()
            End If
        End If
    End Sub
    Private Sub GridView1_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
        If IsNothing(GridView1.GetFocusedRowCellValue(colSector)) Then
            Session1.ExecuteNonQuery("Delete Pedidos where IdPedido = " & CInt(GridView1.GetFocusedRowCellValue(colIdPedido)))
            Pedidos.Reload()
        End If
    End Sub
    Private Sub GridView2_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridView2.CustomUnboundColumnData
        Dim view As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "Total" AndAlso e.IsGetData Then
            ' e.Value = CBool(view.ActiveEditor.AccessibilityObject.Value).CompareTo(False)
            e.Value = CDbl(view.GetRowCellValue(e.ListSourceRowIndex, colCantidad)) * CDbl(view.GetRowCellValue(e.ListSourceRowIndex, colPrecio))
        End If
    End Sub
    Private Sub GridView2_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView2.RowCellClick
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        If e.Button.XButton1.Left And e.Column.Caption = "Producto" Then
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            XpDataView1.FilterString = "IdProducto = " & CInt(e.CellValue)
            pop1.Show()
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView2.SetFocusedRowCellValue(colPrecio, LookUpEdit1.EditValue)
        pop1.Hide()
    End Sub
    Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEdit1.EditValueChanged
        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue)
            Dim value As Object = row("IdProveedor")
            Dim detail As GridView = TryCast(GridView1.GetDetailView(GridView1.FocusedRowHandle, 0), GridView)
            detail.SetFocusedRowCellValue(colPrecio, LookUpEdit1.EditValue)
            detail.SetFocusedRowCellValue(colIdproveedor, value)
            pop1.Hide()
            LookUpEdit1.EditValue = Nothing
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        FrListasPrecios.Show()
        pop1.Hide()
    End Sub
    Private Sub Pop1VisibleChanged(sender As Object, e As EventArgs) Handles pop1.VisibleChanged
        Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT * from Vistalistaprecios")
        XpDataView1.LoadData(resultSet)
    End Sub
    Private Sub FrPedidosValorizados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Aprobar = 0
    End Sub
    Public Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'If GridView1.GetFocusedRowCellValue(colEstado) Then
        '    Session1.ExecuteQuery("UPDATE VistaPedidosDetalle SET Estado = 7 ")
        '    Pedidos.Reload()
        'End If
        ' Dim obs As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdDetalle)
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido1) Is Nothing Then
            MsgBox("Selecciona una fila para anular.")
        Else
            GridView1.SetFocusedRowCellValue(colEstado, 3)
            GridView1.SetFocusedRowCellValue(colObservaciones, "Anulado por " + Responsable + " el dia: " & Today & " a las: " & TimeOfDay)
            GridView1.UpdateCurrentRow()
        End If
    End Sub

    Public Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido) Is Nothing and Cotiza <> 10 Then
            MsgBox("Selecciona una fila para aprobar.")
        Else

            'If Cotiza = 10 Then 'martin

            '    GridView1.SetFocusedRowCellValue(colAutorizadoPor, Responsable)
            '    GridView1.SetFocusedRowCellValue(colEstado, 2)
            '    GridView1.SetFocusedRowCellValue(colFechaAprobacion, Today)
            '    GridView1.SetFocusedRowCellValue(colObservaciones, obs)
            '    GridView1.UpdateCurrentRow()
            '    Exit sub
            'End If
            GridView1.SetFocusedRowCellValue(colEstado, 2)
            GridView1.SetFocusedRowCellValue(colAutorizadoPor, ComboBoxEdit1.Text)
            GridView1.SetFocusedRowCellValue(colFechaAprobacion, Today)
            GridView1.SetFocusedRowCellValue(colObservaciones, obs)
            GridView1.UpdateCurrentRow()
            ComboBoxEdit1.Text = ""
            'ComboBoxEdit1.Enabled = false
        End If

    End Sub
    Public Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

        try
            If CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colObservaciones)).Contains("Anulado por ") Then

            Else
                obs = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colObservaciones)

            End If
        Catch ex As Exception
        End try
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colEstado) = 3 Then
            imprimirtodos.Enabled = False
        Else
            imprimirtodos.Enabled = True
        End If
        Try
            Dim consulta = GridView1.GetFocusedRowCellValue(colIdPedido)
            If consulta = 0 Then
            Else
                Try
                    DetallePedido.CriteriaString = "IdPedido = " & consulta '& " And Sector = " & Sectorid
                    Dim direccion = Session1.ExecuteScalar("Select DireccionDeEnvio from Pedidos where IdPedido = " & GridView1.GetFocusedRowCellValue(colIdPedido))
                    Dim direccionfisica = Session1.ExecuteScalar("Select Direccion from DireccionesEntrega where Id = " & direccion)
                    If direccion <> 0 then
                        dirlabel.Text = "Direccion de entrega: " & direccionfisica
                    Else
                        dirlabel.Text = ""
                    End if
                Catch ex As Exception
                End try
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Se produjo un error, consulte con soporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub GridView5_RowcellClick(sender As Object, e As RowClickEventArgs) Handles GridView5.RowCellClick

    End Sub
    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Dim view As GridView = sender
        Vencer = DateDiff(DateInterval.Day, Now.Date, GridView1.GetRowCellValue(e.RowHandle, colFechaRecepcion)) >= 15
        If Vencer = True Then
        Else
            e.Appearance.ForeColor = Color.DarkRed
        End If
        If (e.RowHandle >= 0) Then
            Dim urgente As String = view.GetRowCellDisplayText(e.RowHandle, view.Columns("Urgente"))
            If urgente = "Urgente" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.salmon
                e.Appearance.ForeColor = Color.White
            Else

            End If
        End If
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        FrListasPrecios.Show()

    End Sub
    Private Sub ComboBoxEdit1_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit1.TextChanged
        If ComboBoxEdit1.Text = "" Then
            SimpleButton3.Enabled = False
        Else
            SimpleButton3.Enabled = True
        End If

        '' borrar desde aca


        ' hasta aca
    End Sub

    Private Sub GridControl2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GridControl2.Validating
        'Dim idprov = Session1.ExecuteScalar("select RazonSocial from Vistalistaprecios where IdProveedor =" & RepositoryItemGridLookUpEdit8.GetDisplayValue(1))
        'MsgBox(idprov)
        'GridView5.SetFocusedValue(idprov)
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)
        Dim querylinq As New XPQuery(Of Productos)(Session1)

        FrProductos.Show()
    End Sub

    Private Sub sbimprimir_Click(sender As Object, e As EventArgs) Handles imprimirtodos.Click
        Dim report As New RpListaAprobar()
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        If GridView1.SelectedRowsCount = 1 Then
            Dim consulta = Session1.ExecuteScalar("Select IdPedido from VistaListaAprobar where IdPedido = " & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido))
            report.FilterString = "IdPedido = " & consulta & " And Sector = " & Sectorid
            tool.Report.ShowPreviewDialog()
            Pedidos.Reload()


        ElseIf GridView1.SelectedRowsCount > 1 Then
            Dim x As IList = GridView1.GetSelectedRows().ToList
            Dim stra As String
            For s = 0 To x.Count - 1

                Dim consulta = Session1.ExecuteScalar("Select IdPedido from VistaListaAprobar where IdPedido = " & GridView1.GetRowCellValue(x.Item(s), colIdPedido))
                stra = stra & " IdPedido = " & consulta & " or "
            Next
            stra = Mid(stra, 1, Len(stra) - 3) & " and Sector = " & Sectorid
            report.FilterString = stra
            tool.Report.ShowPreviewDialog()
            Pedidos.Reload()
        End If
        'ComboBoxEdit1.Enabled = true

    End Sub
    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Session1.ExecuteNonQuery("insert into PedidosDetalles (IdPedido, IdProducto, Cantidad) values (" & GridView1.GetFocusedRowCellValue(colidpedido) & ",'6764' ,'1')")
        DetallePedido.reload
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        
        
        'dim a = GridView5.GetFocusedRowCellValue(GridColumn3)             
        ' GridView5.SetFocusedRowCellValue(GridColumn5,a)
        'If GridView5.GetFocusedRowCellValue(GridColumn4) = "0" Then
        '    dim a = GridView5.GetFocusedRowCellValue(GridColumn3)
        '    GridView5.SetFocusedRowCellValue(GridColumn5, a)
        'End If
        'PreciosProductos.CriteriaString = "" 
        PreciosProductos.Reload
        impuestos.reload
    End Sub


    Private Sub GridView5_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView5.ShowingPopupEditForm
        
    End Sub

    Private Sub GridView5_ShownEditor(sender As Object, e As EventArgs) Handles GridView5.ShownEditor

    End Sub

    Private Sub GridView5_EditFormShowing(sender As Object, e As EditFormShowingEventArgs) Handles GridView5.EditFormShowing
        Try
            Dim filtro = GridView5.GetFocusedRowCellDisplayText(colIdProducto1)
            PreciosProductos.CriteriaString = "Producto like '" & filtro & "'"
        Catch exp As Exception

            MessageBox.Show(exp.Message, "Se produjo un error, consulte con soporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub GridView5_MouseMove(sender As Object, e As MouseEventArgs) Handles GridView5.MouseMove

    End Sub

    Private Sub GridView5_MouseLeave(sender As Object, e As EventArgs) Handles GridView5.MouseLeave

    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click

    End Sub

    'Private Sub GridView5_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView5.RowClick
    '     If GridView5.CloseEditForm = True Then
    '        Dim a = GridView5.GetFocusedRowCellValue(GridColumn5).ToString.Replace(",",".")
    '  '  MsgBox (a)
    '    Session1.ExecuteNonQuery("update PedidosDetalles set Total = "& a &"  Where IdDetalle = "& GridView5.GetFocusedRowCellValue(colIdDetalle1))
    '    a= Nothing
    '    End If
    'End Sub

    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
      If GridView5.CloseEditForm = True Then
            
            Dim a = GridView5.GetFocusedRowCellValue(GridColumn5).ToString.Replace(",",".")
      '  MsgBox (a)
        Session1.ExecuteNonQuery("update PedidosDetalles set Total = "& a &"  Where IdDetalle = "& GridView5.GetFocusedRowCellValue(colIdDetalle1))
        a= Nothing
        End If
           
    End Sub

    Private Sub GridView5_MasterRowCollapsed(sender As Object, e As CustomMasterRowEventArgs) Handles GridView5.MasterRowCollapsed
     
    End Sub

    Private Sub GridView5_DoubleClick(sender As Object, e As EventArgs) Handles GridView5.DoubleClick
           
    End Sub

    'Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
    '    If GridView1.SelectedRowsCount = 0 Then
    '        MsgBox("Selecciona una fila para iniciar el proceso de aprobacion manual", vbinformation)
    '    else

    '        simplebutton6.Enabled = False
    '        imprimirtodos.Enabled = True
    '        comboboxedit1.Enabled = false
    '        If ComboBoxEdit1.Text <> "" Then
    '            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido) Is Nothing Then
    '                MsgBox("Selecciona una fila para aprobar.")
    '            Else
    '                GridView1.SetFocusedRowCellValue(colEstado, 2)
    '                GridView1.SetFocusedRowCellValue(colAutorizadoPor, "Manual por " + ComboBoxEdit1.Text)
    '                GridView1.SetFocusedRowCellValue(colFechaAprobacion, Today)
    '                GridView1.SetFocusedRowCellValue(colObservaciones, obs)
    '                GridView1.UpdateCurrentRow()

    '                comboboxedit1.enabled = false
    '                comboboxedit1.text = ""
    '                imprimirtodos.Enabled = false
    '                SimpleButton6.Enabled = true
    '                GridView1.UpdateCurrentRow()
    '            End If
    '        End If
    '    End If
    'End Sub
End Class