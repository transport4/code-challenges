import axios from "axios"

export async function getStarWarsCharacterName(id: Number) {

    try
    {
        const response = await axios.get(`https://swapi.dev/api/people/${id}/`);
        return response.data.name as string;
    }
    catch(err)
    {
        throw err;
    }

}

