'Isabella Dougherty
'RCET0265
'Spring 2023
'Shuffle The Deck
'https://github.com/IsabellaDougherty/ShuffleTheDeck.git

Option Explicit On
Option Strict On

Imports System
Imports System.ComponentModel.Design
Imports System.Data.Common

Module ShuffleTheDeck
    Sub Main()
        Dim deck(3, 12) As String
        Dim list(51) As String
        Dim shuffling(51) As String
        Dim reshuffle As Boolean = False
        Dim userInput As String = ""
        Dim temp As String
        Dim value As String

        CreateDeck(deck)
        Reassign(shuffling, deck)
        Shuffle(shuffling)
        ShuffledDeck(deck, shuffling)
        'PrintDeck(deck)
        Console.WriteLine("Press Enter to draw a card! Input anything at any time to quit")
        userInput = Console.ReadLine()
        While userInput = ""
            If reshuffle = True Then
                Shuffle(shuffling)
                ShuffledDeck(deck, shuffling)
                reshuffle = False
            Else
                reshuffle = DrawCard(deck)
            End If
            userInput = Console.ReadLine()
        End While
        Console.WriteLine("Have a good day!")
    End Sub

    'Goes through and assigns each slot in the deck array as an individual card for each
    'card in a standard 52 card deck
    Sub CreateDeck(deck(,) As String)
        For i = 0 To 3
            For j = 0 To 12
                Select Case j
                    Case 0
                        deck(i, j) = "A"
                    Case 1
                        deck(i, j) = "2"
                    Case 2
                        deck(i, j) = "3"
                    Case 3
                        deck(i, j) = "4"
                    Case 4
                        deck(i, j) = "5"
                    Case 5
                        deck(i, j) = "6"
                    Case 6
                        deck(i, j) = "7"
                    Case 7
                        deck(i, j) = "8"
                    Case 8
                        deck(i, j) = "9"
                    Case 9
                        deck(i, j) = "10"
                    Case 10
                        deck(i, j) = "J"
                    Case 11
                        deck(i, j) = "Q"
                    Case 12
                        deck(i, j) = "K"
                End Select
                Select Case i
                    Case 0
                        deck(i, j) += "♥"
                    Case 1
                        deck(i, j) += "♣"
                    Case 2
                        deck(i, j) += "♠"
                    Case 3
                        deck(i, j) += "♦"
                End Select
            Next
        Next
    End Sub

    'Iterates through the deck and assigns each value into the 1D array of shuffling
    Sub Reassign(shuffling() As String, deck(,) As String)
        Dim iteration As Integer = 0
        For i = 0 To 3
            For j = 0 To 12
                shuffling(iteration) = deck(i, j)
                iteration += 1
            Next
        Next
    End Sub

    'Uses a simple swapping method to swap the values of the cards around
    Sub Shuffle(deck() As String)
        Dim value As Integer
        Dim temp As String
        Static count As Integer = 0
        Dim random As New Random()
        For i = 0 To 51
            value = random.Next(0, 51)
            temp = deck(count)
            deck(count) = deck(value)
            deck(value) = temp
        Next
    End Sub

    'Reassigns the shuffling array to the deck array
    Sub ShuffledDeck(deck(,) As String, shuffling() As String)
        Dim iteration As Integer = 0
        For i = 0 To 3
            For j = 0 To 12
                deck(i, j) = shuffling(iteration)
                iteration += 1
            Next
        Next
    End Sub

    'Iterates through the deck array and prints it out nicely so the entire deck is visible
    Sub PrintDeck(deck(,) As String)
        For i = 0 To 3
            For j = 0 To 12
                Console.Write(deck(i, j) & " | ")
            Next
            Console.WriteLine()
            Console.WriteLine("-----------------------------------------------------------------")
            Console.WriteLine()
        Next
    End Sub

    'Draws a random card and makes sure said card has not already been pulled
    Function DrawCard(deck(,) As String) As Boolean
        Static row As Integer
        Static column As Integer
        Static iterate As Integer
        Static initiate As Boolean = False
        Dim remake As Boolean = False
        initiate = True
        Try
            Console.WriteLine(deck(row, column))

            If column < 12 Then
                column += 1
            ElseIf column = 12 And row <= 3 Then
                column = 0
                row += 1
            End If
        Catch ex As Exception
            remake = True
        End Try
        If remake Then
            row = 0
            column = 0
            Console.WriteLine("Reshuffling...
...
...
Complete!
")
            Return True
        Else
            Return False
        End If
    End Function

End Module
