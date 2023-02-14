'Isabella Dougherty
'RCET0265
'Spring 2023
'Shuffle The Deck
'https://github.com/IsabellaDougherty/ShuffleTheDeck.git


Imports System

Module ShuffleTheDeck
    Sub Main()
        Dim deck(3, 12) As String
        Dim list(51) As String
        Dim shuffling(51) As String
        Dim temp As String
        Dim iteration As Integer = 0
        Dim random As New Random()
        Dim value As String
        Dim row As Integer
        Dim column As Integer

        'Goes through and assigns each slot in the deck array as an individual card for each
        'card in a standard 52 card deck
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

        'Iterates through the deck and assigns each value into the 1D array of shuffling
        For i = 0 To 3
            For j = 0 To 12
                'list(iteration) = deck(i, j)
                shuffling(iteration) = deck(i, j)
                iteration += 1
            Next
        Next
        iteration = 0

        'Swaps values between shuffling
        For i = 0 To 51
            value = random.Next(0, 51)
            temp = shuffling(i)
            shuffling(i) = shuffling(value)
            shuffling(value) = temp
        Next
        'Reassigns the shuffling array to the deck array
        For i = 0 To 3
            For j = 0 To 12
                deck(i, j) = shuffling(iteration)
                iteration += 1
            Next
        Next
        'Iterates through the deck array and prints it out nicely so the entire deck is visible
        For i = 0 To 3
            For j = 0 To 12
                Console.Write(deck(i, j) & " | ")
            Next
            Console.WriteLine()
            Console.WriteLine("-----------------------------------------------------------------")
            Console.WriteLine()
        Next
        'Draws a random card
        row = random.Next(0, 3)
        column = random.Next(0, 12)
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine(deck(row, column))
    End Sub
End Module
