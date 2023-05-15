
Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader
Imports System.Net.Security
Imports System.Xml
Imports WMPLib

Public Class Form1

    Dim selected As Label
    Dim selected2 As Label

    Dim white As Boolean

    Dim tmp As String

    Dim move As Boolean

    Dim player1 As String
    Dim player2 As String

    Dim start As Boolean

    Dim player As New WindowsMediaPlayer

    Dim valid As Boolean = False

    'pieces'
    Dim b_rook As String = "♜"
    Dim b_horse As String = "♞"
    Dim b_bishop As String = "♝"
    Dim b_king As String = "♚"
    Dim b_queen As String = "♛"
    Dim b_pawn As String = "♙"

    Dim rook As String = "♜"
    Dim horse As String = "♞"
    Dim bishop As String = "♝"
    Dim king As String = "♚"
    Dim queen As String = "♛"
    Dim pawn As String = "♙"
    'pieces'

    'moves'
    Dim enpassant As Boolean = False
    Dim castleleft As Boolean = False
    Dim castleright As Boolean = False
    Dim kingmoved, bkingmoved As Boolean
    Dim check As Boolean = False
    Dim b_check As Boolean = False
    Dim mate As Boolean = False
    Dim rook1, rook2, rook3, rook4 As Boolean
    Dim promote As Boolean = False
    Dim numofmoves As Integer = 0
    Dim tmpvar As Integer = 0
    Dim stalemate As Boolean = False

    Dim i, j, k, l As Integer
    Dim x3 As Integer
    Dim y3 As Integer

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles A2.Click

        mob(A2)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles A3.Click
        mob(A3)
    End Sub

    Private Sub checkmate()


        If check And white Then

            For Each control In Board.Controls
                Dim ctrl As Label = control

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = SystemColors.ControlLightLight Then

                        For Each label In Board.Controls
                            Dim ct As Label = label

                            If ct.Text = "" Or (Not (ct.Text = "") And ct.ForeColor = SystemColors.ActiveCaptionText) Then

                                moves(ctrl, ct)

                                'check moves'
                                Dim val2 As String = ct.Text
                                Dim val1 As String = ctrl.Text
                                Dim cl As Color = ctrl.ForeColor
                                Dim cl2 As Color = ct.ForeColor
                                If valid Then

                                    ct.Text = ctrl.Text
                                    ct.ForeColor = ctrl.ForeColor
                                    ctrl.Text = ""


                                    checkking()

                                    If check Then
                                        valid = False
                                    End If

                                    ct.Text = val2
                                    ctrl.Text = val1
                                    ctrl.ForeColor = cl
                                    ct.ForeColor = cl2

                                    If valid Then
                                        Exit For
                                    End If
                                End If
                                'check moves'
                            End If
                        Next

                        If valid Then
                            Exit For
                        End If
                    End If
                End If
            Next

            If Not valid Then
                mate = True
                player.controls.stop()
                Dim play As New WindowsMediaPlayer

                play.settings.volume = 100
                play.URL = "C:\Users\brixo\Downloads\matekapareh.mp3"

                MessageBox.Show("Mate Ka Pareh", "Pareh Naman", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                Dim play As New WindowsMediaPlayer

                play.settings.volume = 100
                play.URL = "C:\Users\brixo\Downloads\Check.mp3"
                valid = False
            End If

        ElseIf b_check And Not white Then
            For Each control In Board.Controls
                Dim ctrl As Label = control

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = SystemColors.ActiveCaptionText Then

                        For Each label In Board.Controls
                            Dim ct As Label = label

                            If ct.Text = "" Or (Not (ct.Text = "") And ct.ForeColor = SystemColors.ControlLightLight) Then

                                moves(ctrl, ct)

                                'check moves'
                                Dim val2 As String = ct.Text
                                Dim val1 As String = ctrl.Text
                                Dim cl As Color = ctrl.ForeColor
                                Dim cl2 As Color = ct.ForeColor
                                If valid Then

                                    ct.Text = ctrl.Text
                                    ct.ForeColor = ctrl.ForeColor
                                    ctrl.Text = ""


                                    checkking()

                                    If b_check Then
                                        valid = False
                                    End If

                                    ct.Text = val2
                                    ctrl.Text = val1
                                    ctrl.ForeColor = cl
                                    ct.ForeColor = cl2

                                    If valid Then
                                        Exit For
                                    End If
                                End If
                                'check moves'
                            End If
                        Next

                        If valid Then
                            Exit For
                        End If
                    End If
                End If
            Next

            If Not valid Then
                mate = True
                player.controls.stop()
                Dim play As New WindowsMediaPlayer

                play.settings.volume = 100
                play.URL = "C:\Users\brixo\Downloads\matekapareh.mp3"

                MessageBox.Show("Mate Ka Pareh", "Pareh Naman", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                Dim play As New WindowsMediaPlayer

                play.settings.volume = 100
                play.URL = "C:\Users\brixo\Downloads\Check.mp3"
                valid = False
            End If

        ElseIf Not check And white Then
            For Each control In Board.Controls
                Dim ctrl As Label = control

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = SystemColors.ControlLightLight Then

                        For Each label In Board.Controls
                            Dim ct As Label = label

                            If ct.Text = "" Or (Not (ct.Text = "") And ct.ForeColor = SystemColors.ActiveCaptionText) Then

                                moves(ctrl, ct)

                                'check moves'
                                Dim val2 As String = ct.Text
                                Dim val1 As String = ctrl.Text
                                Dim cl As Color = ctrl.ForeColor
                                Dim cl2 As Color = ct.ForeColor
                                If valid Then

                                    ct.Text = ctrl.Text
                                    ct.ForeColor = ctrl.ForeColor
                                    ctrl.Text = ""


                                    checkking()

                                    If check Then
                                        valid = False
                                    End If

                                    ct.Text = val2
                                    ctrl.Text = val1
                                    ctrl.ForeColor = cl
                                    ct.ForeColor = cl2

                                    If valid Then
                                        Exit For
                                    End If
                                End If
                                'check moves'
                            End If
                        Next

                        If valid Then
                            Exit For
                        End If
                    End If
                End If
            Next

            If Not valid Then
                stalemate = True
                MessageBox.Show("Stalemate")
            End If

        ElseIf Not check And Not white Then
            For Each control In Board.Controls
                Dim ctrl As Label = control

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = SystemColors.ControlLightLight Then

                        For Each label In Board.Controls
                            Dim ct As Label = label

                            If ct.Text = "" Or (Not (ct.Text = "") And ct.ForeColor = SystemColors.ActiveCaptionText) Then

                                moves(ctrl, ct)

                                'check moves'
                                Dim val2 As String = ct.Text
                                Dim val1 As String = ctrl.Text
                                Dim cl As Color = ctrl.ForeColor
                                Dim cl2 As Color = ct.ForeColor
                                If valid Then

                                    ct.Text = ctrl.Text
                                    ct.ForeColor = ctrl.ForeColor
                                    ctrl.Text = ""


                                    checkking()

                                    If check Then
                                        valid = False
                                    End If

                                    ct.Text = val2
                                    ctrl.Text = val1
                                    ctrl.ForeColor = cl
                                    ct.ForeColor = cl2

                                    If valid Then
                                        Exit For
                                    End If
                                End If
                                'check moves'
                            End If
                        Next

                        If valid Then
                            Exit For
                        End If
                    End If
                End If
            Next

            If Not valid Then
                stalemate = True
                MessageBox.Show("Stalemate")
            End If

        End If


    End Sub
    Private Sub checkking()

        Dim x As Integer
        Dim y As Integer
        Dim cl As Color
        Dim clear As Boolean = False

        For Each control In Board.Controls
            Dim ctrl As Label = control

            If white Then
                If ctrl.Text = king And ctrl.ForeColor = SystemColors.ControlLightLight Then
                    x = Board.Controls.Container.GetColumn(ctrl)
                    y = Board.Controls.Container.GetRow(ctrl)

                    cl = ctrl.ForeColor
                    Exit For
                End If
            Else
                If ctrl.Text = king And ctrl.ForeColor = SystemColors.ActiveCaptionText Then
                    x = Board.Controls.Container.GetColumn(ctrl)
                    y = Board.Controls.Container.GetRow(ctrl)

                    cl = ctrl.ForeColor
                    Exit For
                End If
            End If
        Next

        check = False
        b_check = False

        'straight up'
        Dim l As Integer = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y - l And pos1 = x Then

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If ctrl.Text = queen Or ctrl.Text = rook Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If

                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If


            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label

                If row = y - l And col = x Then

                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If ct.Text = queen Or ct.Text = rook Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If
            Next

            If clear Then
                Exit For
            End If

        Next

        clear = False

        'straight down'
        l = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y + l And pos1 = x Then

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If ctrl.Text = queen Or ctrl.Text = rook Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If


            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label

                If row = y + l And col = x Then

                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If ct.Text = queen Or ct.Text = rook Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If
            Next

            If clear Then
                Exit For
            End If
        Next
        clear = False

        'straight right'
        l = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y And pos1 = x + l Then

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If ctrl.Text = queen Or ctrl.Text = rook Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If


            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label

                If row = y And col = x + l Then

                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If ct.Text = queen Or ct.Text = rook Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If
            Next

            If clear Then
                Exit For
            End If
        Next
        clear = False

        'straight left'
        l = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y And pos1 = x - l Then

                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If ctrl.Text = queen Or ctrl.Text = rook Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If


            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label

                If row = y And col = x - l Then

                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If ct.Text = queen Or ct.Text = rook Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If
            Next

            If clear Then
                Exit For
            End If
        Next
        clear = False

        'upper left'
        l = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y - l And pos1 = x - l Then
                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If (ctrl.Text = queen Or ctrl.Text = bishop) Or (ctrl.Text = pawn And l = 1) Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If
            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label


                If row = y - l And col = x - l Then
                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If (ct.Text = queen Or ct.Text = bishop) Or (ct.Text = pawn And l = 1) Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If


            Next

            If clear Then
                Exit For
            End If

        Next
        clear = False

        'upper right'
        l = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y - l And pos1 = x + l Then
                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If (ctrl.Text = queen Or ctrl.Text = bishop) Or (ctrl.Text = pawn And l = 1) Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If
            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label


                If row = y - l And col = x + l Then
                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If (ct.Text = queen Or ct.Text = bishop) Or (ct.Text = pawn And l = 1) Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If


            Next

            If clear Then
                Exit For
            End If

        Next
        clear = False

        'lower right'
        l = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y + l And pos1 = x + l Then
                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If (ctrl.Text = queen Or ctrl.Text = bishop) Or (ctrl.Text = pawn And l = 1) Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If
            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label


                If row = y + l And col = x + l Then
                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If (ct.Text = queen Or ct.Text = bishop) Or (ct.Text = pawn And l = 1) Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If


            Next

            If clear Then
                Exit For
            End If

        Next
        clear = False

        'lower left'
        l = 1
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control


            If pos2 = y + l And pos1 = x - l Then
                If Not (ctrl.Text = "") Then
                    If ctrl.ForeColor = cl Then
                        Exit For
                    Else
                        If (ctrl.Text = queen Or ctrl.Text = bishop) Or (ctrl.Text = pawn And l = 1) Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If ctrl.Text = "" Then
                    l += 1
                End If
            End If

            For Each label In Board.Controls
                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                Dim row As Integer = Board.Controls.Container.GetRow(label)
                Dim ct As Label = label


                If row = y + l And col = x - l Then
                    If Not (ct.Text = "") Then
                        If ct.ForeColor = cl Then
                            clear = True
                            Exit For
                        Else
                            If (ct.Text = queen Or ct.Text = bishop) Or (ct.Text = pawn And l = 1) Then
                                If white Then
                                    check = True
                                    Exit Sub
                                Else
                                    b_check = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    If ct.Text = "" Then
                        l += 1
                    End If
                End If


            Next

            If clear Then
                Exit For
            End If

        Next
        clear = False

        'horse'
        For Each control In Board.Controls
            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
            Dim ctrl As Label = control

            If pos2 = y - 1 Or pos2 = y + 1 Then
                If pos1 = x + 2 Or pos1 = x - 2 Then
                    If Not (ctrl.ForeColor = cl) Then
                        If ctrl.Text = horse Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            ElseIf pos2 = y - 2 Or pos2 = y + 2 Then
                If pos1 = x + 1 Or pos1 = x - 1 Then
                    If Not (ctrl.ForeColor = cl) Then
                        If ctrl.Text = horse Then
                            If white Then
                                check = True
                                Exit Sub
                            Else
                                b_check = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If

        Next


    End Sub

    Private Sub moves(ByVal x As Label, ByVal y As Label)

        Dim x1 As Integer
        Dim y1 As Integer

        Dim x2 As Integer
        Dim y2 As Integer




        For Each control In Board.Controls
            Dim ctrl As Label = control
            If x.Location = ctrl.Location Then
                x1 = Board.Controls.Container.GetColumn(ctrl)
                y1 = Board.Controls.Container.GetRow(ctrl)
            End If
        Next

        For Each control In Board.Controls
            Dim ctrl As Label = control
            If y.Location = ctrl.Location Then
                x2 = Board.Controls.Container.GetColumn(ctrl)
                y2 = Board.Controls.Container.GetRow(ctrl)
            End If
        Next



        Select Case x.Text
            Case rook

                If white Or Not (white) Then
                    Dim l As Integer

                    l = 1
                    If y2 < y1 And x2 = x1 Then
                        'straight up'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos2 = y1 - l And pos1 = x1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If


                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If row = y1 - l And col = x1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If

                                End If
                            Next

                        Next

                    ElseIf y2 > y1 And x2 = x1 Then
                        'straight down'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos2 = y1 + l And pos1 = x1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If


                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If row = y1 + l And col = x1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If

                                End If
                            Next

                        Next
                    ElseIf y2 = y1 And x2 > x1 Then
                        'straight right'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos1 = x1 + l And pos2 = y1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If


                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If col = x1 + l And row = y1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If

                                End If
                            Next

                        Next
                    ElseIf y2 = y1 And x2 < x1 Then
                        'straight left'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos1 = x1 - l And pos2 = y1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If


                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If col = x1 - l And row = y1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If

                                End If
                            Next

                        Next
                    End If
                End If

            Case pawn
                'pawn'
                If (white) Then
                    If y1 = 6 Then
                        If ((y2 = y1 - 1) Or (y2 = y1 - 2)) And x1 = x2 Then

                            If x1 = 3 Then
                                Dim m As Integer = 0
                                For Each control In Board.Controls
                                    Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                    Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                    Dim ctrl As Label = control

                                    If y2 = y1 - 1 Then
                                        If pos2 = y2 And pos1 = x2 Then
                                            If ctrl.Text = "" Then
                                                valid = True
                                            Else
                                                valid = False
                                                Exit Sub
                                            End If
                                        End If
                                    ElseIf y2 = y1 - 2 Then
                                        If pos2 = y2 + m And pos1 = x2 Then
                                            If ctrl.Text = "" Then
                                                m += 1
                                                If pos2 = y2 + 1 Then
                                                    valid = True
                                                    Exit For

                                                End If
                                            Else
                                                valid = False
                                                Exit Sub
                                            End If

                                        End If
                                    End If

                                Next
                            Else
                                Dim m As Integer = 0
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If y2 = y1 - 1 Then
                                    If pos2 = y2 And pos1 = x2 Then
                                        If ctrl.Text = "" Then
                                            valid = True
                                        Else
                                            valid = False
                                            Exit Sub
                                        End If
                                    End If
                                ElseIf y2 = y1 - 2 Then
                                    If pos2 = y2 + m And pos1 = x2 Then
                                        If pos2 = y1 And pos1 = x2 Then
                                            valid = True
                                            Exit For
                                        End If
                                        If ctrl.Text = "" Then

                                            m += 1
                                        Else
                                            valid = False
                                            Exit Sub
                                        End If
                                    End If
                                End If

                            Next
                        End If


                        'enpassant'
                        If (y2 = y1 - 2) And valid Then
                                For Each control In Board.Controls
                                    Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                    Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                    Dim ctrl As Label = control

                                    If ((pos1 = x2 - 1) Or (pos1 = x2 + 1)) And pos2 = y2 Then
                                        If ctrl.Text = b_pawn And ctrl.ForeColor = SystemColors.ActiveCaptionText Then
                                            If pos1 = x2 - 1 Then
                                                x3 = pos1 + 1
                                            Else
                                                x3 = pos1 - 1
                                            End If

                                            enpassant = True
                                            tmpvar = numofmoves
                                            EnpassantTimer.Start()
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If


                            Exit Sub

                        ElseIf (y2 = y1 - 1) And ((x2 = x1 + 1) Or (x2 = x1 - 1)) Then
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If (pos1 = x2) And pos2 = y2 Then
                                    If String.IsNullOrEmpty(ctrl.Text) Then
                                        valid = False
                                    Else

                                        valid = True
                                        Exit Sub
                                    End If
                                End If
                            Next

                        Else
                            valid = False
                            Exit Sub
                        End If
                        'promotion'
                    ElseIf y1 = 1 Then
                        If (y2 = y1 - 1) And x1 = x2 Then

                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If pos2 = y2 And pos1 = x2 Then
                                    If ctrl.Text = "" Then
                                        valid = True
                                    Else
                                        valid = False
                                        Exit Sub
                                    End If
                                End If

                                If valid Then
                                    If pos2 = y1 And pos1 = x1 Then
                                        ctrl.Text = queen
                                        Exit Sub
                                    End If
                                End If

                            Next

                        ElseIf (y2 = y1 - 1) And ((x2 = x1 + 1) Or (x2 = x1 - 1)) Then
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If (pos1 = x2) And pos2 = y2 Then
                                    If String.IsNullOrEmpty(ctrl.Text) Then
                                        valid = False
                                    Else
                                        valid = True
                                    End If
                                End If

                                If valid Then
                                    If pos2 = y1 And pos1 = x1 Then
                                        ctrl.Text = queen
                                        Exit Sub
                                    End If
                                End If
                            Next
                        End If

                    Else
                        If (y2 = y1 - 1) And x1 = x2 Then

                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If pos2 = y2 And pos1 = x2 Then
                                    If ctrl.Text = "" Then
                                        valid = True
                                    Else
                                        valid = False
                                        Exit Sub
                                    End If
                                End If

                            Next

                        ElseIf (y2 = y1 - 1) And ((x2 = x1 + 1) Or (x2 = x1 - 1)) Then
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If (pos1 = x2) And pos2 = y2 Then
                                    If String.IsNullOrEmpty(ctrl.Text) Then
                                        valid = False
                                    Else
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                If x2 = x3 Then
                                    If ((pos1 = x2) And pos2 = y2 + 1) And enpassant Then
                                        If ctrl.Text = pawn Then
                                            ctrl.Text = ""
                                            valid = True
                                            Exit Sub
                                        Else
                                            valid = False
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            Next



                        Else
                            valid = False
                            Exit Sub
                        End If
                    End If
                    'balck'
                Else
                    If y1 = 1 Then
                        If ((y2 = y1 + 1) Or (y2 = y1 + 2)) And x1 = x2 Then

                            Dim m As Integer = 1
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If y2 = y1 + 1 Then
                                    If pos2 = y2 And pos1 = x2 Then
                                        If ctrl.Text = "" Then
                                            valid = True
                                        Else
                                            valid = False
                                            Exit Sub
                                        End If
                                    End If
                                ElseIf y2 = y1 + 2 Then
                                    If pos2 = y1 + m And pos1 = x2 Then
                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit For
                                        End If
                                        If ctrl.Text = "" Then

                                            m += 1
                                        Else
                                            valid = False
                                            Exit Sub
                                        End If
                                    End If
                                End If

                            Next

                            'enpassant'
                            If (y2 = y1 + 2) And valid Then
                                For Each control In Board.Controls
                                    Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                    Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                    Dim ctrl As Label = control

                                    If ((pos1 = x2 - 1) Or (pos1 = x2 + 1)) And pos2 = y2 Then
                                        If ctrl.Text = pawn And ctrl.ForeColor = SystemColors.ControlLightLight Then

                                            If pos1 = x2 - 1 Then
                                                x3 = pos1 + 1
                                            Else
                                                x3 = pos1 - 1
                                            End If
                                            enpassant = True
                                            tmpvar = numofmoves
                                            EnpassantTimer.Start()
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If

                            Exit Sub

                        ElseIf (y2 = y1 + 1) And ((x2 = x1 + 1) Or (x2 = x1 - 1)) Then
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If (pos1 = x2) And pos2 = y2 Then
                                    If String.IsNullOrEmpty(ctrl.Text) Then
                                        valid = False
                                    Else
                                        valid = True
                                        Exit Sub
                                    End If
                                End If
                            Next
                        Else
                            valid = False
                            Exit Sub
                        End If
                        'promotion'
                    ElseIf y1 = 6 Then
                        If (y2 = y1 + 1) And x1 = x2 Then

                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If pos2 = y2 And pos1 = x2 Then
                                    If ctrl.Text = "" Then
                                        valid = True
                                    Else
                                        valid = False
                                        Exit Sub
                                    End If
                                End If

                            Next
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If valid Then
                                    If pos2 = y1 And pos1 = x1 Then
                                        ctrl.Text = b_queen
                                        Exit Sub
                                    End If
                                End If
                            Next
                        ElseIf (y2 = y1 + 1) And ((x2 = x1 + 1) Or (x2 = x1 - 1)) Then

                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If (pos1 = x2) And pos2 = y2 Then
                                    If String.IsNullOrEmpty(ctrl.Text) Then
                                        valid = False
                                    Else
                                        valid = True

                                    End If
                                End If

                            Next
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If valid Then
                                    If pos2 = y1 And pos1 = x1 Then
                                        ctrl.Text = b_queen
                                        Exit Sub
                                    End If
                                End If
                            Next
                        End If

                    Else
                        If (y2 = y1 + 1) And x1 = x2 Then

                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If pos2 = y2 And pos1 = x2 Then
                                    If ctrl.Text = "" Then
                                        valid = True
                                    Else
                                        valid = False
                                        Exit Sub
                                    End If
                                End If

                            Next
                        ElseIf (y2 = y1 + 1) And ((x2 = x1 + 1) Or (x2 = x1 - 1)) Then

                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control

                                If (pos1 = x2) And pos2 = y2 Then
                                    If String.IsNullOrEmpty(ctrl.Text) Then
                                        valid = False
                                    Else
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                If x2 = x3 Then
                                    If ((pos1 = x2) And pos2 = y2 - 1) And enpassant Then
                                        If ctrl.Text = pawn Then
                                            ctrl.Text = ""
                                            valid = True
                                            Exit Sub
                                        Else
                                            valid = False
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            Next

                        Else
                            valid = False
                            Exit Sub
                        End If

                    End If
                End If
                'pawn'
            Case bishop
                'bishop'

                If white Or Not (white) Then
                    Dim l As Integer
                    l = 1
                    If y2 < y1 Then

                        If x2 < x1 Then

                            'upper left'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 - l And pos1 = x1 - l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 - l And col = x1 - l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next



                        ElseIf x2 > x1 Then
                            'upper right'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 - l And pos1 = x1 + l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 - l And col = x1 + l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next
                        End If

                    ElseIf y2 > y1 Then

                        If x2 < x1 Then
                            'lower left'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 + l And pos1 = x1 - l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 + l And col = x1 - l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next
                        ElseIf x2 > x1 Then
                            'lower right'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 + l And pos1 = x1 + l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 + l And col = x1 + l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next

                        End If


                    End If
                End If
                'bishop'
            Case horse
                'horse'
                If white Or Not (white) Then
                    If y2 = y1 - 1 Or y2 = y1 + 1 Then
                        If x2 = x1 - 2 Or x2 = x1 + 2 Then
                            valid = True
                        End If
                    ElseIf y2 = y1 + 2 Or y2 = y1 - 2 Then
                        If x2 = x1 + 1 Or x2 = x1 - 1 Then
                            valid = True
                        End If
                    End If
                End If
                'horse'
            Case queen
                'queen'
                If white Or Not (white) Then
                    Dim l As Integer

                    l = 1
                    If y2 < y1 And Not (x2 = x1) Then

                        If x2 < x1 Then

                            'upper left'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 - l And pos1 = x1 - l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 - l And col = x1 - l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next



                        ElseIf x2 > x1 Then
                            'upper right'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 - l And pos1 = x1 + l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 - l And col = x1 + l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next
                        End If

                    ElseIf y2 > y1 And Not (x2 = x1) Then

                        If x2 < x1 Then
                            'lower left'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 + l And pos1 = x1 - l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 + l And col = x1 - l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next
                        ElseIf x2 > x1 Then
                            'lower right'
                            For Each control In Board.Controls
                                Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                                Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                                Dim ctrl As Label = control


                                If pos2 = y1 + l And pos1 = x1 + l Then
                                    If ctrl.Text = "" Then
                                        l += 1

                                        If pos2 = y2 And pos1 = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If
                                    If pos2 = y2 And pos1 = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                End If

                                For Each label In Board.Controls
                                    Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                    Dim row As Integer = Board.Controls.Container.GetRow(label)
                                    Dim ct As Label = label


                                    If row = y1 + l And col = x1 + l Then
                                        If ct.Text = "" Then

                                            If row = y2 And col = x2 Then
                                                valid = True
                                                Exit Sub
                                            Else
                                                l += 1
                                                Exit For
                                            End If
                                        End If
                                        If row = y2 And col = x2 Then
                                            valid = True
                                            Exit Sub
                                        End If
                                    End If


                                Next

                            Next

                        End If

                    ElseIf y2 < y1 And x2 = x1 Then
                        'straight up'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos2 = y1 - l And pos1 = x1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If

                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If row = y1 - l And col = x1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If
                                End If
                            Next

                        Next

                    ElseIf y2 > y1 And x2 = x1 Then
                        'straight down'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos2 = y1 + l And pos1 = x1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If

                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If row = y1 + l And col = x1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If
                                End If
                            Next

                        Next
                    ElseIf y2 = y1 And x2 > x1 Then
                        'straight right'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos1 = x1 + l And pos2 = y1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If

                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If col = x1 + l And row = y1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If
                                End If
                            Next

                        Next
                    ElseIf y2 = y1 And x2 < x1 Then
                        'straight left'
                        For Each control In Board.Controls
                            Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                            Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                            Dim ctrl As Label = control


                            If pos1 = x1 - l And pos2 = y1 Then
                                If pos2 = y2 And pos1 = x2 Then
                                    valid = True
                                    Exit Sub
                                End If
                                If ctrl.Text = "" Then
                                    l += 1
                                End If

                            End If

                            For Each label In Board.Controls
                                Dim col As Integer = Board.Controls.Container.GetColumn(label)
                                Dim row As Integer = Board.Controls.Container.GetRow(label)
                                Dim ct As Label = label

                                If col = x1 - l And row = y1 Then
                                    If row = y2 And col = x2 Then
                                        valid = True
                                        Exit Sub
                                    End If
                                    If ct.Text = "" Then
                                        l += 1
                                    End If
                                End If
                            Next

                        Next
                    End If
                End If
                'queen'
            Case king
                'king'
                Dim l As Integer
                l = 1
                For Each control In Board.Controls
                    Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                    Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                    Dim ctrl As Label = control


                    If pos1 = x1 - l And pos2 = y1 Then
                        If (pos2 = 7 Or pos2 = 0) And pos1 = 0 Then
                            castleleft = True
                            Exit For
                        End If
                        If ctrl.Text = "" Then
                            l += 1
                        End If

                    End If

                    For Each label In Board.Controls
                        Dim col As Integer = Board.Controls.Container.GetColumn(label)
                        Dim row As Integer = Board.Controls.Container.GetRow(label)
                        Dim ct As Label = label

                        If col = x1 - l And row = y1 Then
                            If (row = 7 Or row = 0) And col = 0 Then
                                castleleft = True
                                Exit For
                            End If
                            If ct.Text = "" Then
                                l += 1
                            End If
                        End If
                    Next

                Next

                For Each control In Board.Controls
                    Dim pos1 As Integer = Board.Controls.Container.GetColumn(control)
                    Dim pos2 As Integer = Board.Controls.Container.GetRow(control)
                    Dim ctrl As Label = control


                    If pos1 = x1 + l And pos2 = y1 Then
                        If (pos2 = 7 Or pos2 = 0) And pos1 = 7 Then
                            castleright = True
                            Exit For
                        End If
                        If ctrl.Text = "" Then
                            l += 1
                        End If

                    End If

                    For Each label In Board.Controls
                        Dim col As Integer = Board.Controls.Container.GetColumn(label)
                        Dim row As Integer = Board.Controls.Container.GetRow(label)
                        Dim ct As Label = label

                        If col = x1 + l And row = y1 Then
                            If (row = 7 Or row = 0) And col = 7 Then
                                castleright = True
                                Exit For
                            End If
                            If ct.Text = "" Then
                                l += 1
                            End If
                        End If
                    Next

                Next

                If white Then
                    If (y2 = y1 - 1 And x2 = x1) Or (y2 = y1 + 1 And x2 = x1) Or (x2 = x1 + 1 And y2 = y1) Or (x2 = x1 - 1 And y2 = y1) Or (y2 = y1 + 1 And x2 = x1 + 1) Or (y2 = y1 + 1 And x2 = x1 - 1) Or (y2 = y1 - 1 And x2 = x1 + 1) Or (y2 = y1 - 1 And x2 = x1 - 1) Then
                        valid = True
                        kingmoved = True
                    ElseIf castleright = True And kingmoved = False AndAlso (y2 = y1 And x2 = x1 + 2) AndAlso rook2 AndAlso Not check Then


                        valid = True
                        'check moves'
                        Dim val2 As String = selected2.Text
                        Dim val1 As String = selected.Text
                        Dim cl As Color = selected.ForeColor
                        Dim cl2 As Color = selected2.ForeColor
                        If valid Then

                            If white Then
                                selected.ForeColor = SystemColors.ControlLightLight
                            Else
                                selected.ForeColor = SystemColors.ActiveCaptionText
                            End If

                            selected2.Text = selected.Text
                            selected2.ForeColor = selected.ForeColor
                            selected.Text = ""


                            checkking()


                            If check And selected.ForeColor = SystemColors.ControlLightLight Then
                                valid = False

                            End If

                            If b_check And selected.ForeColor = SystemColors.ActiveCaptionText Then
                                valid = False

                            End If

                            selected2.Text = val2
                            selected.Text = val1
                            selected.ForeColor = cl
                            selected2.ForeColor = cl2

                            If Not valid Then
                                Exit Sub
                            End If

                        End If
                        'check moves'
                        F1.Text = H1.Text
                        H1.Text = ""
                        rook2 = False
                        castleleft = False
                        castleright = False
                        kingmoved = True

                    ElseIf castleleft = True And kingmoved = False AndAlso (y2 = y1 And x2 = x1 - 2) AndAlso rook1 AndAlso Not check Then


                        valid = True
                        'check moves'
                        Dim val2 As String = selected2.Text
                        Dim val1 As String = selected.Text
                        Dim cl As Color = selected.ForeColor
                        Dim cl2 As Color = selected2.ForeColor
                        If valid Then

                            If white Then
                                selected.ForeColor = SystemColors.ControlLightLight
                            Else
                                selected.ForeColor = SystemColors.ActiveCaptionText
                            End If

                            selected2.Text = selected.Text
                            selected2.ForeColor = selected.ForeColor
                            selected.Text = ""


                            checkking()


                            If check And selected.ForeColor = SystemColors.ControlLightLight Then
                                valid = False

                            End If

                            If b_check And selected.ForeColor = SystemColors.ActiveCaptionText Then
                                valid = False

                            End If

                            selected2.Text = val2
                            selected.Text = val1
                            selected.ForeColor = cl
                            selected2.ForeColor = cl2

                            If Not valid Then
                                Exit Sub
                            End If

                        End If
                        'check moves'
                        D1.Text = A1.Text
                        A1.Text = ""
                        rook1 = False
                        castleleft = False
                        castleright = False
                        kingmoved = True

                    End If
                Else
                    If (y2 = y1 - 1 And x2 = x1) Or (y2 = y1 + 1 And x2 = x1) Or (x2 = x1 + 1 And y2 = y1) Or (x2 = x1 - 1 And y2 = y1) Or (y2 = y1 + 1 And x2 = x1 + 1) Or (y2 = y1 + 1 And x2 = x1 - 1) Or (y2 = y1 - 1 And x2 = x1 + 1) Or (y2 = y1 - 1 And x2 = x1 - 1) Then
                        valid = True
                        bkingmoved = True
                    ElseIf castleright = True And bkingmoved = False AndAlso (y2 = y1 And x2 = x1 + 2) AndAlso rook4 AndAlso Not b_check Then


                        valid = True
                        'check moves'
                        Dim val2 As String = selected2.Text
                        Dim val1 As String = selected.Text
                        Dim cl As Color = selected.ForeColor
                        Dim cl2 As Color = selected2.ForeColor
                        If valid Then

                            If white Then
                                selected.ForeColor = SystemColors.ControlLightLight
                            Else
                                selected.ForeColor = SystemColors.ActiveCaptionText
                            End If

                            selected2.Text = selected.Text
                            selected2.ForeColor = selected.ForeColor
                            selected.Text = ""


                            checkking()


                            If check And selected.ForeColor = SystemColors.ControlLightLight Then
                                valid = False

                            End If

                            If b_check And selected.ForeColor = SystemColors.ActiveCaptionText Then
                                valid = False

                            End If

                            selected2.Text = val2
                            selected.Text = val1
                            selected.ForeColor = cl
                            selected2.ForeColor = cl2

                            If Not valid Then
                                Exit Sub
                            End If

                        End If
                        'check moves'
                        F8.Text = H8.Text
                        H8.Text = ""
                        rook4 = False
                        castleleft = False
                        castleright = False
                        bkingmoved = True

                    ElseIf castleleft = True And bkingmoved = False AndAlso (y2 = y1 And x2 = x1 - 2) AndAlso rook3 AndAlso Not (b_check) Then

                        valid = True

                        'check moves'
                        Dim val2 As String = selected2.Text
                        Dim val1 As String = selected.Text
                        Dim cl As Color = selected.ForeColor
                        Dim cl2 As Color = selected2.ForeColor
                        If valid Then

                            If white Then
                                selected.ForeColor = SystemColors.ControlLightLight
                            Else
                                selected.ForeColor = SystemColors.ActiveCaptionText
                            End If

                            selected2.Text = selected.Text
                            selected2.ForeColor = selected.ForeColor
                            selected.Text = ""


                            checkking()


                            If check And selected.ForeColor = SystemColors.ControlLightLight Then
                                valid = False

                            End If

                            If b_check And selected.ForeColor = SystemColors.ActiveCaptionText Then
                                valid = False

                            End If

                            selected2.Text = val2
                            selected.Text = val1
                            selected.ForeColor = cl
                            selected2.ForeColor = cl2

                            If Not valid Then
                                Exit Sub
                            End If

                        End If
                        'check moves'

                        D8.Text = A8.Text
                        A8.Text = ""
                        rook3 = False
                        castleleft = False
                        castleright = False
                        bkingmoved = True

                    End If
                End If
                'king'
        End Select
    End Sub
    Private Sub mob(ByVal x As Label)

        If start Then
            If move = False Then
                'selecting pieces'
                If (white And x.ForeColor = SystemColors.ControlLightLight) Or (Not (white) And x.ForeColor = SystemColors.ActiveCaptionText) Then
                    If Not (x.Text = "") Then
                        selected = x
                        move = True

                        If white Then
                            selected.ForeColor = Color.RoyalBlue
                        Else
                            selected.ForeColor = Color.Red
                        End If
                    End If
                End If
            Else

                If (white And (x.ForeColor = SystemColors.ControlLightLight Or x.ForeColor = Color.RoyalBlue) AndAlso Not (x.Text = "")) Or (Not (white) And (x.ForeColor = SystemColors.ActiveCaptionText Or x.ForeColor = Color.Red) AndAlso Not (x.Text = "")) Then
                    'reselecting pieces'
                    If Not (x.Text = "") Then
                        If white Then
                            selected.ForeColor = SystemColors.ControlLightLight
                        Else
                            selected.ForeColor = SystemColors.ActiveCaptionText
                        End If

                        selected = x
                        move = True

                        If white Then
                            selected.ForeColor = Color.RoyalBlue
                        Else
                            selected.ForeColor = Color.Red
                        End If
                    End If
                Else
                    'moving pieces'

                    selected2 = x


                    moves(selected, selected2)

                    'check moves'
                    Dim val2 As String = selected2.Text
                    Dim val1 As String = selected.Text
                    Dim cl As Color = selected.ForeColor
                    Dim cl2 As Color = selected2.ForeColor
                    If valid Then

                        If white Then
                            selected.ForeColor = SystemColors.ControlLightLight
                        Else
                            selected.ForeColor = SystemColors.ActiveCaptionText
                        End If

                        selected2.Text = selected.Text
                        selected2.ForeColor = selected.ForeColor
                        selected.Text = ""


                        checkking()


                        If check And selected.ForeColor = SystemColors.ControlLightLight Then
                            valid = False
                        End If

                        If b_check And selected.ForeColor = SystemColors.ActiveCaptionText Then
                            valid = False
                        End If

                        selected2.Text = val2
                        selected.Text = val1
                        selected.ForeColor = cl
                        selected2.ForeColor = cl2


                    End If
                    'check moves'

                    If valid Then
                        Dim play As New WindowsMediaPlayer

                        play.settings.volume = 100
                        play.URL = "C:\Users\brixo\Downloads\mobsound.mp3"

                        If white Then
                            If Not (selected2.Text = "") Then
                                For Each control In WhiteCap.Controls
                                    Dim pos1 As Integer = WhiteCap.Controls.Container.GetColumn(control)
                                    Dim pos2 As Integer = WhiteCap.Controls.Container.GetRow(control)
                                    Dim ctrl As Label = control

                                    If pos1 = i And pos2 = j Then

                                        ctrl.Text = selected2.Text

                                        If i = 7 Then
                                            j = 1
                                            i = 0
                                        Else
                                            i += 1
                                        End If
                                        Exit For
                                    End If

                                Next
                            ElseIf enpassant And tmpvar = numofmoves - 1 Then
                                For Each control In WhiteCap.Controls
                                    Dim pos1 As Integer = WhiteCap.Controls.Container.GetColumn(control)
                                    Dim pos2 As Integer = WhiteCap.Controls.Container.GetRow(control)
                                    Dim ctrl As Label = control

                                    If pos1 = i And pos2 = j Then


                                        ctrl.Text = pawn

                                        If i = 7 Then
                                            j = 1
                                            i = 0
                                        Else
                                            i += 1
                                        End If
                                        Exit For
                                    End If

                                Next
                            End If



                            If selected.Location = H1.Location Then
                                rook2 = False
                            ElseIf selected.Location = A1.Location Then
                                rook1 = False
                            End If
                            selected.ForeColor = SystemColors.ControlLightLight
                        Else

                            If Not (selected2.Text = "") Then
                                For Each control In BlackCap.Controls
                                    Dim pos1 As Integer = BlackCap.Controls.Container.GetColumn(control)
                                    Dim pos2 As Integer = BlackCap.Controls.Container.GetRow(control)
                                    Dim ctrl As Label = control

                                    If pos1 = k And pos2 = l Then

                                        ctrl.Text = selected2.Text

                                        If k = 7 Then
                                            l = 1
                                            k = 0
                                        Else
                                            k += 1
                                        End If
                                        Exit For

                                    End If
                                Next
                            ElseIf enpassant And tmpvar = numofmoves - 1 Then
                                For Each control In BlackCap.Controls
                                    Dim pos1 As Integer = BlackCap.Controls.Container.GetColumn(control)
                                    Dim pos2 As Integer = BlackCap.Controls.Container.GetRow(control)
                                    Dim ctrl As Label = control

                                    If pos1 = k And pos2 = l Then


                                        ctrl.Text = pawn

                                        If k = 7 Then
                                            l = 1
                                            k = 0
                                        Else
                                            k += 1
                                        End If
                                        Exit For
                                    End If

                                Next
                            End If



                            If selected.Location = H8.Location Then
                                rook4 = False
                            ElseIf selected.Location = A8.Location Then
                                rook3 = False
                            End If

                            selected.ForeColor = SystemColors.ActiveCaptionText
                        End If



                        selected2.Text = selected.Text
                        selected2.ForeColor = selected.ForeColor
                        selected.Text = ""



                        move = False

                        If white Then
                            white = False

                        ElseIf Not (white) Then
                            white = True

                        End If

                        numofmoves += 1
                        valid = False

                        checkking()
                        checkmate()


                    End If
                End If


            End If
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kingmoved = False
        bkingmoved = False
    End Sub

    Private Sub B2_Click(sender As Object, e As EventArgs) Handles B2.Click
        mob(B2)
    End Sub

    Private Sub C2_Click(sender As Object, e As EventArgs) Handles C2.Click
        mob(C2)
    End Sub

    Private Sub D2_Click(sender As Object, e As EventArgs) Handles D2.Click
        mob(D2)
    End Sub

    Private Sub E2_Click(sender As Object, e As EventArgs) Handles E2.Click
        mob(E2)
    End Sub

    Private Sub F2_Click(sender As Object, e As EventArgs) Handles F2.Click
        mob(F2)
    End Sub

    Private Sub G2_Click(sender As Object, e As EventArgs) Handles G2.Click
        mob(G2)
    End Sub

    Private Sub H2_Click(sender As Object, e As EventArgs) Handles H2.Click
        mob(H2)
    End Sub

    Private Sub B3_Click(sender As Object, e As EventArgs) Handles B3.Click
        mob(B3)
    End Sub

    Private Sub C3_Click(sender As Object, e As EventArgs) Handles C3.Click
        mob(C3)
    End Sub

    Private Sub D3_Click(sender As Object, e As EventArgs) Handles D3.Click
        mob(D3)
    End Sub

    Private Sub E3_Click(sender As Object, e As EventArgs) Handles E3.Click
        mob(E3)
    End Sub

    Private Sub F3_Click(sender As Object, e As EventArgs) Handles F3.Click
        mob(F3)
    End Sub

    Private Sub G3_Click(sender As Object, e As EventArgs) Handles G3.Click
        mob(G3)
    End Sub

    Private Sub H3_Click(sender As Object, e As EventArgs) Handles H3.Click
        mob(H3)
    End Sub

    Private Sub A4_Click(sender As Object, e As EventArgs) Handles A4.Click
        mob(A4)
    End Sub

    Private Sub B4_Click(sender As Object, e As EventArgs) Handles B4.Click
        mob(B4)
    End Sub

    Private Sub C4_Click(sender As Object, e As EventArgs) Handles C4.Click
        mob(C4)
    End Sub

    Private Sub D4_Click(sender As Object, e As EventArgs) Handles D4.Click
        mob(D4)
    End Sub

    Private Sub E4_Click(sender As Object, e As EventArgs) Handles E4.Click
        mob(E4)
    End Sub

    Private Sub F4_Click(sender As Object, e As EventArgs) Handles F4.Click
        mob(F4)
    End Sub

    Private Sub G4_Click(sender As Object, e As EventArgs) Handles G4.Click
        mob(G4)
    End Sub

    Private Sub H4_Click(sender As Object, e As EventArgs) Handles H4.Click
        mob(H4)
    End Sub

    Private Sub A5_Click(sender As Object, e As EventArgs) Handles A5.Click
        mob(A5)
    End Sub

    Private Sub B5_Click(sender As Object, e As EventArgs) Handles B5.Click
        mob(B5)
    End Sub

    Private Sub C5_Click(sender As Object, e As EventArgs) Handles C5.Click
        mob(C5)
    End Sub

    Private Sub D5_Click(sender As Object, e As EventArgs) Handles D5.Click
        mob(D5)
    End Sub

    Private Sub E5_Click(sender As Object, e As EventArgs) Handles E5.Click
        mob(E5)
    End Sub

    Private Sub F5_Click(sender As Object, e As EventArgs) Handles F5.Click
        mob(F5)
    End Sub

    Private Sub G5_Click(sender As Object, e As EventArgs) Handles G5.Click
        mob(G5)
    End Sub

    Private Sub H5_Click(sender As Object, e As EventArgs) Handles H5.Click
        mob(H5)
    End Sub

    Private Sub A6_Click(sender As Object, e As EventArgs) Handles A6.Click
        mob(A6)
    End Sub

    Private Sub B6_Click(sender As Object, e As EventArgs) Handles B6.Click
        mob(B6)
    End Sub

    Private Sub C6_Click(sender As Object, e As EventArgs) Handles C6.Click
        mob(C6)
    End Sub

    Private Sub D6_Click(sender As Object, e As EventArgs) Handles D6.Click
        mob(D6)
    End Sub

    Private Sub E6_Click(sender As Object, e As EventArgs) Handles E6.Click
        mob(E6)
    End Sub

    Private Sub F6_Click(sender As Object, e As EventArgs) Handles F6.Click
        mob(F6)
    End Sub

    Private Sub G6_Click(sender As Object, e As EventArgs) Handles G6.Click
        mob(G6)
    End Sub

    Private Sub H6_Click(sender As Object, e As EventArgs) Handles H6.Click
        mob(H6)
    End Sub

    Private Sub A7_Click(sender As Object, e As EventArgs) Handles A7.Click
        mob(A7)
    End Sub

    Private Sub B7_Click(sender As Object, e As EventArgs) Handles B7.Click
        mob(B7)
    End Sub

    Private Sub C7_Click(sender As Object, e As EventArgs) Handles C7.Click
        mob(C7)
    End Sub

    Private Sub D7_Click(sender As Object, e As EventArgs) Handles D7.Click
        mob(D7)
    End Sub

    Private Sub E7_Click(sender As Object, e As EventArgs) Handles E7.Click
        mob(E7)
    End Sub

    Private Sub F7_Click(sender As Object, e As EventArgs) Handles F7.Click
        mob(F7)
    End Sub

    Private Sub G7_Click(sender As Object, e As EventArgs) Handles G7.Click
        mob(G7)
    End Sub

    Private Sub H7_Click(sender As Object, e As EventArgs) Handles H7.Click
        mob(H7)
    End Sub

    Private Sub A8_Click(sender As Object, e As EventArgs) Handles A8.Click
        mob(A8)
    End Sub

    Private Sub B8_Click(sender As Object, e As EventArgs) Handles B8.Click
        mob(B8)
    End Sub

    Private Sub C8_Click(sender As Object, e As EventArgs) Handles C8.Click
        mob(C8)
    End Sub

    Private Sub D8_Click(sender As Object, e As EventArgs) Handles D8.Click
        mob(D8)
    End Sub

    Private Sub E8_Click(sender As Object, e As EventArgs) Handles E8.Click
        mob(E8)
    End Sub

    Private Sub F8_Click(sender As Object, e As EventArgs) Handles F8.Click
        mob(F8)
    End Sub

    Private Sub G8_Click(sender As Object, e As EventArgs) Handles G8.Click
        mob(G8)
    End Sub

    Private Sub H8_Click(sender As Object, e As EventArgs) Handles H8.Click
        mob(H8)
    End Sub

    Private Sub A1_Click(sender As Object, e As EventArgs) Handles A1.Click
        mob(A1)
    End Sub

    Private Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click
        mob(B1)
    End Sub

    Private Sub C1_Click(sender As Object, e As EventArgs) Handles C1.Click
        mob(C1)
    End Sub

    Private Sub D1_Click(sender As Object, e As EventArgs) Handles D1.Click
        mob(D1)
    End Sub

    Private Sub E1_Click(sender As Object, e As EventArgs) Handles E1.Click
        mob(E1)
    End Sub

    Private Sub F1_Click(sender As Object, e As EventArgs) Handles F1.Click
        mob(F1)
    End Sub

    Private Sub G1_Click(sender As Object, e As EventArgs) Handles G1.Click
        mob(G1)
    End Sub

    Private Sub H1_Click(sender As Object, e As EventArgs) Handles H1.Click
        mob(H1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim play As New WindowsMediaPlayer

        play.settings.volume = 100
        play.URL = "C:\Users\brixo\Downloads\Pareh naman.mp3"

    End Sub

    Private Sub MateKa_Tick(sender As Object, e As EventArgs) Handles MateKa.Tick

        If mate Then
            valid = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(TextBox1.Text) = False Then
                player1 = TextBox1.Text
                TextBox1.ReadOnly = True
                TextBox2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown

        If e.KeyCode = Keys.Enter Then

            If String.IsNullOrEmpty(TextBox1.Text) = False Then
                player2 = TextBox2.Text
                TextBox2.ReadOnly = True
                Board.Focus()
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If player.playState = WMPPlayState.wmppsPaused Then
            Dim url As String = "C:\Users\brixo\Downloads\ost\Passionate_Duelist_Yugi_Mutos_Theme_Dual_Mix.wav"

            player.URL = url
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Not (player1 = "") And Not (player2 = "") Then
            start = True
            Timer1.Stop()
            boardload()
        End If

    End Sub

    Private Sub boardload()
        If start Then
            white = True



            A1.Text = rook
            B1.Text = horse
            C1.Text = bishop
            D1.Text = queen
            E1.Text = king
            F1.Text = bishop
            G1.Text = horse
            H1.Text = rook

            A2.Text = pawn
            B2.Text = pawn
            C2.Text = pawn
            D2.Text = pawn
            E2.Text = pawn
            F2.Text = pawn
            G2.Text = pawn
            H2.Text = pawn

            A8.Text = b_rook
            B8.Text = b_horse
            C8.Text = b_bishop
            D8.Text = b_queen
            E8.Text = b_king
            F8.Text = b_bishop
            G8.Text = b_horse
            H8.Text = b_rook

            A7.Text = b_pawn
            B7.Text = b_pawn
            C7.Text = b_pawn
            D7.Text = b_pawn
            E7.Text = b_pawn
            F7.Text = b_pawn
            G7.Text = b_pawn
            H7.Text = b_pawn

            rook1 = True
            rook2 = True
            rook3 = True
            rook4 = True

            For Each control In Board.Controls

                Dim x As Label = control

                x.TextAlign = HorizontalAlignment.Center

            Next

            Dim url As String = "C:\Users\brixo\Downloads\ost\Passionate_Duelist_Yugi_Mutos_Theme_Dual_Mix.wav"

            player.settings.volume = 30
            player.URL = url

            Label18.Hide()
            WhiteCap.Show()
            BlackCap.Show()

        End If
    End Sub

    Private Sub EnpassantTimer_Tick(sender As Object, e As EventArgs) Handles EnpassantTimer.Tick
        If tmpvar = numofmoves - 2 Then
            enpassant = False
            EnpassantTimer.Stop()
        End If
    End Sub

    Private Sub WhiteCap_Paint(sender As Object, e As PaintEventArgs) Handles WhiteCap.Paint

    End Sub


End Class
