Imports System.Text
Imports System.IO

''' <summary>
''' A class for encript\decript a string based on a constant private
''' encryption key (see keys() and ivb())
''' </summary>
''' <remarks></remarks>
Friend Class clsHashEncrypt

#Region " Private class declaration"
    'Set the empty password replacment for encryption
    Private Const strEmptyPassword As String = "NO_P@$$word"

    'Set up the keys, these are used for both encryption and decryption
    Private Shared keyb() As Byte = {1, 253, 5, 50, 52, 91, 193, 133, 193, 121, 221, 164, 57, 128, 91, 91, 19, 39, 111, 197, 125, 98, 89, 48, 97, 154, 83, 187, 222, 167, 171, 74}
    Private Shared ivb() As Byte = {10, 61, 235, 120, 122, 120, 80, 248, 13, 182, 196, 212, 176, 46, 23, 85}
#End Region

#Region "Class Constructor"

    Shared Sub New()

    End Sub

#End Region

#Region " Class Functions"

    Private Shared Function ConvertStringToByteArray(ByVal s As [String]) As [Byte]()
        Return (New UnicodeEncoding).GetBytes(s)
    End Function

    Shared Function EncodeString(ByVal str As String) As String
        '*************************************************************************
        '* Function Name:   EncodeString
        '* Description:     Shared function for encoding a given string
        '* Created by:      Erez Yaron
        '* Created date:    17/02/2004
        '* Last Modifyer:   Erez Yaron
        '*************************************************************************

        ' Set up the streams and stuff 
        Dim ms As New MemoryStream
        Dim cs As System.Security.Cryptography.CryptoStream
        Dim encodedBytes() As Byte
        Dim outStr As String = String.Empty

        'Set the empty password replacement, if needed
        If str.Length = 0 Then str = strEmptyPassword

        Try
            Dim rv As New System.Security.Cryptography.RijndaelManaged
            cs = New System.Security.Cryptography.CryptoStream(ms, rv.CreateEncryptor(keyb, ivb), System.Security.Cryptography.CryptoStreamMode.Write)
            Dim p() As Byte = Encoding.ASCII.GetBytes(str.ToCharArray())

            'Write to stream as encrypted(data)
            cs.Write(p, 0, p.Length)
            cs.FlushFinalBlock()
            cs.Close()

            'Convert the stream to something we can use
            encodedBytes = ms.ToArray

            'Get the converted string
            outStr = Convert.ToBase64String(encodedBytes)

        Catch ex As Exception
            'Throw the exception to the callre class
            Throw ex

        Finally
            ms.Close()
        End Try

        'Return the encripted string
        Return outStr

    End Function

    Shared Function DecodeString(ByVal str As String) As String
        '*************************************************************************
        '* Function Name:   EncodeString
        '* Description:     Shared function for encoding a given string
        '* Created by:      Erez Yaron
        '* Created date:    17/02/2004
        '* Last Modifyer:   Erez Yaron
        '*************************************************************************
        If str Is Nothing Then str = EncodeString(strEmptyPassword)
        Dim p() As Byte = Convert.FromBase64String(str)
        Dim initialText(p.Length) As Byte
        Dim rv As New System.Security.Cryptography.RijndaelManaged
        Dim ms As New MemoryStream(p)
        Dim cs As System.Security.Cryptography.CryptoStream

        Try
            cs = New System.Security.Cryptography.CryptoStream(ms, rv.CreateDecryptor(keyb, ivb), System.Security.Cryptography.CryptoStreamMode.Read)
            cs.Read(initialText, 0, initialText.Length)
            cs.Flush()
            cs.Close()
        Catch ex As Exception
            'Throw the exception to the callre class
            Throw ex
        Finally
            ms.Close()
        End Try

        Dim sb As New StringBuilder
        Dim i As Integer

        Dim b As Byte
        For i = 0 To initialText.Length() - 1
            b = initialText(i)
            'The encryption pads with NULLs, break so the aren't added to the string!
            If (b = 0) Then
                Exit For
            End If
            sb.Append(Convert.ToChar(b))
        Next

        'Check for empty password
        If sb.ToString = strEmptyPassword Then Return String.Empty

        'Not an empty password, return the decoded password
        Return sb.ToString()

    End Function

#End Region

End Class