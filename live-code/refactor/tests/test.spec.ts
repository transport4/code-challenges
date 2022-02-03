import "jest"
import * as app from "../src/app"

describe("App", () => {

    it("should get a Star Wars character name and starships from the Star Wars API", async() => {

        const nameandships = await app.get(1);

        expect(nameandships).not.toEqual(undefined);
        expect(nameandships).toEqual({
            name: 'Luke Skywalker',
            starships: [
                '',
                'https://swapi.dev/api/starships/12/',
                'https://swapi.dev/api/starships/22/'
            ]
        })

    });

   
});


