Imports System
Imports Tinkerforge

Module ExampleCallback
    Const HOST As String = "localhost"
    Const PORT As Integer = 4223
    Const UID As String = "XYZ" ' Change XYZ to the UID of your Analog In Bricklet 2.0

    ' Callback subroutine for voltage callback
    Sub VoltageCB(ByVal sender As BrickletAnalogInV2, ByVal voltage As Integer)
        Console.WriteLine("Voltage: " + (voltage/1000.0).ToString() + " V")
    End Sub

    Sub Main()
        Dim ipcon As New IPConnection() ' Create IP connection
        Dim ai As New BrickletAnalogInV2(UID, ipcon) ' Create device object

        ipcon.Connect(HOST, PORT) ' Connect to brickd
        ' Don't use device before ipcon is connected

        ' Register voltage callback to subroutine VoltageCB
        AddHandler ai.VoltageCallback, AddressOf VoltageCB

        ' Set period for voltage callback to 1s (1000ms)
        ' Note: The voltage callback is only called every second
        '       if the voltage has changed since the last call!
        ai.SetVoltageCallbackPeriod(1000)

        Console.WriteLine("Press key to exit")
        Console.ReadLine()
        ipcon.Disconnect()
    End Sub
End Module
