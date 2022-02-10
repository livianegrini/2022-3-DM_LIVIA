// faz a importação do pacote axios
import axios from 'axios';

// define a função para chamada das requisições
const api = axios.create({
  // define a URL base das requisições
  baseURL: 'https://6204f8ad161670001741b136.mockapi.io/',
});

// define o padrão de exportação
export default api;