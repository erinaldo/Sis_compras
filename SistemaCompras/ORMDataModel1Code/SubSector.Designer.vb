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

    Partial Public Class SubSector
        Inherits XPLiteObject
        Dim fIdSubSector As Integer
        <Key(True)>
        Public Property IdSubSector() As Integer
            Get
                Return fIdSubSector
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdSubSector", fIdSubSector, value)
            End Set
        End Property
        Dim fIdSector As Integer
        Public Property IdSector() As Integer
            Get
                Return fIdSector
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdSector", fIdSector, value)
            End Set
        End Property
        Dim fSubSector1 As String
        <Size(80)>
        <Persistent("SubSector")>
        Public Property SubSector1() As String
            Get
                Return fSubSector1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SubSector1", fSubSector1, value)
            End Set
        End Property
        Dim fObservacionesSS As String
        <Size(80)>
        Public Property ObservacionesSS() As String
            Get
                Return fObservacionesSS
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ObservacionesSS", fObservacionesSS, value)
            End Set
        End Property
    End Class

End Namespace
