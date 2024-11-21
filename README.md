
# 🌞 Eazy - Calculadora de Energia Elétrica para Energia Solar 🌱

Bem-vindo ao **Eazy**! Um projeto desenvolvido para ajudar você a gerenciar seus gastos com energia elétrica e fornecer insights sobre a economia ao adotar energia solar. 💡

## 📚 **Sobre o Projeto**
Todos nós já sentimos a necessidade de gerenciar nossas contas de forma fácil, mas criar uma planilha cheia de fórmulas pode ser complicado! Pensando nisso, e visando uma vida mais sustentável, criamos o **Eazy** — uma plataforma gratuita que permite o usuário ter controle sobre seus gastos com energia elétrica. Além disso, nossa calculadora fornece insights detalhados sobre a economia que pode ser alcançada a longo prazo com o uso de energia solar. 🌍🔋

### 🌟 **Relevância**
O **Eazy** aborda a questão do consumo elevado e desperdício de energia devido à falta de monitoramento. Com nossa solução, queremos:
- Melhorar a qualidade de vida dos usuários.
- Promover o uso de fontes de energia renováveis.
- Conscientizar sobre o consumo consciente de energia.

## 🛠️ **Tecnologias Utilizadas**
- **Backend:** C# com Entity Framework
- **Banco de Dados:** Migrations configuradas com Entity Framework
- **Frontend:** Interface Web usando o padrão MVC
- **Banco de Dados:** Oracle
- **Metodologia:** MVC para estruturação da interface web

## 🚀 **Funcionalidades Principais**
- 📊 **Cálculo de Consumo Elétrico:** Insira seu consumo de energia elétrica e veja a previsão de economia ao adotar energia solar.
- 🌱 **Economia Sustentável:** Compare seus gastos atuais com uma projeção de gastos usando energia solar.
- 📈 **Insights Financeiros:** Obtenha dicas e relatórios sobre como reduzir seus custos e poupar dinheiro.

## 📝 **Como Usar**
## Instruções de Instalação e Configuração

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/ThaiisRibeiro/DotnetGlobalSolution
   cd DotnetGlobalSolution
   ```

2. **Configuração do Banco de Dados:**
   - Crie o banco de dados no Oracle.
   - Configure a string de conexão no arquivo `Context` e `Program` da aplicação:
     
     ```csharp
     private string GetStringConectionConfig()
     {
         string strCon = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";
         return strCon;
     }
     ```

3. **Aplicação das Migrations:**
   - Execute as migrations para criar as tabelas necessárias:
     ```bash
     Add-Migration Nome_do_seu_BD
     Update-Database Nome_do_seu_BD
     ```

4. **Executar a Aplicação:**
   - Inicie o servidor com:
     ```bash
     dotnet run
     ```

---
