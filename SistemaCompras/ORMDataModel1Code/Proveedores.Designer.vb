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

    Partial Public Class Proveedores
        Inherits XPLiteObject
        Dim fIdProveedor As Integer
        <Key(True)>
        Public Property IdProveedor() As Integer
            Get
                Return fIdProveedor
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdProveedor", fIdProveedor, value)
            End Set
        End Property
        Dim fCUIT_CUIL As String
        <Size(15)>
        Public Property CUIT_CUIL() As String
            Get
                Return fCUIT_CUIL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUIT_CUIL", fCUIT_CUIL, value)
            End Set
        End Property
        Dim fRazonSocial As String
        <Size(80)>
        Public Property RazonSocial() As String
            Get
                Return fRazonSocial
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RazonSocial", fRazonSocial, value)
            End Set
        End Property
        Dim fNombreFantasia As String
        <Size(80)>
        Public Property NombreFantasia() As String
            Get
                Return fNombreFantasia
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NombreFantasia", fNombreFantasia, value)
            End Set
        End Property
        Dim fFechaAlta As DateTime
        Public Property FechaAlta() As DateTime
            Get
                Return fFechaAlta
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FechaAlta", fFechaAlta, value)
            End Set
        End Property
        Dim fTelefonos As String
        <Size(200)>
        Public Property Telefonos() As String
            Get
                Return fTelefonos
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Telefonos", fTelefonos, value)
            End Set
        End Property
        Dim fDomicilio As String
        <Size(150)>
        Public Property Domicilio() As String
            Get
                Return fDomicilio
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Domicilio", fDomicilio, value)
            End Set
        End Property
        Dim fLocalidad As String
        <Size(80)>
        Public Property Localidad() As String
            Get
                Return fLocalidad
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Localidad", fLocalidad, value)
            End Set
        End Property
        Dim fCP As String
        <Size(13)>
        Public Property CP() As String
            Get
                Return fCP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CP", fCP, value)
            End Set
        End Property
        Dim fProvincia As String
        <Size(50)>
        Public Property Provincia() As String
            Get
                Return fProvincia
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Provincia", fProvincia, value)
            End Set
        End Property
        Dim fPais As String
        <Size(50)>
        Public Property Pais() As String
            Get
                Return fPais
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Pais", fPais, value)
            End Set
        End Property
        Dim fEmail As String
        <Size(50)>
        Public Property Email() As String
            Get
                Return fEmail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", fEmail, value)
            End Set
        End Property
        Dim fPaginaWeb As String
        <Size(50)>
        Public Property PaginaWeb() As String
            Get
                Return fPaginaWeb
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PaginaWeb", fPaginaWeb, value)
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
        Dim fRubro As String
        <Size(50)>
        Public Property Rubro() As String
            Get
                Return fRubro
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Rubro", fRubro, value)
            End Set
        End Property
    End Class

End Namespace