const fs = require('fs');
const readLine = require('readline');

class FileParser {
    constructor(fileName) {
        this.fileName = fileName;
    }

    readFile(callback) {
        let inputFile = readLine.createInterface({
            input: fs.createReadStream(this.fileName)
        });

        inputFile.on('line', callback);
    }

    readCommand(callback) {
        this.readFile((line) => {
            let lineSplit = line.split(' ');
            // console.log(lineSplit);
            callback(lineSplit[0].trim(), lineSplit[1], lineSplit[2]);
        });
    }
}

module.exports = FileParser