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

    Partial Public Class VistaPedidos
        Inherits XPLiteObject
        Dim fIdPedido As Integer
        <Key()>
        Public Property IdPedido() As Integer
            Get
                Return fIdPedido
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdPedido", fIdPedido, value)
            End Set
        End Property
        Dim fFechaPedido As DateTime
        Public Property FechaPedido() As DateTime
            Get
                Return fFechaPedido
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FechaPedido", fFechaPedido, value)
            End Set
        End Property
        Dim fResponsable As String
        <Size(200)>
        Public Property Responsable() As String
            Get
                Return fResponsable
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Responsable", fResponsable, value)
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
        Dim fSector As String
        <Size(80)>
        Public Property Sector() As String
            Get
                Return fSector
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Sector", fSector, value)
            End Set
        End Property
        Dim fEstado As String
        <Size(50)>
        Public Property Estado() As String
            Get
                Return fEstado
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Estado", fEstado, value)
            End Set
        End Property
    End Class

End Namespace