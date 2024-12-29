Imports System
Imports System.Security.Cryptography

Public Class SequentialGUID
    Private Shared ReadOnly RandomGenerator As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()

    Public Shared Function Create(ByVal guidType As SequentialGuidType) As Guid
        Dim randomBytes As Byte() = New Byte(9) {}
        SequentialGUID.RandomGenerator.GetBytes(randomBytes)

        Dim timestamp As Long = DateTime.UtcNow.Ticks / 10000L

        Dim timestampBytes As Byte() = BitConverter.GetBytes(timestamp)

        If BitConverter.IsLittleEndian Then
            Array.Reverse(timestampBytes)
        End If

        Dim guidBytes As Byte() = New Byte(15) {}

        Select Case guidType
            Case SequentialGuidType.SequentialAsString, SequentialGuidType.SequentialAsBinary

                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6)
                Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10)

                If guidType = SequentialGuidType.SequentialAsString AndAlso BitConverter.IsLittleEndian Then
                    Array.Reverse(guidBytes, 0, 4)
                    Array.Reverse(guidBytes, 4, 2)
                End If

                Exit Select

            Case SequentialGuidType.SequentialAtEnd

                Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10)
                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6)
                Exit Select
        End Select

        Return New Guid(guidBytes)
    End Function


End Class

