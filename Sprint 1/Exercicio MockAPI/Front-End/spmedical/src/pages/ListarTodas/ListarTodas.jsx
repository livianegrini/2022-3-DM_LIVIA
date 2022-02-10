import { useState, useEffect } from "react";
import axios from "axios";
import { Link } from 'react-router-dom';
import Logo from '../assets/Imagens/logo.png'
import Logout from '../assets/Imagens/logout.png'
import Back from '../assets/Imagens/back.png'
import { useHistory } from "react-router-dom";

export default function MinhasConsultas() {

    const [ListaMinhasConsultas, SetListaMinhasConsultas] = useState([]);
    const history = useHistory();

    function BuscarMinhasConsultas() {

        axios('https://6204f8ad161670001741b136.mockapi.io/Consulta', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-Login')
            }
        })
            .then(Resposta => {
                if (Resposta.status === 200) {
                    console.log(Resposta.data)
                    SetListaMinhasConsultas(Resposta.data)
                };
            })
            .catch(Erro => console.log(Erro));
    };

    useEffect(BuscarMinhasConsultas, []);

    return (
        <div>

            <header>
                <div className="HeaderListarTodas">
                    <img className="ImagemLogo" onClick={() => history.push('/CadastrarConsulta')} src={Logo} alt="Imagem do logo" />
                </div>
                <div className="AlinhamnetoLinks">
                    <Link className="BotoesHeaderListarTodas" to='/CadastrarConsulta'>
                        <img className="ImagensHeaderListarTodos" src={Back} alt="Imagem do back" />
                    </Link>
                    <Link className="BotoesHeaderListarTodas" to='/'>
                        <img className="ImagensHeaderListarTodos" onClick={() => localStorage.clear()} src={Logout} alt="Imagem do logout" />
                    </Link>
                </div>
            </header>

            <main className="FundoListarTodos">

                <article className="AlinhamentoDivs">

                    <div className="ContainerCards">
                        {
                            ListaMinhasConsultas.map((MinhasConsultas) => {
                                console.log(MinhasConsultas)
                                return (
                                    <div>
                                        <article className="ConteudoListar">

                                            <div className="ConteudoListarConsulta">

                                                <p className="TituloListarMinhas">Consulta</p>

                                                <div className="ConteudoListarDentro">

                                                    <div className="DataHora">
                                                        <div className="ConteudoLinhas">
                                                            <p className="ChaveListar">
                                                                Data:
                                                            </p>

                                                            <div className="valorListar">
                                                                {Intl.DateTimeFormat("pt-BR", {
                                                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                                                }).format(new Date(MinhasConsultas.DataConsulta))}
                                                            </div>
                                                        </div>

                                                        <div className="ConteudoLinhasHora ListarHora">
                                                            <p className="ChaveListar">
                                                                Hora:
                                                            </p>

                                                            <div className="valorListar">
                                                                {Intl.DateTimeFormat("pt-BR", {
                                                                    hour: 'numeric',minute: 'numeric'
                                                                }).format(new Date(MinhasConsultas.Hora))}
                                                            </div>
                                                        </div>
                                                    </div>



                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Situação:
                                                        </p>

                                                        <div className="valorListar">
                                                            <p>
                                                                Realizada
                                                            </p>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>


                                            <div className="ConteudoEspacamento">
                                                <p className="TituloListarMinhas">Medico</p>

                                                <div className="ConteudoListarConsultaM">

                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Nome:
                                                        </p>

                                                        <div className="valorListar">
                                                            {MinhasConsultas.Medico[0].Nome}
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                            <div className="ConteudoEspacamento">
                                                <p className="TituloListarMinhas">Paciente</p>

                                                <div className="ConteudoListarConsulta">

                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Nome:
                                                        </p>

                                                        <div className="valorListar">
                                                            {MinhasConsultas.Paciente[0].Nome}
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                            <div className="ConteudoEspacamento">
                                                <p className="TituloListarMinhas">Descrição</p>

                                                <div className="ConteudoListarConsulta Descricao">

                                                    <div className="ConteudoLinhas">
                                                        <div className="valorListar" id={"desc" + MinhasConsultas.idConsulta} style={{ display: " " }}>
                                                            {MinhasConsultas.Descricao}
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                        </article>
                                    </div>
                                )
                            })

                        }

                    </div>
                </article>
            </main>

        </div >
    )
};