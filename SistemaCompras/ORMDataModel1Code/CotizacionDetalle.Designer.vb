﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace MontagneAdministracion

    Partial Public Class CotizacionDetalle
        Inherits XPLiteObject
        Dim fIdDetalleCot As Integer
        <Key(True)>
        Public Property IdDetalleCot() As Integer
            Get
                Return fIdDetalleCot
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdDetalleCot", fIdDetalleCot, value)
            End Set
        End Property
        Dim fIdCotizacion As Cotizaciones
        <Association("CotizacionDetalleReferencesCotizaciones")>
        Public Property IdCotizacion() As Cotizaciones
            Get
                Return fIdCotizacion
            End Get
            Set(ByVal value As Cotizaciones)
                SetPropertyValue(Of Cotizaciones)("IdCotizacion", fIdCotizacion, value)
            End Set
        End Property
        Dim fIdProducto As Integer
        Public Property IdProducto() As Integer
            Get
                Return fIdProducto
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdProducto", fIdProducto, value)
            End Set
        End Property
        Dim fCantidad As Decimal
        Public Property Cantidad() As Decimal
            Get
                Return fCantidad
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Cantidad", fCantidad, value)
            End Set
        End Property
        Dim fObservaciones As String
        <Size(SizeAttribute.Unlimited)>
        Public Property Observaciones() As String
            Get
                Return fObservaciones
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Observaciones", fObservaciones, value)
            End Set
        End Property
    End Class

End Namespace
