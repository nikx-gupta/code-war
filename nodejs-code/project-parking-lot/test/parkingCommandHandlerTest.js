const path = require('path');
const assert = require('assert')
const chai = require("chai");
const expect = chai.expect;
const sinon = require("sinon");

const ParkingCommandHandler = require("../modules/ParkingCommandHandler");

describe("ParkingCommandHandler", function () {
    it('should handle park command', function () {
        let parkingHandler = {
            park: sinon.spy()
        }
        
        let handler = new ParkingCommandHandler(parkingHandler)
        handler.handle_command("park", "DKLK")
        expect(parkingHandler.park.calledOnce).to.be.true;
        expect(parkingHandler.park.firstCall.args[0]).to.equal('DKLK');
    })

    it('should handle create parking lot command', function () {
        let parkingHandler = {
            createParkingLot: sinon.spy()
        }
        
        let handler = new ParkingCommandHandler(parkingHandler)
        handler.handle_command("create_parking_lot", "10")
        expect(parkingHandler.createParkingLot.calledOnce).to.be.true;
        expect(parkingHandler.createParkingLot.firstCall.args[0]).to.equal('10');
    })

    it('should handle leave command', function () {
        let parkingHandler = {
            leave: sinon.spy()
        }
        
        let handler = new ParkingCommandHandler(parkingHandler)
        handler.handle_command("leave", "reg_no")
        expect(parkingHandler.leave.calledOnce).to.be.true;
        expect(parkingHandler.leave.firstCall.args[0]).to.equal('reg_no');
    })

    it('should handle status command', function () {
        let parkingHandler = {
            status: sinon.spy()
        }
        
        let handler = new ParkingCommandHandler(parkingHandler)
        handler.handle_command("status")
        expect(parkingHandler.status.calledOnce).to.be.true;
    })
})