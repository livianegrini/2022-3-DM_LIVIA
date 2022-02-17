// Metodo de teste -  describe('descrição', funcao a ser execuada)

describe('Componente - Rodapé', ()=>{
    // Abrir navegador
    // beforeEach = Antes de tudo
    beforeEach(()=>{
        cy.visit('http://localhost:3000');
    })

    // Descrição
    it('Deve existiri uma tag footer no corpo do documento', ()=>{
        // Pré-Condição

        // Procedimento
        cy.get('footer').should('exist')

        // Resultado Esperado
    })

    it('Deve conter o texto Escola Senai de Informatica', ()=>{
        cy.get('.rodapePrincipal section div p').should('have.text', 'Escola SENAI de Informatica - 2021')
    })

    it('Deve verificar se footer está visivel e se possui uma classe chamada rodapePrincipal', ()=>{
        cy.get('footer').should('be.visible').and('have.class', 'rodapePrincipal')
    })
})