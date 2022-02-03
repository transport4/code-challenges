import axios from "axios"

export async function get(i: any)
{
    const r = { name: null, starships: [""] }

    const res = await axios.get(`https://swapi.dev/api/people/${i}/`);

    if(res != undefined){
        if(res.data != undefined) { r.name = res.data.name; }

    const res2 = await axios.get(`https://swapi.dev/api/people/${i}/`);

    if(res2 != undefined){ 
        if(res2.data != undefined) {
            res2.data.starships.forEach((s: string) => {
                r.starships.push(s);
            });
        }
    }

    if(r != null) { return r; }
    else
    {
        throw new Error("Could not get name and starships");
    }
}

}
