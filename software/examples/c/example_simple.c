#include <stdio.h>

#include "ip_connection.h"
#include "bricklet_analog_in_v2.h"

#define HOST "localhost"
#define PORT 4223
#define UID "XYZ" // Change XYZ to the UID of your Analog In Bricklet 2.0

int main(void) {
	// Create IP connection
	IPConnection ipcon;
	ipcon_create(&ipcon);

	// Create device object
	AnalogInV2 ai;
	analog_in_v2_create(&ai, UID, &ipcon);

	// Connect to brickd
	if(ipcon_connect(&ipcon, HOST, PORT) < 0) {
		fprintf(stderr, "Could not connect\n");
		return 1;
	}
	// Don't use device before ipcon is connected

	// Get current voltage (unit is mV)
	uint16_t voltage;
	if(analog_in_v2_get_voltage(&ai, &voltage) < 0) {
		fprintf(stderr, "Could not get voltage, probably timeout\n");
		return 1;
	}

	printf("Voltage: %f V\n", voltage/1000.0);

	printf("Press key to exit\n");
	getchar();
	analog_in_v2_destroy(&ai);
	ipcon_destroy(&ipcon); // Calls ipcon_disconnect internally
	return 0;
}
