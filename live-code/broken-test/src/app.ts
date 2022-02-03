import * as data from "./data"

export class StarWarsCharacter 
{
    public async getName(id:number) {
        try
        {
            const characterName = await data.getStarWarsCharacterName(1);
            
            return characterName;
        }
        catch(err)
        {
            throw err;
        }
    }
}


