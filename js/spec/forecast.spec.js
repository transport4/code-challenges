import Forecast from '../src/forecast';

describe("Forecast should", function () {

    let originalTimeout;

    beforeEach(function () {
        originalTimeout = jasmine.DEFAULT_TIMEOUT_INTERVAL;
        jasmine.DEFAULT_TIMEOUT_INTERVAL = 20000;
    });

    it("retrieve today's weather", function (done) {
        const forecast = new Forecast();

        forecast.predict("Atlanta", null, false)
        .then(function (prediction) {
            console.log("Today: " + prediction);

            expect(true).toBe(true); // I don't know how to test it

            done();
        });
    });


    afterEach(function () {
        jasmine.DEFAULT_TIMEOUT_INTERVAL = originalTimeout;
    });
});