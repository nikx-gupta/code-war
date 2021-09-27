# project-parking-lot

- ### Environment Setup
    - #### Dependencies on external Libraries
        - mocha (for testing)
        - chai (for testing)
        - sinon (for testing)
        - nyx (for code coverage)
    - run `npm install`
- ### For Testing
    - Run `npm run test`
    - Code Coverage is provided as part of test command
- ## For Build and Test
    - Run `npm run build`
    
- ### Modules
    - #### FileParser
        - Parses the input File line by line and seperates commands and values
    - #### ParkingCommandHandler
        - Parses commands passed to it and Pass it to the ParkingHandler invoking respective functions
        - Command validations if any should be done inside this handler
    - #### ParkingHandler
        - Process commands related to parking and writes to the logger

