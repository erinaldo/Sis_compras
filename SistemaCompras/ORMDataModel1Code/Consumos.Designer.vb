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

    Partial Public Class Consumos
        Inherits XPLiteObject
        Dim fIdConsumo As Integer
        <Key(True)>
        Public Property IdConsumo() As Integer
            Get
                Return fIdConsumo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdConsumo", fIdConsumo, value)
            End Set
        End Property
        Dim fSector As String
        <Size(50)>
        Public Property Sector() As String
            Get
                Return fSector
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Sector", fSector, value)
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
        Dim fFecha As DateTime
        Public Property Fecha() As DateTime
            Get
                Return fFecha
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Fecha", fFecha, value)
            End Set
        End Property
        Dim fMotivo As String
        <Size(SizeAttribute.Unlimited)>
        Public Property Motivo() As String
            Get
                Return fMotivo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Motivo", fMotivo, value)
            End Set
        End Property
        Dim fStockeado As Integer
        Public Property Stockeado() As Integer
            Get
                Return fStockeado
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Stockeado", fStockeado, value)
            End Set
        End Property
    End Class

End Namespace