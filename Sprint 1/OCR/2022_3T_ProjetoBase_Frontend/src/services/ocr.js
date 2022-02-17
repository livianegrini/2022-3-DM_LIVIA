import axios from "axios";

export const LerConteudoImagem = async (formData) => {

    let resultado;

    await axios({
        method : "POST",
        url : "https://ocr-equipamentos-livia.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data : formData,
        headers : {
            "Content-Type" : "multipart/form-data",
            "Ocp-Apim-Subscription-Key" : "5504d201b85a45f8bb8961ab6ba34511"
        }
    })
    .then(response => {
        console.log(response)
        resultado = LerJSON(response.data);
    })
    .catch(erro => console.log(erro))

    return resultado;
}

export const LerJSON = (obj) => {

    let resultado;

    obj.regions.forEach(regions => {
        regions.lines.forEach(lines => {
            lines.words.forEach(words => {
                if(words.text[0] === "1" &&  words.text[1] === "2"){
                    resultado = words.text;
                }
            })
        })
    });

    return resultado;
}
 