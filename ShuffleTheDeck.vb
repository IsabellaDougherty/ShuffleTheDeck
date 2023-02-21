'Isabella Dougherty
'RCET0265
'Spring 2023
'Shuffle The Deck
'https://github.com/IsabellaDougherty/ShuffleTheDeck.git


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
                Console.WriteLine("Reshuffling the deck. Please hold...")
                Console.WriteLine("...")
                Shuffle(shuffling)
                Console.WriteLine("...")
                ShuffledDeck(deck, shuffling)
                Console.WriteLine("...")
                Console.WriteLine("Reshuffling complete!")
            Else
                DrawCard(deck, reshuffle)
            End If
            userInput = Console.ReadLine()
        End While
        Console.WriteLine("Have a good day!")
    End Sub

    'Goes through and assigns each slot in the deck array as an individual card for each
    'card in a standard 52 card deck
    Sub CreateDeck(deck(,))
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
    Sub Reassign(shuffling(), deck(,))
        Dim iteration As Integer = 0
        For i = 0 To 3
            For j = 0 To 12
                shuffling(iteration) = deck(i, j)
                iteration += 1
            Next
        Next
    End Sub

    'Uses a simple swapping method to swap the values of the cards around
    Function Shuffle(deck())
        Dim value As String
        Dim temp As String
        Static count As Integer = 0
        Dim random As New Random()
        For i = 0 To 51
            value = random.Next(0, 51)
            temp = deck(count)
            deck(count) = deck(value)
            deck(value) = temp
        Next
        Return deck
    End Function

    'Reassigns the shuffling array to the deck array
    Sub ShuffledDeck(deck, shuffling)
        Dim iteration As Integer = 0
        For i = 0 To 3
            For j = 0 To 12
                deck(i, j) = shuffling(iteration)
                iteration += 1
            Next
        Next
    End Sub

    'Iterates through the deck array and prints it out nicely so the entire deck is visible
    Sub PrintDeck(deck(,))
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
    Sub DrawCard(deck(,), reshuffle)
        Static drawn(3, 12) As Boolean
        Static count As Integer
        Dim remake As Boolean = False
        Dim row As Integer
        Dim column As Integer
        Dim random As New Random()

        row = random.Next(0, 3)
        column = random.Next(0, 12)

        Try
            While drawn(row, column) = True Or count < 51
                If count < 51 Then
                    row = random.Next(0, 3)
                    column = random.Next(0, 12)
                    count += 1
                Else
                    remake = True
                End If
            End While
        Catch ex As Exception
            Console.WriteLine("FAILURE")
        End Try
        If remake = False Then
            drawn(row, column) = True
            Console.WriteLine(deck(row, column))
        Else
            Console.WriteLine("Remaking")
            For i = 0 To 3
                For j = 0 To 12
                    drawn(i, j) = False
                Next
            Next
            reshuffle = True
        End If
    End Sub

End Module
