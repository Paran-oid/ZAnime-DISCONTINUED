import React, { useState, useEffect } from "react";

function CRUDchar() {
    const APIurl = "https://localhost:7221";

    const [characters, setCharacters] = useState([])

    useEffect(() => {
        fetch(APIurl + "/Character/GetAll")
            .then(response => response.json())
            .then(data => setCharacters(data))
            .catch(err => console.log(err))
    }, [])

    return (
        <div>
            <h1>Hello World</h1>
            <ul>
                {characters.map((character, index) => (
                    <li key={index}>{character.id} | {character.name}</li>
                ))}
            </ul>
        </div>

    )
}

export default CRUDchar;