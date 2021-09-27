const ParkingHandler = require('./ParkingHandler');

class ParkingCommandHandler {
    constructor(handler) {
        this.handler = handler;
    }

    handle_command(command, command_first_value, command_second_value) {
        // console.log(`Received Command: ${command}, Value: ${command_value}`);
        if (command === "create_parking_lot") {
            this.handler.createParkingLot(command_first_value.trim());
        } else if (command === "park") {
            this.handler.park(command_first_value.trim());
        }
        else if (command === "leave") {
            this.handler.leave(command_first_value.trim(), command_second_value);
        }
        else if (command === "status") {
            this.handler.status();
        }
    }
}

module.exports = ParkingCommandHandler;