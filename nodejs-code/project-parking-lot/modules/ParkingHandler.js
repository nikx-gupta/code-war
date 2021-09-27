class ParkingHandler {
    constructor(logger, rateOpt) {
        this.logger = logger;
        this.rateOpt = rateOpt;
    }

    createParkingLot(capacity) {
        this.capacity = capacity;
        this.parkArr = new Map();
        this.logger.log(`Created parking lot with ${this.capacity} slots`);
    }


    park(reg_no) {
        let nearestSlot = this.getNearestSlot();
        if (nearestSlot === -1) {
            this.logger.log("Sorry, parking lot is full");
            return;
        }

        this.parkArr.set(nearestSlot, { reg: reg_no, time: new Date() });
        this.logger.log(`Allocated slot number: ${nearestSlot + 1}`);
    }

    leave(reg_no, hours) {
        var foundEntryAt = -1;

        for (const entry of this.parkArr.entries()) {
            // this.logger.log(entry[1].reg);
            // this.logger.log(entry[1].reg === reg_no);
            if (entry[1].reg === reg_no) {
                foundEntryAt = entry[0];
                break;
            }
        }

        if (foundEntryAt === -1) {
            this.logger.log(`Registration number ${reg_no} not found`);
            return;
        }

        var entry = this.parkArr.get(foundEntryAt);
        var fee = this.calculateFee(hours);
        this.parkArr.delete(foundEntryAt);
        this.logger.log(`Registration number ${entry.reg} with Slot Number ${foundEntryAt + 1} is free with Charge ${fee}`);
    }

    status() {
        var output = 'Slot No.    Registration No.\n';
        for (let i = 0; i < this.capacity; i++) {
            if (this.parkArr.has(i)) {
                let entry = this.parkArr.get(i);
                output += `${i + 1}           ${entry.reg}\n`;
            }
        }

        this.logger.log(output.slice(0, output.length - 1));
    }

    calculateFee(hours) {
        return hours > 2 ? ((this.rateOpt.firstTwoHours) + ((hours - 2) * this.rateOpt.general)) : this.rateOpt.firstTwoHours;
    }

    getNearestSlot() {
        for (let i = 0; i < this.capacity; i++) {
            if (!this.parkArr.has(i)) {
                return i;
            }
        }

        return -1;
    }
}

module.exports = ParkingHandler;