Imports System
Imports System.IO

Module Program
    Dim Password As String

    Sub Choices()
        Console.WriteLine("1. Enter a new password.")
        Console.WriteLine("2. Check your password.")
        Console.WriteLine("3. Change your password.")
        Console.WriteLine("4. Quit.")
    End Sub
    Sub PasswordInput()
        Dim Numbers(9) As String
        Numbers = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim CorrectLength, NoSpaces, UpperCasePresent, DigitPresent As Boolean
        FileOpen(1, "Password.txt", OpenMode.Output)
        Do
            CorrectLength = False
            NoSpaces = False
            UpperCasePresent = False
            DigitPresent = False
            Console.Write("Enter Password: ")
            Password = Console.ReadLine()
            If Password.Length >= 10 And Password.Length <= 20 Then
                CorrectLength = True
            End If
            For CheckCounter = 0 To Password.Length - 1
                If Password.Substring(CheckCounter, 1) <> " " Then
            For CheckCounter = 0 To Password.Length - 1
                If Password.Substring(CheckCounter, 1) <> " " Then
                    NoSpaces = True
                End If
                if Password.Substring(CheckCounter,1)=ucase(Password.Substring(CheckCounter,1)) Then
                    UpperCasePresent=True
                end if
                for DigitCounter=0 to 9
                    if Password.Substring(CheckCounter,1)=Numbers(DigitCounter) Then
                    DigitPresent=True
                    end if
                Next
            Next
        Loop Until CorrectLength And NoSpaces And UpperCasePresent And DigitPresent
        PrintLine(1, Password)
        FileClose(1)
    End Sub
    Sub Main()
        Dim ChoiceOption As Integer
        Do
            Call Choices()
            ChoiceOption = 0
            While ChoiceOption > 4 Or ChoiceOption < 1
                Console.Write("Enter your choice: ")
                ChoiceOption = Console.ReadLine
            End While
            Select Case ChoiceOption
                Case 1
                    Call PasswordInput()
                Case 2
                Case 3
            End Select
        Loop Until ChoiceOption = 4
    End Sub
End Module