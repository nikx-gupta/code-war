const fs = require('fs');
const readLine = require('readline');
const path = require('path');
const os = require('os');
const assert = require('assert')
const FileParser = require("../modules/fileParser");

const testFileName = path.join(__dirname, "testParkData.txt")
describe("FileParser", function () {
    it('should read line by line', function () {
        let parser = new FileParser(testFileName);
        let index = 0;
        parser.readFile(line => {
            if (index == 0) {
                assert.ok(line, "CommandName, CommandValue");
                index++;
            } else {
                assert.ok(line, "SecondCommand, SecondCommandValue")
            }
        })
    })

    it('should read command', function () {
        let parser = new FileParser(testFileName);
        let index = 0;
        parser.readCommand((cmd, val) => {
            if (index == 0) {
                assert.ok(cmd, "CommandName");
                assert.ok(val, "CommandValue");
                index++;
            } else {
                assert.ok(cmd, "SecondCommand");
                assert.ok(val, "SecondCommandValue");
            }
        })
    })

    it('should handle three argument in command', function () {
        let parser = new FileParser(testFileName);
        let index = 0;
        parser.readCommand((cmd, va11, val2) => {
            if (index == 2) {
                assert.ok(cmd, "ThirdCommand");
                assert.ok(va11, "val1");
                assert.ok(val2, "val2");
                index++;
            } else {
                index++;
            }
        })
    })
})