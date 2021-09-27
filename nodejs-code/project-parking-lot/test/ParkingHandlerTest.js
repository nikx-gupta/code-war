const path = require('path');
const assert = require('assert')
const chai = require("chai");
const expect = chai.expect;
const sinon = require("sinon");

const ParkingHandler = require("../modules/ParkingHandler");

describe("ParkingHandler", function () {
    it('handle create parking lot command', function () {
        let logger = {
            log: sinon.spy()
        };

        let handler = new ParkingHandler(logger)
        handler.createParkingLot(10)
        expect(logger.log.calledOnce).to.be.true;
        expect(logger.log.firstCall.args[0]).to.equal("Created parking lot with 10 slots");
    })

    describe("park commands", function () {
        it('handle park command', function () {
            let logger = {
                log: sinon.spy()
            };

            let handler = new ParkingHandler(logger)
            handler.createParkingLot(2)
            handler.park("DKL-456")
            handler.park("DPL-456")

            expect(logger.log.calledThrice).to.be.true;
            expect(logger.log.secondCall.args[0]).to.equal("Allocated slot number: 1");
            expect(logger.log.thirdCall.args[0]).to.equal("Allocated slot number: 2");
        })

        it('handle park full', function () {
            let logger = {
                log: sinon.spy()
            };

            let handler = new ParkingHandler(logger)
            handler.createParkingLot(2)
            handler.park("DKL-456")
            handler.park("DPL-456")
            handler.park("NPL-456")

            expect(logger.log.callCount).to.equal(4);
            expect(logger.log.getCalls()[3].args[0]).to.equal("Sorry, parking lot is full");
        })
    });

    describe('leave comamnd', function () {
        var rateOpt = {
            firstTwoHours: 10,
            general: 10
        };

        it('handle leave command not found', function () {
            let logger = {
                log: sinon.spy()
            };

            let handler = new ParkingHandler(logger, rateOpt)
            handler.createParkingLot(2)
            handler.park("DKL-456")
            handler.leave("PKL-456", 2)

            expect(logger.log.thirdCall.args[0]).to.equal('Registration number PKL-456 not found');
        })

        it('handle leave command with 2 hours', function () {
            let logger = {
                log: sinon.spy()
            };

            let handler = new ParkingHandler(logger, rateOpt)
            handler.createParkingLot(2)
            handler.park("DKL-456")
            handler.leave("DKL-456", 2)

            expect(logger.log.thirdCall.args[0]).to.equal('Registration number DKL-456 with Slot Number 1 is free with Charge 10');
        })

        it('handle leave command with 1 hour', function () {
            let logger = {
                log: sinon.spy()
            };

            let handler = new ParkingHandler(logger, rateOpt)
            handler.createParkingLot(2)
            handler.park("DKL-456")
            handler.leave("DKL-456", 1)

            expect(logger.log.thirdCall.args[0]).to.equal('Registration number DKL-456 with Slot Number 1 is free with Charge 10');
        })

        it('handle leave command with 4 hours', function () {
            let logger = {
                log: sinon.spy()
            };

            let handler = new ParkingHandler(logger, rateOpt)
            handler.createParkingLot(2)
            handler.park("DKL-456")
            handler.leave("DKL-456", 4)

            expect(logger.log.thirdCall.args[0]).to.equal('Registration number DKL-456 with Slot Number 1 is free with Charge 30');
        })
    })

    describe("satus command", function () {
        it('handle status', function () {
            let logger = {
                log: sinon.spy()
            };

            let handler = new ParkingHandler(logger, {})
            handler.createParkingLot(2)
            handler.park("DKL-456")
            handler.status();

            var expected_status = `Slot No.    Registration No.\n1           DKL-456`
            expect(logger.log.thirdCall.args[0]).to.equal(expected_status);
        })
    })
})