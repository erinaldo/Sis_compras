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

    Partial Public Class RemitoRecepcion
        Inherits XPLiteObject
        Dim fRemitoNro As Integer
        <Key()>
        Public Property RemitoNro() As Integer
            Get
                Return fRemitoNro
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RemitoNro", fRemitoNro, value)
            End Set
        End Property
        Dim fIdProveedor As Integer
        Public Property IdProveedor() As Integer
            Get
                Return fIdProveedor
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdProveedor", fIdProveedor, value)
            End Set
        End Property
        Dim fFechaRecepcion As DateTime
        Public Property FechaRecepcion() As DateTime
            Get
                Return fFechaRecepcion
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FechaRecepcion", fFechaRecepcion, value)
            End Set
        End Property
        Dim fFacturaNro As String
        <Size(30)>
        Public Property FacturaNro() As String
            Get
                Return fFacturaNro
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FacturaNro", fFacturaNro, value)
            End Set
        End Property
        Dim fResponsable As String
        <Size(150)>
        Public Property Responsable() As String
            Get
                Return fResponsable
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Responsable", fResponsable, value)
            End Set
        End Property
        Dim fOrdenCompraNro As String
        <Size(20)>
        Public Property OrdenCompraNro() As String
            Get
                Return fOrdenCompraNro
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("OrdenCompraNro", fOrdenCompraNro, value)
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