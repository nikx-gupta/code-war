const FileParser = require("./modules/fileParser");
const Logger = require("./modules/Logger");
const ParkingCommandHandler  = require("./modules/ParkingCommandHandler");
const ParkingHandler = require('./modules/ParkingHandler');


var fileName = process.argv[2]

// console.log(fileName)
var logger = new Logger();
var rateOpt = {
    firstTwoHours: 10,
    general: 10
};

var fileParser = new FileParser(fileName);
var parkingHandler = new ParkingHandler(logger, rateOpt);
var commandHandler = new ParkingCommandHandler(parkingHandler);
fileParser.readCommand((command, command_value, command_second_value) => {
    // console.log(command, command_value);
    commandHandler.handle_command(command, command_value, command_second_value);
})