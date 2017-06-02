function octave_example_simple()
    more off;

    HOST = "localhost";
    PORT = 4223;
    UID = "XYZ"; % Change XYZ to the UID of your Analog In Bricklet 2.0

    ipcon = javaObject("com.tinkerforge.IPConnection"); % Create IP connection
    ai = javaObject("com.tinkerforge.BrickletAnalogInV2", UID, ipcon); % Create device object

    ipcon.connect(HOST, PORT); % Connect to brickd
    % Don't use device before ipcon is connected

    % Get current voltage (unit is mV)
    voltage = ai.getVoltage();
    fprintf("Voltage: %g V\n", voltage/1000.0);

    input("Press key to exit\n", "s");
    ipcon.disconnect();
end
