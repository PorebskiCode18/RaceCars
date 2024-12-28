Public Class Form1
    Dim rnum As New Random
    Dim numLaps As Integer
    Dim finished(3) As Boolean
    Dim cars() As Label
    Dim topBumps() As Label
    Dim rightBumps() As Label
    Dim bottomBumps() As Label
    Dim leftBumps() As Label
    Dim carRight(3) As Boolean
    Dim carLeft(3) As Boolean
    Dim carDown(3) As Boolean
    Dim carUp(3) As Boolean
    Dim dirx(3) As Integer
    Dim diry(3) As Integer
    Dim carLaps(3) As Integer
    Dim carTimes(3) As Double
    Dim carPlace As Integer
    Dim lapTexts() As Label
    Dim timeTexts() As Label
    Dim placeTexts() As Label
    Dim numCars As Integer
    Dim FpadR(3) As Boolean
    Dim FpadL(3) As Boolean
    Dim fastPads() As Label
    Dim slowPads() As Label
    Dim speedBoost(3) As Integer
    Dim allFastPads() As Label
    Dim allSlowPads() As Label
    Dim placeChecks() As Label


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cars = {Car1, Car2, Car3, Car4}
        topBumps = {TopBumper1, TopBumper2, TopBumper3, TopBumper4}
        rightBumps = {RightBumper1, RightBumper2, RightBumper3, RightBumper4}
        bottomBumps = {BottomBumper1, BottomBumper2, BottomBumper3, BottomBumper4}
        leftBumps = {LeftBumper1, LeftBumper2, LeftBumper3, LeftBumper4}
        lapTexts = {car1Laps, car2Laps, car3Laps, car4Laps}
        timeTexts = {carTime1, carTime2, carTime3, carTime4}
        placeTexts = {carPlace1, carPlace2, carPlace3, carPlace4}
        fastPads = {fastPad1, fastPad2, fastPad3, fastPad4}
        slowPads = {slowPad1, slowPad2}
        allFastPads = {fastPad1, fastPad2, fastPad3, fastPad4, fastPadStay1, fastPadStay2, fastPadStay3, fastPadStay4}
        allSlowPads = {slowPad1, slowPad2, slowPadStay1, slowPadStay2}
        placeChecks = {PlaceCheck1, PlaceCheck2}
        For i = 0 To 1
            FpadL(i) = True
        Next
        For i = 2 To 3
            FpadR(i) = True
        Next
        For i = 0 To 3
            carLaps(i) = 0
            carRight(i) = True
            speedBoost(i) = 0
        Next
        numLaps = 0

    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i = 0 To 3
            dirx(i) = rnum.Next(1, 16)
            diry(i) = rnum.Next(1, 16)
            If carRight(i) = True Then
                cars(i).Left = cars(i).Left + dirx(i) + speedBoost(i)
                If cars(i).Bounds.IntersectsWith(rightBumps(i).Bounds) Then
                    carRight(i) = False
                    carDown(i) = True
                    cars(i).Height = 35
                    cars(i).Width = 15
                End If
            End If
            If carDown(i) = True Then
                cars(i).Top = cars(i).Top + diry(i) + speedBoost(i)
                If cars(i).Bounds.IntersectsWith(bottomBumps(i).Bounds) Then
                    carDown(i) = False
                    carLeft(i) = True
                    cars(i).Height = 15
                    cars(i).Width = 35
                End If
            End If
            If carLeft(i) = True Then
                cars(i).Left = cars(i).Left - dirx(i) - speedBoost(i)
                If cars(i).Bounds.IntersectsWith(leftBumps(i).Bounds) Then
                    carLeft(i) = False
                    carUp(i) = True
                    cars(i).Height = 35
                    cars(i).Width = 15
                End If
            End If
            If carUp(i) = True Then
                cars(i).Top = cars(i).Top - diry(i) - speedBoost(i)
                If numLaps > carLaps(i) And cars(i).Bounds.IntersectsWith(topBumps(i).Bounds) Then
                    carUp(i) = False
                    carRight(i) = True
                    cars(i).Height = 15
                    cars(i).Width = 35
                    carLaps(i) = carLaps(i) + 1
                    lapTexts(i).Text = carLaps(i)
                    timeTexts(i).Text = carLaps(i)
                ElseIf numLaps = carLaps(i) And cars(i).Bounds.IntersectsWith(topBumps(i).Bounds) Then
                    carUp(i) = False
                    finished(i) = True
                    carLaps(i) = carLaps(i) + 1
                    lapTexts(i).Text = carLaps(i)
                End If
            End If
            For j = 0 To 7
                If cars(i).Bounds.IntersectsWith(allFastPads(j).Bounds) Then
                    speedBoost(i) = 15

                Else
                    speedBoost(i) = 0
                End If
            Next
        Next

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        For i = 0 To 3
            If finished(i) = False Then
                carTimes(i) = carTimes(i) + 0.1
                timeTexts(i).Text = Math.Round(carTimes(i), 1)
            End If
        Next
    End Sub

    Private Sub CarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CarToolStripMenuItem.Click
        numCars = 1
    End Sub

    Private Sub CarsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CarsToolStripMenuItem.Click
        numCars = 2
    End Sub

    Private Sub CarsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CarsToolStripMenuItem1.Click
        numCars = 3
    End Sub

    Private Sub CarsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CarsToolStripMenuItem2.Click
        numCars = 4
    End Sub

    Private Sub RedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedToolStripMenuItem.Click
        Car1.BackColor = Color.Red
    End Sub

    Private Sub BlueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem.Click
        Car1.BackColor = Color.Orange
    End Sub

    Private Sub OrangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrangeToolStripMenuItem.Click
        Car1.BackColor = Color.Yellow
    End Sub

    Private Sub GreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreenToolStripMenuItem.Click
        Car1.BackColor = Color.Green
    End Sub

    Private Sub BlueToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem1.Click
        Car1.BackColor = Color.Blue
    End Sub

    Private Sub PurpleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurpleToolStripMenuItem.Click
        Car1.BackColor = Color.Purple
    End Sub

    Private Sub PinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PinkToolStripMenuItem.Click
        Car1.BackColor = Color.Pink
    End Sub

    Private Sub GoldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoldToolStripMenuItem.Click
        Car1.BackColor = Color.Gold
    End Sub

    Private Sub RedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RedToolStripMenuItem1.Click
        Car2.BackColor = Color.Red
    End Sub

    Private Sub OrangeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrangeToolStripMenuItem1.Click
        Car2.BackColor = Color.Orange
    End Sub

    Private Sub YellowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YellowToolStripMenuItem.Click
        Car2.BackColor = Color.Yellow
    End Sub

    Private Sub GreenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GreenToolStripMenuItem1.Click
        Car2.BackColor = Color.Green
    End Sub

    Private Sub BlueToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem2.Click
        Car2.BackColor = Color.Blue
    End Sub

    Private Sub PurpleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PurpleToolStripMenuItem1.Click
        Car2.BackColor = Color.Purple
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        For i = 0 To 1
            If FpadL(i) = True Then
                fastPads(i).Left = fastPads(i).Left - 1
                If fastPads(i).Bounds.IntersectsWith(RightBumper3.Bounds) Then
                    FpadL(i) = False
                    FpadR(i) = True
                End If
            End If
            If FpadR(i) = True Then
                fastPads(i).Left = fastPads(i).Left + 1
                If fastPads(i).Bounds.IntersectsWith(RightBumper1.Bounds) Then
                    FpadL(i) = True
                    FpadR(i) = False
                End If
            End If
        Next
        For i = 2 To 3
            If FpadL(i) = True Then
                fastPads(i).Left = fastPads(i).Left - 1
                If fastPads(i).Bounds.IntersectsWith(LeftBumper1.Bounds) Then
                    FpadL(i) = False
                    FpadR(i) = True
                End If
            End If
            If FpadR(i) = True Then
                fastPads(i).Left = fastPads(i).Left + 1
                If fastPads(i).Bounds.IntersectsWith(LeftBumper3.Bounds) Then
                    FpadL(i) = True
                    FpadR(i) = False
                End If
            End If
        Next
    End Sub

    Private Sub LapsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LapsToolStripMenuItem.Click
        numLaps = 2
    End Sub

    Private Sub LapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LapToolStripMenuItem.Click
        numLaps = 0
    End Sub

    Private Sub LapsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LapsToolStripMenuItem1.Click
        numLaps = 4
    End Sub

    Private Sub LapsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles LapsToolStripMenuItem2.Click
        numLaps = 9
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        For i = 0 To 1
            FpadL(i) = True
            FpadR(i) = False
        Next
        For i = 2 To 3
            FpadR(i) = True
            FpadL(i) = False
        Next
        For i = 0 To 3
            carLaps(i) = 0
            carRight(i) = True
            speedBoost(i) = 0
            carTimes(i) = 0
            timeTexts(i).Text = carTimes(i)
            lapTexts(i).Text = carLaps(i)
            carPlace = 0
            placeTexts(i).Text = carPlace
        Next
    End Sub

    Private Sub Timer4_Tick_1(sender As Object, e As EventArgs) Handles Timer4.Tick
        For i = 0 To 3
            For b = 0 To 1
                If cars(i).Bounds.IntersectsWith(placeChecks(b).Bounds) Then
                    carPlace = carPlace
                End If
            Next
        Next
    End Sub
End Class
'Car 1 starting position: 461, 47
'Car 2 staring position: 372, 82
'Car 3 starting position: 269, 117
'Car 4 staring position: 163, 152