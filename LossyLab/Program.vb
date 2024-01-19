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
        Dim CorrectLength, SpacesPresent, UpperCasePresent, DigitPresent As Boolean
        Dim Placeholder as Double
        FileOpen(1, "Password.txt", OpenMode.Output)
        
        Do
            CorrectLength = False
            SpacesPresent = False
            UpperCasePresent = False
            DigitPresent = False
            Console.Write("Enter Password: ")
            Password = Console.ReadLine()
            
            If Password.Length >= 10 And Password.Length <= 20 Then
                CorrectLength = True
            End If
            For CheckCounter = 0 To Password.Length-1
                    If Password.Substring(CheckCounter, 1) = " " Then
                        SpacesPresent =True
                    End If
                    if Not Double.TryParse(Password.Substring(CheckCounter,1),Placeholder) then 
                        if Password.Substring(CheckCounter,1)=ucase(Password.Substring(CheckCounter,1)) Then
                            UpperCasePresent=True
                        end if
                    end if
                    for DigitCounter=0 to 9
                        if Password.Substring(CheckCounter,1)=Numbers(DigitCounter) Then
                        DigitPresent=True
                        end if
                    Next
            Next
            If Not CorrectLength then
                Console.WriteLine("Your Password should be between 10 and 20 characters.")
            End If
            If SpacesPresent then
                Console.WriteLine("Your Password should not contain space.")
            End If
            If Not UpperCasePresent then
                Console.WriteLine("Your Password should have at least 1 Uppercase character.")
             End If
            If Not DigitPresent then
                Console.WriteLine("Your Password should have at least 1 numerical digit.")
            End If
        Loop Until CorrectLength And Not SpacesPresent And UpperCasePresent And DigitPresent

        PrintLine(1, Password)
        FileClose(1)
    End Sub

    Dim PasswordCorrect as Boolean
    Sub PasswordCheck()
        PasswordCorrect=False
        dim PasswordCheckInput as String
        Console.Write("Input Password for verification: ")
        PasswordCheckInput=Console.ReadLine
        FileOpen(1,"Password.txt",OpenMode.Input)
        if PasswordCheckInput = LineInput(1) then
            Console.WriteLine("Password is correct.")
            PasswordCorrect=True
        else
            Console.WriteLine("Password is incorrect.")
        end if
        FileClose(1)
    End Sub

    Sub PasswordChanging()
        Call PasswordCheck()
        If PasswordCorrect Then
            Call PasswordInput()
        End If
    End Sub

    Sub Main()
        Dim ChoiceOption As Integer
        Dim PasswordCreated As Boolean = False
        Do
            Call Choices()
            ChoiceOption = 0
            While ChoiceOption > 4 Or ChoiceOption < 1
                Console.Write("Enter your choice: ")
                ChoiceOption = Console.ReadLine
            End While
            Select Case ChoiceOption
                Case 1
                    If PasswordCreated=False Then
                        Call PasswordInput()
                        PasswordCreated=True
                    else
                        Console.WriteLine("Password has already been created, only changing and checking is allowed.")
                    End If
                Case 2
                    Call PasswordCheck()
                Case 3
                    Call PasswordChanging()
            End Select
        Loop Until ChoiceOption = 4
    End Sub

End Module