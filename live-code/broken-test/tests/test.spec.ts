import "jest"
import { idText } from "typescript";
import { StarWarsCharacter } from "../src/app"
import * as data from "../src/data";

describe("App", () => {

    let instance: StarWarsCharacter;

    beforeEach(()=> {
        instance = new StarWarsCharacter();
    });

    it("should instantiate a new class of the correct type", async() => {

        expect(instance).toBeInstanceOf(StarWarsCharacter);

    });

    it("should get a Star Wars character name from the Star Wars API", async() => {

        const DarthVaderName = "Darth Vader";

        const characterName = await instance.getName(1);

        expect(characterName).toEqual(DarthVaderName);

    });

    it("should throw an error when the Star Wars API fails", async() => {

        const errorMessage = "Star Wars API Error";
        const mockError = jest.spyOn(data, "getStarWarsCharacterName").mockRejectedValue(new Error(errorMessage));

        try
        {
            await instance.getName(1);
        }
        catch(e:any) {
            expect(e.message).toEqual(errorMessage)
        } 

    });

});

describe("Data", () => {

    

});

